---
author: Karl-Bridge-Microsoft
Description: Learn how accelerator keys can improve the usability and accessibility of UWP apps.
title: キーボード アクセラレータ
label: Keyboard accelerators
template: detail.hbs
keywords: キーボード, アクセラレータ, アクセラレータ キー, キーボード ショートカット, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作, ゲームパッド, リモート
ms.author: kbridge
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
pm-contact: chigy
design-contact: miguelrb
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: ce84debc3422f923c7c88aae1fa216665ef1ef0f
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2830894"
---
# <a name="keyboard-accelerators"></a><span data-ttu-id="0bb05-103">キーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="0bb05-103">Keyboard accelerators</span></span>

![Surface キーボード](images/accelerators/accelerators_hero2.png)

<span data-ttu-id="0bb05-105">アクセラレータ キー (キーボード アクセラレータ) は、アプリの UI 間を移動せずに一般的な操作やコマンドを呼び出すための直感的な方法をユーザーに提供して、Windows アプリケーションの使いやすさとアクセシビリティを向上させるキーボード ショートカットです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-105">Accelerator keys (or keyboard accelerators) are keyboard shortcuts that improve the usability and accessibility of your Windows applications by providing an intuitive way for users to invoke common actions or commands without navigating the app UI.</span></span>

<span data-ttu-id="0bb05-106">キーボード ショートカットを使って Windows アプリケーションの UI に移動する方法について詳しくは、「[アクセス キー ](access-keys.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bb05-106">See the [Access keys](access-keys.md) topic for details on navigating the UI of a Windows application with keyboard shortcuts.</span></span>

> [!NOTE]
> <span data-ttu-id="0bb05-107">キーボードは、特定の障碍を持つユーザーにとっては不可欠であり ([キーボードのアクセシビリティ](https://docs.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)をご覧ください)、アプリをより効率的に操作することを望むユーザーにとって重要なツールでもあります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-107">A keyboard is indispensable for users with certain disabilities (see [Keyboard accessibility](https://docs.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)), and is also an important tool for users who prefer it as a more efficient way to interact with an app.</span></span>

## <a name="overview"></a><span data-ttu-id="0bb05-108">概要</span><span class="sxs-lookup"><span data-stu-id="0bb05-108">Overview</span></span>

<span data-ttu-id="0bb05-109">通常、アクセラレータには F1 から F12 までのファンクション キーや、標準キーと 1 つ以上の修飾キー (Ctrl、Shift など) の組み合わせが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-109">Accelerators typically include the function keys F1 through F12 or some combination of a standard key paired with one or more modifier keys (CTRL, Shift).</span></span>

> [!NOTE]
> <span data-ttu-id="0bb05-110">UWP プラットフォームのコントロールには、組み込みのキーボード アクセラレータが用意されています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-110">The UWP platform controls have built-in keyboard accelerators.</span></span> <span data-ttu-id="0bb05-111">たとえば、ListView では Ctrl + A (一覧のすべての項目を選択する) がサポートされ、RichEditBox では Ctrl + Tab (テキスト ボックスにタブを挿入する) がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-111">For example, ListView supports Ctrl+A for selecting all the items in the list, and RichEditBox supports Ctrl+Tab for inserting a Tab in the text box.</span></span> <span data-ttu-id="0bb05-112">これらの組み込みキーボード アクセラレータは、**コントロール アクセラレータ**と呼ばれ、要素またはその子にフォーカスがある場合にのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-112">These built-in keyboard accelerators are referred to as **control accelerators** and are executed only if the focus is on the element or one of its children.</span></span> <span data-ttu-id="0bb05-113">ここで説明するキーボード アクセラレータ API を使用して定義するアクセラレータは、**アプリ アクセラレータ**と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-113">Accelerators defined by you using the keyboard accelerator APIs discussed here are referred to as **app accelerators**.</span></span>

<span data-ttu-id="0bb05-114">キーボード アクセラレータは、すべてのアクションに用意されるのではなく、多くの場合はメニューで公開されているコマンドに関連付けられています (メニュー項目コンテンツにも示されています)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-114">Keyboard accelerators are not available for every action but are often associated with commands exposed in menus (and should be specified with the menu item content).</span></span> <span data-ttu-id="0bb05-115">アクセラレータは、対応するメニュー項目がない操作に関連付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-115">Accelerators can also be associated with actions that do not have equivalent menu items.</span></span> <span data-ttu-id="0bb05-116">ただし、ユーザーはアプリケーションのメニューを使用して、利用可能なコマンド セットを見つけ、その機能を理解するため、アクセラレータができるだけ簡単に検出されるようにする必要があります (ラベルの使用や、決まったパターンの使用が役立ちます)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-116">However, because users rely on an application's menus to discover and learn the available command set, you should try to make discovery of accelerators as easy as possible (using labels or established patterns can help with this).</span></span>

![メニュー項目ラベルに示されているキーボード アクセラレータ](images/accelerators/accelerators_menuitemlabel.png)  
*<span data-ttu-id="0bb05-118">メニュー項目ラベルに示されているキーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="0bb05-118">Keyboard accelerators described in a menu item label</span></span>*

## <a name="when-to-use-keyboard-accelerators"></a><span data-ttu-id="0bb05-119">キーボード アクセラレータの使用に適したケース</span><span class="sxs-lookup"><span data-stu-id="0bb05-119">When to use keyboard accelerators</span></span>

<span data-ttu-id="0bb05-120">UI に適切な場合は必ずキーボード アクセラレータを指定し、すべてのカスタム コントロールでアクセラレータをサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-120">We recommend that you specify keyboard accelerators wherever appropriate in your UI, and support accelerators in all custom controls.</span></span>

- <span data-ttu-id="0bb05-121">一度に押せるキーが 1 つに限定されるユーザーや、マウスを使うのが困難なユーザーなど、運動障碍を持つユーザーにとっては、キーボード アクセラレータによりアプリのアクセシビリティが高まります。**</span><span class="sxs-lookup"><span data-stu-id="0bb05-121">Keyboard accelerators make your app more accessible for users with motor disabilities, including those users who can press only one key at a time or have difficulty using a mouse.**</span></span>

  <span data-ttu-id="0bb05-122">適切に設計されたキーボード UI はソフトウェアのアクセシビリティの重要な要素であり、</span><span class="sxs-lookup"><span data-stu-id="0bb05-122">A well-designed keyboard UI is an important aspect of software accessibility.</span></span> <span data-ttu-id="0bb05-123">視覚に障碍のあるユーザーや特定の運動障碍のあるユーザーによるアプリ内の移動や、その機能の操作を実現します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-123">It enables users with vision impairments or who have certain motor disabilities to navigate an app and interact with its features.</span></span> <span data-ttu-id="0bb05-124">このようなユーザーはマウスを操作できない場合があるため、代わりにさまざまな支援技術 (キーボード強化ツール、スクリーン キーボード、スクリーン拡大機能、スクリーン リーダー、音声入力ユーティリティなど) が不可欠になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-124">Such users might not be able to operate a mouse and instead rely on various assistive technologies such as keyboard enhancement tools, on-screen keyboards, screen enlargers, screen readers, and voice input utilities.</span></span> <span data-ttu-id="0bb05-125">このようなユーザーにとっては、コマンドを包括的にカバーすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="0bb05-125">For these users, comprehensive command coverage is crucial.</span></span>

- <span data-ttu-id="0bb05-126">キーボードを使った操作を好むパワー ユーザーにとっては、キーボード アクセラレータによりアプリが使いやすくなります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-126">Keyboard accelerators make your app more usable for power users who prefer to interact through the keyboard.</span></span>

  <span data-ttu-id="0bb05-127">多くの経験豊富なユーザーには、キーボードの使用の方がはるかに好まれます。キーボード ベースのコマンドであれば、すばやく入力することができ、キーボードから手を離す必要がないためです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-127">Experienced users often have a strong preference for using the keyboard because keyboard-based commands can be entered more quickly and don't require them to remove their hands from the keyboard.</span></span> <span data-ttu-id="0bb05-128">このようなユーザーにとっては、効率性と一貫性が重要です。包括性が重要になるのは、特に頻繁に使用するコマンドに対してのみです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-128">For these users, efficiency and consistency are crucial; comprehensiveness is important only for the most frequently used commands.</span></span>

## <a name="specify-a-keyboard-accelerator"></a><span data-ttu-id="0bb05-129">キーボード アクセラレータを指定する</span><span class="sxs-lookup"><span data-stu-id="0bb05-129">Specify a keyboard accelerator</span></span>

<span data-ttu-id="0bb05-130">UWP アプリのキーボード アクセラレータを作成するには、[KeyboardAccelerator](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.keyboardaccelerator.-ctor) API を使用します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-130">Use the [KeyboardAccelerator](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.input.keyboardaccelerator.-ctor) APIs to create keyboard accelerators in UWP apps.</span></span> <span data-ttu-id="0bb05-131">これらの API を使用すると、複数の KeyDown イベントを処理してキーの組み合わせの押下を検出する必要がなくなり、アプリのリソース内でアクセラレータをローカライズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-131">With these APIs, you don't have to handle multiple KeyDown events to detect the key combination pressed, and you can localize accelerators in the app resources.</span></span>

<span data-ttu-id="0bb05-132">アプリ内で特に一般的な操作に対してキーボード アクセラレータを設定し、メニュー項目のラベルまたはツール ヒントを使用してわかりやすく示すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-132">We recommend that you set keyboard accelerators for the most common actions in your app and document them using the menu item label or tooltip.</span></span> <span data-ttu-id="0bb05-133">この例では、名前の変更コマンドとコピー コマンドに対してのみキーボード アクセラレータを宣言しています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-133">In this example, we declare keyboard accelerators only for the Rename and Copy commands.</span></span>

``` xaml
<CommandBar Margin="0,200" AccessKey="M">
  <AppBarButton 
    Icon="Share" 
    Label="Share" 
    Click="OnShare" 
    AccessKey="S" />
  <AppBarButton 
    Icon="Copy" 
    Label="Copy" 
    ToolTipService.ToolTip="Copy (Ctrl+C)" 
    Click="OnCopy" 
    AccessKey="C">
    <AppBarButton.KeyboardAccelerators>
      <KeyboardAccelerator 
        Modifiers="Control" 
        Key="C" />
    </AppBarButton.KeyboardAccelerators>
  </AppBarButton>

  <AppBarButton 
    Icon="Delete" 
    Label="Delete" 
    Click="OnDelete" 
    AccessKey="D" />
  <AppBarSeparator/>
  <AppBarButton 
    Icon="Rename" 
    Label="Rename" 
    ToolTipService.ToolTip="Rename (F2)" 
    Click="OnRename" 
    AccessKey="R">
    <AppBarButton.KeyboardAccelerators>
      <KeyboardAccelerator 
        Modifiers="None" Key="F2" />
    </AppBarButton.KeyboardAccelerators>
  </AppBarButton>

  <AppBarButton 
    Icon="SelectAll" 
    Label="Select" 
    Click="OnSelect" 
    AccessKey="A" />
  
  <CommandBar.SecondaryCommands>
    <AppBarButton 
      Icon="OpenWith" 
      Label="Sources" 
      AccessKey="S">
      <AppBarButton.Flyout>
        <MenuFlyout>
          <ToggleMenuFlyoutItem Text="OneDrive" />
          <ToggleMenuFlyoutItem Text="Contacts" />
          <ToggleMenuFlyoutItem Text="Photos"/>
          <ToggleMenuFlyoutItem Text="Videos"/>
        </MenuFlyout>
      </AppBarButton.Flyout>
    </AppBarButton>
    <AppBarToggleButton 
      Icon="Save" 
      Label="Auto Save" 
      IsChecked="True" 
      AccessKey="A"/>
  </CommandBar.SecondaryCommands>

</CommandBar>
```

![ツール ヒントに示されたアクセス キーの説明](images/accelerators/accelerators_tooltip.png)  
***<span data-ttu-id="0bb05-135">ツール ヒントに示されたアクセス キーの説明</span><span class="sxs-lookup"><span data-stu-id="0bb05-135">Keyboard accelerator described in a tooltip</span></span>***

<span data-ttu-id="0bb05-136">[UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) オブジェクトには、[KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) コレクションおよび [KeyboardAccelerators](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.KeyboardAccelerators) があり、カスタムの KeyboardAccelerator オブジェクトを指定して、キーボード アクセラレータのキー入力を定義できます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-136">The [UIElement](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement) object has a [KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) collection, [KeyboardAccelerators](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.KeyboardAccelerators), where you specify your custom KeyboardAccelerator objects and define the keystrokes for the keyboard accelerator:</span></span>

-   <span data-ttu-id="0bb05-137">**[Key](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Key)** - キーボード アクセラレータに使用される [VirtualKey](https://docs.microsoft.com/uwp/api/windows.system.virtualkey)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-137">**[Key](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Key)** - the [VirtualKey](https://docs.microsoft.com/uwp/api/windows.system.virtualkey) used for the keyboard accelerator.</span></span>

-   <span data-ttu-id="0bb05-138">**[Modifiers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Modifiers)** – キーボード アクセラレータに使用される [VirtualKeyModifiers](https://docs.microsoft.com/uwp/api/windows.system.virtualkeymodifiers)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-138">**[Modifiers](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Modifiers)** – the [VirtualKeyModifiers](https://docs.microsoft.com/uwp/api/windows.system.virtualkeymodifiers) used for the keyboard accelerator.</span></span> <span data-ttu-id="0bb05-139">Modifiers が設定されていない場合、既定値は None です。</span><span class="sxs-lookup"><span data-stu-id="0bb05-139">If Modifiers is not set, the default value is None.</span></span>

> [!NOTE]
> <span data-ttu-id="0bb05-140">単一キーのアクセラレータ (A、Del、F2、Space キー、Esc キー、マルチメディア キー) と複数キーのアクセラレータ (Ctrl + Shift + M) がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-140">Single key (A, Delete, F2, Spacebar, Esc, Multimedia Key) accelerators and multi-key accelerators (Ctrl+Shift+M) are supported.</span></span> <span data-ttu-id="0bb05-141">ただし、ゲームパッドの仮想キーはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0bb05-141">However, Gamepad virtual keys are not supported.</span></span>

## <a name="scoped-accelerators"></a><span data-ttu-id="0bb05-142">アクセラレータのスコープ</span><span class="sxs-lookup"><span data-stu-id="0bb05-142">Scoped accelerators</span></span>

<span data-ttu-id="0bb05-143">アクセラレータには、アプリ全体で動作するものと、特定のスコープのみで動作するものがあります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-143">Some accelerators work only in specific scopes while others work app-wide.</span></span>

<span data-ttu-id="0bb05-144">たとえば、Microsoft Outlook には、次のアクセラレータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-144">For example, Microsoft Outlook includes the following accelerators:</span></span>
-   <span data-ttu-id="0bb05-145">Ctrl + B、Ctrl + I、Esc キーは、メール送信フォームのスコープのみで動作します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-145">Ctrl+B, Ctrl+I and ESC work only on the scope of the send email form</span></span>
-   <span data-ttu-id="0bb05-146">Ctrl + 1 と Ctrl + 2 は、アプリ全体で動作します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-146">Ctrl+1 and Ctrl+2 work app-wide</span></span>

### <a name="context-menus"></a><span data-ttu-id="0bb05-147">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="0bb05-147">Context menus</span></span>

<span data-ttu-id="0bb05-148">コンテキスト メニューのアクションは、テキスト エディター内で選択された文字やプレイリスト内の曲など、特定の領域または要素のみに影響します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-148">Context menu actions affect only specific areas or elements, such as the selected characters in a text editor or a song in a playlist.</span></span> <span data-ttu-id="0bb05-149">このため、コンテキスト メニュー項目のキーボード アクセラレータのスコープは、コンテキスト メニューの親に設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-149">For this reason, we recommend setting the scope of keyboard accelerators for context menu items to the parent of the context menu.</span></span>

<span data-ttu-id="0bb05-150">キーボード アクセラレータのスコープを指定するには、[ScopeOwner](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.ScopeOwner)プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-150">Use the [ScopeOwner](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.ScopeOwner) property to specify the scope of the keyboard accelerator.</span></span> <span data-ttu-id="0bb05-151">このコードでは、スコープ指定されたキーボード アクセラレータと共に、コンテキスト メニューを ListView に実装する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-151">This code demonstrates how to implement a context menu on a ListView with scoped keyboard accelerators:</span></span>

``` xaml
<ListView x:Name="MyList">
  <ListView.ContextFlyout>
    <MenuFlyout>
      <MenuFlyoutItem Text="Share" Icon="Share"/>
      <MenuFlyoutItem Text="Copy" Icon="Copy">
        <MenuFlyoutItem.KeyboardAccelerators>
          <KeyboardAccelerator 
            Modifiers="Control" 
            Key="C" 
            ScopeOwner="{x:Bind MyList }" />
        </MenuFlyoutItem.KeyboardAccelerators>
      </MenuFlyoutItem>
      
      <MenuFlyoutItem Text="Delete" Icon="Delete" />
      <MenuFlyoutSeparator />
      
      <MenuFlyoutItem Text="Rename">
        <MenuFlyoutItem.KeyboardAccelerators>
          <KeyboardAccelerator 
            Modifiers="None" 
            Key="F2" 
            ScopeOwner="{x:Bind MyList}" />
        </MenuFlyoutItem.KeyboardAccelerators>
      </MenuFlyoutItem>
      
      <MenuFlyoutItem Text="Select" />
    </MenuFlyout>
    
  </ListView.ContextFlyout>
    
  <ListViewItem>Track 1</ListViewItem>
  <ListViewItem>Alternative Track 1</ListViewItem>

</ListView>
```

<span data-ttu-id="0bb05-152">MenuFlyoutItem.KeyboardAccelerators 要素の ScopeOwner 属性は、アクセラレータがグローバルではなくスコープ指定されていることを示します (既定値はグローバルを示す null)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-152">The ScopeOwner attribute of the MenuFlyoutItem.KeyboardAccelerators element marks the accelerator as scoped instead of global (the default is null, or global).</span></span> <span data-ttu-id="0bb05-153">詳しくは、このトピックの「**アクセラレータの解決**」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0bb05-153">For more detail, see the **Resolving accelerators** section later in this topic.</span></span>

## <a name="invoke-a-keyboard-accelerator"></a><span data-ttu-id="0bb05-154">キーボード アクセラレータを呼び出す</span><span class="sxs-lookup"><span data-stu-id="0bb05-154">Invoke a keyboard accelerator</span></span> 

<span data-ttu-id="0bb05-155">[KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) オブジェクトは、[UI オートメーション (UIA) コントロール パターン](https://msdn.microsoft.com/library/windows/desktop/ee671194(v=vs.85).aspx)を使用して、アクセラレータが呼び出されたときにアクションを実行します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-155">The [KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) object uses the [UI Automation (UIA) control pattern](https://msdn.microsoft.com/library/windows/desktop/ee671194(v=vs.85).aspx) to take action when an accelerator is invoked.</span></span>

<span data-ttu-id="0bb05-156">UIA [コントロール パターン] では、一般的なコントロール機能が公開されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-156">The UIA [control patterns] expose common control functionality.</span></span> <span data-ttu-id="0bb05-157">たとえば Button コントロールには、Click イベントをサポートするために [Invoke](https://msdn.microsoft.com/library/windows/desktop/ee671279(v=vs.85).aspx) コントロール パターンが実装されています (一般的に、コントロールはクリックまたはダブルクリックの操作のほか、Enter キー、定義済みのショートカット キー、または別の組み合わせのキー入力よって呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-157">For example, the Button control implements the [Invoke](https://msdn.microsoft.com/library/windows/desktop/ee671279(v=vs.85).aspx) control pattern to support the Click event (typically a control is invoked by clicking, double-clicking, or pressing Enter, a predefined keyboard shortcut, or some alternate combination of keystrokes).</span></span> <span data-ttu-id="0bb05-158">キーボード アクセラレータでコントロールが呼び出されると、XAML フレームワークは、コントロールに Invoke コントロール パターンが実装されているかどうかを調べ、その場合は、コントロールをアクティブ化します (KeyboardAcceleratorInvoked イベントをリッスンする必要はありません)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-158">When a keyboard accelerator is used to invoke a control, the XAML framework looks up whether the control implements the Invoke control pattern and, if so, activates it (it is not necessary to listen for the KeyboardAcceleratorInvoked event).</span></span>

<span data-ttu-id="0bb05-159">次の例では、ボタンに Invoke パターンが実装されているため、Ctrl + S によって Click イベントがトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-159">In the following example, Control+S triggers the Click event because the button implements the Invoke pattern.</span></span>

``` xaml 
<Button Content="Save" Click="OnSave">
  <Button.KeyboardAccelerators>
    <KeyboardAccelerator Key="S" Modifiers="Control" />
  </Button.KeyboardAccelerators>
</Button>
```

<span data-ttu-id="0bb05-160">要素に複数のコントロール パターンが実装されている場合、アクセラレータでアクティブ化できるのは 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-160">If an element implements multiple control patterns, only one can be activated through an accelerator.</span></span> <span data-ttu-id="0bb05-161">コントロール パターンの優先順位は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-161">The control patterns are prioritized as follows:</span></span>
1.  <span data-ttu-id="0bb05-162">Invoke (Button)</span><span class="sxs-lookup"><span data-stu-id="0bb05-162">Invoke (Button)</span></span>
2.  <span data-ttu-id="0bb05-163">Toggle (Checkbox)</span><span class="sxs-lookup"><span data-stu-id="0bb05-163">Toggle (Checkbox)</span></span>
3.  <span data-ttu-id="0bb05-164">Selection (ListView)</span><span class="sxs-lookup"><span data-stu-id="0bb05-164">Selection (ListView)</span></span>
4.  <span data-ttu-id="0bb05-165">Expand/Collapse (ComboBox)</span><span class="sxs-lookup"><span data-stu-id="0bb05-165">Expand/Collapse (ComboBox)</span></span> 

<span data-ttu-id="0bb05-166">一致するコントロール パターンが見つからない場合は、アクセラレータが無効となり、デバッグ メッセージが発行されます ("このコンポーネントのオートメーション パターンが見つかりません。</span><span class="sxs-lookup"><span data-stu-id="0bb05-166">If no match is identified, the accelerator is invalid and a debug message is provided ("No automation patterns for this component found.</span></span> <span data-ttu-id="0bb05-167">Invoked イベントに目的の動作をすべて実装してください。</span><span class="sxs-lookup"><span data-stu-id="0bb05-167">Implement all desired behavior in the Invoked event.</span></span> <span data-ttu-id="0bb05-168">イベント ハンドラーで Handled を true に設定すると、このメッセージは表示されません")。</span><span class="sxs-lookup"><span data-stu-id="0bb05-168">Setting Handled to true in your event handler suppresses this message.")</span></span>

## <a name="custom-keyboard-accelerator-behavior"></a><span data-ttu-id="0bb05-169">カスタムのキーボード アクセラレータの動作</span><span class="sxs-lookup"><span data-stu-id="0bb05-169">Custom keyboard accelerator behavior</span></span>

<span data-ttu-id="0bb05-170">[KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) オブジェクトの Invoked イベントは、アクセラレータが実行されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-170">The Invoked event of the [KeyboardAccelerator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator) object is fired when the accelerator is executed.</span></span> <span data-ttu-id="0bb05-171">[KeyboardAcceleratorInvokedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorinvokedeventargs) イベント オブジェクトには、次のプロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-171">The [KeyboardAcceleratorInvokedEventArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorinvokedeventargs) event object includes the following properties:</span></span>
- <span data-ttu-id="0bb05-172">**Handled** (Boolean): これを true に設定すると、イベントによるコントロール パターンのトリガーが回避され、アクセラレータ イベントのバブルが停止されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-172">**Handled** (Boolean): Setting this to true prevents the event triggering the control pattern and stops accelerator event bubbling.</span></span> <span data-ttu-id="0bb05-173">既定値は false です。</span><span class="sxs-lookup"><span data-stu-id="0bb05-173">The default is false.</span></span>
- <span data-ttu-id="0bb05-174">**Element** (DependencyObject): アクセラレータを含むオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-174">**Element** (DependencyObject): The object that contains the accelerator.</span></span>

<span data-ttu-id="0bb05-175">次のコードは、キーボード アクセラレータのコレクションを定義する方法と、Invoked イベントを処理する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-175">Here we demonstrate how to define a collection of keyboard accelerators and how to handle the Invoked event.</span></span>

``` xaml
<ListView x:Name="MyListView">
  <ListView.KeyboardAccelerators>
    <KeyboardAccelerator Key="A" Modifiers="Control,Shift" Invoked="SelectAllInvoked" />
    <KeyboardAccelerator Key="F5" Invoked="RefreshInvoked"  />
  </ListView.KeyboardAccelerators>
</ListView>   
```

``` csharp
void SelectAllInvoked (KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
  CustomSelectAll(MyListView);
  args.Handled = true;
}

void RefreshInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
  Refresh(MyListView);
  args.Handled = true;
}
```

## <a name="disable-a-keyboard-accelerator"></a><span data-ttu-id="0bb05-176">キーボード アクセラレータを無効にする</span><span class="sxs-lookup"><span data-stu-id="0bb05-176">Disable a keyboard accelerator</span></span> 

<span data-ttu-id="0bb05-177">コントロールが無効になると、関連付けられたアクセラレータも無効になります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-177">If a control is disabled, the associated accelerator is also disabled.</span></span> <span data-ttu-id="0bb05-178">次の例では、ListView の IsEnabled プロパティが false に設定されているため、関連付けられている Control+A アクセラレータを呼び出すことができません。</span><span class="sxs-lookup"><span data-stu-id="0bb05-178">In the following example, because the IsEnabled property of the ListView is set to false, the associated Control+A accelerator can't be invoked.</span></span>

``` xaml
<ListView >
  <ListView.KeyboardAccelerators>
    <KeyboardAccelerator Key="A" 
      Modifiers="Control"
      Invoked="CustomListViewSelecAllInvoked" />
  </ListView.KeyboardAccelerators>
  
  <TextBox>
    <TextBox.KeyboardAccelerators>
      <KeyboardAccelerator 
        Key="A" 
        Modifiers="Control" 
        Invoked="CustomTextSelecAllInvoked" 
        IsEnabled="False" />
    </TextBox.KeyboardAccelerators>
  </TextBox>

<ListView>
```

<span data-ttu-id="0bb05-179">親と子のコントロールは、同じアクセラレータを共有できます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-179">Parent and child controls can share the same accelerator.</span></span> <span data-ttu-id="0bb05-180">この場合は、子にフォーカスがあってアクセス キーが無効になっている場合でも、親のコントロールを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-180">In this case, the parent control can be invoked even if the child has focus and its accelerator is disabled.</span></span>

## <a name="screen-readers-and-keyboard-accelerators"></a><span data-ttu-id="0bb05-181">スクリーン リーダーとキーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="0bb05-181">Screen readers and keyboard accelerators</span></span> 

<span data-ttu-id="0bb05-182">ナレーターなどのスクリーン リーダーでは、キーボード アクセラレータを構成するキーの組み合わせをユーザーに読み上げることができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-182">Screen readers such as Narrator can announce the keyboard accelerator key combination to users.</span></span> <span data-ttu-id="0bb05-183">既定では、各修飾キー (VirtualModifiers 列挙の順) の後にキーが ("+" 記号で区切って) 組み合わされています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-183">By default, this is each modifier (in the VirtualModifiers enum order) followed by the key (and separated by "+" signs).</span></span> <span data-ttu-id="0bb05-184">これは、AutomationProperties の [AcceleratorKey](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties.AcceleratorKeyProperty) 添付プロパティを通じてカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-184">You can customize this through the [AcceleratorKey](https://docs.microsoft.com/uwp/api/windows.ui.xaml.automation.automationproperties.AcceleratorKeyProperty) AutomationProperties attached property.</span></span> <span data-ttu-id="0bb05-185">複数のアクセラレータが指定されている場合は、最初のものだけが通知されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-185">If more than one accelerator is specified, only the first is announced.</span></span>

<span data-ttu-id="0bb05-186">この例では、AutomationProperty.AcceleratorKey は "Control+Shift+A" という文字列を返します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-186">In this example, the AutomationProperty.AcceleratorKey returns the string "Control+Shift+A":</span></span>

``` xaml
<ListView x:Name="MyListView">
  <ListView.KeyboardAccelerators>

    <KeyboardAccelerator 
      Key="A" 
      Modifiers="Control,Shift" 
      Invoked="CustomSelectAllInvoked" />
      
    <KeyboardAccelerator 
      Key="F5" 
      Modifiers="None" 
      Invoked="RefreshInvoked" />

  </ListView.KeyboardAccelerators>

</ListView>   
```

> [!NOTE] 
> <span data-ttu-id="0bb05-187">AutomationProperties.AcceleratorKey を設定しても、キーボード機能が有効になるのではなく、使用するキーが UIA フレームワークに通知されるだけです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-187">Setting AutomationProperties.AcceleratorKey doesn't enable keyboard functionality, it only indicates to the UIA framework which keys are used.</span></span>

## <a name="common-keyboard-accelerators"></a><span data-ttu-id="0bb05-188">一般的なキーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="0bb05-188">Common Keyboard Accelerators</span></span>

<span data-ttu-id="0bb05-189">キーボード アクセラレータは、どの UWP アプリケーションでも統一することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-189">We recommend that you make keyboard accelerators consistent across UWP applications.</span></span> <span data-ttu-id="0bb05-190">ユーザーは、キーボード アクセラレータを記憶する必要があり、同じ (または同様の) 結果を期待します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-190">Users have to memorize keyboard accelerators and expect the same (or similar) results.</span></span>

<span data-ttu-id="0bb05-191">このことは、アプリによる機能の相違のため実現できないこともあります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-191">This might not always be possible due to differences in functionality across apps.</span></span>

| **<span data-ttu-id="0bb05-192">編集</span><span class="sxs-lookup"><span data-stu-id="0bb05-192">Editing</span></span>** | **<span data-ttu-id="0bb05-193">一般的なキーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="0bb05-193">Common Keyboard Accelerator</span></span>** |
| ------------- | ----------------------------------- |
| <span data-ttu-id="0bb05-194">編集モードを開始する</span><span class="sxs-lookup"><span data-stu-id="0bb05-194">Begin editing mode</span></span> | <span data-ttu-id="0bb05-195">Ctrl + E</span><span class="sxs-lookup"><span data-stu-id="0bb05-195">Ctrl + E</span></span> |
| <span data-ttu-id="0bb05-196">フォーカスのあるコントロール内またはウィンドウ内のすべての項目を選択する</span><span class="sxs-lookup"><span data-stu-id="0bb05-196">Select all items in a focused control or window</span></span> | <span data-ttu-id="0bb05-197">Ctrl + A</span><span class="sxs-lookup"><span data-stu-id="0bb05-197">Ctrl + A</span></span> |
| <span data-ttu-id="0bb05-198">検索して置換</span><span class="sxs-lookup"><span data-stu-id="0bb05-198">Search and replace</span></span> | <span data-ttu-id="0bb05-199">Ctrl + H</span><span class="sxs-lookup"><span data-stu-id="0bb05-199">Ctrl + H</span></span> |
| <span data-ttu-id="0bb05-200">元に戻す</span><span class="sxs-lookup"><span data-stu-id="0bb05-200">Undo</span></span> | <span data-ttu-id="0bb05-201">Ctrl + Z</span><span class="sxs-lookup"><span data-stu-id="0bb05-201">Ctrl + Z</span></span> |
| <span data-ttu-id="0bb05-202">やり直す</span><span class="sxs-lookup"><span data-stu-id="0bb05-202">Redo</span></span> | <span data-ttu-id="0bb05-203">Ctrl + Y</span><span class="sxs-lookup"><span data-stu-id="0bb05-203">Ctrl + Y</span></span> |
| <span data-ttu-id="0bb05-204">選択範囲を削除してクリップボードにコピーする</span><span class="sxs-lookup"><span data-stu-id="0bb05-204">Delete selection and copy it to the clipboard</span></span> | <span data-ttu-id="0bb05-205">Ctrl + X</span><span class="sxs-lookup"><span data-stu-id="0bb05-205">Ctrl + X</span></span> |
| <span data-ttu-id="0bb05-206">選択範囲をクリップボードにコピーする</span><span class="sxs-lookup"><span data-stu-id="0bb05-206">Copy selection to the clipboard</span></span> | <span data-ttu-id="0bb05-207">Ctrl + C、Ctrl + Ins</span><span class="sxs-lookup"><span data-stu-id="0bb05-207">Ctrl + C, Ctrl + Insert</span></span> |
| <span data-ttu-id="0bb05-208">クリップボードの内容を貼り付ける</span><span class="sxs-lookup"><span data-stu-id="0bb05-208">Paste the contents of the clipboard</span></span> | <span data-ttu-id="0bb05-209">Ctrl + V、Shift + Ins</span><span class="sxs-lookup"><span data-stu-id="0bb05-209">Ctrl + V, Shift + Insert</span></span> |
| <span data-ttu-id="0bb05-210">クリップボードの内容を貼り付ける (オプションあり)</span><span class="sxs-lookup"><span data-stu-id="0bb05-210">Paste the contents of the clipboard (with options)</span></span> | <span data-ttu-id="0bb05-211">Ctrl + Alt + V</span><span class="sxs-lookup"><span data-stu-id="0bb05-211">Ctrl + Alt + V</span></span> |
| <span data-ttu-id="0bb05-212">項目の名前を変更する</span><span class="sxs-lookup"><span data-stu-id="0bb05-212">Rename an item</span></span> | <span data-ttu-id="0bb05-213">F2</span><span class="sxs-lookup"><span data-stu-id="0bb05-213">F2</span></span> |
| <span data-ttu-id="0bb05-214">新しい項目を追加する</span><span class="sxs-lookup"><span data-stu-id="0bb05-214">Add a new item</span></span> | <span data-ttu-id="0bb05-215">Ctrl + N</span><span class="sxs-lookup"><span data-stu-id="0bb05-215">Ctrl + N</span></span> |
| <span data-ttu-id="0bb05-216">新しいセカンダリ項目を追加する</span><span class="sxs-lookup"><span data-stu-id="0bb05-216">Add a new secondary item</span></span> | <span data-ttu-id="0bb05-217">Ctrl + Shift + N</span><span class="sxs-lookup"><span data-stu-id="0bb05-217">Ctrl + Shift + N</span></span> |
| <span data-ttu-id="0bb05-218">選択した項目を削除する (元に戻すオプションあり)</span><span class="sxs-lookup"><span data-stu-id="0bb05-218">Delete selected item (with undo)</span></span> | <span data-ttu-id="0bb05-219">Del、Ctrl+D</span><span class="sxs-lookup"><span data-stu-id="0bb05-219">Del, Ctrl+D</span></span> |
| <span data-ttu-id="0bb05-220">選択した項目を削除する (元に戻すオプションなし)</span><span class="sxs-lookup"><span data-stu-id="0bb05-220">Delete selected item (without undo)</span></span> | <span data-ttu-id="0bb05-221">Shift + Del</span><span class="sxs-lookup"><span data-stu-id="0bb05-221">Shift + Del</span></span> |
| <span data-ttu-id="0bb05-222">太字</span><span class="sxs-lookup"><span data-stu-id="0bb05-222">Bold</span></span> | <span data-ttu-id="0bb05-223">Ctrl + B</span><span class="sxs-lookup"><span data-stu-id="0bb05-223">Ctrl + B</span></span> |
| <span data-ttu-id="0bb05-224">下線</span><span class="sxs-lookup"><span data-stu-id="0bb05-224">Underline</span></span> | <span data-ttu-id="0bb05-225">Ctrl + U</span><span class="sxs-lookup"><span data-stu-id="0bb05-225">Ctrl + U</span></span> |
| <span data-ttu-id="0bb05-226">斜体</span><span class="sxs-lookup"><span data-stu-id="0bb05-226">Italic</span></span> | <span data-ttu-id="0bb05-227">Ctrl + I</span><span class="sxs-lookup"><span data-stu-id="0bb05-227">Ctrl + I</span></span> |

| **<span data-ttu-id="0bb05-228">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="0bb05-228">Navigation</span></span>** | |
| ------------- | ----------------------------------- |
| <span data-ttu-id="0bb05-229">フォーカスのあるコントロールまたはウィンドウでコンテンツを見つける</span><span class="sxs-lookup"><span data-stu-id="0bb05-229">Find content in a focused control or Window</span></span> | <span data-ttu-id="0bb05-230">Ctrl + F</span><span class="sxs-lookup"><span data-stu-id="0bb05-230">Ctrl + F</span></span> |
| <span data-ttu-id="0bb05-231">次の検索結果に移動する</span><span class="sxs-lookup"><span data-stu-id="0bb05-231">Go to the next search result</span></span> | <span data-ttu-id="0bb05-232">F3</span><span class="sxs-lookup"><span data-stu-id="0bb05-232">F3</span></span> |

| **<span data-ttu-id="0bb05-233">その他の操作</span><span class="sxs-lookup"><span data-stu-id="0bb05-233">Other Actions</span></span>** | |
| ------------- | ----------------------------------- |
| <span data-ttu-id="0bb05-234">お気に入りに追加する</span><span class="sxs-lookup"><span data-stu-id="0bb05-234">Add favorites</span></span> | <span data-ttu-id="0bb05-235">Ctrl + D</span><span class="sxs-lookup"><span data-stu-id="0bb05-235">Ctrl + D</span></span> | 
| <span data-ttu-id="0bb05-236">最新の情報に更新する</span><span class="sxs-lookup"><span data-stu-id="0bb05-236">Refresh</span></span> | <span data-ttu-id="0bb05-237">F5 または Ctrl + R</span><span class="sxs-lookup"><span data-stu-id="0bb05-237">F5 or Ctrl + R</span></span> | 
| <span data-ttu-id="0bb05-238">拡大</span><span class="sxs-lookup"><span data-stu-id="0bb05-238">Zoom In</span></span> | <span data-ttu-id="0bb05-239">Ctrl + +</span><span class="sxs-lookup"><span data-stu-id="0bb05-239">Ctrl + +</span></span> | 
| <span data-ttu-id="0bb05-240">縮小</span><span class="sxs-lookup"><span data-stu-id="0bb05-240">Zoom out</span></span> | <span data-ttu-id="0bb05-241">Ctrl + -</span><span class="sxs-lookup"><span data-stu-id="0bb05-241">Ctrl + -</span></span> | 
| <span data-ttu-id="0bb05-242">既定の表示倍率に拡大縮小</span><span class="sxs-lookup"><span data-stu-id="0bb05-242">Zoom to default view</span></span> | <span data-ttu-id="0bb05-243">Ctrl + 0</span><span class="sxs-lookup"><span data-stu-id="0bb05-243">Ctrl + 0</span></span> | 
| <span data-ttu-id="0bb05-244">上書き保存</span><span class="sxs-lookup"><span data-stu-id="0bb05-244">Save</span></span> | <span data-ttu-id="0bb05-245">Ctrl + S</span><span class="sxs-lookup"><span data-stu-id="0bb05-245">Ctrl + S</span></span> | 
| <span data-ttu-id="0bb05-246">閉じる</span><span class="sxs-lookup"><span data-stu-id="0bb05-246">Close</span></span> | <span data-ttu-id="0bb05-247">Ctrl + W</span><span class="sxs-lookup"><span data-stu-id="0bb05-247">Ctrl + W</span></span> | 
| <span data-ttu-id="0bb05-248">印刷</span><span class="sxs-lookup"><span data-stu-id="0bb05-248">Print</span></span> | <span data-ttu-id="0bb05-249">Ctrl + P</span><span class="sxs-lookup"><span data-stu-id="0bb05-249">Ctrl + P</span></span> | 

<span data-ttu-id="0bb05-250">ローカライズされたバージョンの Windows では使用できない組み合わせもあります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-250">Notice that some of the combinations are not valid for localized versions of Windows.</span></span> <span data-ttu-id="0bb05-251">たとえば、スペイン語バージョンの Windows では、太字の指定には Ctrl + B ではなく Ctrl + N が使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-251">For example, in the Spanish version of Windows, Ctrl+N is used for bold instead of Ctrl+B.</span></span> <span data-ttu-id="0bb05-252">アプリがローカライズされている場合は、ローカライズされたキーボード アクセラレータを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-252">We recommend providing localized keyboard accelerators if the app is localized.</span></span>

## <a name="usability-affordances-for-keyboard-accelerators"></a><span data-ttu-id="0bb05-253">キーボード アクセラレータのユーザビリティ アフォーダンス</span><span class="sxs-lookup"><span data-stu-id="0bb05-253">Usability affordances for keyboard accelerators</span></span>

### <a name="tooltips"></a><span data-ttu-id="0bb05-254">ヒント</span><span class="sxs-lookup"><span data-stu-id="0bb05-254">Tooltips</span></span>

<span data-ttu-id="0bb05-255">通常、キーボード アクセラレータは UWP アプリケーションの UI で直接説明されるものではありません。ユーザーがフォーカスをコントロールに移動したり、コントロールを長押ししたり、マウス ポインターをコントロール上にホバーしたりするときに自動的に表示される、[ヒント](../controls-and-patterns/tooltips.md)を使用すると、キーボード アクセラレータが見つけやすくなります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-255">As keyboard accelerators are not typically described directly in the UI of your UWP application, you can improve discoverability through [tooltips](../controls-and-patterns/tooltips.md), which display automatically when the user moves focus to, presses and holds, or hovers the mouse pointer over a control.</span></span> <span data-ttu-id="0bb05-256">ヒントによって、コントロールにキーボード アクセラレータが関連付けられているかどうかを識別でき、関連付けられている場合は、アクセラレータ キーの組み合わせを識別することができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-256">The tooltip can identify whether a control has an associated keyboard accelerator and, if so, what the accelerator key combination is.</span></span>

**<span data-ttu-id="0bb05-257">Windows 10、バージョン 1803 (年 2018年 4 月更新) 以降</span><span class="sxs-lookup"><span data-stu-id="0bb05-257">Windows 10, Version 1803 (April 2018 Update) and newer</span></span>**

<span data-ttu-id="0bb05-258">既定では、キーボード アクセラレータを宣言すると、( [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem)と[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)) を除くすべてのコントロール表示対応するキーの組み合わせツールヒントにします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-258">By default, When keyboard accelerators are declared, all controls (except [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem) and [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)) present the corresponding key combinations in a tooltip.</span></span>

> [!NOTE] 
> <span data-ttu-id="0bb05-259">コントロールに定義されている 1 つ以上のアクセスがある場合は、最初のレコードのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-259">If a control has more than one accelerator defined, only the first is presented.</span></span>

![アクセラレータ キーのヒント](images/accelerators/accelerators_tooltip_savebutton_small.png)

*<span data-ttu-id="0bb05-261">ヒントでのアクセラレータ キーの組み合わせ</span><span class="sxs-lookup"><span data-stu-id="0bb05-261">Accelerator key combo in tooltip</span></span>*

<span data-ttu-id="0bb05-262">[ボタン](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.button)、 [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)と[AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton)オブジェクトは、コントロールの既定のツールヒントに、アクセス キーが追加されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-262">For [Button](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.button), [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton), and [AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) objects, the keyboard accelerator is appended to the control's default tooltip.</span></span> <span data-ttu-id="0bb05-263">[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)と[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)) オブジェクトをテキストをフライアウト アクセス キーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-263">For [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton) and [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)) objects, the keyboard accelerator is displayed with the flyout text.</span></span>

> [!NOTE]
> <span data-ttu-id="0bb05-264">ヒントを指定する (次の例を参照 Button1) は、この動作を上書きします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-264">Specifying a tooltip (see Button1 in the following example) overrides this behavior.</span></span>

```xaml
<StackPanel x:Name="Container" Grid.Row="0" Background="AliceBlue">
    <Button Content="Button1" Margin="20"
            Click="OnSave" 
            KeyboardAcceleratorPlacementMode="Auto" 
            ToolTipService.ToolTip="Tooltip">
        <Button.KeyboardAccelerators>
            <KeyboardAccelerator  Key="A" Modifiers="Windows"/>
        </Button.KeyboardAccelerators>
    </Button>
    <Button Content="Button2"  Margin="20"
            Click="OnSave" 
            KeyboardAcceleratorPlacementMode="Auto">
        <Button.KeyboardAccelerators>
            <KeyboardAccelerator  Key="B" Modifiers="Windows"/>
        </Button.KeyboardAccelerators>
    </Button>
    <Button Content="Button3"  Margin="20"
            Click="OnSave" 
            KeyboardAcceleratorPlacementMode="Auto">
        <Button.KeyboardAccelerators>
            <KeyboardAccelerator  Key="C" Modifiers="Windows"/>
        </Button.KeyboardAccelerators>
    </Button>
</StackPanel>
```

![アクセラレータ キーのヒント](images/accelerators/accelerators-button-small.png)

*<span data-ttu-id="0bb05-266">ボタンの既定のツールヒントに追加のアクセス キーの組み合わせ</span><span class="sxs-lookup"><span data-stu-id="0bb05-266">Accelerator key combo appended to Button's default tooltip</span></span>*

```xaml
<AppBarButton Icon="Save" Label="Save">
    <AppBarButton.KeyboardAccelerators>
        <KeyboardAccelerator Key="S" Modifiers="Control"/>
    </AppBarButton.KeyboardAccelerators>
</AppBarButton>
```

![アクセラレータ キーのヒント](images/accelerators/accelerators-appbarbutton-small.png)

*<span data-ttu-id="0bb05-268">アクセス キーの組み合わせ AppBarButton の既定のヒントを追加します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-268">Accelerator key combo appended to AppBarButton's default tooltip</span></span>*

```xaml
<AppBarButton AccessKey="R" Icon="Refresh" Label="Refresh" IsAccessKeyScope="True">
    <AppBarButton.Flyout>
        <MenuFlyout>
            <MenuFlyoutItem AccessKey="A" Icon="Refresh" Text="Refresh A">
                <MenuFlyoutItem.KeyboardAccelerators>
                    <KeyboardAccelerator Key="R" Modifiers="Control"/>
                </MenuFlyoutItem.KeyboardAccelerators>
            </MenuFlyoutItem>
            <MenuFlyoutItem AccessKey="B" Icon="Globe" Text="Refresh B" />
            <MenuFlyoutItem AccessKey="C" Icon="Globe" Text="Refresh C" />
            <MenuFlyoutItem AccessKey="D" Icon="Globe" Text="Refresh D" />
            <ToggleMenuFlyoutItem AccessKey="E" Icon="Globe" Text="ToggleMe">
                <MenuFlyoutItem.KeyboardAccelerators>
                    <KeyboardAccelerator Key="Q" Modifiers="Control"/>
                </MenuFlyoutItem.KeyboardAccelerators>
            </ToggleMenuFlyoutItem>
        </MenuFlyout>
    </AppBarButton.Flyout>
</AppBarButton>
```

![アクセラレータ キーのヒント](images/accelerators/accelerators-appbar-menuflyoutitem-small.png)

*<span data-ttu-id="0bb05-270">アクセス キーの組み合わせ MenuFlyoutItem のテキストを追加します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-270">Accelerator key combo appended to MenuFlyoutItem's text</span></span>*

<span data-ttu-id="0bb05-271">表示の動作を制御するには、[KeyboardAcceleratorPlacementMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.KeyboardAcceleratorPlacementMode) プロパティを使用します。このプロパティは 2 つの値、[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode) または [Hidden](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode) を受け入れます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-271">Control the presentation behavior by using the [KeyboardAcceleratorPlacementMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.KeyboardAcceleratorPlacementMode) property, which accepts two values: [Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode) or [Hidden](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardacceleratorplacementmode).</span></span>    

```xaml
<Button Content="Save" Click="OnSave" KeyboardAcceleratorPlacementMode="Auto">
    <Button.KeyboardAccelerators>
        <KeyboardAccelerator Key="S" Modifiers="Control" />
    </Button.KeyboardAccelerators>
</Button>
```

<span data-ttu-id="0bb05-272">場合によっては、他の要素 (通常はコンテナー オブジェクト) に関連するヒントを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-272">In some cases, you might need to present a tooltip relative to another element (typically a container object).</span></span> <span data-ttu-id="0bb05-273">たとえば、ピボット ヘッダー共に PivotItem のヒントを表示するピボット コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-273">For example, a Pivot control that displays the tooltip for a PivotItem with the Pivot header.</span></span> 

<span data-ttu-id="0bb05-274">ここでは、KeyboardAcceleratorPlacementTarget プロパティを使用して、[保存] ボタンのキーボード アクセラレータを構成するキーの組み合わを表示する方法について説明します。この例では、ボタンではなく Grid コンテナーを使用します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-274">Here, we show how to use the KeyboardAcceleratorPlacementTarget property to display the keyboard accelerator key combination for a Save button with the Grid container instead of the button.</span></span>

```xaml
<Grid x:Name="Container" Padding="30">
  <Button Content="Save"
    Click="OnSave"
    KeyboardAcceleratorPlacementMode="Auto"
    KeyboardAcceleratorPlacementTarget="{x:Bind Container}">
    <Button.KeyboardAccelerators>
      <KeyboardAccelerator  Key="S" Modifiers="Control" />
    </Button.KeyboardAccelerators>
  </Button>
</Grid>
```

### <a name="labels"></a><span data-ttu-id="0bb05-275">ラベル</span><span class="sxs-lookup"><span data-stu-id="0bb05-275">Labels</span></span>

<span data-ttu-id="0bb05-276">場合によっては、コントロールのラベルを使用して、コントロールにキーボード アクセラレータが関連付けられているかどうかを識別し、関連付けられている場合は、アクセラレータ キーの組み合わせを識別することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-276">In some cases, we recommend using a control's label to identify whether the control has an associated keyboard accelerator and, if so, what the accelerator key combination is.</span></span> 

<span data-ttu-id="0bb05-277">一部のプラットフォームのコントロールでは、既定でこの識別が行われます。具体的には、[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem) オブジェクトと [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem) オブジェクトで実行されます。これに対して、[AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton) と [AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) は、[CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar) のオーバーフロー メニューにこれらが表示されたときに、この識別が行われます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-277">Some platform controls do this by default, specifically the [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem) and [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem) objects, while the [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton) and the [AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) do it when they appear in the overflow menu of the [CommandBar](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.commandbar).</span></span>

![メニュー項目ラベルに示されているキーボード アクセラレータ](images/accelerators/accelerators_menuitemlabel.png)  
*<span data-ttu-id="0bb05-279">メニュー項目ラベルに示されているキーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="0bb05-279">Keyboard accelerators described in a menu item label</span></span>*

<span data-ttu-id="0bb05-280">[MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem)、[ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem)、[AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)、[AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) の各コントロールの [KeyboardAcceleratorTextOverride](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.KeyboardAcceleratorTextOverride) プロパティを使用して、ラベルの既定のアクセラレータ テキストを上書きすることができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-280">You can override the default accelerator text for the label through the [KeyboardAcceleratorTextOverride](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton.KeyboardAcceleratorTextOverride) property of the [MenuFlyoutItem](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.MenuFlyoutItem), [ToggleMenuFlyoutItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.togglemenuflyoutitem), [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton), and [AppBarToggleButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbartogglebutton) controls (use a single space for no text).</span></span> 

> [!NOTE] 
> <span data-ttu-id="0bb05-281">上書きしたテキストは、取り付けられているキーボードをシステムが検出できない場合は表示されません (取り付けられているキーボードの検出は、[KeyboardPresent](https://docs.microsoft.com/uwp/api/windows.devices.input.keyboardcapabilities.KeyboardPresent) プロパティを使用して、ご自分で確認することができます)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-281">The override text is not be presented if the system cannot detect an attached keyboard (you can check this yourself through the [KeyboardPresent](https://docs.microsoft.com/uwp/api/windows.devices.input.keyboardcapabilities.KeyboardPresent) property).</span></span>

## <a name="advanced-concepts"></a><span data-ttu-id="0bb05-282">高度な概念</span><span class="sxs-lookup"><span data-stu-id="0bb05-282">Advanced Concepts</span></span>

<span data-ttu-id="0bb05-283">ここでは、キーボード アクセラレータの基本的な特徴をいくつか確認します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-283">Here, we review some low-level aspects of keyboard accelerators.</span></span>

### <a name="when-an-accelerator-is-invoked"></a><span data-ttu-id="0bb05-284">アクセラレータの呼び出し</span><span class="sxs-lookup"><span data-stu-id="0bb05-284">When an accelerator is invoked</span></span>

<span data-ttu-id="0bb05-285">アクセラレータは、2 種類のキー (修飾キーと非修飾キー) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-285">Accelerators are composed of two types of keys: modifiers and non-modifiers.</span></span> <span data-ttu-id="0bb05-286">修飾キーには、Shift キー、メニュー キー、Ctrl キー、Windows キーがあり、[VirtualKeyModifiers](http://msdn.microsoft.com/library/windows/apps/xaml/Windows.System.VirtualKeyModifiers) で公開されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-286">Modifier keys include Shift, Menu, Control, and the Windows key, which are exposed through [VirtualKeyModifiers](http://msdn.microsoft.com/library/windows/apps/xaml/Windows.System.VirtualKeyModifiers).</span></span> <span data-ttu-id="0bb05-287">非修飾子キーは、Del キー、F3 キー、Space キー、Esc キーなどのすべての仮想キーと、すべての英数字キー、記号キーです。</span><span class="sxs-lookup"><span data-stu-id="0bb05-287">Non-modifiers are any virtual key, such as Delete, F3, Spacebar, Esc, and all alphanumeric and punctuation keys.</span></span> <span data-ttu-id="0bb05-288">キーボード アクセラレータは、ユーザーが 1 つまたは複数の修飾キーを押しながら非修飾キーを押したときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-288">A keyboard accelerator is invoked when the user presses a non-modifier key while they press and hold one or more modifier keys.</span></span> <span data-ttu-id="0bb05-289">たとえば、ユーザーが Ctrl + Shift + M を押す場合、M キーが押されたときに、フレームワークは修飾キー (Ctrl キーと Shift キー) を確認し、存在する場合はアクセラレータを起動します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-289">For example, if the user presses Ctrl+Shift+M, when the user presses M, the framework checks the modifiers (Ctrl and Shift) and fires the accelerator, if it exists.</span></span>

> [!NOTE]
> <span data-ttu-id="0bb05-290">仕様では、アクセラレータは自動的に反復されます (たとえば、ユーザーが Ctrl + Shift を押しながら M キーを押した場合は、M キーが解放されるまで、アクセラレータが繰り返し呼び出されます)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-290">By design, the accelerator autorepeats (for example, when the user presses Ctrl+Shift and then holds down M, the accelerator is invoked repeatedly until M is released).</span></span> <span data-ttu-id="0bb05-291">この動作は変更できません。</span><span class="sxs-lookup"><span data-stu-id="0bb05-291">This behavior cannot be modified.</span></span>

### <a name="input-event-priority"></a><span data-ttu-id="0bb05-292">入力イベントの優先順位</span><span class="sxs-lookup"><span data-stu-id="0bb05-292">Input event priority</span></span>
<span data-ttu-id="0bb05-293">入力イベントは特定の順序で発生します。これをインターセプトし、アプリの要件に基づいて処理することができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-293">Input events occur in a specific sequence that you can intercept and handle based on the requirements of your app.</span></span> 

#### <a name="the-keydownkeyup-bubbling-event"></a><span data-ttu-id="0bb05-294">KeyDown/KeyUp バブル イベント</span><span class="sxs-lookup"><span data-stu-id="0bb05-294">The KeyDown/KeyUp bubbling event</span></span> 

<span data-ttu-id="0bb05-295">XAML では、入力バブル パイプラインが 1 つだけであるかのようにキー入力が処理されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-295">In XAML, a keystroke is processed as if there is just one input bubbling pipeline.</span></span> <span data-ttu-id="0bb05-296">この入力パイプラインは KeyDown/KeyUp イベントや文字入力によって使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-296">This input pipeline is used by the KeyDown/KeyUp events and character input.</span></span> <span data-ttu-id="0bb05-297">たとえば、要素にフォーカスがある場合にユーザーがキーを押すと、その要素で KeyDown イベントが発生します。これに続き、要素の親、さらにその親と、args.Handled プロパティが true になるまでツリー上層方向にイベントの発生が続きます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-297">For example, if an element has focus and the user presses a key down, a KeyDown event is raised on the element, followed by the parent of the element, and so on up the tree, until the args.Handled property is true.</span></span>

<span data-ttu-id="0bb05-298">KeyDown イベントは、一部のコントロールで組み込みのコントロール アクセラレータを実装するためにも使用されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-298">The KeyDown event is also used by some controls to implement the built-in control accelerators.</span></span> <span data-ttu-id="0bb05-299">コントロールにキーボード アクセラレータが設定されている場合は、KeyDown イベントが処理されます。つまり、KeyDown イベント バブルは発生しません。</span><span class="sxs-lookup"><span data-stu-id="0bb05-299">When a control has a keyboard accelerator, it handles the KeyDown event, which means that there won't be KeyDown event bubbling.</span></span> <span data-ttu-id="0bb05-300">たとえば、RichEditBox は、Ctrl + C によるコピー操作をサポートします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-300">For example, the RichEditBox supports copy with Ctrl+C.</span></span> <span data-ttu-id="0bb05-301">Ctrl が押されると KeyDown イベントおよびバブルが発生しますが、ユーザーが同時に C キーを押した場合、KeyDown イベントが Handled となり発生しません ([UIElement.AddHandler](http://msdn.microsoft.com/library/windows/apps/xaml/Windows.UI.Xaml.UIElement.AddHandler) の handledEventsToo パラメーターが true に設定されている場合は例外)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-301">When Ctrl is pressed, the KeyDown event is fired and bubbles, but when the user presses C at the same time, the KeyDown event is marked Handled and is not raised (unless the handledEventsToo parameter of [UIElement.AddHandler](http://msdn.microsoft.com/library/windows/apps/xaml/Windows.UI.Xaml.UIElement.AddHandler) is set to true).</span></span>

#### <a name="the-characterreceived-event"></a><span data-ttu-id="0bb05-302">CharacterReceived イベント</span><span class="sxs-lookup"><span data-stu-id="0bb05-302">The CharacterReceived event</span></span>

<span data-ttu-id="0bb05-303">TextBox などのテキスト コントロールに対する [KeyDown](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.KeyDown) イベントの後で [CharacterReceived](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.CharacterReceived) イベントが発生した場合は、KeyDown イベント ハンドラーで文字入力を取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-303">As the [CharacterReceived](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.CharacterReceived) event is fired after the [KeyDown](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.KeyDown) event for text controls such as TextBox, you can cancel character input in the KeyDown event handler.</span></span>

#### <a name="the-previewkeydown-and-previewkeyup-events"></a><span data-ttu-id="0bb05-304">PreviewKeyDown イベントと PreviewKeyUp イベント</span><span class="sxs-lookup"><span data-stu-id="0bb05-304">The PreviewKeyDown and PreviewKeyUp events</span></span>

<span data-ttu-id="0bb05-305">プレビュー入力イベントは、他のイベントの前に発生します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-305">The preview input events are fired before any other events.</span></span> <span data-ttu-id="0bb05-306">これらのイベントを処理しない場合は、フォーカスのある要素のアクセラレータが呼び出され、これに続いて KeyDown イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-306">If you don't handle these events, the accelerator for the element that has the focus is fired, followed by the KeyDown event.</span></span> <span data-ttu-id="0bb05-307">処理されるまで、両方のイベントのバブルが発生します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-307">Both events bubble until handled.</span></span>


![<span data-ttu-id="0bb05-308">キー イベントのシーケンス](images/accelerators/accelerators_keyevents.png)
***キー イベントのシーケンス***</span><span class="sxs-lookup"><span data-stu-id="0bb05-308">Key event sequence](images/accelerators/accelerators_keyevents.png)
***Key event sequence***</span></span>

<span data-ttu-id="0bb05-309">イベントの順序:</span><span class="sxs-lookup"><span data-stu-id="0bb05-309">Order of events:</span></span>

<span data-ttu-id="0bb05-310">PreviewKeyDown イベント …</span><span class="sxs-lookup"><span data-stu-id="0bb05-310">Preview KeyDown events …</span></span>
<span data-ttu-id="0bb05-311">アプリ アクセラレータ、OnKeyDown メソッド、KeyDown イベント、親に対するアプリ アクセラレータ、親に対する OnKeyDown メソッド、親に対する KeyDown イベント (ルートまでバブル) …</span><span class="sxs-lookup"><span data-stu-id="0bb05-311">App accelerator OnKeyDown method KeyDown event App accelerators on the parent OnKeyDown method on the parent KeyDown event on the parent (Bubbles to the root) …</span></span>
<span data-ttu-id="0bb05-312">CharacterReceived イベント、PreviewKeyUp イベント、KeyUp イベント</span><span class="sxs-lookup"><span data-stu-id="0bb05-312">CharacterReceived event PreviewKeyUp events KeyUpEvents</span></span>

<span data-ttu-id="0bb05-313">アクセラレータ イベントが処理されると、KeyDown イベントも処理済みとしてマークされます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-313">When the accelerator event is handled, the KeyDown event is also marked as handled.</span></span> <span data-ttu-id="0bb05-314">KeyUp イベントは、未処理のままとなります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-314">The KeyUp event remains unhandled.</span></span>

### <a name="resolving-accelerators"></a><span data-ttu-id="0bb05-315">アクセラレータの解決</span><span class="sxs-lookup"><span data-stu-id="0bb05-315">Resolving accelerators</span></span>

<span data-ttu-id="0bb05-316">フォーカスのある要素からルートまで、キーボード アクセラレータ イベントのバブルが発生します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-316">A keyboard accelerator event bubbles from the element that has focus up to the root.</span></span> <span data-ttu-id="0bb05-317">イベントが処理されない場合、XAML フレームワークはバブル パスの外で、スコープ外の他のアプリ アクセラレータを探します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-317">If the event isn't handled, the XAML framework looks for other unscoped app accelerators outside of the bubbling path.</span></span>

<span data-ttu-id="0bb05-318">2 つのキーボード アクセラレータが同じキーの組み合わせで定義されている場合は、ビジュアル ツリーで最初に見つかったキーボード アクセラレータが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-318">When two keyboard accelerators are defined with the same key combination, the first keyboard accelerator found on the visual tree is invoked.</span></span>

<span data-ttu-id="0bb05-319">スコープ指定されたキーボード アクセラレータは、フォーカスが特定のスコープ内にある場合にのみ呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-319">Scoped keyboard accelerators are invoked only when focus is inside a specific scope.</span></span> <span data-ttu-id="0bb05-320">たとえば、多数のコントロールが含まれる Grid では、Grid (スコープ所有者) 内にフォーカスがある場合にのみ、コントロールに対してキーボード アクセラレータを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-320">For example, in a Grid that contains dozens of controls, a keyboard accelerator can be invoked for a control only when focus is within the Grid (the scope owner).</span></span>

### <a name="scoping-accelerators-programmatically"></a><span data-ttu-id="0bb05-321">アクセラレータのスコープをプログラムで指定する</span><span class="sxs-lookup"><span data-stu-id="0bb05-321">Scoping accelerators programmatically</span></span>

<span data-ttu-id="0bb05-322">[UIElement.TryInvokeKeyboardAccelerator](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement.tryinvokekeyboardaccelerator) メソッドは、要素のサブツリー内で一致するアクセラレータを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-322">The [UIElement.TryInvokeKeyboardAccelerator](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement.tryinvokekeyboardaccelerator) method invokes any matching accelerators in the subtree of the element.</span></span>

<span data-ttu-id="0bb05-323">[UIElement.OnProcessKeyboardAccelerators](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement.onprocesskeyboardaccelerators) メソッドは、キーボード アクセラレータの前に実行されます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-323">The [UIElement.OnProcessKeyboardAccelerators](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement.onprocesskeyboardaccelerators) method is executed before the keyboard accelerator.</span></span> <span data-ttu-id="0bb05-324">このメソッドは、キー、修飾子、およびブール値 (キーボード アクセラレータが処理済みかどうかを示す) が含まれた [ProcessKeyboardAcceleratorArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.processkeyboardacceleratoreventargs) オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-324">This method passes a [ProcessKeyboardAcceleratorArgs](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.processkeyboardacceleratoreventargs) object that contains the key, the modifier, and a Boolean indicating whether the keyboard accelerator is handled.</span></span> <span data-ttu-id="0bb05-325">処理済みとしてマークされると、キーボード アクセラレータでバブルが発生します (外部のキーボード アクセラレータが呼び出されることはありません)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-325">If marked as handled, the keyboard accelerator bubbles (so the outside keyboard accelerator is never invoked).</span></span>

> [!NOTE]
> <span data-ttu-id="0bb05-326">処理済みかどうかに関係なく、OnProcessKeyboardAccelerators は常に発生します (OnKeyDown イベントに似ています)。</span><span class="sxs-lookup"><span data-stu-id="0bb05-326">OnProcessKeyboardAccelerators always fires, whether handled or not (similar to the OnKeyDown event).</span></span> <span data-ttu-id="0bb05-327">イベントが処理済みとしてマークされたかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0bb05-327">You must check whether the event was marked as handled.</span></span>

<span data-ttu-id="0bb05-328">この例では、OnProcessKeyboardAccelerators と TryInvokeKeyboardAccelerator を使用して、キーボード アクセラレータのスコープを Page オブジェクトに設定します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-328">In this example, we use OnProcessKeyboardAccelerators and TryInvokeKeyboardAccelerator to scope keyboard accelerators to the Page object:</span></span>

``` csharp
protected override void OnProcessKeyboardAccelerators(
  ProcessKeyboardAcceleratorArgs args)
{
  if(args.Handled != true)
  {
    this.TryInvokeKeyboardAccelerator(args);
    args.Handled = true;
  }
}
```

### <a name="localize-the-accelerators"></a><span data-ttu-id="0bb05-329">アクセラレータのローカライズ</span><span class="sxs-lookup"><span data-stu-id="0bb05-329">Localize the accelerators</span></span>

<span data-ttu-id="0bb05-330">キーボード アクセラレータは、すべてローカライズすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0bb05-330">We recommend localizing all keyboard accelerators.</span></span> <span data-ttu-id="0bb05-331">これを行うには、標準的な UWP リソース (.resw) ファイルと XAML 宣言の x:Uid 属性を使用します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-331">You can do this with the standard UWP resources (.resw) file and the x:Uid attribute in your XAML declarations.</span></span> <span data-ttu-id="0bb05-332">この例では、Windows ランタイムによってリソースが自動的に読み込まれます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-332">In this example, the Windows Runtime automatically loads the resources.</span></span>

![<span data-ttu-id="0bb05-333">UWP リソース ファイルの使用によるキーボード アクセラレータのローカライズ](images/accelerators/accelerators_localization.png)
***UWP リソース ファイルの使用によるキーボード アクセラレータのローカライズ***</span><span class="sxs-lookup"><span data-stu-id="0bb05-333">Keyboard accelerator localization with UWP resources file](images/accelerators/accelerators_localization.png)
***Keyboard accelerator localization with UWP resources file***</span></span>

``` xaml
<Button x:Uid="myButton" Click="OnSave">
  <Button.KeyboardAccelerators>
    <KeyboardAccelerator x:Uid="myKeyAccelerator" Modifiers="Control"/>
  </Button.KeyboardAccelerators>
</Button>
```

### <a name="setup-an-accelerator-programmatically"></a><span data-ttu-id="0bb05-334">アクセラレータをプログラムでセットアップする</span><span class="sxs-lookup"><span data-stu-id="0bb05-334">Setup an accelerator programmatically</span></span>

<span data-ttu-id="0bb05-335">アクセラレータをプログラムで定義する例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-335">Here is an example of programmatically defining an accelerator:</span></span>

``` csharp
void AddAccelerator(
  VirtualKeyModifiers keyModifiers, 
  VirtualKey key, 
  TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> handler )
  {
    var accelerator = 
      new KeyboardAccelerator() 
      { 
        Modifiers = keyModifiers, Key = key
      };
    accelerator.Invoked = handler;
    this.KeyAccelerators.Add(accelerator);
  }
```

> [!NOTE]
> <span data-ttu-id="0bb05-336">KeyboardAccelerator は共有できません。同じ KeyboardAccelerator を複数の要素に追加することはできません。</span><span class="sxs-lookup"><span data-stu-id="0bb05-336">KeyboardAccelerator is not shareable, the same KeyboardAccelerator can't be added to multiple elements.</span></span>

### <a name="override-keyboard-accelerator-behavior"></a><span data-ttu-id="0bb05-337">キーボード アクセラレータの動作を上書きする</span><span class="sxs-lookup"><span data-stu-id="0bb05-337">Override keyboard accelerator behavior</span></span>

<span data-ttu-id="0bb05-338">[KeyboardAccelerator.Invoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Invoked) イベントを処理して、KeyboardAccelerator の既定の動作を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="0bb05-338">You can handle the [KeyboardAccelerator.Invoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardaccelerator.Invoked) event to override the default KeyboardAccelerator behavior.</span></span>

<span data-ttu-id="0bb05-339">次の例は、カスタムの ListView コントロールで "すべて選択" コマンド (キーボード アクセラレータは Ctrl + A) を上書きする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="0bb05-339">This example shows how to override the "Select all" command (Ctrl+A keyboard accelerator) in a custom ListView control.</span></span> <span data-ttu-id="0bb05-340">また、Handled プロパティを true に設定して、以降のイベント バブルを停止します。</span><span class="sxs-lookup"><span data-stu-id="0bb05-340">We also set the Handled property to true to stop the event bubbling further.</span></span>

```csharp
public class MyListView : ListView
{
  …
  protected override void OnKeyboardAcceleratorInvoked(KeyboardAcceleratorInvokedEventArgs args) 
  {
    if(args.Accelerator.Key == VirtualKey.A 
      && args.Accelerator.Modifiers == KeyboardModifiers.Control)
    {
      CustomSelectAll(TypeOfSelection.OnlyNumbers); 
      args.Handled = true;
    }
  }
  …
}
```

## <a name="related-articles"></a><span data-ttu-id="0bb05-341">関連記事</span><span class="sxs-lookup"><span data-stu-id="0bb05-341">Related articles</span></span>

* [<span data-ttu-id="0bb05-342">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="0bb05-342">Keyboard interactions</span></span>](keyboard-interactions.md)
* [<span data-ttu-id="0bb05-343">アクセス キー</span><span class="sxs-lookup"><span data-stu-id="0bb05-343">Access keys</span></span>](access-keys.md)

**<span data-ttu-id="0bb05-344">サンプル</span><span class="sxs-lookup"><span data-stu-id="0bb05-344">Samples</span></span>**
* [<span data-ttu-id="0bb05-345">XAML コントロール ギャラリー (別名 XamlUiBasics)</span><span class="sxs-lookup"><span data-stu-id="0bb05-345">XAML Controls Gallery (aka XamlUiBasics)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/c2aeaa588d9b134466bbd2cc387c8ff4018f151e/Samples/XamlUIBasics)


 
