---
title: 音声は、Xbox でシェル (VES) を有効になっています。
description: Xbox、UWP アプリに音声コントロールのサポートを追加する方法について説明します。
ms.date: 10/19/2017
ms.topic: article
keywords: windows 10、uwp、xbox、音声、音声が有効になっているシェル
ms.openlocfilehash: ea51216c804754e98c3bac459b79fb75dd9369cc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596057"
---
# <a name="using-speech-to-invoke-ui-elements"></a><span data-ttu-id="bb827-104">音声認識を使用して、UI 要素を呼び出す</span><span class="sxs-lookup"><span data-stu-id="bb827-104">Using Speech to Invoke UI Elements</span></span>

<span data-ttu-id="bb827-105">音声有効になっているシェル (VES) は、Windows 音声のプラットフォーム、アプリ内でファースト クラスの音声認識エクスペリエンスを実現する画面を起動するための音声認識を使用できるようにする拡張機能のコントロールとディクテーションを使用してテキストを挿入します。</span><span class="sxs-lookup"><span data-stu-id="bb827-105">Voice Enabled Shell (VES) is an extension to the Windows Speech Platform that enables a first-class speech experience inside apps, allowing users to use speech for invoking on-screen controls and to insert text via dictation.</span></span> <span data-ttu-id="bb827-106">VE では、すべての Windows シェルおよびデバイスでアプリ開発者のために必要な最小限の労力で一般的なエンド ツー エンドの「it say it エクスペリエンスを提供するよう努力しています。</span><span class="sxs-lookup"><span data-stu-id="bb827-106">VES strives to provide a common end-to-end see-it-say-it experience on all Windows Shells and devices, with minimum effort required from app developers.</span></span>  <span data-ttu-id="bb827-107">これを実現するには、Microsoft の音声のプラットフォームと、UI オートメーション (UIA) フレームワークを活用します。</span><span class="sxs-lookup"><span data-stu-id="bb827-107">To achieve this, it leverages the Microsoft Speech Platform  and the UI Automation (UIA) framework.</span></span>

## <a name="user-experience-walkthrough"></a><span data-ttu-id="bb827-108">ユーザー エクスペリエンスのチュートリアル</span><span class="sxs-lookup"><span data-stu-id="bb827-108">User experience walkthrough</span></span> ##
<span data-ttu-id="bb827-109">次にどのようなユーザーが発生した場合、Xbox で VE を使用する場合の概要と VES のしくみの詳細に入る前にコンテキストを設定するようにします。</span><span class="sxs-lookup"><span data-stu-id="bb827-109">The following is an overview of what a user would experience when using VES on Xbox, and it should help set the context before diving into the details of how VES works.</span></span>

- <span data-ttu-id="bb827-110">ユーザーが、Xbox コンソールをオンにし、関心のあるものを検索するには、そのアプリを参照します。</span><span class="sxs-lookup"><span data-stu-id="bb827-110">User turns on the Xbox console and wants to browse through their apps to find something of interest:</span></span>

        User: "Hey Cortana, open My Games and Apps"

- <span data-ttu-id="bb827-111">ユーザーは左側のアクティブなリッスン モード (ALM)、つまり、コンソールがリッスンするいると言うことがなく、画面に表示されているコントロールの呼び出しをユーザーのコルタナさん」毎回です。</span><span class="sxs-lookup"><span data-stu-id="bb827-111">User is left in Active Listening Mode (ALM), meaning the console is now listening for the user to invoke a control that’s visible on the screen, without needing to say, “Hey Cortana” each time.</span></span>  <span data-ttu-id="bb827-112">アプリとアプリの一覧をスクロールして表示するのには、ユーザーは切り替えることができますようになりました。</span><span class="sxs-lookup"><span data-stu-id="bb827-112">User can now switch to view apps and scroll through the app list:</span></span>

        User: "applications"

- <span data-ttu-id="bb827-113">ビューをスクロールするには、ユーザー可能だけです。</span><span class="sxs-lookup"><span data-stu-id="bb827-113">To scroll the view, user can simply say:</span></span>

        User: "scroll down"

- <span data-ttu-id="bb827-114">アプリに関心が名前を忘れた場合、ボックス アートが表示されます。</span><span class="sxs-lookup"><span data-stu-id="bb827-114">User sees the box art for the app they are interested in but forgot the name.</span></span>  <span data-ttu-id="bb827-115">音声ヒント ラベルに表示するユーザーを要求します。</span><span class="sxs-lookup"><span data-stu-id="bb827-115">User asks for voice tip labels to be displayed:</span></span>

        User: "show labels"

- <span data-ttu-id="bb827-116">これで明確に何を言おう、アプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="bb827-116">Now that it's clear what to say, the app can be launched:</span></span>

        User: "movies and TV"

- <span data-ttu-id="bb827-117">アクティブなリッスン モードを終了するには、ユーザーは、リッスンを停止する Xbox を指示します。</span><span class="sxs-lookup"><span data-stu-id="bb827-117">To exit active listening mode, user tells Xbox to stop listening:</span></span>

        User: "stop listening"

- <span data-ttu-id="bb827-118">後で、新しいアクティブなリッスンしているセッションを開始できます。</span><span class="sxs-lookup"><span data-stu-id="bb827-118">Later on, a new active listening session can be started with:</span></span>

        User: "Hey Cortana, make a selection" or "Hey Cortana, select"

## <a name="ui-automation-dependency"></a><span data-ttu-id="bb827-119">UI オートメーションの依存関係</span><span class="sxs-lookup"><span data-stu-id="bb827-119">UI automation dependency</span></span> ##
<span data-ttu-id="bb827-120">VE、UI オートメーション クライアントであり、UI オートメーション プロバイダーを使用してアプリによって公開される情報に依存しています。</span><span class="sxs-lookup"><span data-stu-id="bb827-120">VES is a UI Automation client and relies on information exposed by the app through its UI Automation providers.</span></span> <span data-ttu-id="bb827-121">これは、Windows プラットフォームでのナレーター機能によって既に使用されている同じインフラストラクチャです。</span><span class="sxs-lookup"><span data-stu-id="bb827-121">This is the same infrastructure already being used by the Narrator feature on Windows platforms.</span></span>  <span data-ttu-id="bb827-122">UI オートメーションでは、コントロール、その型、およびどのようなコントロール パターン、実装の名前を含む、ユーザー インターフェイス要素にプログラムからアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="bb827-122">UI Automation enables programmatic access to user interface elements, including the name of the control, its type and what control patterns it implements.</span></span>  <span data-ttu-id="bb827-123">UI は、アプリの変更、VES は UIA 更新イベントに対応し、この情報を使用して、音声認識文法を作成する実行可能なすべての項目を検索する更新済みの UI オートメーション ツリーを再解析します。</span><span class="sxs-lookup"><span data-stu-id="bb827-123">As the UI changes in the app, VES will react to UIA update events and re-parse the updated UI Automation tree to find all the actionable items, using this information to build a speech recognition grammar.</span></span> 

<span data-ttu-id="bb827-124">すべての UWP アプリでは、UI オートメーション フレームワークにアクセスし、(XAML、DirectX/Direct3D、Xamarin など) に基づいて構築されていますが、どのグラフィックス フレームワークに依存しない UI に関する情報を公開できます。</span><span class="sxs-lookup"><span data-stu-id="bb827-124">All UWP apps have access to the UI Automation framework and can expose information about the UI independent of which graphics framework they are built upon (XAML, DirectX/Direct3D, Xamarin, etc.).</span></span>  <span data-ttu-id="bb827-125">場合によっては、XAML などでは、面倒な作業のほとんどは、ナレーターおよび VES をサポートするために必要な作業を大幅に削減に、フレームワークによって行われます。</span><span class="sxs-lookup"><span data-stu-id="bb827-125">In some cases, like XAML, most of the heavy lifting is done by the framework, greatly reducing the work required to support Narrator and VES.</span></span>

<span data-ttu-id="bb827-126">UI オートメーションの詳細についてを参照してください。 [UI オートメーションの基礎](https://msdn.microsoft.com/en-us/library/ms753107(v=vs.110).aspx "UI オートメーションの基礎")します。</span><span class="sxs-lookup"><span data-stu-id="bb827-126">For more info on UI Automation see [UI Automation Fundamentals](https://msdn.microsoft.com/en-us/library/ms753107(v=vs.110).aspx "UI Automation Fundamentals").</span></span>

## <a name="control-invocation-name"></a><span data-ttu-id="bb827-127">コントロールの呼び出しの名前</span><span class="sxs-lookup"><span data-stu-id="bb827-127">Control invocation name</span></span> ##
<span data-ttu-id="bb827-128">VE 何がコントロールの名前として「音声認識エンジンに登録する語句を決定するため次ヒューリスティックを採用しています (ie。 コントロールを呼び出す話す必要があるユーザー)。</span><span class="sxs-lookup"><span data-stu-id="bb827-128">VES employs the following heuristic for determining what phrase to register with the speech recognizer as the control’s name (ie. what the user needs to speak to invoke the control).</span></span>  <span data-ttu-id="bb827-129">これは、また、音声ヒント ラベルに表示される語句です。</span><span class="sxs-lookup"><span data-stu-id="bb827-129">This is also the phrase that will show up in the voice tip label.</span></span>

<span data-ttu-id="bb827-130">優先順位の順序で名前のソース:</span><span class="sxs-lookup"><span data-stu-id="bb827-130">Source of Name in order of priority:</span></span>

1. <span data-ttu-id="bb827-131">要素の場合、 `LabeledBy` VES、添付プロパティを使用して、`AutomationProperties.Name`のこのテキスト ラベル。</span><span class="sxs-lookup"><span data-stu-id="bb827-131">If the element has a `LabeledBy` attached property, VES will use the `AutomationProperties.Name` of this text label.</span></span>
2. <span data-ttu-id="bb827-132">`AutomationProperties.Name` 要素。</span><span class="sxs-lookup"><span data-stu-id="bb827-132">`AutomationProperties.Name` of the element.</span></span>  <span data-ttu-id="bb827-133">既定値として、コントロールのテキスト コンテンツを使用、XAML で`AutomationProperties.Name`します。</span><span class="sxs-lookup"><span data-stu-id="bb827-133">In XAML, the text content of the control will be used as the default value for `AutomationProperties.Name`.</span></span>
3. <span data-ttu-id="bb827-134">VE は有効な最初の子要素を探して、コントロールが ListItem またはボタンの場合は、`AutomationProperties.Name`します。</span><span class="sxs-lookup"><span data-stu-id="bb827-134">If the control is a ListItem or Button, VES will look for the first child element with a valid `AutomationProperties.Name`.</span></span>

## <a name="actionable-controls"></a><span data-ttu-id="bb827-135">実用的なコントロール</span><span class="sxs-lookup"><span data-stu-id="bb827-135">Actionable controls</span></span> ##
<span data-ttu-id="bb827-136">VE は、次のオートメーション コントロール パターンのいずれかを実装している場合に実行可能なコントロールを考慮します。</span><span class="sxs-lookup"><span data-stu-id="bb827-136">VES considers a control actionable if it implements one of the following Automation control patterns:</span></span>

- <span data-ttu-id="bb827-137">**InvokePattern** (例。</span><span class="sxs-lookup"><span data-stu-id="bb827-137">**InvokePattern** (eg.</span></span> <span data-ttu-id="bb827-138">ボタン) の開始または 1 つの明確なアクションを実行し、アクティブになったときの状態を保持しないコントロールを表します。</span><span class="sxs-lookup"><span data-stu-id="bb827-138">Button)- Represents controls that initiate or perform a single, unambiguous action and do not maintain state when activated.</span></span>

- <span data-ttu-id="bb827-139">**TogglePattern** (例。</span><span class="sxs-lookup"><span data-stu-id="bb827-139">**TogglePattern** (eg.</span></span> <span data-ttu-id="bb827-140">チェック ボックスをオン) に、一連の状態の切り替え、一度設定した状態を維持できるコントロールを表します。</span><span class="sxs-lookup"><span data-stu-id="bb827-140">Check Box) - Represents a control that can cycle through a set of states and maintain a state once set.</span></span>

- <span data-ttu-id="bb827-141">**SelectionItemPattern** (例。</span><span class="sxs-lookup"><span data-stu-id="bb827-141">**SelectionItemPattern** (eg.</span></span> <span data-ttu-id="bb827-142">コンボ ボックス) には、選択可能な子項目のコレクションのコンテナーとして機能するコントロールを表します。</span><span class="sxs-lookup"><span data-stu-id="bb827-142">Combo Box) - Represents a control that acts as a container for a collection of selectable child items.</span></span>

- <span data-ttu-id="bb827-143">**ExpandCollapsePattern** (例。</span><span class="sxs-lookup"><span data-stu-id="bb827-143">**ExpandCollapsePattern** (eg.</span></span> <span data-ttu-id="bb827-144">コンボ ボックス) - 視覚的に展開するコンテンツを表示し、コンテンツを非表示に折りたたみコントロールを表します。</span><span class="sxs-lookup"><span data-stu-id="bb827-144">Combo Box) - Represents controls that visually expand to display content and collapse to hide content.</span></span>

- <span data-ttu-id="bb827-145">**ScrollPattern** (例。</span><span class="sxs-lookup"><span data-stu-id="bb827-145">**ScrollPattern** (eg.</span></span> <span data-ttu-id="bb827-146">リスト) の子要素のコレクションのスクロール可能なコンテナーとして機能するコントロールを表します。</span><span class="sxs-lookup"><span data-stu-id="bb827-146">List) - Represents controls that act as scrollable containers for a collection of child elements.</span></span>

## <a name="scrollable-containers"></a><span data-ttu-id="bb827-147">スクロール可能なコンテナー</span><span class="sxs-lookup"><span data-stu-id="bb827-147">Scrollable containers</span></span> ##
<span data-ttu-id="bb827-148">スクロール可能なコンテナーのサポートは、ScrollPattern、VES 音声をリッスンする「左右にスクロール」、「右にスクロールして」などのようなコマンドは、ユーザーがこれらのコマンドのいずれかをトリガーしたときに、適切なパラメーターを使用してスクロールを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bb827-148">For scrollable containers that support the ScrollPattern, VES will listen for voice commands like “scroll left”, “scroll right”, etc. and will invoke Scroll with the appropriate parameters when the user triggers one of these commands.</span></span>  <span data-ttu-id="bb827-149">値に基づくスクロール コマンドが挿入され、`HorizontalScrollPercent`と`VerticalScrollPercent`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="bb827-149">Scroll commands are injected based on the value of the `HorizontalScrollPercent` and `VerticalScrollPercent` properties.</span></span>  <span data-ttu-id="bb827-150">たとえば場合、`HorizontalScrollPercent`は 100、「右にスクロール」を追加するよりも小さい場合、0 の場合、「スクロール左」が追加するよりも大きいためです。</span><span class="sxs-lookup"><span data-stu-id="bb827-150">For instance, if `HorizontalScrollPercent` is greater than 0, “scroll left” will be added, if it’s less than 100, “scroll right” will be added, and so on.</span></span>

## <a name="narrator-overlap"></a><span data-ttu-id="bb827-151">ナレーターの重複</span><span class="sxs-lookup"><span data-stu-id="bb827-151">Narrator overlap</span></span> ##
<span data-ttu-id="bb827-152">ナレーター アプリケーションは、UI オートメーション クライアントでも、使用して、`AutomationProperties.Name`として現在選択されている UI 要素を読み取るテキストのソースのいずれかのプロパティ。</span><span class="sxs-lookup"><span data-stu-id="bb827-152">The Narrator application is also a UI Automation client and uses the `AutomationProperties.Name` property as one of the sources for the text it reads for the currently selected UI element.</span></span>  <span data-ttu-id="bb827-153">アクセシビリティのエクスペリエンスを向上させる多くのアプリを提供する開発者が再度並べ替えられたりオーバー ロード、`Name`詳細とナレーターで読み取られる場合のコンテキストを提供することで時間の長い説明のテキストを持つプロパティです。</span><span class="sxs-lookup"><span data-stu-id="bb827-153">To provide a better accessibility experience many app developers have resorted to overloading the `Name` property with long descriptive text with the goal of providing more information and context when read by Narrator.</span></span>  <span data-ttu-id="bb827-154">ただし、これにより、2 つの機能間の競合です。VE では、短い語句と一致するかより適切なコンテキストを提供するフレーズを長くよりわかりやすいメリットは、ナレーターの中に、コントロールの表示テキストと厳密に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb827-154">However, this causes a conflict between the two features: VES needs short phrases that match or closely match the visible text of the control, while Narrator benefits from longer, more descriptive phrases to give better context.</span></span>

<span data-ttu-id="bb827-155">これを解決する、Windows 10 Creators Update 以降、ナレーターも見てに更新されました、`AutomationProperties.HelpText`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="bb827-155">To resolve this, starting with Windows 10 Creators Update, Narrator was updated to also look at the `AutomationProperties.HelpText` property.</span></span>  <span data-ttu-id="bb827-156">ナレーターがほかに、その内容を読み上げる場合、このプロパティが空でない`AutomationProperties.Name`します。</span><span class="sxs-lookup"><span data-stu-id="bb827-156">If this property is not empty, Narrator will speak its contents in addition to `AutomationProperties.Name`.</span></span>  <span data-ttu-id="bb827-157">場合`HelpText`は空の場合、ナレーターはのみの内容を読み取る名。</span><span class="sxs-lookup"><span data-stu-id="bb827-157">If `HelpText` is empty, Narrator will only read the contents of Name.</span></span>  <span data-ttu-id="bb827-158">これにより、必要に応じて、使用するわかりやすい文字列になったが短く、音声認識フレンドリ内の句を維持、`Name`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="bb827-158">This will enable longer descriptive strings to be used where needed, but maintains a shorter, speech recognition friendly phrase in the `Name` property.</span></span>

![](images/ves_narrator.jpg)

<span data-ttu-id="bb827-159">詳細については、次を参照してください。 [UI でのユーザー補助のサポートのオートメーション プロパティ](https://msdn.microsoft.com/en-us/library/ff400332(vs.95).aspx "UI でのユーザー補助のサポートのオートメーション プロパティ")します。</span><span class="sxs-lookup"><span data-stu-id="bb827-159">For more info see [Automation Properties for Accessibility Support in UI](https://msdn.microsoft.com/en-us/library/ff400332(vs.95).aspx "Automation Properties for Accessibility Support in UI").</span></span>

## <a name="active-listening-mode-alm"></a><span data-ttu-id="bb827-160">アクティブなリッスン モード (ALM)</span><span class="sxs-lookup"><span data-stu-id="bb827-160">Active Listening Mode (ALM)</span></span> ##
### <a name="entering-alm"></a><span data-ttu-id="bb827-161">ALM を入力します。</span><span class="sxs-lookup"><span data-stu-id="bb827-161">Entering ALM</span></span> ###
<span data-ttu-id="bb827-162">Xbox では、VES が音声入力の継続的にリッスンしていません。</span><span class="sxs-lookup"><span data-stu-id="bb827-162">On Xbox, VES is not constantly listening for speech input.</span></span>  <span data-ttu-id="bb827-163">ユーザーは、ことを示すアクティブなリッスン モードを明示的に入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb827-163">The user needs to enter Active Listening Mode explicitly by saying:</span></span>

- <span data-ttu-id="bb827-164">"こんにちは Cortana、select"、または</span><span class="sxs-lookup"><span data-stu-id="bb827-164">“Hey Cortana, select”, or</span></span>
- <span data-ttu-id="bb827-165">"こんにちは Cortana、選択する"</span><span class="sxs-lookup"><span data-stu-id="bb827-165">“Hey Cortana, make a selection”</span></span>

<span data-ttu-id="bb827-166">"Hey Cortana、サインイン"または」「コルタナさんホームに戻るなど、完了時アクティブにリッスンしているユーザーのままにもいくつかその他の Cortana コマンドもあります。</span><span class="sxs-lookup"><span data-stu-id="bb827-166">There are several other Cortana commands that also leave the user in active listening upon completion, for example “Hey Cortana, sign in” or “Hey Cortana, go home”.</span></span> 

<span data-ttu-id="bb827-167">ALM を入力すると、次の効果が完成します。</span><span class="sxs-lookup"><span data-stu-id="bb827-167">Entering ALM will have the following effect:</span></span>

- <span data-ttu-id="bb827-168">Cortana のオーバーレイは、表示される内容とユーザーに求める上部右に表示されます。</span><span class="sxs-lookup"><span data-stu-id="bb827-168">The Cortana overlay will be shown in the top right corner, telling the user they can say what they see.</span></span>  <span data-ttu-id="bb827-169">ユーザーが言うと、中に音声認識エンジンによって認識される語句フラグメントはこの場所にも表示されます。</span><span class="sxs-lookup"><span data-stu-id="bb827-169">While the user is speaking, phrase fragments that are recognized by the speech recognizer will also be shown in this location.</span></span>
- <span data-ttu-id="bb827-170">VE は、UIA ツリーに解析、実行可能なすべてのコントロールを検索します、それぞれのテキストを音声認識文法の登録、および継続的なリッスンしているセッションを開始するを。</span><span class="sxs-lookup"><span data-stu-id="bb827-170">VES parses the UIA tree, finds all actionable controls, registers their text in the speech recognition grammar and starts a continuous listening session.</span></span>

    ![](images/ves_overlay.png)

### <a name="exiting-alm"></a><span data-ttu-id="bb827-171">既存の ALM</span><span class="sxs-lookup"><span data-stu-id="bb827-171">Exiting ALM</span></span> ###
<span data-ttu-id="bb827-172">ユーザーが音声を使用して UI を使用した操作中に、システムは ALM に残ります。</span><span class="sxs-lookup"><span data-stu-id="bb827-172">The system will remain in ALM while the user is interacting with the UI using voice.</span></span>  <span data-ttu-id="bb827-173">ALM を終了する 2 つの方法はあります。</span><span class="sxs-lookup"><span data-stu-id="bb827-173">There are two ways to exit ALM:</span></span>

- <span data-ttu-id="bb827-174">ユーザーに明示的には、「リッスンを停止」または</span><span class="sxs-lookup"><span data-stu-id="bb827-174">User explicitly says, “stop listening”, or</span></span>
- <span data-ttu-id="bb827-175">ALM を入力してから、または最後の正の認識以降 17 秒以内に正の認識がない場合、タイムアウトが発生します。</span><span class="sxs-lookup"><span data-stu-id="bb827-175">A timeout will occur If there isn’t a positive recognition within 17 seconds of entering ALM or since the last positive recognition</span></span>

## <a name="invoking-controls"></a><span data-ttu-id="bb827-176">コントロールの呼び出し</span><span class="sxs-lookup"><span data-stu-id="bb827-176">Invoking controls</span></span> ##
<span data-ttu-id="bb827-177">音声を使用して UI を使用したユーザーが操作できる ALM の場合にします。</span><span class="sxs-lookup"><span data-stu-id="bb827-177">When in ALM the user can interact with the UI using voice.</span></span>  <span data-ttu-id="bb827-178">UI が正しく (表示されるテキストに一致する名前プロパティ) で構成されている、音声を使用してアクションを実行する、シームレスで自然なの経験ことがあります。</span><span class="sxs-lookup"><span data-stu-id="bb827-178">If the UI is configured correctly (with Name properties matching the visible text), using voice to perform actions should be a seamless, natural experience.</span></span>  <span data-ttu-id="bb827-179">ユーザーは、単に画面に表示できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb827-179">The user should be able to just say what they see on the screen.</span></span>

## <a name="overlay-ui-on-xbox"></a><span data-ttu-id="bb827-180">Xbox で UI をオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="bb827-180">Overlay UI on Xbox</span></span> ##
<span data-ttu-id="bb827-181">VES 名前は派生のコントロールが UI に表示される実際のテキストよりも異なる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bb827-181">The name VES derives for a control may be different than the actual visible text in the UI.</span></span>  <span data-ttu-id="bb827-182">期限を指定できます、`Name`プロパティまたは関連付けられているコントロールの`LabeledBy`要素の明示的に別の文字列に設定します。</span><span class="sxs-lookup"><span data-stu-id="bb827-182">This can be due to the `Name` property of the control or the attached `LabeledBy` element being explicitly set to different string.</span></span>  <span data-ttu-id="bb827-183">または、コントロールに GUI テキスト、アイコンまたはイメージ要素のみがありません。</span><span class="sxs-lookup"><span data-stu-id="bb827-183">Or, the control does not have GUI text but only an icon or image element.</span></span>

<span data-ttu-id="bb827-184">このような場合は、ユーザーには、このようなコントロールを呼び出すためには当てはまりませんが必要なものを表示する方法が必要があります。</span><span class="sxs-lookup"><span data-stu-id="bb827-184">In these cases, users need a way to see what needs to be said in order to invoke such a control.</span></span>  <span data-ttu-id="bb827-185">そのため、1 回でアクティブなリッスンしている、音声のヒント表示できます「のラベルを表示する」と言って。</span><span class="sxs-lookup"><span data-stu-id="bb827-185">Therefore, once in active listening, voice tips can be displayed by saying “show labels”.</span></span>  <span data-ttu-id="bb827-186">これにより、音声はヒント ラベルをすべて実行可能なコントロールの上に表示されます。</span><span class="sxs-lookup"><span data-stu-id="bb827-186">This causes voice tip labels to appear on top of every actionable control.</span></span>

<span data-ttu-id="bb827-187">100 のラベルの制限がある場合は、アプリの UI がある 100 よりもより実施可能なコントロールがあるため一部の音声ヒント ラベルはありません。</span><span class="sxs-lookup"><span data-stu-id="bb827-187">There is a limit of 100 labels, so if the app’s UI has more actionable controls than 100 there will be some that will not have voice tip labels shown.</span></span>  <span data-ttu-id="bb827-188">ラベルが選択したこの例では非決定的、構造と、現在の UI の構成に依存している UIA ツリーに最初に列挙します。</span><span class="sxs-lookup"><span data-stu-id="bb827-188">Which labels are chosen in this case is not deterministic, as it depends on the structure and composition of the current UI as first enumerated in the UIA tree.</span></span>

<span data-ttu-id="bb827-189">音声ヒント ラベルを表示するには、非表示にするコマンドがないとは引き続き表示された、次のイベントのいずれかが発生するまで。</span><span class="sxs-lookup"><span data-stu-id="bb827-189">Once voice tip labels are shown there is no command to hide them, they will remain visible until one of the following events occur:</span></span>

- <span data-ttu-id="bb827-190">ユーザーがコントロールを呼び出す</span><span class="sxs-lookup"><span data-stu-id="bb827-190">user invokes a control</span></span>
- <span data-ttu-id="bb827-191">ユーザーが現在のシーンから離れた</span><span class="sxs-lookup"><span data-stu-id="bb827-191">user navigates away from the current scene</span></span>
- <span data-ttu-id="bb827-192">「リッスンを停止」、ユーザーを質問します。</span><span class="sxs-lookup"><span data-stu-id="bb827-192">user says, “stop listening”</span></span>
- <span data-ttu-id="bb827-193">アクティブなリッスン モードをタイムアウトします。</span><span class="sxs-lookup"><span data-stu-id="bb827-193">active listening mode times out</span></span>

## <a name="location-of-voice-tip-labels"></a><span data-ttu-id="bb827-194">音声のヒントのラベルの場所</span><span class="sxs-lookup"><span data-stu-id="bb827-194">Location of voice tip labels</span></span> ##
<span data-ttu-id="bb827-195">音声ヒント ラベルは、コントロールの BoundingRectangle 内で水平方向および垂直方向に中央が。</span><span class="sxs-lookup"><span data-stu-id="bb827-195">Voice tip labels are horizontally and vertically centered within the control’s BoundingRectangle.</span></span>  <span data-ttu-id="bb827-196">ラベルができるコントロールが小さいと緊密にグループ化する場合、他のユーザーがはっきりと見えなく重複/なる、VES はこれらのラベル間隔にプッシュを別々 に表示されることを確認しようとしています。</span><span class="sxs-lookup"><span data-stu-id="bb827-196">When controls are small and tightly grouped, the labels can overlap/become obscured by others and VES will try to push these labels apart to separate them and ensure they are visible.</span></span>  <span data-ttu-id="bb827-197">ただし、これは保証されません 100% の時間を操作します。</span><span class="sxs-lookup"><span data-stu-id="bb827-197">However, this is not guaranteed to work 100% of the time.</span></span>  <span data-ttu-id="bb827-198">可能性は非常に混雑した UI の場合、他のユーザーによって隠されている一部のラベルが発生します。</span><span class="sxs-lookup"><span data-stu-id="bb827-198">If there is a very crowded UI, it will likely result in some labels being obscured by others.</span></span> <span data-ttu-id="bb827-199">「ラベルを表示する」で、UI を確認してください音声ヒントの表示のための十分な余裕があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bb827-199">Please review your UI with “show labels” to ensure there is adequate room for voice tip visibility.</span></span>

![](images/ves_labels.png)

## <a name="combo-boxes"></a><span data-ttu-id="bb827-200">コンボ ボックス</span><span class="sxs-lookup"><span data-stu-id="bb827-200">Combo boxes</span></span> ##
<span data-ttu-id="bb827-201">コンボ ボックスは、コンボ ボックスの個々 の項目を展開するときに、独自の音声ヒント ラベルを取得し、ドロップダウン リストの背後にある既存のコントロールの上にこれらは多くの場合、します。</span><span class="sxs-lookup"><span data-stu-id="bb827-201">When a combo box is expanded each individual item in the combo box gets its own voice tip label and often these will be on top of existing controls behind drop down list.</span></span>  <span data-ttu-id="bb827-202">プレゼンテーションの乱雑および混乱ラベルの混同 (コンボ ボックス項目のラベルがコンボ ボックスの背後にあるコントロールのラベルを混在させるは) を回避するために子アイテムが表示されるため、コンボ ボックスのラベルのみを展開します。 その他のすべての音声ヒント ラベルは表示されません。</span><span class="sxs-lookup"><span data-stu-id="bb827-202">To avoid presenting a cluttered and confusing muddle of labels (where combo box item labels are intermixed with the labels of controls behind the combo box) when a combo box is expanded only the labels for its child items will be shown;  all other voice tip labels will be hidden.</span></span>  <span data-ttu-id="bb827-203">ユーザーか、ドロップダウン リストの項目のいずれかを選択したりできますコンボ ボックスの「閉じる」。</span><span class="sxs-lookup"><span data-stu-id="bb827-203">The user can then either select one of the drop-down items or “close” the combo box.</span></span>

- <span data-ttu-id="bb827-204">折りたたまれたコンボ ボックスのラベル。</span><span class="sxs-lookup"><span data-stu-id="bb827-204">Labels on collapsed combo boxes:</span></span>

    ![](images/ves_combo_closed.png)

- <span data-ttu-id="bb827-205">拡張コンボ ボックスのラベル。</span><span class="sxs-lookup"><span data-stu-id="bb827-205">Labels on expanded combo box:</span></span>

    ![](images/ves_combo_open.png)


## <a name="scrollable-controls"></a><span data-ttu-id="bb827-206">スクロール可能なコントロール</span><span class="sxs-lookup"><span data-stu-id="bb827-206">Scrollable controls</span></span> ##
<span data-ttu-id="bb827-207">スクロール可能なコントロールは、各コントロールの端でスクロール コマンドに対する音声ヒントが中央揃えにします。</span><span class="sxs-lookup"><span data-stu-id="bb827-207">For scrollable controls, the voice tips for the scroll commands will be centered on each of the edges of the control.</span></span>  <span data-ttu-id="bb827-208">音声のヒントは実用的なは、そのため、たとえば「上にスクロールする」と「スクロール」の垂直方向スクロールがない場合は表示されませんがスクロール方向のみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="bb827-208">Voice tips will only be shown for the scroll directions that are actionable, so for example if vertical scrolling is not available, “scroll up” and “scroll down” will not be shown.</span></span>  <span data-ttu-id="bb827-209">VE が序数を使用して区別する (例: スクロール可能な複数のリージョンが存在する場合</span><span class="sxs-lookup"><span data-stu-id="bb827-209">When multiple scrollable regions are present VES will use ordinals to differentiate between them (eg.</span></span> <span data-ttu-id="bb827-210">「スクロール権限 1」、「スクロール右側 2」など。)。</span><span class="sxs-lookup"><span data-stu-id="bb827-210">“Scroll right 1”, “Scroll right 2”, etc.).</span></span>

![](images/ves_scroll.png) 

## <a name="disambiguation"></a><span data-ttu-id="bb827-211">不明瞭解消</span><span class="sxs-lookup"><span data-stu-id="bb827-211">Disambiguation</span></span> ##
<span data-ttu-id="bb827-212">複数の UI 要素が同じ名前を持つか、音声認識エンジンが複数の候補を一致、VES は曖昧性除去モードを入力します。</span><span class="sxs-lookup"><span data-stu-id="bb827-212">When multiple UI elements have the same Name, or the speech recognizer matched multiple candidates, VES will enter disambiguation mode.</span></span>  <span data-ttu-id="bb827-213">このモードの音声のヒントにラベルを表示する要素の関連するユーザーが適切なものを選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="bb827-213">In this mode voice tip labels will be shown for the elements involved so that the user can select the right one.</span></span> <span data-ttu-id="bb827-214">曖昧性除去モードを解除「キャンセル」を言うことにより、ユーザーをキャンセルできます。</span><span class="sxs-lookup"><span data-stu-id="bb827-214">The user can cancel out of disambiguation mode by saying "cancel".</span></span>

<span data-ttu-id="bb827-215">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="bb827-215">For example:</span></span>

- <span data-ttu-id="bb827-216">曖昧性除去; 前に、のアクティブなリッスン モードで「います I があいまいです」、ユーザーを質問します。</span><span class="sxs-lookup"><span data-stu-id="bb827-216">In Active Listening Mode, before disambiguation; user says, "Am I Ambiguous":</span></span>

    ![](images/ves_disambig1.png) 

- <span data-ttu-id="bb827-217">両方のボタンと一致します。曖昧性除去は、次の開始。</span><span class="sxs-lookup"><span data-stu-id="bb827-217">Both buttons matched; disambiguation started:</span></span>

    ![](images/ves_disambig2.png) 

- <span data-ttu-id="bb827-218">表示は、"Select 2"が選択されたときにアクションをクリックします。</span><span class="sxs-lookup"><span data-stu-id="bb827-218">Showing click action when "Select 2" was chosen:</span></span>

    ![](images/ves_disambig3.png) 
 
## <a name="sample-ui"></a><span data-ttu-id="bb827-219">サンプル UI</span><span class="sxs-lookup"><span data-stu-id="bb827-219">Sample UI</span></span> ##
<span data-ttu-id="bb827-220">ここでは、XAML の例に基づく UI、さまざまな方法で AutomationProperties.Name を設定します。</span><span class="sxs-lookup"><span data-stu-id="bb827-220">Here’s an example of a XAML based UI, setting the AutomationProperties.Name in various ways:</span></span>

    <Page
        x:Class="VESSampleCSharp.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:VESSampleCSharp"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d">
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Button x:Name="button1" Content="Hello World" HorizontalAlignment="Left" Margin="44,56,0,0" VerticalAlignment="Top"/>
            <Button x:Name="button2" AutomationProperties.Name="Launch Game" Content="Launch" HorizontalAlignment="Left" Margin="44,106,0,0" VerticalAlignment="Top" Width="99"/>
            <TextBlock AutomationProperties.Name="Day of Week" x:Name="label1" HorizontalAlignment="Left" Height="22" Margin="168,62,0,0" TextWrapping="Wrap" Text="Select Day of Week:" VerticalAlignment="Top" Width="137"/>
            <ComboBox AutomationProperties.LabeledBy="{Binding ElementName=label1}" x:Name="comboBox" HorizontalAlignment="Left" Margin="310,57,0,0" VerticalAlignment="Top" Width="120">
                <ComboBoxItem Content="Monday" IsSelected="True"/>
                <ComboBoxItem Content="Tuesday"/>
                <ComboBoxItem Content="Wednesday"/>
                <ComboBoxItem Content="Thursday"/>
                <ComboBoxItem Content="Friday"/>
                <ComboBoxItem Content="Saturday"/>
                <ComboBoxItem Content="Sunday"/>
            </ComboBox>
            <Button x:Name="button3" HorizontalAlignment="Left" Margin="44,156,0,0" VerticalAlignment="Top" Width="213">
                <Grid>
                    <TextBlock AutomationProperties.Name="Accept">Accept Offer</TextBlock>
                    <TextBlock Margin="0,25,0,0" Foreground="#FF5A5A5A">Exclusive offer just for you</TextBlock>
                </Grid>
            </Button>
        </Grid>
    </Page>


<span data-ttu-id="bb827-221">ここで、上記のサンプルを使用して、UI の外観と音声のヒントのラベルがない場合です。</span><span class="sxs-lookup"><span data-stu-id="bb827-221">Using the above sample here is what the UI will look like with and without voice tip labels.</span></span>
 
- <span data-ttu-id="bb827-222">アクティブなリッスン モードで表示されるラベルがない場合。</span><span class="sxs-lookup"><span data-stu-id="bb827-222">In Active Listening Mode, without labels shown:</span></span>

    ![](images/ves_alm_nolabels.png) 

- <span data-ttu-id="bb827-223">アクティブなリッスン モードで、ユーザーの質問「ラベルを表示する」後。</span><span class="sxs-lookup"><span data-stu-id="bb827-223">In Active Listening Mode, after user says "show labels":</span></span>

    ![](images/ves_alm_labels.png) 

<span data-ttu-id="bb827-224">場合に`button1`、XAML 自動に設定します、`AutomationProperties.Name`プロパティ、コントロールの表示のテキスト コンテンツからテキストを使用します。</span><span class="sxs-lookup"><span data-stu-id="bb827-224">In the case of `button1`, XAML auto populates the `AutomationProperties.Name` property using text from the control’s visible text content.</span></span>  <span data-ttu-id="bb827-225">これは、明示的ながない場合でも、音声ヒント ラベルがある理由`AutomationProperties.Name`を設定します。</span><span class="sxs-lookup"><span data-stu-id="bb827-225">This is why there is a voice tip label even though there isn't an explicit `AutomationProperties.Name` set.</span></span>

<span data-ttu-id="bb827-226">`button2`を明示的に設定、`AutomationProperties.Name`コントロールのテキスト以外のものにします。</span><span class="sxs-lookup"><span data-stu-id="bb827-226">With `button2`, we explicitly set the `AutomationProperties.Name` to something other than the text of the control.</span></span>

<span data-ttu-id="bb827-227">`comboBox`を使用して、`LabeledBy`プロパティ参照を`label1`自動化のソースとして`Name`、し、`label1`を設定します、`AutomationProperties.Name`を画面にレンダリングされるコンテンツよりもより自然な語句 ("Day of Week"ではなく"Select 1 日に複数の曜日")。</span><span class="sxs-lookup"><span data-stu-id="bb827-227">With `comboBox`, we used the `LabeledBy` property to reference `label1` as the source of the automation `Name`, and in `label1` we set the `AutomationProperties.Name` to a more natural phrase than what is rendered on screen (“Day of Week” rather than “Select Day of Week”).</span></span>

<span data-ttu-id="bb827-228">最後に、 `button3`、VES を取得、`Name`から最初の子要素から`button3`自体はありません、`AutomationProperties.Name`を設定します。</span><span class="sxs-lookup"><span data-stu-id="bb827-228">Finally, with `button3`, VES grabs the `Name` from the first child element since `button3` itself does not have an `AutomationProperties.Name` set.</span></span>

## <a name="see-also"></a><span data-ttu-id="bb827-229">関連項目</span><span class="sxs-lookup"><span data-stu-id="bb827-229">See also</span></span>
- <span data-ttu-id="bb827-230">[UI オートメーションの基礎](https://msdn.microsoft.com/en-us/library/ms753107(v=vs.110).aspx "UI オートメーションの基礎")</span><span class="sxs-lookup"><span data-stu-id="bb827-230">[UI Automation Fundamentals](https://msdn.microsoft.com/en-us/library/ms753107(v=vs.110).aspx "UI Automation Fundamentals")</span></span>
- <span data-ttu-id="bb827-231">[UI でのユーザー補助のサポートのオートメーション プロパティ](https://msdn.microsoft.com/en-us/library/ff400332(vs.95).aspx "UI でのユーザー補助のサポートのオートメーション プロパティ")</span><span class="sxs-lookup"><span data-stu-id="bb827-231">[Automation Properties for Accessibility Support in UI](https://msdn.microsoft.com/en-us/library/ff400332(vs.95).aspx "Automation Properties for Accessibility Support in UI")</span></span>
- [<span data-ttu-id="bb827-232">よく寄せられる質問</span><span class="sxs-lookup"><span data-stu-id="bb827-232">Frequently asked questions</span></span>](frequently-asked-questions.md)
- [<span data-ttu-id="bb827-233">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="bb827-233">UWP on Xbox One</span></span>](index.md)
