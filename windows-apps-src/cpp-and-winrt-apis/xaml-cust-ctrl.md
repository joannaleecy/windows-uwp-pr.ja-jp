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
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2823084"
---
# <a name="xaml-custom-templated-controls-with-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a><span data-ttu-id="7e4f4-105">カスタム (テンプレート) コントロールで XAML [C + +/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span><span class="sxs-lookup"><span data-stu-id="7e4f4-105">XAML custom (templated) controls with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)</span></span>

<span data-ttu-id="7e4f4-106">どこからでも Windows プラットフォーム (UWP) の主要な機能 XAML[コントロール](/uwp/api/windows.ui.xaml.controls.control)の種類に基づいてカスタム コントロールを作成するのには、ユーザー インターフェイス (UI) スタックの柔軟性があります。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-106">One of the most powerful features of the Universal Windows Platform (UWP) is the flexibility that the user-interface (UI) stack provides to create custom controls based on the XAML [Control](/uwp/api/windows.ui.xaml.controls.control) type.</span></span> <span data-ttu-id="7e4f4-107">XAML UI フレームワークでは、[依存関係のカスタム プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)と接続されているプロパティ、および[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)が豊富な機能やカスタマイズ可能なコントロールを作成するは簡単になりますなどの機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-107">The XAML UI framework provides features such as [custom dependency properties](/windows/uwp/xaml-platform/custom-dependency-properties) and attached properties, and [control templates](/windows/uwp/design/controls-and-patterns/control-templates), which make it easy to create feature-rich and customizable controls.</span></span> <span data-ttu-id="7e4f4-108">このトピックでは、手順 C + を使用してカスタム (テンプレート) コントロールを作成する +/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-108">This topic walks you through the steps of creating a custom (templated) control with C++/WinRT.</span></span>

## <a name="create-a-blank-app-bglabelcontrolapp"></a><span data-ttu-id="7e4f4-109">空のアプリ (BgLabelControlApp) を作成します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-109">Create a Blank App (BgLabelControlApp)</span></span>
<span data-ttu-id="7e4f4-110">まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-110">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="7e4f4-111">作成、 **C++ 空のアプリを視覚的な (C + +/WinRT)** プロジェクト、および*BgLabelControlApp*という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-111">Create a **Visual C++ Blank App (C++/WinRT)** project, and name it *BgLabelControlApp*.</span></span>

<span data-ttu-id="7e4f4-112">カスタム (テンプレート) を表すための新しいクラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-112">We're going to author a new class to represent a custom (templated) control.</span></span> <span data-ttu-id="7e4f4-113">同じコンパイル ユニット内のクラスを作成および使用しています。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-113">We're authoring and consuming the class within the same compilation unit.</span></span> <span data-ttu-id="7e4f4-114">クラス インスタンス化この XAML マークアップと理由ランタイム クラスになることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-114">But we want to be able to instantiate this class from XAML markup, and for that reason it's going to be a runtime class.</span></span> <span data-ttu-id="7e4f4-115">また、この作成と使用のどちらにも C++/WinRT を使用します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-115">And we're going to use C++/WinRT to both author and consume it.</span></span>

<span data-ttu-id="7e4f4-116">新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-116">The first step in authoring a new runtime class is to add a new **Midl File (.idl)** item to the project.</span></span> <span data-ttu-id="7e4f4-117">これに `BgLabelControl.idl` という名前をつけます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-117">Name it `BgLabelControl.idl`.</span></span> <span data-ttu-id="7e4f4-118">`BgLabelControl.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-118">Delete the default contents of `BgLabelControl.idl`, and paste in this runtime class declaration.</span></span>

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

<span data-ttu-id="7e4f4-119">上にある一覧では、依存関係のプロパティ (DP) を宣言するときにフォローしているパターンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-119">The listing above shows the pattern that you follow when declaring a dependency property (DP).</span></span> <span data-ttu-id="7e4f4-120">各 DP に 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-120">There are two pieces to each DP.</span></span> <span data-ttu-id="7e4f4-121">まず、[報告](/uwp/api/windows.ui.xaml.dependencyproperty)の種類の読み取り専用の静的なプロパティを宣言します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-121">First, you declare a read-only static property of type [DependencyProperty](/uwp/api/windows.ui.xaml.dependencyproperty).</span></span> <span data-ttu-id="7e4f4-122">DP plus*プロパティ*の名前があります。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-122">It has the name of your DP plus *Property*.</span></span> <span data-ttu-id="7e4f4-123">実装では、この静的なプロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-123">You'll use this static property in your implementation.</span></span> <span data-ttu-id="7e4f4-124">次に、インスタンスの読み取り専用プロパティを宣言するには、DP の名前と種類をします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-124">Second, you declare a read-write instance property with the type and name of your DP.</span></span>

> [!NOTE]
> <span data-ttu-id="7e4f4-125">浮動小数点型と、DP をする場合、[して`double`(`Double` [MIDL 3.0](/uwp/midl-3/)で)。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-125">If you want a DP with a floating-point type, then make it `double` (`Double` in [MIDL 3.0](/uwp/midl-3/)).</span></span> <span data-ttu-id="7e4f4-126">宣言と実装の種類の DP `float` (`Single` midl)、XAML の変更履歴/コメント] では、その DP の値を設定し、エラーが発生して*テキストから 'Windows.Foundation.Single' を作成できませんでした '<NUMBER>'* します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-126">Declaring and implementing a DP of type `float` (`Single` in MIDL), and then setting a value for that DP in XAML markup, results in the error *Failed to create a 'Windows.Foundation.Single' from the text '<NUMBER>'*.</span></span>

<span data-ttu-id="7e4f4-127">ファイルを保存し、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-127">Save the file and build the project.</span></span> <span data-ttu-id="7e4f4-128">ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) が作成されます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-128">During the build process, the `midl.exe` tool is run to create a Windows Runtime metadata file (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) describing the runtime class.</span></span> <span data-ttu-id="7e4f4-129">次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-129">Then, the `cppwinrt.exe` tool is run to generate source code files to support you in authoring and consuming your runtime class.</span></span> <span data-ttu-id="7e4f4-130">これらのファイルには、IDL で宣言する**BgLabelControl**ランタイム クラスの実装を使い始めるときにスタブが含まれます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-130">These files include stubs to get you started implementing the **BgLabelControl** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="7e4f4-131">これらのスタブは `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` と `BgLabelControl.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-131">Those stubs are `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` and `BgLabelControl.cpp`.</span></span>

<span data-ttu-id="7e4f4-132">スタブ ファイル `BgLabelControl.h` と `BgLabelControl.cpp` を `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` からプロジェクト フォルダー `\BgLabelControlApp\BgLabelControlApp\` にコピーします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-132">Copy the stub files `BgLabelControl.h` and `BgLabelControl.cpp` from `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` into the project folder, which is `\BgLabelControlApp\BgLabelControlApp\`.</span></span> <span data-ttu-id="7e4f4-133">**ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-133">In **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="7e4f4-134">コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-134">Right-click the stub files that you copied, and click **Include In Project**.</span></span>

## <a name="implement-the-bglabelcontrol-custom-control-class"></a><span data-ttu-id="7e4f4-135">**BgLabelControl**カスタム コントロール クラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-135">Implement the **BgLabelControl** custom control class</span></span>
<span data-ttu-id="7e4f4-136">ここで、`\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` と `BgLabelControl.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-136">Now, let's open `\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` and `BgLabelControl.cpp` and implement our runtime class.</span></span> <span data-ttu-id="7e4f4-137">[`BgLabelControl.h`キーを設定する既定のスタイル、**ラベル**と**LabelProperty**を実装するコンス、依存関係のプロパティ] の値に変更を処理する**OnLabelChanged**という名前の静的なイベント ハンドラーを追加およびプライベート メンバーを追加します。**LabelProperty**のフィールドには、バックアップを保存します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-137">In `BgLabelControl.h`, change the constructor to set the default style key, implement **Label** and **LabelProperty**, add a static event handler named **OnLabelChanged** to process changes to the value of the dependency property, and add a private member to store the backing field for **LabelProperty**.</span></span>

<span data-ttu-id="7e4f4-138">このチュートリアルでは使用しません**OnLabelChanged**を。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-138">In this walkthrough, we won't be using **OnLabelChanged**.</span></span> <span data-ttu-id="7e4f4-139">あるプロパティ変更コールバックを依存関係のプロパティを登録する方法を確認できるようにします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-139">But it's there so that you can see how to register a dependency property with a property-changed callback.</span></span>

<span data-ttu-id="7e4f4-140">これらを追加した後、`BgLabelControl.h`次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-140">After adding those, your `BgLabelControl.h` looks like this.</span></span>

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

<span data-ttu-id="7e4f4-141">`BgLabelControl.cpp`、次のような静的メンバーを定義します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-141">In `BgLabelControl.cpp`, define the static members like this.</span></span>

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

## <a name="design-the-default-style-for-bglabelcontrol"></a><span data-ttu-id="7e4f4-142">**BgLabelControl**の既定のスタイルをデザインします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-142">Design the default style for **BgLabelControl**</span></span>

<span data-ttu-id="7e4f4-143">**BgLabelControl**はそれ自体の既定のスタイル キーを設定します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-143">In its constructor, **BgLabelControl** sets a default style key for itself.</span></span> <span data-ttu-id="7e4f4-144">** どのような既定のスタイルですか?</span><span class="sxs-lookup"><span data-stu-id="7e4f4-144">But what *is* a default style?</span></span> <span data-ttu-id="7e4f4-145">カスタム (テンプレート) コントロールは、既定のスタイルが必要です&mdash;既定のコントロールのテンプレートが含まれている&mdash;を使用して、コントロールのコンシューマーは、スタイルまたはテンプレートを設定しない場合に表示します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-145">A custom (templated) control needs to have a default style&mdash;containing a default control template&mdash;which it can use to render itself with in case the consumer of the control doesn't set a style and/or template.</span></span> <span data-ttu-id="7e4f4-146">このセクションで、既定のスタイルが含まれているプロジェクトに変更履歴とコメントのファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-146">In this section we'll add a markup file to the project containing our default style.</span></span>

<span data-ttu-id="7e4f4-147">プロジェクト ノード、[新しいフォルダーを作成して、「テーマ」という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-147">Under your project node, create a new folder and name it "Themes".</span></span> <span data-ttu-id="7e4f4-148">`Themes`、 **Visual C**の種類の新しいアイテムを追加する > **XAML** > **XAML ビュー**"Generic.xaml"という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-148">Under `Themes`, add a new item of type **Visual C++** > **XAML** > **XAML View**, and name it "Generic.xaml".</span></span> <span data-ttu-id="7e4f4-149">フォルダーとファイルの名前にする必要が次のような XAML フレームワーク カスタム コントロールの既定のスタイルを検索するためにします。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-149">The folder and file names have to be like this in order for the XAML framework to find the default style for a custom control.</span></span> <span data-ttu-id="7e4f4-150">既定の内容を削除する`Generic.xaml`] の下の変更履歴/コメントに貼り付ける。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-150">Delete the default contents of `Generic.xaml`, and paste in the markup below.</span></span>

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

<span data-ttu-id="7e4f4-151">この例では、既定のスタイルを設定するプロパティは、コントロール テンプレートです。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-151">In this case, the only property that the default style sets is the control template.</span></span> <span data-ttu-id="7e4f4-152">テンプレートは、正方形 (背景を XAML[コントロール](/uwp/api/windows.ui.xaml.controls.control)の種類のすべてのインスタンスが**バック グラウンド**プロパティが連結された)、および (テキストは**BgLabelControl::Label**の依存関係プロパティにバインドされている) テキストの要素から成ります。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-152">The template consists of a square (whose background is bound to the **Background** property that all instances of the XAML [Control](/uwp/api/windows.ui.xaml.controls.control) type have), and a text element (whose text is bound to the **BgLabelControl::Label** dependency property).</span></span>

## <a name="add-an-instance-of-bglabelcontrol-to-the-main-ui-page"></a><span data-ttu-id="7e4f4-153">UI のメイン ページに**BgLabelControl**のインスタンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-153">Add an instance of **BgLabelControl** to the main UI page</span></span>

<span data-ttu-id="7e4f4-154">メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-154">Open `MainPage.xaml`, which contains the XAML markup for our main UI page.</span></span> <span data-ttu-id="7e4f4-155">**ボタン**の要素 ( **StackPanel**) 内の直後後には、次の変更履歴とコメントを追加します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-155">Immediately after the **Button** element (inside the **StackPanel**), add the following markup.</span></span>

```xaml
<local:BgLabelControl Background="Red" Label="Hello, World!"/>
```

<span data-ttu-id="7e4f4-156">また、追加、次にディレクティブ`MainPage.h` **MainPage**の種類 (XAML マークアップと強制コードのコンパイル時の組み合わせ) **BgLabelControl**カスタム コントロールの種類を認識されるようです。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-156">Also, add the following include directive to `MainPage.h` so that the **MainPage** type (a combination of compiling XAML markup and imperative code) is aware of the **BgLabelControl** custom control type.</span></span>

```cppwinrt
// MainPage.h
...
#include "BgLabelControl.h"
...
```

<span data-ttu-id="7e4f4-157">ここでプロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-157">Now build and run the project.</span></span> <span data-ttu-id="7e4f4-158">背景ブラシ、および**BgLabelControl**インスタンスで、変更履歴とコメントのラベルにコントロールの既定のテンプレートをバインドすることが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-158">You'll see that the default control template is binding to the background brush, and to the label, of the **BgLabelControl** instance in the markup.</span></span>

<span data-ttu-id="7e4f4-159">このチュートリアルの C + でカスタム (テンプレート) コントロールの簡単な例が表示されていた +/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-159">This walkthrough showed a simple example of a custom (templated) control in C++/WinRT.</span></span> <span data-ttu-id="7e4f4-160">任意リッチとフル機能は、独自のカスタム コントロールを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-160">You can make your own custom controls arbitrarily rich and full-featured.</span></span> <span data-ttu-id="7e4f4-161">たとえば、カスタム コントロールはフォームの編集可能なデータ グリッドをビデオ プレーヤーの場合、またはビジュアライザー 3D 図形の名前を付けて、複雑なものを取得できます。</span><span class="sxs-lookup"><span data-stu-id="7e4f4-161">For example, a custom control can take the form of something as complicated as an editable data grid, a video player, or a visualizer of 3D geometry.</span></span>

## <a name="important-apis"></a><span data-ttu-id="7e4f4-162">重要な API</span><span class="sxs-lookup"><span data-stu-id="7e4f4-162">Important APIs</span></span>
* [<span data-ttu-id="7e4f4-163">コントロール</span><span class="sxs-lookup"><span data-stu-id="7e4f4-163">Control</span></span>](/uwp/api/windows.ui.xaml.controls.control)
* [<span data-ttu-id="7e4f4-164">DependencyProperty</span><span class="sxs-lookup"><span data-stu-id="7e4f4-164">DependencyProperty</span></span>](/uwp/api/windows.ui.xaml.dependencyproperty)

## <a name="related-topics"></a><span data-ttu-id="7e4f4-165">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7e4f4-165">Related topics</span></span>
* [<span data-ttu-id="7e4f4-166">コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="7e4f4-166">Control templates</span></span>](/windows/uwp/design/controls-and-patterns/control-templates)
* [<span data-ttu-id="7e4f4-167">カスタム依存関係プロパティ</span><span class="sxs-lookup"><span data-stu-id="7e4f4-167">Custom dependency properties</span></span>](/windows/uwp/xaml-platform/custom-dependency-properties)
