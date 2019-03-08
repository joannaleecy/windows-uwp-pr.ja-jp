---
Description: タッチ キーボードを表示または非表示にするときにアプリの UI を調整する方法について説明します。
title: タッチ キーボードの表示への応答
ms.assetid: 70C6130E-23A2-4F9D-88E7-7060062DA988
label: Respond to the presence of the touch keyboard
template: detail.hbs
keywords: キーボード, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作
ms.date: 07/13/2018
ms.topic: article
ms.openlocfilehash: e44b7cf5a61a795e52490f6d603aea0bcf87bea2
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57658297"
---
# <a name="respond-to-the-presence-of-the-touch-keyboard"></a><span data-ttu-id="ec717-104">タッチ キーボードの表示への応答</span><span class="sxs-lookup"><span data-stu-id="ec717-104">Respond to the presence of the touch keyboard</span></span>

<span data-ttu-id="ec717-105">タッチ キーボードを表示または非表示にするときにアプリの UI を調整する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ec717-105">Learn how to tailor the UI of your app when showing or hiding the touch keyboard.</span></span>

### <a name="important-apis"></a><span data-ttu-id="ec717-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="ec717-106">Important APIs</span></span>

- [<span data-ttu-id="ec717-107">AutomationPeer</span><span class="sxs-lookup"><span data-stu-id="ec717-107">AutomationPeer</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationPeer)
- [<span data-ttu-id="ec717-108">InputPane</span><span class="sxs-lookup"><span data-stu-id="ec717-108">InputPane</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.InputPane)

![既定のレイアウト モードのタッチ キーボード](images/keyboard/default.png)

<span data-ttu-id="ec717-110"><sup>既定のキーボード、タッチのレイアウト モード</sup></span><span class="sxs-lookup"><span data-stu-id="ec717-110"><sup>The touch keyboard in default layout mode</sup></span></span>

<span data-ttu-id="ec717-111">タッチ キーボードによって、タッチをサポートするデバイスのテキスト入力が有効になります。</span><span class="sxs-lookup"><span data-stu-id="ec717-111">The touch keyboard enables text entry for devices that support touch.</span></span> <span data-ttu-id="ec717-112">ユニバーサル Windows プラットフォーム (UWP) のテキスト入力コントロールでは、ユーザーが編集可能な入力フィールドをタップしたときに、既定でタッチ キーボードが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ec717-112">Universal Windows Platform (UWP) text input controls invoke the touch keyboard by default when a user taps on an editable input field.</span></span> <span data-ttu-id="ec717-113">タッチ キーボードは、通常、ユーザーがフォーム内のコントロール間を移動している間は表示されますが、この動作はフォーム内の他のコントロールの種類に基づいて異なります。</span><span class="sxs-lookup"><span data-stu-id="ec717-113">The touch keyboard typically remains visible while the user navigates between controls in a form, but this behavior can vary based on the other control types within the form.</span></span>

<span data-ttu-id="ec717-114">標準のテキスト入力コントロールから派生していないカスタムのテキスト入力コントロールに対応するタッチ キーボード動作をサポートするために使用する必要があります、 <a href="https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationPeer">AutomationPeer</a> Microsoft UI オートメーションを使用するコントロールを公開するクラスと適切な UI オートメーション コントロール パターンを実装します。</span><span class="sxs-lookup"><span data-stu-id="ec717-114">To support corresponding touch keyboard behavior in a custom text input control that does not derive from a standard text input control, you must use the <a href="https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationPeer">AutomationPeer</a> class to expose your controls to Microsoft UI Automation and implement the correct UI Automation control patterns.</span></span> <span data-ttu-id="ec717-115">「[キーボードのアクセシビリティ](https://docs.microsoft.com/windows/uwp/design/accessibility/keyboard-accessibility)」と「[カスタム オートメーション ピア](https://docs.microsoft.com/windows/uwp/design/accessibility/custom-automation-peers)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ec717-115">See [Keyboard accessibility](https://docs.microsoft.com/windows/uwp/design/accessibility/keyboard-accessibility) and [Custom automation peers](https://docs.microsoft.com/windows/uwp/design/accessibility/custom-automation-peers).</span></span>

<span data-ttu-id="ec717-116">このサポートがカスタム コントロールに追加されると、タッチ キーボードの表示に適切に応答できます。</span><span class="sxs-lookup"><span data-stu-id="ec717-116">Once this support has been added to your custom control, you can respond appropriately to the presence of the touch keyboard.</span></span>

<span data-ttu-id="ec717-117">**前提条件:**</span><span class="sxs-lookup"><span data-stu-id="ec717-117">**Prerequisites:**</span></span>

<span data-ttu-id="ec717-118">このトピックは、「[キーボード操作](keyboard-interactions.md)」に基づいています。</span><span class="sxs-lookup"><span data-stu-id="ec717-118">This topic builds on [Keyboard interactions](keyboard-interactions.md).</span></span>

<span data-ttu-id="ec717-119">標準のキーボード操作、キーボード入力とイベントの処理、UI オートメーションの基本を理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="ec717-119">You should have a basic understanding of standard keyboard interactions, handling keyboard input and events, and UI Automation.</span></span>

<span data-ttu-id="ec717-120">ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。</span><span class="sxs-lookup"><span data-stu-id="ec717-120">If you're new to developing Universal Windows Platform (UWP) apps, have a look through these topics to get familiar with the technologies discussed here.</span></span>

- [<span data-ttu-id="ec717-121">初めてのアプリの作成</span><span class="sxs-lookup"><span data-stu-id="ec717-121">Create your first app</span></span>](https://docs.microsoft.com/windows/uwp/get-started/your-first-app)
- <span data-ttu-id="ec717-122">「[イベントとルーティング イベントの概要](https://docs.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview)」に記載されているイベントの説明</span><span class="sxs-lookup"><span data-stu-id="ec717-122">Learn about events with [Events and routed events overview](https://docs.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview)</span></span>

<span data-ttu-id="ec717-123">**ユーザー エクスペリエンス ガイドライン:**</span><span class="sxs-lookup"><span data-stu-id="ec717-123">**User experience guidelines:**</span></span>

<span data-ttu-id="ec717-124">キーボード入力用に最適化された、便利で魅力的なアプリの設計に関する役立つヒントを次を参照してください。[の相互作用をキーボード](https://docs.microsoft.com/windows/uwp/design/input/keyboard-interactions)します。</span><span class="sxs-lookup"><span data-stu-id="ec717-124">For helpful tips about designing a useful and engaging app optimized for keyboard input, see [Keyboard interactions](https://docs.microsoft.com/windows/uwp/design/input/keyboard-interactions) .</span></span>

## <a name="touch-keyboard-and-a-custom-ui"></a><span data-ttu-id="ec717-125">タッチ キーボードとカスタム UI</span><span class="sxs-lookup"><span data-stu-id="ec717-125">Touch keyboard and a custom UI</span></span>

<span data-ttu-id="ec717-126">ここでは、カスタム テキスト入力コントロールについてのいくつかの基本的な推奨事項を示します。</span><span class="sxs-lookup"><span data-stu-id="ec717-126">Here are a few basic recommendations for custom text input controls.</span></span>

- <span data-ttu-id="ec717-127">フォームに対する操作が行われている間はタッチ キーボードを表示します。</span><span class="sxs-lookup"><span data-stu-id="ec717-127">Display the touch keyboard throughout the entire interaction with your form.</span></span>

- <span data-ttu-id="ec717-128">カスタム コントロールは、適切な UI オートメーションでいることを確認 [AutomationControlType](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationControlType)キーボードのテキスト入力のコンテキストでのテキスト入力フィールドからフォーカスが移動したときに永続化します。</span><span class="sxs-lookup"><span data-stu-id="ec717-128">Ensure that your custom controls have the appropriate UI Automation [AutomationControlType](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationControlType) for the keyboard to persist when focus moves from a text input field while in the context of text entry.</span></span> <span data-ttu-id="ec717-129">たとえば、テキスト入力シナリオの半ばでメニューを開くときに、キーボードを表示したままにするには、このメニューに Menu の **AutomationControlType** が必要です。</span><span class="sxs-lookup"><span data-stu-id="ec717-129">For example, if you have a menu that's opened in the middle of a text-entry scenario, and you want the keyboard to persist, the menu must have the **AutomationControlType** of Menu.</span></span>

- <span data-ttu-id="ec717-130">UI オートメーション プロパティを操作してタッチ キーボードを制御しないでください。</span><span class="sxs-lookup"><span data-stu-id="ec717-130">Don't manipulate UI Automation properties to control the touch keyboard.</span></span> <span data-ttu-id="ec717-131">UI オートメーション プロパティの正確さに依存する他のアクセシビリティ ツールがあります。</span><span class="sxs-lookup"><span data-stu-id="ec717-131">Other accessibility tools rely on the accuracy of UI Automation properties.</span></span>

- <span data-ttu-id="ec717-132">操作している入力フィールドをユーザーが常に見られるようにします。</span><span class="sxs-lookup"><span data-stu-id="ec717-132">Ensure that users can always see the input field that they're interacting with.</span></span>

    <span data-ttu-id="ec717-133">タッチ キーボードによって画面の大部分が見えなくなるため、UWP では、ユーザーがフォームのコントロール間を移動するときに、フォーカスのある入力フィールドをスクロールしてビューに表示します。これには、現在ビューに表示されていないコントロールも含まれます。</span><span class="sxs-lookup"><span data-stu-id="ec717-133">Because the touch keyboard occludes a large portion of the screen, the UWP ensures that the input field with focus scrolls into view as a user navigates through the controls on the form, including controls that are not currently in view.</span></span>

    <span data-ttu-id="ec717-134">UI をカスタマイズするときに動作を提供のようなタッチ キーボードの外観を処理することによって、[示す](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.showing)と[を非表示](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.hiding)によって公開されるイベント、 [ **InputPane**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.InputPane)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="ec717-134">When customizing your UI, provide similar behavior on the appearance of the touch keyboard by handling the [Showing](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.showing) and [Hiding](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.hiding) events exposed by the [**InputPane**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.InputPane) object.</span></span>

    ![タッチ キーボードが表示または非表示になっているフォーム](images/touch-keyboard-pan1.png)

    <span data-ttu-id="ec717-136">場合によっては、画面にずっと表示されたままであることが必要な UI 要素もあります。</span><span class="sxs-lookup"><span data-stu-id="ec717-136">In some cases, there are UI elements that should stay on the screen the entire time.</span></span> <span data-ttu-id="ec717-137">フォーム コントロールがパン領域に含まれ、重要な UI 要素が静的であるように UI を設計します。</span><span class="sxs-lookup"><span data-stu-id="ec717-137">Design the UI so that the form controls are contained in a panning region and the important UI elements are static.</span></span> <span data-ttu-id="ec717-138">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ec717-138">For example:</span></span>

    ![常に表示されている必要がある領域を含むフォーム](images/touch-keyboard-pan2.png)

## <a name="handling-the-showing-and-hiding-events"></a><span data-ttu-id="ec717-140">Showing イベントと Hiding イベントの処理</span><span class="sxs-lookup"><span data-stu-id="ec717-140">Handling the Showing and Hiding events</span></span>

<span data-ttu-id="ec717-141">イベント ハンドラーのアタッチの例を次に示します、[示す](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.showing)と[を非表示](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.hiding)タッチ キーボードのイベント。</span><span class="sxs-lookup"><span data-stu-id="ec717-141">Here's an example of attaching event handlers for the [Showing](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.showing) and [Hiding](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.hiding) events of the touch keyboard.</span></span>

```csharp
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.Foundation;
using Windows.UI.Xaml.Navigation;

namespace SDKTemplate
{
    /// <summary>
    /// Sample page to subscribe show/hide event of Touch Keyboard.
    /// </summary>
    public sealed partial class Scenario2_ShowHideEvents : Page
    {
        public Scenario2_ShowHideEvents()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            InputPane currentInputPane = InputPane.GetForCurrentView();
            // Subscribe to Showing/Hiding events
            currentInputPane.Showing += OnShowing;
            currentInputPane.Hiding += OnHiding;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            InputPane currentInputPane = InputPane.GetForCurrentView();
            // Unsubscribe from Showing/Hiding events
            currentInputPane.Showing -= OnShowing;
            currentInputPane.Hiding -= OnHiding;
        }

        void OnShowing(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            LastInputPaneEventRun.Text = "Showing";
        }
        
        void OnHiding(InputPane sender, InputPaneVisibilityEventArgs e)
        {
            LastInputPaneEventRun.Text = "Hiding";
        }
    }
}
```

```cppwinrt
...
#include <winrt/Windows.UI.ViewManagement.h>
...
private:
    winrt::event_token m_showingEventToken;
    winrt::event_token m_hidingEventToken;
...
Scenario2_ShowHideEvents::Scenario2_ShowHideEvents()
{
    InitializeComponent();
}

void Scenario2_ShowHideEvents::OnNavigatedTo(Windows::UI::Xaml::Navigation::NavigationEventArgs const& e)
{
    auto inputPane{ Windows::UI::ViewManagement::InputPane::GetForCurrentView() };
    // Subscribe to Showing/Hiding events
    m_showingEventToken = inputPane.Showing({ this, &Scenario2_ShowHideEvents::OnShowing });
    m_hidingEventToken = inputPane.Hiding({ this, &Scenario2_ShowHideEvents::OnHiding });
}

void Scenario2_ShowHideEvents::OnNavigatedFrom(Windows::UI::Xaml::Navigation::NavigationEventArgs const& e)
{
    auto inputPane{ Windows::UI::ViewManagement::InputPane::GetForCurrentView() };
    // Unsubscribe from Showing/Hiding events
    inputPane.Showing(m_showingEventToken);
    inputPane.Hiding(m_hidingEventToken);
}

void Scenario2_ShowHideEvents::OnShowing(Windows::UI::ViewManagement::InputPane const& /*sender*/, Windows::UI::ViewManagement::InputPaneVisibilityEventArgs const& /*args*/)
{
    LastInputPaneEventRun().Text(L"Showing");
}

void Scenario2_ShowHideEvents::OnHiding(Windows::UI::ViewManagement::InputPane const& /*sender*/, Windows::UI::ViewManagement::InputPaneVisibilityEventArgs const& /*args*/)
{
    LastInputPaneEventRun().Text(L"Hiding");
}
```

```cpp
#include "pch.h"
#include "Scenario2_ShowHideEvents.xaml.h"

using namespace SDKTemplate;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::UI::ViewManagement;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Navigation;

Scenario2_ShowHideEvents::Scenario2_ShowHideEvents()
{
    InitializeComponent();
}

void Scenario2_ShowHideEvents::OnNavigatedTo(NavigationEventArgs^ e)
{
    auto inputPane = InputPane::GetForCurrentView();
    // Subscribe to Showing/Hiding events
    showingEventToken = inputPane->Showing +=
        ref new TypedEventHandler<InputPane^, InputPaneVisibilityEventArgs^>(this, &Scenario2_ShowHideEvents::OnShowing);
    hidingEventToken = inputPane->Hiding +=
        ref new TypedEventHandler<InputPane^, InputPaneVisibilityEventArgs^>(this, &Scenario2_ShowHideEvents::OnHiding);
}

void Scenario2_ShowHideEvents::OnNavigatedFrom(NavigationEventArgs^ e)
{
    auto inputPane = Windows::UI::ViewManagement::InputPane::GetForCurrentView();
    // Unsubscribe from Showing/Hiding events
    inputPane->Showing -= showingEventToken;
    inputPane->Hiding -= hidingEventToken;
}

void Scenario2_ShowHideEvents::OnShowing(InputPane^ /*sender*/, InputPaneVisibilityEventArgs^ /*args*/)
{
    LastInputPaneEventRun->Text = L"Showing";
}

void Scenario2_ShowHideEvents::OnHiding(InputPane^ /*sender*/, InputPaneVisibilityEventArgs ^ /*args*/)
{
    LastInputPaneEventRun->Text = L"Hiding";
}
```

## <a name="related-articles"></a><span data-ttu-id="ec717-142">関連記事</span><span class="sxs-lookup"><span data-stu-id="ec717-142">Related articles</span></span>

- [<span data-ttu-id="ec717-143">キーボードの相互作用</span><span class="sxs-lookup"><span data-stu-id="ec717-143">Keyboard interactions</span></span>](keyboard-interactions.md)
- [<span data-ttu-id="ec717-144">キーボードのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="ec717-144">Keyboard accessibility</span></span>](https://msdn.microsoft.com/library/windows/apps/mt244347)
- [<span data-ttu-id="ec717-145">カスタム オートメーション ピア</span><span class="sxs-lookup"><span data-stu-id="ec717-145">Custom automation peers</span></span>](https://msdn.microsoft.com/library/windows/apps/mt297667)

<span data-ttu-id="ec717-146">**サンプル**</span><span class="sxs-lookup"><span data-stu-id="ec717-146">**Samples**</span></span>

- [<span data-ttu-id="ec717-147">タッチ キーボードのサンプル</span><span class="sxs-lookup"><span data-stu-id="ec717-147">Touch keyboard sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)

<span data-ttu-id="ec717-148">**サンプルのアーカイブ**</span><span class="sxs-lookup"><span data-stu-id="ec717-148">**Archive samples**</span></span>

- [<span data-ttu-id="ec717-149">入力:タッチ キーボードのサンプル</span><span class="sxs-lookup"><span data-stu-id="ec717-149">Input: Touch keyboard sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=246019)
- [<span data-ttu-id="ec717-150">外観に応答して、スクリーン キーボードのサンプル</span><span class="sxs-lookup"><span data-stu-id="ec717-150">Responding to the appearance of the on-screen keyboard sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=231633)
- [<span data-ttu-id="ec717-151">XAML テキスト編集のサンプル</span><span class="sxs-lookup"><span data-stu-id="ec717-151">XAML text editing sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=251417)
- [<span data-ttu-id="ec717-152">XAML のアクセシビリティのサンプル</span><span class="sxs-lookup"><span data-stu-id="ec717-152">XAML accessibility sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=238570)
