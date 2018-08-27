---
author: stevewhims
description: このトピックでは、単純な C キーを使用してカスタム コントロールを作成する手順を +/WinRT します。 独自の豊富な機能やカスタマイズ可能な UI コントロールを作成するのには次の情報で作成できます。
title: C + を使用してカスタム (テンプレート) コントロールを XAML +/WinRT
ms.author: stwhi
ms.date: 08/01/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、標準、c、cpp、winrt、投影、XAML、独自のカスタム テンプレート] コントロール
ms.localizationpriority: medium
ms.openlocfilehash: c108175c66d27b2cdbd910a0f7653ca1befb68e9
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2856972"
---
# <a name="xaml-custom-templated-controls-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>カスタム (テンプレート) コントロールで XAML [C + +/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)

どこからでも Windows プラットフォーム (UWP) の主要な機能 XAML[コントロール](/uwp/api/windows.ui.xaml.controls.control)の種類に基づいてカスタム コントロールを作成するのには、ユーザー インターフェイス (UI) スタックの柔軟性があります。 XAML UI フレームワークでは、[依存関係のカスタム プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)と接続されているプロパティ、および[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)が豊富な機能やカスタマイズ可能なコントロールを作成するは簡単になりますなどの機能を提供します。 このトピックでは、手順 C + を使用してカスタム (テンプレート) コントロールを作成する +/WinRT します。

## <a name="create-a-blank-app-bglabelcontrolapp"></a>空のアプリ (BgLabelControlApp) を作成します。
まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。 作成、 **C++ 空のアプリを視覚的な (C + +/WinRT)** プロジェクト、および*BgLabelControlApp*という名前を付けます。

カスタム (テンプレート) を表すための新しいクラスを作成します。 同じコンパイル ユニット内のクラスを作成および使用しています。 クラス インスタンス化この XAML マークアップと理由ランタイム クラスになることができるようにします。 また、この作成と使用のどちらにも C++/WinRT を使用します。

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

上にある一覧では、依存関係のプロパティ (DP) を宣言するときにフォローしているパターンが表示されます。 各 DP に 2 つがあります。 まず、[報告](/uwp/api/windows.ui.xaml.dependencyproperty)の種類の読み取り専用の静的なプロパティを宣言します。 DP plus*プロパティ*の名前があります。 実装では、この静的なプロパティを使用します。 次に、インスタンスの読み取り専用プロパティを宣言するには、DP の名前と種類をします。

> [!NOTE]
> 浮動小数点型と、DP をする場合、[して`double`(`Double` [MIDL 3.0](/uwp/midl-3/)で)。 宣言と実装の種類の DP `float` (`Single` midl)、XAML の変更履歴/コメント] では、その DP の値を設定し、エラーが発生して*テキストから 'Windows.Foundation.Single' を作成できませんでした '<NUMBER>'* します。

ファイルを保存し、プロジェクトをビルドします。 ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) が作成されます。 次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL で宣言する**BgLabelControl**ランタイム クラスの実装を使い始めるときにスタブが含まれます。 これらのスタブは `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` と `BgLabelControl.cpp` です。

スタブ ファイル `BgLabelControl.h` と `BgLabelControl.cpp` を `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` からプロジェクト フォルダー `\BgLabelControlApp\BgLabelControlApp\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。

## <a name="implement-the-bglabelcontrol-custom-control-class"></a>**BgLabelControl**カスタム コントロール クラスを実装します。
ここで、`\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` と `BgLabelControl.cpp` を開いてランタイム クラスを実装してみましょう。 [`BgLabelControl.h`キーを設定する既定のスタイル、**ラベル**と**LabelProperty**を実装するコンス、依存関係のプロパティ] の値に変更を処理する**OnLabelChanged**という名前の静的なイベント ハンドラーを追加およびプライベート メンバーを追加します。**LabelProperty**のフィールドには、バックアップを保存します。

このチュートリアルでは使用しません**OnLabelChanged**を。 あるプロパティ変更コールバックを依存関係のプロパティを登録する方法を確認できるようにします。

これらを追加した後、`BgLabelControl.h`次のように表示されます。

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

**BgLabelControl**はそれ自体の既定のスタイル キーを設定します。 ** どのような既定のスタイルですか? カスタム (テンプレート) コントロールは、既定のスタイルが必要です&mdash;既定のコントロールのテンプレートが含まれている&mdash;を使用して、コントロールのコンシューマーは、スタイルまたはテンプレートを設定しない場合に表示します。 このセクションで、既定のスタイルが含まれているプロジェクトに変更履歴とコメントのファイルを追加します。

プロジェクト ノード、[新しいフォルダーを作成して、「テーマ」という名前を付けます。 `Themes`、 **Visual C**の種類の新しいアイテムを追加する > **XAML** > **XAML ビュー**"Generic.xaml"という名前を付けます。 フォルダーとファイルの名前にする必要が次のような XAML フレームワーク カスタム コントロールの既定のスタイルを検索するためにします。 既定の内容を削除する`Generic.xaml`] の下の変更履歴/コメントに貼り付ける。

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

この例では、既定のスタイルを設定するプロパティは、コントロール テンプレートです。 テンプレートは、正方形 (背景を XAML[コントロール](/uwp/api/windows.ui.xaml.controls.control)の種類のすべてのインスタンスが**バック グラウンド**プロパティが連結された)、および (テキストは**BgLabelControl::Label**の依存関係プロパティにバインドされている) テキストの要素から成ります。

## <a name="add-an-instance-of-bglabelcontrol-to-the-main-ui-page"></a>UI のメイン ページに**BgLabelControl**のインスタンスを追加します。

メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。 **ボタン**の要素 ( **StackPanel**) 内の直後後には、次の変更履歴とコメントを追加します。

```xaml
<local:BgLabelControl Background="Red" Label="Hello, World!"/>
```

また、追加、次にディレクティブ`MainPage.h` **MainPage**の種類 (XAML マークアップと強制コードのコンパイル時の組み合わせ) **BgLabelControl**カスタム コントロールの種類を認識されるようです。

```cppwinrt
// MainPage.h
...
#include "BgLabelControl.h"
...
```

ここでプロジェクトをビルドして実行します。 背景ブラシ、および**BgLabelControl**インスタンスで、変更履歴とコメントのラベルにコントロールの既定のテンプレートをバインドすることが表示されます。

このチュートリアルの C + でカスタム (テンプレート) コントロールの簡単な例が表示されていた +/WinRT します。 任意リッチとフル機能は、独自のカスタム コントロールを行うことができます。 たとえば、カスタム コントロールはフォームの編集可能なデータ グリッドをビデオ プレーヤーの場合、またはビジュアライザー 3D 図形の名前を付けて、複雑なものを取得できます。

## <a name="important-apis"></a>重要な API
* [コントロール](/uwp/api/windows.ui.xaml.controls.control)
* [DependencyProperty](/uwp/api/windows.ui.xaml.dependencyproperty)

## <a name="related-topics"></a>関連トピック
* [コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)
* [カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)
