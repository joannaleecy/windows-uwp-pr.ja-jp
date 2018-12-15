---
Description: The media player has customizable XAML transport controls to manage control of audio and video content.
title: カスタム メディア トランスポート コントロールを作成する
ms.assetid: 6643A108-A6EB-42BC-B800-22EABD7B731B
label: Create custom media transport controls
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4878ce99d449674243c8a3f7360a9e9b0dd6db19
ms.sourcegitcommit: 1cf04b0b1bd7623cd7f6067b8392dce4372f2c69
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/14/2018
ms.locfileid: "8970995"
---
# <a name="create-custom-transport-controls"></a><span data-ttu-id="85d39-103">カスタム トランスポート コントロールを作成する</span><span class="sxs-lookup"><span data-stu-id="85d39-103">Create custom transport controls</span></span>



<span data-ttu-id="85d39-104">MediaPlayerElement には、ユニバーサル Windows プラットフォーム (UWP) アプリ内でオーディオおよびビデオ コンテンツのコントロールを管理するためのカスタマイズ可能な XAML トランスポート コントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="85d39-104">MediaPlayerElement has customizable XAML transport controls to manage control of audio and video content within a Universal Windows Platform (UWP) app.</span></span> <span data-ttu-id="85d39-105">ここでは、MediaTransportControls テンプレートをカスタマイズする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="85d39-105">Here, we demonstrate how to customize the MediaTransportControls template.</span></span> <span data-ttu-id="85d39-106">オーバーフロー メニューの操作方法、カスタム ボタンの追加方法、スライダーの変更方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="85d39-106">We’ll show you how to work with the overflow menu, add a custom button and modify the slider.</span></span>

> <span data-ttu-id="85d39-107">**重要な API**: [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx)、[MediaPlayerElement.AreTransportControlsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aretransportcontrolsenabled.aspx)、[MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677)</span><span class="sxs-lookup"><span data-stu-id="85d39-107">**Important APIs**: [MediaPlayerElement](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx), [MediaPlayerElement.AreTransportControlsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aretransportcontrolsenabled.aspx), [MediaTransportControls](https://msdn.microsoft.com/library/windows/apps/dn278677)</span></span>

<span data-ttu-id="85d39-108">始める前に、MediaPlayerElement クラスと MediaTransportControls クラスについて理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-108">Before starting, you should be familiar with the MediaPlayerElement and the MediaTransportControls classes.</span></span> <span data-ttu-id="85d39-109">詳しくは、「MediaPlayerElement コントロール ガイド」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85d39-109">For more info, see the MediaPlayerElement control guide.</span></span>

> [!TIP]
> <span data-ttu-id="85d39-110">このトピックの例は、[メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)を基にしています。</span><span class="sxs-lookup"><span data-stu-id="85d39-110">The examples in this topic are based on the [Media Transport Controls sample](http://go.microsoft.com/fwlink/p/?LinkId=620023).</span></span> <span data-ttu-id="85d39-111">サンプルをダウンロードし、詳細なコードを参照して実行することができます。</span><span class="sxs-lookup"><span data-stu-id="85d39-111">You can download the sample to view and run the completed code.</span></span>

> [!NOTE]
> <span data-ttu-id="85d39-112">**MediaPlayerElement** は Windows 10 バージョン 1607 以降でのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="85d39-112">**MediaPlayerElement** is only available in Windows 10, version 1607 and up.</span></span> <span data-ttu-id="85d39-113">Windows 10 の以前のバージョン用にアプリを開発する場合は、代わりに [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-113">If you are developing an app for an earlier version of Windows 10 you will need to use [**MediaElement**](https://msdn.microsoft.com/library/windows/apps/br242926) instead.</span></span> <span data-ttu-id="85d39-114">このページのすべての例は **MediaElement**でも動作します。</span><span class="sxs-lookup"><span data-stu-id="85d39-114">All of the examples on this page work with **MediaElement** as well.</span></span>

## <a name="when-should-you-customize-the-template"></a><span data-ttu-id="85d39-115">テンプレートをカスタマイズする必要がある状況</span><span class="sxs-lookup"><span data-stu-id="85d39-115">When should you customize the template?</span></span>

<span data-ttu-id="85d39-116">**MediaPlayerElement** には、変更しなくてもほとんどのビデオおよびオーディオ再生アプリで正常に動作するように設計されているトランスポート コントロールが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-116">**MediaPlayerElement** has built-in transport controls that are designed to work well without modification in most video and audio playback apps.</span></span> <span data-ttu-id="85d39-117">これらのコントロールは、[**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) クラスによって提供され、再生、停止、メディアのナビゲーション、音量の調節、全画面表示の切り替え、2 台目のデバイスへのキャスト、字幕の有効化、オーディオ トラックの切り替え、再生速度の調整を行うためのボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-117">They’re provided by the [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) class and include buttons to play, stop, and navigate media, adjust volume, toggle full screen, cast to a second device, enable captions, switch audio tracks, and adjust the playback rate.</span></span> <span data-ttu-id="85d39-118">MediaTransportControls には、各ボタンを表示し、有効にするかどうかを制御できるプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="85d39-118">MediaTransportControls has properties that let you control whether each button is shown and enabled.</span></span> <span data-ttu-id="85d39-119">[**IsCompact**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.iscompact.aspx) プロパティを設定して、コントロールを 1 行に表示するか、2 行に表示するかを指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="85d39-119">You can also set the [**IsCompact**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.iscompact.aspx) property to specify whether the controls are shown in one row or two.</span></span>

<span data-ttu-id="85d39-120">ただし、コントロールの外観をさらにカスタマイズしたり、動作を変更したりする必要があるシナリオも考えられます。</span><span class="sxs-lookup"><span data-stu-id="85d39-120">However, there may be scenarios where you need to further customize the look of the control or change its behavior.</span></span> <span data-ttu-id="85d39-121">例をいくつか紹介します。</span><span class="sxs-lookup"><span data-stu-id="85d39-121">Here are some examples:</span></span>
- <span data-ttu-id="85d39-122">アイコン、スライダーの動作、色を変更する。</span><span class="sxs-lookup"><span data-stu-id="85d39-122">Change the icons, slider behavior, and colors.</span></span>
- <span data-ttu-id="85d39-123">使用頻度の低いコマンド ボタンをオーバーフロー メニューに移動する。</span><span class="sxs-lookup"><span data-stu-id="85d39-123">Move less commonly used command buttons into an overflow menu.</span></span>
- <span data-ttu-id="85d39-124">コントロールのサイズが変更されたときに、コマンドをドロップ アウトする順序を変更する。</span><span class="sxs-lookup"><span data-stu-id="85d39-124">Change the order in which commands drop out when the control is resized.</span></span>
- <span data-ttu-id="85d39-125">既定のセットには含まれていないコマンド ボタンを提供する。</span><span class="sxs-lookup"><span data-stu-id="85d39-125">Provide a command button that’s not in the default set.</span></span>

> [!NOTE]
> <span data-ttu-id="85d39-126">画面に表示されているボタンは、画面に十分なスペースがない場合、組み込みのトランスポート コントロールから定義済みの順序でドロップ アウトします。</span><span class="sxs-lookup"><span data-stu-id="85d39-126">The buttons visible on screen will drop out of the built-in transport controls in a predefined order if there is not enough room on screen.</span></span> <span data-ttu-id="85d39-127">この順序を変更するか、オーバーフロー メニューに収まらないコマンドを配置するには、コントロールをカスタマイズする必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-127">To change this ordering or put commands that don't fit into an overflow menu, you will need to customize the controls.</span></span>

<span data-ttu-id="85d39-128">コントロールの外観をカスタマイズするには、既定のテンプレートを変更します。</span><span class="sxs-lookup"><span data-stu-id="85d39-128">You can customize the appearance of the control by modifying the default template.</span></span> <span data-ttu-id="85d39-129">コントロールの動作を変更したり、新しいコマンドを追加したりするには、MediaTransportControls から派生したカスタム コントロールを作成できます。</span><span class="sxs-lookup"><span data-stu-id="85d39-129">To modify the control's behavior or add new commands, you can create a custom control that's derived from MediaTransportControls.</span></span>

> [!TIP]
> <span data-ttu-id="85d39-130">カスタマイズ可能なコントロール テンプレートは XAML プラットフォームの強力な機能ですが、考慮すべき影響もあります。</span><span class="sxs-lookup"><span data-stu-id="85d39-130">Customizable control templates are a powerful feature of the XAML platform, but there are also consequences that you should take into consideration.</span></span> <span data-ttu-id="85d39-131">テンプレートをカスタマイズすると、アプリの静的な部分となるため、Microsoft によって行われるプラットフォームの更新を受け取らなくなります。</span><span class="sxs-lookup"><span data-stu-id="85d39-131">When you customize a template, it becomes a static part of your app and therefore will not receive any platform updates that are made to the template by Microsoft.</span></span> <span data-ttu-id="85d39-132">Microsoft によってテンプレートの更新が加えられた場合、更新されたテンプレートを利用するには、新しいテンプレートを取得して再変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-132">If template updates are made by Microsoft, you should take the new template and re-modify it in order to get the benefits of the updated template.</span></span>

## <a name="template-structure"></a><span data-ttu-id="85d39-133">テンプレートの構造</span><span class="sxs-lookup"><span data-stu-id="85d39-133">Template structure</span></span>

<span data-ttu-id="85d39-134">[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.controltemplate.aspx) は既定のスタイルに含まれます。</span><span class="sxs-lookup"><span data-stu-id="85d39-134">The [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.controltemplate.aspx) is part of the default style.</span></span> <span data-ttu-id="85d39-135">この既定のスタイルをプロジェクトにコピーして変更できます。</span><span class="sxs-lookup"><span data-stu-id="85d39-135">You can copy this default style into your project to modify it.</span></span> <span data-ttu-id="85d39-136">ControlTemplate は、他の XAML コントロール テンプレートと同様のセクションに分かれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-136">The ControlTemplate is divided into sections similar to other XAML control templates.</span></span>
- <span data-ttu-id="85d39-137">テンプレートの最初のセクションには、MediaTransportControls のさまざまなコンポーネントの [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) 定義が含まれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-137">The first section of the template contains the [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) definitions for the various components of the MediaTransportControls.</span></span>
- <span data-ttu-id="85d39-138">2 番目のセクションでは、MediaTransportControls が使うさまざまな表示状態が定義されています。</span><span class="sxs-lookup"><span data-stu-id="85d39-138">The second section defines the various visual states that are used by the MediaTransportControls.</span></span>
- <span data-ttu-id="85d39-139">3 番目のセクションには、さまざまな MediaTransportControls 要素をまとめて保持し、コンポーネントのレイアウトを定義する [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-139">The third section contains the [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) that holds that various MediaTransportControls elements together and defines how the components are laid out.</span></span>

> [!NOTE]
> <span data-ttu-id="85d39-140">テンプレートの変更について詳しくは、「[コントロール テンプレート]()」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85d39-140">For more info about modifying templates, see [Control templates]().</span></span> <span data-ttu-id="85d39-141">テキスト エディターか、IDE の同様のエディターを使って、\(*Program Files*)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\\(*SDK version*)\Generic にある XAML ファイルを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="85d39-141">You can use a text editor or similar editors in your IDE to open the XAML files in \(*Program Files*)\Windows Kits\10\DesignTime\CommonConfiguration\Neutral\UAP\\(*SDK version*)\Generic.</span></span> <span data-ttu-id="85d39-142">各コントロールの既定のスタイルとテンプレートは、**generic.xaml** ファイルで定義されています。</span><span class="sxs-lookup"><span data-stu-id="85d39-142">The default style and template for each control is defined in the **generic.xaml** file.</span></span> <span data-ttu-id="85d39-143">MediaTransportControls テンプレートは、generic.xaml で "MediaTransportControls" を検索すると見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="85d39-143">You can find the MediaTransportControls template in generic.xaml by searching for "MediaTransportControls".</span></span>

<span data-ttu-id="85d39-144">以下のセクションでは、トランスポート コントロールの主な要素のいくつかをカスタマイズする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="85d39-144">In the following sections, you learn how to customize several of the main elements of the transport controls:</span></span>
- <span data-ttu-id="85d39-145">[**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx): ユーザーがメディアをスクラブし、進行状況も表示できるようにします。</span><span class="sxs-lookup"><span data-stu-id="85d39-145">[**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx): allows a user to scrub through their media and also displays progress</span></span>
- <span data-ttu-id="85d39-146">[**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx): すべてのボタンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-146">[**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx): contains all of the buttons.</span></span>
<span data-ttu-id="85d39-147">詳しくは、MediaTransportControls リファレンス トピックの構造セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85d39-147">For more info, see the Anatomy section of the MediaTransportControls reference topic.</span></span>

## <a name="customize-the-transport-controls"></a><span data-ttu-id="85d39-148">トランスポート コントロールをカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="85d39-148">Customize the transport controls</span></span>

<span data-ttu-id="85d39-149">MediaTransportControls の外観のみを変更する場合、既定のコントロールのスタイルとテンプレートのコピーを作成し、変更することができます。</span><span class="sxs-lookup"><span data-stu-id="85d39-149">If you want to modify only the appearance of the MediaTransportControls, you can create a copy of the default control style and template, and modify that.</span></span> <span data-ttu-id="85d39-150">ただし、コントロールの機能を追加または変更する場合は、MediaTransportControls から派生した新しいクラスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-150">However, if you also want to add to or modify the functionality of the control, you need to create a new class that derives from MediaTransportControls.</span></span>

### <a name="re-template-the-control"></a><span data-ttu-id="85d39-151">コントロールのテンプレートの再適用</span><span class="sxs-lookup"><span data-stu-id="85d39-151">Re-template the control</span></span>

**<span data-ttu-id="85d39-152">MediaTransportControls の既定のスタイルとテンプレートをカスタマイズするには</span><span class="sxs-lookup"><span data-stu-id="85d39-152">To customize the MediaTransportControls default style and template</span></span>**
1. <span data-ttu-id="85d39-153">「MediaTransportControls スタイルとテンプレート」に示されている既定のスタイルを、プロジェクトの ResourceDictionary にコピーします。</span><span class="sxs-lookup"><span data-stu-id="85d39-153">Copy the default style from MediaTransportControls styles and templates into a ResourceDictionary in your project.</span></span>
2. <span data-ttu-id="85d39-154">次のように、Style に、識別するための x:Key 値を指定します。</span><span class="sxs-lookup"><span data-stu-id="85d39-154">Give the Style an x:Key value to identify it, like this.</span></span>

```xaml
<Style TargetType="MediaTransportControls" x:Key="myTransportControlsStyle">
    <!-- Style content ... -->
</Style>
```

3. <span data-ttu-id="85d39-155">UI に MediaPlayerElement を MediaTransportControls と共に追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-155">Add a MediaPlayerElement with MediaTransportControls to your UI.</span></span>
4. <span data-ttu-id="85d39-156">次に示すように、MediaTransportControls 要素の Style プロパティを、カスタム Style リソースに設定します。</span><span class="sxs-lookup"><span data-stu-id="85d39-156">Set the Style property of the MediaTransportControls element to your custom Style resource, as shown here.</span></span>

```xaml
<MediaPlayerElement AreTransportControlsEnabled="True">
    <MediaPlayerElement.TransportControls>
        <MediaTransportControls Style="{StaticResource myTransportControlsStyle}"/>
    </MediaPlayerElement.TransportControls>
</MediaPlayerElement>
```

<span data-ttu-id="85d39-157">スタイルとテンプレートの変更について詳しくは、「[コントロールのスタイル]()」と「[コントロール テンプレート]()」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85d39-157">For more info about modifying styles and templates, see [Styling controls]() and [Control templates]().</span></span>

### <a name="create-a-derived-control"></a><span data-ttu-id="85d39-158">派生コントロールの作成</span><span class="sxs-lookup"><span data-stu-id="85d39-158">Create a derived control</span></span>

<span data-ttu-id="85d39-159">トランスポート コントロールの機能を追加または変更するには、MediaTransportControls から派生した新しいクラスを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-159">To add to or modify the functionality of the transport controls, you must create a new class that's derived from MediaTransportControls.</span></span> <span data-ttu-id="85d39-160">[メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)と、このページの他の例では、`CustomMediaTransportControls` という名前の派生クラスが使用されています。</span><span class="sxs-lookup"><span data-stu-id="85d39-160">A derived class called `CustomMediaTransportControls` is shown in the [Media Transport Controls sample](http://go.microsoft.com/fwlink/p/?LinkId=620023) and the remaining examples on this page.</span></span>

**<span data-ttu-id="85d39-161">MediaTransportControls から派生した新しいクラスを作成するには</span><span class="sxs-lookup"><span data-stu-id="85d39-161">To create a new class derived from MediaTransportControls</span></span>**
1. <span data-ttu-id="85d39-162">プロジェクトに新しいクラス ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-162">Add a new class file to your project.</span></span>
    - <span data-ttu-id="85d39-163">Visual Studio で、[プロジェクト] の [クラスの追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="85d39-163">In Visual Studio, select Project > Add Class.</span></span> <span data-ttu-id="85d39-164">[新しい項目の追加] ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="85d39-164">The Add New Item dialog opens.</span></span>
    - <span data-ttu-id="85d39-165">[新しい項目の追加] ダイアログで、クラス ファイルの名前を入力し、[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="85d39-165">In the Add New Item dialog, enter a name for the class file, then click Add.</span></span> <span data-ttu-id="85d39-166">(メディア トランスポート コントロールのサンプルでは、このクラスに `CustomMediaTransportControls` という名前を付けています。)</span><span class="sxs-lookup"><span data-stu-id="85d39-166">(In the Media Transport Controls sample, the class is named `CustomMediaTransportControls`.)</span></span>
2. <span data-ttu-id="85d39-167">このクラスのコードを変更して、MediaTransportControls クラスから派生クラスを作成します。</span><span class="sxs-lookup"><span data-stu-id="85d39-167">Modify the class code to derive from the MediaTransportControls class.</span></span>

```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
}
```

3. <span data-ttu-id="85d39-168">[**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) の既定のスタイルをプロジェクトの [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.resourcedictionary.aspx) にコピーします。</span><span class="sxs-lookup"><span data-stu-id="85d39-168">Copy the default style for [**MediaTransportControls**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) into a [ResourceDictionary](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.resourcedictionary.aspx) in your project.</span></span> <span data-ttu-id="85d39-169">これが変更する対象のスタイルとテンプレートです。</span><span class="sxs-lookup"><span data-stu-id="85d39-169">This is the style and template you modify.</span></span>
<span data-ttu-id="85d39-170">(メディア トランスポート コントロールのサンプルでは、"Themes" という新しいフォルダーが作成され、generic.xaml という ResourceDictionary ファイルがそのフォルダーに追加されます。)</span><span class="sxs-lookup"><span data-stu-id="85d39-170">(In the Media Transport Controls sample, a new folder called "Themes" is created, and a ResourceDictionary file called generic.xaml is added to it.)</span></span>
4. <span data-ttu-id="85d39-171">スタイルの [**TargetType**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.targettype.aspx) を、新しいカスタム コントロール型に変更します。</span><span class="sxs-lookup"><span data-stu-id="85d39-171">Change the [**TargetType**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.targettype.aspx) of the style to the new custom control type.</span></span> <span data-ttu-id="85d39-172">(サンプルでは、TargetType を `local:CustomMediaTransportControls` に変更しています。)</span><span class="sxs-lookup"><span data-stu-id="85d39-172">(In the sample, the TargetType is changed to `local:CustomMediaTransportControls`.)</span></span>

```xaml
xmlns:local="using:CustomMediaTransportControls">
...
<Style TargetType="local:CustomMediaTransportControls">
```

5. <span data-ttu-id="85d39-173">カスタム クラスの [**DefaultStyleKey**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.defaultstylekey.aspx) を設定します。</span><span class="sxs-lookup"><span data-stu-id="85d39-173">Set the [**DefaultStyleKey**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.defaultstylekey.aspx) of your custom class.</span></span> <span data-ttu-id="85d39-174">これにより、TargetType が `local:CustomMediaTransportControls` である Style を使用するようにカスタム クラスに指示します。</span><span class="sxs-lookup"><span data-stu-id="85d39-174">This tells your custom class to use a Style with a TargetType of `local:CustomMediaTransportControls`.</span></span>

```csharp
public sealed class CustomMediaTransportControls : MediaTransportControls
{
    public CustomMediaTransportControls()
    {
        this.DefaultStyleKey = typeof(CustomMediaTransportControls);
    }
}
```

6. <span data-ttu-id="85d39-175">XAML マークアップに [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) を追加し、この MediaPlayerElement にカスタム トランスポート コントロールを追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-175">Add a [**MediaPlayerElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) to your XAML markup and add the custom transport controls to it.</span></span> <span data-ttu-id="85d39-176">注意が必要な 1 つの点は、既定のボタンを非表示、表示、無効、有効にする API は、カスタマイズされたテンプレートでも機能するという点です。</span><span class="sxs-lookup"><span data-stu-id="85d39-176">One thing to note is that the APIs to hide, show, disable, and enable the default buttons still work with a customized template.</span></span>

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

<span data-ttu-id="85d39-177">これで、コントロールのスタイルとテンプレートを変更してカスタム コントロールの外観を更新し、コントロールのコードを変更して動作を更新できました。</span><span class="sxs-lookup"><span data-stu-id="85d39-177">You can now modify the control style and template to update the look of your custom control, and the control code to update its behavior.</span></span>

### <a name="working-with-the-overflow-menu"></a><span data-ttu-id="85d39-178">オーバーフロー メニューを使う</span><span class="sxs-lookup"><span data-stu-id="85d39-178">Working with the overflow menu</span></span>

<span data-ttu-id="85d39-179">MediaTransportControls のコマンド ボタンをオーバーフロー メニューに移動し、ユーザーが必要になるまでに使用頻度の低いコマンドを非表示にすることができます。</span><span class="sxs-lookup"><span data-stu-id="85d39-179">You can move MediaTransportControls command buttons into an overflow menu, so that less commonly used commands are hidden until the user needs them.</span></span>

<span data-ttu-id="85d39-180">MediaTransportControls テンプレートでは、コマンド ボタンは [**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) 要素に含まれています。</span><span class="sxs-lookup"><span data-stu-id="85d39-180">In the MediaTransportControls template, the command buttons are contained in a [**CommandBar**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) element.</span></span> <span data-ttu-id="85d39-181">コマンド バーには、プライマリ コマンドとセカンダリ コマンドの概念があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-181">The command bar has the concept of primary and secondary commands.</span></span> <span data-ttu-id="85d39-182">プライマリ コマンドは、既定でコントロールに表示されるボタンであり、常に表示されます (ボタンを無効または非表示にした場合や十分なスペースがない場合を除く)。</span><span class="sxs-lookup"><span data-stu-id="85d39-182">The primary commands are the buttons that appear in the control by default and are always visible (unless you disable the button, hide the button or there is not enough room).</span></span> <span data-ttu-id="85d39-183">セカンダリ コマンドはオーバーフロー メニューに表示されます。オーバーフロー メニューは、ユーザーが省略記号 (...) ボタンをクリックしたときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="85d39-183">The secondary commands are shown in an overflow menu that appears when a user clicks the ellipsis (…) button.</span></span> <span data-ttu-id="85d39-184">詳しくは、「[アプリ バーとコマンド バー](app-bars.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="85d39-184">For more info, see the [App bars and command bars](app-bars.md) article.</span></span>

<span data-ttu-id="85d39-185">コマンド バーのプライマリ コマンドの要素をオーバーフロー メニューに移動するには、XAML コントロール テンプレートを編集する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-185">To move an element from the command bar primary commands to the overflow menu, you need to edit the XAML control template.</span></span>

**<span data-ttu-id="85d39-186">オーバーフロー メニューにコマンドを移動するには</span><span class="sxs-lookup"><span data-stu-id="85d39-186">To move a command to the overflow menu:</span></span>**
1. <span data-ttu-id="85d39-187">コントロール テンプレートで、`MediaControlsCommandBar` という名前の CommandBar 要素を検索します。</span><span class="sxs-lookup"><span data-stu-id="85d39-187">In the control template, find the CommandBar element named `MediaControlsCommandBar`.</span></span>
2. <span data-ttu-id="85d39-188">CommandBar の XAML に [**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) セクションを追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-188">Add a [**SecondaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.secondarycommands.aspx) section to the XAML for the CommandBar.</span></span> <span data-ttu-id="85d39-189">このセクションは、[**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx) の終了タグの後に配置します。</span><span class="sxs-lookup"><span data-stu-id="85d39-189">Put it after the closing tag for the [**PrimaryCommands**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.primarycommands.aspx).</span></span>

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

3. <span data-ttu-id="85d39-190">このメニューにコマンドを表示するには、目的の [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) オブジェクトの XAML を PrimaryCommands から切り取って SecondaryCommands に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="85d39-190">To populate the menu with commands, cut and paste the XAML for the desired [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) objects from the PrimaryCommands to the SecondaryCommands.</span></span> <span data-ttu-id="85d39-191">この例では、`PlaybackRateButton` をオーバーフロー メニューに移動します。</span><span class="sxs-lookup"><span data-stu-id="85d39-191">In this example, we move the `PlaybackRateButton` to the overflow menu.</span></span>

4. <span data-ttu-id="85d39-192">次に示すように、ボタンにラベルを追加し、スタイル情報を削除します。</span><span class="sxs-lookup"><span data-stu-id="85d39-192">Add a label to the button and remove the styling information, as shown here.</span></span>
<span data-ttu-id="85d39-193">オーバーフロー メニューはテキスト ボタンで構成されているため、ボタンにテキスト ラベルを追加し、ボタンの高さと幅を設定するスタイルを削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-193">Because the overflow menu is comprised of text buttons, you must add a text label to the button and also remove the style that sets the height and width of the button.</span></span> <span data-ttu-id="85d39-194">そうしないと、ボタンはオーバーフロー メニューに正しく表示されません。</span><span class="sxs-lookup"><span data-stu-id="85d39-194">Otherwise, it won't appear correctly in the overflow menu.</span></span>

```xaml
<CommandBar.SecondaryCommands>
    <AppBarButton x:Name='PlaybackRateButton'
                  Label='Playback Rate'>
    </AppBarButton>
</CommandBar.SecondaryCommands>
```

> [!IMPORTANT]
> <span data-ttu-id="85d39-195">ボタンをオーバーフロー メニューで使用するには、ボタンを表示して有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="85d39-195">You must still make the button visible and enable it in order to use it in the overflow menu.</span></span> <span data-ttu-id="85d39-196">この例では、IsPlaybackRateButtonVisible プロパティが true ではない場合、PlaybackRateButton 要素はオーバーフロー メニューに表示されません。</span><span class="sxs-lookup"><span data-stu-id="85d39-196">In this example, the PlaybackRateButton element isn't visible in the overflow menu unless the IsPlaybackRateButtonVisible property is true.</span></span> <span data-ttu-id="85d39-197">IsPlaybackRateEnabled プロパティが true ではない場合、この要素は有効ではありません。</span><span class="sxs-lookup"><span data-stu-id="85d39-197">It's not enabled unless the IsPlaybackRateEnabled property is true.</span></span> <span data-ttu-id="85d39-198">これらのプロパティの設定は、前のセクションに示されています。</span><span class="sxs-lookup"><span data-stu-id="85d39-198">Setting these properties is shown in the previous section.</span></span>

### <a name="adding-a-custom-button"></a><span data-ttu-id="85d39-199">カスタム ボタンの追加</span><span class="sxs-lookup"><span data-stu-id="85d39-199">Adding a custom button</span></span>

<span data-ttu-id="85d39-200">MediaTransportControls をカスタマイズする理由の 1 つは、コントロールにカスタム コマンドを追加するためです。</span><span class="sxs-lookup"><span data-stu-id="85d39-200">One reason you might want to customize MediaTransportControls is to add a custom command to the control.</span></span> <span data-ttu-id="85d39-201">コマンドをプライマリ コマンドとセカンダリ コマンドのどちらとして追加するかに関係なく、コマンド ボタンを作成し、その動作を変更する手順は同じです。</span><span class="sxs-lookup"><span data-stu-id="85d39-201">Whether you add it as a primary command or a secondary command, the procedure for creating the command button and modifying its behavior is the same.</span></span> <span data-ttu-id="85d39-202">[メディア トランスポート コントロールのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620023)では、"評価" ボタンをプライマリ コマンドに追加しています。</span><span class="sxs-lookup"><span data-stu-id="85d39-202">In the [Media Transport Controls sample](http://go.microsoft.com/fwlink/p/?LinkId=620023), a "rating" button is added to the primary commands.</span></span>

**<span data-ttu-id="85d39-203">カスタム コマンド ボタンを追加するには</span><span class="sxs-lookup"><span data-stu-id="85d39-203">To add a custom command button</span></span>**
1. <span data-ttu-id="85d39-204">AppBarButton オブジェクトを作成し、コントロール テンプレートの CommandBar に追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-204">Create an AppBarButton object and add it to the CommandBar in the control template.</span></span>

```xaml
<AppBarButton x:Name="LikeButton"
              Icon="Like"
              Style="{StaticResource AppBarButtonStyle}"
              MediaTransportControlsHelper.DropoutOrder="3"
              VerticalAlignment="Center" />
```

    You must add it to the CommandBar in the appropriate location. (For more info, see the Working with the overflow menu section.) How it's positioned in the UI is determined by where the button is in the markup. For example, if you want this button to appear as the last element in the primary commands, add it at the very end of the primary commands list.

    You can also customize the icon for the button. For more info, see the [**AppBarButton**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx) reference.

2. <span data-ttu-id="85d39-205">[**OnApplyTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) のオーバーライドで、テンプレートからボタンを取得し、その [**Click**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベントのハンドラーを登録します。</span><span class="sxs-lookup"><span data-stu-id="85d39-205">In the [**OnApplyTemplate**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.onapplytemplate.aspx) override, get the button from the template and register a handler for its [**Click**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event.</span></span> <span data-ttu-id="85d39-206">次のコードを `CustomMediaTransportControls` クラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-206">This code goes in the `CustomMediaTransportControls` class.</span></span>

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

3. <span data-ttu-id="85d39-207">Click イベント ハンドラーに、ボタンがクリックされたときに発生するアクションを実行するコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="85d39-207">Add code to the Click event handler to perform the action that occurs when the button is clicked.</span></span>
<span data-ttu-id="85d39-208">このクラスのコード全体を次に示します。</span><span class="sxs-lookup"><span data-stu-id="85d39-208">Here's the complete code for the class.</span></span>

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

<span data-ttu-id="85d39-209">**"いいね" ボタンが追加された、カスタム メディア トランスポート コントロール**
![いいねボタンが追加されたカスタム メディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="85d39-209">**Custom media transport controls with a "Like" button added**
![Custom media transport control with additional like button</span></span>](images/controls/mtc_double_custom_inprod.png)

### <a name="modifying-the-slider"></a><span data-ttu-id="85d39-210">スライダーを変更する</span><span class="sxs-lookup"><span data-stu-id="85d39-210">Modifying the slider</span></span>

<span data-ttu-id="85d39-211">MediaTransportControls の "seek" コントロールは、[**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) 要素により提供されます。</span><span class="sxs-lookup"><span data-stu-id="85d39-211">The "seek" control of the MediaTransportControls is provided by a [**Slider**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) element.</span></span> <span data-ttu-id="85d39-212">このコントロールをカスタマイズする 1 つの方法として、シーク動作の細かさを変更できます。</span><span class="sxs-lookup"><span data-stu-id="85d39-212">One way you can customize it is to change the granularity of the seek behavior.</span></span>

<span data-ttu-id="85d39-213">既定のシーク スライダーは 100 の部分に分かれているため、シーク動作はその数のセクションに限定されます。</span><span class="sxs-lookup"><span data-stu-id="85d39-213">The default seek slider is divided into 100 parts, so the seek behavior is limited to that many sections.</span></span> <span data-ttu-id="85d39-214">シーク スライダーの細かさを変更するには、[**MediaPlayerElement.MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx) の [**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediaopened.aspx) イベント ハンドラーで XAML ビジュアル ツリーから Slider を取得します。</span><span class="sxs-lookup"><span data-stu-id="85d39-214">You can change the granularity of the seek slider by getting the Slider from the XAML visual tree in your [**MediaOpened**](https://msdn.microsoft.com/library/windows/apps/windows.media.playback.mediaplayer.mediaopened.aspx) event handler on [**MediaPlayerElement.MediaPlayer**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.mediaplayerelement.aspx).</span></span> <span data-ttu-id="85d39-215">この例では、[**VisualTreeHelper**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.visualtreehelper.aspx) を使って Slider への参照を取得し、メディアが 120 分より長い場合に、スライダーの既定のステップ間隔を 1% から 0.1% (1000 ステップ) に変更する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="85d39-215">This example shows how to use [**VisualTreeHelper**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.visualtreehelper.aspx) to get a reference to the Slider, then change the default step frequency of the slider from 1% to 0.1% (1000 steps) if the media is longer than 120 minutes.</span></span> <span data-ttu-id="85d39-216">MediaPlayerElement には、`MediaPlayerElement1` という名前が付けられています。</span><span class="sxs-lookup"><span data-stu-id="85d39-216">The MediaPlayerElement is named `MediaPlayerElement1`.</span></span>

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
## <a name="related-articles"></a><span data-ttu-id="85d39-217">関連記事</span><span class="sxs-lookup"><span data-stu-id="85d39-217">Related articles</span></span>

- [<span data-ttu-id="85d39-218">メディア再生</span><span class="sxs-lookup"><span data-stu-id="85d39-218">Media playback</span></span>](media-playback.md)
