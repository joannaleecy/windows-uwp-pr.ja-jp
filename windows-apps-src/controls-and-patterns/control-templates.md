---
author: Jwmsft
Description: "XAML フレームワークで、コントロール テンプレートを作ることによって、コントロールの視覚的構造や視覚的動作をカスタマイズすることができます。"
MS-HAID: dev\_ctrl\_layout\_txt.control\_templates
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "コントロール テンプレート"
ms.assetid: 6E642626-A1D6-482F-9F7E-DBBA7A071DAD
label: Control templates
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 44f272f3c93ab56623897e5d9c801256a12f0a18
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="control-templates"></a><span data-ttu-id="b5c50-104">コントロール テンプレート</span><span class="sxs-lookup"><span data-stu-id="b5c50-104">Control templates</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="b5c50-105">XAML フレームワークで、コントロール テンプレートを作ることによって、コントロールの視覚的構造や視覚的動作をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-105">You can customize a control's visual structure and visual behavior by creating a control template in the XAML framework.</span></span> <span data-ttu-id="b5c50-106">コントロールには、[**Background**](https://msdn.microsoft.com/library/windows/apps/br209395)、[**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414)、[**FontFamily**](https://msdn.microsoft.com/library/windows/apps/br209404) などの多くのプロパティがあり、このプロパティを設定することで、コントロールの外観に関するさまざまな要素を指定できます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-106">Controls have many properties, such as [**Background**](https://msdn.microsoft.com/library/windows/apps/br209395), [**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414), and [**FontFamily**](https://msdn.microsoft.com/library/windows/apps/br209404), that you can set to specify different aspects of the control's appearance.</span></span> <span data-ttu-id="b5c50-107">ただし、これらのプロパティの設定によって変更できる内容は限られています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-107">But the changes that you can make by setting these properties are limited.</span></span> <span data-ttu-id="b5c50-108">[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) クラスを使ってテンプレートを作成することにより、さらに細かいカスタマイズを指定できます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-108">You can specify additional customizations by creating a template using the [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) class.</span></span> <span data-ttu-id="b5c50-109">ここでは、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) コントロールの外観をカスタマイズする **ControlTemplate** の作成方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-109">Here, we show you how to create a **ControlTemplate** to customize the appearance of a [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) control.</span></span>

> <span data-ttu-id="b5c50-110">**重要な API**: [**ControlTemplate クラス**](https://msdn.microsoft.com/library/windows/apps/br209391)、[**Control.Template プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.template.aspx)</span><span class="sxs-lookup"><span data-stu-id="b5c50-110">**Important APIs**: [**ControlTemplate class**](https://msdn.microsoft.com/library/windows/apps/br209391), [**Control.Template property**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.template.aspx)</span></span>


## <a name="custom-control-template-example"></a><span data-ttu-id="b5c50-111">カスタム コントロール テンプレートの例</span><span class="sxs-lookup"><span data-stu-id="b5c50-111">Custom control template example</span></span>


<span data-ttu-id="b5c50-112">既定では、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) コントロールの内容 (**CheckBox** の横に表示される文字列またはオブジェクト) は、選択ボックスの右側に配置され、チェック マークはユーザーがその **CheckBox** を選択したことを示します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-112">By default, a [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) control puts its content (the string or object next to the **CheckBox**) to the right of the selection box, and a check mark indicates that a user selected the **CheckBox**.</span></span> <span data-ttu-id="b5c50-113">これらの特性は、**CheckBox** の視覚的構造や視覚的動作を表します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-113">These characteristics represent the visual structure and visual behavior of the **CheckBox**.</span></span>

<span data-ttu-id="b5c50-114">次の図は、既定の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を使った [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) での `Unchecked`、`Checked`、`Indeterminate` の各状態を示しています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-114">Here's a [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) using the default [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) shown in the `Unchecked`, `Checked`, and `Indeterminate` states.</span></span>

![既定の CheckBox テンプレート](images/templates-checkbox-states-default.png)

<span data-ttu-id="b5c50-116">[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) に対して [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を作成することで、これらの特性を変更できます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-116">You can change these characteristics by creating a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) for the [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316).</span></span> <span data-ttu-id="b5c50-117">たとえば、チェック ボックスの内容を選択ボックスの下に配置し、ユーザーがチェック ボックスをオンにしたことを **X** で示す場合を考えます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-117">For example, if you want the content of the check box to be below the selection box, and you want to use an **X** to indicate that a user selected the check box.</span></span> <span data-ttu-id="b5c50-118">**CheckBox** の **ControlTemplate** に、これらの特性を指定します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-118">You specify these characteristics in the **ControlTemplate** of the **CheckBox**.</span></span>

<span data-ttu-id="b5c50-119">コントロールにカスタム テンプレートを使うには、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) をコントロールの [**Template**](https://msdn.microsoft.com/library/windows/apps/br209465) プロパティに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-119">To use a custom template with a control, assign the [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) to the [**Template**](https://msdn.microsoft.com/library/windows/apps/br209465) property of the control.</span></span> <span data-ttu-id="b5c50-120">ここでは、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) に `CheckBoxTemplate1` という名前の **ControlTemplate** を使います。</span><span class="sxs-lookup"><span data-stu-id="b5c50-120">Here's a [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) using a **ControlTemplate** called `CheckBoxTemplate1`.</span></span> <span data-ttu-id="b5c50-121">**ControlTemplate** の Extensible Application Markup Language (XAML) は、次のセクションで示します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-121">We show the Extensible Application Markup Language (XAML) for the **ControlTemplate** in the next section.</span></span>

```XAML
<CheckBox Content="CheckBox" Template="{StaticResource CheckBoxTemplate1}" IsThreeState="True" Margin="20"/>
```

<span data-ttu-id="b5c50-122">このテンプレートを適用した後で [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) の `Unchecked`、`Checked`、`Indeterminate` の各状態がどのようになるかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-122">Here's how this [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) looks in the `Unchecked`, `Checked`, and `Indeterminate` states after we apply our template.</span></span>

![カスタム CheckBox テンプレート](images/templates-checkbox-states.png)

## <a name="specify-the-visual-structure-of-a-control"></a><span data-ttu-id="b5c50-124">コントロールの視覚的構造の指定</span><span class="sxs-lookup"><span data-stu-id="b5c50-124">Specify the visual structure of a control</span></span>


<span data-ttu-id="b5c50-125">[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を作るときには、いくつかの [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) オブジェクトを組み合わせて 1 つのコントロールを作ります。</span><span class="sxs-lookup"><span data-stu-id="b5c50-125">When you create a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391), you combine [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) objects to build a single control.</span></span> <span data-ttu-id="b5c50-126">**ControlTemplate** には、ルート要素として **FrameworkElement** が 1 つだけ含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="b5c50-126">A **ControlTemplate** must have only one **FrameworkElement** as its root element.</span></span> <span data-ttu-id="b5c50-127">通常、ルート要素には、他の **FrameworkElement** オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-127">The root element usually contains other **FrameworkElement** objects.</span></span> <span data-ttu-id="b5c50-128">オブジェクトの組み合わせによって、コントロールの視覚的構造が作られます</span><span class="sxs-lookup"><span data-stu-id="b5c50-128">The combination of objects makes up the control's visual structure.</span></span>

<span data-ttu-id="b5c50-129">次の XAML は、コントロールの内容を選択ボックスの下に配置するよう指定する、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) 用の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) を作成します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-129">This XAML creates a [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) for a [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) that specifies that the content of the control is below the selection box.</span></span> <span data-ttu-id="b5c50-130">ルート要素は [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) です。</span><span class="sxs-lookup"><span data-stu-id="b5c50-130">The root element is a [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250).</span></span> <span data-ttu-id="b5c50-131">この例では、ユーザーが **CheckBox** をオンにしたことを示す **X** を作成する [**Path**](https://msdn.microsoft.com/library/windows/apps/br243355) と、不確定状態を示す [**Ellipse**](https://msdn.microsoft.com/library/windows/apps/br243343) を指定しています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-131">The example specifies a [**Path**](https://msdn.microsoft.com/library/windows/apps/br243355) to create an **X** that indicates that a user selected the **CheckBox**, and an [**Ellipse**](https://msdn.microsoft.com/library/windows/apps/br243343) that indicates an indeterminate state.</span></span> <span data-ttu-id="b5c50-132">これらの **Path** と **Ellipse** では [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) が 0 に設定されているため、既定ではどちらも表示されません。</span><span class="sxs-lookup"><span data-stu-id="b5c50-132">Note that the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) is set to 0 on the **Path** and the **Ellipse** so that by default, neither appear.</span></span>

```XAML
<ControlTemplate x:Key="CheckBoxTemplate1" TargetType="CheckBox">
    <Border BorderBrush="{TemplateBinding BorderBrush}" 
            BorderThickness="{TemplateBinding BorderThickness}" 
            Background="{TemplateBinding Background}">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="25"/>
            </Grid.RowDefinitions>
            <Rectangle x:Name="NormalRectangle" Fill="Transparent" Height="20" Width="20" 
                       Stroke="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" 
                       StrokeThickness="{ThemeResource CheckBoxBorderThemeThickness}" 
                       UseLayoutRounding="False"/>
            <!-- Create an X to indicate that the CheckBox is selected. -->
            <Path x:Name="CheckGlyph" 
                  Data="M103,240 L111,240 119,248 127,240 135,240 123,252 135,264 127,264 119,257 111,264 103,264 114,252 z" 
                  Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                  FlowDirection="LeftToRight" 
                  Height="14" Width="16" Opacity="0" Stretch="Fill"/>
            <Ellipse x:Name="IndeterminateGlyph" 
                     Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                     Height="8" Width="8" Opacity="0" UseLayoutRounding="False" />
            <ContentPresenter x:Name="ContentPresenter" 
                              ContentTemplate="{TemplateBinding ContentTemplate}" 
                              Content="{TemplateBinding Content}" 
                              Margin="{TemplateBinding Padding}" Grid.Row="1" 
                              HorizontalAlignment="Center" 
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Grid>
    </Border>
</ControlTemplate>
```

## <a name="specify-the-visual-behavior-of-a-control"></a><span data-ttu-id="b5c50-133">コントロールの視覚的動作の指定</span><span class="sxs-lookup"><span data-stu-id="b5c50-133">Specify the visual behavior of a control</span></span>


<span data-ttu-id="b5c50-134">視覚的動作は、コントロールが特定の状態にあるときの外観を指定します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-134">A visual behavior specifies the appearance of a control when it is in a certain state.</span></span> <span data-ttu-id="b5c50-135">[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) コントロールには、`Checked`、`Unchecked`、`Indeterminate` という 3 つのチェック状態があります。</span><span class="sxs-lookup"><span data-stu-id="b5c50-135">The [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) control has 3 check states: `Checked`, `Unchecked`, and `Indeterminate`.</span></span> <span data-ttu-id="b5c50-136">[**IsChecked**](https://msdn.microsoft.com/library/windows/apps/br209798) プロパティの値によって **CheckBox** の状態が決まり、その状態によって、ボックスに何が表示されるかが決まります。</span><span class="sxs-lookup"><span data-stu-id="b5c50-136">The value of the [**IsChecked**](https://msdn.microsoft.com/library/windows/apps/br209798) property determines the state of the **CheckBox**, and its state determines what appears in the box.</span></span>

<span data-ttu-id="b5c50-137">次の表に、考えられる [**IsChecked**](https://msdn.microsoft.com/library/windows/apps/br209798) の値と、対応する [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) の状態および **CheckBox** の外観を示します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-137">This table lists the possible values of [**IsChecked**](https://msdn.microsoft.com/library/windows/apps/br209798), the corresponding states of the [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316), and the appearance of the **CheckBox**.</span></span>

|                     |                    |                         |
|---------------------|--------------------|-------------------------|
| <span data-ttu-id="b5c50-138">**IsChecked** の値</span><span class="sxs-lookup"><span data-stu-id="b5c50-138">**IsChecked** value</span></span> | <span data-ttu-id="b5c50-139">**CheckBox** の状態</span><span class="sxs-lookup"><span data-stu-id="b5c50-139">**CheckBox** state</span></span> | <span data-ttu-id="b5c50-140">**CheckBox** の外観</span><span class="sxs-lookup"><span data-stu-id="b5c50-140">**CheckBox** appearance</span></span> |
| **<span data-ttu-id="b5c50-141">true</span><span class="sxs-lookup"><span data-stu-id="b5c50-141">true</span></span>**            | `Checked`          | <span data-ttu-id="b5c50-142">"X" を表示。</span><span class="sxs-lookup"><span data-stu-id="b5c50-142">Contains an "X".</span></span>        |
| **<span data-ttu-id="b5c50-143">false</span><span class="sxs-lookup"><span data-stu-id="b5c50-143">false</span></span>**           | `Unchecked`        | <span data-ttu-id="b5c50-144">空白。</span><span class="sxs-lookup"><span data-stu-id="b5c50-144">Empty.</span></span>                  |
| **<span data-ttu-id="b5c50-145">null</span><span class="sxs-lookup"><span data-stu-id="b5c50-145">null</span></span>**            | `Indeterminate`    | <span data-ttu-id="b5c50-146">円を表示。</span><span class="sxs-lookup"><span data-stu-id="b5c50-146">Contains a circle.</span></span>      |

 

<span data-ttu-id="b5c50-147">[**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) オブジェクトを使って、コントロールが特定の状態にあるときの外観を指定します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-147">You specify the appearance of a control when it is in a certain state by using [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) objects.</span></span> <span data-ttu-id="b5c50-148">**VisualState** には、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 内の要素の外観を変更する [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br243053) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-148">A **VisualState** contains a [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) or [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br243053) that changes the appearance of the elements in the [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391).</span></span> <span data-ttu-id="b5c50-149">コントロールが [**VisualState.Name**](https://msdn.microsoft.com/library/windows/apps/br209031) プロパティで指定された状態になると、**Setter** または [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) 内のプロパティの変更が適用されます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-149">When the control enters the state that the [**VisualState.Name**](https://msdn.microsoft.com/library/windows/apps/br209031) property specifies, the property changes in the **Setter** or [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) are applied.</span></span> <span data-ttu-id="b5c50-150">コントロールがこの状態でなくなると、変更は削除されます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-150">When the control exits the state, the changes are removed.</span></span> <span data-ttu-id="b5c50-151">**VisualState** オブジェクトは [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/br209014) オブジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-151">You add **VisualState** objects to [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/br209014) objects.</span></span> <span data-ttu-id="b5c50-152">**ControlTemplate** のルート [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) に設定する [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) 添付プロパティに、**VisualStateGroup** オブジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-152">You add **VisualStateGroup** objects to the [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) attached property, which you set on the root [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) of the **ControlTemplate**.</span></span>

<span data-ttu-id="b5c50-153">次の XAML は、`Checked`、`Unchecked`、`Indeterminate` の各状態に対する [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) オブジェクトを示しています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-153">This XAML shows the [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) objects for the `Checked`, `Unchecked`, and `Indeterminate` states.</span></span> <span data-ttu-id="b5c50-154">この例では、[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) のルート要素である [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250) に対して [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) 添付プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-154">The example sets the [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/hh738505) attached property on the [**Border**](https://msdn.microsoft.com/library/windows/apps/br209250), which is the root element of the [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391).</span></span> <span data-ttu-id="b5c50-155">`Checked` **VisualState** は、(前の例で示した) `CheckGlyph` という名前の [**Path**](https://msdn.microsoft.com/library/windows/apps/br243355) の [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) が 1 であることを指定します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-155">The `Checked` **VisualState** specifies that the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) of the [**Path**](https://msdn.microsoft.com/library/windows/apps/br243355) named `CheckGlyph` (which we show in the previous example) is 1.</span></span> <span data-ttu-id="b5c50-156">`Indeterminate` **VisualState** は、`IndeterminateGlyph` という名前の [**Ellipse**](https://msdn.microsoft.com/library/windows/apps/br243343) の **Opacity** が 1 であることを指定します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-156">The `Indeterminate` **VisualState** specifies that the **Opacity** of the [**Ellipse**](https://msdn.microsoft.com/library/windows/apps/br243343) named `IndeterminateGlyph` is 1.</span></span> <span data-ttu-id="b5c50-157">`Unchecked` **VisualState** には [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) または [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) がないため、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) は既定の外観に戻ります。</span><span class="sxs-lookup"><span data-stu-id="b5c50-157">The `Unchecked` **VisualState** has no [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) or [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490), so the [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) returns to its default appearance.</span></span>

```XAML
<ControlTemplate x:Key="CheckBoxTemplate1" TargetType="CheckBox">
    <Border BorderBrush="{TemplateBinding BorderBrush}" 
            BorderThickness="{TemplateBinding BorderThickness}" 
            Background="{TemplateBinding Background}">
            
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="CheckStates">
                <VisualState x:Name="Checked">
                    <VisualState.Setters>
                        <Setter Target="CheckGlyph.Opacity" Value="1"/>
                    </VisualState.Setters>
                    <!-- This Storyboard is equivalent to the Setter. -->
                    <!--<Storyboard>
                        <DoubleAnimation Duration="0" To="1" 
                         Storyboard.TargetName="CheckGlyph" Storyboard.TargetProperty="Opacity"/>
                    </Storyboard>-->
                </VisualState>
                <VisualState x:Name="Unchecked"/>
                <VisualState x:Name="Indeterminate">
                    <VisualState.Setters>
                        <Setter Target="IndeterminateGlyph.Opacity" Value="1"/>
                    </VisualState.Setters>
                    <!-- This Storyboard is equivalent to the Setter. -->
                    <!--<Storyboard>
                        <DoubleAnimation Duration="0" To="1"
                         Storyboard.TargetName="IndeterminateGlyph" Storyboard.TargetProperty="Opacity"/>
                    </Storyboard>-->
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="25"/>
            </Grid.RowDefinitions>
            <Rectangle x:Name="NormalRectangle" Fill="Transparent" Height="20" Width="20" 
                       Stroke="{ThemeResource SystemControlForegroundBaseMediumHighBrush}" 
                       StrokeThickness="{ThemeResource CheckBoxBorderThemeThickness}" 
                       UseLayoutRounding="False"/>
            <!-- Create an X to indicate that the CheckBox is selected. -->
            <Path x:Name="CheckGlyph" 
                  Data="M103,240 L111,240 119,248 127,240 135,240 123,252 135,264 127,264 119,257 111,264 103,264 114,252 z" 
                  Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                  FlowDirection="LeftToRight" 
                  Height="14" Width="16" Opacity="0" Stretch="Fill"/>
            <Ellipse x:Name="IndeterminateGlyph" 
                     Fill="{ThemeResource CheckBoxForegroundThemeBrush}" 
                     Height="8" Width="8" Opacity="0" UseLayoutRounding="False" />
            <ContentPresenter x:Name="ContentPresenter" 
                              ContentTemplate="{TemplateBinding ContentTemplate}" 
                              Content="{TemplateBinding Content}" 
                              Margin="{TemplateBinding Padding}" Grid.Row="1" 
                              HorizontalAlignment="Center" 
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
        </Grid>
    </Border>
</ControlTemplate>
```

<span data-ttu-id="b5c50-158">[**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) オブジェクトの機能をよりよく理解するために、[**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) が `Unchecked` 状態から `Checked` 状態に変化した後、`Indeterminate` 状態に変化してから、`Unchecked` 状態に戻るとき、どのようになるかを考えてみます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-158">To better understand how [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) objects work, consider what happens when the [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) goes from the `Unchecked` state to the `Checked` state, then to the `Indeterminate` state, and then back to the `Unchecked` state.</span></span> <span data-ttu-id="b5c50-159">状態の遷移を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b5c50-159">Here are the transitions.</span></span>

|                                      |                                                                                                                                                                                                                                                                                                                                                |                                                   |
|--------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------|
| <span data-ttu-id="b5c50-160">状態の遷移</span><span class="sxs-lookup"><span data-stu-id="b5c50-160">State transition</span></span>                     | <span data-ttu-id="b5c50-161">動作</span><span class="sxs-lookup"><span data-stu-id="b5c50-161">What happens</span></span>                                                                                                                                                                                                                                                                                                                                   | <span data-ttu-id="b5c50-162">遷移完了時の CheckBox の外観</span><span class="sxs-lookup"><span data-stu-id="b5c50-162">CheckBox appearance when the transition completes</span></span> |
| <span data-ttu-id="b5c50-163">`Unchecked` から `Checked`。</span><span class="sxs-lookup"><span data-stu-id="b5c50-163">From `Unchecked` to `Checked`.</span></span>       | <span data-ttu-id="b5c50-164">`Checked` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 値が適用され、`CheckGlyph` の [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) が 1 となる。</span><span class="sxs-lookup"><span data-stu-id="b5c50-164">The [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) value of the `Checked` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) is applied, so the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) of `CheckGlyph` is 1.</span></span>                                                                                                                                                         | <span data-ttu-id="b5c50-165">X が表示される。</span><span class="sxs-lookup"><span data-stu-id="b5c50-165">An X is displayed.</span></span>                                |
| <span data-ttu-id="b5c50-166">`Checked` から `Indeterminate`。</span><span class="sxs-lookup"><span data-stu-id="b5c50-166">From `Checked` to `Indeterminate`.</span></span>   | <span data-ttu-id="b5c50-167">`Indeterminate` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 値が適用され、`IndeterminateGlyph` の [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) が 1 となる。</span><span class="sxs-lookup"><span data-stu-id="b5c50-167">The [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) value of the `Indeterminate` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) is applied, so the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) of `IndeterminateGlyph` is 1.</span></span> <span data-ttu-id="b5c50-168">`Checked` **VisualState** の **Setter** 値が削除され、`CheckGlyph` の [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br228078) が 0 となる。</span><span class="sxs-lookup"><span data-stu-id="b5c50-168">The **Setter** value of the `Checked` **VisualState** is removed, so the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br228078) of `CheckGlyph` is 0.</span></span> | <span data-ttu-id="b5c50-169">円が表示される。</span><span class="sxs-lookup"><span data-stu-id="b5c50-169">A circle is displayed.</span></span>                            |
| <span data-ttu-id="b5c50-170">`Indeterminate` から `Unchecked`。</span><span class="sxs-lookup"><span data-stu-id="b5c50-170">From `Indeterminate` to `Unchecked`.</span></span> | <span data-ttu-id="b5c50-171">`Indeterminate` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 値が削除され、`IndeterminateGlyph` の [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) が 0 となる。</span><span class="sxs-lookup"><span data-stu-id="b5c50-171">The [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) value of the `Indeterminate` [**VisualState**](https://msdn.microsoft.com/library/windows/apps/br209007) is removed, so the [**Opacity**](https://msdn.microsoft.com/library/windows/apps/br208962) of `IndeterminateGlyph` is 0.</span></span>                                                                                                                                           | <span data-ttu-id="b5c50-172">何も表示されない。</span><span class="sxs-lookup"><span data-stu-id="b5c50-172">Nothing is displayed.</span></span>                             |

 
<span data-ttu-id="b5c50-173">コントロールの表示状態の作成方法、特に、[**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) クラスとアニメーション タイプの使い方について詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/jj819808)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b5c50-173">For more info about how to create visual states for controls, and in particular how to use the [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/br210490) class and the animation types, see [Storyboarded animations for visual states](https://msdn.microsoft.com/library/windows/apps/xaml/jj819808).</span></span>

## <a name="use-tools-to-work-with-themes-easily"></a><span data-ttu-id="b5c50-174">ツールを使ってテーマを簡単に操作</span><span class="sxs-lookup"><span data-stu-id="b5c50-174">Use tools to work with themes easily</span></span>

<span data-ttu-id="b5c50-175">コントロールにテーマをすばやく適用する方法の 1 つは、Microsoft Visual Studio の **[ドキュメント アウトライン]** でコントロールを右クリックし、**[テーマの編集]** または **[スタイルの編集]** (右クリックしたコントロールによって異なる) をクリックすることです。</span><span class="sxs-lookup"><span data-stu-id="b5c50-175">A fast way to apply themes to your controls is to right-click on a control on the Microsoft Visual Studio **Document Outline** and select **Edit Theme** or **Edit Style** (depending on the control you are right-clicking on).</span></span> <span data-ttu-id="b5c50-176">その後、**[リソースの適用]** をクリックして既にあるテーマを適用するか、または **[空アイテムの作成]** をクリックして新しいテーマを定義できます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-176">You can then apply an existing theme by selecting **Apply Resource** or define a new one by selecting **Create Empty**.</span></span>

## <a name="controls-and-accessibility"></a><span data-ttu-id="b5c50-177">コントロールとアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="b5c50-177">Controls and accessibility</span></span>

<span data-ttu-id="b5c50-178">コントロールのテンプレートを新しく作成するときは、コントロールの動作と外見を変更する以外にも、アクセシビリティ フレームワークに対する表現方法も変更することができます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-178">When you create a new template for a control, in addition to possibly changing the control's behavior and visual appearance, you might also be changing how the control represents itself to accessibility frameworks.</span></span> <span data-ttu-id="b5c50-179">ユニバーサル Windows プラットフォーム (UWP) は、アクセシビリティのための Microsoft UI オートメーション フレームワークをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-179">The Universal Windows Platform (UWP) supports the Microsoft UI Automation framework for accessibility.</span></span> <span data-ttu-id="b5c50-180">既定のコントロールとそのテンプレートはいずれも、UI オートメーションの共通のコントロール型と、その目的や機能に合ったパターンをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-180">All of the default controls and their templates have support for common UI Automation control types and patterns that are appropriate for the control's purpose and function.</span></span> <span data-ttu-id="b5c50-181">支援技術などの UI オートメーション クライアントが、これらのコントロール型とパターンを解釈することにより、アクセシビリティ対応アプリの UI という、より大きな枠組みを構成する要素としてコントロールを利用することができます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-181">These control types and patterns are interpreted by UI Automation clients such as assistive technologies, and this enables a control to be accessible as a part of a larger accessible app UI.</span></span>

<span data-ttu-id="b5c50-182">基本的なコントロールのロジックを分離すると共に、UI オートメーションのアーキテクチャに求められるいくつかの要件を満たすために、コントロール クラスのアクセシビリティ機能は、別個のクラス (オートメーション ピア) に置かれています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-182">To separate the basic control logic and also to satisfy some of the architectural requirements of UI Automation, control classes include their accessibility support in a separate class, an automation peer.</span></span> <span data-ttu-id="b5c50-183">オートメーション ピアは、折に触れてコントロール テンプレートと対話します。テンプレート内の特定の名前付きパーツの存在を頼りにその機能 (支援技術によってボタン アクションを呼び出すなど) を実現しているためです。</span><span class="sxs-lookup"><span data-stu-id="b5c50-183">The automation peers sometimes have interactions with the control templates because the peers expect certain named parts to exist in the templates, so that functionality such as enabling assistive technologies to invoke actions of buttons is possible.</span></span>

<span data-ttu-id="b5c50-184">まったく新しいカスタム コントロールを作成するときは、同時に、新しいオートメーション ピアの作成が必要になることもあります。</span><span class="sxs-lookup"><span data-stu-id="b5c50-184">When you create a completely new custom control, you sometimes also will want to create a new automation peer to go along with it.</span></span> <span data-ttu-id="b5c50-185">詳しくは、「[カスタム オートメーション ピア](../accessibility/custom-automation-peers.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b5c50-185">For more info, see [Custom automation peers](../accessibility/custom-automation-peers.md).</span></span>

## <a name="learn-more-about-a-controls-default-template"></a><span data-ttu-id="b5c50-186">コントロールの既定のテンプレートの詳細</span><span class="sxs-lookup"><span data-stu-id="b5c50-186">Learn more about a control's default template</span></span>

<span data-ttu-id="b5c50-187">XAML コントロールのスタイルとテンプレートについて説明するトピックでは、既に説明した **テーマの編集**や**スタイルの編集**の手法を使った場合に見られる、同じ XAML の開始部分を抜粋しています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-187">The topics that document the styles and templates for XAML controls show you excerpts of the same starting XAML you'd see if you used the **Edit Theme** or **Edit Style** techniques explained previously.</span></span> <span data-ttu-id="b5c50-188">各トピックでは、表示状態の名前、使用しているテーマ リソースを示しているほか、テンプレートを含むスタイルの完全な XAML を示しています。</span><span class="sxs-lookup"><span data-stu-id="b5c50-188">Each topic lists the names of the visual states, the theme resources used, and the full XAML for the style that contains the template.</span></span> <span data-ttu-id="b5c50-189">これらのトピックが便利なガイダンスになるのは、テンプレートを変更し始めてから元のテンプレートがどのように見えていたかを確認したり、必要な名前付きの表示状態がすべて新しいテンプレートにあることを確認したりする場合です。</span><span class="sxs-lookup"><span data-stu-id="b5c50-189">The topics can be useful guidance if you've already started modifying a template and want to see what the original template looked like, or to verify that your new template has all of the required named visual states.</span></span>

## <a name="theme-resources-in-control-templates"></a><span data-ttu-id="b5c50-190">コントロール テンプレートのテーマ リソース</span><span class="sxs-lookup"><span data-stu-id="b5c50-190">Theme resources in control templates</span></span>

<span data-ttu-id="b5c50-191">XAML の例を見ると、一部の属性について [{ThemeResource} マークアップ拡張機能](../xaml-platform/themeresource-markup-extension.md) を使うリソース参照があることがわかるでしょう。</span><span class="sxs-lookup"><span data-stu-id="b5c50-191">For some of the attributes in the XAML examples, you may have noticed resource references that use the [{ThemeResource} markup extension](../xaml-platform/themeresource-markup-extension.md).</span></span> <span data-ttu-id="b5c50-192">この手法では、現在アクティブであるテーマに応じて値が変わるリソースを 1 つのコントロール テンプレートで使用できます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-192">This is a technique that enables a single control template to use resources that can be different values depending on which theme is currently active.</span></span> <span data-ttu-id="b5c50-193">この点はブラシと色に特に重要です。システム全体に暗い、明るい、またはハイコントラストのいずれのテーマを適用するかをユーザーが選択できるようにすることが、テーマの主な目的であるためです。</span><span class="sxs-lookup"><span data-stu-id="b5c50-193">This is particularly important for brushes and colors, because the main purpose of the themes is to enable users to choose whether they want a dark, light, or high contrast theme applied to the system overall.</span></span> <span data-ttu-id="b5c50-194">XAML リソース システムを使うアプリはそのテーマに適切な一連のリソースを使用できます。そのため、アプリの UI のテーマの選択にはユーザーのシステム全体のテーマの選択が反映されます。</span><span class="sxs-lookup"><span data-stu-id="b5c50-194">Apps that use the XAML resource system can use a resource set that's appropriate for that theme, so that the theme choices in an app's UI are reflective of the user's systemwide theme choice.</span></span>

 ## <a name="get-the-sample-code"></a><span data-ttu-id="b5c50-195">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="b5c50-195">Get the sample code</span></span>
* [<span data-ttu-id="b5c50-196">XAML UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="b5c50-196">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)
* [<span data-ttu-id="b5c50-197">カスタム テキスト編集コントロールのサンプル</span><span class="sxs-lookup"><span data-stu-id="b5c50-197">Custom text edit control sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/CustomEditControl)

 



