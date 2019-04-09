---
title: コマンドの実行でユニバーサル Windows プラットフォーム (UWP) アプリ
description: (ICommand インターフェイス) と共に XamlUICommand と StandardUICommand クラスを使用して、共有し、さまざまなデバイスに関係なく、種類のコントロールを使用している入力の種類のコマンドを管理する方法。
author: Karl-Bridge-Microsoft
ms.service: ''
ms.topic: overview
ms.date: 03/11/2019
ms.openlocfilehash: a85a101cd529bf487cbc97b93bb3905f28213c19
ms.sourcegitcommit: 99271798fe53d9768fc52b21366de05268cadcb0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/20/2019
ms.locfileid: "58221418"
---
# <a name="commanding-in-universal-windows-platform-uwp-apps-using-standarduicommand-xamluicommand-and-icommand"></a><span data-ttu-id="2510a-103">StandardUICommand、XamlUICommand、ICommand を使用してユニバーサル Windows プラットフォーム (UWP) アプリでコマンド処理</span><span class="sxs-lookup"><span data-stu-id="2510a-103">Commanding in Universal Windows Platform (UWP) apps using StandardUICommand, XamlUICommand, and ICommand</span></span>

<span data-ttu-id="2510a-104">このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリケーションでコマンド処理について説明します。</span><span class="sxs-lookup"><span data-stu-id="2510a-104">In this topic, we describe commanding in Universal Windows Platform (UWP) applications.</span></span> <span data-ttu-id="2510a-105">使用する方法について説明します具体的には、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)と[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)を共有し、コマンドの管理のさまざまなコントロールの種類に関係なく (ICommand インターフェイス) と共にクラス入力の種類とデバイスの使用されています。</span><span class="sxs-lookup"><span data-stu-id="2510a-105">Specifically, we discuss how you can use the [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) and [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) classes (along with the ICommand interface) to share and manage commands across various control types, regardless of the device and input type being used.</span></span>

![共有のコマンドの一般的な使用方法を表すダイアグラム: '任意' コマンドを使用して複数の UI が表示されます](images/commanding/generic-commanding.png)

<span data-ttu-id="2510a-107">*デバイスと、入力の種類に関係なく、さまざまなコントロール間で共有コマンド*</span><span class="sxs-lookup"><span data-stu-id="2510a-107">*Share commands across various controls, regardless of device and input type*</span></span>

## <a name="important-apis"></a><span data-ttu-id="2510a-108">重要な API</span><span class="sxs-lookup"><span data-stu-id="2510a-108">Important APIs</span></span>

- <span data-ttu-id="2510a-109">[Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)と[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-109">[Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) and [System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)</span></span>
- [<span data-ttu-id="2510a-110">XamlUICommand</span><span class="sxs-lookup"><span data-stu-id="2510a-110">XamlUICommand</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)
- [<span data-ttu-id="2510a-111">StandardUICommand</span><span class="sxs-lookup"><span data-stu-id="2510a-111">StandardUICommand</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)

## <a name="overview"></a><span data-ttu-id="2510a-112">概要</span><span class="sxs-lookup"><span data-stu-id="2510a-112">Overview</span></span>

<!-- See https://blogs.msdn.microsoft.com/jebarson/2017/07/26/writing-an-asynchronous-relaycommand-implementing-icommand/ -->

<!-- A command describes an action but not its implementation (in other words, the what, but not the how). For example, the "Paste" command indicates that the user wants to copy something from the clipboard to a target control, but does not specify how. -->

<span data-ttu-id="2510a-113">コマンドは、ボタンをクリックしてまたはコンテキスト メニューから項目を選択するような UI 操作を使用して直接呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="2510a-113">Commands can be invoked directly through UI interactions like clicking a button or selecting an item from a context menu.</span></span> <span data-ttu-id="2510a-114">呼び出すことができましていない直接をキーボード アクセラレータ、ジェスチャ、音声認識、または automation/ユーザー補助ツールなどの入力デバイス。</span><span class="sxs-lookup"><span data-stu-id="2510a-114">They can also be invoked indirectly through an input device such as a keyboard accelerator, gesture, speech recognition, or an automation/accessibility tool.</span></span> <span data-ttu-id="2510a-115">呼び出されると後のコマンドは、しで処理できるコントロール (エディット コントロールでテキスト ナビゲーション) ウィンドウ (ナビゲーション)、またはアプリケーションを (終了)。</span><span class="sxs-lookup"><span data-stu-id="2510a-115">Once invoked, the command can then be handled by a control (text navigation in an edit control), a window (back navigation), or the application (exit).</span></span>

<span data-ttu-id="2510a-116">コマンド テキストを削除するか、アクションを元に戻すなど、アプリ内で特定のコンテキストを操作できるまたはオーディオのミュートまたは明るさの調整などのコンテキスト フリーになることができます。</span><span class="sxs-lookup"><span data-stu-id="2510a-116">Commands can operate on a specific context within your app, such as deleting text or undoing an action, or they can be context-free, such as muting audio or adjusting brightness.</span></span>

<span data-ttu-id="2510a-117">次の図は 2 つのコマンド インターフェイス (、 [CommandBar](app-bars.md)浮動コンテキストと[CommandBarFlyout](command-bar-flyout.md)) と同じコマンドの多くを共有します。</span><span class="sxs-lookup"><span data-stu-id="2510a-117">The following image shows two command interfaces (a [CommandBar](app-bars.md) and a floating contextual [CommandBarFlyout](command-bar-flyout.md)) that share many of the same commands.</span></span>

![コマンド インターフェイスの例](images/commanding/command-interface-example.png)

## <a name="command-interactions"></a><span data-ttu-id="2510a-119">コマンドの相互作用</span><span class="sxs-lookup"><span data-stu-id="2510a-119">Command interactions</span></span>

<span data-ttu-id="2510a-120">により、さまざまなデバイス、入力の種類、およびコマンドの呼び出し方法に影響を与える UI の外観、できるだけ多くのコマンド実行画面から、コマンドを公開することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2510a-120">Due to the variety of devices, input types, and UI surfaces that can affect how a command is invoked, we recommend exposing your commands through as many commanding surfaces as possible.</span></span> <span data-ttu-id="2510a-121">これらの組み合わせを含めることができます[スワイプ](swipe.md)、 [MenuBar](menus.md)、 [CommandBar](app-bars.md)、 [CommandBarFlyout](command-bar-flyout.md)、従来と[コンテキスト メニュー](menus.md)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-121">These can include a combination of [Swipe](swipe.md), [MenuBar](menus.md), [CommandBar](app-bars.md), [CommandBarFlyout](command-bar-flyout.md), and traditional [context menu](menus.md).</span></span>

<span data-ttu-id="2510a-122">**重要なコマンドは、入力に固有のアクセラレータを使用します。**</span><span class="sxs-lookup"><span data-stu-id="2510a-122">**For critical commands, use input-specific accelerators.**</span></span> <span data-ttu-id="2510a-123">入力のアクセラレータを使用している入力デバイスに応じてすばやく操作を実行することができます。</span><span class="sxs-lookup"><span data-stu-id="2510a-123">Input accelerators let a user perform actions more quickly depending on the input device they're using.</span></span>

<span data-ttu-id="2510a-124">いくつかの一般的な入力アクセラレータのさまざまな入力の種類を次に示します。</span><span class="sxs-lookup"><span data-stu-id="2510a-124">Here are some common input accelerators for various input types:</span></span>

- <span data-ttu-id="2510a-125">**ポインター** -マウス (& p) ボタンをホバー</span><span class="sxs-lookup"><span data-stu-id="2510a-125">**Pointer** - Mouse & Pen hover buttons</span></span>
- <span data-ttu-id="2510a-126">**キーボード**-ショートカット (アクセス キーとアクセラレータ キー)</span><span class="sxs-lookup"><span data-stu-id="2510a-126">**Keyboard** - Shortcuts (access keys and accelerator keys)</span></span>
- <span data-ttu-id="2510a-127">**タッチ**-スワイプ</span><span class="sxs-lookup"><span data-stu-id="2510a-127">**Touch** - Swipe</span></span>
- <span data-ttu-id="2510a-128">**タッチ**-データを更新するプル</span><span class="sxs-lookup"><span data-stu-id="2510a-128">**Touch** - Pull to refresh data</span></span>

<span data-ttu-id="2510a-129">アプリケーションの機能を普遍的にアクセスできるようにする入力タイプとユーザー エクスペリエンスを検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2510a-129">You must consider the input type and user experiences to make your application's functionality universally accessible.</span></span> <span data-ttu-id="2510a-130">たとえば、コレクション (特にユーザー編集可能なもの) には通常、さまざまな入力デバイスによって大きく異なる実行される特定のコマンドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="2510a-130">For example, collections (especially user editable ones) typically include a variety of specific commands that are performed quite differently depending on the input device.</span></span>

<span data-ttu-id="2510a-131">次の表は、いくつかの一般的なコレクション コマンドとこれらのコマンドを公開する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="2510a-131">The following table shows some typical collection commands and ways to expose those commands.</span></span>

| <span data-ttu-id="2510a-132">コマンド</span><span class="sxs-lookup"><span data-stu-id="2510a-132">Command</span></span>          | <span data-ttu-id="2510a-133">入力方法を問わない</span><span class="sxs-lookup"><span data-stu-id="2510a-133">Input-agnostic</span></span> | <span data-ttu-id="2510a-134">マウス アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="2510a-134">Mouse accelerator</span></span> | <span data-ttu-id="2510a-135">キーボード アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="2510a-135">Keyboard accelerator</span></span> | <span data-ttu-id="2510a-136">タッチ アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="2510a-136">Touch accelerator</span></span> |
| ---------------- | -------------- | ----------------- | -------------------- | ----------------- |
| <span data-ttu-id="2510a-137">項目の削除</span><span class="sxs-lookup"><span data-stu-id="2510a-137">Delete item</span></span>      | <span data-ttu-id="2510a-138">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="2510a-138">Context menu</span></span>   | <span data-ttu-id="2510a-139">ホバー ボタン</span><span class="sxs-lookup"><span data-stu-id="2510a-139">Hover button</span></span>      | <span data-ttu-id="2510a-140">DEL キー</span><span class="sxs-lookup"><span data-stu-id="2510a-140">DEL key</span></span>              | <span data-ttu-id="2510a-141">スワイプして削除</span><span class="sxs-lookup"><span data-stu-id="2510a-141">Swipe to delete</span></span>   |
| <span data-ttu-id="2510a-142">フラグの設定</span><span class="sxs-lookup"><span data-stu-id="2510a-142">Flag item</span></span>        | <span data-ttu-id="2510a-143">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="2510a-143">Context menu</span></span>   | <span data-ttu-id="2510a-144">ホバー ボタン</span><span class="sxs-lookup"><span data-stu-id="2510a-144">Hover button</span></span>      | <span data-ttu-id="2510a-145">Ctrl + Shift + G</span><span class="sxs-lookup"><span data-stu-id="2510a-145">Ctrl+Shift+G</span></span>         | <span data-ttu-id="2510a-146">スワイプしてフラグを設定</span><span class="sxs-lookup"><span data-stu-id="2510a-146">Swipe to flag</span></span>     |
| <span data-ttu-id="2510a-147">データの更新</span><span class="sxs-lookup"><span data-stu-id="2510a-147">Refresh data</span></span>     | <span data-ttu-id="2510a-148">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="2510a-148">Context menu</span></span>   | <span data-ttu-id="2510a-149">なし</span><span class="sxs-lookup"><span data-stu-id="2510a-149">N/A</span></span>               | <span data-ttu-id="2510a-150">F5 キー</span><span class="sxs-lookup"><span data-stu-id="2510a-150">F5 key</span></span>               | <span data-ttu-id="2510a-151">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="2510a-151">Pull to refresh</span></span>   |
| <span data-ttu-id="2510a-152">お気に入りに追加</span><span class="sxs-lookup"><span data-stu-id="2510a-152">Favorite an item</span></span> | <span data-ttu-id="2510a-153">コンテキスト メニュー</span><span class="sxs-lookup"><span data-stu-id="2510a-153">Context menu</span></span>   | <span data-ttu-id="2510a-154">ホバー ボタン</span><span class="sxs-lookup"><span data-stu-id="2510a-154">Hover button</span></span>      | <span data-ttu-id="2510a-155">F、Ctrl + S</span><span class="sxs-lookup"><span data-stu-id="2510a-155">F, Ctrl+S</span></span>            | <span data-ttu-id="2510a-156">スワイプしてお気に入りに追加</span><span class="sxs-lookup"><span data-stu-id="2510a-156">Swipe to favorite</span></span> |

<span data-ttu-id="2510a-157">**コンテキスト メニューを常に提供**をお勧めの従来のコンテキスト メニューまたは CommandBarFlyout、関連するすべてのコンテキストに応じたコマンドを含むすべての種類の入力の両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="2510a-157">**Always provide a context menu** We recommend including all relevant contextual commands in a traditional context menu or CommandBarFlyout, as both are supported for all input types.</span></span> <span data-ttu-id="2510a-158">たとえば、コマンドが、ポインターのホバー イベント中にのみ公開されている場合、タッチ専用デバイスで使用できません。</span><span class="sxs-lookup"><span data-stu-id="2510a-158">For example, if a command is exposed only during a pointer hover event, it cannot be used on a touch-only device.</span></span>

## <a name="commands-in-uwp-applications"></a><span data-ttu-id="2510a-159">UWP アプリケーションでのコマンド</span><span class="sxs-lookup"><span data-stu-id="2510a-159">Commands in UWP applications</span></span>

<span data-ttu-id="2510a-160">共有および UWP アプリケーションでのコマンド実行のエクスペリエンスを管理できるいくつかの方法はあります。</span><span class="sxs-lookup"><span data-stu-id="2510a-160">There are a few ways you can share and manage commanding experiences in a UWP application.</span></span> <span data-ttu-id="2510a-161">(これはできない、UI の複雑さによっては、非常に効率的な) 分離コードでのクリックなどの標準的なやり取りのイベント ハンドラーを定義することができます。、標準的な対話のイベント リスナーをバインドするには、共有のハンドラーに、またはコントロールのバインドすることができます。コマンド ロジックを記述する ICommand 実装にコマンドのプロパティです。</span><span class="sxs-lookup"><span data-stu-id="2510a-161">You can define event handlers for standard interactions, such as Click, in code-behind (this can be quite inefficient, depending on the complexity of your UI), you can bind event listener for standard interactions to a shared handler, or you can bind the control's Command property to an ICommand implementation that describes the command logic.</span></span>

<span data-ttu-id="2510a-162">バインディングでは、このトピックで説明されている機能のコマンドを使用してお勧めを効率的かつ最小限のコードの重複は、コマンドのサーフェイスにわたって機能が豊富で包括的なユーザー エクスペリエンスを提供するに (標準的なイベント処理のため、個々 のイベントのトピックを参照してください)。</span><span class="sxs-lookup"><span data-stu-id="2510a-162">To provide rich and comprehensive user experiences across command surfaces efficiently and with minimal code duplication, we recommend using the command binding features described in this topic(for standard event handling, see the individual event topics).</span></span>

<span data-ttu-id="2510a-163">コマンドの共有リソースにコントロールをバインドする、自分で ICommand インターフェイスを実装できますまたはいずれかから、コマンドをビルドすることができます、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)基底クラスまたはそのいずれかで定義されているプラットフォームのコマンド、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)クラスを派生します。</span><span class="sxs-lookup"><span data-stu-id="2510a-163">To bind a control to a shared command resource, you can implement the ICommand interfaces yourself, or you can build your command from either the [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) base class or one of the platform commands defined by the [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) derived class.</span></span>

- <span data-ttu-id="2510a-164">ICommand インターフェイス ([Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)) を作成する完全にカスタマイズされたアプリ間で再利用可能なコマンドを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="2510a-164">The ICommand interface ([Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) or [System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)) lets you create fully customized, reusable commands across your app.</span></span>
- <span data-ttu-id="2510a-165">[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)もこの機能を提供しますが、一連のコマンドの動作、キーボード ショートカット (アクセス キーとアクセラレータ キー)、アイコン、ラベル、および説明などの組み込みコマンドのプロパティを公開することで開発を簡略化されます。</span><span class="sxs-lookup"><span data-stu-id="2510a-165">[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) also provides this capability but simplifies development by exposing a set of built-in command properties such as the command behavior, keyboard shortcuts (access key and accelerator key), icon, label, and description.</span></span>
- <span data-ttu-id="2510a-166">[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)から定義済みのプロパティを持つ標準プラットフォームのコマンドのセットを選択することで、さらを簡略化します。</span><span class="sxs-lookup"><span data-stu-id="2510a-166">[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) simplifies things further by letting you choose from a set of standard platform commands with predefined properties.</span></span>

> [!Important]
> <span data-ttu-id="2510a-167">コマンドのいずれかの実装は、UWP アプリケーションで、 [Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) (C++) または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand) (C#) に応じて、選択したインターフェイス言語フレームワーク。</span><span class="sxs-lookup"><span data-stu-id="2510a-167">In UWP applications, commands are implementations of either the [Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) (C++) or the [System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand) (C#) interface, depending on your chosen language framework.</span></span>

## <a name="command-experiences-using-the-standarduicommand-class"></a><span data-ttu-id="2510a-168">StandardUICommand クラスを使用してコマンドのエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="2510a-168">Command experiences using the StandardUICommand class</span></span>

<span data-ttu-id="2510a-169">派生した[XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) (から派生した[Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) c++ または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)のC#)、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)クラスは、アイコン、キーボード アクセス キー、および説明などの定義済みのプロパティを持つ標準プラットフォームのコマンドのセットを公開します。</span><span class="sxs-lookup"><span data-stu-id="2510a-169">Derived from [XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) (derived from [Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) for C++ or  [System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand) for C#), the [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) class exposes a set of standard platform commands with pre-defined properties such as icon, keyboard accelerator, and description.</span></span>

<span data-ttu-id="2510a-170">A [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)などの一般的なコマンドを定義する迅速かつ一貫した方法を提供します`Save`または`Delete`します。</span><span class="sxs-lookup"><span data-stu-id="2510a-170">A [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) provides a quick and consistent way to define common commands such as `Save` or `Delete`.</span></span> <span data-ttu-id="2510a-171">Execute と canExecute 関数を指定するだけです。</span><span class="sxs-lookup"><span data-stu-id="2510a-171">All you have to do is provide the execute and canExecute functions.</span></span>

### <a name="example"></a><span data-ttu-id="2510a-172">例</span><span class="sxs-lookup"><span data-stu-id="2510a-172">Example</span></span>

![StandardUICommand サンプル](images/commanding/StandardUICommandSampleOptimized.gif)

<span data-ttu-id="2510a-174">*StandardUICommandSample*</span><span class="sxs-lookup"><span data-stu-id="2510a-174">*StandardUICommandSample*</span></span>

| <span data-ttu-id="2510a-175">この例のコードをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2510a-175">Download the code for this example</span></span> |
| -------------------- |
| [<span data-ttu-id="2510a-176">UWP コマンド実行サンプル (StandardUICommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-176">UWP commanding sample (StandardUICommand)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-commanding-standarduicommand.zip) |

<span data-ttu-id="2510a-177">この例では、基本的なを強化する方法を説明します[ListView](listview-and-gridview.md)コマンドを使用して実装を項目の削除、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)入力の種類のさまざまなユーザー エクスペリエンスを最適化する際に、クラス使用して、 [MenuBar](menus.md)、[スワイプ](swipe.md)コントロール、ボタンのポイントと[コンテキスト メニュー](menus.md)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-177">In this example, we show how to enhance a basic [ListView](listview-and-gridview.md) with a Delete item command implemented through the [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) class, while optimizing the user experience for a variety of input types using a [MenuBar](menus.md), [Swipe](swipe.md) control, hover buttons, and [context menu](menus.md).</span></span>

> [!NOTE]
> <span data-ttu-id="2510a-178">このサンプルの一部である Microsoft.UI.Xaml.Controls NuGet パッケージが必要です、 [Microsoft Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-178">This sample requires the Microsoft.UI.Xaml.Controls NuGet package, a part of the [Microsoft Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="2510a-179">**Xaml:**</span><span class="sxs-lookup"><span data-stu-id="2510a-179">**Xaml:**</span></span>

<span data-ttu-id="2510a-180">UI を含むサンプル、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) 5 つの項目。</span><span class="sxs-lookup"><span data-stu-id="2510a-180">The sample UI includes a [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) of five items.</span></span> <span data-ttu-id="2510a-181">削除[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)にバインドされて、 [MenuBarItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubaritem)、 [SwipeItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.swipeitem)、 [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)、および[ContextFlyout メニュー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-181">The Delete [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) is bound to a [MenuBarItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubaritem), a [SwipeItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.swipeitem), an [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton), and [ContextFlyout menu](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout).</span></span>

``` xaml
<Page
    x:Class="StandardUICommandSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:StandardUICommandSample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:muxcontrols="using:Microsoft.UI.Xaml.Controls"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.Resources>
        <Style x:Key="HorizontalSwipe" 
               TargetType="ListViewItem" 
               BasedOn="{StaticResource ListViewItemRevealStyle}">
            <Setter Property="Height" Value="60"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            <Setter Property="VerticalContentAlignment" Value="Stretch"/>
            <Setter Property="BorderThickness" Value="0"/>
        </Style>
    </Page.Resources>

    <Grid Loaded="ControlExample_Loaded">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <StackPanel Grid.Row="0" 
                    Padding="10" 
                    BorderThickness="0,0,0,1" 
                    BorderBrush="LightBlue"
                    Background="AliceBlue">
            <TextBlock Style="{StaticResource HeaderTextBlockStyle}">
                StandardUICommand sample
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,10">
                This sample shows how to use the StandardUICommand class to 
                share a platform command and consistent user experiences 
                across various controls.
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,0">
                Specifically, we define a standard delete command and add it 
                to a variety of command surfaces, all of which share a common 
                icon, label, keyboard accelerator, and description.
            </TextBlock>
        </StackPanel>

        <muxcontrols:MenuBar Grid.Row="1" Padding="10">
            <muxcontrols:MenuBarItem Title="File">
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Edit">
                <MenuFlyoutItem x:Name="DeleteFlyoutItem"/>
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Help">
            </muxcontrols:MenuBarItem>
        </muxcontrols:MenuBar>

        <ListView x:Name="ListViewRight" Grid.Row="2" 
                  Loaded="ListView_Loaded" 
                  IsItemClickEnabled="True" 
                  SelectionMode="Single" 
                  SelectionChanged="ListView_SelectionChanged" 
                  ItemContainerStyle="{StaticResource HorizontalSwipe}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ListItemData">
                    <UserControl PointerEntered="ListViewSwipeContainer_PointerEntered" 
                                 PointerExited="ListViewSwipeContainer_PointerExited">
                        <UserControl.ContextFlyout>
                            <MenuFlyout>
                                <MenuFlyoutItem 
                                    Command="{x:Bind Command}" 
                                    CommandParameter="{x:Bind Text}" />
                            </MenuFlyout>
                        </UserControl.ContextFlyout>
                        <Grid AutomationProperties.Name="{x:Bind Text}">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="HoveringStates">
                                    <VisualState x:Name="HoverButtonsHidden" />
                                    <VisualState x:Name="HoverButtonsShown">
                                        <VisualState.Setters>
                                            <Setter Target="HoverButton.Visibility" 
                                                    Value="Visible" />
                                        </VisualState.Setters>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <SwipeControl x:Name="ListViewSwipeContainer" >
                                <SwipeControl.RightItems>
                                    <SwipeItems Mode="Execute">
                                        <SwipeItem x:Name="DeleteSwipeItem" 
                                                   Background="Red" 
                                                   Command="{x:Bind Command}" 
                                                   CommandParameter="{x:Bind Text}"/>
                                    </SwipeItems>
                                </SwipeControl.RightItems>
                                <Grid VerticalAlignment="Center">
                                    <TextBlock Text="{x:Bind Text}" 
                                               Margin="10" 
                                               FontSize="18" 
                                               HorizontalAlignment="Left" 
                                               VerticalAlignment="Center"/>
                                    <AppBarButton x:Name="HoverButton" 
                                                  IsTabStop="False" 
                                                  HorizontalAlignment="Right" 
                                                  Visibility="Collapsed" 
                                                  Command="{x:Bind Command}" 
                                                  CommandParameter="{x:Bind Text}"/>
                                </Grid>
                            </SwipeControl>
                        </Grid>
                    </UserControl>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Page>
```

<span data-ttu-id="2510a-182">**分離コード**</span><span class="sxs-lookup"><span data-stu-id="2510a-182">**Code-behind**</span></span>

1. <span data-ttu-id="2510a-183">最初に、定義、`ListItemData`それぞれの ListViewItem、ListView 内のテキスト文字列と ICommand を含むクラスです。</span><span class="sxs-lookup"><span data-stu-id="2510a-183">First, we define a `ListItemData` class that contains a text string and ICommand for each ListViewItem in our ListView.</span></span>

```csharp
public class ListItemData
{
    public String Text { get; set; }
    public ICommand Command { get; set; }
}
```

2. <span data-ttu-id="2510a-184">MainPage クラスでのコレクションを定義します。`ListItemData`オブジェクトに対する、 [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate)の、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) [ItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemtemplate)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-184">In the MainPage class, we define a collection of `ListItemData` objects for the [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate) of the [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) [ItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemtemplate).</span></span> <span data-ttu-id="2510a-185">5 つの項目の初期のコレクションを使用し、設定します (テキストと関連付けられた[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)削除) します。</span><span class="sxs-lookup"><span data-stu-id="2510a-185">We then populate it with an initial collection of five items (with text and associated [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) Delete).</span></span>

```csharp
/// <summary>
/// ListView item collection.
/// </summary>
ObservableCollection<ListItemData> collection = 
    new ObservableCollection<ListItemData>();

/// <summary>
/// Handler for the layout Grid control load event.
/// </summary>
/// <param name="sender">Source of the control loaded event</param>
/// <param name="e">Event args for the loaded event</param>
private void ControlExample_Loaded(object sender, RoutedEventArgs e)
{
    // Create the standard Delete command.
    var deleteCommand = new StandardUICommand(StandardUICommandKind.Delete);
    deleteCommand.ExecuteRequested += DeleteCommand_ExecuteRequested;

    DeleteFlyoutItem.Command = deleteCommand;

    for (var i = 0; i < 5; i++)
    {
        collection.Add(
            new ListItemData {
                Text = "List item " + i.ToString(),
                Command = deleteCommand });
    }
}

/// <summary>
/// Handler for the ListView control load event.
/// </summary>
/// <param name="sender">Source of the control loaded event</param>
/// <param name="e">Event args for the loaded event</param>
private void ListView_Loaded(object sender, RoutedEventArgs e)
{
    var listView = (ListView)sender;
    // Populate the ListView with the item collection.
    listView.ItemsSource = collection;
}
```

3. <span data-ttu-id="2510a-186">次に、項目の削除コマンドを実装して、ICommand ExecuteRequested ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="2510a-186">Next, we define the ICommand ExecuteRequested handler where we implement the item delete command.</span></span>

``` csharp
/// <summary>
/// Handler for the Delete command.
/// </summary>
/// <param name="sender">Source of the command event</param>
/// <param name="e">Event args for the command event</param>
private void DeleteCommand_ExecuteRequested(
    XamlUICommand sender, ExecuteRequestedEventArgs args)
{
    // If possible, remove specfied item from collection.
    if (args.Parameter != null)
    {
        foreach (var i in collection)
        {
            if (i.Text == (args.Parameter as string))
            {
                collection.Remove(i);
                return;
            }
        }
    }
    if (ListViewRight.SelectedIndex != -1)
    {
        collection.RemoveAt(ListViewRight.SelectedIndex);
    }
}
```

4. <span data-ttu-id="2510a-187">最後に、定義を含む、ListView のさまざまなイベントのハンドラー [PointerEntered](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered)、 [PointerExited](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited)、および[SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベント。</span><span class="sxs-lookup"><span data-stu-id="2510a-187">Finally, we define handlers for various ListView events, including [PointerEntered](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered), [PointerExited](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited), and [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged) events.</span></span> <span data-ttu-id="2510a-188">ポインターのイベント ハンドラーは、各項目の削除 ボタンを非表示に使用されます。</span><span class="sxs-lookup"><span data-stu-id="2510a-188">The pointer event handlers are used to show or hide the Delete button for each item.</span></span>

```csharp
/// <summary>
/// Handler for the ListView selection changed event.
/// </summary>
/// <param name="sender">Source of the selection changed event</param>
/// <param name="e">Event args for the selection changed event</param>
private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (ListViewRight.SelectedIndex != -1)
    {
        var item = collection[ListViewRight.SelectedIndex];
    }
}

/// <summary>
/// Handler for the pointer entered event.
/// Displays the delete item "hover" buttons.
/// </summary>
/// <param name="sender">Source of the pointer entered event</param>
/// <param name="e">Event args for the pointer entered event</param>
private void ListViewSwipeContainer_PointerEntered(
    object sender, PointerRoutedEventArgs e)
{
    if (e.Pointer.PointerDeviceType == 
        Windows.Devices.Input.PointerDeviceType.Mouse || 
        e.Pointer.PointerDeviceType == 
        Windows.Devices.Input.PointerDeviceType.Pen)
    {
        VisualStateManager.GoToState(
            sender as Control, "HoverButtonsShown", true);
    }
}

/// <summary>
/// Handler for the pointer exited event.
/// Hides the delete item "hover" buttons.
/// </summary>
/// <param name="sender">Source of the pointer exited event</param>
/// <param name="e">Event args for the pointer exited event</param>

private void ListViewSwipeContainer_PointerExited(
    object sender, PointerRoutedEventArgs e)
{
    VisualStateManager.GoToState(
        sender as Control, "HoverButtonsHidden", true);
}
```

## <a name="command-experiences-using-the-xamluicommand-class"></a><span data-ttu-id="2510a-189">XamlUICommand クラスを使用してコマンドのエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="2510a-189">Command experiences using the XamlUICommand class</span></span>

<span data-ttu-id="2510a-190">によって定義されていないコマンドを作成する必要があるかどうか、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)クラス、または希望コマンドの外観を細かく制御、 [XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)クラスから派生、 [ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)インターフェイス、さまざまな UI (アイコン、ラベル、説明、キーボード ショートカットなど) のプロパティ、メソッド、およびカスタム コマンドの動作と UI を簡単に定義のイベントを追加します。</span><span class="sxs-lookup"><span data-stu-id="2510a-190">If you need to create a command that isn't defined by the [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) class, or you'd like more control over the command appearance, the [XamlUiCommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) class derives from the [ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) interface, adding various UI properties (such as an icon, label, description, and keyboard shortcuts), methods, and events to quickly define the UI and behavior of a custom command.</span></span>

<span data-ttu-id="2510a-191">[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)コントロールのアイコンなど、バインドを通じて UI を指定することができますが、説明、ラベルし、個々 のプロパティを設定せずのキーボード ショートカット (アクセス キーおよびキーボード アクセラレータの両方)、します。</span><span class="sxs-lookup"><span data-stu-id="2510a-191">[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) lets you specify UI through the control binding, such as an icon, label, description, and keyboard shortcuts (both an access key and a keyboard accelerator), without setting the individual properties.</span></span>

### <a name="example"></a><span data-ttu-id="2510a-192">例</span><span class="sxs-lookup"><span data-stu-id="2510a-192">Example</span></span>

![XamlUICommand サンプル](images/commanding/XamlUICommandSampleOptimized.gif)

<span data-ttu-id="2510a-194">*XamlUICommandSample*</span><span class="sxs-lookup"><span data-stu-id="2510a-194">*XamlUICommandSample*</span></span>

| <span data-ttu-id="2510a-195">この例のコードをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2510a-195">Download the code for this example</span></span> |
| -------------------- |
| [<span data-ttu-id="2510a-196">UWP コマンド実行サンプル (XamlUICommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-196">UWP commanding sample (XamlUICommand)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-commanding-xamluicommand.zip) |

<span data-ttu-id="2510a-197">この例は、以前の削除機能を共有[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)などが表示されますが、どのように[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)クラスでは、独自のフォントのアイコンとカスタム削除コマンドを定義できますラベル、。キーボード アクセス キー、および説明します。</span><span class="sxs-lookup"><span data-stu-id="2510a-197">This example shares the Delete functionality of the previous [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) example, but shows how the [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) class lets you define a custom delete command with your own font icon, label, keyboard accelerator, and description.</span></span> <span data-ttu-id="2510a-198">ように、 [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)例では、基本的なを向上させ[ListView](listview-and-gridview.md)コマンドを使用して実装を項目の削除、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)を最適化しつつ、クラス、使用して入力の型のさまざまなユーザー エクスペリエンスを[MenuBar](menus.md)、[スワイプ](swipe.md)コントロール、ボタンのポイントと[コンテキスト メニュー](menus.md)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-198">Like the [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) example, we enhance a basic [ListView](listview-and-gridview.md) with a Delete item command implemented through the [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) class, while optimizing the user experience for a variety of input types using a [MenuBar](menus.md), [Swipe](swipe.md) control, hover buttons, and [context menu](menus.md).</span></span>

<span data-ttu-id="2510a-199">多くのプラットフォーム コントロールでは、実際には、前のセクションでは、この StandardUICommand 例と同様の XamlUICommand プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="2510a-199">Many platform controls use the XamlUICommand properties under the covers, just like our StandardUICommand example in the previous section.</span></span> 

> [!NOTE]
> <span data-ttu-id="2510a-200">このサンプルの一部である Microsoft.UI.Xaml.Controls NuGet パッケージが必要です、 [Microsoft Windows の UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-200">This sample requires the Microsoft.UI.Xaml.Controls NuGet package, a part of the [Microsoft Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="2510a-201">**Xaml:**</span><span class="sxs-lookup"><span data-stu-id="2510a-201">**Xaml:**</span></span>

<span data-ttu-id="2510a-202">UI を含むサンプル、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) 5 つの項目。</span><span class="sxs-lookup"><span data-stu-id="2510a-202">The sample UI includes a [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) of five items.</span></span> <span data-ttu-id="2510a-203">カスタム[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) Delete にバインドされて、 [MenuBarItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubaritem)、 [SwipeItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.swipeitem)、 [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton)、および[ContextFlyout メニュー](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-203">The custom [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) Delete is bound to a [MenuBarItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.menubaritem), a [SwipeItem](https://docs.microsoft.com/uwp/api/microsoft.ui.xaml.controls.swipeitem), an [AppBarButton](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.appbarbutton), and [ContextFlyout menu](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.contextflyout).</span></span>

``` xaml
<Page
    x:Class="XamlUICommand_Sample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:XamlUICommand_Sample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:muxcontrols="using:Microsoft.UI.Xaml.Controls"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.Resources>
        <XamlUICommand x:Name="CustomXamlUICommand" ExecuteRequested="DeleteCommand_ExecuteRequested" Description="Custom XamlUICommand" Label="Custom XamlUICommand">
            <XamlUICommand.IconSource>
                <FontIconSource FontFamily="Wingdings" Glyph="&#x4D;"/>
            </XamlUICommand.IconSource>
            <XamlUICommand.KeyboardAccelerators>
                <KeyboardAccelerator Key="D" Modifiers="Control"/>
            </XamlUICommand.KeyboardAccelerators>
        </XamlUICommand>

        <Style x:Key="HorizontalSwipe" 
               TargetType="ListViewItem" 
               BasedOn="{StaticResource ListViewItemRevealStyle}">
            <Setter Property="Height" Value="70"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            <Setter Property="VerticalContentAlignment" Value="Stretch"/>
            <Setter Property="BorderThickness" Value="0"/>
        </Style>
        
    </Page.Resources>

    <Grid Loaded="ControlExample_Loaded" Name="MainGrid">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        
        <StackPanel Grid.Row="0" 
                    Padding="10" 
                    BorderThickness="0,0,0,1" 
                    BorderBrush="LightBlue"
                    Background="AliceBlue">
            <TextBlock Style="{StaticResource HeaderTextBlockStyle}">
                XamlUICommand sample
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,10">
                This sample shows how to use the XamlUICommand class to 
                share a custom command with consistent user experiences 
                across various controls.
            </TextBlock>
            <TextBlock Style="{StaticResource SubtitleTextBlockStyle}" Margin="0,0,0,0">
                Specifically, we define a custom delete command and add it 
                to a variety of command surfaces, all of which share a common 
                icon, label, keyboard accelerator, and description.
            </TextBlock>
        </StackPanel>

        <muxcontrols:MenuBar Grid.Row="1">
            <muxcontrols:MenuBarItem Title="File">
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Edit">
                <MenuFlyoutItem x:Name="DeleteFlyoutItem" Command="{StaticResource CustomXamlUICommand}"/>
            </muxcontrols:MenuBarItem>
            <muxcontrols:MenuBarItem Title="Help">
            </muxcontrols:MenuBarItem>
        </muxcontrols:MenuBar>

        <ListView x:Name="ListViewRight" Grid.Row="2" 
                  Loaded="ListView_Loaded" 
                  IsItemClickEnabled="True"
                  SelectionMode="Single" 
                  SelectionChanged="ListView_SelectionChanged" 
                  ItemContainerStyle="{StaticResource HorizontalSwipe}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:ListItemData">
                    <UserControl PointerEntered="ListViewSwipeContainer_PointerEntered"
                                 PointerExited="ListViewSwipeContainer_PointerExited">
                        <UserControl.ContextFlyout>
                            <MenuFlyout>
                                <MenuFlyoutItem 
                                    Command="{x:Bind Command}" 
                                    CommandParameter="{x:Bind Text}" />
                            </MenuFlyout>
                        </UserControl.ContextFlyout>
                        <Grid AutomationProperties.Name="{x:Bind Text}">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="HoveringStates">
                                    <VisualState x:Name="HoverButtonsHidden" />
                                    <VisualState x:Name="HoverButtonsShown">
                                        <VisualState.Setters>
                                            <Setter Target="HoverButton.Visibility" 
                                                    Value="Visible" />
                                        </VisualState.Setters>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <SwipeControl x:Name="ListViewSwipeContainer">
                                <SwipeControl.RightItems>
                                    <SwipeItems Mode="Execute">
                                        <SwipeItem x:Name="DeleteSwipeItem"
                                                   Background="Red" 
                                                   Command="{x:Bind Command}" 
                                                   CommandParameter="{x:Bind Text}"/>
                                    </SwipeItems>
                                </SwipeControl.RightItems>
                                <Grid VerticalAlignment="Center">
                                    <TextBlock Text="{x:Bind Text}" 
                                               Margin="10" 
                                               FontSize="18" 
                                               HorizontalAlignment="Left"       
                                               VerticalAlignment="Center"/>
                                    <AppBarButton x:Name="HoverButton" 
                                                  IsTabStop="False" 
                                                  HorizontalAlignment="Right" 
                                                  Visibility="Collapsed" 
                                                  Command="{x:Bind Command}" 
                                                  CommandParameter="{x:Bind Text}"/>
                                </Grid>
                            </SwipeControl>
                        </Grid>
                    </UserControl>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Page>
```

<span data-ttu-id="2510a-204">**分離コード**</span><span class="sxs-lookup"><span data-stu-id="2510a-204">**Code-behind**</span></span>

1. <span data-ttu-id="2510a-205">最初に、定義、`ListItemData`それぞれの ListViewItem、ListView 内のテキスト文字列と ICommand を含むクラスです。</span><span class="sxs-lookup"><span data-stu-id="2510a-205">First, we define a `ListItemData` class that contains a text string and ICommand for each ListViewItem in our ListView.</span></span>

```csharp
public class ListItemData
{
    public String Text { get; set; }
    public ICommand Command { get; set; }
}
```

2. <span data-ttu-id="2510a-206">MainPage クラスでのコレクションを定義します。`ListItemData`オブジェクトに対する、 [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate)の、 [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) [ItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemtemplate)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-206">In the MainPage class, we define a collection of `ListItemData` objects for the [DataTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.datatemplate) of the [ListView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview) [ItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.itemscontrol.itemtemplate).</span></span> <span data-ttu-id="2510a-207">5 つの項目の初期のコレクションを使用し、設定します (テキストと関連付けられた[XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand))。</span><span class="sxs-lookup"><span data-stu-id="2510a-207">We then populate it with an initial collection of five items (with text and associated [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)).</span></span>

```csharp
ObservableCollection<ListItemData> collection = new ObservableCollection<ListItemData>();

private void ControlExample_Loaded(object sender, RoutedEventArgs e)
{
    for (var i = 0; i < 5; i++)
    {
        collection.Add(new ListItemData { Text = "List item " + i.ToString(), Command = CustomXamlUICommand });
    }
}

private void ListView_Loaded(object sender, RoutedEventArgs e)
{
    var listView = (ListView)sender;
    listView.ItemsSource = collection;
}
```

3. <span data-ttu-id="2510a-208">次に、項目の削除コマンドを実装して、ICommand ExecuteRequested ハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="2510a-208">Next, we define the ICommand ExecuteRequested handler where we implement the item delete command.</span></span>

``` csharp
private void DeleteCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
{
    if (args.Parameter != null)
    {
        foreach (var i in collection)
        {
            if (i.Text == (args.Parameter as string))
            {
                collection.Remove(i);
                return;
            }
        }
    }
    if (ListViewRight.SelectedIndex != -1)
    {
        collection.RemoveAt(ListViewRight.SelectedIndex);
    }
}
```

4. <span data-ttu-id="2510a-209">最後に、定義を含む、ListView のさまざまなイベントのハンドラー [PointerEntered](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered)、 [PointerExited](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited)、および[SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged)イベント。</span><span class="sxs-lookup"><span data-stu-id="2510a-209">Finally, we define handlers for various ListView events, including [PointerEntered](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerentered), [PointerExited](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement.pointerexited), and [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.primitives.selector.selectionchanged) events.</span></span> <span data-ttu-id="2510a-210">ポインターのイベント ハンドラーは、各項目の削除 ボタンを非表示に使用されます。</span><span class="sxs-lookup"><span data-stu-id="2510a-210">The pointer event handlers are used to show or hide the Delete button for each item.</span></span>

```csharp
private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (ListViewRight.SelectedIndex != -1)
    {
        var item = collection[ListViewRight.SelectedIndex];
    }
}

private void ListViewSwipeContainer_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen)
    {
        VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
    }
}

private void ListViewSwipeContainer_PointerExited(object sender, PointerRoutedEventArgs e)
{
    VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
}
```

## <a name="command-experiences-using-the-icommand-interface"></a><span data-ttu-id="2510a-211">ICommand インターフェイスを使用してコマンドのエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="2510a-211">Command experiences using the ICommand interface</span></span>

<span data-ttu-id="2510a-212">標準の UWP コントロール (ボタン、リスト、選択、予定表、予測のテキスト) は、多くの一般的なコマンド エクスペリエンスの基礎を提供します。</span><span class="sxs-lookup"><span data-stu-id="2510a-212">Standard UWP controls (button, list, selection, calendar, predictive text) provide the basis for many common command experiences.</span></span> <span data-ttu-id="2510a-213">コントロールの種類の完全な一覧を参照してください。[コントロールと UWP アプリのパターン](index.md)します。</span><span class="sxs-lookup"><span data-stu-id="2510a-213">For a complete list of control types, see [Controls and patterns for UWP apps](index.md).</span></span>

<span data-ttu-id="2510a-214">構造化されたコマンド実行エクスペリエンスをサポートする最も基本的な方法は、ICommand インターフェイスの実装を定義する ([Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) c++ または[System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand)のC#)。</span><span class="sxs-lookup"><span data-stu-id="2510a-214">The most basic way to support a structured commanding experience is to define an implementation of the ICommand interface ([Windows.UI.Xaml.Input.ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) for C++ or  [System.Windows.Input.ICommand](https://docs.microsoft.com/dotnet/api/system.windows.input.icommand) for C#).</span></span>  <span data-ttu-id="2510a-215">この ICommand インスタンスは、ボタンなどのコントロールにバインドできます。</span><span class="sxs-lookup"><span data-stu-id="2510a-215">This ICommand instance can then be bound to controls such as buttons.</span></span>

> [!NOTE]
> <span data-ttu-id="2510a-216">場合によっては、同じメソッドをクリック イベントと IsEnabled プロパティをプロパティにバインドするように効率的場合があります。</span><span class="sxs-lookup"><span data-stu-id="2510a-216">In some cases, it might be just as efficient to bind a method to the Click event and a property to the IsEnabled property.</span></span>

#### <a name="example"></a><span data-ttu-id="2510a-217">例</span><span class="sxs-lookup"><span data-stu-id="2510a-217">Example</span></span>

![コマンド インターフェイスの例](images/commanding/icommand.gif)

<span data-ttu-id="2510a-219">*ICommand の例*</span><span class="sxs-lookup"><span data-stu-id="2510a-219">*ICommand example*</span></span>

| <span data-ttu-id="2510a-220">この例のコードをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="2510a-220">Download the code for this example</span></span> |
| -------------------- |
| [<span data-ttu-id="2510a-221">UWP コマンド実行サンプル (ICommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-221">UWP commanding sample (ICommand)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-commanding-icommand.zip) |

<span data-ttu-id="2510a-222">この基本的な例では 1 つのコマンドを呼び出すボタンを使用する方法を示します をクリックして、キーボード アクセス キー、およびマウス ホイールを回転します。</span><span class="sxs-lookup"><span data-stu-id="2510a-222">In this basic example, we demonstrate how a single command can be invoked with a button click, a keyboard accelerator, and rotating a mouse wheel.</span></span>

<span data-ttu-id="2510a-223">使用して 2 つ[Listview](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview)左、右から項目を移動するため、5 つの項目とその他の空の場合は、2 つのボタンが、ListView から左側、右側の ListView に項目の移動のいずれかのいずれかに設定されます。</span><span class="sxs-lookup"><span data-stu-id="2510a-223">We use two [ListViews](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.listview), one populated with five items and the other empty, and two buttons, one for moving items from the ListView on the left to the ListView on the right, and the other for moving items from the right to the left.</span></span> <span data-ttu-id="2510a-224">各ボタンは、対応するコマンドにバインドされます (ViewModel.MoveRightCommand と ViewModel.MoveLeftCommand、それぞれ)、およびが有効になっているし、関連する ListView の項目数に基づいて自動的に無効になっています。</span><span class="sxs-lookup"><span data-stu-id="2510a-224">Each button is bound to a corresponding command (ViewModel.MoveRightCommand and ViewModel.MoveLeftCommand, respectively), and are enabled and disabled automatically based on the number of items in their associated ListView.</span></span>

<span data-ttu-id="2510a-225">**次の XAML コードは、この例の UI を定義します。**</span><span class="sxs-lookup"><span data-stu-id="2510a-225">**The following XAML code defines the UI for our example.**</span></span>

```xaml
<Page
    x:Class="UICommand1.View.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:vm="using:UICommand1.ViewModel"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Page.Resources>
        <vm:OpacityConverter x:Key="opaque" />
    </Page.Resources>

    <Grid Name="ItemGrid"
          Background="AliceBlue"
          PointerWheelChanged="Page_PointerWheelChanged">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="2*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <ListView Grid.Column="0" VerticalAlignment="Center"
                  x:Name="CommandListView" 
                  ItemsSource="{x:Bind Path=ViewModel.ListItemLeft}" 
                  SelectionMode="None" IsItemClickEnabled="False" 
                  HorizontalAlignment="Right">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="vm:ListItemData">
                    <Grid VerticalAlignment="Center">
                        <AppBarButton Label="{x:Bind ListItemText}">
                            <AppBarButton.Icon>
                                <SymbolIcon Symbol="{x:Bind ListItemIcon}"/>
                            </AppBarButton.Icon>
                        </AppBarButton>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Grid Grid.Column="1" Margin="0,0,0,0"
              HorizontalAlignment="Center" 
              VerticalAlignment="Center">
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <StackPanel Grid.Row="1">
                <FontIcon FontFamily="{StaticResource SymbolThemeFontFamily}" 
                          FontSize="40" Glyph="&#xE893;" 
                          Opacity="{x:Bind Path=ViewModel.ListItemLeft.Count, 
                                        Mode=OneWay, Converter={StaticResource opaque}}"/>
                <Button Name="MoveItemRightButton"
                        Margin="0,10,0,10" Width="120" HorizontalAlignment="Center"
                        Command="{x:Bind Path=ViewModel.MoveRightCommand}">
                    <Button.KeyboardAccelerators>
                        <KeyboardAccelerator 
                            Modifiers="Control" 
                            Key="Add" />
                    </Button.KeyboardAccelerators>
                    <StackPanel>
                        <SymbolIcon Symbol="Next"/>
                        <TextBlock>Move item right</TextBlock>
                    </StackPanel>
                </Button>
                <Button Name="MoveItemLeftButton" 
                            Margin="0,10,0,10" Width="120" HorizontalAlignment="Center"
                            Command="{x:Bind Path=ViewModel.MoveLeftCommand}">
                    <Button.KeyboardAccelerators>
                        <KeyboardAccelerator 
                            Modifiers="Control" 
                            Key="Subtract" />
                    </Button.KeyboardAccelerators>
                    <StackPanel>
                        <SymbolIcon Symbol="Previous"/>
                        <TextBlock>Move item left</TextBlock>
                    </StackPanel>
                </Button>
                <FontIcon FontFamily="{StaticResource SymbolThemeFontFamily}" 
                          FontSize="40" Glyph="&#xE892;"
                          Opacity="{x:Bind Path=ViewModel.ListItemRight.Count, 
                                        Mode=OneWay, Converter={StaticResource opaque}}"/>
            </StackPanel>
        </Grid>
        <ListView Grid.Column="2" 
                  x:Name="CommandListViewRight" 
                  VerticalAlignment="Center" 
                  IsItemClickEnabled="False" 
                  SelectionMode="None"
                  ItemsSource="{x:Bind Path=ViewModel.ListItemRight}" 
                  HorizontalAlignment="Left">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="vm:ListItemData">
                    <Grid VerticalAlignment="Center">
                        <AppBarButton Label="{x:Bind ListItemText}">
                            <AppBarButton.Icon>
                                <SymbolIcon Symbol="{x:Bind ListItemIcon}"/>
                            </AppBarButton.Icon>
                        </AppBarButton>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Page>
```

<span data-ttu-id="2510a-226">**上記の UI の分離コードを次に示します。**</span><span class="sxs-lookup"><span data-stu-id="2510a-226">**Here's the code-behind for the preceding UI.**</span></span>

<span data-ttu-id="2510a-227">分離コードでは、このコマンド コードを含むビュー モデルに接続します。</span><span class="sxs-lookup"><span data-stu-id="2510a-227">In code-behind, we connect to our view model that contains our command code.</span></span> <span data-ttu-id="2510a-228">さらに、マウスのホイール コマンド コードにも接続からの入力のハンドラーを定義します。</span><span class="sxs-lookup"><span data-stu-id="2510a-228">In addition, we define a handler for input from the mouse wheel, which also connects our command code.</span></span>

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
using UICommand1.ViewModel;
using Windows.System;
using Windows.UI.Core;

namespace UICommand1.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Reference to our view model.
        public UICommand1ViewModel ViewModel { get; set; }

        // Initialize our view and view model.
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new UICommand1ViewModel();
        }

        /// <summary>
        /// Handle mouse wheel input and assign our
        /// commands to appropriate direction of rotation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            var props = e.GetCurrentPoint(sender as UIElement).Properties;

            // Require CTRL key and accept only vertical mouse wheel movement 
            // to eliminate accidental wheel input.
            if ((Window.Current.CoreWindow.GetKeyState(VirtualKey.Control) != 
                CoreVirtualKeyStates.None) && !props.IsHorizontalMouseWheel)
            {
                bool delta = props.MouseWheelDelta < 0 ? true : false;

                switch (delta)
                {
                    case true:
                        ViewModel.MoveRight();
                        break;
                    case false:
                        ViewModel.MoveLeft();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
```

<span data-ttu-id="2510a-229">**このビュー モデルからコードに示します。**</span><span class="sxs-lookup"><span data-stu-id="2510a-229">**Here's the code from our view model**</span></span>

<span data-ttu-id="2510a-230">このビュー モデルでは、アプリで 2 つのコマンドの実行の詳細を定義、1 つの ListView を設定したり表示または非表示の各 ListView の項目数に基づくいくつか追加の UI の不透明度の値コンバーターを提供します。</span><span class="sxs-lookup"><span data-stu-id="2510a-230">Our view model is where we define the execution details for the two commands in our app, populate one ListView, and provide an opacity value converter for hiding or displaying some additional UI based on the item count of each ListView.</span></span>

```csharp
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace UICommand1.ViewModel
{
    /// <summary>
    /// UI properties for our list items.
    /// </summary>
    public class ListItemData
    {
        /// <summary>
        /// Gets and sets the list item content string.
        /// </summary>
        public string ListItemText { get; set; }
        /// <summary>
        /// Gets and sets the list item icon.
        /// </summary>
        public Symbol ListItemIcon { get; set; }
    }

    /// <summary>
    /// View Model that sets up a command to handle invoking the move item buttons.
    /// </summary>
    public class UICommand1ViewModel
    {
        /// <summary>
        /// The command to invoke when the Move item left button is pressed.
        /// </summary>
        public RelayCommand MoveLeftCommand { get; private set; }

        /// <summary>
        /// The command to invoke when the Move item right button is pressed.
        /// </summary>
        public RelayCommand MoveRightCommand { get; private set; }

        // Item collections
        public ObservableCollection<ListItemData> ListItemLeft { get; } = new ObservableCollection<ListItemData>();
        public ObservableCollection<ListItemData> ListItemRight { get; } = new ObservableCollection<ListItemData>();

        public ListItemData listItem;

        /// <summary>
        /// Sets up a command to handle invoking the move item buttons.
        /// </summary>
        public UICommand1ViewModel()
        {
            MoveLeftCommand = new RelayCommand(new Action(MoveLeft), CanExecuteMoveLeftCommand);
            MoveRightCommand = new RelayCommand(new Action(MoveRight), CanExecuteMoveRightCommand);

            LoadItems();
        }

        /// <summary>
        ///  Populate our list of items.
        /// </summary>
        public void LoadItems()
        {
            for (var x = 0; x <= 4; x++)
            {
                listItem = new ListItemData();
                listItem.ListItemText = "Item " + (ListItemLeft.Count + 1).ToString();
                listItem.ListItemIcon = Symbol.Emoji;
                ListItemLeft.Add(listItem);
            }
        }

        /// <summary>
        /// Move left command valid when items present in the list on right.
        /// </summary>
        /// <returns>True, if count is greater than 0.</returns>
        private bool CanExecuteMoveLeftCommand()
        {
            return ListItemRight.Count > 0;
        }

        /// <summary>
        /// Move right command valid when items present in the list on left.
        /// </summary>
        /// <returns>True, if count is greater than 0.</returns>
        private bool CanExecuteMoveRightCommand()
        {
            return ListItemLeft.Count > 0;
        }

        /// <summary>
        /// The command implementation to execute when the Move item right button is pressed.
        /// </summary>
        public void MoveRight()
        {
            if (ListItemLeft.Count > 0)
            {
                listItem = new ListItemData();
                ListItemRight.Add(listItem);
                listItem.ListItemText = "Item " + ListItemRight.Count.ToString();
                listItem.ListItemIcon = Symbol.Emoji;
                ListItemLeft.RemoveAt(ListItemLeft.Count - 1);
                MoveRightCommand.RaiseCanExecuteChanged();
                MoveLeftCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// The command implementation to execute when the Move item left button is pressed.
        /// </summary>
        public void MoveLeft()
        {
            if (ListItemRight.Count > 0)
            {
                listItem = new ListItemData();
                ListItemLeft.Add(listItem);
                listItem.ListItemText = "Item " + ListItemLeft.Count.ToString();
                listItem.ListItemIcon = Symbol.Emoji;
                ListItemRight.RemoveAt(ListItemRight.Count - 1);
                MoveRightCommand.RaiseCanExecuteChanged();
                MoveLeftCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Views subscribe to this event to get notified of property updates.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify subscribers of updates to the named property
        /// </summary>
        /// <param name="propertyName">The full, case-sensitive, name of a property.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                handler(this, args);
            }
        }
    }

    /// <summary>
    /// Convert a collection count to an opacity value of 0.0 or 1.0.
    /// </summary>
    public class OpacityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a collection count to an opacity value of 0.0 or 1.0.
        /// </summary>
        /// <param name="value">The count passed in</param>
        /// <param name="targetType">Ignored.</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="language">Ignored</param>
        /// <returns>1.0 if count > 0, otherwise returns 0.0</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((int)value > 0 ? 1.0 : 0.0);
        }

        /// <summary>
        /// Not used, converter is not intended for two-way binding. 
        /// </summary>
        /// <param name="value">Ignored</param>
        /// <param name="targetType">Ignored</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="language">Ignored</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
```

<span data-ttu-id="2510a-231">**最後に、ICommand インターフェイスの実装を示します**</span><span class="sxs-lookup"><span data-stu-id="2510a-231">**Finally, here's our implementation of the ICommand interface**</span></span>

<span data-ttu-id="2510a-232">ここでは、実装するコマンドを定義、 [ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand)インターフェイスし、その他のオブジェクトにその機能を単純に中継します。</span><span class="sxs-lookup"><span data-stu-id="2510a-232">Here, we define a command that implements the [ICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.icommand) interface and simply relays its functionality to other objects.</span></span>

```csharp
using System;
using System.Windows.Input;

namespace UICommand1
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality 
    /// to other objects by invoking delegates. 
    /// The default return value for the CanExecute method is 'true'.
    /// <see cref="RaiseCanExecuteChanged"/> needs to be called whenever
    /// <see cref="CanExecute"/> is expected to return a different value.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Raised when RaiseCanExecuteChanged is called.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether this <see cref="RelayCommand"/> can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Executes the <see cref="RelayCommand"/> on the current command target.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// Method used to raise the <see cref="CanExecuteChanged"/> event
        /// to indicate that the return value of the <see cref="CanExecute"/>
        /// method has changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
```

## <a name="summary"></a><span data-ttu-id="2510a-233">概要</span><span class="sxs-lookup"><span data-stu-id="2510a-233">Summary</span></span>

<span data-ttu-id="2510a-234">ユニバーサル Windows プラットフォームの提供できるようにするための堅牢性と柔軟性ようにコマンド実行システムを共有し、コントロールの種類、デバイス、および入力の型の間でのコマンドを管理するアプリを構築します。</span><span class="sxs-lookup"><span data-stu-id="2510a-234">The Universal Windows Platform provides a robust and flexible commanding system that lets you build apps that share and manage commands across control types, devices, and input types.</span></span>

<span data-ttu-id="2510a-235">UWP アプリ用のコマンドを構築するときに、次の方法を使用します。</span><span class="sxs-lookup"><span data-stu-id="2510a-235">Use the following approaches when building commands for your UWP apps:</span></span>

- <span data-ttu-id="2510a-236">リッスンし、XAML またはコード ビハインドでイベントを処理</span><span class="sxs-lookup"><span data-stu-id="2510a-236">Listen for and handle events in XAML/code-behind</span></span>
- <span data-ttu-id="2510a-237">イベント処理クリックなどのメソッドにバインドします。</span><span class="sxs-lookup"><span data-stu-id="2510a-237">Bind to an event handling method such as Click</span></span>
- <span data-ttu-id="2510a-238">独自の ICommand 実装を定義します。</span><span class="sxs-lookup"><span data-stu-id="2510a-238">Define your own ICommand implementation</span></span>
- <span data-ttu-id="2510a-239">事前に定義された一連のプロパティの独自の値を持つ XamlUICommand オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="2510a-239">Create XamlUICommand objects with your own values for a pre-defined set of properties</span></span>
- <span data-ttu-id="2510a-240">定義済みのプラットフォームのプロパティと値のセットで StandardUICommand オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="2510a-240">Create StandardUICommand objects with a set of pre-defined platform properties and values</span></span>

## <a name="next-steps"></a><span data-ttu-id="2510a-241">次のステップ</span><span class="sxs-lookup"><span data-stu-id="2510a-241">Next steps</span></span>

<span data-ttu-id="2510a-242">完全な例を示す、 [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand)と[StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand)実装を参照してください、 [XAML コントロール ギャラリー](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics)サンプル。</span><span class="sxs-lookup"><span data-stu-id="2510a-242">For a complete example that demonstrates a [XamlUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xamluicommand) and [StandardUICommand](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.standarduicommand) implementation, see the [XAML Controls Gallery](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) sample.</span></span>

## <a name="see-also"></a><span data-ttu-id="2510a-243">関連項目</span><span class="sxs-lookup"><span data-stu-id="2510a-243">See also</span></span>

[<span data-ttu-id="2510a-244">コントロールと UWP アプリのパターン</span><span class="sxs-lookup"><span data-stu-id="2510a-244">Controls and patterns for UWP apps</span></span>](index.md)

### <a name="samples"></a><span data-ttu-id="2510a-245">サンプル</span><span class="sxs-lookup"><span data-stu-id="2510a-245">Samples</span></span>

#### <a name="topic-samples"></a><span data-ttu-id="2510a-246">トピックのサンプル</span><span class="sxs-lookup"><span data-stu-id="2510a-246">Topic samples</span></span>

- [<span data-ttu-id="2510a-247">UWP コマンド実行サンプル (StandardUICommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-247">UWP commanding sample (StandardUICommand)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-commanding-standarduicommand.zip)
- [<span data-ttu-id="2510a-248">UWP コマンド実行サンプル (XamlUICommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-248">UWP commanding sample (XamlUICommand)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-commanding-xamluicommand.zip)
- [<span data-ttu-id="2510a-249">UWP コマンド実行サンプル (ICommand)</span><span class="sxs-lookup"><span data-stu-id="2510a-249">UWP commanding sample (ICommand)</span></span>](https://github.com/MicrosoftDocs/windows-topic-specific-samples/archive/uwp-commanding-icommand.zip)

#### <a name="other-samples"></a><span data-ttu-id="2510a-250">その他のサンプル</span><span class="sxs-lookup"><span data-stu-id="2510a-250">Other samples</span></span>

- [<span data-ttu-id="2510a-251">ユニバーサル Windows プラットフォームのサンプル (C#および C++)</span><span class="sxs-lookup"><span data-stu-id="2510a-251">Universal Windows Platform samples (C# and C++)</span></span>](https://go.microsoft.com/fwlink/?linkid=832713)
- [<span data-ttu-id="2510a-252">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="2510a-252">XAML Controls Gallery</span></span>](https://github.com/Microsoft/Xaml-Controls-Gallery)

<!---Some context for the following links goes here
- [link to next logical step for the customer](global-quickstart-template.md)--->

<!--- Required:
In Overview articles, provide at least one next step and no more than three.
Next steps in overview articles will often link to a quickstart.
Use regular links; do not use a blue box link. What you link to will depend on what is really a next step for the customer.
Do not use a "More info section" or a "Resources section" or a "See also section".
--->
