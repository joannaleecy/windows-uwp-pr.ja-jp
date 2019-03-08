---
Description: メディア プレーヤーには、オーディオおよびビデオ コンテンツのコントロールを管理するためのカスタマイズ可能な XAML トランスポート コントロールがあります。
title: カスタム メディア トランスポート コントロールを作成する
ms.assetid: 6643A108-A6EB-42BC-B800-22EABD7B731B
label: Create custom media transport controls
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d4b9e82b0ab5e798bb0b29c4d5127cfe773db5f7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616257"
---
# <a name="create-custom-transport-controls"></a><span data-ttu-id="ac527-104">カスタム トランスポート コントロールを作成する</span><span class="sxs-lookup"><span data-stu-id="ac527-104">Create custom transport controls</span></span>



<span data-ttu-id="ac527-105">MediaPlayerElement には、ユニバーサル Windows プラットフォーム (UWP) アプリ内でオーディオおよびビデオ コンテンツのコントロールを管理するためのカスタマイズ可能な XAML トランスポート コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="ac527-105">MediaPlayerElement has customizable XAML transport controls to manage control of audio and video content within a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="ac527-106">ここでは、MediaTransportControls テンプレートをカスタマイズする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="ac527-106">Here, we demonstrate how to customize the MediaTransportControls template.</span></span> <span data-ttu-id="ac527-107">オーバーフロー メニューの操作方法、カスタム ボタンの追加方法、スライダーの変更方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ac527-107">We’ll show you how to work with the overflow menu, add a custom button and modify the slider.</span></span>

> <span data-ttu-id="ac527-108">**重要な Api**:[MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx)、 [MediaPlayerElement.AreTransportControlsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aretransportcontrolsenabled.aspx)、 [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677)</span><span class="sxs-lookup"><span data-stu-id="ac527-108">**Important APIs**: [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx), [MediaPlayerElement.AreTransportControlsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aretransportcontrolsenabled.aspx), [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677)</span></span>

<span data-ttu-id="ac527-109">始める前に、MediaPlayerElement クラスと MediaTransportControls クラスについて理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-109">Before starting, you should be familiar with the MediaPlayerElement and the MediaTransportControls classes.</span></span> <span data-ttu-id="ac527-110">詳しくは、「MediaPlayerElement コントロール ガイド」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ac527-110">For more info, see the MediaPlayerElement control guide.</span></span>

> [!TIP]
> <span data-ttu-id="ac527-111">このトピックの例は、[メディア トランスポート コントロールのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=620023)を基にしています。</span><span class="sxs-lookup"><span data-stu-id="ac527-111">The examples in this topic are based on the [Media Transport Controls sample](https://go.microsoft.com/fwlink/p/?LinkId=620023).</span></span> <span data-ttu-id="ac527-112">サンプルをダウンロードし、詳細なコードを参照して実行することができます。</span><span class="sxs-lookup"><span data-stu-id="ac527-112">You can download the sample to view and run the completed code.</span></span>

> [!NOTE]
> <span data-ttu-id="ac527-113">**MediaPlayerElement** は Windows 10 バージョン 1607 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="ac527-113">**MediaPlayerElement** is only available in Windows 10, version 1607 and up.</span></span> <span data-ttu-id="ac527-114">Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-114">If you are developing an app for an earlier version of Windows 10 you will need to use [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) instead.</span></span> <span data-ttu-id="ac527-115">このページのすべての例は **MediaElement**でも動作します。</span><span class="sxs-lookup"><span data-stu-id="ac527-115">All of the examples on this page work with **MediaElement** as well.</span></span>

## <a name="when-should-you-customize-the-template"></a><span data-ttu-id="ac527-116">テンプレートをカスタマイズする必要がある状況</span><span class="sxs-lookup"><span data-stu-id="ac527-116">When should you customize the template?</span></span>

<span data-ttu-id="ac527-117">**MediaPlayerElement** には、変更しなくてもほとんどのビデオおよびオーディオ再生アプリで正常に動作するように設計されているトランスポート コントロールが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-117">**MediaPlayerElement** has built-in transport controls that are designed to work well without modification in most video and audio playback apps.</span></span> <span data-ttu-id="ac527-118">これらのコントロールは、[**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) クラスによって提供され、再生、停止、メディアのナビゲーション、音量の調節、全画面表示の切り替え、2 台目のデバイスへのキャスト、字幕の有効化、オーディオ トラックの切り替え、再生速度の調整を行うためのボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-118">They’re provided by the [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) class and include buttons to play, stop, and navigate media, adjust volume, toggle full screen, cast to a second device, enable captions, switch audio tracks, and adjust the playback rate.</span></span> <span data-ttu-id="ac527-119">MediaTransportControls には、各ボタンを表示し、有効にするかどうかを制御できるプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="ac527-119">MediaTransportControls has properties that let you control whether each button is shown and enabled.</span></span> <span data-ttu-id="ac527-120">[  **IsCompact**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.iscompact.aspx) プロパティを設定して、コントロールを 1 行に表示するか、2 行に表示するかを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="ac527-120">You can also set the [**IsCompact**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.iscompact.aspx) property to specify whether the controls are shown in one row or two.</span></span>

<span data-ttu-id="ac527-121">ただし、コントロールの外観をさらにカスタマイズしたり、動作を変更したりする必要があるシナリオも考えられます。</span><span class="sxs-lookup"><span data-stu-id="ac527-121">However, there may be scenarios where you need to further customize the look of the control or change its behavior.</span></span> <span data-ttu-id="ac527-122">例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="ac527-122">Here are some examples:</span></span>
- <span data-ttu-id="ac527-123">アイコン、スライダーの動作、色を変更する。</span><span class="sxs-lookup"><span data-stu-id="ac527-123">Change the icons, slider behavior, and colors.</span></span>
- <span data-ttu-id="ac527-124">使用頻度の低いコマンド ボタンをオーバーフロー メニューに移動する。</span><span class="sxs-lookup"><span data-stu-id="ac527-124">Move less commonly used command buttons into an overflow menu.</span></span>
- <span data-ttu-id="ac527-125">コントロールのサイズが変更されたときに、コマンドをドロップ アウトする順序を変更する。</span><span class="sxs-lookup"><span data-stu-id="ac527-125">Change the order in which commands drop out when the control is resized.</span></span>
- <span data-ttu-id="ac527-126">既定のセットには含まれていないコマンド ボタンを提供する。</span><span class="sxs-lookup"><span data-stu-id="ac527-126">Provide a command button that’s not in the default set.</span></span>

> [!NOTE]
> <span data-ttu-id="ac527-127">画面に表示されているボタンは、画面に十分なスペースがない場合、組み込みのトランスポート コントロールから定義済みの順序でドロップ アウトします。</span><span class="sxs-lookup"><span data-stu-id="ac527-127">The buttons visible on screen will drop out of the built-in transport controls in a predefined order if there is not enough room on screen.</span></span> <span data-ttu-id="ac527-128">この順序を変更するか、オーバーフロー メニューに収まらないコマンドを配置するには、コントロールをカスタマイズする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-128">To change this ordering or put commands that don't fit into an overflow menu, you will need to customize the controls.</span></span>

<span data-ttu-id="ac527-129">コントロールの外観をカスタマイズするには、既定のテンプレートを変更します。</span><span class="sxs-lookup"><span data-stu-id="ac527-129">You can customize the appearance of the control by modifying the default template.</span></span> <span data-ttu-id="ac527-130">コントロールの動作を変更したり、新しいコマンドを追加したりするには、MediaTransportControls から派生したカスタム コントロールを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ac527-130">To modify the control's behavior or add new commands, you can create a custom control that's derived from MediaTransportControls.</span></span>

> [!TIP]
> <span data-ttu-id="ac527-131">カスタマイズ可能なコントロール テンプレートは XAML プラットフォームの強力な機能ですが、考慮すべき影響もあります。</span><span class="sxs-lookup"><span data-stu-id="ac527-131">Customizable control templates are a powerful feature of the XAML platform, but there are also consequences that you should take into consideration.</span></span> <span data-ttu-id="ac527-132">テンプレートをカスタマイズすると、アプリの静的な部分となるため、Microsoft によって行われるプラットフォームの更新を受け取らなくなります。</span><span class="sxs-lookup"><span data-stu-id="ac527-132">When you customize a template, it becomes a static part of your app and therefore will not receive any platform updates that are made to the template by Microsoft.</span></span> <span data-ttu-id="ac527-133">Microsoft によってテンプレートの更新が加えられた場合、更新されたテンプレートを利用するには、新しいテンプレートを取得して再変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-133">If template updates are made by Microsoft, you should take the new template and re-modify it in order to get the benefits of the updated template.</span></span>

## <a name="template-structure"></a><span data-ttu-id="ac527-134">テンプレートの構造</span><span class="sxs-lookup"><span data-stu-id="ac527-134">Template structure</span></span>

<span data-ttu-id="ac527-135">[  **ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.controltemplate.aspx) は既定のスタイルに含まれます。</span><span class="sxs-lookup"><span data-stu-id="ac527-135">The [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.controltemplate.aspx) is part of the default style.</span></span> <span data-ttu-id="ac527-136">この既定のスタイルをプロジェクトにコピーして変更できます。</span><span class="sxs-lookup"><span data-stu-id="ac527-136">You can copy this default style into your project to modify it.</span></span> <span data-ttu-id="ac527-137">ControlTemplate は、他の XAML コントロール テンプレートと同様のセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-137">The ControlTemplate is divided into sections similar to other XAML control templates.</span></span>
- <span data-ttu-id="ac527-138">テンプレートの最初のセクションには、MediaTransportControls のさまざまなコンポーネントの [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) 定義が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-138">The first section of the template contains the [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) definitions for the various components of the MediaTransportControls.</span></span>
- <span data-ttu-id="ac527-139">2 番目のセクションでは、MediaTransportControls が使うさまざまな表示状態が定義されています。</span><span class="sxs-lookup"><span data-stu-id="ac527-139">The second section defines the various visual states that are used by the MediaTransportControls.</span></span>
- <span data-ttu-id="ac527-140">3 番目のセクションには、さまざまな MediaTransportControls 要素をまとめて保持し、コンポーネントのレイアウトを定義する [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-140">The third section contains the [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) that holds that various MediaTransportControls elements together and defines how the components are laid out.</span></span>

> [!NOTE]
> <span data-ttu-id="ac527-141">テンプレートの変更について詳しくは、「[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ac527-141">For more info about modifying templates, see [Control templates](/windows/uwp/design/controls-and-patterns/control-templates).</span></span> <span data-ttu-id="ac527-142">テキスト エディターまたは同様のエディターお使いの IDE で XAML ファイルを開く\( *Program Files*) \Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\\(*のSDKバージョン*)\Generic します。</span><span class="sxs-lookup"><span data-stu-id="ac527-142">You can use a text editor or similar editors in your IDE to open the XAML files in \(*Program Files*)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\\(*SDK version*)\Generic.</span></span> <span data-ttu-id="ac527-143">各コントロールの既定のスタイルとテンプレートは、**generic.xaml** ファイルで定義されています。</span><span class="sxs-lookup"><span data-stu-id="ac527-143">The default style and template for each control is defined in the **generic.xaml** file.</span></span> <span data-ttu-id="ac527-144">MediaTransportControls テンプレートは、generic.xaml で "MediaTransportControls" を検索すると見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="ac527-144">You can find the MediaTransportControls template in generic.xaml by searching for "MediaTransportControls".</span></span>

<span data-ttu-id="ac527-145">以下のセクションでは、トランスポート コントロールの主な要素のいくつかをカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="ac527-145">In the following sections, you learn how to customize several of the main elements of the transport controls:</span></span>
- <span data-ttu-id="ac527-146">[**スライダー**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx): により、ユーザーはそのメディアでスクラブし、も進行状況が表示されます</span><span class="sxs-lookup"><span data-stu-id="ac527-146">[**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx): allows a user to scrub through their media and also displays progress</span></span>
- <span data-ttu-id="ac527-147">[**コマンド バー**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx): すべてのボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-147">[**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx): contains all of the buttons.</span></span>
<span data-ttu-id="ac527-148">詳しくは、MediaTransportControls リファレンス トピックの構造セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ac527-148">For more info, see the Anatomy section of the MediaTransportControls reference topic.</span></span>

## <a name="customize-the-transport-controls"></a><span data-ttu-id="ac527-149">トランスポート コントロールをカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="ac527-149">Customize the transport controls</span></span>

<span data-ttu-id="ac527-150">MediaTransportControls の外観のみを変更する場合、既定のコントロールのスタイルとテンプレートのコピーを作成し、変更することができます。</span><span class="sxs-lookup"><span data-stu-id="ac527-150">If you want to modify only the appearance of the MediaTransportControls, you can create a copy of the default control style and template, and modify that.</span></span> <span data-ttu-id="ac527-151">ただし、コントロールの機能を追加または変更する場合は、MediaTransportControls から派生した新しいクラスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-151">However, if you also want to add to or modify the functionality of the control, you need to create a new class that derives from MediaTransportControls.</span></span>

### <a name="re-template-the-control"></a><span data-ttu-id="ac527-152">コントロールのテンプレートの再適用</span><span class="sxs-lookup"><span data-stu-id="ac527-152">Re-template the control</span></span>

<span data-ttu-id="ac527-153">**MediaTransportControls 既定のスタイルとテンプレートをカスタマイズするには**</span><span class="sxs-lookup"><span data-stu-id="ac527-153">**To customize the MediaTransportControls default style and template**</span></span>
1. <span data-ttu-id="ac527-154">「MediaTransportControls スタイルとテンプレート」に示されている既定のスタイルを、プロジェクトの ResourceDictionary にコピーします。</span><span class="sxs-lookup"><span data-stu-id="ac527-154">Copy the default style from MediaTransportControls styles and templates into a ResourceDictionary in your project.</span></span>
2. <span data-ttu-id="ac527-155">次のように、Style に、識別するための x:Key 値を指定します。</span><span class="sxs-lookup"><span data-stu-id="ac527-155">Give the Style an x:Key value to identify it, like this.</span></span>

```xaml
<Style TargetType="MediaTransportControls" x:Key="myTransportControlsStyle">
    <!-- Style content ... -->
</Style>
```

3. <span data-ttu-id="ac527-156">UI に MediaPlayerElement を MediaTransportControls と共に追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-156">Add a MediaPlayerElement with MediaTransportControls to your UI.</span></span>
4. <span data-ttu-id="ac527-157">次に示すように、MediaTransportControls 要素の Style プロパティを、カスタム Style リソースに設定します。</span><span class="sxs-lookup"><span data-stu-id="ac527-157">Set the Style property of the MediaTransportControls element to your custom Style resource, as shown here.</span></span>

```xaml
<MediaPlayerElement AreTransportControlsEnabled="True">
    <MediaPlayerElement.TransportControls>
        <MediaTransportControls Style="{StaticResource myTransportControlsStyle}"/>
    </MediaPlayerElement.TransportControls>
</MediaPlayerElement>
```

<span data-ttu-id="ac527-158">スタイルとテンプレートの変更について詳しくは、「[コントロールのスタイル](/windows/uwp/design/controls-and-patterns/xaml-styles)」と「[コントロール テンプレート](/windows/uwp/design/controls-and-patterns/control-templates)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ac527-158">For more info about modifying styles and templates, see [Styling controls](/windows/uwp/design/controls-and-patterns/xaml-styles) and [Control templates](/windows/uwp/design/controls-and-patterns/control-templates).</span></span>

### <a name="create-a-derived-control"></a><span data-ttu-id="ac527-159">派生コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="ac527-159">Create a derived control</span></span>

<span data-ttu-id="ac527-160">トランスポート コントロールの機能を追加または変更するには、MediaTransportControls から派生した新しいクラスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-160">To add to or modify the functionality of the transport controls, you must create a new class that's derived from MediaTransportControls.</span></span> <span data-ttu-id="ac527-161">[メディア トランスポート コントロールのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=620023)と、このページの他の例では、`CustomMediaTransportControls` という名前の派生クラスが使用されています。</span><span class="sxs-lookup"><span data-stu-id="ac527-161">A derived class called `CustomMediaTransportControls` is shown in the [Media Transport Controls sample](https://go.microsoft.com/fwlink/p/?LinkId=620023) and the remaining examples on this page.</span></span>

<span data-ttu-id="ac527-162">**MediaTransportControls から派生した新しいクラスを作成するには**</span><span class="sxs-lookup"><span data-stu-id="ac527-162">**To create a new class derived from MediaTransportControls**</span></span>
1. <span data-ttu-id="ac527-163">プロジェクトに新しいクラス ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-163">Add a new class file to your project.</span></span>
    - <span data-ttu-id="ac527-164">Visual Studio で、[プロジェクト] の [クラスの追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ac527-164">In Visual Studio, select Project > Add Class.</span></span> <span data-ttu-id="ac527-165">[新しい項目の追加] ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="ac527-165">The Add New Item dialog opens.</span></span>
    - <span data-ttu-id="ac527-166">[新しい項目の追加] ダイアログで、クラス ファイルの名前を入力し、[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ac527-166">In the Add New Item dialog, enter a name for the class file, then click Add.</span></span> <span data-ttu-id="ac527-167">(メディア トランスポート コントロールのサンプルでは、このクラスに `CustomMediaTransportControls` という名前を付けています。)</span><span class="sxs-lookup"><span data-stu-id="ac527-167">(In the Media Transport Controls sample, the class is named `CustomMediaTransportControls`.)</span></span>
2. <span data-ttu-id="ac527-168">このクラスのコードを変更して、MediaTransportControls クラスから派生クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ac527-168">Modify the class code to derive from the MediaTransportControls class.</span></span>

```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
}
```

3. <span data-ttu-id="ac527-169">[  **MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) の既定のスタイルをプロジェクトの [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.resourcedictionary.aspx) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="ac527-169">Copy the default style for [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) into a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.resourcedictionary.aspx) in your project.</span></span> <span data-ttu-id="ac527-170">これが変更する対象のスタイルとテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="ac527-170">This is the style and template you modify.</span></span>
<span data-ttu-id="ac527-171">(メディア トランスポート コントロールのサンプルでは、"Themes" という新しいフォルダーが作成され、generic.xaml という ResourceDictionary ファイルがそのフォルダーに追加されます。)</span><span class="sxs-lookup"><span data-stu-id="ac527-171">(In the Media Transport Controls sample, a new folder called "Themes" is created, and a ResourceDictionary file called generic.xaml is added to it.)</span></span>
4. <span data-ttu-id="ac527-172">スタイルの [**TargetType**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.targettype.aspx) を、新しいカスタム コントロール型に変更します。</span><span class="sxs-lookup"><span data-stu-id="ac527-172">Change the [**TargetType**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.targettype.aspx) of the style to the new custom control type.</span></span> <span data-ttu-id="ac527-173">(サンプルでは、TargetType を `local:CustomMediaTransportControls` に変更しています。)</span><span class="sxs-lookup"><span data-stu-id="ac527-173">(In the sample, the TargetType is changed to `local:CustomMediaTransportControls`.)</span></span>

```xaml
xmlns:local="using:CustomMediaTransportControls">
...
<Style TargetType="local:CustomMediaTransportControls">
```

5. <span data-ttu-id="ac527-174">カスタム クラスの [**DefaultStyleKey**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.defaultstylekey.aspx) を設定します。</span><span class="sxs-lookup"><span data-stu-id="ac527-174">Set the [**DefaultStyleKey**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.defaultstylekey.aspx) of your custom class.</span></span> <span data-ttu-id="ac527-175">これにより、TargetType が `local:CustomMediaTransportControls` である Style を使用するようにカスタム クラスに指示します。</span><span class="sxs-lookup"><span data-stu-id="ac527-175">This tells your custom class to use a Style with a TargetType of `local:CustomMediaTransportControls`.</span></span>

```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
    public CustomMediaTransportControls()
    {
        this.DefaultStyleKey = typeof(CustomMediaTransportControls);
    }
}
```

6. <span data-ttu-id="ac527-176">XAML マークアップに [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) を追加し、この MediaPlayerElement にカスタム トランスポート コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-176">Add a [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) to your XAML markup and add the custom transport controls to it.</span></span> <span data-ttu-id="ac527-177">注意が必要な 1 つの点は、既定のボタンを非表示、表示、無効、有効にする API は、カスタマイズされたテンプレートでも機能するという点です。</span><span class="sxs-lookup"><span data-stu-id="ac527-177">One thing to note is that the APIs to hide, show, disable, and enable the default buttons still work with a customized template.</span></span>

```xaml
<MediaPlayerElement Name="MediaPlayerElement1" AreTransportControlsEnabled="True" Source="video.mp4">
    <MediaPlayerElement.TransportControls>
        <local:CustomMediaTransportControls x:Name="customMTC"
                                            IsFastForwardButtonVisible="True"
                                            IsFastForwardEnabled="True"
                                            IsFastRewindButtonVisible="True"
                                            IsFastRewindEnabled="True"
                                            IsPlaybackRateButtonVisible="True"
                                            IsPlaybackRateEnabled="True"
                                            IsCompact="False">
        </local:CustomMediaTransportControls>
    </MediaPlayerElement.TransportControls>
</MediaPlayerElement>
```

<span data-ttu-id="ac527-178">これで、コントロールのスタイルとテンプレートを変更してカスタム コントロールの外観を更新し、コントロールのコードを変更して動作を更新できました。</span><span class="sxs-lookup"><span data-stu-id="ac527-178">You can now modify the control style and template to update the look of your custom control, and the control code to update its behavior.</span></span>

### <a name="working-with-the-overflow-menu"></a><span data-ttu-id="ac527-179">オーバーフロー メニューを使う</span><span class="sxs-lookup"><span data-stu-id="ac527-179">Working with the overflow menu</span></span>

<span data-ttu-id="ac527-180">MediaTransportControls のコマンド ボタンをオーバーフロー メニューに移動し、ユーザーが必要になるまでに使用頻度の低いコマンドを非表示にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ac527-180">You can move MediaTransportControls command buttons into an overflow menu, so that less commonly used commands are hidden until the user needs them.</span></span>

<span data-ttu-id="ac527-181">MediaTransportControls テンプレートでは、コマンド ボタンは [**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) 要素に含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac527-181">In the MediaTransportControls template, the command buttons are contained in a [**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) element.</span></span> <span data-ttu-id="ac527-182">コマンド バーには、プライマリ コマンドとセカンダリ コマンドの概念があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-182">The command bar has the concept of primary and secondary commands.</span></span> <span data-ttu-id="ac527-183">プライマリ コマンドは、既定でコントロールに表示されるボタンであり、常に表示されます (ボタンを無効または非表示にした場合や十分なスペースがない場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="ac527-183">The primary commands are the buttons that appear in the control by default and are always visible (unless you disable the button, hide the button or there is not enough room).</span></span> <span data-ttu-id="ac527-184">セカンダリ コマンドはオーバーフロー メニューに表示されます。オーバーフロー メニューは、ユーザーが省略記号 (...) ボタンをクリックしたときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="ac527-184">The secondary commands are shown in an overflow menu that appears when a user clicks the ellipsis (…) button.</span></span> <span data-ttu-id="ac527-185">詳しくは、「[アプリ バーとコマンド バー](app-bars.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ac527-185">For more info, see the [App bars and command bars](app-bars.md) article.</span></span>

<span data-ttu-id="ac527-186">コマンド バーのプライマリ コマンドの要素をオーバーフロー メニューに移動するには、XAML コントロール テンプレートを編集する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-186">To move an element from the command bar primary commands to the overflow menu, you need to edit the XAML control template.</span></span>

<span data-ttu-id="ac527-187">**オーバーフロー メニューにコマンドを移動します。**</span><span class="sxs-lookup"><span data-stu-id="ac527-187">**To move a command to the overflow menu:**</span></span>
1. <span data-ttu-id="ac527-188">コントロール テンプレートで、`MediaControlsCommandBar` という名前の CommandBar 要素を検索します。</span><span class="sxs-lookup"><span data-stu-id="ac527-188">In the control template, find the CommandBar element named `MediaControlsCommandBar`.</span></span>
2. <span data-ttu-id="ac527-189">CommandBar の XAML に [**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) セクションを追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-189">Add a [**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) section to the XAML for the CommandBar.</span></span> <span data-ttu-id="ac527-190">このセクションは、[**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) の終了タグの後に配置します。</span><span class="sxs-lookup"><span data-stu-id="ac527-190">Put it after the closing tag for the [**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx).</span></span>

```xaml
<CommandBar x:Name="MediaControlsCommandBar" ... >  
  <CommandBar.PrimaryCommands>
...
    <AppBarButton x:Name='PlaybackRateButton'
                    Style='{StaticResource AppBarButtonStyle}'
                    MediaTransportControlsHelper.DropoutOrder='4'
                    Visibility='Collapsed'>
      <AppBarButton.Icon>
        <FontIcon Glyph="&#xEC57;"/>
      </AppBarButton.Icon>
    </AppBarButton>
...
  </CommandBar.PrimaryCommands>
<!-- Add secondary commands (overflow menu) here -->
  <CommandBar.SecondaryCommands>
    ...
  </CommandBar.SecondaryCommands>
</CommandBar>
```

3. <span data-ttu-id="ac527-191">このメニューにコマンドを表示するには、目的の [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) オブジェクトの XAML を PrimaryCommands から切り取って SecondaryCommands に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="ac527-191">To populate the menu with commands, cut and paste the XAML for the desired [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) objects from the PrimaryCommands to the SecondaryCommands.</span></span> <span data-ttu-id="ac527-192">この例では、`PlaybackRateButton` をオーバーフロー メニューに移動します。</span><span class="sxs-lookup"><span data-stu-id="ac527-192">In this example, we move the `PlaybackRateButton` to the overflow menu.</span></span>

4. <span data-ttu-id="ac527-193">次に示すように、ボタンにラベルを追加し、スタイル情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="ac527-193">Add a label to the button and remove the styling information, as shown here.</span></span>
<span data-ttu-id="ac527-194">オーバーフロー メニューはテキスト ボタンで構成されているため、ボタンにテキスト ラベルを追加し、ボタンの高さと幅を設定するスタイルを削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-194">Because the overflow menu is comprised of text buttons, you must add a text label to the button and also remove the style that sets the height and width of the button.</span></span> <span data-ttu-id="ac527-195">そうしないと、ボタンはオーバーフロー メニューに正しく表示されません。</span><span class="sxs-lookup"><span data-stu-id="ac527-195">Otherwise, it won't appear correctly in the overflow menu.</span></span>

```xaml
<CommandBar.SecondaryCommands>
    <AppBarButton x:Name='PlaybackRateButton'
                  Label='Playback Rate'>
    </AppBarButton>
</CommandBar.SecondaryCommands>
```

> [!IMPORTANT]
> <span data-ttu-id="ac527-196">ボタンをオーバーフロー メニューで使用するには、ボタンを表示して有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-196">You must still make the button visible and enable it in order to use it in the overflow menu.</span></span> <span data-ttu-id="ac527-197">この例では、IsPlaybackRateButtonVisible プロパティが true ではない場合、PlaybackRateButton 要素はオーバーフロー メニューに表示されません。</span><span class="sxs-lookup"><span data-stu-id="ac527-197">In this example, the PlaybackRateButton element isn't visible in the overflow menu unless the IsPlaybackRateButtonVisible property is true.</span></span> <span data-ttu-id="ac527-198">IsPlaybackRateEnabled プロパティが true ではない場合、この要素は有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="ac527-198">It's not enabled unless the IsPlaybackRateEnabled property is true.</span></span> <span data-ttu-id="ac527-199">これらのプロパティの設定は、前のセクションに示されています。</span><span class="sxs-lookup"><span data-stu-id="ac527-199">Setting these properties is shown in the previous section.</span></span>

### <a name="adding-a-custom-button"></a><span data-ttu-id="ac527-200">カスタム ボタンの追加</span><span class="sxs-lookup"><span data-stu-id="ac527-200">Adding a custom button</span></span>

<span data-ttu-id="ac527-201">MediaTransportControls をカスタマイズする理由の 1 つは、コントロールにカスタム コマンドを追加するためです。</span><span class="sxs-lookup"><span data-stu-id="ac527-201">One reason you might want to customize MediaTransportControls is to add a custom command to the control.</span></span> <span data-ttu-id="ac527-202">コマンドをプライマリ コマンドとセカンダリ コマンドのどちらとして追加するかに関係なく、コマンド ボタンを作成し、その動作を変更する手順は同じです。</span><span class="sxs-lookup"><span data-stu-id="ac527-202">Whether you add it as a primary command or a secondary command, the procedure for creating the command button and modifying its behavior is the same.</span></span> <span data-ttu-id="ac527-203">[メディア トランスポート コントロールのサンプル](https://go.microsoft.com/fwlink/p/?LinkId=620023)では、"評価" ボタンをプライマリ コマンドに追加しています。</span><span class="sxs-lookup"><span data-stu-id="ac527-203">In the [Media Transport Controls sample](https://go.microsoft.com/fwlink/p/?LinkId=620023), a "rating" button is added to the primary commands.</span></span>

<span data-ttu-id="ac527-204">**カスタム コマンド ボタンを追加するには**</span><span class="sxs-lookup"><span data-stu-id="ac527-204">**To add a custom command button**</span></span>
1. <span data-ttu-id="ac527-205">AppBarButton オブジェクトを作成し、コントロール テンプレートの CommandBar に追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-205">Create an AppBarButton object and add it to the CommandBar in the control template.</span></span>

```xaml
<AppBarButton x:Name="LikeButton"
              Icon="Like"
              Style="{StaticResource AppBarButtonStyle}"
              MediaTransportControlsHelper.DropoutOrder="3"
              VerticalAlignment="Center" />
```

<span data-ttu-id="ac527-206">適切な場所にコマンド バーに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac527-206">You must add it to the CommandBar in the appropriate location.</span></span> <span data-ttu-id="ac527-207">(詳細については、オーバーフロー メニューのセクションを使用した作業を参照してください)。UI での配置方法については、ボタンは、マークアップの場所によって決まります。</span><span class="sxs-lookup"><span data-stu-id="ac527-207">(For more information, see the Working with the overflow menu section.) How it's positioned in the UI is determined by where the button is in the markup.</span></span> <span data-ttu-id="ac527-208">などの主要なコマンドの最後の要素として表示するには、このボタンをクリックする場合は、主要なコマンド一覧の末尾に追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-208">For example, if you want this button to appear as the last element in the primary commands, add it at the very end of the primary commands list.</span></span>

<span data-ttu-id="ac527-209">ボタンのアイコンをカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ac527-209">You can also customize the icon for the button.</span></span> <span data-ttu-id="ac527-210">詳細については、次を参照してください。、 <a href="https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx"> <b>AppBarButton</b> </a>参照。</span><span class="sxs-lookup"><span data-stu-id="ac527-210">For more information, see the <a href="https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx"><b>AppBarButton</b></a> reference.</span></span>
    

2. <span data-ttu-id="ac527-211">[  **OnApplyTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) のオーバーライドで、テンプレートからボタンを取得し、その [**Click**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントのハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="ac527-211">In the [**OnApplyTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) override, get the button from the template and register a handler for its [**Click**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="ac527-212">次のコードを `CustomMediaTransportControls` クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-212">This code goes in the `CustomMediaTransportControls` class.</span></span>

```csharp
public sealed class CustomMediaTransportControls :  MediaTransportControls
{
    // ...

    protected override void OnApplyTemplate()
    {
        // Find the custom button and create an event handler for its Click event.
        var likeButton = GetTemplateChild("LikeButton") as Button;
        likeButton.Click += LikeButton_Click;
        base.OnApplyTemplate();
    }

    //...
}
```

3. <span data-ttu-id="ac527-213">Click イベント ハンドラーに、ボタンがクリックされたときに発生するアクションを実行するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="ac527-213">Add code to the Click event handler to perform the action that occurs when the button is clicked.</span></span>
<span data-ttu-id="ac527-214">このクラスのコード全体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="ac527-214">Here's the complete code for the class.</span></span>

```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
    public event EventHandler< EventArgs> Liked;

    public CustomMediaTransportControls()
    {
        this.DefaultStyleKey = typeof(CustomMediaTransportControls);
    }

    protected override void OnApplyTemplate()
    {
        // Find the custom button and create an event handler for its Click event.
        var likeButton = GetTemplateChild("LikeButton") as Button;
        likeButton.Click += LikeButton_Click;
        base.OnApplyTemplate();
    }

    private void LikeButton_Click(object sender, RoutedEventArgs e)
    {
        // Raise an event on the custom control when 'like' is clicked.
        var handler = Liked;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
}
```

<span data-ttu-id="ac527-215">**「ような」ボタンが追加のトランスポート コントロールをカスタム メディア**
![カスタム メディアのトランスポート コントロールの追加などのボタン](images/controls/mtc_double_custom_inprod.png)</span><span class="sxs-lookup"><span data-stu-id="ac527-215">**Custom media transport controls with a "Like" button added**
![Custom media transport control with additional like button](images/controls/mtc_double_custom_inprod.png)</span></span>

### <a name="modifying-the-slider"></a><span data-ttu-id="ac527-216">スライダーを変更する</span><span class="sxs-lookup"><span data-stu-id="ac527-216">Modifying the slider</span></span>

<span data-ttu-id="ac527-217">MediaTransportControls の "seek" コントロールは、[**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) 要素により提供されます。</span><span class="sxs-lookup"><span data-stu-id="ac527-217">The "seek" control of the MediaTransportControls is provided by a [**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) element.</span></span> <span data-ttu-id="ac527-218">このコントロールをカスタマイズする 1 つの方法として、シーク動作の細かさを変更できます。</span><span class="sxs-lookup"><span data-stu-id="ac527-218">One way you can customize it is to change the granularity of the seek behavior.</span></span>

<span data-ttu-id="ac527-219">既定のシーク スライダーは 100 の部分に分かれているため、シーク動作はその数のセクションに限定されます。</span><span class="sxs-lookup"><span data-stu-id="ac527-219">The default seek slider is divided into 100 parts, so the seek behavior is limited to that many sections.</span></span> <span data-ttu-id="ac527-220">シーク スライダーの細かさを変更するには、[**MediaPlayerElement.MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediaopened.aspx) イベント ハンドラーで XAML ビジュアル ツリーから Slider を取得します。</span><span class="sxs-lookup"><span data-stu-id="ac527-220">You can change the granularity of the seek slider by getting the Slider from the XAML visual tree in your [**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediaopened.aspx) event handler on [**MediaPlayerElement.MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx).</span></span> <span data-ttu-id="ac527-221">この例では、[**VisualTreeHelper**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.visualtreehelper.aspx) を使って Slider への参照を取得し、メディアが 120 分より長い場合に、スライダーの既定のステップ間隔を 1% から 0.1% (1000 ステップ) に変更する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="ac527-221">This example shows how to use [**VisualTreeHelper**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.visualtreehelper.aspx) to get a reference to the Slider, then change the default step frequency of the slider from 1% to 0.1% (1000 steps) if the media is longer than 120 minutes.</span></span> <span data-ttu-id="ac527-222">MediaPlayerElement には、`MediaPlayerElement1` という名前が付けられています。</span><span class="sxs-lookup"><span data-stu-id="ac527-222">The MediaPlayerElement is named `MediaPlayerElement1`.</span></span>

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
  MediaPlayerElement1.MediaPlayer.MediaOpened += MediaPlayerElement_MediaPlayer_MediaOpened;
  base.OnNavigatedTo(e);
}

private void MediaPlayerElement_MediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
{
  FrameworkElement transportControlsTemplateRoot = (FrameworkElement)VisualTreeHelper.GetChild(MediaPlayerElement1.TransportControls, 0);
  Slider sliderControl = (Slider)transportControlsTemplateRoot.FindName("ProgressSlider");
  if (sliderControl != null && MediaPlayerElement1.NaturalDuration.TimeSpan.TotalMinutes > 120)
  {
    // Default is 1%. Change to 0.1% for more granular seeking.
    sliderControl.StepFrequency = 0.1;
  }
}
```
## <a name="related-articles"></a><span data-ttu-id="ac527-223">関連記事</span><span class="sxs-lookup"><span data-stu-id="ac527-223">Related articles</span></span>

- [<span data-ttu-id="ac527-224">メディア再生</span><span class="sxs-lookup"><span data-stu-id="ac527-224">Media playback</span></span>](media-playback.md)
