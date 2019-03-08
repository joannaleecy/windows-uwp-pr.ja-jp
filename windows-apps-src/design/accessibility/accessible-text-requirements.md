---
Description: このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。
ms.assetid: BA689C76-FE68-4B5B-9E8D-1E7697F737E6
title: アクセシビリティに対応したテキストの要件
label: Accessible text requirements
template: detail.hbs
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3f474ec0c3017c3834d3eadb6f1caa989fc188a7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653337"
---
# <a name="accessible-text-requirements"></a><span data-ttu-id="166ce-104">アクセシビリティに対応したテキストの要件</span><span class="sxs-lookup"><span data-stu-id="166ce-104">Accessible text requirements</span></span>  




<span data-ttu-id="166ce-105">このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="166ce-105">This topic describes best practices for accessibility of text in an app, by assuring that colors and backgrounds satisfy the necessary contrast ratio.</span></span> <span data-ttu-id="166ce-106">また、ユニバーサル Windows プラットフォーム (UWP) アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。</span><span class="sxs-lookup"><span data-stu-id="166ce-106">This topic also discusses the Microsoft UI Automation roles that text elements in a Universal Windows Platform (UWP) app can have, and best practices for text in graphics.</span></span>

<span id="contrast_rations"/>
<span id="CONTRAST_RATIONS"/>

## <a name="contrast-ratios"></a><span data-ttu-id="166ce-107">コントラスト比</span><span class="sxs-lookup"><span data-stu-id="166ce-107">Contrast ratios</span></span>  
<span data-ttu-id="166ce-108">ユーザーはハイ コントラスト モードにいつでも切り替えることができますが、テキスト用のアプリ設計ではこのオプションを最後の手段にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-108">Although users always have the option to switch to a high-contrast mode, your app design for text should regard that option as a last resort.</span></span> <span data-ttu-id="166ce-109">これよりも、アプリのテキストが、テキストと背景とのコントラストのレベルに関して確立されているガイドラインに準拠するようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="166ce-109">A much better practice is to make sure that your app text meets certain established guidelines for the level of contrast between text and its background.</span></span> <span data-ttu-id="166ce-110">コントラストのレベルは、色合いを考慮しない確定的な方法に基づいて評価されます。</span><span class="sxs-lookup"><span data-stu-id="166ce-110">Evaluation of the level of contrast is based on deterministic techniques that do not consider color hue.</span></span> <span data-ttu-id="166ce-111">たとえば、緑の背景の上に赤のテキストを配置すると、色覚に障碍があるユーザーはそのテキストを読み取ることができない場合があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-111">For example, if you have red text on a green background, that text might not be readable to someone with a color blindness impairment.</span></span> <span data-ttu-id="166ce-112">コントラスト比を確認して修正することで、このようなアクセシビリティの問題を防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="166ce-112">Checking and correcting the contrast ratio can prevent these types of accessibility issues.</span></span>

<span data-ttu-id="166ce-113">Standard、web アクセシビリティのテキストのコントラストがここに記載の推奨事項は[G18:確認する、コントラスト比を少なくとも 4.5: 1 がテキスト (とテキストのイメージ) の間に存在して、テキストの背景](https://go.microsoft.com/fwlink/p/?linkid=221823)します。</span><span class="sxs-lookup"><span data-stu-id="166ce-113">The recommendations for text contrast documented here are based on a web accessibility standard, [G18: Ensuring that a contrast ratio of at least 4.5:1 exists between text (and images of text) and background behind the text](https://go.microsoft.com/fwlink/p/?linkid=221823).</span></span> <span data-ttu-id="166ce-114">このガイドラインは、*W3C Techniques for WCAG 2.0* 仕様に含まれています。</span><span class="sxs-lookup"><span data-stu-id="166ce-114">This guidance exists in the *W3C Techniques for WCAG 2.0* specification.</span></span>

<span data-ttu-id="166ce-115">表示テキストがアクセシビリティに対応していると見なされるためには、背景に対する明暗のコントラスト比が最低でも 4.5:1 以上であることが必要です。</span><span class="sxs-lookup"><span data-stu-id="166ce-115">To be considered accessible, visible text must have a minimum luminosity contrast ratio of 4.5:1 against the background.</span></span> <span data-ttu-id="166ce-116">ただし、ロゴや、非アクティブな UI コンポーネントの一部のテキストなどの付随テキストは、例外です。</span><span class="sxs-lookup"><span data-stu-id="166ce-116">Exceptions include logos and incidental text, such as text that is part of an inactive UI component.</span></span>

<span data-ttu-id="166ce-117">装飾テキストや、伝える情報がないテキストも例外になります。</span><span class="sxs-lookup"><span data-stu-id="166ce-117">Text that is decorative and conveys no information is excluded.</span></span> <span data-ttu-id="166ce-118">たとえば、ランダムな文字を使って背景を作成し、意味を変えることなくその文字を再配置したり置換したりできる場合、文字は装飾と見なされ、この基準を満たす必要がありません。</span><span class="sxs-lookup"><span data-stu-id="166ce-118">For example, if random words are used to create a background, and the words can be rearranged or substituted without changing meaning, the words are considered to be decorative and do not need to meet this criterion.</span></span>

<span data-ttu-id="166ce-119">色コントラスト ツールを使って、表示テキストのコントラスト比が適切であることを検証します。</span><span class="sxs-lookup"><span data-stu-id="166ce-119">Use color contrast tools to verify that the visible text contrast ratio is acceptable.</span></span> <span data-ttu-id="166ce-120">コントラスト比をテストできるツールについては、[Techniques for WCAG 2.0 の G18 (リソース セクション)](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="166ce-120">See [Techniques for WCAG 2.0 G18 (Resources section)](https://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) for tools that can test contrast ratios.</span></span>

> [!NOTE]
> <span data-ttu-id="166ce-121">Techniques for WCAG 2.0 の G18 にリストされたツールのいくつかは、UWP アプリで対話的に使うことができません。</span><span class="sxs-lookup"><span data-stu-id="166ce-121">Some of the tools listed by Techniques for WCAG 2.0 G18 can't be used interactively with a UWP app.</span></span> <span data-ttu-id="166ce-122">場合によっては、前景と背景の色の値を手動でツールに入力する必要があります。またアプリ UI の画面をキャプチャした後、そのキャプチャ画像に対してコントラスト比ツールを実行することが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="166ce-122">You may need to enter foreground and background color values manually in the tool, or make screen captures of app UI and then run the contrast ratio tool over the screen capture image.</span></span>

<span id="Text_element_roles"/>
<span id="text_element_roles"/>
<span id="TEXT_ELEMENT_ROLES"/>

## <a name="text-element-roles"></a><span data-ttu-id="166ce-123">テキスト要素の役割</span><span class="sxs-lookup"><span data-stu-id="166ce-123">Text element roles</span></span>  
<span data-ttu-id="166ce-124">UWP アプリでは、次の既定の要素 (一般に*テキスト要素*または*テキスト編集コントロール*と呼ばれる) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="166ce-124">A UWP app can use these default elements (commonly called *text elements* or *textedit controls*):</span></span>

* <span data-ttu-id="166ce-125">[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652): 役割は、 [**テキスト**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="166ce-125">[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652): role is [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>
* <span data-ttu-id="166ce-126">[**テキスト ボックス**](https://msdn.microsoft.com/library/windows/apps/BR209683): 役割は、 [**編集**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="166ce-126">[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683): role is [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>
* <span data-ttu-id="166ce-127">[**RichTextBlock** ](https://msdn.microsoft.com/library/windows/apps/BR227565) (とクラスを overflow [ **RichTextBlockOverflow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.richtextblockoverflow)): 役割は、 [**テキスト**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="166ce-127">[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) (and overflow class [**RichTextBlockOverflow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.richtextblockoverflow)): role is [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>
* <span data-ttu-id="166ce-128">[**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/BR227548): 役割は、 [**編集**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="166ce-128">[**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/BR227548): role is [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>

<span data-ttu-id="166ce-129">コントロールから [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182) の役割があることが報告されると、支援技術では、ユーザーが値を変更できると想定します。</span><span class="sxs-lookup"><span data-stu-id="166ce-129">When a control reports that is has a role of [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182), assistive technologies assume that there are ways for users to change the values.</span></span> <span data-ttu-id="166ce-130">このため、静的テキストを [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) に配置すると、役割が誤って報告され、この結果、アクセシビリティ対応を必要とするユーザーにアプリの構造が誤って報告されます。</span><span class="sxs-lookup"><span data-stu-id="166ce-130">So if you put static text in a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683), you are misreporting the role and thus misreporting the structure of your app to the accessibility user.</span></span>

<span data-ttu-id="166ce-131">XAML のテキスト モデルでは、静的なテキスト、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) で主に使われる 2 つの要素があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-131">In the text models for XAML, there are two elements that are primarily used for static text, [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) and [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565).</span></span> <span data-ttu-id="166ce-132">これらはいずれも [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) サブクラスではないため、キーボード フォーカス可能でなく、またタブ オーダーに含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="166ce-132">Neither of these are a [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) subclass, and as such neither of them are keyboard-focusable or can appear in the tab order.</span></span> <span data-ttu-id="166ce-133">ただし、支援技術でそれらを読み取ることができないか、または読み取られないわけではありません。</span><span class="sxs-lookup"><span data-stu-id="166ce-133">But that does not mean that assistive technologies can't or won't read them.</span></span> <span data-ttu-id="166ce-134">スクリーン リーダーは一般的に、「仮想カーソル」など、フォーカスとタブ オーダーを超える専用読み取り値モードやナビゲーション パターンを含めて、アプリ内のコンテンツを読み取る複数のモードをサポートするように設計されています。</span><span class="sxs-lookup"><span data-stu-id="166ce-134">Screen readers are typically designed to support multiple modes of reading the content in an app, including a dedicated reading mode or navigation patterns that go beyond focus and the tab order, like a "virtual cursor".</span></span> <span data-ttu-id="166ce-135">したがって、タブ オーダーによりユーザーが移動できることのみを理由として、フォーカス可能なコンテナーに静的テキストを格納しないでください。</span><span class="sxs-lookup"><span data-stu-id="166ce-135">So don't put your static text into focusable containers just so that tab order gets the user there.</span></span> <span data-ttu-id="166ce-136">支援技術ユーザーは、タブ オーダー内では対話的であることを期待しており、そこに静的なテキストが存在するとその有用性にも増して、混乱を招くことになります。</span><span class="sxs-lookup"><span data-stu-id="166ce-136">Assistive technology users expect that anything in the tab order is interactive, and if they encounter static text there, that is more confusing than helpful.</span></span> <span data-ttu-id="166ce-137">アプリの静的テキストを調べるためにスクリーン リーダーを使う場合に、アプリに対するユーザー エクスペリエンスの感覚を得るために、自身で、ナレーターによりこの出力のテストを行う必要があります</span><span class="sxs-lookup"><span data-stu-id="166ce-137">You should test this out yourself with Narrator to get a sense of the user experience with your app when using a screen reader to examine your app's static text.</span></span>

<span id="Auto-suggest_accessibility"/>
<span id="auto-suggest_accessibility"/>
<span id="AUTO-SUGGEST_ACCESSIBILITY"/>

## <a name="auto-suggest-accessibility"></a><span data-ttu-id="166ce-138">自動提案のアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="166ce-138">Auto-suggest accessibility</span></span>  
<span data-ttu-id="166ce-139">ユーザーが入力フィールドに入力すると、潜在的な候補の一覧が表示される場合、この種のシナリオは自動提案と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="166ce-139">When a user types into an entry field and a list of potential suggestions appears, this type of scenario is called auto-suggest.</span></span> <span data-ttu-id="166ce-140">これは、メールの**宛先:** 行フィールド、Windows の Cortana 検索ボックス、Microsoft Edge の URL 入力フィールド、天気予報アプリの場所入力フィールドなどでよく使用されます。</span><span class="sxs-lookup"><span data-stu-id="166ce-140">This is common in the **To:** line of a mail field, the Cortana search box in Windows, the URL entry field in Microsoft Edge, the location entry field in the Weather app, and so on.</span></span> <span data-ttu-id="166ce-141">XAML の [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) や HTML の組み込みコントロールを使用している場合、このエクスペリエンスは既定で用意されています。</span><span class="sxs-lookup"><span data-stu-id="166ce-141">If you are using a XAML [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) or the HTML intrinsic controls, then this experience is already hooked up for you by default.</span></span> <span data-ttu-id="166ce-142">このエクスペリエンスをアクセシビリティ対応にするには、入力フィールドと一覧を関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-142">To make this experience accessible the entry field and the list must be associated.</span></span> <span data-ttu-id="166ce-143">これについては、「[自動提案の実装](#implementing_auto-suggest)」セクションで説明しています。</span><span class="sxs-lookup"><span data-stu-id="166ce-143">This is explained in the [Implementing auto-suggest](#implementing_auto-suggest) section.</span></span>

<span data-ttu-id="166ce-144">ナレーターは、特別な候補の表示モードによって、このタイプのエクスペリエンスをアクセシビリティ対応にするように更新されました。</span><span class="sxs-lookup"><span data-stu-id="166ce-144">Narrator has been updated to make this type of experience accessible with a special suggestions mode.</span></span> <span data-ttu-id="166ce-145">大まかに言うと、編集フィールドと一覧が正しく接続されている場合、エンドユーザーには次のようなメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="166ce-145">At a high level, when the edit field and list are connected properly the end user will:</span></span>

* <span data-ttu-id="166ce-146">一覧が存在していることと一覧が閉じるタイミングを把握する</span><span class="sxs-lookup"><span data-stu-id="166ce-146">Know the list is present and when the list closes</span></span>
* <span data-ttu-id="166ce-147">利用可能な入力候補の数を把握する</span><span class="sxs-lookup"><span data-stu-id="166ce-147">Know how many suggestions are available</span></span>
* <span data-ttu-id="166ce-148">項目が選択されている場合は、選択項目を把握する</span><span class="sxs-lookup"><span data-stu-id="166ce-148">Know the selected item, if any</span></span>
* <span data-ttu-id="166ce-149">ナレーターのフォーカスを一覧に移動できる</span><span class="sxs-lookup"><span data-stu-id="166ce-149">Be able to move Narrator focus to the list</span></span>
* <span data-ttu-id="166ce-150">他のすべての閲覧モードで候補内を移動できる</span><span class="sxs-lookup"><span data-stu-id="166ce-150">Be able to navigate through a suggestion with all other reading modes</span></span>

<span data-ttu-id="166ce-151">![候補リスト](images/autosuggest-list.png)</span><span class="sxs-lookup"><span data-stu-id="166ce-151">![Suggestion list](images/autosuggest-list.png)</span></span><br/>
<span data-ttu-id="166ce-152">_候補リストの例_</span><span class="sxs-lookup"><span data-stu-id="166ce-152">_Example of a suggestion list_</span></span>

<span id="Implementing_auto-suggest"/>
<span id="implementing_auto-suggest"/>
<span id="IMPLEMENTING_AUTO-SUGGEST"/>

### <a name="implementing-auto-suggest"></a><span data-ttu-id="166ce-153">自動提案の実装</span><span class="sxs-lookup"><span data-stu-id="166ce-153">Implementing auto-suggest</span></span>  
<span data-ttu-id="166ce-154">このエクスペリエンスをアクセシビリティ対応にするには、UIA ツリーで、入力フィールドと一覧が関連付けられている必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-154">To make this experience accessible the entry field and the list must be associated in the UIA tree.</span></span> <span data-ttu-id="166ce-155">この関連付けは、デスクトップ アプリの [UIA_ControllerForPropertyId](https://msdn.microsoft.com/windows/desktop/ee684017) プロパティまたは UWP アプリの [ControlledPeers](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) プロパティを使って設定されます。</span><span class="sxs-lookup"><span data-stu-id="166ce-155">This association is done with the [UIA_ControllerForPropertyId](https://msdn.microsoft.com/windows/desktop/ee684017) property in desktop apps or the [ControlledPeers](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) property in UWP apps.</span></span>

<span data-ttu-id="166ce-156">自動提案のエクスペリエンスには、大まかに 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-156">At a high level there are 2 types of auto-suggest experiences.</span></span>

<span data-ttu-id="166ce-157">**既定の選択**</span><span class="sxs-lookup"><span data-stu-id="166ce-157">**Default selection**</span></span>  
<span data-ttu-id="166ce-158">一覧で既定の選択が行われる場合、ナレーターは、デスクトップ アプリでは [**UIA_SelectionItem_ElementSelectedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223) イベント、UWP アプリでは [**AutomationEvents.SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントの発生を検索します。</span><span class="sxs-lookup"><span data-stu-id="166ce-158">If a default selection is made in the list, Narrator looks for a  [**UIA_SelectionItem_ElementSelectedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223) event in a desktop app, or the [**AutomationEvents.SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) event to be fired in a UWP app.</span></span> <span data-ttu-id="166ce-159">選択項目が変更されるたび、つまりユーザーが別の文字を入力して候補が更新されたときや、ユーザーが一覧内を移動したときに、**ElementSelected** イベントが発生する必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-159">Every time the selection changes, when the user types another letter and the suggestions have been updated or when a user navigates through the list, the **ElementSelected** event should be fired.</span></span>

<span data-ttu-id="166ce-160">![既定値を選択した場合、ボックスの一覧します。](images/autosuggest-default-selection.png)</span><span class="sxs-lookup"><span data-stu-id="166ce-160">![List with a default selection](images/autosuggest-default-selection.png)</span></span><br/>
<span data-ttu-id="166ce-161">_例が、既定の選択_</span><span class="sxs-lookup"><span data-stu-id="166ce-161">_Example where there is a default selection_</span></span>

<span data-ttu-id="166ce-162">**既定の選択がありません。**</span><span class="sxs-lookup"><span data-stu-id="166ce-162">**No default selection**</span></span>  
<span data-ttu-id="166ce-163">天気予報アプリの場所のボックスなど、既定の選択がない場合、ナレーターはデスクトップの [**UIA_LayoutInvalidatedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223 ) イベントまたは UWP の [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントの発生を検索します。</span><span class="sxs-lookup"><span data-stu-id="166ce-163">If there is no default selection, such as in the Weather app’s location box, then Narrator looks for the desktop [**UIA_LayoutInvalidatedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223 ) event or the UWP [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) event to be fired on the list every time the list is updated.</span></span>

<span data-ttu-id="166ce-164">![既定値も選択されていないを一覧表示します。](images/autosuggest-no-default-selection.png)</span><span class="sxs-lookup"><span data-stu-id="166ce-164">![List with no default selection](images/autosuggest-no-default-selection.png)</span></span><br/>
<span data-ttu-id="166ce-165">_例を既定の選択が存在しません。_</span><span class="sxs-lookup"><span data-stu-id="166ce-165">_Example where there is no default selection_</span></span>

### <a name="xaml-implementation"></a><span data-ttu-id="166ce-166">XAML の実装</span><span class="sxs-lookup"><span data-stu-id="166ce-166">XAML implementation</span></span>  
<span data-ttu-id="166ce-167">XAML の既定の [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) を使用している場合、既にすべての準備が完了しています。</span><span class="sxs-lookup"><span data-stu-id="166ce-167">If you are using the default XAML [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox), then everything is already hooked up for you.</span></span> <span data-ttu-id="166ce-168">[  **TextBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox) と一覧を使って独自の自動提案エクスペリエンスを作成している場合は、**TextBox** で一覧を [**AutomationProperties.ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) として設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-168">If you are making your own auto-suggest experience using a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox) and a list then you will need to set the list as [**AutomationProperties.ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) on the **TextBox**.</span></span> <span data-ttu-id="166ce-169">[  **ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) プロパティを追加または削除するたびに、このプロパティの **AutomationPropertyChanged** イベントを発生させる必要があります。また、この記事で既に説明したシナリオのタイプに応じて、独自の [**SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントまたは [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントを発生させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-169">You must fire the **AutomationPropertyChanged** event for the [**ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) property every time you add or remove this property and also fire your own [**SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) events or [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) events depending on your type of scenario, which was explained previously in this article.</span></span>

### <a name="html-implementation"></a><span data-ttu-id="166ce-170">HTML の実装</span><span class="sxs-lookup"><span data-stu-id="166ce-170">HTML implementation</span></span>  
<span data-ttu-id="166ce-171">HTML で組み込みのコントロールを使っている場合は、UIA 実装が既にマップされています。</span><span class="sxs-lookup"><span data-stu-id="166ce-171">If you are using the intrinsic controls in HTML, then the UIA implementation has already been mapped for you.</span></span> <span data-ttu-id="166ce-172">既に準備されている実装の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="166ce-172">Below is an example of an implementation that is already hooked up for you:</span></span>

``` HTML
<label>Sites <input id="input1" type="text" list="datalist1" /></label>
<datalist id="datalist1">
        <option value="http://www.google.com/" label="Google"></option>
        <option value="http://www.reddit.com/" label="Reddit"></option>
</datalist>
```

 <span data-ttu-id="166ce-173">独自のコントロールを作成する場合は、W3C 標準で説明されている独自の ARIA コントロールを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-173">If you are creating your own controls, you must set up your own ARIA controls, which are explained in the W3C standards.</span></span>

<span id="Text_in_graphics"/>
<span id="text_in_graphics"/>
<span id="TEXT_IN_GRAPHICS"/>

## <a name="text-in-graphics"></a><span data-ttu-id="166ce-174">グラフィックス内のテキスト</span><span class="sxs-lookup"><span data-stu-id="166ce-174">Text in graphics</span></span>

<span data-ttu-id="166ce-175">可能な限り、テキストをグラフィックスに含めないでください。</span><span class="sxs-lookup"><span data-stu-id="166ce-175">Whenever possible, avoid including text in a graphic.</span></span> <span data-ttu-id="166ce-176">たとえば、アプリで [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) 要素として表示されるイメージ ソース ファイルにテキストを含めると、支援技術ではそのテキストのアクセスや読み取りを自動的に行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="166ce-176">For example, any text that you include in the image source file that is displayed in the app as an [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) element is not automatically accessible or readable by assistive technologies.</span></span> <span data-ttu-id="166ce-177">グラフィックス内でテキストを使う必要がある場合は、"alt テキスト" に相当するものとして指定する [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) の値に、そのテキストまたはテキストの意味の要約を含めてください。</span><span class="sxs-lookup"><span data-stu-id="166ce-177">If you must use text in graphics, make sure that the [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) value that you provide as the equivalent of "alt text" includes that text or a summary of the text's meaning.</span></span> <span data-ttu-id="166ce-178">これは、テキスト文字をベクトルから [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) の一部として作成する場合や、[**Glyphs**](https://msdn.microsoft.com/library/windows/apps/BR209921) を使って作成する場合も同様です。</span><span class="sxs-lookup"><span data-stu-id="166ce-178">Similar considerations apply if you are creating text characters from vectors as part of a [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path), or by using [**Glyphs**](https://msdn.microsoft.com/library/windows/apps/BR209921).</span></span>

<span id="Text_font_size"/>
<span id="text_font_size"/>
<span id="TEXT_FONT_SIZE"/>

## <a name="text-font-size-and-scale"></a><span data-ttu-id="166ce-179">テキストのフォント サイズとスケール</span><span class="sxs-lookup"><span data-stu-id="166ce-179">Text font size and scale</span></span>

<span data-ttu-id="166ce-180">ユーザーと、このフォントの用途は、単にアプリ内のテキストを読みづらくなってしまうことができますが小さすぎるように、アプリケーションで任意のテキストが妥当なサイズが最初に確認してください。</span><span class="sxs-lookup"><span data-stu-id="166ce-180">Users can have difficulty reading text in an app when the fonts uses are simply too small, so make sure any text in your application is a reasonable size in the first place.</span></span>

<span data-ttu-id="166ce-181">完了すると、明確な Windows にはさまざまなアクセシビリティ ツールとユーザーが活用し、独自のニーズとテキストを読み取るための基本設定を調整する設定が含まれます。</span><span class="sxs-lookup"><span data-stu-id="166ce-181">Once you've done the obvious, Windows includes various accessibility tools and settings that users can take advantage of and adjust to their own needs and preferences for reading text.</span></span> <span data-ttu-id="166ce-182">次のようなクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="166ce-182">These include:</span></span>

* <span data-ttu-id="166ce-183">拡大鏡ツール、UI の選択範囲を拡大します。</span><span class="sxs-lookup"><span data-stu-id="166ce-183">The Magnifier tool, which enlarges a selected area of the UI.</span></span> <span data-ttu-id="166ce-184">アプリ内のテキストのレイアウトが困難に拡大鏡を使用して、読み取り用に行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="166ce-184">You should ensure the layout of text in your app doesn't make it difficult to use Magnifier for reading.</span></span>
* <span data-ttu-id="166ce-185">スケールと解像度の設定をグローバル**設定]、[システムの表示]-> [-> スケールとレイアウト**します。</span><span class="sxs-lookup"><span data-stu-id="166ce-185">Global scale and resolution settings in **Settings->System->Display->Scale and layout**.</span></span> <span data-ttu-id="166ce-186">正確にサイズ変更オプションが使用可能なディスプレイ デバイスの機能に依存とは異なります。</span><span class="sxs-lookup"><span data-stu-id="166ce-186">Exactly which sizing options are available can vary as this depends on the capabilities of the display device.</span></span>
* <span data-ttu-id="166ce-187">テキスト サイズ設定\*\*設定、アクセスの容易さの表示-> \*\*します。</span><span class="sxs-lookup"><span data-stu-id="166ce-187">Text size settings in **Settings->Ease of access->Display**.</span></span> <span data-ttu-id="166ce-188">調整、**テキストを大きく**すべてのアプリケーションと画面 (すべての UWP テキスト コントロールは、テキストをカスタマイズまたはテンプレートなしのエクスペリエンスをスケーリングをサポート) 間でのサポート コントロールでテキストのサイズだけを指定する設定。</span><span class="sxs-lookup"><span data-stu-id="166ce-188">Adjust the **Make text bigger** setting to specify only the size of text in supporting controls across all applications and screens (all UWP text controls support the text scaling experience without any customization or templating).</span></span> 
> [!NOTE]
> <span data-ttu-id="166ce-189">**すべての大きな**設定により、ユーザーのプライマリ画面のみに一般にテキストとアプリの推奨サイズを指定します。</span><span class="sxs-lookup"><span data-stu-id="166ce-189">The **Make everything bigger** setting lets a user specify their preferred size for text and apps in general on their primary screen only.</span></span>

<span data-ttu-id="166ce-190">さまざまなテキスト要素とコントロールには [**IsTextScaleFactorEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.istextscalefactorenabled) プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="166ce-190">Various text elements and controls have an [**IsTextScaleFactorEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.istextscalefactorenabled) property.</span></span> <span data-ttu-id="166ce-191">このプロパティの既定値は **true** です。</span><span class="sxs-lookup"><span data-stu-id="166ce-191">This property has the value **true** by default.</span></span> <span data-ttu-id="166ce-192">ときに**true**、その要素内のテキストのサイズをスケールできます。</span><span class="sxs-lookup"><span data-stu-id="166ce-192">When **true**, the size of text in that element can be scaled.</span></span> <span data-ttu-id="166ce-193">スケーリングが小規模のテキストに影響を与えます**FontSize**が大規模なテキストに影響を与えるよりも高いに**FontSize**します。</span><span class="sxs-lookup"><span data-stu-id="166ce-193">The scaling affects text that has a small **FontSize** to a greater degree than it affects text that has a large **FontSize**.</span></span> <span data-ttu-id="166ce-194">要素の設定の自動サイズ変更を無効にした**IsTextScaleFactorEnabled**プロパティを**false**します。</span><span class="sxs-lookup"><span data-stu-id="166ce-194">You can disable automatic resizing by setting an element's **IsTextScaleFactorEnabled** property to **false**.</span></span> 

<span data-ttu-id="166ce-195">参照してください[テキスト スケーリング](https://docs.microsoft.com/windows/uwp/design/input/text-scaling)の詳細。</span><span class="sxs-lookup"><span data-stu-id="166ce-195">See [Text scaling](https://docs.microsoft.com/windows/uwp/design/input/text-scaling) for more details.</span></span>

<span data-ttu-id="166ce-196">次のマークアップをアプリに追加し、それを実行します。</span><span class="sxs-lookup"><span data-stu-id="166ce-196">Add the following markup to an app and run it.</span></span> <span data-ttu-id="166ce-197">調整、**テキスト サイズ**を設定して、それぞれに何が起こるか見て**TextBlock**します。</span><span class="sxs-lookup"><span data-stu-id="166ce-197">Adjust the **Text size** setting, and see what happens to each **TextBlock**.</span></span>

<span data-ttu-id="166ce-198">XAML</span><span class="sxs-lookup"><span data-stu-id="166ce-198">XAML</span></span>
```xml
<TextBlock Text="In this case, IsTextScaleFactorEnabled has been left set to its default value of true."
    Style="{StaticResource BodyTextBlockStyle}"/>

<TextBlock Text="In this case, IsTextScaleFactorEnabled has been set to false."
    Style="{StaticResource BodyTextBlockStyle}" IsTextScaleFactorEnabled="False"/>
```  

<span data-ttu-id="166ce-199">テキストのすべてのアプリ間で汎用的スケーリングの UI テキストがユーザーにとっては重要なユーザー補助のスケーリングを無効にすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="166ce-199">We don't recommend that you disable text scaling as scaling UI text universally across all apps is an important accessibility experience for users.</span></span>

<span data-ttu-id="166ce-200">[  **TextScaleFactorChanged**](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) イベントと [**TextScaleFactor**](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactor) プロパティを使って、電話の **[テキスト サイズ]** 設定の変更に関する情報を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="166ce-200">You can also use the [**TextScaleFactorChanged**](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactorchanged) event and the [**TextScaleFactor**](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.uisettings.textscalefactor) property to find out about changes to the **Text size** setting on the phone.</span></span> <span data-ttu-id="166ce-201">方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="166ce-201">Here’s how:</span></span>

<span data-ttu-id="166ce-202">C#</span><span class="sxs-lookup"><span data-stu-id="166ce-202">C#</span></span>
```csharp
{
    ...
    var uiSettings = new Windows.UI.ViewManagement.UISettings();
    uiSettings.TextScaleFactorChanged += UISettings_TextScaleFactorChanged;
    ...
}

private async void UISettings_TextScaleFactorChanged(Windows.UI.ViewManagement.UISettings sender, object args)
{
    var messageDialog = new Windows.UI.Popups.MessageDialog(string.Format("It's now {0}", sender.TextScaleFactor), "The text scale factor has changed");
    await messageDialog.ShowAsync();
}
```

<span data-ttu-id="166ce-203">値**TextScaleFactor**が範囲内の二重\[1,2.25\]します。</span><span class="sxs-lookup"><span data-stu-id="166ce-203">The value of **TextScaleFactor** is a double in the range \[1,2.25\].</span></span> <span data-ttu-id="166ce-204">最も小さい文字がこの大きさまで拡大されます。</span><span class="sxs-lookup"><span data-stu-id="166ce-204">The smallest text is scaled up by this amount.</span></span> <span data-ttu-id="166ce-205">たとえば、この値を使ってテキストに合わせてグラフィックスを拡大縮小できます。</span><span class="sxs-lookup"><span data-stu-id="166ce-205">You might be able to use the value to, say, scale graphics to match the text.</span></span> <span data-ttu-id="166ce-206">ただし、すべてのテキストが同じ倍率で拡大縮小されるわけではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="166ce-206">But remember that not all text is scaled by the same factor.</span></span> <span data-ttu-id="166ce-207">一般に、最初の状態のテキストのサイズが大きいほど、拡大縮小の影響は小さくなります。</span><span class="sxs-lookup"><span data-stu-id="166ce-207">Generally speaking, the larger text is to begin with, the less it’s affected by scaling.</span></span>

<span data-ttu-id="166ce-208">次の型に **IsTextScaleFactorEnabled** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="166ce-208">These types have an **IsTextScaleFactorEnabled** property:</span></span>  
* [<span data-ttu-id="166ce-209">**ContentPresenter**</span><span class="sxs-lookup"><span data-stu-id="166ce-209">**ContentPresenter**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR209378)
* <span data-ttu-id="166ce-210">[**コントロール**](https://msdn.microsoft.com/library/windows/apps/BR209390)と派生クラス</span><span class="sxs-lookup"><span data-stu-id="166ce-210">[**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) and derived classes</span></span>
* [<span data-ttu-id="166ce-211">**FontIcon**</span><span class="sxs-lookup"><span data-stu-id="166ce-211">**FontIcon**</span></span>](https://msdn.microsoft.com/library/windows/apps/Dn279514)
* [<span data-ttu-id="166ce-212">**RichTextBlock**</span><span class="sxs-lookup"><span data-stu-id="166ce-212">**RichTextBlock**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR227565)
* [<span data-ttu-id="166ce-213">**TextBlock**</span><span class="sxs-lookup"><span data-stu-id="166ce-213">**TextBlock**</span></span>](https://msdn.microsoft.com/library/windows/apps/BR209652)
* <span data-ttu-id="166ce-214">[**TextElement** ](https://msdn.microsoft.com/library/windows/apps/BR209967)と派生クラス</span><span class="sxs-lookup"><span data-stu-id="166ce-214">[**TextElement**](https://msdn.microsoft.com/library/windows/apps/BR209967) and derived classes</span></span>

<span id="related_topics"/>

## <a name="related-topics"></a><span data-ttu-id="166ce-215">関連トピック</span><span class="sxs-lookup"><span data-stu-id="166ce-215">Related topics</span></span>  

* [<span data-ttu-id="166ce-216">テキストのスケーリング</span><span class="sxs-lookup"><span data-stu-id="166ce-216">Text scaling</span></span>](https://docs.microsoft.com/windows/uwp/design/input/text-scaling)
* [<span data-ttu-id="166ce-217">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="166ce-217">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="166ce-218">基本的なユーザー補助情報</span><span class="sxs-lookup"><span data-stu-id="166ce-218">Basic accessibility information</span></span>](basic-accessibility-information.md)
* [<span data-ttu-id="166ce-219">XAML テキスト表示のサンプル</span><span class="sxs-lookup"><span data-stu-id="166ce-219">XAML text display sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=238579)
* [<span data-ttu-id="166ce-220">XAML テキスト編集のサンプル</span><span class="sxs-lookup"><span data-stu-id="166ce-220">XAML text editing sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=251417)
* [<span data-ttu-id="166ce-221">XAML のアクセシビリティのサンプル</span><span class="sxs-lookup"><span data-stu-id="166ce-221">XAML accessibility sample</span></span>](https://go.microsoft.com/fwlink/p/?linkid=238570) 
