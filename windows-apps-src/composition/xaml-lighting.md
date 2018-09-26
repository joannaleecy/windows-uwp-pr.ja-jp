---
author: daneuber
title: XAML 照明
description: Light オブジェクトは、動的な照明と反射をシミュレートするために SceneLightingEffect と共に使用されます。
ms.author: jimwalk
ms.date: 06/28/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cpp
- cppwinrt
ms.openlocfilehash: b4e3678e17e7545dfe9cb4049ace7ff864198156
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4207600"
---
# <a name="xaml-lighting"></a><span data-ttu-id="e0946-104">XAML 照明</span><span class="sxs-lookup"><span data-stu-id="e0946-104">XAML lighting</span></span>

<span data-ttu-id="e0946-105">[**CompositionLight**](/uwp/api/Windows.UI.Composition.CompositionLight) オブジェクトは、動的な照明と反射をシミュレートするために [**SceneLightingEffect**](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) と共に使用されます。</span><span class="sxs-lookup"><span data-stu-id="e0946-105">[**CompositionLight**](/uwp/api/Windows.UI.Composition.CompositionLight) objects are used in conjunction with [**SceneLightingEffect**](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) to simulate dynamic lighting and reflectivity.</span></span>

<span data-ttu-id="e0946-106">[**Visual**](https://msdn.microsoft.com/library/windows/apps/Dn706858) と XAML [**UIElement**](/uwp/api/Windows.UI.Xaml.UIElement) にライトを適用できます。</span><span class="sxs-lookup"><span data-stu-id="e0946-106">You can apply lights to [**Visuals**](https://msdn.microsoft.com/library/windows/apps/Dn706858) and XAML [**UIElements**](/uwp/api/Windows.UI.Xaml.UIElement).</span></span>

## <a name="applying-lights-to-xaml-uielements"></a><span data-ttu-id="e0946-107">XAML UIElement へのライトの適用</span><span class="sxs-lookup"><span data-stu-id="e0946-107">Applying lights to XAML UIElements</span></span>

<span data-ttu-id="e0946-108">XAML UIElement に動的なライトを適用するには、[**XamlLight**](/uwp/api/windows.ui.xaml.media.xamllight) オブジェクトを使用して [**CompositionLight**](/uwp/api/Windows.UI.Composition.CompositionLight) を適用します。</span><span class="sxs-lookup"><span data-stu-id="e0946-108">[**XamlLight**](/uwp/api/windows.ui.xaml.media.xamllight) objects are used to apply [**CompositionLights**](/uwp/api/Windows.UI.Composition.CompositionLight) to dynamically light XAML UIElements.</span></span> <span data-ttu-id="e0946-109">XamlLight は Uielement または XAML ブラシ、Uielement のツリーにライトを適用することをターゲットとするメソッドを提供し、現在いるかどうかに基づいてリソースを使用して CompositionLight の有効期間を管理します。</span><span class="sxs-lookup"><span data-stu-id="e0946-109">XamlLight provides methods for targeting UIElements or XAML Brushes, applying lights to trees of UIElements, and helping manage the lifetime of CompositionLight resources based on whether they're currently in use.</span></span>

- <span data-ttu-id="e0946-110">XamlLight で **Brush** をターゲットにする場合、その Brush 使用している任意の UIElement の部分がライトによって照らされます。</span><span class="sxs-lookup"><span data-stu-id="e0946-110">If you target a **Brush** with a XamlLight then the portions of any UIElements using that Brush are lit by the light.</span></span>
- <span data-ttu-id="e0946-111">XamlLight で **UIElement** をターゲットにする場合、UIElement 全体とその子 UIElement がライトによって照らされます。</span><span class="sxs-lookup"><span data-stu-id="e0946-111">If you target a **UIElement** with a XamlLight then the entire UIElement and its child UIElements are all lit by the light.</span></span>

## <a name="creating-and-using-a-xamllight"></a><span data-ttu-id="e0946-112">XamlLight の作成と使用</span><span class="sxs-lookup"><span data-stu-id="e0946-112">Creating and using a XamlLight</span></span>

<span data-ttu-id="e0946-113">[**XamlLight**](/uwp/api/windows.ui.xaml.media.xamllight) は、カスタム ライトを作成するために使用できる基底クラスです。</span><span class="sxs-lookup"><span data-stu-id="e0946-113">[**XamlLight**](/uwp/api/windows.ui.xaml.media.xamllight) is a base class which can be used to create custom lights.</span></span>

<span data-ttu-id="e0946-114">この例では、ターゲットの Uielement とブラシに色付きのスポット ライトを適用するカスタム XamlLight の定義を示します。</span><span class="sxs-lookup"><span data-stu-id="e0946-114">This example shows the definition for a custom XamlLight that applies a multicolored spotlight to targeted UIElements and Brushes.</span></span>

```csharp
public sealed class OrangeSpotLight : XamlLight
{
    // Register an attached property that lets you set a UIElement
    // or Brush as a target for this light type in markup.
    public static readonly DependencyProperty IsTargetProperty =
        DependencyProperty.RegisterAttached(
        "IsTarget",
        typeof(bool),
        typeof(OrangeSpotLight),
        new PropertyMetadata(null, OnIsTargetChanged)
    );

    public static void SetIsTarget(DependencyObject target, bool value)
    {
        target.SetValue(IsTargetProperty, value);
    }

    public static Boolean GetIsTarget(DependencyObject target)
    {
        return (bool)target.GetValue(IsTargetProperty);
    }

    // Handle attached property changed to automatically target and untarget UIElements and Brushes.
    private static void OnIsTargetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var isAdding = (bool)e.NewValue;

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
        if (CompositionLight == null)
        {
            // OnConnected is called when the first target UIElement is shown on the screen.
            // This lets you delay creation of the composition object until it's actually needed.
            var spotLight = Window.Current.Compositor.CreateSpotLight();
            spotLight.InnerConeColor = Colors.Orange;
            spotLight.OuterConeColor = Colors.Yellow;
            spotLight.InnerConeAngleInDegrees = 30;
            spotLight.OuterConeAngleInDegrees = 45;
            CompositionLight = spotLight;
        }
    }

    protected override void OnDisconnected(UIElement oldElement)
    {
        // OnDisconnected is called when there are no more target UIElements on the screen.
        // The CompositionLight should be disposed when no longer required.
        // For SDK 15063, see Remarks in the XamlLight class documentation.
        if (CompositionLight != null)
        {
            CompositionLight.Dispose();
            CompositionLight = null;
        }
    }

    protected override string GetId()
    {
        return GetIdStatic();
    }

    private static string GetIdStatic()
    {
        // This specifies the unique name of the light.
        // In most cases you should use the type's FullName.
        return typeof(OrangeSpotLight).FullName;
    }
}
```

```vb
Public NotInheritable Class OrangeSpotLight
    Inherits XamlLight

    ' Register an attached property that lets you set a UIElement
    ' or Brush as a target for this light type in markup.
    Public Shared ReadOnly IsTargetProperty As DependencyProperty = DependencyProperty.RegisterAttached(
            "IsTarget",
            GetType(Boolean),
            GetType(OrangeSpotLight),
            New PropertyMetadata(Nothing, New PropertyChangedCallback(AddressOf OnIsTargetChanged)
            )
        )

    Public Shared Sub SetIsTarget(target As DependencyObject, value As Boolean)
        target.SetValue(IsTargetProperty, value)
    End Sub

    Public Shared Function GetIsTarget(target As DependencyObject) As Boolean
        Return DirectCast(target.GetValue(IsTargetProperty), Boolean)
    End Function

    ' Handle attached property changed to automatically target And untarget UIElements And Brushes.
    Public Shared Sub OnIsTargetChanged(obj As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim isAdding = DirectCast(e.NewValue, Boolean)

        If isAdding Then
            If TypeOf obj Is UIElement Then
                XamlLight.AddTargetElement(GetIdStatic(), TryCast(obj, UIElement))
            ElseIf TypeOf obj Is Brush Then
                XamlLight.AddTargetBrush(GetIdStatic(), TryCast(obj, Brush))
            End If
        Else
            If TypeOf obj Is UIElement Then
                XamlLight.RemoveTargetElement(GetIdStatic(), TryCast(obj, UIElement))
            ElseIf TypeOf obj Is Brush Then
                XamlLight.RemoveTargetBrush(GetIdStatic(), TryCast(obj, Brush))
            End If
        End If
    End Sub

    Protected Overrides Sub OnConnected(newElement As UIElement)
        If CompositionLight Is Nothing Then
            ' OnConnected Is called when the first target UIElement Is shown on the screen.
            ' This lets you delay creation of the composition object until it's actually needed.
            Dim spotLight = Window.Current.Compositor.CreateSpotLight()
            spotLight.InnerConeColor = Colors.Orange
            spotLight.OuterConeColor = Colors.Yellow
            spotLight.InnerConeAngleInDegrees = 30
            spotLight.OuterConeAngleInDegrees = 45
            CompositionLight = spotLight
        End If
    End Sub

    Protected Overrides Sub OnDisconnected(oldElement As UIElement)
        ' OnDisconnected Is called when there are no more target UIElements on the screen.
        ' The CompositionLight should be disposed when no longer required.
        If CompositionLight IsNot Nothing Then
            CompositionLight.Dispose()
            CompositionLight = Nothing
        End If
    End Sub

    Protected Overrides Function GetId() As String
        Return GetIdStatic()
    End Function

    Private Shared Function GetIdStatic() As String
        ' This specifies the unique name of the light.
        ' In most cases you should use the type's FullName.
        Return GetType(OrangeSpotLight).FullName
    End Function
End Class
```

```cppwinrt
// For the C++/WinRT code example below, you'll need to add a Midl File (.idl) file to your project.

// OrangeSpotLight.idl
namespace MyApp
{
    [default_interface]
    runtimeclass OrangeSpotLight : Windows.UI.Xaml.Media.XamlLight
    {
        OrangeSpotLight();
        static Windows.UI.Xaml.DependencyProperty IsTargetProperty{ get; };
        static Boolean GetIsTarget(Windows.UI.Xaml.DependencyObject target);
        static void SetIsTarget(Windows.UI.Xaml.DependencyObject target, Boolean value);
    }
}

// OrangeSpotLight.h
struct OrangeSpotLight : OrangeSpotLightT<OrangeSpotLight>
{
    OrangeSpotLight() = default;

    winrt::hstring GetId();

    static Windows::UI::Xaml::DependencyProperty IsTargetProperty() { return m_isTargetProperty; }

    static bool GetIsTarget(Windows::UI::Xaml::DependencyObject const& target)
    {
        return winrt::unbox_value<bool>(target.GetValue(m_isTargetProperty));
    }

    static void SetIsTarget(Windows::UI::Xaml::DependencyObject const& target, bool value)
    {
        target.SetValue(m_isTargetProperty, winrt::box_value(value));
    }

    void OnConnected(Windows::UI::Xaml::UIElement const& newElement);
    void OnDisconnected(Windows::UI::Xaml::UIElement const& oldElement);

    static void OnIsTargetChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e);

    inline static winrt::hstring GetIdStatic()
    {
        // This specifies the unique name of the light. In most cases you should use the type's full name.
        return winrt::xaml_typename<MyApp::OrangeSpotLight>().Name;
    }

private:
    static Windows::UI::Xaml::DependencyProperty m_isTargetProperty;
};

// OrangeSpotLight.cpp
Windows::UI::Xaml::DependencyProperty OrangeSpotLight::m_isTargetProperty =
    Windows::UI::Xaml::DependencyProperty::RegisterAttached(
        L"IsTarget",
        winrt::xaml_typename<bool>(),
        winrt::xaml_typename<MyApp::OrangeSpotLight>(),
        Windows::UI::Xaml::PropertyMetadata{ winrt::box_value(false), Windows::UI::Xaml::PropertyChangedCallback{ &OrangeSpotLight::OnIsTargetChanged } }
);

void OrangeSpotLight::OnConnected(Windows::UI::Xaml::UIElement const& /* newElement */)
{
    if (!CompositionLight())
    {
        // OnConnected is called when the first target UIElement is shown on the screen. This enables delaying composition object creation until it's actually necessary.
        auto spotLight{ Windows::UI::Xaml::Window::Current().Compositor().CreateSpotLight() };
        spotLight.InnerConeColor(Windows::UI::Colors::Orange());
        spotLight.OuterConeColor(Windows::UI::Colors::Yellow());
        spotLight.InnerConeAngleInDegrees(30);
        spotLight.OuterConeAngleInDegrees(45);
        CompositionLight(spotLight);
    }
}

void OrangeSpotLight::OnDisconnected(Windows::UI::Xaml::UIElement const& /* oldElement */)
{
    // OnDisconnected is called when there are no more target UIElements on the screen.
    // Dispose of composition resources when no longer in use.
    if (CompositionLight())
    {
        CompositionLight(nullptr);
    }
}

winrt::hstring OrangeSpotLight::GetId()
{
    return OrangeSpotLight::GetIdStatic();
}

void OrangeSpotLight::OnIsTargetChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e)
{
    auto uie{ d.try_as<Windows::UI::Xaml::UIElement>() };
    auto brush{ d.try_as<Windows::UI::Xaml::Media::Brush>() };

    auto isAdding = winrt::unbox_value<bool>(e.NewValue());
    if (isAdding)
    {

        if (uie)
        {
            Windows::UI::Xaml::Media::XamlLight::AddTargetElement(OrangeSpotLight::GetIdStatic(), uie);
        }
        else if (brush)
        {
            Windows::UI::Xaml::Media::XamlLight::AddTargetBrush(OrangeSpotLight::GetIdStatic(), brush);
        }
    }
    else
    {
        if (uie)
        {
            Windows::UI::Xaml::Media::XamlLight::RemoveTargetElement(OrangeSpotLight::GetIdStatic(), uie);
        }
        else if (brush)
        {
            Windows::UI::Xaml::Media::XamlLight::RemoveTargetBrush(OrangeSpotLight::GetIdStatic(), brush);
        }
    }
}

// MainPage.h
...
#include "OrangeSpotLight.h"
...
struct MainPage : MainPageT<MainPage>
{
    MainPage()
    {
        InitializeComponent();

        OrangeSpotLight::SetIsTarget(spotlitBrush(), true);
        OrangeSpotLight::SetIsTarget(spotlitUIElement(), true);
    }
...
};
```

```cpp
// OrangeSpotLight.h:
public ref class OrangeSpotLight sealed :
    public Windows::UI::Xaml::Media::XamlLight
{
public:
    OrangeSpotLight();

    static property Windows::UI::Xaml::DependencyProperty^ IsTargetProperty
    {
        Windows::UI::Xaml::DependencyProperty^ get() { return m_isTargetProperty; }
    };
    static void SetIsTarget(Windows::UI::Xaml::DependencyObject^ target, bool value);
    static bool GetIsTarget(Windows::UI::Xaml::DependencyObject^ target);

protected:
    virtual void OnConnected(Windows::UI::Xaml::UIElement^ newElement) override;
    virtual void OnDisconnected(Windows::UI::Xaml::UIElement^ oldElement) override;
    virtual Platform::String^ GetId() override;

private:
    static Windows::UI::Xaml::DependencyProperty^ m_isTargetProperty;
    static void OnIsTargetChanged(Windows::UI::Xaml::DependencyObject^ obj, Windows::UI::Xaml::DependencyPropertyChangedEventArgs^ e);

    inline static Platform::String^ GetIdStatic()
    {
        // This specifies the unique name of the light. In most cases you should use the type's FullName.
        return OrangeSpotLight::typeid->FullName;
    }
};

//OrangeSpotLight.cpp:

// Register an attached property that lets you set a UIElement
// or Brush as a target for this light type in markup.
DependencyProperty^ OrangeSpotLight::m_isTargetProperty = DependencyProperty::RegisterAttached(
    "IsTarget",
    bool::typeid,
    OrangeSpotLight::typeid,
    ref new PropertyMetadata(0.0, ref new PropertyChangedCallback(OnIsTargetChanged))
);

OrangeSpotLight::OrangeSpotLight()
{
}

void OrangeSpotLight::SetIsTarget(DependencyObject^ target, bool value)
{
    target->SetValue(IsTargetProperty, value);
}

bool OrangeSpotLight::GetIsTarget(DependencyObject^ target)
{
    return static_cast<bool>(target->GetValue(IsTargetProperty));
}

// Handle attached property changed to automatically target and untarget UIElements and Brushes.
void OrangeSpotLight::OnIsTargetChanged(DependencyObject^ obj, DependencyPropertyChangedEventArgs^ e)
{
    auto isAdding = static_cast<bool>(e->NewValue);

    if (isAdding)
    {
        if (dynamic_cast<UIElement^>(obj))
        {
            XamlLight::AddTargetElement(GetIdStatic(), static_cast<UIElement^>(obj));
        }
        else if (dynamic_cast<Brush^>(obj))
        {
            XamlLight::AddTargetBrush(GetIdStatic(), static_cast<Brush^>(obj));
        }
    }
    else
    {
        if (dynamic_cast<UIElement^>(obj))
        {
            XamlLight::RemoveTargetElement(GetIdStatic(), static_cast<UIElement^>(obj));
        }
        else if (dynamic_cast<Brush^>(obj))
        {
            XamlLight::RemoveTargetBrush(GetIdStatic(), static_cast<Brush^>(obj));
        }
    }
}
void OrangeSpotLight::OnConnected(UIElement^ newElement)
{
    if (CompositionLight == nullptr)
    {
        // OnConnected is called when the first target UIElement is shown on the screen.
        // This lets you delay creation of the composition object until it's actually needed.
        auto spotLight = Window::Current->Compositor->CreateSpotLight();
        spotLight->InnerConeColor = Colors::Orange;
        spotLight->OuterConeColor = Colors::Yellow;
        spotLight->InnerConeAngleInDegrees = 30;
        spotLight->OuterConeAngleInDegrees = 45;
        CompositionLight = spotLight;
    }
}

void OrangeSpotLight::OnDisconnected(UIElement^ oldElement)
{
    // OnDisconnected is called when there are no more target UIElements on the screen.
    // The CompositionLight should be disposed when no longer required.
    // For SDK 15063, see Remarks in the XamlLight class documentation.
    if (CompositionLight != nullptr)
    {
        delete CompositionLight;
        CompositionLight = nullptr;
    }
}

Platform::String^ OrangeSpotLight::GetId()
{
    return GetIdStatic();
}
```

<span data-ttu-id="e0946-115">この光は、任意の XAML UIElement またはブラシに光を適用できます。</span><span class="sxs-lookup"><span data-stu-id="e0946-115">You can then apply this light to any XAML UIElement or Brush to light them.</span></span> <span data-ttu-id="e0946-116">この例では、さまざまな潜在的な使用法を示します。</span><span class="sxs-lookup"><span data-stu-id="e0946-116">This example shows different potential usages.</span></span>

> [!Important]
> <span data-ttu-id="e0946-117">[、C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)、削除が 2 回`local:OrangeSpotLight.IsTarget="True"`次のマークアップからです。</span><span class="sxs-lookup"><span data-stu-id="e0946-117">For [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt), remove the two occurrences of `local:OrangeSpotLight.IsTarget="True"` from the markup below.</span></span> <span data-ttu-id="e0946-118">添付プロパティは、コード ビハインドで既に設定されます。</span><span class="sxs-lookup"><span data-stu-id="e0946-118">The attached properties are already set in code-behind.</span></span>

```xaml
<StackPanel Width="100">
    <StackPanel.Lights>
        <local:OrangeSpotLight/>
    </StackPanel.Lights>

    <!-- This border is lit by the OrangeSpotLight, but its content is not. -->
    <Border BorderThickness="4" Margin="2">
        <Border.BorderBrush>
            <SolidColorBrush x:Name="spotlitBrush" Color="White" local:OrangeSpotLight.IsTarget="True"/>
        </Border.BorderBrush>
        <Rectangle Fill="LightGray" Height="20"/>
    </Border>

    <!-- This border and its content are lit by the OrangeSpotLight. -->
    <Border x:Name="spotlitUIElement" BorderThickness="4" BorderBrush="PaleGreen" Margin="2"
            local:OrangeSpotLight.IsTarget="True">
        <Rectangle Fill="LightGray" Height="20"/>
    </Border>

    <!-- This border and its content are not lit by the OrangeSpotLight. -->
    <Border BorderThickness="4" BorderBrush="PaleGreen" Margin="2">
        <Rectangle Fill="LightGray" Height="20"/>
    </Border>
</StackPanel>
```

<span data-ttu-id="e0946-119">この XAML の結果を次に示します。</span><span class="sxs-lookup"><span data-stu-id="e0946-119">The results of this XAML look like this.</span></span>

![Xaml ライトによって照らさ要素の例](images/orange-spot-light.png)

> [!Important]
> <span data-ttu-id="e0946-121">上の例で示しているような、マークアップでの UIElement.Lights の設定は、最小バージョンが Windows 10 Creators Update 以降であるアプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="e0946-121">Setting UIElement.Lights in markup as shown in the above example is only supported for apps with a Minimum Version equal to the Windows 10 Creators Update or later.</span></span> <span data-ttu-id="e0946-122">それ以前のバージョンをターゲットとするアプリでは、分離コードでライトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e0946-122">For apps that target earlier versions, lights must be created in code-behind.</span></span>

## <a name="additional-resources"></a><span data-ttu-id="e0946-123">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="e0946-123">Additional Resources</span></span>

* <span data-ttu-id="e0946-124">[WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs) にある高度な UI とコンポジションのサンプル</span><span class="sxs-lookup"><span data-stu-id="e0946-124">Advanced UI and Composition samples in the [WindowsUIDevLabs GitHub](https://github.com/microsoft/windowsuidevlabs).</span></span>
