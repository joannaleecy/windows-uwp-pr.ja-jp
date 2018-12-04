---
title: 学習トラック - フォームの作成と構成
description: アプリで堅牢なフォームを作成するために必要となることについて説明します。
ms.date: 05/07/2018
ms.topic: article
keywords: 概要, uwp, windows 10, 学習トラック, レイアウト, フォーム
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 0cb42552139fd706dd9e87d61c24f8fe2c2d51f7
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8463183"
---
# <a name="create-and-customize-a-form"></a><span data-ttu-id="7735e-104">フォームを作成してカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="7735e-104">Create and customize a form</span></span>

<span data-ttu-id="7735e-105">ユーザーが大量の情報を入力する必要のあるアプリを作成している場合は、ユーザーが入力するフォームが必要になる可能性があります。この記事では、利便性と信頼性の高いフォームを作成するために知っておく必要のあることについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7735e-105">If you're creating an app that requires users to input a significant amount of information, chances are you'll want to create a form for them to fill out. This article will show you what you need to know in order to create a form that is useful and robust.</span></span>

<span data-ttu-id="7735e-106">これはチュートリアルではありません。</span><span class="sxs-lookup"><span data-stu-id="7735e-106">This is not a tutorial.</span></span> <span data-ttu-id="7735e-107">チュートリアルが必要な場合は、「[アダプティブ レイアウトのチュートリアル](../design/basics/xaml-basics-adaptive-layout.md)」を参照してください。このチュートリアルでは、手順を説明したガイド付きのエクスペリエンスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="7735e-107">If you want one, see our [adaptive layout tutorial](../design/basics/xaml-basics-adaptive-layout.md), which will provide you with a step-by-step guided experience.</span></span>

<span data-ttu-id="7735e-108">フォームに含める **XAML コントロール**、ページ上で XAML コントロールを最適に配置する方法、画面のサイズを変更するためにフォームを最適化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7735e-108">We'll discuss what **XAML controls** go into a form, how to best arrange them on your page, and how to optimize your form for changing screen sizes.</span></span> <span data-ttu-id="7735e-109">ただし、フォームは visual 要素の相対位置に関することなので、まず XAML を使ったページ レイアウトについて詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="7735e-109">But because a form is about the relative position of visual elements, let's first discuss page layout with XAML.</span></span>

## <a name="what-do-you-need-to-know"></a><span data-ttu-id="7735e-110">理解しておく必要があること</span><span class="sxs-lookup"><span data-stu-id="7735e-110">What do you need to know?</span></span>

<span data-ttu-id="7735e-111">UWP には、アプリに追加して構成することができる明示的なフォーム コントロールはありません。</span><span class="sxs-lookup"><span data-stu-id="7735e-111">UWP does not have an explicit form control that you can add to your app and configure.</span></span> <span data-ttu-id="7735e-112">代わりに、ページ上に UI 要素のコレクションを配置することによって、フォームを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7735e-112">Instead, you'll need to create a form by arranging a collection of UI elements on a page.</span></span>

<span data-ttu-id="7735e-113">そのためには、**レイアウト パネル**を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7735e-113">To do so, you'll need to understand **layout panels**.</span></span> <span data-ttu-id="7735e-114">レイアウト パネルは、アプリの UI 要素を保持するコンテナーで、アプリの UI 要素を配置およびグループ化することができます。</span><span class="sxs-lookup"><span data-stu-id="7735e-114">These are containers that hold your app's UI elements, allowing you to arrange and group them.</span></span> <span data-ttu-id="7735e-115">レイアウト パネルを他のレイアウト パネル内に配置すると、相互の関連で項目の表示場所や表示方法を自由に制御できます。</span><span class="sxs-lookup"><span data-stu-id="7735e-115">Placing layout panels within other layout panels gives you a great deal of control over where and how your items display in relation to one another.</span></span> <span data-ttu-id="7735e-116">また、これにより画面サイズ変更にアプリを対応させることがはるかに簡単になります。</span><span class="sxs-lookup"><span data-stu-id="7735e-116">This also makes it far easier to adapt your app to changing screen sizes.</span></span>

<span data-ttu-id="7735e-117">[レイアウト パネルに関するこちらのドキュメント](../design/layout/layout-panels.md)をお読みください。</span><span class="sxs-lookup"><span data-stu-id="7735e-117">Read [this documentation on layout panels](../design/layout/layout-panels.md).</span></span> <span data-ttu-id="7735e-118">フォームは通常 1 つ以上の垂直列に表示されるため、類似した項目を **StackPanel** にまとめ、必要であれば **RelativePanel** 内に配置します。</span><span class="sxs-lookup"><span data-stu-id="7735e-118">Because forms are usually displayed in one or more vertical columns, you'll want to group similar items in a **StackPanel**, and arrange those within a **RelativePanel** if you need to.</span></span> <span data-ttu-id="7735e-119">それでは、一部のパネルの編成を開始してください。リファレンスが必要な場合は、2 列のフォームの基本的なレイアウト フレームワークが以下に用意されています。</span><span class="sxs-lookup"><span data-stu-id="7735e-119">Start putting together some panels now — if you need a reference, below is a basic layout framework for a two-column form:</span></span>

```xaml
<RelativePanel>
    <StackPanel x:Name="Customer" Margin="20">
        <!--Content-->
    </StackPanel>
    <StackPanel x:Name="Associate" Margin="20" RelativePanel.RightOf="Customer">
        <!--Content-->
    </StackPanel>
    <StackPanel x:Name="Save" Orientation="Horizontal" RelativePanel.Below="Customer">
        <!--Save and Cancel buttons-->
    </StackPanel>
</RelativePanel>
```

## <a name="what-goes-in-a-form"></a><span data-ttu-id="7735e-120">フォームに含めるもの</span><span class="sxs-lookup"><span data-stu-id="7735e-120">What goes in a form?</span></span>

<span data-ttu-id="7735e-121">各種の [XAML コントロール](../design/controls-and-patterns/controls-and-events-intro.md) を使用してフォームに入力する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7735e-121">You'll need to fill your form with an assortment of [XAML Controls](../design/controls-and-patterns/controls-and-events-intro.md).</span></span> <span data-ttu-id="7735e-122">XAML コントロールは使い慣れているかもしれませんが、思い出す必要がある場合は、自由に目を通してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-122">You're probably familiar with those, but feel free to read up if you need a refresher.</span></span> <span data-ttu-id="7735e-123">特に、ユーザーがテキストを入力するか、または値の一覧から選択できるようにするコントロールが必要になります。</span><span class="sxs-lookup"><span data-stu-id="7735e-123">In particular, you'll want controls that allow your user to input text or choose from a list of values.</span></span> <span data-ttu-id="7735e-124">これは、追加のオプションの基本的なリスト – 外観やしくみを理解するために十分なに関するすべての情報を読み取る必要はありません。</span><span class="sxs-lookup"><span data-stu-id="7735e-124">This is a basic list of options you could add – you don't need to read everything about them, just enough so you understand what they look like and how they work.</span></span>

* <span data-ttu-id="7735e-125">[TextBox](../design/controls-and-patterns/text-box.md)では、アプリにユーザーがテキストを入力できます。</span><span class="sxs-lookup"><span data-stu-id="7735e-125">[TextBox](../design/controls-and-patterns/text-box.md) lets a user input text into your app.</span></span>
* <span data-ttu-id="7735e-126">[ToggleSwitch](../design/controls-and-patterns/toggles.md) では、ユーザーが 2 つのオプションから選択できます。</span><span class="sxs-lookup"><span data-stu-id="7735e-126">[ToggleSwitch](../design/controls-and-patterns/toggles.md) lets a user choose between two options.</span></span>
* <span data-ttu-id="7735e-127">[DatePicker](../design/controls-and-patterns/date-picker.md) では、ユーザーが日付値を選択できます。</span><span class="sxs-lookup"><span data-stu-id="7735e-127">[DatePicker](../design/controls-and-patterns/date-picker.md) lets a user select a date value.</span></span>
* <span data-ttu-id="7735e-128">[TimePicker](../design/controls-and-patterns/time-picker.md) では、ユーザーが時刻値を選択できます。</span><span class="sxs-lookup"><span data-stu-id="7735e-128">[TimePicker](../design/controls-and-patterns/time-picker.md) lets a user select a time value.</span></span>
* <span data-ttu-id="7735e-129">[ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox) は、選択可能な項目の一覧を表示するために展開します。</span><span class="sxs-lookup"><span data-stu-id="7735e-129">[ComboBox](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox) expand to display a list of selectable items.</span></span> <span data-ttu-id="7735e-130">これらの詳細については、[こちら](../design/controls-and-patterns/lists.md#drop-down-lists)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-130">You can learn more about them [here](../design/controls-and-patterns/lists.md#drop-down-lists)</span></span>

<span data-ttu-id="7735e-131">また、ユーザーが保存やキャンセルを行うことができるように、[ボタン](../design/controls-and-patterns/buttons.md)を追加することができます。</span><span class="sxs-lookup"><span data-stu-id="7735e-131">You also might want to add [buttons](../design/controls-and-patterns/buttons.md), so the user can save or cancel.</span></span>

## <a name="format-controls-in-your-layout"></a><span data-ttu-id="7735e-132">レイアウトでのコントロールの書式設定</span><span class="sxs-lookup"><span data-stu-id="7735e-132">Format controls in your layout</span></span>

<span data-ttu-id="7735e-133">レイアウト パネルを配置する方法を理解し、追加したい項目がありますが、どのように書式設定すればいいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="7735e-133">You know how to arrange layout panels and have items you'd like to add, but how should they be formatted?</span></span> <span data-ttu-id="7735e-134">[フォーム](../design/controls-and-patterns/forms.md) ページにはいくつかの詳しい設計ガイダンスが記載されています。</span><span class="sxs-lookup"><span data-stu-id="7735e-134">The [forms](../design/controls-and-patterns/forms.md) page has some specific design guidance.</span></span> <span data-ttu-id="7735e-135">**フォームの種類**と**レイアウト**に関するセクションに目を通して役立つアドバイスを確認してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-135">Read through the sections on **Types of forms** and **layout** for useful advice.</span></span> <span data-ttu-id="7735e-136">アクセシビリティと相対レイアウトについては簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="7735e-136">We'll discuss accessibility and relative layout more shortly.</span></span>

<span data-ttu-id="7735e-137">そのアドバイスに留意し、選択したコントロールをレイアウトに追加し始め、ラベルと行間が正しく指定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7735e-137">With that advice in mind, you should start adding your controls of choice into your layout, being sure they're given labels and spaced properly.</span></span> <span data-ttu-id="7735e-138">例として、上記のレイアウト、コントロール、設計ガイダンスを使用した単一ページ フォームの必要最小限の概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7735e-138">As an example, here's the bare-bones outline for a single-page form using the above layout, controls, and design guidance:</span></span>

```xaml
<RelativePanel>
    <StackPanel x:Name="Customer" Margin="20">
        <TextBox x:Name="CustomerName" Header= "Customer Name" Margin="0,24,0,0" HorizontalAlignment="Left" />
        <TextBox x:Name="Address" Header="Address" PlaceholderText="Address" Margin="0,24,0,0" HorizontalAlignment="Left" />
        <TextBox x:Name="Address2" Margin="0,24,0,0" PlaceholderText="Address 2" HorizontalAlignment="Left" />
            <RelativePanel>
                <TextBox x:Name="City" PlaceholderText="City" Margin="0,24,0,0" HorizontalAlignment="Left" />
                <ComboBox x:Name="State" PlaceholderText="State" Margin="24,24,0,0" RelativePanel.RightOf="City">
                    <!--List of valid states-->
                </ComboBox>
            </RelativePanel>
    </StackPanel>
    <StackPanel x:Name="Associate" Margin="20" RelativePanel.Below="Customer">
        <TextBox x:Name="AssociateName" Header= "Associate" Margin="0,24,0,0" HorizontalAlignment="Left" />
        <DatePicker x:Name="TargetInstallDate" Header="Target install Date" HorizontalAlignment="Left" Margin="0,24,0,0"></DatePicker>
        <TimePicker x:Name="InstallTime" Header="Install Time" HorizontalAlignment="Left" Margin="0,24,0,0"></TimePicker>
    </StackPanel>
    <StackPanel x:Name="Save" Orientation="Horizontal" RelativePanel.Below="Associate">
        <Button Content="Save" Margin="24" />
        <Button Content="Cancel" Margin="24" />
    </StackPanel>
</RelativePanel>
```

<span data-ttu-id="7735e-139">視覚エクスペリエンスを向上させるために、さらにプロパティを使って自由にコントロールをカスタマイズしてください。</span><span class="sxs-lookup"><span data-stu-id="7735e-139">Feel free to customize your controls with more properties for a better visual experience.</span></span>

## <a name="make-your-layout-responsive"></a><span data-ttu-id="7735e-140">レイアウトの応答性を向上させる</span><span class="sxs-lookup"><span data-stu-id="7735e-140">Make your layout responsive</span></span>

<span data-ttu-id="7735e-141">ユーザーは、さまざまな画面幅の多様なデバイスで UI を表示する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7735e-141">Users might view your UI on a variety of devices with different screen widths.</span></span> <span data-ttu-id="7735e-142">画面に関係なく優れたエクスペリエンスを確実に提供するには、[レスポンシブ デザイン](../design/layout/responsive-design.md)を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7735e-142">To ensure that they have a good experience regardless of their screen, you should use [responsive design](../design/layout/responsive-design.md).</span></span> <span data-ttu-id="7735e-143">そのページに目を通し、作業を進めるうえで留意する設計哲学に関する優れたアドバイスを確認してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-143">Read through that page for good advice on the design philosophies to keep in mind as you proceed.</span></span>

<span data-ttu-id="7735e-144">[XAML でのレスポンシブ レイアウト](../design/layout/layouts-with-xaml.md)のページでは、この実装方法に関する詳細な概要について説明しています。</span><span class="sxs-lookup"><span data-stu-id="7735e-144">The [Responsive layouts with XAML](../design/layout/layouts-with-xaml.md) page gives a detailed overview of how to implement this.</span></span> <span data-ttu-id="7735e-145">ここでは、**柔軟なレイアウト**と **XAML での表示状態**を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="7735e-145">For now, we'll focus on **fluid layouts** and **visual states in XAML**.</span></span>

<span data-ttu-id="7735e-146">用意されている基本的なフォームのアウトラインは、特定のピクセル サイズと位置を最小限にしか使用しないコントロールの相対位置にほぼ依存しているため、既に**柔軟なレイアウト**になっています。</span><span class="sxs-lookup"><span data-stu-id="7735e-146">The basic form outline that we've put together is already a **fluid layout**, as it's depending mostly on the relative position of controls with only minimal use of specific pixel sizes and positions.</span></span> <span data-ttu-id="7735e-147">ただし、今後作成する可能性がある追加の UI についてはこのガイダンスに留意してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-147">Keep this guidance in mind for more UIs you might create in the future, though.</span></span>

<span data-ttu-id="7735e-148">レスポンシブ レイアウトでさらに重要なのは**表示状態**です。</span><span class="sxs-lookup"><span data-stu-id="7735e-148">More important to responsive layouts are **visual states.**</span></span> <span data-ttu-id="7735e-149">表示状態は、特定の条件が該当する場合に指定された要素に適用されるプロパティ値を定義します。</span><span class="sxs-lookup"><span data-stu-id="7735e-149">A visual state defines property values that are applied to a given element when a given condition is true.</span></span> <span data-ttu-id="7735e-150">[xaml でこれを行う方法について目を通し](../design/layout/layouts-with-xaml.md#set-visual-states-in-xaml-markup)、フォームに実装してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-150">[Read up on how to do this in xaml](../design/layout/layouts-with-xaml.md#set-visual-states-in-xaml-markup), and then implement them into your form.</span></span> <span data-ttu-id="7735e-151">前のサンプルでの*非常に*基本的な例の外観を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7735e-151">Here's what a *very* basic one might look like in our previous sample:</span></span>

```xaml
<VisualStateManager.VisualStateGroups>
    <VisualStateGroup>
        <VisualState>
            <VisualState.StateTriggers>
                <AdaptiveTrigger MinWindowWidth="640" />
            </VisualState.StateTriggers>

            <VisualState.Setters>
                <Setter Target="Associate.(RelativePanel.RightOf)" Value="Customer"/>
                <Setter Target="Associate.(RelativePanel.Below)" Value=""/>
                <Setter Target="Save.(RelativePanel.Below)" Value="Customer"/>
            </VisualState.Setters>
        </VisualState>
    </VisualStateGroup>
</VisualStateManager.VisualStateGroups>

<RelativePanel>
    <!--Previous 3 stack panels-->
</RelativePanel>
```

<span data-ttu-id="7735e-152">幅広い画面サイズに対応する表示状態を作成するのは実用的ではなく、アプリのユーザー エクスペリエンスに大きな影響を及ぼす可能性もそれほど高くはありません。</span><span class="sxs-lookup"><span data-stu-id="7735e-152">It's not practical to create visual states for a wide array of screen sizes, nor are more than a couple likely to have significant impact on the user experience of your app.</span></span> <span data-ttu-id="7735e-153">その代わり、いくつかの主要なブレークポイントを設計することをお勧めします。[こちらを参照](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md)してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-153">We recommend designing instead for a few key breakpoints - you can [read more here](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

## <a name="add-accessibility-support"></a><span data-ttu-id="7735e-154">アクセシビリティのサポートの追加</span><span class="sxs-lookup"><span data-stu-id="7735e-154">Add accessibility support</span></span>

<span data-ttu-id="7735e-155">これで、画面サイズの変更に対応する、適切に構築されたレイアウトが用意できたので、最後にユーザー エクスペリエンスを向上させるために、[アプリをアクセシビリティ対応にする](../design/accessibility/accessibility-overview.md)ことができます。</span><span class="sxs-lookup"><span data-stu-id="7735e-155">Now that you have a well-constructed layout that responds to changes in screen sizes, a last thing you can do to improve the user experience is to [make your app accessible](../design/accessibility/accessibility-overview.md).</span></span> <span data-ttu-id="7735e-156">詳しく説明できることはたくさんありますが、このようなフォームでは見た目よりも簡単です。</span><span class="sxs-lookup"><span data-stu-id="7735e-156">There's a lot that can go into this, but in a form like this one it's easier than it looks.</span></span> <span data-ttu-id="7735e-157">次の点を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="7735e-157">Focus on the following:</span></span>

* <span data-ttu-id="7735e-158">キーボードのサポート - ユーザーが簡単にタブ移動できるように、UI パネルの要素の順序が、画面上に表示される方法と一致するようにします。</span><span class="sxs-lookup"><span data-stu-id="7735e-158">Keyboard support - ensure the order of elements in your UI panels match how they're displayed on screen, so a user can easily tab through them.</span></span>
* <span data-ttu-id="7735e-159">スクリーン リーダーのサポート - すべてのコントロールにわかりやすい名前があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7735e-159">Screen reader support - ensure all your controls have a descriptive name.</span></span>

<span data-ttu-id="7735e-160">より多くの視覚要素を含む複雑なレイアウトを作成する場合は、詳細について、「[アクセシビリティのチェック リスト](../design/accessibility/accessibility-checklist.md)」を参照する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7735e-160">When you're creating more complex layouts with more visual elements, you'll want to consult the [accessibility checklist](../design/accessibility/accessibility-checklist.md) for more details.</span></span> <span data-ttu-id="7735e-161">結局のところ、アクセシビリティがアプリに必要なくても、アクセシビリティによってより多くの人にリーチして感心を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="7735e-161">After all, while accessibility isn't necessary for an app, it helps it reach and engage a larger audience.</span></span>

## <a name="going-further"></a><span data-ttu-id="7735e-162">追加情報</span><span class="sxs-lookup"><span data-stu-id="7735e-162">Going further</span></span>

<span data-ttu-id="7735e-163">ここではフォームを作成しましたが、レイアウトとコントロールの概念は、作成する可能性のあるすべての XAML UI で適用可能です。</span><span class="sxs-lookup"><span data-stu-id="7735e-163">Though you've created a form here, the concepts of layouts and controls are applicable across all XAML UIs you might construct.</span></span> <span data-ttu-id="7735e-164">自由に戻ってがある場合、新しい UI 機能を追加して、ユーザー エクスペリエンスを絞り込むフォームの実験し、リンクしたドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="7735e-164">Feel free to go back through the docs we've linked you to and experiment with the form you have, adding new UI features and further refining the user experience.</span></span> <span data-ttu-id="7735e-165">詳細なレイアウト機能を使ってステップ バイ ステップのガイダンスを設定する場合、[アダプティブ レイアウトのチュートリアル](../design/basics/xaml-basics-adaptive-layout.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7735e-165">If you want step-by-step guidance through more detailed layout features, see our [adaptive layout tutorial](../design/basics/xaml-basics-adaptive-layout.md)</span></span>

<span data-ttu-id="7735e-166">また、フォームは真空に存在する必要はありません。一歩進んで、自分のフォームを[マスター/詳細パターン](../design/controls-and-patterns/master-details.md)または[ピボット コントロール](../design/controls-and-patterns/tabs-pivot.md)に組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="7735e-166">Forms also don't have to exist in a vacuum - you could go one step forward and embed yours within a [master/details pattern](../design/controls-and-patterns/master-details.md) or a [pivot control](../design/controls-and-patterns/tabs-pivot.md).</span></span> <span data-ttu-id="7735e-167">または、自分のフォームで分離コードを使用する場合は、[イベントの概要](../xaml-platform/events-and-routed-events-overview.md)を参照して作業を開始することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7735e-167">Or if you want to get to work on the code-behind for your form, you might want to get started with our [events overview](../xaml-platform/events-and-routed-events-overview.md).</span></span>

## <a name="useful-apis-and-docs"></a><span data-ttu-id="7735e-168">便利な API とドキュメント</span><span class="sxs-lookup"><span data-stu-id="7735e-168">Useful APIs and docs</span></span>

<span data-ttu-id="7735e-169">データ バインディングを操作するうえで役立つ API の簡単な概要とその他の役立つドキュメントを次に示します。</span><span class="sxs-lookup"><span data-stu-id="7735e-169">Here's a quick summary of APIs and other useful documentation to help you get started working with Data Binding.</span></span>

### <a name="useful-apis"></a><span data-ttu-id="7735e-170">便利な API</span><span class="sxs-lookup"><span data-stu-id="7735e-170">Useful APIs</span></span>

| <span data-ttu-id="7735e-171">API</span><span class="sxs-lookup"><span data-stu-id="7735e-171">API</span></span> | <span data-ttu-id="7735e-172">説明</span><span class="sxs-lookup"><span data-stu-id="7735e-172">Description</span></span> |
|------|---------------|
| [<span data-ttu-id="7735e-173">フォームに役立つコントロール</span><span class="sxs-lookup"><span data-stu-id="7735e-173">Controls useful for forms</span></span>](../design/controls-and-patterns/forms.md#input-controls) | <span data-ttu-id="7735e-174">フォームを作成するために役立つ入力コントロールの一覧と、それを使用する場所に関する基本的なガイダンスです。</span><span class="sxs-lookup"><span data-stu-id="7735e-174">A list of useful input controls for creating forms, and basic guidance of where to use them.</span></span> |
| [<span data-ttu-id="7735e-175">グリッド</span><span class="sxs-lookup"><span data-stu-id="7735e-175">Grid</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Grid) | <span data-ttu-id="7735e-176">複数行および段組レイアウトで要素を配置するためのパネルです。</span><span class="sxs-lookup"><span data-stu-id="7735e-176">A panel for arranging elements in multi-row and multi-column layouts.</span></span> |
| [<span data-ttu-id="7735e-177">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="7735e-177">RelativePanel</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.RelativePanel) | <span data-ttu-id="7735e-178">その他の要素とパネルの境界を基準にして項目を配置するためのパネルです。</span><span class="sxs-lookup"><span data-stu-id="7735e-178">A panel for arraging items in relation to other elements and to the panel's boundaries.</span></span> |
| [<span data-ttu-id="7735e-179">StackPanel</span><span class="sxs-lookup"><span data-stu-id="7735e-179">StackPanel</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) | <span data-ttu-id="7735e-180">単一の水平線または垂直線に要素を配置するためのパネルです。</span><span class="sxs-lookup"><span data-stu-id="7735e-180">A panel for arranging elements into a single horizontal or vertical line.</span></span> |
| [<span data-ttu-id="7735e-181">VisualState</span><span class="sxs-lookup"><span data-stu-id="7735e-181">VisualState</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.VisualState) | <span data-ttu-id="7735e-182">UI 要素が特定の状態にあるときに要素の外観を設定できます。</span><span class="sxs-lookup"><span data-stu-id="7735e-182">Allows you to set the appearance of UI elements when they're in particular states.</span></span> |

### <a name="useful-docs"></a><span data-ttu-id="7735e-183">役立つドキュメント</span><span class="sxs-lookup"><span data-stu-id="7735e-183">Useful docs</span></span>

| <span data-ttu-id="7735e-184">トピック</span><span class="sxs-lookup"><span data-stu-id="7735e-184">Topic</span></span> | <span data-ttu-id="7735e-185">説明</span><span class="sxs-lookup"><span data-stu-id="7735e-185">Description</span></span> |
|-------|----------------|
| [<span data-ttu-id="7735e-186">アクセシビリティの概要</span><span class="sxs-lookup"><span data-stu-id="7735e-186">Accessibility overview</span></span>](../design/accessibility/accessibility-overview.md) | <span data-ttu-id="7735e-187">アプリでのアクセシビリティ オプションの広範囲にわたる概要です。</span><span class="sxs-lookup"><span data-stu-id="7735e-187">A broad-scale overview of accessibility options in apps.</span></span> |
| [<span data-ttu-id="7735e-188">アクセシビリティのチェック リスト</span><span class="sxs-lookup"><span data-stu-id="7735e-188">Accessibility checklist</span></span>](../design/accessibility/accessibility-checklist.md) | <span data-ttu-id="7735e-189">アプリがアクセシビリティの基準を満たしていることを確認するための実用的なチェックリストです。</span><span class="sxs-lookup"><span data-stu-id="7735e-189">A practical checklist to ensure your app meets accessibility standards.</span></span> |
| [<span data-ttu-id="7735e-190">イベントの概要</span><span class="sxs-lookup"><span data-stu-id="7735e-190">Events overview</span></span>](../xaml-platform/events-and-routed-events-overview.md) | <span data-ttu-id="7735e-191">UI 操作を処理するイベントの追加と構築に関する詳細です。</span><span class="sxs-lookup"><span data-stu-id="7735e-191">Details on adding and structuring events to handle UI actions.</span></span> |
| [<span data-ttu-id="7735e-192">フォーム</span><span class="sxs-lookup"><span data-stu-id="7735e-192">Forms</span></span>](../design/controls-and-patterns/forms.md) | <span data-ttu-id="7735e-193">フォームを作成するための全体的なガイダンスです。</span><span class="sxs-lookup"><span data-stu-id="7735e-193">Overall guidance for creating forms.</span></span> |
| [<span data-ttu-id="7735e-194">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="7735e-194">Layout panels</span></span>](../design/layout/layout-panels.md) | <span data-ttu-id="7735e-195">レイアウト パネルの種類とそれらを使用する場所に関する概要を示します。</span><span class="sxs-lookup"><span data-stu-id="7735e-195">Provides an overview of the types of layout panels and where to use them.</span></span> |
| [<span data-ttu-id="7735e-196">マスター/詳細パターン</span><span class="sxs-lookup"><span data-stu-id="7735e-196">Master/details pattern</span></span>](../design/controls-and-patterns/master-details.md) | <span data-ttu-id="7735e-197">1 つまたは複数のフォームの周囲に実装できる設計パターンです。</span><span class="sxs-lookup"><span data-stu-id="7735e-197">A design pattern that can be implemented around one or multiple forms.</span></span> |
| [<span data-ttu-id="7735e-198">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="7735e-198">Pivot control</span></span>](../design/controls-and-patterns/tabs-pivot.md) | <span data-ttu-id="7735e-199">1 つまたは複数のフォームを含めることができるコントロールです。</span><span class="sxs-lookup"><span data-stu-id="7735e-199">A control that can contain one or multiple forms.</span></span> |
| [<span data-ttu-id="7735e-200">レスポンシブ デザイン</span><span class="sxs-lookup"><span data-stu-id="7735e-200">Responsive design</span></span>](../design/layout/responsive-design.md) | <span data-ttu-id="7735e-201">大規模なレスポンシブ デザインの原則の概要です。</span><span class="sxs-lookup"><span data-stu-id="7735e-201">An overview of large-scale responsive design principles.</span></span> | 
| [<span data-ttu-id="7735e-202">XAML でのレスポンシブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="7735e-202">Responsive layouts with XAML</span></span>](../design/layout/layouts-with-xaml.md) | <span data-ttu-id="7735e-203">レスポンシブ デザインの表示状態とその他の実装に関する具体的な情報です。</span><span class="sxs-lookup"><span data-stu-id="7735e-203">Specific information on visual states and other implementations of responsive design.</span></span> |
| [<span data-ttu-id="7735e-204">レスポンシブ デザインの画面サイズ</span><span class="sxs-lookup"><span data-stu-id="7735e-204">Screen sizes for responsive design</span></span>](../design/layout/screen-sizes-and-breakpoints-for-responsive-design.md) | <span data-ttu-id="7735e-205">レスポンシブ レイアウトの対象とする画面サイズに関するガイダンスです。</span><span class="sxs-lookup"><span data-stu-id="7735e-205">Guidance on which screen sizes to which responsive layouts should be scoped.</span></span> |

## <a name="useful-code-samples"></a><span data-ttu-id="7735e-206">役立つコード サンプル</span><span class="sxs-lookup"><span data-stu-id="7735e-206">Useful code samples</span></span>

| <span data-ttu-id="7735e-207">コード サンプル</span><span class="sxs-lookup"><span data-stu-id="7735e-207">Code sample</span></span> | <span data-ttu-id="7735e-208">説明</span><span class="sxs-lookup"><span data-stu-id="7735e-208">Description</span></span> |
|-----------------|---------------|
| [<span data-ttu-id="7735e-209">アダプティブ レイアウトのチュートリアル</span><span class="sxs-lookup"><span data-stu-id="7735e-209">Adaptive layout tutorial</span></span>](../design/basics/xaml-basics-adaptive-layout.md) | <span data-ttu-id="7735e-210">アダプティブ レイアウトやレスポンシブ デザインの手順を説明したガイド付きエクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="7735e-210">A step-by-step guided experience through adaptive layouts and responsive design.</span></span> | 
| [<span data-ttu-id="7735e-211">顧客注文データベース</span><span class="sxs-lookup"><span data-stu-id="7735e-211">Customer Orders Database</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database) | <span data-ttu-id="7735e-212">マルチページのエンタープライズのサンプルで、レイアウトとフォームの動作を確認してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-212">See layout and forms in action on a multi-page enterprise sample.</span></span> |
| [<span data-ttu-id="7735e-213">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="7735e-213">XAML Controls Gallery</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) | <span data-ttu-id="7735e-214">一部の XAML コントロール、およびそれらの実装方法を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-214">See a selection of XAML controls, and how they're implemented.</span></span> |
| [<span data-ttu-id="7735e-215">その他のコード サンプル</span><span class="sxs-lookup"><span data-stu-id="7735e-215">Additional code samples</span></span>](https://developer.microsoft.com//windows/samples) | <span data-ttu-id="7735e-216">[カテゴリ] ドロップダウン リストで **[コントロール、レイアウト、テキスト]** を選択し、関連するコード サンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="7735e-216">Choose **Controls, layout, and text** in the category drop-down list to see related code samples.</span></span> |
