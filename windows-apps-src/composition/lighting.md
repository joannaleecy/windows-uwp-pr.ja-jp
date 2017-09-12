---
author: jebishop
ms.assetid: fb8ae71d-5c88-4c85-9257-a9607d5179b1
title: "照明"
description: "Light オブジェクトは、動的な照明と反射をシミュレートするために SceneLightingEffect と共に使用されます。"
ms.author: jimwalk
ms.date: 03/29/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: 3f922cae8aa0787f8be6496997df1021dda8e142
ms.sourcegitcommit: b42d14c775efbf449a544ddb881abd1c65c1ee86
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/20/2017
---
# <a name="lighting"></a><span data-ttu-id="60dee-104">照明</span><span class="sxs-lookup"><span data-stu-id="60dee-104">Lighting</span></span>

<span data-ttu-id="60dee-105">[**CompositionLight**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionLight) オブジェクトは、動的な照明と反射をシミュレートするために [**SceneLightingEffect**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) と共に使用されます。</span><span class="sxs-lookup"><span data-stu-id="60dee-105">[**CompositionLight**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionLight) objects are used in conjunction with [**SceneLightingEffect**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) to simulate dynamic lighting and reflectivity.</span></span>

<span data-ttu-id="60dee-106">[**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) と XAML [**UIElement**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) にライトを適用できます。</span><span class="sxs-lookup"><span data-stu-id="60dee-106">You can apply lights to [**Visuals**](https://msdn.microsoft.com/library/windows/apps/Dn706858) and XAML [**UIElements**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement).</span></span>

## <a name="applying-lights-to-xaml-uielements"></a><span data-ttu-id="60dee-107">XAML UIElement へのライトの適用</span><span class="sxs-lookup"><span data-stu-id="60dee-107">Applying lights to XAML UIElements</span></span>

<span data-ttu-id="60dee-108">XAML UIElement に動的なライトを適用するには、[**XamlLight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamllight) オブジェクトを使用して [**CompositionLight**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionLight) を適用します。</span><span class="sxs-lookup"><span data-stu-id="60dee-108">[**XamlLight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamllight) objects are used to apply [**CompositionLights**](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionLight) to dynamically light XAML UIElements.</span></span> <span data-ttu-id="60dee-109">XamlLight には、ターゲットの UIElement やその他の XAML Brush を指定するメソッド、UIElement のツリーにライトを適用するメソッド、現在使用されているかどうかに基づいて CompositionLight リソースの有効期間を管理するためのメソッドが用意されています。</span><span class="sxs-lookup"><span data-stu-id="60dee-109">XamlLight provides methods for targeting UIElements or other XAML Brushes, applying lights to trees of UIElements, and helping manage the lifetime of CompositionLight resources based on whether they're currently in use.</span></span>

* <span data-ttu-id="60dee-110">XamlLight で **Brush** をターゲットにする場合、その Brush 使用している任意の UIElement の部分がライトによって照らされます。</span><span class="sxs-lookup"><span data-stu-id="60dee-110">If you target a **Brush** with a XamlLight then the portions of any UIElements using that Brush are lit by the light.</span></span>
* <span data-ttu-id="60dee-111">XamlLight で **UIElement** をターゲットにする場合、UIElement 全体とその子 UIElement がライトによって照らされます。</span><span class="sxs-lookup"><span data-stu-id="60dee-111">If you target a **UIElement** with a XamlLight then the entire UIElement and its child UIElements are all lit by the light.</span></span>

## <a name="creating-and-using-a-xamllight"></a><span data-ttu-id="60dee-112">XamlLight の作成と使用</span><span class="sxs-lookup"><span data-stu-id="60dee-112">Creating and using a XamlLight</span></span>

<span data-ttu-id="60dee-113">[**XamlLight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamllight) は、カスタム ライトを作成するために使用できる基底クラスです。</span><span class="sxs-lookup"><span data-stu-id="60dee-113">[**XamlLight**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamllight) is a base class which can be used to create custom lights.</span></span>

<span data-ttu-id="60dee-114">特定の要素を対象とする添付プロパティを使用するカスタム XamlLight の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="60dee-114">Here is an example of a custom XamlLight that uses an attached property to target specific elements:</span></span>

```csharp
public sealed class FancyOrangeSpotLight : XamlLight
{
    // Register an attached proeprty that enables apps to set a UIElement or Brush as a target for this light type in markup.
    public static readonly DependencyProperty IsTargetProperty =
        DependencyProperty.RegisterAttached(
        "IsTarget",
        typeof(Boolean),
        typeof(FancyOrangeSpotLight),
        new PropertyMetadata(null, OnIsTargetChanged)
    );
    public static void SetIsTarget(DependencyObject target, Boolean value)
    {
        target.SetValue(IsTargetProperty, value);
    }
    public static Boolean GetIsTarget(DependencyObject target)
    {
        return (Boolean) target.GetValue(IsTargetProperty);
    }

    // Handle attached property changed to automatically target and untarget UIElements and Brushes.
    private static void OnIsTargetChanged(DependencyObject obj,
                                            DependencyPropertyChangedEventArgs e)
    {
        var isAdding = (Boolean)e.NewValue;

        if (isAdding)
        {
            if (obj is UIElement)
            {
                XamlLight.AddTargetElement(GetIdStatic(), obj as UIElement);
            }
            else if (obj is Brush)
            {
                XamlLight.AddTargetBrush(GetIdStatic(), obj as Brush);
            }
        }
        else
        {
            if (obj is UIElement)
            {
                XamlLight.RemoveTargetElement(GetIdStatic(), obj as UIElement);
            }
            else if (obj is Brush)
            {
                XamlLight.RemoveTargetBrush(GetIdStatic(), obj as Brush);
            }
        }
    }

    protected override void OnConnected(UIElement newElement)
    {
        // OnConnected is called when the first target UIElement is shown on the screen. This enables delaying composition object creation until it's actually necessary.
        CompositionLight = Window.Current.Compositor.CreateSpotLight();
        CompositionLight.InnerConeColor = Colors.Orange;
        CompositionLight.OuterConeColor = Colors.Yellow;
        CompositionLight.InnerConeAngleInDegrees = 30;
        CompositionLight.OuterConeAngleInDegrees = 45;
    }

    protected override void OnDisconnected(UIElement oldElement)
    {
        // OnDisconnected is called when there are no more target UIElements on the screen. The CompositionLight should be disposed when no longer required.
        CompositionLight.Dispose();
        CompositionLight = null;
    }

    protected override string GetId()
    {
        return GetIdStatic();
    }

    private static string GetIdStatic()
    {
        // This specifies the unique name of the light. In most cases you should use the type's FullName.
        return typeof(FancyPointerTrackerLight).FullName;
    }
}
```

<span data-ttu-id="60dee-115">上で定義したカスタム ライトの考えられる別の使用例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="60dee-115">And here is an example showing different possible uses of the custom light defined above:</span></span>

```xml
<Page>
    <Page.Lights>
        <local:SimpleOrangeSpotLight />
    </Page.Lights>

    <StackPanel>
        <!-- this border will be lit by a FancyOrangeSpotLight, but not its children -->
        <Border BorderThickness="1">
            <Border.BorderBrush>
                <SolidColorBrush Color="Orange" local:FancyOrangeSpotLight.IsTarget="true" />
            </Border.BorderBrush>
            <TextBlock Text="hello world" />
        </Border>

        <!-- this border and its children will be lit by FancyOrangeSpotLight -->
        <Border BorderThickness="2" local:FancyOrangeSpotLight.IsTarget="true">
            <Border.BorderBrush>
                <SolidColorBrush Color="Purple" />
            </Border.BorderBrush>
            <TextBlock Text="hello world" />
        </Border>

        <!-- this border will not be lit -->
        <Border BorderThickness="2">
            <Border.BorderBrush>
                <SolidColorBrush Color="Green" />
            </Border.BorderBrush>
            <TextBlock Text="hello world" />
        </Border>
    </StackPanel>
<Page>
```

> [!Important]
> <span data-ttu-id="60dee-116">上の例で示しているような、マークアップでの UIElement.Lights の設定は、最小バージョンが Windows 10 Creators Update 以降であるアプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="60dee-116">Setting UIElement.Lights in markup as shown in the above example is only supported for apps with a Minimum Version equal to the Windows 10 Creators Update or later.</span></span> <span data-ttu-id="60dee-117">それ以前のバージョンをターゲットとするアプリでは、分離コードでライトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="60dee-117">For apps that target earlier versions, lights must be created in code-behind.</span></span>

## <a name="additional-resources"></a><span data-ttu-id="60dee-118">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="60dee-118">Additional Resources</span></span>

* <span data-ttu-id="60dee-119">[WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs) にある高度な UI とコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="60dee-119">Advanced UI and Composition samples in the [WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs).</span></span>