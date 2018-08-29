---
author: Karl-Bridge-Microsoft
Description: Learn how to improve both the usability and the accessibility of your UWP app by providing an intuitive way for users to quickly navigate and interact with an app's visible UI through a keyboard instead of a pointer device (such as touch or mouse).
title: アクセス キーの設計ガイドライン
label: Access keys design guidelines
keywords: キーボード, アクセス キー, keytip, キーのヒント, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作
template: detail.hbs
ms.author: kbridge
ms.date: 06/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 8e842d6c5b8e62a9c043c97849fdf17f524ccfc7
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2907115"
---
# <a name="access-keys"></a><span data-ttu-id="c0b65-103">アクセス キー</span><span class="sxs-lookup"><span data-stu-id="c0b65-103">Access keys</span></span>

<span data-ttu-id="c0b65-104">アクセス キーは、ポインター デバイス (タッチやマウスなど) の代わりにキーボードを使って、アプリに表示される UI 間をすばやく移動したり、これらの UI を操作したりするための直感的な方法をユーザーに提供して、Windows アプリケーションの使いやすさとアクセシビリティを向上させるキーボード ショートカットです。</span><span class="sxs-lookup"><span data-stu-id="c0b65-104">Access keys are keyboard shortcuts that improve the usability and the accessibility of your Windows applications by providing an intuitive way for users to quickly navigate and interact with an app's visible UI through a keyboard instead of a pointer device (such as touch or mouse).</span></span>

<span data-ttu-id="c0b65-105">キーボード ショートカットを使って Windows アプリケーションの一般的な操作を呼び出す方法について詳しくは、「[アクセラレータ キー](keyboard-accelerators.md)」のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0b65-105">See the [Accelerator keys](keyboard-accelerators.md) topic for details on invoking common actions in a Windows application with keyboard shortcuts.</span></span> 

> [!NOTE]
> <span data-ttu-id="c0b65-106">キーボードは、特定の障碍を持つユーザーにとっては不可欠であり ([キーボードのアクセシビリティ](https://docs.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)をご覧ください)、アプリをより効率的に操作することを望むユーザーにとって重要なツールでもあります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-106">A keyboard is indispensable for users with certain disabilities (see [Keyboard accessibility](https://docs.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)), and is also an important tool for users who prefer it as a more efficient way to interact with an app.</span></span>

<span data-ttu-id="c0b65-107">ユニバーサル Windows プラットフォーム (UWP) には、キーボード ベースのアクセス キー、およびキーのヒントと呼ばれる視覚的な合図を利用した関連する UI フィードバックの両方について、さまざまなプラットフォーム コントロールに対応した組み込みのサポートが用意されています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-107">The Universal Windows Platform (UWP) provides built-in support across platform controls for both keyboard-based access keys and associated UI feedback through visual cues called Key Tips.</span></span>

## <a name="overview"></a><span data-ttu-id="c0b65-108">概要</span><span class="sxs-lookup"><span data-stu-id="c0b65-108">Overview</span></span>

<span data-ttu-id="c0b65-109">アクセス キーは、Alt キーと 1 つ以上の英数字キー (*ニーモニック*と呼ばれることがあります) の組み合わせであり、通常は同時に押すのではなく順番に押します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-109">An access key is a combination of the Alt key and one or more alphanumeric keys—sometimes called a *mnemonic*—typically pressed sequentially, rather than simultaneously.</span></span>

<span data-ttu-id="c0b65-110">キーのヒントは、ユーザーが Alt キーを押したときにアクセス キーをサポートするコントロールの横に表示されるバッジです。</span><span class="sxs-lookup"><span data-stu-id="c0b65-110">Key tips are badges displayed next to controls that support access keys when the user presses the Alt key.</span></span> <span data-ttu-id="c0b65-111">キーのヒントにはそれぞれ、関連するコントロールをアクティブ化する英数字キーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-111">Each Key Tip contains the alphanumeric keys that activate the associated control.</span></span>

> [!NOTE]
> <span data-ttu-id="c0b65-112">1 文字の英数字を使ったアクセス キーでは、キーボード ショートカットが自動的にサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-112">Keyboard shortcuts are automatically supported for access keys with a single alphanumeric character.</span></span> <span data-ttu-id="c0b65-113">たとえば、Word で Alt キーを押しながら F キーを押すと、キーのヒントが表示されずに [ファイル] メニューが開きます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-113">For example, simultaneously pressing Alt+F in Word opens the File menu without displaying Key Tips.</span></span>

<span data-ttu-id="c0b65-114">Alt キーを押すとアクセス キー機能が初期化され、現在利用可能なキーの組み合わせがすべてキーのヒントに表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-114">Pressing the Alt key initializes access key functionality and displays all currently available key combinations in Key Tips.</span></span> <span data-ttu-id="c0b65-115">後続のキー入力は、アクセス キー フレームワークによって処理されます。このフレームワークは、有効なアクセス キーが押されるか、、Enter、Esc、Tab、または方向キーを押してアクセス キーを非アクティブ化することでキー入力の処理がアプリに返されるまでは、無効なキーを拒否します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-115">Subsequent keystrokes are handled by the access key framework, which rejects invalid keys until either a valid access key is pressed, or the Enter, Esc, Tab, or Arrow keys are pressed to deactivate access keys and return keystroke handling to the app.</span></span>

<span data-ttu-id="c0b65-116">Microsoft Office アプリでは、アクセス キーが広範にサポートされています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-116">Microsoft Office apps provide extensive support for access keys.</span></span> <span data-ttu-id="c0b65-117">次の図は、アクセス キーがアクティブになった状態の Word の [ホーム] タブを示しています (数字と複数のキー入力の両方のサポートに注目してください)。</span><span class="sxs-lookup"><span data-stu-id="c0b65-117">The following image shows the Home tab of Word with access keys activated (note the support for both numbers and multiple keystrokes).</span></span>

![Microsoft Word におけるアクセス キーの KeyTip バッジ](images/accesskeys/keytip-badges-word.png)

_<span data-ttu-id="c0b65-119">Microsoft Word におけるアクセス キーの KeyTip バッジ</span><span class="sxs-lookup"><span data-stu-id="c0b65-119">KeyTip badges for access keys in Microsoft Word</span></span>_

<span data-ttu-id="c0b65-120">コントロールにアクセス キーを追加するには、**AccessKey プロパティ**を使います。</span><span class="sxs-lookup"><span data-stu-id="c0b65-120">To add an access key to a control, use the **AccessKey property**.</span></span> <span data-ttu-id="c0b65-121">このプロパティの値は、アクセス キーの順序、ショートカット (1 文字の英数字の場合)、キーのヒントを指定します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-121">The value of this property specifies the access key sequence, the shortcut (if a single alphanumeric), and the Key Tip.</span></span>

``` xaml
<Button Content="Accept" AccessKey="A" Click="AcceptButtonClick" />
```

## <a name="when-to-use-access-keys"></a><span data-ttu-id="c0b65-122">アクセス キーを使う場合</span><span class="sxs-lookup"><span data-stu-id="c0b65-122">When to use access keys</span></span>

<span data-ttu-id="c0b65-123">UI に適切な場合は必ずアクセス キーを指定し、すべてのカスタム コントロールでアクセス キーをサポートすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-123">We recommend that you specify access keys wherever appropriate in your UI, and support access keys in all custom controls.</span></span>

1.  <span data-ttu-id="c0b65-124">一度に 1 つのキーのみ押すことができるユーザーや、マウスを使うのが困難なユーザーなど、運動障碍を持つユーザーにとっては、**アクセス キーによりアプリのアクセシビリティが高まります**。</span><span class="sxs-lookup"><span data-stu-id="c0b65-124">**Access keys make your app more accessible** for users with motor disabilities, including those users who can press only one key at a time or have difficulty using a mouse.</span></span>

    <span data-ttu-id="c0b65-125">適切に設計されたキーボード UI はソフトウェアのアクセシビリティの重要な要素であり、</span><span class="sxs-lookup"><span data-stu-id="c0b65-125">A well-designed keyboard UI is an important aspect of software accessibility.</span></span> <span data-ttu-id="c0b65-126">視覚に障碍のあるユーザーや特定の運動障碍のあるユーザーによるアプリ内の移動や、その機能の操作を実現します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-126">It enables users with vision impairments or who have certain motor disabilities to navigate an app and interact with its features.</span></span> <span data-ttu-id="c0b65-127">このようなユーザーはマウスを操作できない場合があるため、代わりにさまざまな支援技術 (キーボード強化ツール、スクリーン キーボード、スクリーン拡大機能、スクリーン リーダー、音声入力ユーティリティなど) が不可欠になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-127">Such users might not be able to operate a mouse and instead rely on various assistive technologies such as keyboard enhancement tools, on-screen keyboards, screen enlargers, screen readers, and voice input utilities.</span></span> <span data-ttu-id="c0b65-128">このようなユーザーにとっては、コマンドを包括的にカバーすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="c0b65-128">For these users, comprehensive command coverage is crucial.</span></span>

2.  <span data-ttu-id="c0b65-129">キーボードを使った操作を好むパワー ユーザーにとっては、**アクセス キーによりアプリが使いやすくなります**。</span><span class="sxs-lookup"><span data-stu-id="c0b65-129">**Access keys make your app more usable** for power users who prefer to interact through the keyboard.</span></span>

    <span data-ttu-id="c0b65-130">多くの経験豊富なユーザーには、キーボードの使用の方がはるかに好まれます。キーボード ベースのコマンドであれば、すばやく入力することができ、キーボードから手を離す必要がないためです。</span><span class="sxs-lookup"><span data-stu-id="c0b65-130">Experienced users often have a strong preference for using the keyboard because keyboard-based commands can be entered more quickly and don't require them to remove their hands from the keyboard.</span></span> <span data-ttu-id="c0b65-131">このようなユーザーにとっては、効率性と一貫性が重要です。包括性が重要になるのは、特に頻繁に使用するコマンドに対してのみです。</span><span class="sxs-lookup"><span data-stu-id="c0b65-131">For these users, efficiency and consistency are crucial; comprehensiveness is important only for the most frequently used commands.</span></span>

## <a name="set-access-key-scope"></a><span data-ttu-id="c0b65-132">アクセス キーのスコープを設定する</span><span class="sxs-lookup"><span data-stu-id="c0b65-132">Set access key scope</span></span>

<span data-ttu-id="c0b65-133">アクセス キーをサポートする要素が画面上に多くある場合、**認知的負荷**を軽減するためにアクセス キーのスコープを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-133">When there are many elements on the screen that support access keys, we recommend scoping the access keys to reduce **cognitive load**.</span></span> <span data-ttu-id="c0b65-134">これにより、画面上のアクセス キーの数が最小限に抑えられるため、見つけやすくなり、効率性と生産性が向上します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-134">This minimizes the number of access keys on the screen, which makes them easier to locate, and improves efficiency and productivity.</span></span>

<span data-ttu-id="c0b65-135">たとえば、Microsoft Word には 2 つのアクセス キー スコープが用意されています。リボン タブ用のプライマリ スコープと、選択されたタブ上のコマンドのセカンダリ スコープです。</span><span class="sxs-lookup"><span data-stu-id="c0b65-135">For example, Microsoft Word provides two access key scopes: a primary scope for the Ribbon tabs and a secondary scope for commands on the selected tab.</span></span>

<span data-ttu-id="c0b65-136">次の図は、Word における 2 つのアクセス キー スコープを示しています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-136">The following images demonstrate the two access key scopes in Word.</span></span> <span data-ttu-id="c0b65-137">最初の図は、ユーザーがタブとその他の最上位レベルのコマンドを選択できるようにするプライマリ アクセス キーを示しています。2 つ目の図は、[ホーム] タブのセカンダリ アクセス キーを示しています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-137">The first shows the primary access keys that let a user select a tab and other top level commands, and the second shows the secondary access keys for the Home tab.</span></span>

![<span data-ttu-id="c0b65-138">Microsoft Word におけるプライマリ アクセス キー](images/accesskeys/primary-access-keys-word.png)
_Microsoft Word におけるプライマリ アクセス キー_</span><span class="sxs-lookup"><span data-stu-id="c0b65-138">Primary access keys in Microsoft Word](images/accesskeys/primary-access-keys-word.png)
_Primary access keys in Microsoft Word_</span></span>

![<span data-ttu-id="c0b65-139">Microsoft Word におけるセカンダリ アクセス キー](images/accesskeys/secondary-access-keys-word.png)
_Microsoft Word におけるセカンダリ アクセス キー_</span><span class="sxs-lookup"><span data-stu-id="c0b65-139">Secondary access keys in Microsoft Word](images/accesskeys/secondary-access-keys-word.png)
_Secondary access keys in Microsoft Word_</span></span>

<span data-ttu-id="c0b65-140">アクセス キーは、異なるスコープの要素用に複製することができます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-140">Access keys can be duplicated for elements in different scopes.</span></span> <span data-ttu-id="c0b65-141">前の例では、"2" はプライマリ スコープにおける [元に戻す] のアクセス キーであり、セカンダリ スコープにおける "斜体" のアクセス キーでもあります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-141">In the preceding example, “2” is the access key for Undo in the primary scope, and also “Italics” in the secondary scope.</span></span>

<span data-ttu-id="c0b65-142">アクセス キーのスコープを定義する方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-142">Here, we show how to define an access key scope.</span></span>

``` xaml
<CommandBar x:Name="MainCommandBar" AccessKey="M" >
    <AppBarButton AccessKey="G" Icon="Globe" Label="Go"/>
    <AppBarButton AccessKey="S" Icon="Stop" Label="Stop"/>
    <AppBarSeparator/>
    <AppBarButton AccessKey="R" Icon="Refresh" Label="Refresh" IsAccessKeyScope="True">
        <AppBarButton.Flyout>
            <MenuFlyout>
                <MenuFlyoutItem AccessKey="A" Icon="Globe" Text="Refresh A" />
                <MenuFlyoutItem AccessKey="B" Icon="Globe" Text="Refresh B" />
                <MenuFlyoutItem AccessKey="C" Icon="Globe" Text="Refresh C" />
                <MenuFlyoutItem AccessKey="D" Icon="Globe" Text="Refresh D" />
            </MenuFlyout>
        </AppBarButton.Flyout>
    </AppBarButton>
    <AppBarButton AccessKey="B" Icon="Back" Label="Back"/>
    <AppBarButton AccessKey="F" Icon="Forward" Label="Forward"/>
    <AppBarSeparator/>
    <AppBarToggleButton AccessKey="V" Icon="Favorite" Label="Favorite"/>
    <CommandBar.SecondaryCommands>
        <AppBarToggleButton Icon="Like" AccessKey="L" Label="Like"/>
        <AppBarButton Icon="Setting" AccessKey="T" Label="Settings" />
    </CommandBar.SecondaryCommands>
</CommandBar>
```

![CommandBar のプライマリ アクセス キー](images/accesskeys/primary-access-keys-commandbar.png)

_<span data-ttu-id="c0b65-144">CommandBar のプライマリ スコープとサポートされているアクセス キー</span><span class="sxs-lookup"><span data-stu-id="c0b65-144">CommandBar primary scope and supported access keys</span></span>_

![CommandBar のセカンダリ アクセス キー](images/accesskeys/secondary-access-keys-commandbar.png)

_<span data-ttu-id="c0b65-146">CommandBar のセカンダリ スコープとサポートされているアクセス キー</span><span class="sxs-lookup"><span data-stu-id="c0b65-146">CommandBar secondary scope and supported access keys</span></span>_

### <a name="windows-10-creators-update-and-older"></a><span data-ttu-id="c0b65-147">Windows 10 Creators Update 以降</span><span class="sxs-lookup"><span data-stu-id="c0b65-147">Windows 10 Creators Update and older</span></span>

<span data-ttu-id="c0b65-148">Windows 10 Fall Creators Update より前のバージョンでは、CommandBar などの一部のコントロールは、組み込みのアクセス キーのスコープをサポートしていませんでした。</span><span class="sxs-lookup"><span data-stu-id="c0b65-148">Prior to Windows 10 Fall Creators Update, some controls, such as the CommandBar, didn’t support built-in access key scopes.</span></span>

<span data-ttu-id="c0b65-149">次の例は、親コマンド (Word のリボンに似ています) が呼び出されると使用できるアクセス キー持つ CommandBar の SecondaryCommands をサポートする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-149">The following example shows how to support CommandBar SecondaryCommands with access keys, which are available once a parent command is invoked (similar to the Ribbon in Word).</span></span>

```xaml
<local:CommandBarHack x:Name="MainCommandBar" AccessKey="M" >
    <AppBarButton AccessKey="G" Icon="Globe" Label="Go"/>
    <AppBarButton AccessKey="S" Icon="Stop" Label="Stop"/>
    <AppBarSeparator/>
    <AppBarButton AccessKey="R" Icon="Refresh" Label="Refresh" IsAccessKeyScope="True">
        <AppBarButton.Flyout>
            <MenuFlyout>
                <MenuFlyoutItem AccessKey="A" Icon="Globe" Text="Refresh A" />
                <MenuFlyoutItem AccessKey="B" Icon="Globe" Text="Refresh B" />
                <MenuFlyoutItem AccessKey="C" Icon="Globe" Text="Refresh C" />
                <MenuFlyoutItem AccessKey="D" Icon="Globe" Text="Refresh D" />
            </MenuFlyout>
        </AppBarButton.Flyout>
    </AppBarButton>
    <AppBarButton AccessKey="B" Icon="Back" Label="Back"/>
    <AppBarButton AccessKey="F" Icon="Forward" Label="Forward"/>
    <AppBarSeparator/>
    <AppBarToggleButton AccessKey="V" Icon="Favorite" Label="Favorite"/>
    <CommandBar.SecondaryCommands>
        <AppBarToggleButton Icon="Like" AccessKey="L" Label="Like"/>
        <AppBarButton Icon="Setting" AccessKey="T" Label="Settings" />
    </CommandBar.SecondaryCommands>
</local:CommandBarHack>
```

```csharp
public class CommandBarHack : CommandBar
{
    CommandBarOverflowPresenter secondaryItemsControl;
    Popup overflowPopup;

    public CommandBarHack()
    {
        this.ExitDisplayModeOnAccessKeyInvoked = false;
        AccessKeyInvoked += OnAccessKeyInvoked;
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        Button moreButton = GetTemplateChild("MoreButton") as Button;
        moreButton.SetValue(Control.IsTemplateKeyTipTargetProperty, true);
        moreButton.IsAccessKeyScope = true;

        // SecondaryItemsControl changes
        secondaryItemsControl = GetTemplateChild("SecondaryItemsControl") as CommandBarOverflowPresenter;
        secondaryItemsControl.AccessKeyScopeOwner = moreButton;

        overflowPopup = GetTemplateChild("OverflowPopup") as Popup;
    }

    private void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
    {
        if (overflowPopup != null)
        {
            overflowPopup.Opened += SecondaryMenuOpened;
        }
    }

    private void SecondaryMenuOpened(object sender, object e)
    {
        //This is not neccesay given we are automatically pushing the scope.
        var item = secondaryItemsControl.Items.First();
        if (item != null && item is Control)
        {
            (item as Control).Focus(FocusState.Keyboard);
        }
        overflowPopup.Opened -= SecondaryMenuOpened;
    }
}
```

## <a name="avoid-access-key-collisions"></a><span data-ttu-id="c0b65-150">アクセス キーの競合を避ける</span><span class="sxs-lookup"><span data-stu-id="c0b65-150">Avoid access key collisions</span></span>

<span data-ttu-id="c0b65-151">アクセス キーの競合は、同じスコープ内の複数の要素が重複するアクセス キーを持っている場合や、同じ英数字で始まる場合に生じます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-151">Access key collisions occur when two or more elements in the same scope have duplicate access keys, or start with the same alphanumeric characters.</span></span>

<span data-ttu-id="c0b65-152">システムは、ビジュアル ツリーに追加された最初の要素のアクセス キーを処理し、他のアクセス キーをすべて無視することで、重複するアクセス キーを解決します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-152">The system resolves duplicate access keys by processing the access key of the first element added to the visual tree, ignoring all others.</span></span>

<span data-ttu-id="c0b65-153">複数のアクセス キーが同じ文字で始まる場合 (たとえば、"A"、"A1"、"AB")、システムは 1 文字のアクセス キーを処理し、他のすべてのアクセス キーを無視します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-153">When multiple access keys start with the same character (for example, “A”, “A1”, and “AB”), the system processes the single character access key and ignores all others.</span></span>

<span data-ttu-id="c0b65-154">競合を避けるには、一意のアクセス キーを使ったり、コマンドのスコープを設定したりします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-154">Avoid collisions by using unique access keys or by scoping commands.</span></span>

## <a name="choose-access-keys"></a><span data-ttu-id="c0b65-155">アクセス キーを選ぶ</span><span class="sxs-lookup"><span data-stu-id="c0b65-155">Choose access keys</span></span>

<span data-ttu-id="c0b65-156">アクセス キーを選ぶときは、以下の点を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="c0b65-156">Consider the following when choosing access keys:</span></span>

-   <span data-ttu-id="c0b65-157">単一の文字を使ってキー入力を最小限に抑え、ショートカット キーを既定でサポートする (Alt + アクセス キー)</span><span class="sxs-lookup"><span data-stu-id="c0b65-157">Use a single character to minimize keystrokes and support accelerator keys by default (Alt+AccessKey)</span></span>
-   <span data-ttu-id="c0b65-158">複数文字を使わない</span><span class="sxs-lookup"><span data-stu-id="c0b65-158">Avoid using more than two characters</span></span>
-   <span data-ttu-id="c0b65-159">アクセス キーの競合を避ける</span><span class="sxs-lookup"><span data-stu-id="c0b65-159">Avoid access keys collisions</span></span>
-   <span data-ttu-id="c0b65-160">アルファベットの "I" と数字の "1"、アルファベットの "O" と数字の "0" など、他の文字との判別が難しい文字を避ける</span><span class="sxs-lookup"><span data-stu-id="c0b65-160">Avoid characters that are difficult to differentiate from other characters, such as the letter “I” and the number “1” or the letter “O” and the number “0”</span></span>
-   <span data-ttu-id="c0b65-161">Word など、有名な他のアプリでよく使われているケースに倣う ("File" の "F"、"Home" の "H" など)</span><span class="sxs-lookup"><span data-stu-id="c0b65-161">Use well-known precedents from other popular apps such as Word (“F” for “File”, “H” for “Home”, and so on)</span></span>
-   <span data-ttu-id="c0b65-162">コマンド名の先頭の文字を使ったり、思い出しやすいようにコマンドとの関連性が高い文字を使ったりする</span><span class="sxs-lookup"><span data-stu-id="c0b65-162">Use the first character of the command name, or a character with a close association to the command that helps with recall</span></span>
    -   <span data-ttu-id="c0b65-163">先頭の文字が既に割り当てられている場合、コマンド名の先頭の文字にできるだけ近い文字を使う ("Insert" の "N" など)</span><span class="sxs-lookup"><span data-stu-id="c0b65-163">If the first letter is already assigned, use a letter that is as close as possible to the first letter of the command name (“N” for Insert)</span></span>
    -   <span data-ttu-id="c0b65-164">コマンド名の特徴的な死因を使う ("View" の "W")</span><span class="sxs-lookup"><span data-stu-id="c0b65-164">Use a distinctive consonant from the command name (“W” for View)</span></span>
    -   <span data-ttu-id="c0b65-165">コマンド名の母音を使う</span><span class="sxs-lookup"><span data-stu-id="c0b65-165">Use a vowel from the command name.</span></span>

## <a name="localize-access-keys"></a><span data-ttu-id="c0b65-166">アクセス キーをローカライズする</span><span class="sxs-lookup"><span data-stu-id="c0b65-166">Localize access keys</span></span>

<span data-ttu-id="c0b65-167">アプリが複数の言語にローカライズされる場合、**アクセス キーのローカライズも検討**してください。</span><span class="sxs-lookup"><span data-stu-id="c0b65-167">If your app is going to be localized in multiple languages, you should also **consider localizing the access keys**.</span></span> <span data-ttu-id="c0b65-168">たとえば、英語 (en-US) における "Home" の "H" とスペイン語 (es-ES) における "Incio" の "I" などです。</span><span class="sxs-lookup"><span data-stu-id="c0b65-168">For example, for “H” for “Home” in en-US and “I” for “Incio” in es-ES.</span></span>

<span data-ttu-id="c0b65-169">以下に示すように、マークアップで x:Uid 拡張を使って、ローカライズされたリソースを適用します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-169">Use the x:Uid extension in markup to apply localized resources as shown here:</span></span>

``` xaml
<Button Content="Home" AccessKey="H" x:Uid="HomeButton" />
```
<span data-ttu-id="c0b65-170">各言語のリソースは、プロジェクト内の対応する文字列フォルダーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-170">Resources for each language are added to corresponding String folders in the project:</span></span>

![英語およびスペイン語のリソース文字列フォルダー](images/accesskeys/resource-string-folders.png)

_<span data-ttu-id="c0b65-172">英語およびスペイン語のリソース文字列フォルダー</span><span class="sxs-lookup"><span data-stu-id="c0b65-172">English and Spanish resource string folders</span></span>_

<span data-ttu-id="c0b65-173">ローカライズされたアクセス キーは、プロジェクトの resources.resw ファイルで指定されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-173">Localized access keys are specified in your projects resources.resw file:</span></span>

![resources.resw ファイルで指定された AccessKey プロパティを指定する](images/accesskeys/resource-resw-file.png)

_<span data-ttu-id="c0b65-175">resources.resw ファイルで指定された AccessKey プロパティを指定する</span><span class="sxs-lookup"><span data-stu-id="c0b65-175">Specify the AccessKey property specified in the resources.resw file</span></span>_

<span data-ttu-id="c0b65-176">詳しくは、「[Translating UI resources](https://msdn.microsoft.com/library/windows/apps/xaml/Hh965329(v=win.10).aspx)」(UI リソースの翻訳) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c0b65-176">For more info, see [Translating UI resources ](https://msdn.microsoft.com/library/windows/apps/xaml/Hh965329(v=win.10).aspx)</span></span>

## <a name="key-tip-positioning"></a><span data-ttu-id="c0b65-177">キーのヒントを配置する</span><span class="sxs-lookup"><span data-stu-id="c0b65-177">Key Tip positioning</span></span>

<span data-ttu-id="c0b65-178">キーのヒントは、他の UI 要素、他のキーのヒント、画面の端の存在を考慮に入れて、対応する UI 要素を基準にフローティング バッジとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-178">Key tips are displayed as floating badges relative to their corresponding UI element, taking into account the presence of other UI elements, other Key Tips, and the screen edge.</span></span>

<span data-ttu-id="c0b65-179">通常、キーのヒントは既定の場所で十分であり、アダプティブ UI の組み込みサポートが提供されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-179">Typically, the default Key Tip location is sufficient and provides built-in support for adaptive UI.</span></span>

![キーのヒントの自動配置の例](images/accesskeys/auto-keytip-position.png)

_<span data-ttu-id="c0b65-181">キーのヒントの自動配置の例</span><span class="sxs-lookup"><span data-stu-id="c0b65-181">Example of automatic Key Tip placement</span></span>_

<span data-ttu-id="c0b65-182">ただし、キーのヒントの配置より細かく制御する必要がある場合、次のことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-182">However, should you need more control over Key Tip positioning, we recommend the following:</span></span>

1.  <span data-ttu-id="c0b65-183">**明白な関連付けの原則**: ユーザーが、コントロールをキーのヒントと簡単に関連付けることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-183">**Obvious association principle**: The user can associate the control with the Key Tip easily.</span></span>

    <span data-ttu-id="c0b65-184">a. </span><span class="sxs-lookup"><span data-stu-id="c0b65-184">a.</span></span>  <span data-ttu-id="c0b65-185">キーのヒントは、アクセス キーを持つ要素 (オーナー) の**近く**に配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-185">The Key Tip should be **close** to the element who have the access key (the owner).</span></span>  
    <span data-ttu-id="c0b65-186">b. </span><span class="sxs-lookup"><span data-stu-id="c0b65-186">b.</span></span>  <span data-ttu-id="c0b65-187">キーのヒントは、アクセス キーを持つ**有効な要素を覆わないようにする**必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-187">The Key Tip should **avoid covering enabled elements** that have access keys.</span></span>   
    <span data-ttu-id="c0b65-188">c. </span><span class="sxs-lookup"><span data-stu-id="c0b65-188">c.</span></span>  <span data-ttu-id="c0b65-189">キーのヒントをそのオーナーの近くに配置できない場合、オーナーと重ねる必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-189">If a Key Tip can’t be placed close to its owner, it should overlap the owner.</span></span> 

2.  <span data-ttu-id="c0b65-190">**見つけやすさ**: ユーザーが、キーのヒントによってコントロールをすばやく見つけることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-190">**Discoverability**: The user can discover the control with the Key Tip quickly.</span></span>

    <span data-ttu-id="c0b65-191">a. </span><span class="sxs-lookup"><span data-stu-id="c0b65-191">a.</span></span>  <span data-ttu-id="c0b65-192">キーのヒントが他のキーのヒントと**重なる**のを回避してください。</span><span class="sxs-lookup"><span data-stu-id="c0b65-192">The Key Tip never **overlaps** other Key Tips.</span></span>  

3.  <span data-ttu-id="c0b65-193">**読み取りやすい:** ユーザーがキーのヒントを簡単に読み取ることができるようにします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-193">**Easy scanning:** The user can skim the Key Tips easily.</span></span>

    <span data-ttu-id="c0b65-194">a. </span><span class="sxs-lookup"><span data-stu-id="c0b65-194">a.</span></span>  <span data-ttu-id="c0b65-195">キーのヒントは、ヒント相互および UI 要素に**揃えて**配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-195">Key Tips should be **aligned** with each other and with the UI Element.</span></span>
    <span data-ttu-id="c0b65-196">b. </span><span class="sxs-lookup"><span data-stu-id="c0b65-196">b.</span></span>  <span data-ttu-id="c0b65-197">キーのヒントはできる限り**グループ分け**する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-197">Key Tips should be **grouped** as much as possible.</span></span> 

### <a name="relative-position"></a><span data-ttu-id="c0b65-198">相対的な配置</span><span class="sxs-lookup"><span data-stu-id="c0b65-198">Relative position</span></span>

<span data-ttu-id="c0b65-199">要素またはグループごとにキーのヒントの配置をカスタマイズするには、**KeyTipPlacementMode** プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="c0b65-199">Use the **KeyTipPlacementMode** property to customize the placement of the Key Tip on a per element or per group basis.</span></span>

<span data-ttu-id="c0b65-200">配置モードは、Top、Bottom、Right、Left、Hidden、Center、Auto です。</span><span class="sxs-lookup"><span data-stu-id="c0b65-200">The placement modes are: Top, Bottom, Right, Left, Hidden, Center, and Auto.</span></span>

![キーのヒントの配置モード](images/accesskeys/keytip-postion-modes.png)

_<span data-ttu-id="c0b65-202">キーのヒントの配置モード</span><span class="sxs-lookup"><span data-stu-id="c0b65-202">Key tip placement modes</span></span>_

<span data-ttu-id="c0b65-203">コントロールの中心線は、キーのヒントの垂直方向および水平方向の配置の計算に使われます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-203">The center line of the control is used to calculate the vertical and horizontal alignment of the Key Tip.</span></span>

<span data-ttu-id="c0b65-204">次の例は、StackPanel コンテナーの KeyTipPlacementMode プロパティを使って、コントロールのグループに関するキーのヒントの配置を設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-204">They following example shows how to set the Key Tip placement of a group of controls using the KeyTipPlacementMode property of a StackPanel container.</span></span>

``` xaml
<StackPanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" KeyTipPlacementMode="Top">
  <Button Content="File" AccessKey="F" />
  <Button Content="Home" AccessKey="H" />
  <Button Content="Insert" AccessKey="N" />
</StackPanel>
```

### <a name="offsets"></a><span data-ttu-id="c0b65-205">オフセット</span><span class="sxs-lookup"><span data-stu-id="c0b65-205">Offsets</span></span>

<span data-ttu-id="c0b65-206">キーのヒントの場所をさらに細かく制御するには、要素の KeyTipHorizontalOffset プロパティと KeyTipVerticalOffset プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="c0b65-206">Use the KeyTipHorizontalOffset and KeyTipVerticalOffset properties of an element for even more granular control of the Key Tip location.</span></span>

> [!NOTE]
> <span data-ttu-id="c0b65-207">KeyTipPlacementMode が Auto に設定されているときは、オフセットを設定できません。</span><span class="sxs-lookup"><span data-stu-id="c0b65-207">Offsets cannot be set when KeyTipPlacementMode is set to Auto.</span></span>

<span data-ttu-id="c0b65-208">KeyTipHorizontalOffset プロパティは、キーのヒントを左または右に移動する距離を指定します。</span><span class="sxs-lookup"><span data-stu-id="c0b65-208">The KeyTipHorizontalOffset property indicates how far to move the Key Tip left or right.</span></span> <span data-ttu-id="c0b65-209">次の例は、ボタンに対するキーのヒントのオフセットを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-209">example shows how to set the Key Tip offsets for a button.</span></span>

![キーのヒントの配置モード](images/accesskeys/keytip-offsets.png)

_<span data-ttu-id="c0b65-211">キーのヒントの垂直オフセットと水平オフセットを設定する</span><span class="sxs-lookup"><span data-stu-id="c0b65-211">Set vertical and horizontal offsets for a Key Tip</span></span>_

``` xaml
<Button
  Content="File"
  AccessKey="F"
  KeyTipPlacementMode="Bottom"
  KeyTipHorizontalOffset="20"
  KeyTipVerticalOffset="-8" />
```

### <a name="screen-edge-alignment-screen-edge-alignment-listparagraph"></a><span data-ttu-id="c0b65-212">画面の端の配置 {#screen-edge-alignment .ListParagraph}</span><span class="sxs-lookup"><span data-stu-id="c0b65-212">Screen edge alignment {#screen-edge-alignment .ListParagraph}</span></span>

<span data-ttu-id="c0b65-213">キーのヒントの場所は、キーのヒントが完全に表示されるように画面の端を基準にして自動的に調整されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-213">The location of a Key Tip is automatically adjusted based on the screen edge to ensure the Key Tip is fully visible.</span></span> <span data-ttu-id="c0b65-214">この場合、コントロールとキーのヒントの配置ポイントとの間にある距離が、水平オフセットと垂直オフセットに指定した値と異なることがあります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-214">When this occurs, the distance between the control and Key Tip alignment point might differ from the values specified for the horizontal and vertical offsets .</span></span>

![キーのヒントの配置モード](images/accesskeys/keytips-screen-edge.png)

_<span data-ttu-id="c0b65-216">画面の端によりキーのヒントの位置が自動的に変更される</span><span class="sxs-lookup"><span data-stu-id="c0b65-216">The screen edge causes the Key Tip to automatically reposition itself</span></span>_

## <a name="key-tip-style"></a><span data-ttu-id="c0b65-217">キーのヒントのスタイル</span><span class="sxs-lookup"><span data-stu-id="c0b65-217">Key Tip style</span></span>

<span data-ttu-id="c0b65-218">プラットフォームのテーマ用に組み込まれているキーのヒントのサポート (ハイ コントラストなど) を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c0b65-218">We recommend using the built-in Key Tip support for platform themes, including high contrast.</span></span>

<span data-ttu-id="c0b65-219">独自のキーのヒントのスタイルを指定する必要がある場合、KeyTipFontSize (フォント サイズ)、KeyTipFontFamily (フォント ファミリ)、KeyTipBackground (背景)、KeyTipForeground (前景)、KeyTipPadding (パディング)、KeyTipBorderBrush (境界線の色)、KeyTipBorderThemeThickness (境界線の太さ) などのアプリケーション リソースを使います。</span><span class="sxs-lookup"><span data-stu-id="c0b65-219">If you need to specify your own Key Tip styles, use application resources such as KeyTipFontSize (font size), KeyTipFontFamily (font family), KeyTipBackground (background), KeyTipForeground (foreground), KeyTipPadding (padding), KeyTipBorderBrush(Border color), and KeyTipBorderThemeThickness (border thickness).</span></span>

![キーのヒントの配置モード](images/accesskeys/keytip-customization.png)

_<span data-ttu-id="c0b65-221">キーのヒントのカスタマイズ オプション</span><span class="sxs-lookup"><span data-stu-id="c0b65-221">Key tip customization options</span></span>_

<span data-ttu-id="c0b65-222">この例は、これらのアプリケーション リソースを変更する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c0b65-222">This example demonstrates how to change these application resources:</span></span>

 ```xaml  
<Application.Resources>
  <SolidColorBrush Color="DarkGray" x:Key="MyBackgroundColor" />
  <SolidColorBrush Color="White" x:Key="MyForegroundColor" />
  <SolidColorBrush Color="Black" x:Key="MyBorderColor" />
  <StaticResource x:Key="KeyTipBackground" ResourceKey="MyBackgroundColor" />
  <StaticResource x:Key="KeyTipForeground" ResourceKey="MyForegroundColor" />
  <StaticResource x:Key="KeyTipBorderBrush" ResourceKey="MyBorderColor"/>
  <FontFamily x:Key="KeyTipFontFamily">Consolas</FontFamily>
  <x:Double x:Key="KeyTipContentThemeFontSize">18</x:Double>
  <Thickness x:Key="KeyTipBorderThemeThickness">2</Thickness>
  <Thickness x:Key="KeyTipThemePadding">4,4,4,4</Thickness>
</Application.Resources>
```

## <a name="access-keys-and-narrator"></a><span data-ttu-id="c0b65-223">アクセス キーとナレーター</span><span class="sxs-lookup"><span data-stu-id="c0b65-223">Access keys and Narrator</span></span>

<span data-ttu-id="c0b65-224">XAML フレームワークには、UI オートメーション クライアントがユーザー インターフェイス内の要素に関する情報を検出できるようにするオートメーション プロパティが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-224">The XAML framework exposes Automation Properties that enable UI Automation clients to discover information about elements in the user interface.</span></span>

<span data-ttu-id="c0b65-225">UIElement または TextElement コントロールで AccessKey プロパティを指定する場合、[AutomationProperties.AccessKey](https://msdn.microsoft.com/library/windows/apps/hh759763) プロパティを使ってこの値を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c0b65-225">If you specify the AccessKey property on a UIElement or TextElement control, you can use the [AutomationProperties.AccessKey](https://msdn.microsoft.com/library/windows/apps/hh759763) property to get this value.</span></span> <span data-ttu-id="c0b65-226">ナレーターなどのアクセシビリティ クライアントは、要素がフォーカスを取得するたびにこのプロパティの値を読み取ります。</span><span class="sxs-lookup"><span data-stu-id="c0b65-226">Accessibility clients, such as Narrator, read the value of this property each time an element gets focus.</span></span>

## <a name="related-articles"></a><span data-ttu-id="c0b65-227">関連記事</span><span class="sxs-lookup"><span data-stu-id="c0b65-227">Related articles</span></span>

* [<span data-ttu-id="c0b65-228">キーボード操作</span><span class="sxs-lookup"><span data-stu-id="c0b65-228">Keyboard interactions</span></span>](keyboard-interactions.md)
* [<span data-ttu-id="c0b65-229">キーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="c0b65-229">Keyboard accelerators</span></span>](keyboard-accelerators.md)

**<span data-ttu-id="c0b65-230">サンプル</span><span class="sxs-lookup"><span data-stu-id="c0b65-230">Samples</span></span>**
* [<span data-ttu-id="c0b65-231">XAML コントロール ギャラリー (別名 XamlUiBasics)</span><span class="sxs-lookup"><span data-stu-id="c0b65-231">XAML Controls Gallery (aka XamlUiBasics)</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/c2aeaa588d9b134466bbd2cc387c8ff4018f151e/Samples/XamlUIBasics)


