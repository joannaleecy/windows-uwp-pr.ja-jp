---
author: jwmsft
ms.assetid: 79CF3927-25DE-43DD-B41A-87E6768D5C35
title: "XAML レイアウトの最適化"
description: "レイアウトは、CPU 使用率とメモリ オーバーヘッドの両方で、XAML アプリの負荷の高い部分です。 ここでは、XAML アプリのレイアウトのパフォーマンスを向上させるための簡単な手順を示します。"
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 40afd15da7e225ea82814ab2fa680a3c95e00488
ms.sourcegitcommit: ec18e10f750f3f59fbca2f6a41bf1892072c3692
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/14/2017
---
# <a name="optimize-your-xaml-layout"></a><span data-ttu-id="916f9-105">XAML レイアウトの最適化</span><span class="sxs-lookup"><span data-stu-id="916f9-105">Optimize your XAML layout</span></span>

<span data-ttu-id="916f9-106">\[ Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="916f9-106">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="916f9-107">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="916f9-107">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

**<span data-ttu-id="916f9-108">重要な API</span><span class="sxs-lookup"><span data-stu-id="916f9-108">Important APIs</span></span>**

-   [**<span data-ttu-id="916f9-109">Panel</span><span class="sxs-lookup"><span data-stu-id="916f9-109">Panel</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR227511)

<span data-ttu-id="916f9-110">レイアウトは、UI の視覚的な構造を定義するプロセスです。</span><span class="sxs-lookup"><span data-stu-id="916f9-110">Layout is the process of defining the visual structure for your UI.</span></span> <span data-ttu-id="916f9-111">XAML でレイアウトを記述するための主要なメカニズムはパネルです。パネルは、UI 要素を内部に配置して整列できるコンテナー オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="916f9-111">The primary mechanism for describing layout in XAML is through panels, which are container objects that enable you to position and arrange the UI elements within them.</span></span> <span data-ttu-id="916f9-112">レイアウトは、CPU 使用率とメモリ オーバーヘッドの両方で、XAML アプリの負荷の高い部分です。</span><span class="sxs-lookup"><span data-stu-id="916f9-112">Layout can be an expensive part of a XAML app—both in CPU usage and memory overhead.</span></span> <span data-ttu-id="916f9-113">ここでは、XAML アプリのレイアウトのパフォーマンスを向上させるための簡単な手順を示します。</span><span class="sxs-lookup"><span data-stu-id="916f9-113">Here are some simple steps you can take to improve the layout performance of your XAML app.</span></span>

## <a name="reduce-layout-structure"></a><span data-ttu-id="916f9-114">レイアウトの構造を減らす</span><span class="sxs-lookup"><span data-stu-id="916f9-114">Reduce layout structure</span></span>

<span data-ttu-id="916f9-115">レイアウトのパフォーマンス向上の効果が最も大きいのは、UI 要素のツリーの階層構造を簡略化することです。</span><span class="sxs-lookup"><span data-stu-id="916f9-115">The biggest gain in layout performance comes from simplifying the hierarchical structure of the tree of UI elements.</span></span> <span data-ttu-id="916f9-116">パネルはビジュアル ツリーに存在しますが、これらは構造型の要素であり、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) や [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/BR243371) などの*ピクセル生成要素*ではありません。</span><span class="sxs-lookup"><span data-stu-id="916f9-116">Panels exist in the visual tree, but they are structural elements, not *pixel producing elements* like a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) or a [**Rectangle**](https://msdn.microsoft.com/library/windows/apps/BR243371).</span></span> <span data-ttu-id="916f9-117">通常、非ピクセル生成要素の数を減らすことによりツリーを簡略化すると、パフォーマンスの大幅な向上につながります。</span><span class="sxs-lookup"><span data-stu-id="916f9-117">Simplifying the tree by reducing the number of non-pixel-producing elements typically provides a significant performance increase.</span></span>

<span data-ttu-id="916f9-118">多くの UI は、パネルを入れ子にすることによって実装されており、結果として、パネルと要素のツリーが深くて複雑な構造になっています。</span><span class="sxs-lookup"><span data-stu-id="916f9-118">Many UIs are implemented by nesting panels which results in deep, complex trees of panels and elements.</span></span> <span data-ttu-id="916f9-119">パネルを入れ子にすると便利ですが、多くの場合は、同じ UI をより複雑な 1 つのパネルを使って実現することができます。</span><span class="sxs-lookup"><span data-stu-id="916f9-119">It is convenient to nest panels, but in many cases the same UI can be achieved with a more complex single panel.</span></span> <span data-ttu-id="916f9-120">1 つのパネルを使用すると、パフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="916f9-120">Using a single panel provides better performance.</span></span>

### <a name="when-to-reduce-layout-structure"></a><span data-ttu-id="916f9-121">レイアウトの構造を減らす場合</span><span class="sxs-lookup"><span data-stu-id="916f9-121">When to reduce layout structure</span></span>

<span data-ttu-id="916f9-122">単純な方法でレイアウトの構造を減らす (たとえば、トップレベルのページから、入れ子になったパネルを 1 つ減らす) だけでは、大きな効果は得られません。</span><span class="sxs-lookup"><span data-stu-id="916f9-122">Reducing layout structure in a trivial way—for example, reducing one nested panel from your top-level page—does not have a noticeable effect.</span></span>

<span data-ttu-id="916f9-123">パフォーマンスの向上が最も大きいのは、[**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) や [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705) などの UI 内で繰り返されるレイアウト構造を減らすことです。</span><span class="sxs-lookup"><span data-stu-id="916f9-123">The largest performance gains come from reducing layout structure that's repeated in the UI, like in a [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) or [**GridView**](https://msdn.microsoft.com/library/windows/apps/BR242705).</span></span> <span data-ttu-id="916f9-124">これらの [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) 要素は [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348) を使用します。これは、何度もをインスタンス化される UI 要素のサブツリーを定義します。</span><span class="sxs-lookup"><span data-stu-id="916f9-124">These [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) elements use a [**DataTemplate**](https://msdn.microsoft.com/library/windows/apps/BR242348), which defines a subtree of UI elements that is instantiated many times.</span></span> <span data-ttu-id="916f9-125">同じサブツリーがアプリ内で何度も複製されている場合、そのサブツリーのパフォーマンスが少しでも向上すれば、アプリの全体的なパフォーマンスへの効果は何倍にもなります。</span><span class="sxs-lookup"><span data-stu-id="916f9-125">When the same subtree is being duplicated many times in your app, any improvements to the performance of that subtree has a multiplicative effect on the overall performance of your app.</span></span>

### <a name="examples"></a><span data-ttu-id="916f9-126">例</span><span class="sxs-lookup"><span data-stu-id="916f9-126">Examples</span></span>

<span data-ttu-id="916f9-127">次のような UI を考えてみます。</span><span class="sxs-lookup"><span data-stu-id="916f9-127">Consider the following UI.</span></span>

![フォーム レイアウトの例](images/layout-perf-ex1.png)

<span data-ttu-id="916f9-129">これらの例では、同じ UI を実装するための 3 つの方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="916f9-129">These examples shows 3 ways of implementing the same UI.</span></span> <span data-ttu-id="916f9-130">どの実装を選択した場合も画面上のピクセル数をほぼ同じ結果になりますが、実装の詳細は大きく異なります。</span><span class="sxs-lookup"><span data-stu-id="916f9-130">Each implementation choice results in nearly identical pixels on the screen, but differs substantially in the implementation details.</span></span>

<span data-ttu-id="916f9-131">オプション 1: 入れ子になった [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) 要素</span><span class="sxs-lookup"><span data-stu-id="916f9-131">Option1: Nested [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) elements</span></span>

<span data-ttu-id="916f9-132">これは最も簡単なモデルですが、5 つのパネル要素を使用し、大きなオーバーヘッドが生じます。</span><span class="sxs-lookup"><span data-stu-id="916f9-132">Although this is the simplest model, it uses 5 panel elements and results in significant overhead.</span></span>

```xml
  <StackPanel>
  <TextBlock Text="Options:" />
  <StackPanel Orientation="Horizontal">
      <CheckBox Content="Power User" />
      <CheckBox Content="Admin" Margin="20,0,0,0" />
  </StackPanel>
  <TextBlock Text="Basic information:" />
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Name:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Email:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <StackPanel Orientation="Horizontal">
      <TextBlock Text="Password:" Width="75" />
      <TextBox Width="200" />
  </StackPanel>
  <Button Content="Save" />
</StackPanel>
```

<span data-ttu-id="916f9-133">オプション 2: 1 つの [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)</span><span class="sxs-lookup"><span data-stu-id="916f9-133">Option 2: A single [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)</span></span>

<span data-ttu-id="916f9-134">[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) は多少複雑になりますが、1 つのパネル要素のみを使用します。</span><span class="sxs-lookup"><span data-stu-id="916f9-134">The [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) adds some complexity, but uses only a single panel element.</span></span>

```xml
  <Grid>
  <Grid.RowDefinitions>
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
      <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>
  <Grid.ColumnDefinitions>
      <ColumnDefinition Width="Auto" />
      <ColumnDefinition Width="Auto" />
  </Grid.ColumnDefinitions>
  <TextBlock Text="Options:" Grid.ColumnSpan="2" />
  <CheckBox Content="Power User" Grid.Row="1" Grid.ColumnSpan="2" />
  <CheckBox Content="Admin" Margin="150,0,0,0" Grid.Row="1" Grid.ColumnSpan="2" />
  <TextBlock Text="Basic information:" Grid.Row="2" Grid.ColumnSpan="2" />
  <TextBlock Text="Name:" Width="75" Grid.Row="3" />
  <TextBox Width="200" Grid.Row="3" Grid.Column="1" />
  <TextBlock Text="Email:" Width="75" Grid.Row="4" />
  <TextBox Width="200" Grid.Row="4" Grid.Column="1" />
  <TextBlock Text="Password:" Width="75" Grid.Row="5" />
  <TextBox Width="200" Grid.Row="5" Grid.Column="1" />
  <Button Content="Save" Grid.Row="6" />
</Grid>
```

<span data-ttu-id="916f9-135">オプション 3: 1 つの [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546)</span><span class="sxs-lookup"><span data-stu-id="916f9-135">Option 3: A single [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546):</span></span>

<span data-ttu-id="916f9-136">この 1 つのパネルも、入れ子になったパネルを使用する場合よりも少し複雑ですが、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) よりも理解しやすく、保守が容易になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="916f9-136">This single panel is also a bit more complex than using nested panels, but may be easier to understand and maintain than a [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704).</span></span>

```xml
<RelativePanel>
  <TextBlock Text="Options:" x:Name="Options" />
  <CheckBox Content="Power User" x:Name="PowerUser" RelativePanel.Below="Options" />
  <CheckBox Content="Admin" Margin="20,0,0,0" 
            RelativePanel.RightOf="PowerUser" RelativePanel.Below="Options" />
  <TextBlock Text="Basic information:" x:Name="BasicInformation"
           RelativePanel.Below="PowerUser" />
  <TextBlock Text="Name:" RelativePanel.AlignVerticalCenterWith="NameBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="NameBox"               
           RelativePanel.Below="BasicInformation" />
  <TextBlock Text="Email:"  RelativePanel.AlignVerticalCenterWith="EmailBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="EmailBox"
           RelativePanel.Below="NameBox" />
  <TextBlock Text="Password:" RelativePanel.AlignVerticalCenterWith="PasswordBox" />
  <TextBox Width="200" Margin="75,0,0,0" x:Name="PasswordBox"
           RelativePanel.Below="EmailBox" />
  <Button Content="Save" RelativePanel.Below="PasswordBox" />
</RelativePanel>
```

<span data-ttu-id="916f9-137">これらの例が示すように、同じ UI を実現するにはさまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="916f9-137">As these examples show, there are many ways of achieving the same UI.</span></span> <span data-ttu-id="916f9-138">パフォーマンス、読みやすさ、保守容易性を含む、すべてのトレードオフを慎重に検討して選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="916f9-138">You should choose by carefully considering all the tradeoffs, including performance, readability, and maintainability.</span></span>

## <a name="use-single-cell-grids-for-overlapping-ui"></a><span data-ttu-id="916f9-139">重なり合った UI としての単一セルのグリッドの使用</span><span class="sxs-lookup"><span data-stu-id="916f9-139">Use single-cell grids for overlapping UI</span></span>

<span data-ttu-id="916f9-140">一般的な UI 要件として、要素が互いに重なり合ったレイアウトがあります。</span><span class="sxs-lookup"><span data-stu-id="916f9-140">A common UI requirement is to have a layout where elements overlap each other.</span></span> <span data-ttu-id="916f9-141">通常、この方法で要素を配置するために、パディング、余白、整列、変換が使用されます。</span><span class="sxs-lookup"><span data-stu-id="916f9-141">Typically padding, margins, alignments, and transforms are used to position the elements this way.</span></span> <span data-ttu-id="916f9-142">XAML [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) コントロールは、重なり合った要素のレイアウトのパフォーマンスを向上させるために最適化されています。</span><span class="sxs-lookup"><span data-stu-id="916f9-142">The XAML [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) control is optimized to improve layout performance for elements that overlap.</span></span>

<span data-ttu-id="916f9-143">**重要**  パフォーマンスの向上を確認するために、単一セルの [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) を使用します。</span><span class="sxs-lookup"><span data-stu-id="916f9-143">**Important**  To see the improvement, use a single-cell [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704).</span></span> <span data-ttu-id="916f9-144">[**RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.rowdefinitions) や [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.columndefinitions) は定義しないでください。</span><span class="sxs-lookup"><span data-stu-id="916f9-144">Do not define [**RowDefinitions**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.rowdefinitions) or [**ColumnDefinitions**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.grid.columndefinitions).</span></span>

### <a name="examples"></a><span data-ttu-id="916f9-145">例</span><span class="sxs-lookup"><span data-stu-id="916f9-145">Examples</span></span>

```xml
<Grid>
    <Ellipse Fill="Red" Width="200" Height="200" />
    <TextBlock Text="Test" 
               HorizontalAlignment="Center" 
               VerticalAlignment="Center" />
</Grid>
```

![円の上にオーバーレイされたテキスト](images/layout-perf-ex2.png)

```xml
<Grid Width="200" BorderBrush="Black" BorderThickness="1">
    <TextBlock Text="Test1" HorizontalAlignment="Left" />
    <TextBlock Text="Test2" HorizontalAlignment="Right" />
</Grid>
```

![グリッド内の 2 つのテキスト ブロック](images/layout-perf-ex3.png)

## <a name="use-a-panels-built-in-border-properties"></a><span data-ttu-id="916f9-148">パネルの組み込みの境界線プロパティを使う</span><span class="sxs-lookup"><span data-stu-id="916f9-148">Use a panel's built-in border properties</span></span>

<span data-ttu-id="916f9-149">[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546)、[**ContentPresenter**](https://msdn.microsoft.com/library/windows/apps/BR209378) の各コントロールには組み込みの境界線プロパティがあり、XAML に [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) 要素を追加せずに周囲に境界線を描画できます。</span><span class="sxs-lookup"><span data-stu-id="916f9-149">[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704), [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635), [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546), and [**ContentPresenter**](https://msdn.microsoft.com/library/windows/apps/BR209378) controls have built-in border properties that let you draw a border around them without adding an additional [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) element to your XAML.</span></span> <span data-ttu-id="916f9-150">組み込みの境界線をサポートする新しいプロパティは、**BorderBrush**、**BorderThickness**、**CornerRadius**、**Padding** です。</span><span class="sxs-lookup"><span data-stu-id="916f9-150">The new properties that support the built-in border are: **BorderBrush**, **BorderThickness**, **CornerRadius**, and **Padding**.</span></span> <span data-ttu-id="916f9-151">これらはそれぞれ [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362) であり、バインディングやアニメーションで使用することができます。</span><span class="sxs-lookup"><span data-stu-id="916f9-151">Each of these is a [**DependencyProperty**](https://msdn.microsoft.com/library/windows/apps/BR242362), so you can use them with bindings and animations.</span></span> <span data-ttu-id="916f9-152">これらは、個別の **Border** 要素を完全に置き換えるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="916f9-152">They’re designed to be a full replacement for a separate **Border** element.</span></span>

<span data-ttu-id="916f9-153">UI でこれらのパネルの周囲に [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) 要素を使っている場合は、代わりに組み込みの境界線を使うことによって、アプリのレイアウト構造内で余分な要素を削減できます。</span><span class="sxs-lookup"><span data-stu-id="916f9-153">If your UI has [**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) elements around these panels, use the built-in border instead, which saves an extra element in the layout structure of your app.</span></span> <span data-ttu-id="916f9-154">既に説明したように、特に繰り返される UI の場合は、大幅に要素を削減できます。</span><span class="sxs-lookup"><span data-stu-id="916f9-154">As mentioned previously, this can be a significant savings, especially in the case of repeated UI.</span></span>

### <a name="examples"></a><span data-ttu-id="916f9-155">例</span><span class="sxs-lookup"><span data-stu-id="916f9-155">Examples</span></span>

```xml
<RelativePanel BorderBrush="Red" BorderThickness="2" CornerRadius="10" Padding="12">
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

## <a name="use-sizechanged-events-to-respond-to-layout-changes"></a><span data-ttu-id="916f9-156">**SizeChanged** イベントを使ってレイアウトの変更に応答する</span><span class="sxs-lookup"><span data-stu-id="916f9-156">Use **SizeChanged** events to respond to layout changes</span></span>

<span data-ttu-id="916f9-157">[**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) クラスは、レイアウト変更に応答するための 2 つの類似したイベント [**LayoutUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.layoutupdated) と [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged) を公開します。</span><span class="sxs-lookup"><span data-stu-id="916f9-157">The [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) class exposes two similar events for responding to layout changes: [**LayoutUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.layoutupdated) and [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged).</span></span> <span data-ttu-id="916f9-158">レイアウト時に、要素のサイズが変更された場合、これらのイベントのいずれかを使用して通知を受信していることがあります。</span><span class="sxs-lookup"><span data-stu-id="916f9-158">You might be using one of these events to receive notification when an element is resized during layout.</span></span> <span data-ttu-id="916f9-159">2 つのイベントのセマンティクスは異なり、どちらを選択するかは、パフォーマンスに関する重要な考慮事項です。</span><span class="sxs-lookup"><span data-stu-id="916f9-159">The semantics of the two events are different, and there are important performance considerations in choosing between them.</span></span>

<span data-ttu-id="916f9-160">パフォーマンスを向上させるには、ほとんどの場合 [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged) が適切な選択肢です。</span><span class="sxs-lookup"><span data-stu-id="916f9-160">For good performance, [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.sizechanged) is almost always the right choice.</span></span> <span data-ttu-id="916f9-161">**SizeChanged** のセマンティクスは直感的です。</span><span class="sxs-lookup"><span data-stu-id="916f9-161">**SizeChanged** has intuitive semantics.</span></span> <span data-ttu-id="916f9-162">このイベントは、レイアウト中に [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) のサイズが更新されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="916f9-162">It is raised during layout when the size of the [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/BR208706) has been updated.</span></span>

<span data-ttu-id="916f9-163">[**LayoutUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.layoutupdated) もレイアウト時に発生しますが、そのセマンティクスはグローバルです。任意の要素が更新されるたびにすべての要素について発生します。</span><span class="sxs-lookup"><span data-stu-id="916f9-163">[**LayoutUpdated**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.frameworkelement.layoutupdated) is also raised during layout, but it has global semantics—it is raised on every element whenever any element is updated.</span></span> <span data-ttu-id="916f9-164">イベント ハンドラーではローカルな処理のみを行うことが一般的であり、この場合、コードは必要以上に頻繁に実行されます。</span><span class="sxs-lookup"><span data-stu-id="916f9-164">It is typical to only do local processing in the event handler, in which case the code is run more often than needed.</span></span> <span data-ttu-id="916f9-165">**LayoutUpdated** は、サイズを変更せずに要素が再配置されたことを知る必要がある場合 (一般的ではありません) にのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="916f9-165">Use **LayoutUpdated** only if you need to know when an element is repositioned without changing size (which is uncommon).</span></span>

## <a name="choosing-between-panels"></a><span data-ttu-id="916f9-166">パネルの選択</span><span class="sxs-lookup"><span data-stu-id="916f9-166">Choosing between panels</span></span>

<span data-ttu-id="916f9-167">通常、パフォーマンスは、個々のパネルを選択するときの検討事項ではありません。</span><span class="sxs-lookup"><span data-stu-id="916f9-167">Performance is typically not a consideration when choosing between individual panels.</span></span> <span data-ttu-id="916f9-168">パネルの選択は、実装しようとする UI に最も近いレイアウトの動作を実現するパネルを検討することによって行われます。</span><span class="sxs-lookup"><span data-stu-id="916f9-168">That choice is typically made by considering which panel provides the layout behavior that is closest to the UI you’re implementing.</span></span> <span data-ttu-id="916f9-169">たとえば、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546) のいずれかを選択する場合、実装の概念的モデルに最も近いマッピングを提供するパネルを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="916f9-169">For example, if you’re choosing between [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704), [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) , and [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/Dn879546), you should choose the panel that provides the closest mapping to your mental model of the implementation.</span></span>

<span data-ttu-id="916f9-170">どの XAML パネルもパフォーマンスが高くなるように最適化されており、同様の UI ではどのパネルのパフォーマンスも同様です。</span><span class="sxs-lookup"><span data-stu-id="916f9-170">Every XAML panel is optimized for good performance, and all the panels provide similar performance for similar UI.</span></span>

