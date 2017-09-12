---
author: mijacobs
Description: "ParallaxView コントロールを使用して、アプリに奥行きと動きを追加します。"
title: "ParallaxView コントロールの使用のガイドライン"
ms.assetid: 
label: Parallax View
template: detail.hbs
ms.author: mijacobs
ms.date: 08/9/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: abarlow
design-contact: conrwi
dev-contact: stpete
doc-status: Published
ms.openlocfilehash: b99b4ca3f3e16a127472633fc3c800db2d773b8c
ms.sourcegitcommit: 0d5b3daddb3ae74f91178c58e35cbab33854cb7f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/09/2017
---
# <a name="parallax"></a><span data-ttu-id="00537-104">視差</span><span class="sxs-lookup"><span data-stu-id="00537-104">Parallax</span></span>

> [!IMPORTANT]
> <span data-ttu-id="00537-105">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="00537-105">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="00537-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="00537-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="00537-107">視差は、アプリの閲覧者の近くにある項目を背景にある項目よりも速く動かすという視覚効果です。</span><span class="sxs-lookup"><span data-stu-id="00537-107">Parallax is a visual effect where items closer to the viewer move faster than items in the background.</span></span> <span data-ttu-id="00537-108">視差によって、奥行き、遠近感、および動きといった感覚が引き起こされます。</span><span class="sxs-lookup"><span data-stu-id="00537-108">Parallax creates a feeling of depth, perspective, and movement.</span></span> <span data-ttu-id="00537-109">UWP アプリでは、ParallaxView コントロールを使用して、視差効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="00537-109">In a UWP app, you can use the ParallaxView control to create a parallax effect.</span></span>  

> <span data-ttu-id="00537-110">**重要な API**: [ParallaxView クラス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview)、[VerticalShift プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_VerticalShift)、[HorizontalShift プロパティ](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_HorizontalShift)</span><span class="sxs-lookup"><span data-stu-id="00537-110">**Important APIs**: [ParallaxView class](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview), [VerticalShift property](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_VerticalShift), [HorizontalShift property](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_HorizontalShift)</span></span>

## <a name="parallax-and-the-fluent-design-system"></a><span data-ttu-id="00537-111">視差と Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="00537-111">Parallax and the Fluent Design System</span></span>

 <span data-ttu-id="00537-112">Fluent Design System では、ライト、深度、モーション、マテリアル、スケールを取り入れた、モダンで目を引く UI を作成できます。</span><span class="sxs-lookup"><span data-stu-id="00537-112">The Fluent Design System helps you create modern, bold UI that incorporates light, depth, motion, material, and scale.</span></span> <span data-ttu-id="00537-113">視差は、アプリにモーション、深度、スケールを追加する Fluent Design System コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="00537-113">Parallax is a Fluent Design System component that adds motion, depth, and scale to your app.</span></span> 

## <a name="how-it-works-in-a-user-interface"></a><span data-ttu-id="00537-114">ユーザー インターフェイスでのしくみ</span><span class="sxs-lookup"><span data-stu-id="00537-114">How it works in a user interface</span></span>

<span data-ttu-id="00537-115">UI では、UI のスクロールやパンを行うときに、さまざまなオブジェクトをさまざまな速度で動かすことによって視差効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="00537-115">In a UI, you can create a parallax effect by moving different objects at different rates when the UI scrolls or pans.</span></span> <!-- Parallax is an important tool in adding depth to applications along with other techniques like transition animations, perspective tilt, and layering. --> <span data-ttu-id="00537-116">その実例として、コンテンツの 2 つのレイヤー (リストと背景画像) を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="00537-116">To demonstrate, let’s look at two layers of content, a list and a background image.</span></span>  <span data-ttu-id="00537-117">リストは背景画像の上に配置されており、リストがアプリの閲覧者の近くに表示されているという錯覚を既に与えています。</span><span class="sxs-lookup"><span data-stu-id="00537-117">The list is placed on top of the background image which already gives the illusion that the list might be closer to the viewer.</span></span>  <span data-ttu-id="00537-118">次に、視差効果を実現するために、最も近くに表示されているオブジェクトを、遠くに表示されているオブジェクトよりも "速く" 動かします。</span><span class="sxs-lookup"><span data-stu-id="00537-118">Now, to achieve the parallax effect, we want the object closest to us to travel “faster” than the object that is farther away.</span></span>  <span data-ttu-id="00537-119">ユーザーがインターフェイスをスクロールすると、リストは背景画像よりも速い速度で動作し、奥行きがあるような錯覚を与えます。</span><span class="sxs-lookup"><span data-stu-id="00537-119">As the user scrolls the interface, the list moves at a faster rate than the background image, which creates the illusion of depth.</span></span>

 ![リストと背景画像を使用した視差の例](images/_Parallax_v2.gif)

 
## <a name="using-the-parallaxview-control-to-create-a-parallax-effect"></a><span data-ttu-id="00537-121">ParallaxView コントロールを使用して視差効果を作成する</span><span class="sxs-lookup"><span data-stu-id="00537-121">Using the ParallaxView control to create a parallax effect</span></span>

<span data-ttu-id="00537-122">視差効果を作成するには、[ParallaxView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview) コントロールを使用します。</span><span class="sxs-lookup"><span data-stu-id="00537-122">To create a parallax effect, you use the [ParallaxView](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview) control.</span></span> <span data-ttu-id="00537-123">このコントロールによって、前景要素 (リストなど) のスクロール位置が背景要素 (画像など) に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="00537-123">This control ties the scroll position of a foreground element, such as a list, to a background element, such as an image.</span></span> <span data-ttu-id="00537-124">前景要素をスクロールすると、背景要素がアニメーション化され、視差効果が発生します。</span><span class="sxs-lookup"><span data-stu-id="00537-124">As you scroll through the foreground element, it animates the background element to create a parallax effect.</span></span> 

<span data-ttu-id="00537-125">ParallaxView コントロールを使用するには、ソース要素と背景要素を用意し、[VerticalShift](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_VerticalShift) プロパティ (垂直スクロール用) や [HorizontalShift](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_HorizontalShift) プロパティ (水平スクロール用) を 0 より大きい値に設定します。</span><span class="sxs-lookup"><span data-stu-id="00537-125">To use the ParallaxView control, you provide a Source element, a background element, and set the [VerticalShift](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_VerticalShift) (for vertical scrolling) and/or [HorizontalShift](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview#Windows_UI_Xaml_Controls_ParallaxView_HorizontalShift) (for horizontal scrolling) properties to a value greater than zero.</span></span> 
* <span data-ttu-id="00537-126">Source プロパティは、前景要素への参照を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="00537-126">The Source property takes a reference to the foreground element.</span></span> <span data-ttu-id="00537-127">視差効果を発生させるには、前景が [ScrollViewer](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) であるか、前景が ScrollViewer を含んでいる要素 ([ListView](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.listview) や [RichTextBox](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.RichEditBox) など) であることがj必要です。</span><span class="sxs-lookup"><span data-stu-id="00537-127">For the parallax effect to occur, the foreground should be a [ScrollViewer](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ScrollViewer) or an element that contains a ScrollViewer, such as a [ListView](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.listview) or a [RichTextBox](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.RichEditBox).</span></span> 

* <span data-ttu-id="00537-128">背景要素を設定するには、その要素を ParallaxView コントロールの子として追加します。</span><span class="sxs-lookup"><span data-stu-id="00537-128">To set the background element, you add that element as a child of the ParallaxView control.</span></span> <span data-ttu-id="00537-129">背景要素には、[Image](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Image) など、どのような [UIElement](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement) でも使用できます。また、追加の UI 要素を含んでいるパネルも使用できます。</span><span class="sxs-lookup"><span data-stu-id="00537-129">The background element can be any [UIElement](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.uielement), such as an [Image](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Image) or a panel that contains additional UI elements.</span></span> 

<span data-ttu-id="00537-130">視差効果を作成するには、ParallaxView が背景要素を介して動作するようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="00537-130">To create a parallax effect, the ParallaxView must be behind the foreground element.</span></span> <span data-ttu-id="00537-131">[Grid](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.grid) パネルや [Canvas](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.canvas) パネルを使用すると、項目を相互に重ねることができ、それらの項目は ParallaxView コントロールで適切に動作します。</span><span class="sxs-lookup"><span data-stu-id="00537-131">The [Grid](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.grid) and [Canvas](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.canvas) panels let you layer items on top of each other, so they work well with the ParallaxView control.</span></span>  

<span data-ttu-id="00537-132">次の例では、リストの視差効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="00537-132">This example creates a parallax effect for a list:</span></span>
 
```xaml
<Grid>
    <ParallaxView Source="{x:Bind ForegroundElement}" VerticalShift="50"> 
    
        <!-- Background element --> 
        <Image x:Name="BackgroundImage" Source="Assets/turntable.png"
               Stretch="UniformToFill"/>
    </ParallaxView>
    
    <!-- Foreground element -->
    <ListView x:Name="ForegroundElement">
       <x:String>Item 1</x:String> 
       <x:String>Item 2</x:String> 
       <x:String>Item 3</x:String> 
       <x:String>Item 4</x:String> 
       <x:String>Item 5</x:String>  
       <x:String>Item 6</x:String> 
       <x:String>Item 7</x:String> 
       <x:String>Item 8</x:String> 
       <x:String>Item 9</x:String> 
       <x:String>Item 10</x:String>     
       <x:String>Item 11</x:String> 
       <x:String>Item 13</x:String> 
       <x:String>Item 14</x:String> 
       <x:String>Item 15</x:String> 
       <x:String>Item 16</x:String>     
       <x:String>Item 17</x:String> 
       <x:String>Item 18</x:String> 
       <x:String>Item 19</x:String> 
       <x:String>Item 20</x:String> 
       <x:String>Item 21</x:String>        
    </ListView>
</Grid>
``` 

<span data-ttu-id="00537-133">ParallaxView では、視差効果の操作で適切に動作するように、画像のサイズが自動的に調整されます。このため、画像のスクロールが画面から消えてしまうことを心配する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="00537-133">The ParallaxView automatically adjusts the size of the image so it works for the parallax operation so you don’t have to worry about the image scrolling out of view.</span></span>

## <a name="customizing-the-parallax-effect"></a><span data-ttu-id="00537-134">視差効果のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="00537-134">Customizing the parallax effect</span></span> 

<span data-ttu-id="00537-135">VerticalShift プロパティと HorizontalShift プロパティでは、視差効果の程度を制御できます。</span><span class="sxs-lookup"><span data-stu-id="00537-135">The VerticalShift and HorizontalShift properties let you control degree of the parallax effect.</span></span>

* <span data-ttu-id="00537-136">VerticalShift プロパティでは、視差効果の操作全体を通じて、背景をどの程度垂直方向に動かすかを指定します。</span><span class="sxs-lookup"><span data-stu-id="00537-136">The VerticalShift property specifies how far we want the background to vertically shift during the entire parallax operation.</span></span> <span data-ttu-id="00537-137">値が 0 の場合、背景はまったく動きません。</span><span class="sxs-lookup"><span data-stu-id="00537-137">A value of 0 means the the background doesn't move at all.</span></span>
* <span data-ttu-id="00537-138">HorizontalShift プロパティでは、視差効果の操作全体を通じて、背景をどの程度水平方向に動かすかを指定します。</span><span class="sxs-lookup"><span data-stu-id="00537-138">The HorizontalShift property specifies how far we want the background to horizontally shift during the entire parallax operation.</span></span> <span data-ttu-id="00537-139">値が 0 の場合、背景はまったく動きません。</span><span class="sxs-lookup"><span data-stu-id="00537-139">A value of 0 means the the background doesn't move at all.</span></span>

<span data-ttu-id="00537-140">値を大きくすると、劇的な効果が発生します。</span><span class="sxs-lookup"><span data-stu-id="00537-140">Larger values create a more dramatic effect.</span></span> 

<span data-ttu-id="00537-141">視差をカスタマイズする方法の完全な一覧については、ParallaxView クラスをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00537-141">For the complete list of ways to customize parallax, see the ParallaxView class.</span></span> 

## <a name="dos-and-donts"></a><span data-ttu-id="00537-142">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="00537-142">Do’s and don’ts</span></span>
- <span data-ttu-id="00537-143">視差は、背景画像を持つリストで使用してください</span><span class="sxs-lookup"><span data-stu-id="00537-143">Use parallax in lists with a background image</span></span>
- <span data-ttu-id="00537-144">ListViewItems に画像が含まれている場合は、ListViewItems で視差を使用することを検討してください</span><span class="sxs-lookup"><span data-stu-id="00537-144">Consider using parallax in ListViewItems when ListViewItems contain an image</span></span>
- <span data-ttu-id="00537-145">視差はアプリの数か所で使用してください。視差を過剰に使用すると、その効果が低下する可能性があります</span><span class="sxs-lookup"><span data-stu-id="00537-145">Don’t use it everywhere, overuse can diminish its impact</span></span>

## <a name="related-articles"></a><span data-ttu-id="00537-146">関連記事</span><span class="sxs-lookup"><span data-stu-id="00537-146">Related articles</span></span>
- **[<span data-ttu-id="00537-147">ParallaxView クラス</span><span class="sxs-lookup"><span data-stu-id="00537-147">ParallaxView class</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Parallaxview)** 
