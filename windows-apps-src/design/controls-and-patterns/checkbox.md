---
author: QuinnRadich
Description: Used to select or deselect action items. Can be used for a single list item or for multiple list items.
title: チェック ボックス
ms.assetid: 6231A806-287D-43EE-BD8D-39D2FF761914
label: Check boxes
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: a3e6180c23208f02c3f7fb2294eabe2ee080f504
ms.sourcegitcommit: 914b38559852aaefe7e9468f6f53a7465bf36e30
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3403218"
---
# <a name="check-boxes"></a><span data-ttu-id="7f4a0-103">チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="7f4a0-103">Check boxes</span></span>

 

<span data-ttu-id="7f4a0-104">チェック ボックスは、アクション項目の選択や選択解除を行うときに使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-104">A check box is used to select or deselect action items.</span></span> <span data-ttu-id="7f4a0-105">また、チェック ボックスはユーザーが選択する単一の項目や複数の項目の一覧に対して使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-105">It can be used for a single item or for a list of multiple items that a user can choose from.</span></span> <span data-ttu-id="7f4a0-106">コントロールには 3 つの選択状態 (選択されていない、選択されている、不確定) があります。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-106">The control has three selection states: unselected, selected, and indeterminate.</span></span> <span data-ttu-id="7f4a0-107">不確定状態は、選択されていない状態と選択されている状態の両方がサブ選択肢のコレクションに含まれている場合に使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-107">Use the indeterminate state when a collection of sub-choices have both unselected and selected states.</span></span>

> <span data-ttu-id="7f4a0-108">**重要な API**: [CheckBox クラス](https://msdn.microsoft.com/library/windows/apps/br209316)、[Checked イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx)、[IsChecked プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx)</span><span class="sxs-lookup"><span data-stu-id="7f4a0-108">**Important APIs**: [CheckBox class](https://msdn.microsoft.com/library/windows/apps/br209316), [Checked event](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx), [IsChecked property](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx)</span></span>

![チェック ボックスの状態の例](images/templates-checkbox-states-default.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="7f4a0-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="7f4a0-110">Is this the right control?</span></span>

<span data-ttu-id="7f4a0-111">**1 つのチェック ボックス**を使うのは、"このアカウントを記憶する" ログイン シナリオや、</span><span class="sxs-lookup"><span data-stu-id="7f4a0-111">Use a **single check box** for a binary yes/no choice, such as with a "Remember me?"</span></span> <span data-ttu-id="7f4a0-112">サービス契約の条項など、はい/いいえの二者択一の選択肢の場合です。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-112">login scenario or with a terms of service agreement.</span></span>

![個人的な選択のための 1 つのチェック ボックス](images/checkbox1.png)

<span data-ttu-id="7f4a0-114">二者択一の場合、**チェック ボックス**と[トグル スイッチ](toggles.md)との主な違いは、チェック ボックスが状態を管理し、トグル スイッチが動作を管理する点です。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-114">For a binary choice, the main difference between a **check box** and a [toggle switch](toggles.md) is that the check box is for status and the toggle switch is for action.</span></span> <span data-ttu-id="7f4a0-115">チェック ボックスによる操作はコミットを遅らせることができますが (たとえばフォームの送信の一部として)、トグル スイッチによる操作は直ちにコミットしなければなりません。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-115">You can delay committing a check box interaction (as part of a form submit, for example), while you should immediately commit a toggle switch interaction.</span></span> <span data-ttu-id="7f4a0-116">また、複数の選択ができるのは、チェック ボックスだけです。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-116">Also, only check boxes allow for multi-selection.</span></span>

<span data-ttu-id="7f4a0-117">**複数のチェック ボックス**を使うのは、複数選択シナリオの場合 (ユーザーが相互排他的でない選択肢のグループから 1 つ以上の項目を選ぶ場合) です。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-117">Use **multiple check boxes** for multi-select scenarios in which a user chooses one or more items from a group of choices that are not mutually exclusive.</span></span>

<span data-ttu-id="7f4a0-118">ユーザーがオプションの任意の組み合わせを選べる場合は、チェック ボックスのグループを作成します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-118">Create a group of check boxes when users can select any combination of options.</span></span>

![チェック ボックスでの複数のオプションの選択](images/checkbox2.png)

<span data-ttu-id="7f4a0-120">オプションをグループ化できる場合は、不確定状態のチェック ボックスを使ってグループ全体を表すことができます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-120">When options can be grouped, you can use an indeterminate check box to represent the whole group.</span></span> <span data-ttu-id="7f4a0-121">グループ内のすべてでなく一部のサブ項目をユーザーが選択する場合は、チェック ボックスの不確定の状態を使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-121">Use the check box's indeterminate state when a user selects some, but not all, sub-items in the group.</span></span>

![混在する選択を示すために使用されるチェック ボックス](images/checkbox3.png)

<span data-ttu-id="7f4a0-123">**チェック ボックス** コントロールと**ラジオ ボタン** コントロールの両方を使うと、ユーザーはオプションの一覧から選択できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-123">Both **check box** and **radio button** controls let the user select from a list of options.</span></span> <span data-ttu-id="7f4a0-124">チェック ボックスを使うと、ユーザーはオプションの組み合わせを選択できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-124">Check boxes let the user select a combination of options.</span></span> <span data-ttu-id="7f4a0-125">これに対し、ラジオ ボタンを使うと、ユーザーは相互排他的なオプションの中から 1 つのオプションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-125">In contrast, radio buttons let the user make a single choice from mutually exclusive options.</span></span> <span data-ttu-id="7f4a0-126">1 つ以上のオプションがあっても、選択できるのが 1 つだけの場合は、代わりにラジオ ボタンを使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-126">When there is more than one option but only one can be selected, use a radio button instead.</span></span>

## <a name="examples"></a><span data-ttu-id="7f4a0-127">例</span><span class="sxs-lookup"><span data-stu-id="7f4a0-127">Examples</span></span>

<table>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="7f4a0-128"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/CheckBox">アプリを開き、CheckBox の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-128">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/CheckBox">open the app and see the CheckBox in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="7f4a0-129">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="7f4a0-129">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="7f4a0-130">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="7f4a0-130">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="create-a-checkbox"></a><span data-ttu-id="7f4a0-131">チェック ボックスを作成する</span><span class="sxs-lookup"><span data-stu-id="7f4a0-131">Create a checkbox</span></span>

<span data-ttu-id="7f4a0-132">チェック ボックスにラベルを割り当てるには、[Content](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-132">To assign a label to the checkbox, set the [Content](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.contentcontrol.content.aspx) property.</span></span> <span data-ttu-id="7f4a0-133">ラベルはチェック ボックスの横に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-133">The label displays next to the checkbox.</span></span>

<span data-ttu-id="7f4a0-134">次の XAML は、フォームの送信前にサービス条件に同意するために使う単一のチェック ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-134">This XAML creates a single check box that is used to agree to terms of service before a form can be submitted.</span></span> 

```xaml
<CheckBox x:Name="termsOfServiceCheckBox" 
          Content="I agree to the terms of service."/>
```

<span data-ttu-id="7f4a0-135">同じチェック ボックスをコードで作成すると、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-135">Here's the same check box created in code.</span></span>

```csharp
CheckBox checkBox1 = new CheckBox();
checkBox1.Content = "I agree to the terms of service.";
```

### <a name="bind-to-ischecked"></a><span data-ttu-id="7f4a0-136">IsChecked にバインドする</span><span class="sxs-lookup"><span data-stu-id="7f4a0-136">Bind to IsChecked</span></span>

<span data-ttu-id="7f4a0-137">チェック ボックスがオンになっているかオフになっているかを判断するには、[IsChecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-137">Use the [IsChecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.ischecked.aspx) property to determine whether the check box is checked or cleared.</span></span> <span data-ttu-id="7f4a0-138">IsChecked プロパティの値を他のバイナリ値にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-138">You can bind the value of the IsChecked property to another binary value.</span></span> <span data-ttu-id="7f4a0-139">ただし、IsChecked は [null 許容](https://msdn.microsoft.com/library/windows/apps/b3h38hb0.aspx)のブール値であるため、値コンバーターを使ってブール値にバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-139">However, because IsChecked is a [nullable](https://msdn.microsoft.com/library/windows/apps/b3h38hb0.aspx) boolean value, you must use a value converter to bind it to a boolean value.</span></span>

<span data-ttu-id="7f4a0-140">次の例では、サービス条件に同意するためのチェック ボックスの **IsChecked** プロパティが送信ボタンの [IsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isenabled.aspx) プロパティにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-140">In this example, the **IsChecked** property of the check box to agree to terms of service is bound to the [IsEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isenabled.aspx) property of a Submit button.</span></span> <span data-ttu-id="7f4a0-141">送信ボタンは、サービス条件に同意した場合にのみ有効です。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-141">The Submit button is enabled only if the terms of service are agreed to.</span></span>

> <span data-ttu-id="7f4a0-142">注&nbsp;&nbsp;ここには関連するコードのみ掲載しています。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-142">Note&nbsp;&nbsp;We only show the relevant code here.</span></span> <span data-ttu-id="7f4a0-143">データ バインディングと値コンバーターについて詳しくは、「[データ バインディングの概要](../../data-binding/data-binding-quickstart.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-143">For more info about data binding and value converters, see [Data binding overview](../../data-binding/data-binding-quickstart.md).</span></span>

```xaml
...
<Page.Resources>
    <local:NullableBooleanToBooleanConverter x:Key="NullableBooleanToBooleanConverter"/>
</Page.Resources>

...

<StackPanel Grid.Column="2" Margin="40">
    <CheckBox x:Name="termsOfServiceCheckBox" Content="I agree to the terms of service."/>
    <Button Content="Submit" 
            IsEnabled="{x:Bind termsOfServiceCheckBox.IsChecked, 
                        Converter={StaticResource NullableBooleanToBooleanConverter}, Mode=OneWay}"/>
</StackPanel>
```

```csharp
public class NullableBooleanToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool?)
        {
            return (bool)value;
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is bool)
            return (bool)value;
        return false;
    }
}
```

### <a name="handle-click-and-checked-events"></a><span data-ttu-id="7f4a0-144">Click イベントと Checked イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="7f4a0-144">Handle Click and Checked events</span></span>

<span data-ttu-id="7f4a0-145">チェック ボックスの状態が変化したときにアクションを実行するには、[Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) イベント、または [Checked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx) イベントと [Unchecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.unchecked.aspx) イベントを処理できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-145">To perform an action when the check box state changes, you can handle either the [Click](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.buttonbase.click.aspx) event, or the [Checked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.checked.aspx) and [Unchecked](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.unchecked.aspx) events.</span></span> 

<span data-ttu-id="7f4a0-146">**Click** イベントはオンの状態が変化するたびに発生します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-146">The **Click** event occurs whenever the checked state changes.</span></span> <span data-ttu-id="7f4a0-147">Click イベントを処理する場合は、**IsChecked** プロパティを使ってチェック ボックスの状態を確認します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-147">If you handle the Click event, use the **IsChecked** property to determine the state of the check box.</span></span>

<span data-ttu-id="7f4a0-148">**Checked** イベントと **Unchecked** イベントは別々に発生します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-148">The **Checked** and **Unchecked** events occur independently.</span></span> <span data-ttu-id="7f4a0-149">これらのイベントを処理する場合は、チェック ボックスの状態の変化に応じて両方のイベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-149">If you handle these events, you should handle both of them to respond to state changes in the check box.</span></span>

<span data-ttu-id="7f4a0-150">次の例では、Click イベントの処理、および Checked イベントと Unchecked イベントの処理を示します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-150">In the following examples, we show handling the Click event, and the Checked and Unchecked events.</span></span>

<span data-ttu-id="7f4a0-151">同じイベント ハンドラーを複数のチェック ボックスで共有できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-151">Multiple checkboxes can share the same event handler.</span></span> <span data-ttu-id="7f4a0-152">この例では、ピザのトッピングを選ぶための 4 つのチェック ボックスを作成します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-152">This example creates four checkboxes for selecting pizza toppings.</span></span> <span data-ttu-id="7f4a0-153">4 つのチェック ボックスで同じ **Click** イベント ハンドラーを共有して、選んだトッピングの一覧を更新します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-153">The four checkboxes share the same **Click** event handler to update the list of selected toppings.</span></span>

```XAML
<StackPanel Margin="40">
    <TextBlock Text="Pizza Toppings"/>
    <CheckBox Content="Pepperoni" x:Name="pepperoniCheckbox"
              Click="toppingsCheckbox_Click"/>
    <CheckBox Content="Beef" x:Name="beefCheckbox" 
              Click="toppingsCheckbox_Click"/>
    <CheckBox Content="Mushrooms" x:Name="mushroomsCheckbox"
              Click="toppingsCheckbox_Click"/>
    <CheckBox Content="Onions" x:Name="onionsCheckbox"
              Click="toppingsCheckbox_Click"/>

    <!-- Display the selected toppings. -->
    <TextBlock Text="Toppings selected:"/>
    <TextBlock x:Name="toppingsList"/>
</StackPanel>
```

<span data-ttu-id="7f4a0-154">Click イベントのイベント ハンドラーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-154">Here's the event handler for the Click event.</span></span> <span data-ttu-id="7f4a0-155">チェック ボックスがクリックされるたびにチェック ボックスを調べ、どれがオンになっているかを確認し、選んだトッピングの一覧を更新します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-155">Every time a checkbox is clicked, it examines the checkboxes to see which ones are checked and update list of selected toppings.</span></span>

```csharp
private void toppingsCheckbox_Click(object sender, RoutedEventArgs e)
{
    string selectedToppingsText = string.Empty;
    CheckBox[] checkboxes = new CheckBox[] { pepperoniCheckbox, beefCheckbox,
                                             mushroomsCheckbox, onionsCheckbox };
    foreach (CheckBox c in checkboxes)
    {
        if (c.IsChecked == true)
        {
            if (selectedToppingsText.Length > 1)
            {
                selectedToppingsText += ", ";
            }
            selectedToppingsText += c.Content;
        }
    }
    toppingsList.Text = selectedToppingsText;
}
```

### <a name="use-the-indeterminate-state"></a><span data-ttu-id="7f4a0-156">不確定の状態を使用する</span><span class="sxs-lookup"><span data-stu-id="7f4a0-156">Use the indeterminate state</span></span>

<span data-ttu-id="7f4a0-157">CheckBox コントロールは [ToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.aspx) を継承します。また、このコントロールには 3 つの状態を指定できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-157">The CheckBox control inherits from [ToggleButton](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.aspx) and can have three states:</span></span> 

<span data-ttu-id="7f4a0-158">状態</span><span class="sxs-lookup"><span data-stu-id="7f4a0-158">State</span></span> | <span data-ttu-id="7f4a0-159">プロパティ</span><span class="sxs-lookup"><span data-stu-id="7f4a0-159">Property</span></span> | <span data-ttu-id="7f4a0-160">値</span><span class="sxs-lookup"><span data-stu-id="7f4a0-160">Value</span></span>
------|----------|------
<span data-ttu-id="7f4a0-161">オン</span><span class="sxs-lookup"><span data-stu-id="7f4a0-161">checked</span></span> | <span data-ttu-id="7f4a0-162">IsChecked</span><span class="sxs-lookup"><span data-stu-id="7f4a0-162">IsChecked</span></span> | **<span data-ttu-id="7f4a0-163">true</span><span class="sxs-lookup"><span data-stu-id="7f4a0-163">true</span></span>** 
<span data-ttu-id="7f4a0-164">オフ</span><span class="sxs-lookup"><span data-stu-id="7f4a0-164">unchecked</span></span> | <span data-ttu-id="7f4a0-165">IsChecked</span><span class="sxs-lookup"><span data-stu-id="7f4a0-165">IsChecked</span></span> | **<span data-ttu-id="7f4a0-166">false</span><span class="sxs-lookup"><span data-stu-id="7f4a0-166">false</span></span>** 
<span data-ttu-id="7f4a0-167">不確定</span><span class="sxs-lookup"><span data-stu-id="7f4a0-167">indeterminate</span></span> | <span data-ttu-id="7f4a0-168">IsChecked</span><span class="sxs-lookup"><span data-stu-id="7f4a0-168">IsChecked</span></span> | **<span data-ttu-id="7f4a0-169">null</span><span class="sxs-lookup"><span data-stu-id="7f4a0-169">null</span></span>** 

<span data-ttu-id="7f4a0-170">不確定の状態を報告するチェック ボックスの場合、[IsThreeState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.isthreestate.aspx) プロパティを **true** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-170">For the check box to report the indeterminate state, you must set the [IsThreeState](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.togglebutton.isthreestate.aspx) property to **true**.</span></span> 

<span data-ttu-id="7f4a0-171">オプションをグループ化できる場合は、不確定状態のチェック ボックスを使ってグループ全体を表すことができます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-171">When options can be grouped, you can use an indeterminate check box to represent the whole group.</span></span> <span data-ttu-id="7f4a0-172">グループ内のすべてでなく一部のサブ項目をユーザーが選択する場合は、チェック ボックスの不確定の状態を使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-172">Use the check box's indeterminate state when a user selects some, but not all, sub-items in the group.</span></span>

<span data-ttu-id="7f4a0-173">次の例では、[すべて選択] チェック ボックスの IsThreeState プロパティを **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-173">In the following example, the "Select all" checkbox has its IsThreeState property set to **true**.</span></span> <span data-ttu-id="7f4a0-174">[すべて選択] チェック ボックスは、すべての子要素がオンになっている場合はオンになり、すべての子要素がオフになっている場合はオフになり、それ以外の場合は不確定の状態になります。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-174">The "Select all" checkbox is checked if all child elements are checked, unchecked if all child elements are unchecked, and indeterminate otherwise.</span></span>

```xaml
<StackPanel>
    <CheckBox x:Name="OptionsAllCheckBox" Content="Select all" IsThreeState="True" 
              Checked="SelectAll_Checked" Unchecked="SelectAll_Unchecked" 
              Indeterminate="SelectAll_Indeterminate"/>
    <CheckBox x:Name="Option1CheckBox" Content="Option 1" Margin="24,0,0,0" 
              Checked="Option_Checked" Unchecked="Option_Unchecked" />
    <CheckBox x:Name="Option2CheckBox" Content="Option 2" Margin="24,0,0,0" 
              Checked="Option_Checked" Unchecked="Option_Unchecked" IsChecked="True"/>
    <CheckBox x:Name="Option3CheckBox" Content="Option 3" Margin="24,0,0,0"
              Checked="Option_Checked" Unchecked="Option_Unchecked" />
</StackPanel>
```

```csharp
private void Option_Checked(object sender, RoutedEventArgs e)
{
    SetCheckedState();
}

private void Option_Unchecked(object sender, RoutedEventArgs e)
{
    SetCheckedState();
}

private void SelectAll_Checked(object sender, RoutedEventArgs e)
{
    Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = true;
}

private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
{
    Option1CheckBox.IsChecked = Option2CheckBox.IsChecked = Option3CheckBox.IsChecked = false;
}

private void SelectAll_Indeterminate(object sender, RoutedEventArgs e)
{
    // If the SelectAll box is checked (all options are selected), 
    // clicking the box will change it to its indeterminate state.
    // Instead, we want to uncheck all the boxes,
    // so we do this programatically. The indeterminate state should
    // only be set programatically, not by the user.

    if (Option1CheckBox.IsChecked == true &&
        Option2CheckBox.IsChecked == true &&
        Option3CheckBox.IsChecked == true)
    {
        // This will cause SelectAll_Unchecked to be executed, so
        // we don't need to uncheck the other boxes here.
        OptionsAllCheckBox.IsChecked = false;
    }
}

private void SetCheckedState()
{
    // Controls are null the first time this is called, so we just 
    // need to perform a null check on any one of the controls.
    if (Option1CheckBox != null)
    {
        if (Option1CheckBox.IsChecked == true &&
            Option2CheckBox.IsChecked == true &&
            Option3CheckBox.IsChecked == true)
        {
            OptionsAllCheckBox.IsChecked = true;
        }
        else if (Option1CheckBox.IsChecked == false &&
            Option2CheckBox.IsChecked == false &&
            Option3CheckBox.IsChecked == false)
        {
            OptionsAllCheckBox.IsChecked = false;
        }
        else
        {
            // Set third state (indeterminate) by setting IsChecked to null.
            OptionsAllCheckBox.IsChecked = null;
        }
    }
}
```

## <a name="dos-and-donts"></a><span data-ttu-id="7f4a0-175">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="7f4a0-175">Do's and don'ts</span></span>

-   <span data-ttu-id="7f4a0-176">チェック ボックスの用途と現在の状態が明確であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-176">Verify that the purpose and current state of the check box is clear.</span></span>
-   <span data-ttu-id="7f4a0-177">チェック ボックスのテキスト コンテンツは 2 行以内にします。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-177">Limit check box text content to no more than two lines.</span></span>
-   <span data-ttu-id="7f4a0-178">チェック マークをオンにすると true、チェック マークをオフにすると false に設定されるようにチェック ボックスのラベルを記述します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-178">Word the checkbox label as a statement that the check mark makes true and the absence of a check mark makes false.</span></span>
-   <span data-ttu-id="7f4a0-179">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-179">Use the default font unless your brand guidelines tell you to use another.</span></span>
-   <span data-ttu-id="7f4a0-180">テキスト コンテンツが動的な場合、コントロールのサイズがどのように変わり、周囲の視覚効果にどのような影響が生じるかを検討してください。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-180">If the text content is dynamic, consider how the control will resize and what will happen to visuals around it.</span></span>
-   <span data-ttu-id="7f4a0-181">相互排他的な複数のオプションから選ぶ場合は、[オプション ボタン](radio-button.md) を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-181">If there are two or more mutually exclusive options from which to choose, consider using [radio buttons](radio-button.md).</span></span>
-   <span data-ttu-id="7f4a0-182">2 つのチェック ボックスのグループを並べて配置しないようにします。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-182">Don't put two check box groups next to each other.</span></span> <span data-ttu-id="7f4a0-183">グループを分けるには、グループ ラベルを使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-183">Use group labels to separate the groups.</span></span>
-   <span data-ttu-id="7f4a0-184">オン/オフの制御やコマンドの実行にはチェック ボックスを使わず、代わりにトグル スイッチを使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-184">Don't use a check box as an on/off control or to perform a command; instead, use a toggle switch.</span></span>
-   <span data-ttu-id="7f4a0-185">ダイアログ ボックスなどの他のコントロールを表示するためにチェック ボックスを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-185">Don't use a check box to display other controls, such as a dialog box.</span></span>
-   <span data-ttu-id="7f4a0-186">すべてではなく一部のサブ選択のためにオプションが設定されていることを示すには、不確定の状態を使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-186">Use the indeterminate state to indicate that an option is set for some, but not all, sub-choices.</span></span>
-   <span data-ttu-id="7f4a0-187">不確定の状態を使う場合は、下位のチェック ボックスを使って、どのオプションが選択され、どのオプションが選択されていないかがわかるようにします。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-187">When using indeterminate state, use subordinate check boxes to show which options are selected and which are not.</span></span> <span data-ttu-id="7f4a0-188">ユーザーにサブ選択肢がわかりやすいように UI を設計します。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-188">Design the UI so that the user can get see the sub-choices.</span></span>
-   <span data-ttu-id="7f4a0-189">不確定の状態を、第 3 の状態を示すために使わないでください。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-189">Don't use the indeterminate state to represent a third state.</span></span> <span data-ttu-id="7f4a0-190">不確定の状態は、すべてではなく一部のサブ選択のためにオプションが設定されていることを示すために使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-190">The indeterminate state is used to indicate that an option is set for some, but not all, sub-choices.</span></span> <span data-ttu-id="7f4a0-191">そのため、ユーザーが不確定の状態を直接設定できないようにします。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-191">So, don't allow users to set an indeterminate state directly.</span></span> <span data-ttu-id="7f4a0-192">良くない例を示すために、次のチェック ボックスでは不確定の状態を使って "中辛" を示しています。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-192">For an example of what not to do, this check box uses the indeterminate state to indicate medium spiciness:</span></span>

    ![不確定状態のチェック ボックス](images/checkbox4_spicy.png)

    <span data-ttu-id="7f4a0-194">このような場合は、[Not spicy]、[Spicy]、[Extra spicy] という 3 つのオプションがあるラジオ ボタン グループを使います。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-194">Instead, use a radio button group that has three options: Not spicy, Spicy, and Extra spicy.</span></span>

    ![[Not spicy]、[Spicy]、[Extra spicy] という 3 つのオプションがあるラジオ ボタン グループ](images/spicyoptions.png)

## <a name="get-the-sample-code"></a><span data-ttu-id="7f4a0-196">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="7f4a0-196">Get the sample code</span></span>

- <span data-ttu-id="7f4a0-197">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="7f4a0-197">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="7f4a0-198">関連記事</span><span class="sxs-lookup"><span data-stu-id="7f4a0-198">Related articles</span></span>

- [<span data-ttu-id="7f4a0-199">CheckBox クラス</span><span class="sxs-lookup"><span data-stu-id="7f4a0-199">CheckBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209316) 
- [<span data-ttu-id="7f4a0-200">ラジオ ボタン</span><span class="sxs-lookup"><span data-stu-id="7f4a0-200">Radio buttons</span></span>](radio-button.md)
- [<span data-ttu-id="7f4a0-201">トグル スイッチ</span><span class="sxs-lookup"><span data-stu-id="7f4a0-201">Toggle switch</span></span>](toggles.md)
