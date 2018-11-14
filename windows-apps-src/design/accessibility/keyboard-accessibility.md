---
author: Xansky
Description: If your app does not provide good keyboard access, users who are blind or have mobility issues can have difficulty using your app or may not be able to use it at all.
ms.assetid: DDAE8C4B-7907-49FE-9645-F105F8DFAD8B
title: キーボードのアクセシビリティ
label: Keyboard accessibility
template: detail.hbs
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 41c5e018ee56b6a0d26bf2159f62801aa4ab5c3c
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6264199"
---
# <a name="keyboard-accessibility"></a><span data-ttu-id="fcdea-103">キーボードのアクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="fcdea-103">Keyboard accessibility</span></span>  



<span data-ttu-id="fcdea-104">アプリに十分なキーボード操作機能が備わっていない場合、視覚障碍や運動障碍のあるユーザーはアプリをうまく使うことができなかったり、まったく使うことができない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-104">If your app does not provide good keyboard access, users who are blind or have mobility issues can have difficulty using your app or may not be able to use it at all.</span></span>

<span id="keyboard_navigation_among_UI_elements"/>
<span id="keyboard_navigation_among_ui_elements"/>
<span id="KEYBOARD_NAVIGATION_AMONG_UI_ELEMENTS"/>

## <a name="keyboard-navigation-among-ui-elements"></a><span data-ttu-id="fcdea-105">UI 要素間でのキーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="fcdea-105">Keyboard navigation among UI elements</span></span>  
<span data-ttu-id="fcdea-106">キーボードでコントロールを操作するにはフォーカスが必要です。ポインターを使わずにフォーカスを移すには、UI 設計でタブ ナビゲーションを使ってコントロールにアクセスできるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-106">To use the keyboard with a control, the control must have focus, and to receive focus (without using a pointer) the control must be accessible in a UI design via tab navigation.</span></span> <span data-ttu-id="fcdea-107">既定では、コントロールのタブ オーダーは、デザイン サーフェイスに追加された順序、XAML で一覧表示された順序、またはプログラムを使ってコンテナーに追加された順序と同じになります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-107">By default, the tab order of controls is the same as the order in which they are added to a design surface, listed in XAML, or programmatically added to a container.</span></span>

<span data-ttu-id="fcdea-108">ほとんどの場合、XML でのコントロールの定義に基づく既定の順序が最適な順序です。これは特に、スクリーン リーダーで読み取られるコントロールの順序と一致するためです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-108">In most cases, the default order based on how you defined controls in XAML is the best order, especially because that is the order in which the controls are read by screen readers.</span></span> <span data-ttu-id="fcdea-109">ただし、既定の順序は表示順序と対応するとは限りません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-109">However, the default order does not necessarily correspond to the visual order.</span></span> <span data-ttu-id="fcdea-110">実際の表示位置は親レイアウト コンテナーと特定のプロパティに依存し、それらを子要素で設定することでレイアウトに影響することがあります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-110">The actual display position might depend on the parent layout container and certain properties that you can set on the child elements to influence the layout.</span></span> <span data-ttu-id="fcdea-111">アプリのタブ オーダーが適切に設定されていることを確かめるには、この動作を自身でテストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-111">To be sure your app has a good tab order, test this behavior yourself.</span></span> <span data-ttu-id="fcdea-112">特に、グリッド形式や表形式で表されるレイアウトを使っている場合は、ユーザーが読み進める順序とタブ オーダーが一致しない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-112">Especially if you have a grid metaphor or table metaphor for your layout, the order in which users might read versus the tab order could end up different.</span></span> <span data-ttu-id="fcdea-113">それ自体は必ずしも問題になるとは限りませんが、</span><span class="sxs-lookup"><span data-stu-id="fcdea-113">That's not always a problem in and of itself.</span></span> <span data-ttu-id="fcdea-114">必ずタッチ可能な UI とキーボードからアクセス可能な UI の両方についてアプリの機能をテストして、どちらの方法でも UI が適切に動作することを確認してください。</span><span class="sxs-lookup"><span data-stu-id="fcdea-114">But just make sure to test your app's functionality both as a touchable UI and as a keyboard-accessible UI and verify that your UI makes sense either way.</span></span>

<span data-ttu-id="fcdea-115">タブ オーダーと表示順序は、XAML を調整することで一致させることができます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-115">You can make the tab order match the visual order by adjusting the XAML.</span></span> <span data-ttu-id="fcdea-116">また、既定のタブ オーダーは、[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) プロパティを設定して上書きできます。たとえば、次の [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) レイアウトでは、タブ ナビゲーションで列が最初に選ばれるようにしています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-116">Or you can override the default tab order by setting the [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) property, as shown in the following example of a [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) layout that uses column-first tab navigation.</span></span>

<span data-ttu-id="fcdea-117">XAML</span><span class="sxs-lookup"><span data-stu-id="fcdea-117">XAML</span></span>
```xml
<!--Custom tab order.-->
<Grid>
  <Grid.RowDefinitions>...</Grid.RowDefinitions>
  <Grid.ColumnDefinitions>...</Grid.ColumnDefinitions>

  <TextBlock Grid.Column="1" HorizontalAlignment="Center">Groom</TextBlock>
  <TextBlock Grid.Column="2" HorizontalAlignment="Center">Bride</TextBlock>

  <TextBlock Grid.Row="1">First name</TextBlock>
  <TextBox x:Name="GroomFirstName" Grid.Row="1" Grid.Column="1" TabIndex="1"/>
  <TextBox x:Name="BrideFirstName" Grid.Row="1" Grid.Column="2" TabIndex="3"/>

  <TextBlock Grid.Row="2">Last name</TextBlock>
  <TextBox x:Name="GroomLastName" Grid.Row="2" Grid.Column="1" TabIndex="2"/>
  <TextBox x:Name="BrideLastName" Grid.Row="2" Grid.Column="2" TabIndex="4"/>
</Grid>
```

<span data-ttu-id="fcdea-118">特定のコントロールをタブ オーダーから除外することができます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-118">You may want to exclude a control from the tab order.</span></span> <span data-ttu-id="fcdea-119">基本的に、コントロールを非対話型にするだけで除外することができます ([**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/BR209419) プロパティを **false** に設定するなど)。</span><span class="sxs-lookup"><span data-stu-id="fcdea-119">You typically do this only by making the control noninteractive, for example by setting its [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/BR209419) property to **false**.</span></span> <span data-ttu-id="fcdea-120">無効になったコントロールは自動的にタブ オーダーから除外されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-120">A disabled control is automatically excluded from the tab order.</span></span> <span data-ttu-id="fcdea-121">ただし、コントロールが無効になっていなくても、タブ オーダーからコントロールを除外したい場合があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-121">But occasionally you might want to exclude a control from the tab order even if it is not disabled.</span></span> <span data-ttu-id="fcdea-122">この場合は、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/BR209422) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-122">In this case, you can set the [**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/BR209422) property to **false**.</span></span>

<span data-ttu-id="fcdea-123">通常、フォーカスを設定できる要素はすべて、既定でタブ オーダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-123">Any elements that can have focus are usually in the tab order by default.</span></span> <span data-ttu-id="fcdea-124">例外は、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) などの一部のテキスト表示型です。このような型では、選択中のテキストにクリップボードからアクセスできるように、フォーカスを設定することができます。ただし、静的テキスト要素がタブ オーダーの対象となることは想定されていないため、タブ オーダーには含められません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-124">The exception to this is that certain text-display types such as [**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) can have focus so that they can be accessed by the clipboard for text selection; however, they're not in the tab order because it is not expected for static text elements to be in the tab order.</span></span> <span data-ttu-id="fcdea-125">通常、これらの要素は対話型ではありません (これらは呼び出すことができず、テキスト入力も必要としませんが、テキスト内の選択ポイントを見つけて調整できる[テキスト コントロール パターン](https://msdn.microsoft.com/library/windows/desktop/Ee671194)はサポートしています)。</span><span class="sxs-lookup"><span data-stu-id="fcdea-125">They're not conventionally interactive (they can't be invoked, and don't require text input, but do support the [Text control pattern](https://msdn.microsoft.com/library/windows/desktop/Ee671194) that supports finding and adjusting selection points in text).</span></span> <span data-ttu-id="fcdea-126">テキストに、フォーカスを設定すると操作が可能になるという含みを持たせないでください。</span><span class="sxs-lookup"><span data-stu-id="fcdea-126">Text should not have the connotation that setting focus to it will enable some action that's possible.</span></span> <span data-ttu-id="fcdea-127">それでも、テキスト要素は、支援技術によって検出され、スクリーン リーダーによって読み上げられますが、これはその要素を実際のタブ オーダーで見つけるのとは異なる技法に依存しています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-127">Text elements will still be detected by assistive technologies, and read aloud in screen readers, but that relies on techniques other than finding those elements in the practical tab order.</span></span>

<span data-ttu-id="fcdea-128">[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) 値を調整する場合も、既定の順序を使う場合も、次のルールが適用されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-128">Whether you adjust [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) values or use the default order, these rules apply:</span></span>

* <span data-ttu-id="fcdea-129">[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) が 0 の UI 要素は、XAML または子コレクションでの宣言順序に基づいてタブ オーダーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-129">UI elements with [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) equal to 0 are added to the tab order based on declaration order in XAML or child collections.</span></span>
* <span data-ttu-id="fcdea-130">[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) が 0 を超える UI 要素は、**TabIndex** 値に基づいてタブ オーダーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-130">UI elements with [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) greater than 0 are added to the tab order based on the **TabIndex** value.</span></span>
* <span data-ttu-id="fcdea-131">[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) が 0 未満の UI 要素はタブ オーダーに追加され、値 0 の UI 要素よりも前に表示されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-131">UI elements with [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) less than 0 are added to the tab order and appear before any zero value.</span></span> <span data-ttu-id="fcdea-132">これは、HTML による **tabindex** 属性の処理とは異なる場合があります (古い HTML 仕様では、負の値の **tabindex** がサポートされていませんでした)。</span><span class="sxs-lookup"><span data-stu-id="fcdea-132">This potentially differs from HTML's handling of its **tabindex** attribute (and negative **tabindex** was not supported in older HTML specifications).</span></span>

<span id="keyboard_navigation_within_a_UI_element"/>
<span id="keyboard_navigation_within_a_ui_element"/>
<span id="KEYBOARD_NAVIGATION_WITHIN_A_UI_ELEMENT"/>

## <a name="keyboard-navigation-within-a-ui-element"></a><span data-ttu-id="fcdea-133">UI 要素内でのキーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="fcdea-133">Keyboard navigation within a UI element</span></span>  
<span data-ttu-id="fcdea-134">コンポジット要素の場合は、含まれている要素間で正しい内部ナビゲーションが実行できることが重要です。</span><span class="sxs-lookup"><span data-stu-id="fcdea-134">For composite elements, it is important to ensure proper inner navigation among the contained elements.</span></span> <span data-ttu-id="fcdea-135">コンポジット要素では、その現在のアクティブな子を管理して、すべての子要素にフォーカスを設定できるようにする場合のオーバーヘッドを減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-135">A composite element can manage its current active child to reduce the overhead of having all child elements able to have focus.</span></span> <span data-ttu-id="fcdea-136">このようなコンポジット要素もタブ オーダーに含まれ、キーボード ナビゲーション イベント自体を処理します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-136">Such a composite element is included in the tab order, and it handles keyboard navigation events itself.</span></span> <span data-ttu-id="fcdea-137">複合コントロールには、多くの場合、コントロールのイベント処理の中に既に内部ナビゲーション ロジックが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-137">Many of the composite controls already have some inner navigation logic built into the into control's event handling.</span></span> <span data-ttu-id="fcdea-138">たとえば、項目の方向キー トラバーサルは、既定では [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) コントロール、[**GridView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview) コントロール、[**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロール、[**FlipView**](https://msdn.microsoft.com/library/windows/apps/BR242678) コントロールで有効になります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-138">For example, arrow-key traversal of items is enabled by default on the [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878), [**GridView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview), [**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) and [**FlipView**](https://msdn.microsoft.com/library/windows/apps/BR242678) controls.</span></span>

<span id="keyboard_activation"/>
<span id="KEYBOARD_ACTIVATION"/>

## <a name="keyboard-alternatives-to-pointer-actions-and-events-for-specific-control-elements"></a><span data-ttu-id="fcdea-139">特定のコントロール要素に対するポインター操作やイベントの代わりにキーボードを利用</span><span class="sxs-lookup"><span data-stu-id="fcdea-139">Keyboard alternatives to pointer actions and events for specific control elements</span></span>  
<span data-ttu-id="fcdea-140">クリックできる UI 要素をキーボードでも呼び出すことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="fcdea-140">Ensure that UI elements that can be clicked can also be invoked by using the keyboard.</span></span> <span data-ttu-id="fcdea-141">キーボードで UI 要素を操作するには、要素にフォーカスが必要になります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-141">To use the keyboard with a UI element, the element must have focus.</span></span> <span data-ttu-id="fcdea-142">フォーカスとタブ ナビゲーションをサポートするのは、[**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) から派生するクラスだけです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-142">Only classes that derive from [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) support focus and tab navigation.</span></span>

<span data-ttu-id="fcdea-143">呼び出すことができる UI 要素の場合は、Space キーと Enter キーのキーボード イベント ハンドラーを実装します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-143">For UI elements that can be invoked, implement keyboard event handlers for the Spacebar and Enter keys.</span></span> <span data-ttu-id="fcdea-144">これで、基本のキーボード アクセシビリティのサポートは完全になり、ユーザーはキーボードのみを使って基本のアプリ シナリオを実行できます。つまり、ユーザーはすべての対話型の UI 要素にアクセスしたり、既定の機能をアクティブにすることができます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-144">This makes the basic keyboard accessibility support complete and enables users to accomplish basic app scenarios by using only the keyboard; that is, users can reach all interactive UI elements and activate the default functionality.</span></span>

<span data-ttu-id="fcdea-145">UI で使う要素がフォーカスを取得できない場合は、独自のカスタム コントロールを作成できます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-145">In cases where an element that you want to use in the UI cannot have focus, you could create your own custom control.</span></span> <span data-ttu-id="fcdea-146">[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/BR209422) プロパティを **true** に設定して入力フォーカスを有効にし、UI にフォーカス インジケーターが示される表示状態を作成して、フォーカスがある状態を視覚的に示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-146">You must set the [**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/BR209422) property to **true** to enable focus and you must provide a visual indication of the focused state by creating a visual state that decorates the UI with a focus indicator.</span></span> <span data-ttu-id="fcdea-147">タブ ストップ、フォーカス、Microsoft UI オートメーションのピアとパターンのサポートを、コンテンツを合成するコントロールで処理するよう、コントロールの合成を使うと簡単になることがよくあります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-147">However, it is often easier to use control composition so that the support for tab stops, focus, and Microsoft UI Automation peers and patterns are handled by the control within which you choose to compose your content.</span></span>

<span data-ttu-id="fcdea-148">たとえば、ポインター入力イベントを [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) で処理するのではなく、その要素を [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) でラップすると、ポインター、キーボード、フォーカスのサポートを取得できます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-148">For example, instead of handling a pointer-pressed event on an [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752), you could wrap that element in a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) to get pointer, keyboard, and focus support.</span></span>

<span data-ttu-id="fcdea-149">XAML</span><span class="sxs-lookup"><span data-stu-id="fcdea-149">XAML</span></span>
```xml
<!--Don't do this.-->
<Image Source="sample.jpg" PointerPressed="Image_PointerPressed"/>

<!--Do this instead.-->
<Button Click="Button_Click"><Image Source="sample.jpg"/></Button>
```

<span id="keyboard_shortcuts"/>
<span id="KEYBOARD_SHORTCUTS"/>

## <a name="keyboard-shortcuts"></a><span data-ttu-id="fcdea-150">キーボード ショートカット</span><span class="sxs-lookup"><span data-stu-id="fcdea-150">Keyboard shortcuts</span></span>  
<span data-ttu-id="fcdea-151">キーボードのナビゲーションのアクティブ化をアプリに実装するだけでなく、ショートカットをアプリの機能に実装することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fcdea-151">In addition to implementing keyboard navigation and activation for your app, it is a good practice to implement shortcuts for your app's functionality.</span></span> <span data-ttu-id="fcdea-152">基本的なキーボードのサポートとしてはタブ ナビゲーションで十分ですが、複雑なフォームではショートカット キーのサポートも追加すると効果的です。</span><span class="sxs-lookup"><span data-stu-id="fcdea-152">Tab navigation provides a good, basic level of keyboard support, but with complex forms you may want to add support for shortcut keys as well.</span></span> <span data-ttu-id="fcdea-153">これにより、キーボードとポインティング デバイスの両方を使うユーザーにも使いやすいアプリになります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-153">This can make your application more efficient to use, even for people who use both a keyboard and pointing devices.</span></span>

<span data-ttu-id="fcdea-154">*ショートカット*は、ユーザーが効率的にアプリの機能にアクセスできるようにして、生産性を向上させるためのキーの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-154">A *shortcut* is a keyboard combination that enhances productivity by providing an efficient way for the user to access app functionality.</span></span> <span data-ttu-id="fcdea-155">ショートカットには次の 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-155">There are two kinds of shortcut:</span></span>

* <span data-ttu-id="fcdea-156">*アクセス キー*は、アプリ内の個別の UI 要素へのショートカットです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-156">An *access key* is a shortcut to a piece of UI in your app.</span></span> <span data-ttu-id="fcdea-157">アクセス キーは、Alt キーと文字キーの組み合わせで構成されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-157">Access keys consist of the Alt key plus a letter key.</span></span>
* <span data-ttu-id="fcdea-158">*ショートカット キー*は、アプリ コマンドへのショートカットです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-158">An *accelerator key* is a shortcut to an app command.</span></span> <span data-ttu-id="fcdea-159">アプリにはコマンドに正確に対応する UI がある場合とない場合があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-159">Your app may or may not have UI that corresponds exactly to the command.</span></span> <span data-ttu-id="fcdea-160">ショートカット キーは、Ctrl キーと文字キーの組み合わせで構成されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-160">Accelerator keys consist of the Ctrl key plus a letter key.</span></span>

<span data-ttu-id="fcdea-161">スクリーン リーダーやその他の支援技術を使うユーザーがアプリのショートカット キーを簡単に見つけることができることが重要です。</span><span class="sxs-lookup"><span data-stu-id="fcdea-161">It is imperative that you provide an easy way for users who rely on screen readers and other assistive technology to discover your app's shortcut keys.</span></span> <span data-ttu-id="fcdea-162">ヒント、アクセシビリティ対応の名前、アクセシビリティ対応の説明、またはその他の画面上の伝達形式を使ってショートカットが確認できるようにします。</span><span class="sxs-lookup"><span data-stu-id="fcdea-162">Communicate shortcut keys by using tooltips, accessible names, accessible descriptions, or some other form of on-screen communication.</span></span> <span data-ttu-id="fcdea-163">少なくとも、アプリのヘルプ コンテンツにはショートカット キーについて十分な説明を用意しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-163">At a minimum, shortcut keys should be well documented in your app's Help content.</span></span>

<span data-ttu-id="fcdea-164">スクリーン リーダーでアクセス キーを文書化するには、[**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/Hh759763) 添付プロパティでショートカット キーを示す文字列を設定します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-164">You can document access keys through screen readers by setting the [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/Hh759763) attached property to a string that describes the shortcut key.</span></span> <span data-ttu-id="fcdea-165">また、[**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/Hh759762) 添付プロパティでニーモニック以外のショートカット キーを文書化することもできます。ただし、スクリーン リーダーでは通常、どちらのプロパティも同じ方法で扱われます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-165">There is also an [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/Hh759762) attached property for documenting non-mnemonic shortcut keys, although screen readers generally treat both properties the same way.</span></span> <span data-ttu-id="fcdea-166">ショートカット キーの文書化は、ヒント、オートメーションのプロパティ、ヘルプ ドキュメントなど、複数の方法で行います。</span><span class="sxs-lookup"><span data-stu-id="fcdea-166">Try to document shortcut keys in multiple ways, using tooltips, automation properties, and written Help documentation.</span></span>

<span data-ttu-id="fcdea-167">次の例では、メディアを再生、一時停止、停止するボタンのショートカット キーを文書化する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-167">The following example demonstrates how to document shortcut keys for media play, pause, and stop buttons.</span></span>

<span data-ttu-id="fcdea-168">XAML</span><span class="sxs-lookup"><span data-stu-id="fcdea-168">XAML</span></span>
```xml
<Grid KeyDown="Grid_KeyDown">

  <Grid.RowDefinitions>
    <RowDefinition Height="Auto" />
    <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>

  <MediaElement x:Name="DemoMovie" Source="xbox.wmv"
    Width="500" Height="500" Margin="20" HorizontalAlignment="Center" />

  <StackPanel Grid.Row="1" Margin="10"
    Orientation="Horizontal" HorizontalAlignment="Center">

    <Button x:Name="PlayButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+P"
      AutomationProperties.AcceleratorKey="Control P">
      <TextBlock>Play</TextBlock>
    </Button>

    <Button x:Name="PauseButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+A"
      AutomationProperties.AcceleratorKey="Control A">
      <TextBlock>Pause</TextBlock>
    </Button>

    <Button x:Name="StopButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+S"
      AutomationProperties.AcceleratorKey="Control S">
      <TextBlock>Stop</TextBlock>
    </Button>
  </StackPanel>
</Grid>
```

> [!IMPORTANT]
> <span data-ttu-id="fcdea-169">[**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/Hh759762) または [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/Hh759763) を設定しても、キーボード機能は有効になりません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-169">Setting [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/Hh759762) or [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/Hh759763) doesn't enable keyboard functionality.</span></span> <span data-ttu-id="fcdea-170">使用する必要があるキーなどの情報を支援技術によってユーザーに渡すことができるように、そのような情報が UI オートメーション フレームワークに通知されるだけです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-170">It only reports to the UI Automation framework what keys should be used, so that such information can be passed on to users via assistive technologies.</span></span> <span data-ttu-id="fcdea-171">キー処理の実装は、XAML ではなくコードで行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-171">The implementation for key handling still needs to be done in code, not XAML.</span></span> <span data-ttu-id="fcdea-172">アプリに対して実際にキーボード ショートカットの動作を実装するには、関連するコントロールに [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/BR208941) イベントや [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/BR208942) イベントのハンドラーをアタッチする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-172">You will still need to attach handlers for [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/BR208941) or [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/BR208942) events on the relevant control in order to actually implement the keyboard shortcut behavior in your app.</span></span> <span data-ttu-id="fcdea-173">また、アクセス キーの下線も自動的には追加されません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-173">Also, the underline text decoration for an access key is not provided automatically.</span></span> <span data-ttu-id="fcdea-174">UI で下線付きのテキストを表示する場合は、インラインの [**Underline**](https://msdn.microsoft.com/library/windows/apps/BR209982) 書式設定として、ニーモニックの特定のキーのテキストに明示的に下線を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-174">You must explicitly underline the text for the specific key in your mnemonic as inline [**Underline**](https://msdn.microsoft.com/library/windows/apps/BR209982) formatting if you wish to show underlined text in the UI.</span></span>

<span data-ttu-id="fcdea-175">わかりやすくするために、上の例では "Ctrl + A" などの文字列に対するリソースは使っていません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-175">For simplicity, the preceding example omits the use of resources for strings such as "Ctrl+A".</span></span> <span data-ttu-id="fcdea-176">ただし、ローカライズ時にはショートカット キーについても考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-176">However, you must also consider shortcut keys during localization.</span></span> <span data-ttu-id="fcdea-177">ショートカット キーとして使うキーは通常、要素の表示テキスト ラベルに基づいて選ぶため、ショートカット キーをローカライズすることは適切な作業です。</span><span class="sxs-lookup"><span data-stu-id="fcdea-177">Localizing shortcut keys is relevant because the choice of key to use as the shortcut key typically depends on the visible text label for the element.</span></span>

<span data-ttu-id="fcdea-178">ショートカット キーの実装について詳しくは、Windows ユーザー エクスペリエンス インタラクション ガイドラインの[ショートカット キー](http://go.microsoft.com/fwlink/p/?linkid=221825)に関する説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcdea-178">For more guidance about implementing shortcut keys, see [Shortcut keys](http://go.microsoft.com/fwlink/p/?linkid=221825) in the Windows User Experience Interaction Guidelines.</span></span>

<span id="Implementing_a_key_event_handler"/>
<span id="implementing_a_key_event_handler"/>
<span id="IMPLEMENTING_A_KEY_EVENT_HANDLER"/>

### <a name="implementing-a-key-event-handler"></a><span data-ttu-id="fcdea-179">キー イベント ハンドラーの実装</span><span class="sxs-lookup"><span data-stu-id="fcdea-179">Implementing a key event handler</span></span>  
<span data-ttu-id="fcdea-180">キー イベントなどの入力イベントでは、*ルーティング イベント*というイベント概念を使います。</span><span class="sxs-lookup"><span data-stu-id="fcdea-180">Input events such as the key events use an event concept called *routed events*.</span></span> <span data-ttu-id="fcdea-181">ルーティング イベントは、共通コントロールの親が複数の子要素に対するイベントを処理できるような、合成コントロールの子要素をバブルアップすることがあります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-181">A routed event can bubble up through the child elements of a composited control, such that a common control parent can handle events for multiple child elements.</span></span> <span data-ttu-id="fcdea-182">このイベント モデルは、仕様によりフォーカスの設定やタブ オーダーへの追加ができない複数の複合パートが含まれるコントロールに、ショートカット キーの操作を定義するときに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-182">This event model is convenient for defining shortcut key actions for a control that contains several composite parts that by design cannot have focus or be part of the tab order.</span></span>

<span data-ttu-id="fcdea-183">Ctrl キーなどの修飾キーのチェックを含むキー イベント ハンドラーの記述方法を示すコード例については、「[キーボード操作](https://msdn.microsoft.com/library/windows/apps/Mt185607)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fcdea-183">For example code that shows how to write a key event handler that includes checking for modifiers such as the Ctrl key, see [Keyboard interactions](https://msdn.microsoft.com/library/windows/apps/Mt185607).</span></span>

<span id="Keyboard_navigation_for_custom_controls"/>
<span id="keyboard_navigation_for_custom_controls"/>
<span id="KEYBOARD_NAVIGATION_FOR_CUSTOM_CONTROLS"/>

## <a name="keyboard-navigation-for-custom-controls"></a><span data-ttu-id="fcdea-184">カスタム コントロールのキーボード ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="fcdea-184">Keyboard navigation for custom controls</span></span>  
<span data-ttu-id="fcdea-185">子要素間に空間的な関係が存在する場合は、子要素間を移動するためのキーボード ショートカットとして方向キーを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fcdea-185">We recommend the use of arrow keys as keyboard shortcuts for navigating among child elements, in cases where the child elements have a spacial relationship to each other.</span></span> <span data-ttu-id="fcdea-186">ツリー ビュー ノードに、展開折りたたみとノードのアクティブ化を処理するための別のサブ要素がある場合は、左右の方向キーを使って、キーボードの展開折りたたみ機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-186">If tree-view nodes have separate sub-elements for handling expand-collapse and node activation, use the left and right arrow keys to provide keyboard expand-collapse functionality.</span></span> <span data-ttu-id="fcdea-187">コントロール コンテンツ内で方向トラバーサルをサポートする指向コントロールがある場合は、適切な方向キーを使ってください。</span><span class="sxs-lookup"><span data-stu-id="fcdea-187">If you have an oriented control that supports directional traversal within the control content, use the appropriate arrow keys.</span></span>

<span data-ttu-id="fcdea-188">一般に、カスタム コントロールに対するカスタム キー処理を実装する場合は、クラス ロジックの一部として、[**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982.aspx) メソッドと [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983.aspx) メソッドのオーバーライドを組み込みます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-188">Generally you implement custom key handling for custom controls by including an override of [**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982.aspx) and [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983.aspx) methods as part of the class logic.</span></span>

<span id="An_example_of_a_visual_state_for_a_focus_indicator"/>
<span id="an_example_of_a_visual_state_for_a_focus_indicator"/>
<span id="AN_EXAMPLE_OF_A_VISUAL_STATE_FOR_A_FOCUS_INDICATOR"/>

## <a name="an-example-of-a-visual-state-for-a-focus-indicator"></a><span data-ttu-id="fcdea-189">フォーカス インジケーターの表示状態の例</span><span class="sxs-lookup"><span data-stu-id="fcdea-189">An example of a visual state for a focus indicator</span></span>  
<span data-ttu-id="fcdea-190">これまで説明したように、ユーザーがフォーカスを合わせることができるカスタム コントロールには視覚的なフォーカス インジケーターが必要です。</span><span class="sxs-lookup"><span data-stu-id="fcdea-190">We mentioned earlier that any custom control that enables the user to focus it should have a visual focus indicator.</span></span> <span data-ttu-id="fcdea-191">一般に、フォーカス インジケーターは、コントロールを囲む通常の四角形の境界線のすぐ外側に、四角形を描画するだけの簡単なものです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-191">Usually that focus indicator is as simple as drawing a rectangle shape immediately around the control's normal bounding rectangle.</span></span> <span data-ttu-id="fcdea-192">視覚的なフォーカスに使う [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は、コントロール テンプレートにおけるコントロールの合成の他の部分に対するピア要素ですが、最初はコントロールにフォーカスがないため、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) の値には **Collapsed** が設定されています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-192">The [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) for visual focus is a peer element to the rest of the control's composition in a control template, but is initially set with a [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) value of **Collapsed** because the control isn't focused yet.</span></span> <span data-ttu-id="fcdea-193">コントロールがフォーカスを取得すると、表示状態が呼び出され、フォーカス表示の **Visibility** が **Visible** に設定されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-193">Then, when the control does get focus, a visual state is invoked that specifically sets the **Visibility** of the focus visual to **Visible**.</span></span> <span data-ttu-id="fcdea-194">フォーカスが別の場所に移動すると、他の表示状態が呼び出され、**Visibility** が **Collapsed** になります。</span><span class="sxs-lookup"><span data-stu-id="fcdea-194">Once focus is moved elsewhere, another visual state is called, and the **Visibility** becomes **Collapsed**.</span></span>

<span data-ttu-id="fcdea-195">既定の XAML コントロールはいずれも、フォーカスを設定できるものであれば、フォーカスを受け取ったときに視覚的なフォーカス インジケーターを適切に表示します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-195">All of the default XAML controls will display an appropriate visual focus indicator when focused (if they can be focused).</span></span> <span data-ttu-id="fcdea-196">また、ユーザーが選んでいるテーマに応じて (ハイ コントラスト モードを使っている場合は特に)、外観が異なる可能性があります。UI で XAML コントロールを使っており、コントロール テンプレートを置き換えていない場合は、特に何もしなくても、視覚的なフォーカス インジケーターがコントロールに適切に表示され、動作します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-196">There are also potentially different looks depending on the user's selected theme (particularly if the user is using a high contrast mode.) If you're using the XAML controls in your UI and not replacing the control templates, you don't need to do anything extra to get visual focus indicators on controls that behave and display correctly.</span></span> <span data-ttu-id="fcdea-197">ただし、コントロールを再テンプレート化する必要がある場合、または XAML コントロールで視覚的なフォーカス インジケーターがどのように実現されているかを理解したい場合のために、このセクションの残りの部分では、XAML とコントロール ロジックにおけるフォーカス インジケーターの処理方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-197">But if you're intending to retemplate a control, or if you're curious about how XAML controls provide their visual focus indicators, the remainder of this section explains how this is done in XAML and in the control logic.</span></span>

<span data-ttu-id="fcdea-198">次に示す XAML の例は、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) の既定の XAML テンプレートに含まれています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-198">Here's some example XAML that comes from the default XAML template for a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265).</span></span>

<span data-ttu-id="fcdea-199">XAML</span><span class="sxs-lookup"><span data-stu-id="fcdea-199">XAML</span></span>
```xml
<ControlTemplate TargetType="Button">
...
    <Rectangle
      x:Name="FocusVisualWhite"
      IsHitTestVisible="False"
      Stroke="{ThemeResource FocusVisualWhiteStrokeThemeBrush}"
      StrokeEndLineCap="Square"
      StrokeDashArray="1,1"
      Opacity="0"
      StrokeDashOffset="1.5"/>
    <Rectangle
      x:Name="FocusVisualBlack"
      IsHitTestVisible="False"
      Stroke="{ThemeResource FocusVisualBlackStrokeThemeBrush}"
      StrokeEndLineCap="Square"
      StrokeDashArray="1,1"
      Opacity="0"
      StrokeDashOffset="0.5"/>
...
</ControlTemplate>
```

<span data-ttu-id="fcdea-200">ここまでのところでは、これは単なる合成です。</span><span class="sxs-lookup"><span data-stu-id="fcdea-200">So far this is just the composition.</span></span> <span data-ttu-id="fcdea-201">フォーカス インジケーターの表示を制御するには、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) プロパティを切り替える表示状態を定義します。</span><span class="sxs-lookup"><span data-stu-id="fcdea-201">To control the focus indicator's visibility, you define visual states that toggle the [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) property.</span></span> <span data-ttu-id="fcdea-202">それには、[**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/Hh738505) 添付プロパティを使います。これは合成を定義するルート要素に適用されます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-202">This is done using the [**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/Hh738505) attached property, as applied to the root element that defines the composition.</span></span>

<span data-ttu-id="fcdea-203">XAML</span><span class="sxs-lookup"><span data-stu-id="fcdea-203">XAML</span></span>
```xml
<ControlTemplate TargetType="Button">
  <Grid>
    <VisualStateManager.VisualStateGroups>
       <!--other visual state groups here-->
       <VisualStateGroup x:Name="FocusStates">
         <VisualState x:Name="Focused">
           <Storyboard>
             <DoubleAnimation
               Storyboard.TargetName="FocusVisualWhite"
               Storyboard.TargetProperty="Opacity"
               To="1" Duration="0"/>
             <DoubleAnimation
               Storyboard.TargetName="FocusVisualBlack"
               Storyboard.TargetProperty="Opacity"
               To="1" Duration="0"/>
         </VisualState>
         <VisualState x:Name="Unfocused" />
         <VisualState x:Name="PointerFocused" />
       </VisualStateGroup>
     <VisualStateManager.VisualStateGroups>
<!--composition is here-->
   </Grid>
</ControlTemplate>
```

<span data-ttu-id="fcdea-204">指定された状態のうち 1 つのみが [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) を直接調整し、他の状態が空のように見えることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="fcdea-204">Note how only one of the named states adjusts [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) directly whereas the others are seemingly empty.</span></span> <span data-ttu-id="fcdea-205">表示状態の動作は、同じ [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/BR209014) の別の状態がコントロールで使われるとすぐに、前の状態で適用されていたすべてのアニメーションが取り消されるというものです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-205">The way that visual states work is that as soon as the control uses another state from the same [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/BR209014), any animations applied by the previous state are immediately canceled.</span></span> <span data-ttu-id="fcdea-206">合成の既定の **Visibility** は **Collapsed** であるため、四角形は表示されません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-206">Because the default **Visibility** from composition is **Collapsed**, this means the rectangle will not appear.</span></span> <span data-ttu-id="fcdea-207">コントロールのロジックでは、[**GotFocus**](https://msdn.microsoft.com/library/windows/apps/BR208927) などのフォーカス イベントをリッスンし、[**GoToState**](https://msdn.microsoft.com/library/windows/apps/BR209025) を使って状態を変更することで、これを制御しています。</span><span class="sxs-lookup"><span data-stu-id="fcdea-207">The control logic controls this by listening for focus events like [**GotFocus**](https://msdn.microsoft.com/library/windows/apps/BR208927) and changing the states with [**GoToState**](https://msdn.microsoft.com/library/windows/apps/BR209025).</span></span> <span data-ttu-id="fcdea-208">既定のコントロールを使っているか、この動作が既に設定されているコントロールを基にカスタマイズしている場合、これは既に自動的に処理されていることがほとんどです。</span><span class="sxs-lookup"><span data-stu-id="fcdea-208">Often this is already handled for you if you are using a default control or customizing based on a control that already has that behavior.</span></span>

<span id="Keyboard_accessibility_and_Windows_Phone"/>
<span id="keyboard_accessibility_and_windows_phone"/>
<span id="KEYBOARD_ACCESSIBILITY_AND_WINDOWS_PHONE"/>

## <a name="keyboard-accessibility-and-windows-phone"></a><span data-ttu-id="fcdea-209">キーボードのアクセシビリティと Windows Phone</span><span class="sxs-lookup"><span data-stu-id="fcdea-209">Keyboard accessibility and Windows Phone</span></span>
<span data-ttu-id="fcdea-210">Windows Phone デバイスには、通常、専用のハードウェア キーボードがありません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-210">A Windows Phone device typically doesn't have a dedicated, hardware keyboard.</span></span> <span data-ttu-id="fcdea-211">ただし、ソフト入力パネル (SIP) は、複数のキーボード アクセシビリティのシナリオをサポートできます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-211">However, a Soft Input Panel (SIP) can support several keyboard accessibility scenarios.</span></span> <span data-ttu-id="fcdea-212">スクリーン リーダーは、削除も含めて、**テキスト** SIP からのテキスト入力を読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-212">Screen readers can read text input from the **Text** SIP, including announcing deletions.</span></span> <span data-ttu-id="fcdea-213">スクリーン リーダーは、ユーザーがキーをスキャンしていることを検出して、スキャンされたキー名を読み上げるため、ユーザーは指の位置を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-213">Users can discover where their fingers are because the screen reader can detect that the user is scanning keys, and it reads the scanned key name aloud.</span></span> <span data-ttu-id="fcdea-214">また、キーボード指向のアクセシビリティに関する概念の一部は、キーボードをまったく使わない関連の支援技術の動作に割り当てることもできます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-214">Also, some of the keyboard-oriented accessibility concepts can be mapped to related assistive technology behaviors that don't use a keyboard at all.</span></span> <span data-ttu-id="fcdea-215">たとえば、SIP が Tab キーを含まない場合でも、ナレーターは、Tab キーを押した場合と同等のタッチ ジェスチャをサポートします。そのため、UI のコントロールを使って便利なタブ オーダーを設定することが、重要なアクセシビリティの原則であることに変わりはありません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-215">For example, even though a SIP won't include a Tab key, Narrator supports a touch gesture that's the equivalent of pressing the Tab key, so having a useful tab order through the controls in a UI is still an important accessibility principle.</span></span> <span data-ttu-id="fcdea-216">複雑なコントロール内で部品を移動するために使われる方向キーも、ナレーターのタッチ ジェスチャでサポートされます。</span><span class="sxs-lookup"><span data-stu-id="fcdea-216">Arrow keys as used for navigating the parts within complex controls are also supported through Narrator touch gestures.</span></span> <span data-ttu-id="fcdea-217">テキスト入力用ではないコントロールにフォーカスが移ると、ナレーターはそのコントロールの操作を呼び出すジェスチャをサポートします。</span><span class="sxs-lookup"><span data-stu-id="fcdea-217">Once focus has reached a control that's not for text input, Narrator supports a gesture that invokes that control's action.</span></span>

<span data-ttu-id="fcdea-218">SIP には Ctrl キーや Alt キーがないため、キーボード ショートカットは通常、Windows Phone アプリには関係ありません。</span><span class="sxs-lookup"><span data-stu-id="fcdea-218">Keyboard shortcuts aren't typically relevant for Windows Phone apps, because a SIP won't include Control or Alt keys.</span></span>

<span id="related_topics"/>

## <a name="related-topics"></a><span data-ttu-id="fcdea-219">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fcdea-219">Related topics</span></span>  
* [<span data-ttu-id="fcdea-220">アクセシビリティ</span><span class="sxs-lookup"><span data-stu-id="fcdea-220">Accessibility</span></span>](accessibility.md)
* [<span data-ttu-id="fcdea-221">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="fcdea-221">Keyboard interactions</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt185607)
* [<span data-ttu-id="fcdea-222">タッチ キーボードのサンプル</span><span class="sxs-lookup"><span data-stu-id="fcdea-222">Touch keyboard sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)
* [<span data-ttu-id="fcdea-223">XAML アクセシビリティ サンプル</span><span class="sxs-lookup"><span data-stu-id="fcdea-223">XAML accessibility sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=238570)

