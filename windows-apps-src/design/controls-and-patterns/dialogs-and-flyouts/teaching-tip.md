---
ms.openlocfilehash: 15379e51f8c272d0cc1e888684322104186bb200
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59249504"
---
# <a name="teaching-tip"></a><span data-ttu-id="8ff52-101">教育のヒント</span><span class="sxs-lookup"><span data-stu-id="8ff52-101">Teaching tip</span></span>

<span data-ttu-id="8ff52-102">教育のヒントは、半永続的なと、豊富なコンテンツのポップアップで、コンテキスト情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-102">A teaching tip is a semi-persistent and content-rich flyout that provides contextual information.</span></span> <span data-ttu-id="8ff52-103">通知、通知、および感を高めることがあり、重要な新しい機能についてユーザーに知らせることがよく使用されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-103">It is often used for informing, reminding, and teaching users about important and new features that may enhance their experience.</span></span>

<span data-ttu-id="8ff52-104">**重要な Api:**[TeachingTip クラス](https://docs.microsoft.com/en-us/uwp/api/microsoft.ui.xaml.controls.teachingtip)</span><span class="sxs-lookup"><span data-stu-id="8ff52-104">**Important APIs:** [TeachingTip class](https://docs.microsoft.com/en-us/uwp/api/microsoft.ui.xaml.controls.teachingtip)</span></span>

<span data-ttu-id="8ff52-105">教育のヒントがあります光無視または明示的なアクションを閉じる必要があります。</span><span class="sxs-lookup"><span data-stu-id="8ff52-105">A teaching tip may be light-dismiss or require explicit action to close.</span></span> <span data-ttu-id="8ff52-106">教育のヒントを末尾に特定の UI 要素をターゲットにして末尾またはターゲットなしでも使用します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-106">A teaching tip can target a specific UI element with its tail and also be used without a tail or target.</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="8ff52-107">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="8ff52-107">Is this the right control?</span></span> 

<span data-ttu-id="8ff52-108">使用して、 **TeachingTip**経験の向上またはタスクの完了方法をユーザーに教えるされる重要でないオプションのユーザーに通知する新規または重要な更新プログラムと機能にユーザーの注意を集中するコントロール。</span><span class="sxs-lookup"><span data-stu-id="8ff52-108">Use a **TeachingTip** control to focus a user's attention on new or important updates and features, remind a user of nonessential options that would improve their experience, or teach a user how a task should be completed.</span></span> 

<span data-ttu-id="8ff52-109">教育のヒントは一時的であるためにはならないユーザー エラーまたは状態に関する重要な変更についてのプロンプトの推奨されるコントロールです。</span><span class="sxs-lookup"><span data-stu-id="8ff52-109">Because teaching tip is transient, it would not be the recommended control for prompting users about errors or important status changes.</span></span>


## <a name="examples"></a><span data-ttu-id="8ff52-110">例</span><span class="sxs-lookup"><span data-stu-id="8ff52-110">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="8ff52-111">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="8ff52-111">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="8ff52-112">ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/TeachingTip">アプリを開き、アクションで TeachingTip を参照してください。</a>します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-112">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/TeachingTip">open the app and see the TeachingTip in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="8ff52-113">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="8ff52-113">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery"><span data-ttu-id="8ff52-114">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="8ff52-114">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="8ff52-115">教育のヒントには、これらの注目すべきものを含む、いくつかの構成を持つことができます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-115">A teaching tip can have several configurations, including these notable ones.</span></span>

<span data-ttu-id="8ff52-116">特定の UI 要素を表示する情報のコンテキストの鮮明さを強化するためには、その末尾で教育ヒント対象にできます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-116">A teaching tip can target a specific UI element with its tail to enhance contextual clarity of the information it is presenting.</span></span> 

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。](../images/teaching-tip-targeted.png)

<span data-ttu-id="8ff52-120">表示される情報は、特定の UI 要素には関連しません、ときに、末尾を削除することによって nontargeted 教育ヒントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-120">When the information presented does not pertain to a particular UI element, a nontargeted teaching tip can be created by removing the tail.</span></span>

![右下隅に教育ヒントを使ってサンプル アプリです。](../images/teaching-tip-non-targeted.png)

<span data-ttu-id="8ff52-124">教育ヒントは、上の隅で、"X"ボタンまたは下部にある [閉じる] ボタンを使用して閉じることをユーザーに要求できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-124">A teaching tip can require the user to dismiss it via an "X" button in a top corner or a "Close" button at the bottom.</span></span> <span data-ttu-id="8ff52-125">教育ヒント可能性がありますもされる光-閉じる閉じるボタンが有効な場合は、ユーザーがスクロールしたり、アプリケーションの他の要素とやり取り教育ヒントを閉じる代わりにします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-125">A teaching tip may also be light-dismiss enabled in which case there is no dismiss button and the teaching tip will instead dismiss when a user scrolls or interacts with other elements of the application.</span></span> <span data-ttu-id="8ff52-126">この動作によりライト-無視のヒントは、最適なソリューション、ヒントは、スクロール可能な領域に配置する必要がある場合。</span><span class="sxs-lookup"><span data-stu-id="8ff52-126">Because of this behavior, light-dismiss tips are the best solution when a tip needs to be placed in a scrollable area.</span></span> 

![使ってサンプル アプリの右下隅で教育ヒントのライトの破棄します。](../images/teaching-tip-light-dismiss.png)


### <a name="create-a-teaching-tip"></a><span data-ttu-id="8ff52-129">教育ヒントを作成します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-129">Create a teaching tip</span></span>

<span data-ttu-id="8ff52-130">ここでは、対象となる教育の XAML コントロールのタイトルとサブタイトル TeachingTip の既定の外観を示すヒントします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-130">Here's the XAML for a targeted teaching tip control that demonstrates the default look of the TeachingTip with a title and subtitle.</span></span> <span data-ttu-id="8ff52-131">教育のヒントに含まれる任意の場所、要素ツリーまたは分離コードに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8ff52-131">Note that the teaching tip can appear anywhere in the element tree or code behind.</span></span> <span data-ttu-id="8ff52-132">次の例には ResourceDictionary にあります。</span><span class="sxs-lookup"><span data-stu-id="8ff52-132">In this example below, it's located in a ResourceDictionary.</span></span>

<span data-ttu-id="8ff52-133">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-133">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save">
    <Button.Resources>
        <controls:TeachingTip x:Name="AutoSaveTip"
            Target="{x:Bind SaveButton}"
            Title="Save automatically"
            Subtitle="When you save your file to OneDrive, we save your changes as you go - so you never have to.">
        </controls:TeachingTip>
    </Button.Resources>
</Button>
```

<span data-ttu-id="8ff52-134">C#</span><span class="sxs-lookup"><span data-stu-id="8ff52-134">C#</span></span>
```C#
public MainPage()
{
    this.InitializeComponent();

    if(!HaveExplainedAutoSave())
    {
        AutoSaveTip.IsOpen = true;
        SetHaveExplainedAutoSave();
    }
}
```

<span data-ttu-id="8ff52-135">次ページ ボタンを含むと教えるヒントが表示されるときに、結果を示します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-135">Here's the result when the Page containing the button and teaching tip is shown:</span></span>

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。](../images/teaching-tip-targeted.png)

### <a name="non-targeted-tips"></a><span data-ttu-id="8ff52-139">非対象のヒント</span><span class="sxs-lookup"><span data-stu-id="8ff52-139">Non-targeted tips</span></span>

<span data-ttu-id="8ff52-140">すべてのヒントは、画面に表示される要素に関連します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-140">Not all tips relate to an element onscreen.</span></span> <span data-ttu-id="8ff52-141">これらのシナリオでは、ターゲット プロパティを設定しないし、教育ヒントは xaml ルートの端を基準とした代わりに表示されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-141">For these scenarios, do not set the Target property and the teaching tip will instead display relative to the edges of the xaml root.</span></span> <span data-ttu-id="8ff52-142">ただし、教育ヒントでは、末尾に「折りたたまれた」TailVisibility プロパティを設定して、UI 要素の相対的な位置を維持したまま削除することができます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-142">However, a teaching tip can have the tail removed while retaining placement relative to a UI element by setting the TailVisibility property to "Collapsed".</span></span> <span data-ttu-id="8ff52-143">次の例では、教育の対象外のヒントの。</span><span class="sxs-lookup"><span data-stu-id="8ff52-143">The following example is of a non-targeted teaching tip.</span></span>

<span data-ttu-id="8ff52-144">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-144">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to.">
</controls:TeachingTip>
```

<span data-ttu-id="8ff52-145">この例では、TeachingTip が要素ツリーではなく ResourceDictionary または分離コードに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8ff52-145">Note that in this example the TeachingTip is in the element tree rather than in a ResourceDictionary or in code behind.</span></span> <span data-ttu-id="8ff52-146">これは、動作に影響はありません。TeachingTip はのみを表示する場合、し、レイアウト スペースを占有します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-146">This has no effect on behavior; the TeachingTip only displays when opened, and takes up no layout space.</span></span>

![右下隅に教育ヒントを使ってサンプル アプリです。](../images/teaching-tip-non-targeted.png)

### <a name="preferred-placement"></a><span data-ttu-id="8ff52-150">推奨される配置</span><span class="sxs-lookup"><span data-stu-id="8ff52-150">Preferred placement</span></span>

<span data-ttu-id="8ff52-151">教育ヒント レプリケート フライアウトの[FlyoutPlacementMode](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode) TeachingTipPlacementMode プロパティを使用して配置動作。</span><span class="sxs-lookup"><span data-stu-id="8ff52-151">Teaching tip replicates Flyout's [FlyoutPlacementMode](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode) placement behavior with the TeachingTipPlacementMode property.</span></span> <span data-ttu-id="8ff52-152">既定の配置モードは、ターゲット上の対象となる教育ヒントと対象外の教育ヒントが xaml ルートの下部中央に配置しようとします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-152">The default placement mode will try to place a targeted teaching tip above its target and a non-targeted teaching tip centered at the bottom of the xaml root.</span></span> <span data-ttu-id="8ff52-153">として、フライアウトで推奨される配置モードは、教育のヒントを表示する余裕を確保していない場合別の配置モードが自動的に選択されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-153">As with Flyout, if the preferred placement mode would not leave room for the teaching tip to show, another placement mode will be automatically chosen.</span></span> 

<span data-ttu-id="8ff52-154">Gamepad 入力を予測するアプリケーションを参照してください[ゲームパッドとリモート制御の相互作用]( https://docs.microsoft.com/en-us/windows/uwp/design/input/gamepad-and-remote-interactions#xy-focus-navigation-and-interaction)します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-154">For applications that predict gamepad input, please see [gamepad and remote control interactions]( https://docs.microsoft.com/en-us/windows/uwp/design/input/gamepad-and-remote-interactions#xy-focus-navigation-and-interaction).</span></span> <span data-ttu-id="8ff52-155">アプリの UI のすべての可能な構成を使用して各教育ヒントのゲームパッド アクセシビリティをテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-155">It is encouraged to test gamepad accessibility of each teaching tip using all possible configurations of an app's UI.</span></span>

<span data-ttu-id="8ff52-156">左にシフトして、教育ヒントの本文と共に、そのターゲットの下部中央に末尾に「斜め」に設定、PreferredPlacement を対象となる教育ヒントが表示されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-156">A targeted teaching tip with its PreferredPlacement set to "BottomLeft" will appear with the tail centered at the bottom of its target with the teaching tip's body shifted toward the left.</span></span>

<span data-ttu-id="8ff52-157">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-157">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save">
    <Button.Resources>
        <controls:TeachingTip x:Name="AutoSaveTip"
            Target="{x:Bind SaveButton}"
            Title="Saving automatically"
            Subtitle="We save your changes as you go - so you never have to."
            PreferredPlacement="BottomLeft">
        </controls:TeachingTip>
    </Button.Resources>
</Button>
```

![[保存] ボタンの左下にある教育 tip によって対象を使ってサンプル アプリです。](../images/teaching-tip-targeted-preferred-placement.png)


<span data-ttu-id="8ff52-161">「斜め」に設定、PreferredPlacement と教育の対象外のヒントは、xaml のルートの左下隅に表示されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-161">A non-targeted teaching tip with its PreferredPlacement set to "BottomLeft" will appear in the bottom left corner of the xaml root.</span></span>

<span data-ttu-id="8ff52-162">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-162">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    PreferredPlacement="BottomLeft">
</controls:TeachingTip>
```

![左下隅に教育ヒントを使ってサンプル アプリです。](../images/teaching-tip-non-targeted-preferred-placement.png)

<span data-ttu-id="8ff52-166">次の図は、ヒントの講義を対象に指定可能なすべての 13 PreferredPlacement モードの結果を示しています。</span><span class="sxs-lookup"><span data-stu-id="8ff52-166">The diagram below depicts the result of all 13 PreferredPlacement modes that can be set for targeted teaching tips.</span></span>
![3 つのオブジェクト ラベルが付いた「ターゲット」周囲に教育ヒントの推奨される対象の配置モードを表示するために使用するヒントの講義を対象とします。](../images/teaching-tip-targeted-preferred-placement-modes.png)

<span data-ttu-id="8ff52-181">次の図は、教育の対象外のヒントを設定できるすべての 13 PreferredPlacement モードの結果を示しています。</span><span class="sxs-lookup"><span data-stu-id="8ff52-181">The diagram below depicts the result of all 13 PreferredPlacement modes that can be set for non-targeted teaching tips.</span></span>
![<span data-ttu-id="8ff52-182">教育ヒントの推奨される配置の対象外のモードを示すために 9 つの対象外の教育ヒントを表示するアプリ ウィンドウです。</span><span class="sxs-lookup"><span data-stu-id="8ff52-182">An app window showing nine non-targeted teaching tips to demonstrate teaching tip's non-targeted preferred placement modes.</span></span> <span data-ttu-id="8ff52-183">アプリの左上隅にある教育ヒントのラベルは「左上端または LeftTop」</span><span class="sxs-lookup"><span data-stu-id="8ff52-183">The teaching tip in the top left corner of the app is labeled "TopLeft or LeftTop."</span></span> <span data-ttu-id="8ff52-184">"Top"というラベルが付いた、アプリの上端を中心と教育のヒント</span><span class="sxs-lookup"><span data-stu-id="8ff52-184">The teaching tip centered at the app's top edge is labeled "Top."</span></span> <span data-ttu-id="8ff52-185">アプリの右上隅にある教育ヒントが「右または RightTop」というラベルが付いた</span><span class="sxs-lookup"><span data-stu-id="8ff52-185">The teaching tip in the top right corner of the app is labeled "TopRight or RightTop."</span></span> <span data-ttu-id="8ff52-186">"Left"というラベルが付いた、アプリの左端を中心と教育のヒント</span><span class="sxs-lookup"><span data-stu-id="8ff52-186">The teaching tip centered at the app's left edge is labeled "Left."</span></span> <span data-ttu-id="8ff52-187">"Center"というラベルが付いた、アプリの中央に教育のヒント</span><span class="sxs-lookup"><span data-stu-id="8ff52-187">The teaching tip centered in the middle of the app is labeled "Center."</span></span>
<span data-ttu-id="8ff52-188">「権限」というラベルが付いた、アプリの右端を中心と教育のヒント</span><span class="sxs-lookup"><span data-stu-id="8ff52-188">The teaching tip centered at the app's right edge is labeled "Right."</span></span> <span data-ttu-id="8ff52-189">アプリの左下隅で教育ヒントが「斜めまたは LeftBottom」というラベルが付いた</span><span class="sxs-lookup"><span data-stu-id="8ff52-189">The teaching tip in the bottom left corner of the app is labeled "BottomLeft or LeftBottom."</span></span> <span data-ttu-id="8ff52-190">アプリの下端を中心と教育のヒントは、"Bottom"というラベルが付いた</span><span class="sxs-lookup"><span data-stu-id="8ff52-190">The teaching tip centered at the app's bottom edge is labeled "Bottom."</span></span> <span data-ttu-id="8ff52-191">アプリの右下隅で教育ヒントが「BottomRight または RightBottom」というラベルが付いた</span><span class="sxs-lookup"><span data-stu-id="8ff52-191">The teaching tip in the bottom right corner of the app is labeled "BottomRight or RightBottom."</span></span>](../images/teaching-tip-non-targeted-preferred-placement-modes.png)

### <a name="add-a-placement-margin"></a><span data-ttu-id="8ff52-192">配置の余白を追加します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-192">Add a placement margin</span></span>  

<span data-ttu-id="8ff52-193">そのターゲットとは別に対象となる教育ヒントを設定する距離と教育の対象外のヒントを PlacementMargin プロパティを使用して xaml ルートの端とは別に設定がどの程度を制御できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-193">You can control how far a targeted teaching tip is set apart from its target and how far a non-targeted teaching tip is set apart from the edges of the xaml root by using the PlacementMargin property.</span></span> <span data-ttu-id="8ff52-194">ような[余白](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.margin)PlacementMargin が 4 つの値、– left、right、top、および下 – のみ、関連する値が使用されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-194">Like [Margin](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.margin), PlacementMargin has four values – left, right, top, and bottom – so only the relevant values are used.</span></span> <span data-ttu-id="8ff52-195">たとえば、ヒントは、ターゲットのまたは xaml ルートの左端のままにした場合に PlacementMargin.Left が適用されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-195">For example, PlacementMargin.Left applies when the tip is left of the target or on the left edge of the xaml root.</span></span>

<span data-ttu-id="8ff52-196">次の例では、すべてのセットを 80 PlacementMargin の左/右/上下の対象外のヒントを示します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-196">The following example shows a non-targeted tip with the PlacementMargin’s Left/Top/Right/Bottom all set to 80.</span></span>

<span data-ttu-id="8ff52-197">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-197">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    PreferredPlacement="BottomLeft"
    PlacementMargin="80">
</controls:TeachingTip>
```

![教育ヒントを表示、方向が、完全なに対する、右下隅に配置されているサンプル アプリです。](../images/teaching-tip-placement-margin.png)


### <a name="add-content"></a><span data-ttu-id="8ff52-201">コンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-201">Add content</span></span>

<span data-ttu-id="8ff52-202">コンテンツは、コンテンツのプロパティを使用して、教育ヒントに追加できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-202">Content can be added to a teaching tip using the Content property.</span></span> <span data-ttu-id="8ff52-203">により教育ヒントのサイズよりも表示する複数のコンテンツがある場合、コンテンツ エリアをスクロールするようにする場合、スクロール バーを自動的に有効になります。</span><span class="sxs-lookup"><span data-stu-id="8ff52-203">If there is more content to show than what the size of a teaching tip will allow, a scrollbar will be automatically enabled to allow a user to scroll the content area.</span></span> 

<span data-ttu-id="8ff52-204">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-204">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save">
    <Button.Resources>
        <controls:TeachingTip x:Name="AutoSaveTip"
            Target="{x:Bind SaveButton}"
            Title="Saving automatically"
            Subtitle="We save your changes as you go - so you never have to.">
                <StackPanel>
                    <CheckBox x:Name="HideTipsCheckBox" Content="Don't show tips at start up" IsChecked="{x:Bind HidingTips, Mode=TwoWay}" />
                    <TextBlock>You can change your tip preferences in <Hyperlink NavigateUri="app:/item/SettingsPage">Settings</Hyperlink> if you change your mind.</TextBlock>
                </StackPanel>
        </controls:TeachingTip>
    </Button.Resources>
</Button>
```

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。](../images/teaching-tip-content.png)

### <a name="add-buttons"></a><span data-ttu-id="8ff52-209">ボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-209">Add buttons</span></span>

<span data-ttu-id="8ff52-210">既定では、標準の"閉じるボタンの X"は教育のヒントのタイトルの横にある表示します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-210">By default, a standard "X" close button is shown next to the title of a teaching tip.</span></span> <span data-ttu-id="8ff52-211">教育ヒントの下部に移動する場合、ボタン、CloseButtonContent プロパティを使用して閉じる ボタンをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-211">The Close button can be customized with the CloseButtonContent property, in which case the button is moved to the bottom of the teaching tip.</span></span>

**<span data-ttu-id="8ff52-212">注:[閉じる] ボタンには表示されませんが有効なヒントを光無視</span><span class="sxs-lookup"><span data-stu-id="8ff52-212">Note: No close button will appear on light-dismiss enabled tips</span></span>**

<span data-ttu-id="8ff52-213">ActionButtonContent プロパティ (および必要に応じて、ActionButtonCommand および ActionButtonCommandParameter プロパティ) を設定して、カスタム アクション ボタンを追加できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-213">A custom action button can be added by setting ActionButtonContent property (and optionally the ActionButtonCommand and the ActionButtonCommandParameter properties).</span></span>

<span data-ttu-id="8ff52-214">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-214">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save">
    <Button.Resources> 
        <controls:TeachingTip x:Name="AutoSaveTip"
            Target="{x:Bind SaveButton}"
            Title="Saving automatically"
            Subtitle="We save your changes as you go - so you never have to."
            ActionButtonContent="Disable"
            ActionButtonCommand="DisableAutoSave"
            CloseButtonContent="Got it!">
                <StackPanel>
                    <CheckBox x:Name="HideTipsCheckBox" Content="Don't show tips at start up" IsChecked="{x:Bind HidingTips, Mode=TwoWay}" />
                    <TextBlock>You can change your tip preferences in <Hyperlink NavigateUri="app:/item/SettingsPage">Settings</Hyperlink> if you change your mind.</TextBlock>
                </StackPanel>
        </controls:TeachingTip>
    </Button.Resources>
</Button>
```

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。](../images/teaching-tip-buttons.png)

### <a name="hero-content"></a><span data-ttu-id="8ff52-219">ヒーローのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="8ff52-219">Hero content</span></span>

<span data-ttu-id="8ff52-220">Edge のコンテンツをエッジは、HeroContent プロパティを設定して、教育のヒントに追加できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-220">Edge to edge content can be added to a teaching tip by setting the HeroContent property.</span></span> <span data-ttu-id="8ff52-221">HeroContentPlacement プロパティを設定して、上または教育ヒントの下にヒーローのコンテンツの場所を設定できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-221">The location of hero content can be set to the top or bottom of a teaching tip by setting the HeroContentPlacement property.</span></span>

<span data-ttu-id="8ff52-222">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-222">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save">
    <Button.Resources> 
        <controls:TeachingTip x:Name="AutoSaveTip"
            Target="{x:Bind SaveButton}"
            Title="Saving automatically"
            Subtitle="We save your changes as you go - so you never have to.">
            <controls:TeachingTip.HeroContent>
                <Image Source="Assets/cloud.png" />
            </controls:TeachingTip.HeroContent>
        </controls:TeachingTip>
    </Button.Resources>
</Button>
```

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。](../images/teaching-tip-hero-content.png)

### <a name="add-an-icon"></a><span data-ttu-id="8ff52-227">アイコンを追加します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-227">Add an icon</span></span>

<span data-ttu-id="8ff52-228">タイトルとサブタイトル IconSource プロパティを使用して横にあるアイコンを追加できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-228">An icon can be added beside the title and subtitle using the IconSource property.</span></span> <span data-ttu-id="8ff52-229">推奨されるアイコンのサイズには、16 px、24px、32px などがあります。</span><span class="sxs-lookup"><span data-stu-id="8ff52-229">Recommended icon sizes include 16px, 24px, and 32px.</span></span> 

<span data-ttu-id="8ff52-230">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-230">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save">
    <Button.Resources>
        <controls:TeachingTip x:Name="AutoSaveTip"
            Target="{x:Bind SaveButton}"
            Title="Saving automatically"
            Subtitle="We save your changes as you go - so you never have to."
            <controls:TeachingTip.IconSource>
                <controls:SymbolIconSource Symbol="Save" />
            </controls:TeachingTip.IconSource>
        </controls:TeachingTip>
    </Button.Resources>
</Button>
```

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。](../images/teaching-tip-icon.png)

### <a name="enable-light-dismiss"></a><span data-ttu-id="8ff52-235">有効にする の light 無視します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-235">Enable light-dismiss</span></span>

<span data-ttu-id="8ff52-236">ライト無視の機能が既定で無効になっていますが、教育ヒントは無視、例については、ユーザーがスクロールしたり、アプリケーションの他の要素とやり取りできるように有効にできます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-236">Light-dismiss functionality is disabled by default but it can enabled so that a teaching tip will dismiss, for example, when a user scrolls or interacts with other elements of the application.</span></span> <span data-ttu-id="8ff52-237">この動作によりライト-無視のヒントは、最適なソリューション、ヒントは、スクロール可能な領域に配置する必要がある場合。</span><span class="sxs-lookup"><span data-stu-id="8ff52-237">Because of this behavior, light-dismiss tips are the best solution when a tip needs to be placed in a scrollable area.</span></span> 

<span data-ttu-id="8ff52-238">閉じるボタンが自動的に識別するために light-dismiss が有効な教育ヒントから削除されます、ユーザー動作のライト無視します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-238">The close button will be automatically removed from a light-dismiss enabled teaching tip to identify its light-dismiss behavior to users.</span></span> 

<span data-ttu-id="8ff52-239">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-239">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    IsLightDismissEnabled="True">
</controls:TeachingTip>
```

![使ってサンプル アプリの右下隅で教育ヒントのライトの破棄します。](../images/teaching-tip-light-dismiss.png)

### <a name="escaping-the-xaml-root-bounds"></a><span data-ttu-id="8ff52-242">Xaml のルートの境界をエスケープ</span><span class="sxs-lookup"><span data-stu-id="8ff52-242">Escaping the xaml root bounds</span></span>

<span data-ttu-id="8ff52-243">Windows のバージョンの 19 H 1 と、教育上のヒントは ShouldConstrainToRootBounds プロパティを設定して xaml ルートと、画面の境界をエスケープできます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-243">On Windows version 19H1 and above, a teaching tip can escape the bounds of the xaml root and the screen by setting the ShouldConstrainToRootBounds property.</span></span> <span data-ttu-id="8ff52-244">このプロパティが有効にすると、教育ヒントしようとしません xaml ルートも画面の境界で状態を維持し、セットの位置では常に PreferredPlacement モード。</span><span class="sxs-lookup"><span data-stu-id="8ff52-244">When this property is enabled, a teaching tip will not attempt to stay in the bounds of the xaml root nor the screen and will always position at the set PreferredPlacement mode.</span></span> <span data-ttu-id="8ff52-245">IsLightDismissEnabled プロパティを有効にして、ユーザーの最適なエクスペリエンスを確実に xaml ルートの中央に最も近い PreferredPlacement モードを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-245">It is encouraged to enable the IsLightDismissEnabled property and set the PreferredPlacement mode nearest to the center of the xaml root to ensure the best experience for users.</span></span>

<span data-ttu-id="8ff52-246">以前のバージョンの Windows では、このプロパティは無視され、教育のヒントは、xaml ルートの境界内で常に存在します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-246">On earlier versions of Windows, this property is ignored and the teaching tip always stays within the bounds of the xaml root.</span></span>

<span data-ttu-id="8ff52-247">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-247">XAML</span></span>
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    PreferredPlacement="BottomRight"
    PlacementMargin="-80,-50,0,0"
    ShouldConstrainToRootBounds="False">
</controls:TeachingTip>
```

![アプリの右下隅の外部で教育ヒントを使ってサンプル アプリです。](../images/teaching-tip-escape-xaml-root.png)

### <a name="canceling-and-deferring-close"></a><span data-ttu-id="8ff52-251">キャンセルして、閉じるを保留します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-251">Canceling and deferring close</span></span>

<span data-ttu-id="8ff52-252">Closing イベントは、キャンセルや教育ヒントの終了を遅延を使用できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-252">The Closing event can be used to cancel and/or defer the close of a teaching tip.</span></span> <span data-ttu-id="8ff52-253">教育のヒントを開いたまままたはアクションまたはカスタム アニメーションが開始する時間を許可するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-253">This can be used to keep the teaching tip open or allow time for an action or custom animation to occur.</span></span> <span data-ttu-id="8ff52-254">教育ヒントの終了が取り消されると、IsOpen が true に戻るには、ただし、そのまま残ります false、遅延中にします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-254">When the closing of a teaching tip is canceled, IsOpen will go back to true, however, it will stay false during the deferral.</span></span> <span data-ttu-id="8ff52-255">プログラムの終了を取り消すこともできます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-255">A programmatic close can also be canceled.</span></span> 

**<span data-ttu-id="8ff52-256">注:配置オプションは、完全に表示するヒントを教育許可しない場合、教育のヒントはせず、アクセス可能な閉じるボタンを表示するのではなく、強制的に終了するイベントのライフ サイクルを反復処理します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-256">Note: If no placement option would allow a teaching tip to fully show, teaching tip will iterate through its event lifecycle to force a close rather than display without an accessible close button.</span></span> <span data-ttu-id="8ff52-257">Closing イベントをキャンセルすると、アプリ教育ヒントがアクセス可能な閉じる ボタンを行わずに開く残ることがあります。</span><span class="sxs-lookup"><span data-stu-id="8ff52-257">If the app cancels the Closing event, the teaching tip may remain open without an accessible Close button.</span></span>**

<span data-ttu-id="8ff52-258">XAML</span><span class="sxs-lookup"><span data-stu-id="8ff52-258">XAML</span></span>
```XAML
<controls:TeachingTip x:Name="EnableNewSettingsTip"
    Title="New ways to protect your privacy!"
    Subtitle="Please close this tip and review our updated privacy policy and privacy settings."
    Closing="OnTipClosing">
</controls:TeachingTip>
```

<span data-ttu-id="8ff52-259">C#</span><span class="sxs-lookup"><span data-stu-id="8ff52-259">C#</span></span>
```C#
public void OnTipClosing(object sender, TeachingTipClosingEventArgs args)
{
    if (args.Reason == TeachingTipCloseReason.CloseButton)
    {
        using(args.GetDeferral())
        {
            bool success = await UpdateUserSettings(User thisUsersID);
            if(!success)
            {
                //We were not able to update the settings! Don't close the tip and display the reason why.
                args.Cancel = true;
                ShowLastErrorMessage();
            }
        }
    }
}
```

## <a name="remarks"></a><span data-ttu-id="8ff52-260">注釈</span><span class="sxs-lookup"><span data-stu-id="8ff52-260">Remarks</span></span>

### <a name="related-articles"></a><span data-ttu-id="8ff52-261">関連記事</span><span class="sxs-lookup"><span data-stu-id="8ff52-261">Related articles</span></span> 

* [<span data-ttu-id="8ff52-262">ダイアログとポップアップ</span><span class="sxs-lookup"><span data-stu-id="8ff52-262">Dialogs and flyouts</span></span>](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/dialogs-and-flyouts/index)

### <a name="recommendations"></a><span data-ttu-id="8ff52-263">推奨事項</span><span class="sxs-lookup"><span data-stu-id="8ff52-263">Recommendations</span></span>
* <span data-ttu-id="8ff52-264">ヒントは永続的であり、情報や、アプリケーションのエクスペリエンスに重要なオプションを含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="8ff52-264">Tips are impermanent and should not contain information or options that are critical to the experience of an application.</span></span> 
* <span data-ttu-id="8ff52-265">頻度が高すぎる教育ヒントが表示されないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="8ff52-265">Try to avoid showing teaching tips too often.</span></span> <span data-ttu-id="8ff52-266">教育のヒントが最も高い長いセッション全体、または複数のセッション間で交互にいるときに、個々 の注意を受け取る各します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-266">Teaching tips are most likely to each recieve individual attention when they are staggered throughout long sessions or across multiple sessions.</span></span>    
* <span data-ttu-id="8ff52-267">簡潔なヒントと、トピックをクリアしてください。</span><span class="sxs-lookup"><span data-stu-id="8ff52-267">Keep tips succinct and their topic clear.</span></span> <span data-ttu-id="8ff52-268">調査によると平均すると、ユーザー、3 ~ 5 の単語を読み取るし、のみのみチップと対話するかどうかを決定する前に 2 ~ 3 の単語を理解します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-268">Research shows users, on average, only read 3-5 words and only comprehend 2-3 words before deciding whether to interact with a tip.</span></span>
* <span data-ttu-id="8ff52-269">教育ヒントのゲームパッドのアクセシビリティは保証されません。</span><span class="sxs-lookup"><span data-stu-id="8ff52-269">Gamepad accessibility of a teaching tip is not guaranteed.</span></span> <span data-ttu-id="8ff52-270">Gamepad 入力を予測するアプリケーションを参照してください[ゲームパッドとリモート制御の相互作用]( https://docs.microsoft.com/en-us/windows/uwp/design/input/gamepad-and-remote-interactions#xy-focus-navigation-and-interaction)します。</span><span class="sxs-lookup"><span data-stu-id="8ff52-270">For applications that predict gamepad input, please see [gamepad and remote control interactions]( https://docs.microsoft.com/en-us/windows/uwp/design/input/gamepad-and-remote-interactions#xy-focus-navigation-and-interaction).</span></span> <span data-ttu-id="8ff52-271">アプリの UI のすべての可能な構成を使用して各教育ヒントのゲームパッド アクセシビリティをテストすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-271">It is encouraged to test gamepad accessibility of each teaching tip using all possible configurations of an app's UI.</span></span>
* <span data-ttu-id="8ff52-272">Xaml のルートをエスケープする教育チップを有効にするときに、IsLightDismissEnabled プロパティを有効にして、xaml のルートの中央に最も近い PreferredPlacement モードを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8ff52-272">When enabling a teaching tip to escape the xaml root, it is encouraged to also enable the IsLightDismissEnabled property and set the PreferredPlacement mode nearest to the center of the xaml root.</span></span> 

### <a name="reconfiguring-an-open-teaching-tip"></a><span data-ttu-id="8ff52-273">開いている教育ヒントの再構成</span><span class="sxs-lookup"><span data-stu-id="8ff52-273">Reconfiguring an open teaching tip</span></span>

<span data-ttu-id="8ff52-274">教育のヒントが開いており、すぐに反映中には、一部のコンテンツとプロパティを再構成できます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-274">Some content and properties can be reconfigured while the teaching tip is open and will take effect immediately.</span></span> <span data-ttu-id="8ff52-275">その他のコンテンツとプロパティ、光を無視し、明示的な閉じるアイコンのプロパティ、操作と閉じるボタン、および再構成の間などがすべて、教育スタイラスの先端をこれらのプロパティを有効にする変更を閉じてで必要があります。</span><span class="sxs-lookup"><span data-stu-id="8ff52-275">Other content and properties, such as the icon property, the Action and Close buttons, and reconfiguring between light-dismiss and explicit-dismiss will all require the teaching tip to be closed and reopened for changes to these properties to take affect.</span></span> <span data-ttu-id="8ff52-276">教育スタイラスの先端を削除する前に、閉じるボタンがあるからジョンソン動作を変更する手動の無視を光閉じます教育ヒントが開いている間に注意してください、光を閉じる動作が有効になっているし、ヒントは止まったまま画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="8ff52-276">Note that changing dismissal behavior from manual-dismiss to light-dismiss while a teaching tip is open will cause the teaching tip to have its Close button removed before the light-dismiss behavior is enabled and the tip can remain stuck on-screen.</span></span>
