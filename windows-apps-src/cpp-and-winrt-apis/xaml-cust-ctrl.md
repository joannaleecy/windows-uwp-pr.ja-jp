---
description: このトピックでは、C++ を使用してシンプルなカスタム コントロールを作成する手順について/WinRT します。 次に、独自の機能が豊富でカスタマイズ可能な UI コントロールを作成する情報に基づいて構築できます。
title: C++/WinRT による XAML カスタム (テンプレート化) コントロール
ms.date: 10/03/2018
ms.topic: article
keywords: windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、XAML で、テンプレート化された、カスタム コントロール
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: e929f217c71a90540803b180e6e79b98802f9c7a
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8347874"
---
# <a name="xaml-custom-templated-controls-with-cwinrt"></a><span data-ttu-id="cb239-105">C++/WinRT による XAML カスタム (テンプレート化) コントロール</span><span class="sxs-lookup"><span data-stu-id="cb239-105">XAML custom (templated) controls with C++/WinRT</span></span>

> [!IMPORTANT]
> <span data-ttu-id="cb239-106">基本的な概念と用語を使用およびでランタイム クラスを作成する方法についての理解をサポートする[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)を参照してください[、C++ での Api の/WinRT](consume-apis.md)と[において、C++ Api の作成/WinRT](author-apis.md)します。</span><span class="sxs-lookup"><span data-stu-id="cb239-106">For essential concepts and terms that support your understanding of how to consume and author runtime classes with [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), see [Consume APIs with C++/WinRT](consume-apis.md) and [Author APIs with C++/WinRT](author-apis.md).</span></span>

<span data-ttu-id="cb239-107">ユニバーサル Windows プラットフォーム (UWP) の最も強力な機能の 1 つは、柔軟性を XAML[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)の種類に基づいてカスタム コントロールを作成するユーザー インターフェイス (UI) スタックを提供します。</span><span class="sxs-lookup"><span data-stu-id="cb239-107">One of the most powerful features of the Universal Windows Platform (UWP) is the flexibility that the user-interface (UI) stack provides to create custom controls based on the XAML [**Control**](/uwp/api/windows.ui.xaml.controls.control) type.</span></span> <span data-ttu-id="cb239-108">XAML UI フレームワークでは、[カスタム依存関係プロパティ](/windows/uwp/xaml-platform/custom-dependency-properties)と添付プロパティ、および[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)では、機能が豊富でカスタマイズ可能なコントロールを作成しやすくなどの機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="cb239-108">The XAML UI framework provides features such as [custom dependency properties](/windows/uwp/xaml-platform/custom-dependency-properties) and attached properties, and [control templates](/windows/uwp/design/controls-and-patterns/control-templates), which make it easy to create feature-rich and customizable controls.</span></span> <span data-ttu-id="cb239-109">このトピックでは、C++ カスタム (テンプレート化) コントロールを作成する手順について/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="cb239-109">This topic walks you through the steps of creating a custom (templated) control with C++/WinRT.</span></span>

## <a name="create-a-blank-app-bglabelcontrolapp"></a><span data-ttu-id="cb239-110">空白のアプリ (BgLabelControlApp) の作成します。</span><span class="sxs-lookup"><span data-stu-id="cb239-110">Create a Blank App (BgLabelControlApp)</span></span>
<span data-ttu-id="cb239-111">まず、Microsoft Visual Studio で、新しいプロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="cb239-111">Begin by creating a new project in Microsoft Visual Studio.</span></span> <span data-ttu-id="cb239-112">**Visual C**を作成 > **Windows ユニバーサル** > **空白のアプリ (、C++/WinRT)** プロジェクト、および*BgLabelControlApp*名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="cb239-112">Create a **Visual C++** > **Windows Universal** > **Blank App (C++/WinRT)** project, and name it *BgLabelControlApp*.</span></span>

<span data-ttu-id="cb239-113">カスタム (テンプレート化) コントロールを表すための新しいクラスを作成しましょう。</span><span class="sxs-lookup"><span data-stu-id="cb239-113">We're going to author a new class to represent a custom (templated) control.</span></span> <span data-ttu-id="cb239-114">同じコンパイル ユニット内のクラスを作成および使用しています。</span><span class="sxs-lookup"><span data-stu-id="cb239-114">We're authoring and consuming the class within the same compilation unit.</span></span> <span data-ttu-id="cb239-115">ただし、このクラス、XAML マークアップからしたいため、ランタイム クラスをインスタンス化できるようにします。</span><span class="sxs-lookup"><span data-stu-id="cb239-115">But we want to be able to instantiate this class from XAML markup, and for that reason it's going to be a runtime class.</span></span> <span data-ttu-id="cb239-116">また、この作成と使用のどちらにも C++/WinRT を使用します。</span><span class="sxs-lookup"><span data-stu-id="cb239-116">And we're going to use C++/WinRT to both author and consume it.</span></span>

<span data-ttu-id="cb239-117">新しいランタイム クラスの作成の最初の手順では、新しい **Midl ファイル (.idl)** 項目をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="cb239-117">The first step in authoring a new runtime class is to add a new **Midl File (.idl)** item to the project.</span></span> <span data-ttu-id="cb239-118">これに `BgLabelControl.idl` という名前をつけます。</span><span class="sxs-lookup"><span data-stu-id="cb239-118">Name it `BgLabelControl.idl`.</span></span> <span data-ttu-id="cb239-119">`BgLabelControl.idl` の既定のコンテンツを削除し、このランタイム クラスの宣言に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="cb239-119">Delete the default contents of `BgLabelControl.idl`, and paste in this runtime class declaration.</span></span>

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

<span data-ttu-id="cb239-120">上記の登録情報は、依存関係プロパティ (DP) を宣言するときに従うパターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="cb239-120">The listing above shows the pattern that you follow when declaring a dependency property (DP).</span></span> <span data-ttu-id="cb239-121">各 DP に 2 つがあります。</span><span class="sxs-lookup"><span data-stu-id="cb239-121">There are two pieces to each DP.</span></span> <span data-ttu-id="cb239-122">まず、 [**DependencyProperty**](/uwp/api/windows.ui.xaml.dependencyproperty)の種類の読み取り専用の静的プロパティを宣言します。</span><span class="sxs-lookup"><span data-stu-id="cb239-122">First, you declare a read-only static property of type [**DependencyProperty**](/uwp/api/windows.ui.xaml.dependencyproperty).</span></span> <span data-ttu-id="cb239-123">DP と*プロパティ*の名前があります。</span><span class="sxs-lookup"><span data-stu-id="cb239-123">It has the name of your DP plus *Property*.</span></span> <span data-ttu-id="cb239-124">実装では、この静的プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="cb239-124">You'll use this static property in your implementation.</span></span> <span data-ttu-id="cb239-125">2 番目に、種類と、DP の名前を使ってインスタンスの読み取り/書き込みプロパティを宣言します。</span><span class="sxs-lookup"><span data-stu-id="cb239-125">Second, you declare a read-write instance property with the type and name of your DP.</span></span>

> [!NOTE]
> <span data-ttu-id="cb239-126">する場合は、DP 浮動小数点型と、しやすく`double`(`Double` [MIDL](/uwp/midl-3/)3.0)。</span><span class="sxs-lookup"><span data-stu-id="cb239-126">If you want a DP with a floating-point type, then make it `double` (`Double` in [MIDL 3.0](/uwp/midl-3/)).</span></span> <span data-ttu-id="cb239-127">宣言と実装の種類の DP `float` (`Single` MIDL で)、エラーの結果の XAML マークアップで、その DP 値を設定および*テキストから 'Windows.Foundation.Single' を作成できませんでした '<NUMBER>'* します。</span><span class="sxs-lookup"><span data-stu-id="cb239-127">Declaring and implementing a DP of type `float` (`Single` in MIDL), and then setting a value for that DP in XAML markup, results in the error *Failed to create a 'Windows.Foundation.Single' from the text '<NUMBER>'*.</span></span>

<span data-ttu-id="cb239-128">ファイルを保存し、プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="cb239-128">Save the file and build the project.</span></span> <span data-ttu-id="cb239-129">ビルド プロセス中に、`midl.exe` ツールが実行されて、ランタイム クラスを記述する Windows ランタイム メタデータ ファイル (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) が作成されます。</span><span class="sxs-lookup"><span data-stu-id="cb239-129">During the build process, the `midl.exe` tool is run to create a Windows Runtime metadata file (`\BgLabelControlApp\Debug\BgLabelControlApp\Unmerged\BgLabelControl.winmd`) describing the runtime class.</span></span> <span data-ttu-id="cb239-130">次に、`cppwinrt.exe` ツールが実行され、ランタイム クラスの作成と使用をサポートするソース コード ファイルが生成されます。</span><span class="sxs-lookup"><span data-stu-id="cb239-130">Then, the `cppwinrt.exe` tool is run to generate source code files to support you in authoring and consuming your runtime class.</span></span> <span data-ttu-id="cb239-131">これらのファイルには、IDL で宣言した**BgLabelControl**ランタイム クラスの実装を開始するためのスタブが含まれます。</span><span class="sxs-lookup"><span data-stu-id="cb239-131">These files include stubs to get you started implementing the **BgLabelControl** runtime class that you declared in your IDL.</span></span> <span data-ttu-id="cb239-132">これらのスタブは `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` と `BgLabelControl.cpp` です。</span><span class="sxs-lookup"><span data-stu-id="cb239-132">Those stubs are `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\BgLabelControl.h` and `BgLabelControl.cpp`.</span></span>

<span data-ttu-id="cb239-133">スタブ ファイル `BgLabelControl.h` と `BgLabelControl.cpp` を `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` からプロジェクト フォルダー `\BgLabelControlApp\BgLabelControlApp\` にコピーします。</span><span class="sxs-lookup"><span data-stu-id="cb239-133">Copy the stub files `BgLabelControl.h` and `BgLabelControl.cpp` from `\BgLabelControlApp\BgLabelControlApp\Generated Files\sources\` into the project folder, which is `\BgLabelControlApp\BgLabelControlApp\`.</span></span> <span data-ttu-id="cb239-134">**ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="cb239-134">In **Solution Explorer**, make sure **Show All Files** is toggled on.</span></span> <span data-ttu-id="cb239-135">コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="cb239-135">Right-click the stub files that you copied, and click **Include In Project**.</span></span>

## <a name="implement-the-bglabelcontrol-custom-control-class"></a><span data-ttu-id="cb239-136">**BgLabelControl**カスタム コントロール クラスを実装します。</span><span class="sxs-lookup"><span data-stu-id="cb239-136">Implement the **BgLabelControl** custom control class</span></span>
<span data-ttu-id="cb239-137">ここで、`\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` と `BgLabelControl.cpp` を開いてランタイム クラスを実装してみましょう。</span><span class="sxs-lookup"><span data-stu-id="cb239-137">Now, let's open `\BgLabelControlApp\BgLabelControlApp\BgLabelControl.h` and `BgLabelControl.cpp` and implement our runtime class.</span></span> <span data-ttu-id="cb239-138">`BgLabelControl.h`、既定のスタイル キーを設定し、**ラベル**と**LabelProperty**実装コンス トラクターを変更、依存関係プロパティの値に変更を処理する**OnLabelChanged**という名前の静的イベント ハンドラーを追加およびプライベート メンバーを追加します。**LabelProperty**のバッキング フィールドを格納します。</span><span class="sxs-lookup"><span data-stu-id="cb239-138">In `BgLabelControl.h`, change the constructor to set the default style key, implement **Label** and **LabelProperty**, add a static event handler named **OnLabelChanged** to process changes to the value of the dependency property, and add a private member to store the backing field for **LabelProperty**.</span></span>

<span data-ttu-id="cb239-139">これらを追加した後、`BgLabelControl.h`ようになります。</span><span class="sxs-lookup"><span data-stu-id="cb239-139">After adding those, your `BgLabelControl.h` looks like this.</span></span>

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

<span data-ttu-id="cb239-140">`BgLabelControl.cpp`、次のように静的メンバーを定義します。</span><span class="sxs-lookup"><span data-stu-id="cb239-140">In `BgLabelControl.cpp`, define the static members like this.</span></span>

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

<span data-ttu-id="cb239-141">このチュートリアルで使用しません**OnLabelChanged**を。</span><span class="sxs-lookup"><span data-stu-id="cb239-141">In this walkthrough, we won't be using **OnLabelChanged**.</span></span> <span data-ttu-id="cb239-142">これは、プロパティ変更コールバックに依存関係プロパティを登録する方法を確認できます。</span><span class="sxs-lookup"><span data-stu-id="cb239-142">But it's there so that you can see how to register a dependency property with a property-changed callback.</span></span> <span data-ttu-id="cb239-143">**OnLabelChanged**の実装では、(基本投影された型は、 **DependencyObject**をここでは) ベースの投影された型から派生投影された型を取得する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="cb239-143">The implementation of **OnLabelChanged** also shows how to obtain a derived projected type from a base projected type (the base projected type is **DependencyObject**, in this case).</span></span> <span data-ttu-id="cb239-144">投影された型を実装する型へのポインターを取得する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="cb239-144">And it shows how to then obtain a pointer to the type that implements the projected type.</span></span> <span data-ttu-id="cb239-145">その 2 つ目の操作が自然のみ可能投影型 (ランタイム クラスを実装するプロジェクト) を実装するプロジェクトでです。</span><span class="sxs-lookup"><span data-stu-id="cb239-145">That second operation will naturally only be possible in the project that implements the projected type (that is, the project that implements the runtime class).</span></span>

> [!NOTE]
> <span data-ttu-id="cb239-146">[**Winrt::from_abi**](/uwp/cpp-ref-for-winrt/from-abi) [**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self)ではなく、上記の依存関係プロパティ変更イベント ハンドラーを呼び出す必要がありますし、後で、Windows SDK バージョン 10.0.17763.0 (Windows 10、バージョン 1809) をインストールしていない場合。</span><span class="sxs-lookup"><span data-stu-id="cb239-146">If you haven't installed the Windows SDK version 10.0.17763.0 (Windows 10, version 1809), or later, then you need to call [**winrt::from_abi**](/uwp/cpp-ref-for-winrt/from-abi) in the dependency property changed event handler above, instead of [**winrt::get_self**](/uwp/cpp-ref-for-winrt/get-self).</span></span>

## <a name="design-the-default-style-for-bglabelcontrol"></a><span data-ttu-id="cb239-147">既定のスタイルに**BgLabelControl**設計します。</span><span class="sxs-lookup"><span data-stu-id="cb239-147">Design the default style for **BgLabelControl**</span></span>

<span data-ttu-id="cb239-148">そのコンス トラクターで**BgLabelControl**は自身の既定のスタイル キーを設定します。</span><span class="sxs-lookup"><span data-stu-id="cb239-148">In its constructor, **BgLabelControl** sets a default style key for itself.</span></span> <span data-ttu-id="cb239-149">どのような*は、* 既定のスタイルかどうか。</span><span class="sxs-lookup"><span data-stu-id="cb239-149">But what *is* a default style?</span></span> <span data-ttu-id="cb239-150">カスタム (テンプレート化) コントロールは、既定のスタイルが必要です&mdash;既定のコントロール テンプレートが含まれている&mdash;するコントロールのコンシューマーは、スタイルやテンプレートを設定しない場合に自身でレンダリングするために使用できます。</span><span class="sxs-lookup"><span data-stu-id="cb239-150">A custom (templated) control needs to have a default style&mdash;containing a default control template&mdash;which it can use to render itself with in case the consumer of the control doesn't set a style and/or template.</span></span> <span data-ttu-id="cb239-151">このセクションで、既定のスタイルを含むプロジェクトに、マークアップ ファイルを追加しますがあります。</span><span class="sxs-lookup"><span data-stu-id="cb239-151">In this section we'll add a markup file to the project containing our default style.</span></span>

<span data-ttu-id="cb239-152">プロジェクト ノード、新しいフォルダーを作成し、"Themes"という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="cb239-152">Under your project node, create a new folder and name it "Themes".</span></span> <span data-ttu-id="cb239-153">`Themes`、 **Visual C**の種類の新しい項目の追加 > **XAML** > **XAML ビュー**にし、"Generic.xaml"という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="cb239-153">Under `Themes`, add a new item of type **Visual C++** > **XAML** > **XAML View**, and name it "Generic.xaml".</span></span> <span data-ttu-id="cb239-154">カスタム コントロールの既定のスタイルを検索する、XAML フレームワークの順序で次のようにする必要は、フォルダーとファイル名。</span><span class="sxs-lookup"><span data-stu-id="cb239-154">The folder and file names have to be like this in order for the XAML framework to find the default style for a custom control.</span></span> <span data-ttu-id="cb239-155">既定のコンテンツを削除`Generic.xaml`、次のマークアップに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="cb239-155">Delete the default contents of `Generic.xaml`, and paste in the markup below.</span></span>

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

<span data-ttu-id="cb239-156">この例では、既定のスタイルを設定する唯一のプロパティは、コントロール テンプレートです。</span><span class="sxs-lookup"><span data-stu-id="cb239-156">In this case, the only property that the default style sets is the control template.</span></span> <span data-ttu-id="cb239-157">テンプレートは、(背景は、XAML[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)型のすべてのインスタンスがある**バック グラウンド**プロパティにバインドされている)、正方形とテキスト要素 (テキストは**BgLabelControl::Label**依存関係プロパティにバインドされている) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="cb239-157">The template consists of a square (whose background is bound to the **Background** property that all instances of the XAML [**Control**](/uwp/api/windows.ui.xaml.controls.control) type have), and a text element (whose text is bound to the **BgLabelControl::Label** dependency property).</span></span>

## <a name="add-an-instance-of-bglabelcontrol-to-the-main-ui-page"></a><span data-ttu-id="cb239-158">UI のメイン ページに**BgLabelControl**のインスタンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="cb239-158">Add an instance of **BgLabelControl** to the main UI page</span></span>

<span data-ttu-id="cb239-159">メイン UI ページの XAML マークアップが含まれている `MainPage.xaml` を開きます。</span><span class="sxs-lookup"><span data-stu-id="cb239-159">Open `MainPage.xaml`, which contains the XAML markup for our main UI page.</span></span> <span data-ttu-id="cb239-160">( **StackPanel**) 内の**ボタン**要素の後すぐには、次のマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="cb239-160">Immediately after the **Button** element (inside the **StackPanel**), add the following markup.</span></span>

```xaml
<local:BgLabelControl Background="Red" Label="Hello, World!"/>
```

<span data-ttu-id="cb239-161">また、追加、次のディレクティブを含める`MainPage.h` **MainPage**型 (XAML マークアップと命令型コードのコンパイルの組み合わせ) が**BgLabelControl**カスタム コントロールの種類を認識できるようにします。</span><span class="sxs-lookup"><span data-stu-id="cb239-161">Also, add the following include directive to `MainPage.h` so that the **MainPage** type (a combination of compiling XAML markup and imperative code) is aware of the **BgLabelControl** custom control type.</span></span>

```cppwinrt
// MainPage.h
...
#include "BgLabelControl.h"
...
```

<span data-ttu-id="cb239-162">ここでプロジェクトをビルドして実行します。</span><span class="sxs-lookup"><span data-stu-id="cb239-162">Now build and run the project.</span></span> <span data-ttu-id="cb239-163">既定のコントロール テンプレートが、背景ブラシとマークアップで**BgLabelControl**インスタンスのラベルをバインドしているが表示されます。</span><span class="sxs-lookup"><span data-stu-id="cb239-163">You'll see that the default control template is binding to the background brush, and to the label, of the **BgLabelControl** instance in the markup.</span></span>

<span data-ttu-id="cb239-164">このチュートリアルでは、カスタム (テンプレート化) コントロールの単純な例を示した c++/WinRT します。</span><span class="sxs-lookup"><span data-stu-id="cb239-164">This walkthrough showed a simple example of a custom (templated) control in C++/WinRT.</span></span> <span data-ttu-id="cb239-165">任意に豊富な機能をフル機能を備えた、独自のカスタム コントロールを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="cb239-165">You can make your own custom controls arbitrarily rich and full-featured.</span></span> <span data-ttu-id="cb239-166">たとえば、カスタム コントロールには、形式を編集可能なデータ グリッド、ビデオ プレーヤーでは、3 D ジオメトリのビジュアライザーとして何か複雑ながかかります。</span><span class="sxs-lookup"><span data-stu-id="cb239-166">For example, a custom control can take the form of something as complicated as an editable data grid, a video player, or a visualizer of 3D geometry.</span></span>

## <a name="implementing-overridable-functions-such-as-measureoverride-and-onapplytemplate"></a><span data-ttu-id="cb239-167">実装する*オーバーライド* **MeasureOverride** **OnApplyTemplate**などの機能</span><span class="sxs-lookup"><span data-stu-id="cb239-167">Implementing *overridable* functions, such as **MeasureOverride** and **OnApplyTemplate**</span></span>

<span data-ttu-id="cb239-168">カスタム コントロールを派生する基本のランタイム クラスから派生自体もさらに、[**コントロール**](/uwp/api/windows.ui.xaml.controls.control)のランタイム クラスからです。</span><span class="sxs-lookup"><span data-stu-id="cb239-168">You derive a custom control from the [**Control**](/uwp/api/windows.ui.xaml.controls.control) runtime class, which itself further derives from base runtime classes.</span></span> <span data-ttu-id="cb239-169">**コントロール**、 [**FrameworkElement**](/uwp/api/windows.ui.xaml.frameworkelement)、派生クラスで上書きできる[**UIElement**](/uwp/api/windows.ui.xaml.uielement)のオーバーライドの方法があります。</span><span class="sxs-lookup"><span data-stu-id="cb239-169">And there are overridable methods of **Control**, [**FrameworkElement**](/uwp/api/windows.ui.xaml.frameworkelement), and [**UIElement**](/uwp/api/windows.ui.xaml.uielement) that you can override in your derived class.</span></span> <span data-ttu-id="cb239-170">その方法を示すコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="cb239-170">Here's a code example showing you how to do that.</span></span>

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

<span data-ttu-id="cb239-171">*オーバーライド可能*関数には含ま自体が異なるさまざまな言語プロジェクション。</span><span class="sxs-lookup"><span data-stu-id="cb239-171">*Overridable* functions present themselves differently in different language projections.</span></span> <span data-ttu-id="cb239-172">C# では、たとえば、オーバーライド可能な関数通常として表示されます保護されている仮想関数。</span><span class="sxs-lookup"><span data-stu-id="cb239-172">In C#, for example, overridable functions typically appear as protected virtual functions.</span></span> <span data-ttu-id="cb239-173">C++/cli/winrt では、これら仮想も、保護ですが引き続きそれらを上書きし、上記のように、独自の実装を提供できます。</span><span class="sxs-lookup"><span data-stu-id="cb239-173">In C++/WinRT, they're neither virtual nor protected, but you can still override them and provide your own implementation, as shown above.</span></span>

## <a name="important-apis"></a><span data-ttu-id="cb239-174">重要な API</span><span class="sxs-lookup"><span data-stu-id="cb239-174">Important APIs</span></span>
* [<span data-ttu-id="cb239-175">コントロール クラス</span><span class="sxs-lookup"><span data-stu-id="cb239-175">Control class</span></span>](/uwp/api/windows.ui.xaml.controls.control)
* [<span data-ttu-id="cb239-176">DependencyProperty クラス</span><span class="sxs-lookup"><span data-stu-id="cb239-176">DependencyProperty class</span></span>](/uwp/api/windows.ui.xaml.dependencyproperty)
* [<span data-ttu-id="cb239-177">FrameworkElement クラス</span><span class="sxs-lookup"><span data-stu-id="cb239-177">FrameworkElement class</span></span>](/uwp/api/windows.ui.xaml.frameworkelement)
* [<span data-ttu-id="cb239-178">UIElement クラス</span><span class="sxs-lookup"><span data-stu-id="cb239-178">UIElement class</span></span>](/uwp/api/windows.ui.xaml.uielement)

## <a name="related-topics"></a><span data-ttu-id="cb239-179">関連トピック</span><span class="sxs-lookup"><span data-stu-id="cb239-179">Related topics</span></span>
* [<span data-ttu-id="cb239-180">コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="cb239-180">Control templates</span></span>](/windows/uwp/design/controls-and-patterns/control-templates)
* [<span data-ttu-id="cb239-181">カスタム依存関係プロパティ</span><span class="sxs-lookup"><span data-stu-id="cb239-181">Custom dependency properties</span></span>](/windows/uwp/xaml-platform/custom-dependency-properties)
