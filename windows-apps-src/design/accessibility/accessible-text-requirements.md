---
author: Xansky
Description: This topic describes best practices for accessibility of text in an app, by assuring that colors and backgrounds satisfy the necessary contrast ratio.
ms.assetid: BA689C76-FE68-4B5B-9E8D-1E7697F737E6
title: アクセシビリティに対応したテキストの要件
label: Accessible text requirements
template: detail.hbs
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f871068ec9964256642f31cafe55b34e2b2a7807
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1655894"
---
# <a name="accessible-text-requirements"></a><span data-ttu-id="b957d-103">アクセシビリティに対応したテキストの要件</span><span class="sxs-lookup"><span data-stu-id="b957d-103">Accessible text requirements</span></span>  




<span data-ttu-id="b957d-104">このトピックでは、色と背景のコントラスト比を適切な値にすることで、アプリのテキストをアクセシビリティ対応にするためのベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="b957d-104">This topic describes best practices for accessibility of text in an app, by assuring that colors and backgrounds satisfy the necessary contrast ratio.</span></span> <span data-ttu-id="b957d-105">また、ユニバーサル Windows プラットフォーム (UWP) アプリ内のテキスト要素に設定できる Microsoft UI オートメーションの役割と、グラフィックス内のテキストに関するベスト プラクティスについても説明します。</span><span class="sxs-lookup"><span data-stu-id="b957d-105">This topic also discusses the Microsoft UI Automation roles that text elements in a Universal Windows Platform (UWP) app can have, and best practices for text in graphics.</span></span>

<span id="contrast_rations"/>
<span id="CONTRAST_RATIONS"/>

## <a name="contrast-ratios"></a><span data-ttu-id="b957d-106">コントラスト比</span><span class="sxs-lookup"><span data-stu-id="b957d-106">Contrast ratios</span></span>  
<span data-ttu-id="b957d-107">ユーザーはハイ コントラスト モードにいつでも切り替えることができますが、テキスト用のアプリ設計ではこのオプションを最後の手段にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-107">Although users always have the option to switch to a high-contrast mode, your app design for text should regard that option as a last resort.</span></span> <span data-ttu-id="b957d-108">これよりも、アプリのテキストが、テキストと背景とのコントラストのレベルに関して確立されているガイドラインに準拠するようにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b957d-108">A much better practice is to make sure that your app text meets certain established guidelines for the level of contrast between text and its background.</span></span> <span data-ttu-id="b957d-109">コントラストのレベルは、色合いを考慮しない確定的な方法に基づいて評価されます。</span><span class="sxs-lookup"><span data-stu-id="b957d-109">Evaluation of the level of contrast is based on deterministic techniques that do not consider color hue.</span></span> <span data-ttu-id="b957d-110">たとえば、緑の背景の上に赤のテキストを配置すると、色覚に障碍があるユーザーはそのテキストを読み取ることができない場合があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-110">For example, if you have red text on a green background, that text might not be readable to someone with a color blindness impairment.</span></span> <span data-ttu-id="b957d-111">コントラスト比を確認して修正することで、このようなアクセシビリティの問題を防ぐことができます。</span><span class="sxs-lookup"><span data-stu-id="b957d-111">Checking and correcting the contrast ratio can prevent these types of accessibility issues.</span></span>

<span data-ttu-id="b957d-112">ここで説明するテキストのコントラストに関する推奨事項は、「[G18: テキスト (および画像化された文字) とテキストの背景のコントラスト比を 4.5:1 以上にする](http://go.microsoft.com/fwlink/p/?linkid=221823)」という Web アクセシビリティ標準に基づいています。</span><span class="sxs-lookup"><span data-stu-id="b957d-112">The recommendations for text contrast documented here are based on a web accessibility standard, [G18: Ensuring that a contrast ratio of at least 4.5:1 exists between text (and images of text) and background behind the text](http://go.microsoft.com/fwlink/p/?linkid=221823).</span></span> <span data-ttu-id="b957d-113">このガイドラインは、*W3C Techniques for WCAG 2.0* 仕様に含まれています。</span><span class="sxs-lookup"><span data-stu-id="b957d-113">This guidance exists in the *W3C Techniques for WCAG 2.0* specification.</span></span>

<span data-ttu-id="b957d-114">表示テキストがアクセシビリティに対応していると見なされるためには、背景に対する明暗のコントラスト比が最低でも 4.5:1 以上であることが必要です。</span><span class="sxs-lookup"><span data-stu-id="b957d-114">To be considered accessible, visible text must have a minimum luminosity contrast ratio of 4.5:1 against the background.</span></span> <span data-ttu-id="b957d-115">ただし、ロゴや、非アクティブな UI コンポーネントの一部のテキストなどの付随テキストは、例外です。</span><span class="sxs-lookup"><span data-stu-id="b957d-115">Exceptions include logos and incidental text, such as text that is part of an inactive UI component.</span></span>

<span data-ttu-id="b957d-116">装飾テキストや、伝える情報がないテキストも例外になります。</span><span class="sxs-lookup"><span data-stu-id="b957d-116">Text that is decorative and conveys no information is excluded.</span></span> <span data-ttu-id="b957d-117">たとえば、ランダムな文字を使って背景を作成し、意味を変えることなくその文字を再配置したり置換したりできる場合、文字は装飾と見なされ、この基準を満たす必要がありません。</span><span class="sxs-lookup"><span data-stu-id="b957d-117">For example, if random words are used to create a background, and the words can be rearranged or substituted without changing meaning, the words are considered to be decorative and do not need to meet this criterion.</span></span>

<span data-ttu-id="b957d-118">色コントラスト ツールを使って、表示テキストのコントラスト比が適切であることを検証します。</span><span class="sxs-lookup"><span data-stu-id="b957d-118">Use color contrast tools to verify that the visible text contrast ratio is acceptable.</span></span> <span data-ttu-id="b957d-119">コントラスト比をテストできるツールについては、[Techniques for WCAG 2.0 の G18 (リソース セクション)](http://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b957d-119">See [Techniques for WCAG 2.0 G18 (Resources section)](http://www.w3.org/TR/WCAG20-TECHS/G18.html#G18-resources) for tools that can test contrast ratios.</span></span>

> [!NOTE]
> <span data-ttu-id="b957d-120">Techniques for WCAG 2.0 の G18 にリストされたツールのいくつかは、UWP アプリで対話的に使うことができません。</span><span class="sxs-lookup"><span data-stu-id="b957d-120">Some of the tools listed by Techniques for WCAG 2.0 G18 can't be used interactively with a UWP app.</span></span> <span data-ttu-id="b957d-121">場合によっては、前景と背景の色の値を手動でツールに入力する必要があります。またアプリ UI の画面をキャプチャした後、そのキャプチャ画像に対してコントラスト比ツールを実行することが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="b957d-121">You may need to enter foreground and background color values manually in the tool, or make screen captures of app UI and then run the contrast ratio tool over the screen capture image.</span></span>

<span id="Text_element_roles"/>
<span id="text_element_roles"/>
<span id="TEXT_ELEMENT_ROLES"/>

## <a name="text-element-roles"></a><span data-ttu-id="b957d-122">テキスト要素の役割</span><span class="sxs-lookup"><span data-stu-id="b957d-122">Text element roles</span></span>  
<span data-ttu-id="b957d-123">UWP アプリでは、次の既定の要素 (一般に*テキスト要素*または*テキスト編集コントロール*と呼ばれる) を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="b957d-123">A UWP app can use these default elements (commonly called *text elements* or *textedit controls*):</span></span>

* <span data-ttu-id="b957d-124">[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652): 役割は [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="b957d-124">[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652): role is [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>
* <span data-ttu-id="b957d-125">[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683): 役割は [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="b957d-125">[**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683): role is [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>
* <span data-ttu-id="b957d-126">[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) (とオーバーフロー クラス [**RichTextBlockOverflow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.richtextblockoverflow)): 役割は [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="b957d-126">[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) (and overflow class [**RichTextBlockOverflow**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.richtextblockoverflow)): role is [**Text**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>
* <span data-ttu-id="b957d-127">[**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/BR227548): 役割は [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span><span class="sxs-lookup"><span data-stu-id="b957d-127">[**RichEditBox**](https://msdn.microsoft.com/library/windows/apps/BR227548): role is [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182)</span></span>

<span data-ttu-id="b957d-128">コントロールから [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182) の役割があることが報告されると、支援技術では、ユーザーが値を変更できると想定します。</span><span class="sxs-lookup"><span data-stu-id="b957d-128">When a control reports that is has a role of [**Edit**](https://msdn.microsoft.com/library/windows/apps/BR209182), assistive technologies assume that there are ways for users to change the values.</span></span> <span data-ttu-id="b957d-129">このため、静的テキストを [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) に配置すると、役割が誤って報告され、この結果、アクセシビリティ対応を必要とするユーザーにアプリの構造が誤って報告されます。</span><span class="sxs-lookup"><span data-stu-id="b957d-129">So if you put static text in a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683), you are misreporting the role and thus misreporting the structure of your app to the accessibility user.</span></span>

<span data-ttu-id="b957d-130">XAML のテキスト モデルでは、静的なテキスト、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652)、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) で主に使われる 2 つの要素があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-130">In the text models for XAML, there are two elements that are primarily used for static text, [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) and [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565).</span></span> <span data-ttu-id="b957d-131">これらはいずれも [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) サブクラスではないため、キーボード フォーカス可能でなく、またタブ オーダーに含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="b957d-131">Neither of these are a [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) subclass, and as such neither of them are keyboard-focusable or can appear in the tab order.</span></span> <span data-ttu-id="b957d-132">ただし、支援技術でそれらを読み取ることができないか、または読み取られないわけではありません。</span><span class="sxs-lookup"><span data-stu-id="b957d-132">But that does not mean that assistive technologies can't or won't read them.</span></span> <span data-ttu-id="b957d-133">スクリーン リーダーは一般的に、「仮想カーソル」など、フォーカスとタブ オーダーを超える専用読み取り値モードやナビゲーション パターンを含めて、アプリ内のコンテンツを読み取る複数のモードをサポートするように設計されています。</span><span class="sxs-lookup"><span data-stu-id="b957d-133">Screen readers are typically designed to support multiple modes of reading the content in an app, including a dedicated reading mode or navigation patterns that go beyond focus and the tab order, like a "virtual cursor".</span></span> <span data-ttu-id="b957d-134">したがって、タブ オーダーによりユーザーが移動できることのみを理由として、フォーカス可能なコンテナーに静的テキストを格納しないでください。</span><span class="sxs-lookup"><span data-stu-id="b957d-134">So don't put your static text into focusable containers just so that tab order gets the user there.</span></span> <span data-ttu-id="b957d-135">支援技術ユーザーは、タブ オーダー内では対話的であることを期待しており、そこに静的なテキストが存在するとその有用性にも増して、混乱を招くことになります。</span><span class="sxs-lookup"><span data-stu-id="b957d-135">Assistive technology users expect that anything in the tab order is interactive, and if they encounter static text there, that is more confusing than helpful.</span></span> <span data-ttu-id="b957d-136">アプリの静的テキストを調べるためにスクリーン リーダーを使う場合に、アプリに対するユーザー エクスペリエンスの感覚を得るために、自身で、ナレーターによりこの出力のテストを行う必要があります</span><span class="sxs-lookup"><span data-stu-id="b957d-136">You should test this out yourself with Narrator to get a sense of the user experience with your app when using a screen reader to examine your app's static text.</span></span>

<span id="Auto-suggest_accessibility"/>
<span id="auto-suggest_accessibility"/>
<span id="AUTO-SUGGEST_ACCESSIBILITY"/>

## <a name="auto-suggest-accessibility"></a><span data-ttu-id="b957d-137">自動提案のアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="b957d-137">Auto-suggest accessibility</span></span>  
<span data-ttu-id="b957d-138">ユーザーが入力フィールドに入力すると、潜在的な候補の一覧が表示される場合、この種のシナリオは自動提案と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="b957d-138">When a user types into an entry field and a list of potential suggestions appears, this type of scenario is called auto-suggest.</span></span> <span data-ttu-id="b957d-139">これは、メールの**宛先:** 行フィールド、Windows の Cortana 検索ボックス、Microsoft Edge の URL 入力フィールド、天気予報アプリの場所入力フィールドなどでよく使用されます。</span><span class="sxs-lookup"><span data-stu-id="b957d-139">This is common in the **To:** line of a mail field, the Cortana search box in Windows, the URL entry field in Microsoft Edge, the location entry field in the Weather app, and so on.</span></span> <span data-ttu-id="b957d-140">XAML の [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) や HTML の組み込みコントロールを使用している場合、このエクスペリエンスは既定で用意されています。</span><span class="sxs-lookup"><span data-stu-id="b957d-140">If you are using a XAML [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) or the HTML intrinsic controls, then this experience is already hooked up for you by default.</span></span> <span data-ttu-id="b957d-141">このエクスペリエンスをアクセシビリティ対応にするには、入力フィールドと一覧を関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-141">To make this experience accessible the entry field and the list must be associated.</span></span> <span data-ttu-id="b957d-142">これについては、「[自動提案の実装](#implementing_auto-suggest)」セクションで説明しています。</span><span class="sxs-lookup"><span data-stu-id="b957d-142">This is explained in the [Implementing auto-suggest](#implementing_auto-suggest) section.</span></span>

<span data-ttu-id="b957d-143">ナレーターは、特別な候補の表示モードによって、このタイプのエクスペリエンスをアクセシビリティ対応にするように更新されました。</span><span class="sxs-lookup"><span data-stu-id="b957d-143">Narrator has been updated to make this type of experience accessible with a special suggestions mode.</span></span> <span data-ttu-id="b957d-144">大まかに言うと、編集フィールドと一覧が正しく接続されている場合、エンドユーザーには次のようなメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="b957d-144">At a high level, when the edit field and list are connected properly the end user will:</span></span>

* <span data-ttu-id="b957d-145">一覧が存在していることと一覧が閉じるタイミングを把握する</span><span class="sxs-lookup"><span data-stu-id="b957d-145">Know the list is present and when the list closes</span></span>
* <span data-ttu-id="b957d-146">利用可能な入力候補の数を把握する</span><span class="sxs-lookup"><span data-stu-id="b957d-146">Know how many suggestions are available</span></span>
* <span data-ttu-id="b957d-147">項目が選択されている場合は、選択項目を把握する</span><span class="sxs-lookup"><span data-stu-id="b957d-147">Know the selected item, if any</span></span>
* <span data-ttu-id="b957d-148">ナレーターのフォーカスを一覧に移動できる</span><span class="sxs-lookup"><span data-stu-id="b957d-148">Be able to move Narrator focus to the list</span></span>
* <span data-ttu-id="b957d-149">他のすべての閲覧モードで候補内を移動できる</span><span class="sxs-lookup"><span data-stu-id="b957d-149">Be able to navigate through a suggestion with all other reading modes</span></span>

![候補一覧](images/autosuggest-list.png)<br/>
_<span data-ttu-id="b957d-151">候補一覧の例</span><span class="sxs-lookup"><span data-stu-id="b957d-151">Example of a suggestion list</span></span>_

<span id="Implementing_auto-suggest"/>
<span id="implementing_auto-suggest"/>
<span id="IMPLEMENTING_AUTO-SUGGEST"/>

### <a name="implementing-auto-suggest"></a><span data-ttu-id="b957d-152">自動提案の実装</span><span class="sxs-lookup"><span data-stu-id="b957d-152">Implementing auto-suggest</span></span>  
<span data-ttu-id="b957d-153">このエクスペリエンスをアクセシビリティ対応にするには、UIA ツリーで、入力フィールドと一覧が関連付けられている必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-153">To make this experience accessible the entry field and the list must be associated in the UIA tree.</span></span> <span data-ttu-id="b957d-154">この関連付けは、デスクトップ アプリの [UIA_ControllerForPropertyId](https://msdn.microsoft.com/windows/desktop/ee684017) プロパティまたは UWP アプリの [ControlledPeers](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) プロパティを使って設定されます。</span><span class="sxs-lookup"><span data-stu-id="b957d-154">This association is done with the [UIA_ControllerForPropertyId](https://msdn.microsoft.com/windows/desktop/ee684017) property in desktop apps or the [ControlledPeers](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) property in UWP apps.</span></span>

<span data-ttu-id="b957d-155">自動提案のエクスペリエンスには、大まかに 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-155">At a high level there are 2 types of auto-suggest experiences.</span></span>

**<span data-ttu-id="b957d-156">既定の選択</span><span class="sxs-lookup"><span data-stu-id="b957d-156">Default selection</span></span>**  
<span data-ttu-id="b957d-157">一覧で既定の選択が行われる場合、ナレーターは、デスクトップ アプリでは [**UIA_SelectionItem_ElementSelectedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223) イベント、UWP アプリでは [**AutomationEvents.SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントの発生を検索します。</span><span class="sxs-lookup"><span data-stu-id="b957d-157">If a default selection is made in the list, Narrator looks for a  [**UIA_SelectionItem_ElementSelectedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223) event in a desktop app, or the [**AutomationEvents.SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) event to be fired in a UWP app.</span></span> <span data-ttu-id="b957d-158">選択項目が変更されるたび、つまりユーザーが別の文字を入力して候補が更新されたときや、ユーザーが一覧内を移動したときに、**ElementSelected** イベントが発生する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-158">Every time the selection changes, when the user types another letter and the suggestions have been updated or when a user navigates through the list, the **ElementSelected** event should be fired.</span></span>

![既定の選択を含む一覧](images/autosuggest-default-selection.png)<br/>
_<span data-ttu-id="b957d-160">既定の選択がある場合の例</span><span class="sxs-lookup"><span data-stu-id="b957d-160">Example where there is a default selection</span></span>_

**<span data-ttu-id="b957d-161">既定の選択がない</span><span class="sxs-lookup"><span data-stu-id="b957d-161">No default selection</span></span>**  
<span data-ttu-id="b957d-162">天気予報アプリの場所のボックスなど、既定の選択がない場合、ナレーターはデスクトップの [**UIA_LayoutInvalidatedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223 ) イベントまたは UWP の [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントの発生を検索します。</span><span class="sxs-lookup"><span data-stu-id="b957d-162">If there is no default selection, such as in the Weather app’s location box, then Narrator looks for the desktop [**UIA_LayoutInvalidatedEventId**](https://msdn.microsoft.com/library/windows/desktop/ee671223 ) event or the UWP [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) event to be fired on the list every time the list is updated.</span></span>

![既定の選択がない一覧](images/autosuggest-no-default-selection.png)<br/>
_<span data-ttu-id="b957d-164">既定の選択がない場合の例</span><span class="sxs-lookup"><span data-stu-id="b957d-164">Example where there is no default selection</span></span>_

### <a name="xaml-implementation"></a><span data-ttu-id="b957d-165">XAML の実装</span><span class="sxs-lookup"><span data-stu-id="b957d-165">XAML implementation</span></span>  
<span data-ttu-id="b957d-166">XAML の既定の [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox) を使用している場合、既にすべての準備が完了しています。</span><span class="sxs-lookup"><span data-stu-id="b957d-166">If you are using the default XAML [**AutosuggestBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.autosuggestbox), then everything is already hooked up for you.</span></span> <span data-ttu-id="b957d-167">[**TextBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox) と一覧を使って独自の自動提案エクスペリエンスを作成している場合は、**TextBox** で一覧を [**AutomationProperties.ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) として設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-167">If you are making your own auto-suggest experience using a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox) and a list then you will need to set the list as [**AutomationProperties.ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) on the **TextBox**.</span></span> <span data-ttu-id="b957d-168">[**ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) プロパティを追加または削除するたびに、このプロパティの **AutomationPropertyChanged** イベントを発生させる必要があります。また、この記事で既に説明したシナリオのタイプに応じて、独自の [**SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントまたは [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) イベントを発生させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-168">You must fire the **AutomationPropertyChanged** event for the [**ControlledPeers**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.getcontrolledpeers) property every time you add or remove this property and also fire your own [**SelectionItemPatternOnElementSelected**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) events or [**LayoutInvalidated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationevents) events depending on your type of scenario, which was explained previously in this article.</span></span>

### <a name="html-implementation"></a><span data-ttu-id="b957d-169">HTML の実装</span><span class="sxs-lookup"><span data-stu-id="b957d-169">HTML implementation</span></span>  
<span data-ttu-id="b957d-170">HTML で組み込みのコントロールを使っている場合は、UIA 実装が既にマップされています。</span><span class="sxs-lookup"><span data-stu-id="b957d-170">If you are using the intrinsic controls in HTML, then the UIA implementation has already been mapped for you.</span></span> <span data-ttu-id="b957d-171">既に準備されている実装の例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b957d-171">Below is an example of an implementation that is already hooked up for you:</span></span>

``` HTML
<label>Sites <input id="input1" type="text" list="datalist1" /></label>
<datalist id="datalist1">
        <option value="http://www.google.com/" label="Google"></option>
        <option value="http://www.reddit.com/" label="Reddit"></option>
</datalist>
```

 <span data-ttu-id="b957d-172">独自のコントロールを作成する場合は、W3C 標準で説明されている独自の ARIA コントロールを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-172">If you are creating your own controls, you must set up your own ARIA controls, which are explained in the W3C standards.</span></span>

<span id="Text_in_graphics"/>
<span id="text_in_graphics"/>
<span id="TEXT_IN_GRAPHICS"/>

## <a name="text-in-graphics"></a><span data-ttu-id="b957d-173">グラフィックス内のテキスト</span><span class="sxs-lookup"><span data-stu-id="b957d-173">Text in graphics</span></span>  
<span data-ttu-id="b957d-174">可能な限り、テキストをグラフィックスに含めないでください。</span><span class="sxs-lookup"><span data-stu-id="b957d-174">Whenever possible, avoid including text in a graphic.</span></span> <span data-ttu-id="b957d-175">たとえば、アプリで [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) 要素として表示されるイメージ ソース ファイルにテキストを含めると、支援技術ではそのテキストのアクセスや読み取りを自動的に行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="b957d-175">For example, any text that you include in the image source file that is displayed in the app as an [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) element is not automatically accessible or readable by assistive technologies.</span></span> <span data-ttu-id="b957d-176">グラフィックス内でテキストを使う必要がある場合は、"alt テキスト" に相当するものとして指定する [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) の値に、そのテキストまたはテキストの意味の要約を含めてください。</span><span class="sxs-lookup"><span data-stu-id="b957d-176">If you must use text in graphics, make sure that the [**AutomationProperties.Name**](https://msdn.microsoft.com/library/windows/apps/Hh759770) value that you provide as the equivalent of "alt text" includes that text or a summary of the text's meaning.</span></span> <span data-ttu-id="b957d-177">これは、テキスト文字をベクトルから [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path) の一部として作成する場合や、[**Glyphs**](https://msdn.microsoft.com/library/windows/apps/BR209921) を使って作成する場合も同様です。</span><span class="sxs-lookup"><span data-stu-id="b957d-177">Similar considerations apply if you are creating text characters from vectors as part of a [**Path**](/uwp/api/Windows.UI.Xaml.Shapes.Path), or by using [**Glyphs**](https://msdn.microsoft.com/library/windows/apps/BR209921).</span></span>

<span id="Text_font_size"/>
<span id="text_font_size"/>
<span id="TEXT_FONT_SIZE"/>

## <a name="text-font-size"></a><span data-ttu-id="b957d-178">テキストのフォント サイズ</span><span class="sxs-lookup"><span data-stu-id="b957d-178">Text font size</span></span>  
<span data-ttu-id="b957d-179">小さすぎて読むことができないサイズのテキスト フォントが使われているだけで、多くのユーザーが、アプリのテキストを読みにくいと感じます。</span><span class="sxs-lookup"><span data-stu-id="b957d-179">Many readers have difficulty reading text in an app when that text is using a text font size that's simply too small for them to read.</span></span> <span data-ttu-id="b957d-180">この問題は、アプリの UI のテキストを最初から適切な大きさにすることで防止できます。</span><span class="sxs-lookup"><span data-stu-id="b957d-180">You can prevent this issue by making the text in your app's UI reasonably large in the first place.</span></span> <span data-ttu-id="b957d-181">Windows に含まれる支援技術もあり、これらの支援技術では、ユーザーがアプリの表示サイズや通常の表示を変更できるようにします。</span><span class="sxs-lookup"><span data-stu-id="b957d-181">There are also assistive technologies that are part of Windows, and these enable users to change the view sizes of apps, or the display in general.</span></span>

* <span data-ttu-id="b957d-182">一部のユーザーはアクセシビリティ対応オプションとして 1 インチあたりのドット数 (dpi) の値を変更します。</span><span class="sxs-lookup"><span data-stu-id="b957d-182">Some users change dots per inch (dpi) values of their primary display as an accessibility option.</span></span> <span data-ttu-id="b957d-183">このオプションは、**[コンピューターの簡単操作]** の **[画面上の項目を拡大します]** から利用できます。この操作は、**コントロール パネル**の UI の **[デスクトップのカスタマイズ]** / **[ディスプレイ]** にリダイレクトされます。</span><span class="sxs-lookup"><span data-stu-id="b957d-183">That option is available from **Make things on the screen larger** in **Ease of Access**, which redirects to a **Control Panel** UI for **Appearance and Personalization** / **Display**.</span></span> <span data-ttu-id="b957d-184">ディスプレイ デバイスの機能に左右されるため、実際に使用できるサイズ変更のオプションは異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="b957d-184">Exactly which sizing options are available can vary because this depends on the capabilities of the display device.</span></span>
* <span data-ttu-id="b957d-185">拡大鏡ツールは UI で選択された領域を拡大できます。</span><span class="sxs-lookup"><span data-stu-id="b957d-185">The Magnifier tool can enlarge a selected area of the UI.</span></span> <span data-ttu-id="b957d-186">ただし、テキストを読むために拡大鏡ツールを使うのは困難です。</span><span class="sxs-lookup"><span data-stu-id="b957d-186">However, it's difficult to use the Magnifier tool for reading text.</span></span>

<span id="Text_scale_factor"/>
<span id="text_scale_factor"/>
<span id="TEXT_SCALE_FACTOR"/>

## <a name="text-scale-factor"></a><span data-ttu-id="b957d-187">テキストの倍率</span><span class="sxs-lookup"><span data-stu-id="b957d-187">Text scale factor</span></span>  
<span data-ttu-id="b957d-188">さまざまなテキスト要素とコントロールには [**IsTextScaleFactorEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.istextscalefactorenabled) プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="b957d-188">Various text elements and controls have an [**IsTextScaleFactorEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.istextscalefactorenabled) property.</span></span> <span data-ttu-id="b957d-189">このプロパティの既定値は **true** です。</span><span class="sxs-lookup"><span data-stu-id="b957d-189">This property has the value **true** by default.</span></span> <span data-ttu-id="b957d-190">値が **true** の場合、電話の **[テキストの拡大縮小]** 設定 (**[設定] &gt; [コンピューターの簡単操作]**) に応じて、対象要素のテキストのサイズが拡大されます。</span><span class="sxs-lookup"><span data-stu-id="b957d-190">When its value is **true**, the setting called **Text scaling** on the phone (**Settings &gt; Ease of access**), causes the text size of text in that element to be scaled up.</span></span> <span data-ttu-id="b957d-191">拡大縮小は、**FontSize** が大きいテキストよりも、**FontSize** が小さいテキストにより大きな影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="b957d-191">The scaling will affect text that has a small **FontSize** to a greater degree than it will affect text that has a large **FontSize**.</span></span> <span data-ttu-id="b957d-192">ただし、要素の **IsTextScaleFactorEnabled** プロパティを **false** に設定することで自動拡大を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="b957d-192">But you can disable that automatic enlargement by setting an element's **IsTextScaleFactorEnabled** property to **false**.</span></span> <span data-ttu-id="b957d-193">次のマークアップを使って電話の **[テキスト サイズ]** 設定を調整し、**TextBlock** がどうなるのかを確認してください。</span><span class="sxs-lookup"><span data-stu-id="b957d-193">Try this markup, adjust the **Text size** setting on the phone, and see what happens to the **TextBlock**s:</span></span>

<span data-ttu-id="b957d-194">XAML</span><span class="sxs-lookup"><span data-stu-id="b957d-194">XAML</span></span>
```xml
<TextBlock Text="In this case, IsTextScaleFactorEnabled has been left set to its default value of true."
    Style="{StaticResource BodyTextBlockStyle}"/>

<TextBlock Text="In this case, IsTextScaleFactorEnabled has been set to false."
    Style="{StaticResource BodyTextBlockStyle}" IsTextScaleFactorEnabled="False"/>
```  

<span data-ttu-id="b957d-195">ただし、通常は自動拡大を無効にしないでください。一般に、UI テキストの拡大縮小はユーザーにとって重要なアクセシビリティ エクスペリエンスであり、どのアプリでもこの機能が動作することが求められています。</span><span class="sxs-lookup"><span data-stu-id="b957d-195">Please don't disable automatic enlargement routinely, though, because scaling UI text universally across all apps is an important accessibility experience for users and they will expect it to work in your app too.</span></span>

<span data-ttu-id="b957d-196">[**TextScaleFactorChanged**](https://msdn.microsoft.com/library/windows/apps/Dn633867) イベントと [**TextScaleFactor**](https://msdn.microsoft.com/library/windows/apps/Dn633866) プロパティを使って、電話の **[テキスト サイズ]** 設定の変更に関する情報を確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="b957d-196">You can also use the [**TextScaleFactorChanged**](https://msdn.microsoft.com/library/windows/apps/Dn633867) event and the [**TextScaleFactor**](https://msdn.microsoft.com/library/windows/apps/Dn633866) property to find out about changes to the **Text size** setting on the phone.</span></span> <span data-ttu-id="b957d-197">その方法を次に紹介します。</span><span class="sxs-lookup"><span data-stu-id="b957d-197">Here’s how:</span></span>

<span data-ttu-id="b957d-198">C#</span><span class="sxs-lookup"><span data-stu-id="b957d-198">C#</span></span>
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

<span data-ttu-id="b957d-199">**TextScaleFactor** の値は、範囲 \[1,2\] の倍精度浮動小数点数です。</span><span class="sxs-lookup"><span data-stu-id="b957d-199">The value of **TextScaleFactor** is a double in the range \[1,2\].</span></span> <span data-ttu-id="b957d-200">最も小さい文字がこの大きさまで拡大されます。</span><span class="sxs-lookup"><span data-stu-id="b957d-200">The smallest text is scaled up by this amount.</span></span> <span data-ttu-id="b957d-201">たとえば、この値を使ってテキストに合わせてグラフィックスを拡大縮小できます。</span><span class="sxs-lookup"><span data-stu-id="b957d-201">You might be able to use the value to, say, scale graphics to match the text.</span></span> <span data-ttu-id="b957d-202">ただし、すべてのテキストが同じ倍率で拡大縮小されるわけではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b957d-202">But remember that not all text is scaled by the same factor.</span></span> <span data-ttu-id="b957d-203">一般に、最初の状態のテキストのサイズが大きいほど、拡大縮小の影響は小さくなります。</span><span class="sxs-lookup"><span data-stu-id="b957d-203">Generally speaking, the larger text is to begin with, the less it’s affected by scaling.</span></span>

<span data-ttu-id="b957d-204">次の型に **IsTextScaleFactorEnabled** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="b957d-204">These types have an **IsTextScaleFactorEnabled** property:</span></span>  
* [**<span data-ttu-id="b957d-205">ContentPresenter</span><span class="sxs-lookup"><span data-stu-id="b957d-205">ContentPresenter</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR209378)
* <span data-ttu-id="b957d-206">[**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) クラスと派生クラス</span><span class="sxs-lookup"><span data-stu-id="b957d-206">[**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) and derived classes</span></span>
* [**<span data-ttu-id="b957d-207">FontIcon</span><span class="sxs-lookup"><span data-stu-id="b957d-207">FontIcon</span></span>**](https://msdn.microsoft.com/library/windows/apps/Dn279514)
* [**<span data-ttu-id="b957d-208">RichTextBlock</span><span class="sxs-lookup"><span data-stu-id="b957d-208">RichTextBlock</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR227565)
* [**<span data-ttu-id="b957d-209">TextBlock</span><span class="sxs-lookup"><span data-stu-id="b957d-209">TextBlock</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR209652)
* <span data-ttu-id="b957d-210">[**TextElement**](https://msdn.microsoft.com/library/windows/apps/BR209967) クラスと派生クラス</span><span class="sxs-lookup"><span data-stu-id="b957d-210">[**TextElement**](https://msdn.microsoft.com/library/windows/apps/BR209967) and derived classes</span></span>

<span id="related_topics"/>

## <a name="related-topics"></a><span data-ttu-id="b957d-211">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b957d-211">Related topics</span></span>  
* [<span data-ttu-id="b957d-212">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="b957d-212">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="b957d-213">基本的なアクセシビリティ情報</span><span class="sxs-lookup"><span data-stu-id="b957d-213">Basic accessibility information</span></span>](basic-accessibility-information.md)
* [<span data-ttu-id="b957d-214">XAML テキスト表示のサンプル</span><span class="sxs-lookup"><span data-stu-id="b957d-214">XAML text display sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=238579)
* [<span data-ttu-id="b957d-215">XAML テキスト編集のサンプルに関するページ</span><span class="sxs-lookup"><span data-stu-id="b957d-215">XAML text editing sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=251417)
* [<span data-ttu-id="b957d-216">XAML アクセシビリティ サンプル</span><span class="sxs-lookup"><span data-stu-id="b957d-216">XAML accessibility sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=238570) 