---
author: jwmsft
description: Template settings (テンプレート設定) クラス
title: Template settings (テンプレート設定) クラス
ms.assetid: CAE933C6-EF13-465A-9831-AB003AF23907
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4d7b08138ab22d4cf2cbf4fb5273759f000a7c94
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5552459"
---
# <a name="template-settings-classes"></a><span data-ttu-id="4df16-104">Template settings (テンプレート設定) クラス</span><span class="sxs-lookup"><span data-stu-id="4df16-104">Template settings classes</span></span>


## <a name="prerequisites"></a><span data-ttu-id="4df16-105">前提条件</span><span class="sxs-lookup"><span data-stu-id="4df16-105">Prerequisites</span></span>

<span data-ttu-id="4df16-106">UI にコントロールを追加し、コントロールのプロパティを設定して、イベント ハンドラーをアタッチできることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="4df16-106">We assume that you can add controls to your UI, set their properties, and attach event handlers.</span></span> <span data-ttu-id="4df16-107">アプリにコントロールを追加する方法については、「[コントロールの追加とイベントの処理](https://msdn.microsoft.com/library/windows/apps/mt228345)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4df16-107">For instructions for adding controls to your app, see [Add controls and handle events](https://msdn.microsoft.com/library/windows/apps/mt228345).</span></span> <span data-ttu-id="4df16-108">読者が既定のテンプレートのコピーを作成、編集して、コントロール用のカスタム テンプレートを定義する方法の基本を知っていることも前提にしています。</span><span class="sxs-lookup"><span data-stu-id="4df16-108">We also assume that you know the basics of how to define a custom template for a control by making a copy of the default template and editing it.</span></span> <span data-ttu-id="4df16-109">これについて詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4df16-109">For more info on this, see [Quickstart: Control templates](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374).</span></span>

## <a name="the-scenario-for-templatesettings-classes"></a><span data-ttu-id="4df16-110">**TemplateSettings** クラスのシナリオ</span><span class="sxs-lookup"><span data-stu-id="4df16-110">The scenario for **TemplateSettings** classes</span></span>

<span data-ttu-id="4df16-111">**TemplateSettings** クラスは、コントロールの新しいコントロール テンプレートを定義する際に使用されるプロパティのセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="4df16-111">**TemplateSettings** classes provide a set of properties that are used when you define a new control template for a control.</span></span> <span data-ttu-id="4df16-112">プロパティには、UI 要素の特定部分のサイズのピクセル値などの値があります。</span><span class="sxs-lookup"><span data-stu-id="4df16-112">The properties have values such as pixel measurements for the size of certain UI element parts.</span></span> <span data-ttu-id="4df16-113">これらの値は、通常は上書きまたはアクセスすることが簡単ではないコントロール ロジックから計算した値であることもあります。</span><span class="sxs-lookup"><span data-stu-id="4df16-113">The values are sometimes calculated values that come from control logic that isn't typically easy to override or even access.</span></span> <span data-ttu-id="4df16-114">一部のプロパティには、部分の切り替えとアニメーションを制御する **From** および **To** 値としての目的があるため、関連する **TemplateSettings** プロパティがペアになっています。</span><span class="sxs-lookup"><span data-stu-id="4df16-114">Some of the properties are intended as **From** and **To** values that control transitions and animations of parts, and thus the relevant **TemplateSettings** properties come in pairs.</span></span>

<span data-ttu-id="4df16-115">いくつかの **TemplateSettings** クラスがあります。</span><span class="sxs-lookup"><span data-stu-id="4df16-115">There are several **TemplateSettings** classes.</span></span> <span data-ttu-id="4df16-116">それらすべては [**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) 名前空間に含まれています。</span><span class="sxs-lookup"><span data-stu-id="4df16-116">All of them are in the [**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) namespace.</span></span> <span data-ttu-id="4df16-117">ここでは、クラスの一覧、および関連コントロールの **TemplateSettings** プロパティへのリンクを示します。</span><span class="sxs-lookup"><span data-stu-id="4df16-117">Here's a list of the classes, and a link to the **TemplateSettings** property of the relevant control.</span></span> <span data-ttu-id="4df16-118">この **TemplateSettings** プロパティは、コントロールの **TemplateSettings** 値へのアクセス方法であり、プロパティへのテンプレート バインドを確立することができます。</span><span class="sxs-lookup"><span data-stu-id="4df16-118">This **TemplateSettings** property is how you access the **TemplateSettings** values for the control, and can establish template bindings to its properties:</span></span>

-   <span data-ttu-id="4df16-119">[**ComboBoxTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227752): [**ComboBox.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209364) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-119">[**ComboBoxTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227752): value of [**ComboBox.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209364)</span></span>
-   <span data-ttu-id="4df16-120">[**GridViewItemTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh738499): [**GridViewItem.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh738503) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-120">[**GridViewItemTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh738499): value of [**GridViewItem.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh738503)</span></span>
-   <span data-ttu-id="4df16-121">[**ListViewItemTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh701948): [**ListViewItem.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br242923) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-121">[**ListViewItemTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh701948): value of [**ListViewItem.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br242923)</span></span>
-   <span data-ttu-id="4df16-122">[**ProgressBarTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227856): [**ProgressBar.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227537) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-122">[**ProgressBarTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227856): value of [**ProgressBar.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227537)</span></span>
-   <span data-ttu-id="4df16-123">[**ProgressRingTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh702248): [**ProgressRing.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh702581) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-123">[**ProgressRingTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh702248): value of [**ProgressRing.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh702581)</span></span>
-   <span data-ttu-id="4df16-124">[**SettingsFlyoutTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/dn298721): [**SettingsFlyout.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/dn252826) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-124">[**SettingsFlyoutTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/dn298721): value of [**SettingsFlyout.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/dn252826)</span></span>
-   <span data-ttu-id="4df16-125">[**ToggleSwitchTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209804): [**ToggleSwitch.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209731) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-125">[**ToggleSwitchTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209804): value of [**ToggleSwitch.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209731)</span></span>
-   <span data-ttu-id="4df16-126">[**ToolTipTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209813): [**ToolTip.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227629) の値。</span><span class="sxs-lookup"><span data-stu-id="4df16-126">[**ToolTipTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209813): value of [**ToolTip.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227629)</span></span>

<span data-ttu-id="4df16-127">**TemplateSettings** プロパティは常に、コードではなく XAML で使うことを想定しています。</span><span class="sxs-lookup"><span data-stu-id="4df16-127">**TemplateSettings** properties are always intended to be used in XAML, not code.</span></span> <span data-ttu-id="4df16-128">親コントロールの読み取り専用 **TemplateSettings** プロパティの読み取り専用サブプロパティです。</span><span class="sxs-lookup"><span data-stu-id="4df16-128">They are read-only sub-properties of a read-only **TemplateSettings** property of a parent control.</span></span> <span data-ttu-id="4df16-129">[**Control**](https://msdn.microsoft.com/library/windows/apps/br209390) ベースの新しいクラスを作成し、そのためコントロール ロジックに影響を与える可能性があるカスタム コントロールの高度なシナリオについては、コントロールから再度テンプレートを作成するユーザーに役立つ情報を伝えるために、コントロールにカスタムの **TemplateSettings** プロパティを定義することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4df16-129">For an advanced custom control scenario, where you're creating a new [**Control**](https://msdn.microsoft.com/library/windows/apps/br209390)-based class and thus can influence the control logic, consider defining a custom **TemplateSettings** property on the control in order to communicate info that might be useful for anyone that is re-templating the control.</span></span> <span data-ttu-id="4df16-130">そのプロパティの読み取り専用の値として、テンプレートの測定値、アニメーションの配置などに関係する情報項目ごとに、読み取り専用プロパティを持つコントロールに関連した新しい **TemplateSettings** クラスを定義し、コントロール ロジックを使って初期化されたそのクラスのランタイム インスタンスを呼び出し元に渡します。</span><span class="sxs-lookup"><span data-stu-id="4df16-130">As that property's read-only value, define a new **TemplateSettings** class related to your control that has read-only properties for each of the info items that are relevant for template measurements, animation positioning, and so on, and give callers the runtime instance of that class that's initialized using your control logic.</span></span> <span data-ttu-id="4df16-131">**TemplateSettings** クラスは [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生し、プロパティでプロパティ変更コールバックに依存関係プロパティ システムを使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="4df16-131">**TemplateSettings** classes are derived from [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356), so that the properties can use the dependency property system for property-changed callbacks.</span></span> <span data-ttu-id="4df16-132">ただし、プロパティの依存関係プロパティの識別子はパブリック API として公開されないため、**TemplateSettings** プロパティは、呼び出し元に対して読み取り専用にすることを意図したものです。</span><span class="sxs-lookup"><span data-stu-id="4df16-132">But the dependency property identifiers for the properties aren't exposed as public API, because the **TemplateSettings** properties are meant to be read-only to callers.</span></span>

## <a name="how-to-use-templatesettings-in-a-control-template"></a><span data-ttu-id="4df16-133">コントロール テンプレートで **TemplateSettings** を使う方法</span><span class="sxs-lookup"><span data-stu-id="4df16-133">How to use **TemplateSettings** in a control template</span></span>

<span data-ttu-id="4df16-134">次に示す例は、基盤になる既定の XAML コントロール テンプレートに含まれています。</span><span class="sxs-lookup"><span data-stu-id="4df16-134">Here's an example that comes from the starting default XAML control templates.</span></span> <span data-ttu-id="4df16-135">この特定の例は、[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) の既定のテンプレートを基にしています。</span><span class="sxs-lookup"><span data-stu-id="4df16-135">This particular one is from the default template of [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538):</span></span>

```xml
<Ellipse
    x:Name="E1"
    Style="{StaticResource ProgressRingEllipseStyle}"
    Width="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Height="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Margin="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseOffset}"
    Fill="{TemplateBinding Foreground}"/>
```

<span data-ttu-id="4df16-136">[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) テンプレートの完全な XAML は数百行あり、これは一部のみの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="4df16-136">The full XAML for the [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) template is hundreds of lines, so this is just a tiny excerpt.</span></span> <span data-ttu-id="4df16-137">次の XAML は、進行状況不定の回転アニメーションを示す 6 つの [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) 要素の 1 つであるコントロール部を定義しています。</span><span class="sxs-lookup"><span data-stu-id="4df16-137">This XAML defines a control part that is one of 6 [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) elements that portray the spinning animation for indeterminate progress.</span></span> <span data-ttu-id="4df16-138">開発者は、アニメーションの進行状況を表す円が気に入らない場合は、別のグラフィック プリミティブや別の基本図形を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4df16-138">As a developer, you might not like the circles and might use a different graphics primitive or a different basic shape for how the animation progresses.</span></span> <span data-ttu-id="4df16-139">たとえば、正方形に配置した一連の [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) 要素を使った **ProgressRing** を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4df16-139">For example, you might compose a **ProgressRing** that uses a set of [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) elements arranged in a square instead.</span></span> <span data-ttu-id="4df16-140">その場合、新しいテンプレートの個別の各 **Rectangle** コンポーネントは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="4df16-140">If so, each individual **Rectangle** component of your new template might look like this:</span></span>

```xml
<Rectangle
    x:Name="R1"
    Width="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Height="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Margin="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseOffset}"
    Fill="{TemplateBinding Foreground}"/>
```

<span data-ttu-id="4df16-141">**TemplateSettings** プロパティがここで有用な理由は、[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) の基本的なコントロールのロジックに基づく計算値であることです。</span><span class="sxs-lookup"><span data-stu-id="4df16-141">The reason that the **TemplateSettings** properties are useful here is because they are calculated values coming from the basic control logic of [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538).</span></span> <span data-ttu-id="4df16-142">計算では、**ProgressRing** の [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) および [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) 全体を分割し、テンプレート内のアニメーションの各要素に計算された測定値を割り当てて、テンプレート パーツをコンテンツに合わせてサイズ変更できるようにします。</span><span class="sxs-lookup"><span data-stu-id="4df16-142">The calculation is dividing up the overall [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) and [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) of the **ProgressRing**, and allotting a calculated measurement for each of the motion elements in its templates so that the template parts can size to content.</span></span>

<span data-ttu-id="4df16-143">既定の XAML コントロール テンプレートから抜粋したもう 1 つの使用例を次に示します。ここでは、アニメーションの **From** と **To** であるプロパティ セットのいずれかを示します。</span><span class="sxs-lookup"><span data-stu-id="4df16-143">Here's another example usage from the default XAML control templates, this time showing one of the property sets that are the **From** and **To** of an animation.</span></span> <span data-ttu-id="4df16-144">これは、[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) 既定テンプレートからの抜粋です。</span><span class="sxs-lookup"><span data-stu-id="4df16-144">This is from the [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) default template:</span></span>

```xml
<VisualStateGroup x:Name="DropDownStates">
    <VisualState x:Name="Opened">
        <Storyboard>
            <SplitOpenThemeAnimation
               OpenedTargetName="PopupBorder"
               ContentTargetName="ScrollViewer"
               ClosedTargetName="ContentPresenter"
               ContentTranslationOffset="0"
               OffsetFromCenter="{Binding RelativeSource={RelativeSource TemplatedParent}, 
                 Path=TemplateSettings.DropDownOffset}"
               OpenedLength="{Binding RelativeSource={RelativeSource TemplatedParent}, 
                 Path=TemplateSettings.DropDownOpenedHeight}"
               ClosedLength="{Binding RelativeSource={RelativeSource TemplatedParent},
                 Path=TemplateSettings.DropDownClosedHeight}" />
        </Storyboard>
   </VisualState>
...
</VisualStateGroup>
```

<span data-ttu-id="4df16-145">ここでも、テンプレートの XAML は量が多いため、一部のみを抜粋して示しています。</span><span class="sxs-lookup"><span data-stu-id="4df16-145">Again there is lots of XAML in the template so we only show an excerpt.</span></span> <span data-ttu-id="4df16-146">これは、それぞれ同じ [**ComboBoxTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227752) プロパティを使用する、複数ある状態とテーマのアニメーションのうちの 1 つにすぎません。</span><span class="sxs-lookup"><span data-stu-id="4df16-146">And this is only one of several states and theme animations that each use the same [**ComboBoxTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227752) properties.</span></span> <span data-ttu-id="4df16-147">[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) では、バインドを利用して **ComboBoxTemplateSettings** 値を使うと、テンプレート内の関連アニメーションが共有値に基づく位置で停止および開始し、スムーズに遷移します。</span><span class="sxs-lookup"><span data-stu-id="4df16-147">For [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348), use of the **ComboBoxTemplateSettings** values through bindings enforces that related animations in the template will stop and start at positions that are based on shared values, and thus transition smoothly.</span></span>

<span data-ttu-id="4df16-148">**注:**  **TemplateSettings**値を使用する、コントロール テンプレートの一部としてとき、は、値の型に一致するプロパティを設定することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="4df16-148">**Note** When you do use **TemplateSettings** values as part of your control template, make sure you're setting properties that match the type of the value.</span></span> <span data-ttu-id="4df16-149">そうしないと、バインドのターゲットの型を **TemplateSettings** 値の異なるソース型から変換できるように、バインドの値のコンバーターを作成することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="4df16-149">If not, you might need to create a value converter for the binding so that the target type of the binding can be converted from a different source type of the **TemplateSettings** value.</span></span> <span data-ttu-id="4df16-150">詳しくは、「[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/br209903)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4df16-150">For more info, see [**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/br209903).</span></span>

## <a name="related-topics"></a><span data-ttu-id="4df16-151">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4df16-151">Related topics</span></span>

* [<span data-ttu-id="4df16-152">クイック スタート: コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="4df16-152">Quickstart: Control templates</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)

