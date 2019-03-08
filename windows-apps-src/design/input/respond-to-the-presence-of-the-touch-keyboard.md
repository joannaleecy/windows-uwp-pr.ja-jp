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
# <a name="respond-to-the-presence-of-the-touch-keyboard"></a>タッチ キーボードの表示への応答

タッチ キーボードを表示または非表示にするときにアプリの UI を調整する方法について説明します。

### <a name="important-apis"></a>重要な API

- [AutomationPeer](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationPeer)
- [InputPane](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.InputPane)

![既定のレイアウト モードのタッチ キーボード](images/keyboard/default.png)

<sup>既定のキーボード、タッチのレイアウト モード</sup>

タッチ キーボードによって、タッチをサポートするデバイスのテキスト入力が有効になります。 ユニバーサル Windows プラットフォーム (UWP) のテキスト入力コントロールでは、ユーザーが編集可能な入力フィールドをタップしたときに、既定でタッチ キーボードが表示されます。 タッチ キーボードは、通常、ユーザーがフォーム内のコントロール間を移動している間は表示されますが、この動作はフォーム内の他のコントロールの種類に基づいて異なります。

標準のテキスト入力コントロールから派生していないカスタムのテキスト入力コントロールに対応するタッチ キーボード動作をサポートするために使用する必要があります、 <a href="https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationPeer">AutomationPeer</a> Microsoft UI オートメーションを使用するコントロールを公開するクラスと適切な UI オートメーション コントロール パターンを実装します。 「[キーボードのアクセシビリティ](https://docs.microsoft.com/windows/uwp/design/accessibility/keyboard-accessibility)」と「[カスタム オートメーション ピア](https://docs.microsoft.com/windows/uwp/design/accessibility/custom-automation-peers)」をご覧ください。

このサポートがカスタム コントロールに追加されると、タッチ キーボードの表示に適切に応答できます。

**前提条件:**

このトピックは、「[キーボード操作](keyboard-interactions.md)」に基づいています。

標準のキーボード操作、キーボード入力とイベントの処理、UI オートメーションの基本を理解している必要があります。

ユニバーサル Windows プラットフォーム (UWP) アプリを開発するのが初めての場合は、以下のトピックに目を通して、ここで説明されているテクノロジをよく理解できるようにしてください。

- [初めてのアプリの作成](https://docs.microsoft.com/windows/uwp/get-started/your-first-app)
- 「[イベントとルーティング イベントの概要](https://docs.microsoft.com/windows/uwp/xaml-platform/events-and-routed-events-overview)」に記載されているイベントの説明

**ユーザー エクスペリエンス ガイドライン:**

キーボード入力用に最適化された、便利で魅力的なアプリの設計に関する役立つヒントを次を参照してください。[の相互作用をキーボード](https://docs.microsoft.com/windows/uwp/design/input/keyboard-interactions)します。

## <a name="touch-keyboard-and-a-custom-ui"></a>タッチ キーボードとカスタム UI

ここでは、カスタム テキスト入力コントロールについてのいくつかの基本的な推奨事項を示します。

- フォームに対する操作が行われている間はタッチ キーボードを表示します。

- カスタム コントロールは、適切な UI オートメーションでいることを確認 [AutomationControlType](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Automation.Peers.AutomationControlType)キーボードのテキスト入力のコンテキストでのテキスト入力フィールドからフォーカスが移動したときに永続化します。 たとえば、テキスト入力シナリオの半ばでメニューを開くときに、キーボードを表示したままにするには、このメニューに Menu の **AutomationControlType** が必要です。

- UI オートメーション プロパティを操作してタッチ キーボードを制御しないでください。 UI オートメーション プロパティの正確さに依存する他のアクセシビリティ ツールがあります。

- 操作している入力フィールドをユーザーが常に見られるようにします。

    タッチ キーボードによって画面の大部分が見えなくなるため、UWP では、ユーザーがフォームのコントロール間を移動するときに、フォーカスのある入力フィールドをスクロールしてビューに表示します。これには、現在ビューに表示されていないコントロールも含まれます。

    UI をカスタマイズするときに動作を提供のようなタッチ キーボードの外観を処理することによって、[示す](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.showing)と[を非表示](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.hiding)によって公開されるイベント、 [ **InputPane**](https://docs.microsoft.com/uwp/api/Windows.UI.ViewManagement.InputPane)オブジェクト。

    ![タッチ キーボードが表示または非表示になっているフォーム](images/touch-keyboard-pan1.png)

    場合によっては、画面にずっと表示されたままであることが必要な UI 要素もあります。 フォーム コントロールがパン領域に含まれ、重要な UI 要素が静的であるように UI を設計します。 次に、例を示します。

    ![常に表示されている必要がある領域を含むフォーム](images/touch-keyboard-pan2.png)

## <a name="handling-the-showing-and-hiding-events"></a>Showing イベントと Hiding イベントの処理

イベント ハンドラーのアタッチの例を次に示します、[示す](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.showing)と[を非表示](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.inputpane.hiding)タッチ キーボードのイベント。

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

## <a name="related-articles"></a>関連記事

- [キーボードの相互作用](keyboard-interactions.md)
- [キーボードのアクセシビリティ](https://msdn.microsoft.com/library/windows/apps/mt244347)
- [カスタム オートメーション ピア](https://msdn.microsoft.com/library/windows/apps/mt297667)

**サンプル**

- [タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)

**サンプルのアーカイブ**

- [入力:タッチ キーボードのサンプル](https://go.microsoft.com/fwlink/p/?linkid=246019)
- [外観に応答して、スクリーン キーボードのサンプル](https://go.microsoft.com/fwlink/p/?linkid=231633)
- [XAML テキスト編集のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=251417)
- [XAML のアクセシビリティのサンプル](https://go.microsoft.com/fwlink/p/?linkid=238570)
