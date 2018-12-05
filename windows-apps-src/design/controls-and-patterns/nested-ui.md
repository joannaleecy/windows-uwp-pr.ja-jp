---
Description: Use nested UI to enable multiple actions on a list item
title: リスト項目の入れ子になった UI
label: Nested UI in list items
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 60a29717-56f2-4388-a9ff-0098e34d5896
pm-contact: chigy
design-contact: kimsea
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 8edb38b8ae91d836e283a8eb37830850bf504db4
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8736162"
---
# <a name="nested-ui-in-list-items"></a>リスト項目の入れ子になった UI

 

入れ子になった UI は、コンテナー内部に囲まれた、操作できる入れ子になったコントロールを公開するユーザー インターフェイス (UI) です。個別のフォーカスを取得することも可能です。

入れ子になった UI を使用することで、重要な操作をスムーズに行うことができるようになる追加のオプションをユーザーに提供できます。 ただし、公開する操作の数が増えるにつれて、UI は複雑になります。 この UI パターンの使用を決めた場合は十分に注意することが必要です。 この記事では、特定の UI に最適な一連の操作の判断に役立つガイドラインを提供します。

> **重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)

この記事では、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) 項目および [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) 項目の入れ子になった UI の作成について説明します。 このセクションでは、入れ子になった UI の他の例については取り上げませんが、これらの概念は他でも利用できます。 始める前に、UI における ListView コントロールまたは GridView コントロールの使用について、一般的なガイダンスを理解している必要があります。この一般的なガイダンスについては、「[リスト](lists.md)」と「[リスト ビューとグリッド ビュー](listview-and-gridview.md)」の記事をご覧ください。

この記事で使用する用語、*リスト*、*リスト項目*、*入れ子になった UI* は次のように定義します。
- *リスト*は、リスト ビューまたはグリッド ビューに含まれた項目のコレクションを表します。
- *リスト項目*は、ユーザーが操作を実行できるリスト上の個別の項目を表します。
- *入れ子になった UI* は、リスト項目自体に対する操作とは別にユーザーが操作できるリスト項目内の UI 要素を表します。

![入れ子になった UI 部](images/nested-ui-example-1.png)

> 注&nbsp;&nbsp; ListView と GridView はどちらも [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx) クラスから派生しているため機能は同じですが、データの表示方法が異なります。 この記事では、リストについての説明は ListView コントロールにも GridView コントロールにも適用されます。

## <a name="primary-and-secondary-actions"></a>プライマリ操作とセカンダリ操作

リストを使って UI を作成する場合、それらのリスト項目でユーザーがどのような操作を行う可能性があるかを考える必要があります。  

- ユーザーが項目をクリックして操作を実行できるかどうか。
    - 通常、リスト項目をクリックすると操作が開始されますが、そうである必要はありません。
- ユーザーが 2 つ以上の操作を実行する可能性があるかどうか。
    - たとえば、リストのメールをタップすることでメールが開きます。 ただし、メールを削除するなど、メールを開かずに、ユーザーがまず行うことを望む他の操作が存在する場合があります。 こうした操作をリストから直接実行できればユーザーにとってメリットになります。
- 操作をどのようにユーザーに公開するか。
    - 入力の種類をすべて検討します。 入れ子になった UI の形式によっては、1 つの入力方法が適切に機能しても、他の方法では動作しない場合があります。  

*プライマリ操作*は、ユーザーがリスト項目を押したときに発生することが予期される操作です。

*セカンダリ操作*は、一般的に、リスト項目と関連付けられたアクセラレータです。 これらのアクセラレータは、リスト管理を対象にしたものものあれば、リスト項目に関する操作用のものである場合もあります。

## <a name="options-for-secondary-actions"></a>セカンダリ操作のオプション

リスト UI を作成する場合にまず必要なことは、UWP でサポートされるすべての入力方法が考慮されていることを確認することです。 さまざまな種類の入力について詳しくは、「[操作の基本情報](../input/index.md)」をご覧ください。

UWP でサポートされているすべての入力にアプリが対応していることを確認したら、メイン リストのアクセラレータとして公開するほどに、アプリのセカンダリ操作が重要であるかどうかを判断する必要があります。 公開する操作が増えるほど、UI が複雑になることに注意してください。 セカンダリ操作をメイン リスト UI に公開する必要性は本当にあるのでしょうか。ないとしたら、どこか他の場所に配置できるでしょうか。

どのような入力からでも常時その操作にアクセスできる必要がある場合は、追加の操作をメイン リスト UI に公開することを検討してみましょう。

セカンダリ操作をメイン リスト UI に配置することが必要ないと判断しても、他のさまざまな方法でその操作ユーザーに公開できます。 セカンダリ操作の公開場所として検討できるオプションには次のようなものがあります。

### <a name="put-secondary-actions-on-the-detail-page"></a>詳細ページにセカンダリ操作を配置

セカンダリ操作を、リスト項目が押されたときの移動先のページに配置します。 マスター/詳細パターンを使用しているなら、多くの場合、詳細ページはセカンダリ操作を配置する適切な場所になります。

詳しくは、「[マスター/詳細パターン](master-details.md)」をご覧ください。

### <a name="put-secondary-actions-in-a-context-menu"></a>コンテキスト メニューにセカンダリ操作を配置

セカンダリ操作を、ユーザーが右クリックまたは長押しすることでアクセスできるコンテキスト メニューに配置します。 この方法には、詳細ページを読み込むことなく、メールの削除などの操作をユーザーが実行できるメリットがあります。 このオプションは詳細ページで利用可能にすることもお勧めします。コンテキスト メニューはプライマリ UI ではなくアクセラレータとして使用することが意図されているためです。

ゲームパッドやリモコンから入力された場合のセカンダリ操作を公開するには、コンテキスト メニューを使用することをお勧めします。

詳しくは、「[コンテキスト メニューとポップアップ](menus.md)」をご覧ください。

### <a name="put-secondary-actions-in-hover-ui-to-optimize-for-pointer-input"></a>ポインター入力に最適化するためにセカンダリ操作をホバー UI に配置

マウスやペンなど、ポインター入力でアプリが使用される頻度が高くなることを見込んでおり、このような入力に対してのみセカンダリ操作をすぐに利用できるようにする必要がある場合、セカンダリ操作をホバー時に限定して表示できます。 このアクセラレータが表示されるのは、ポインター入力が使用されている場合に限られるため、他の入力の種類をサポートするには他のオプションも使用してください。

![ホバー時に表示される入れ子になった UI](images/nested-ui-hover.png)


詳しくは、「[マウス操作](../input/mouse-interactions.md)」をご覧ください。

## <a name="ui-placement-for-primary-and-secondary-actions"></a>プライマリ操作とセカンダリ操作の UI の配置

セカンダリ操作をメイン リスト UI に公開することを決めた場合は、以下のガイドラインに従うことをお勧めします。

プライマリ操作とセカンダリ操作を使用してリスト項目を作成する場合は、プライマリ操作を左側に配置し、セカンダリ操作を右側に配置します。 左から右に向けて読む文化では、ユーザーはリスト項目の左側にある操作をプライマリ操作と結び付けて考えます。

この例では、項目が水平方向に向かって表示される (高さよりも幅の方が広い) リスト UI について説明しています。 ただし、リスト項目が正方形に近かったり、縦長だったりする場合もあることでしょう。 通常、これらの項目はグリッドで使用されます。 このような項目では、リストが垂直方向にスクロールしない場合、セカンダリ操作をリスト項目の右側ではなく一番下に配置します。

## <a name="consider-all-inputs"></a>すべての入力を検討

入れ子になった UI を使用することに決めたら、すべての入力の種類を使ってユーザー エクスペリエンスを評価します。 前述のように、入れ子になった UI は、一部の種類の入力では適切に動作します。 ただし、他の入力方法でも常に適切に動作するとは限りません。 特に、キーボード、コントローラー、およびリモート入力では、入れ子になった UI 要素にアクセスすることが難くなる可能性があります。 UWP がすべての入力の種類で機能するように、後述のガイダンスに従ってください。

## <a name="nested-ui-handling"></a>入れ子になった UI の処理

リスト項目内に 2 つ以上の操作がある場合は、このガイダンスに従って、キーボード、ゲームパッド、リモコンなど、非ポインター入力による移動を処理することを勧めします。

### <a name="nested-ui-where-list-items-perform-an-action"></a>リスト項目で操作が実行される入れ子になった UI

入れ子になった要素を含むリスト UI で、呼び出し処理、選択 (単一または複数) 処理、ドラッグ アンド ドロップ処理などの操作をサポートしている場合は、次の方向キーによる手法を使って、入れ子になった UI 要素を移動することがお勧めです。

![入れ子になった UI 部](images/nested-ui-navigation.png)

**ゲームパッド**

ゲームパッドで入力された場合、次のユーザー エクスペリエンスを提供します。

- **A** では、右方向キーでフォーカスを **B** に設定します。
- **B** では、右方向キーでフォーカスを **C** に設定します。
- **C** では、右方向キーでは移動できなくするか、フォーカス可能な UI 要素がリストの右側にある場合は、そこにフォーカスを設定します。
- **C** では、左方向キーでフォーカスを **B** に設定します。
- **B** では、左方向キーでフォーカスを **A** に設定します。
- **A** では、左方向キーでは移動できなくするか、フォーカス可能な UI 要素がリストの右側にある場合は、そこにフォーカスを設定します。
- **A**、**B**、または **C** では、下方向キーでフォーカスを **D** に設定します。
- リスト項目の左側の UI 要素では、右方向キーでフォーカスを **A** に設定します。
- リスト項目の右側の UI 要素では、左方向キーでフォーカスを **A** に設定します。

**キーボード**

キーボードで入力された場合、ユーザー エクスペリエンスは次のようにします。

- **A** では、Tab キーでフォーカスを **B** に設定します。
- **B** では、Tab キーでフォーカスを **C** に設定します。
- **C** では、Tab キーで、タブ オーダーで次のフォーカス可能な UI 要素にフォーカスを設定します。
- **C** では、Shift + Tab キーでフォーカスを **B** に設定します。
- **B** では、Shift + Tab キーまたは左方向キーでフォーカスを **A** に設定します。
- **A** では、Shift + Tab キーで、逆方向のタブ オーダーで次のフォーカス可能な UI 要素にフォーカスを設定します。
- **A**、**B**、または **C** では、下方向キーでフォーカスを **D** に設定します。
- リスト項目の左側の UI 要素では、Tab キーでフォーカスを **A** に設定します。
- リスト項目の右側の UI 要素では、Shift + Tab キーでフォーカスを **C** に設定します

この UI を実現するには、リストで [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) を **true** に設定します。 [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) は、任意の値を使うことができます。

これを実装するコードについては、この記事の「[例](#example)」セクションをご覧ください。

### <a name="nested-ui-where-list-items-do-not-perform-an-action"></a>リスト項目で操作が実行されない入れ子になった UI

リスト ビューによって仮想化と最適化されたスクロール動作が提供されることからリスト ビューを使用する場合があります。ただし、このとき操作が関連付けられているリスト項目はありません。 これらの UI では通常、要素をグループ化して要素をまとめてスクロールできるようにするためだけに、リスト項目を使用します。

この種類の UI は、前述の例よりもずっと複雑になる傾向があり、ユーザーが操作可能な入れ子になった要素が多数含まれます。

![入れ子になった UI 部](images/nested-ui-grouping.png)


この UI を実現するには、リストのプロパティを次のように設定します。
- [SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) を **None** に設定します。
- [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) を **false** に設定します。
- [IsFocusEngagementEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isfocusengagementenabled.aspx) を **true** に設定します。

```xaml
<ListView SelectionMode="None" IsItemClickEnabled="False" >
    <ListView.ItemContainerStyle>
         <Style TargetType="ListViewItem">
             <Setter Property="IsFocusEngagementEnabled" Value="True"/>
         </Style>
    </ListView.ItemContainerStyle>
</ListView>
```

リスト項目で操作が実行されない場合は、次のガイダンスに従ってゲームパッドまたはキーボードによる移動を処理することをお勧めします。

**ゲームパッド**

ゲームパッドで入力された場合、次のユーザー エクスペリエンスを提供します。

- リスト項目では、下方向キーでフォーカスを次のリスト項目に設定します。
- リスト項目では、左または右方向キーでは移動できなくするか、フォーカス可能な UI 要素がリストの右側にある場合は、そこにフォーカスを設定します。
- リスト項目では、A ボタンで、上/左下/右の優先順位で、入れ子になった UI にフォーカスを設定します。
- 入れ子になた UI 内部では、XY フォーカス ナビゲーション モデルに従います。  ユーザーが B ボタンを押すまで、フォーカスが移動できる対象を現在のリスト項目内にある入れ子になった UI に限定します。B ボタンを押したら、リスト項目にフォーカスを戻します。

**キーボード**

キーボードで入力された場合、ユーザー エクスペリエンスは次のようにします。

- リスト項目では、下方向キーでフォーカスを次のリスト項目に設定します。
- リスト項目では、左方向キーまたは右方向キーを押しても移動しません。
- リスト項目では、TAB キーを押すと、入れ子になった UI 項目の次のタブ ストップにフォーカスを設定します。
- いずれかの入れ子になった UI 項目では、TAB キーを押すと、タブ オーダーで、入れ子になった UI 項目を移動します。  すべての入れ子になった UI 項目を移動したら、タブ オーダーで ListView 後の次のコントロールにフォーカスを設定します。
- Shift + Tab キーを押すと、Tab キーの動作と逆方向に動作します。

## <a name="example"></a>例

この例は、[リスト項目で操作を実行する入れ子になった UI](#nested-ui-where-list-items-perform-an-action) を実装する方法を示します。

```xaml
<ListView SelectionMode="None" IsItemClickEnabled="True"
          ChoosingItemContainer="listview1_ChoosingItemContainer"/>
```

```csharp
private void OnListViewItemKeyDown(object sender, KeyRoutedEventArgs e)
{
    // Code to handle going in/out of nested UI with gamepad and remote only.
    if (e.Handled == true)
    {
        return;
    }

    var focusedElementAsListViewItem = FocusManager.GetFocusedElement() as ListViewItem;
    if (focusedElementAsListViewItem != null)
    {
        // Focus is on the ListViewItem.
        // Go in with Right arrow.
        Control candidate = null;

        switch (e.OriginalKey)
        {
            case Windows.System.VirtualKey.GamepadDPadRight:
            case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                var rawPixelsPerViewPixel = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
                GeneralTransform generalTransform = focusedElementAsListViewItem.TransformToVisual(null);
                Point startPoint = generalTransform.TransformPoint(new Point(0, 0));
                Rect hintRect = new Rect(startPoint.X * rawPixelsPerViewPixel, startPoint.Y * rawPixelsPerViewPixel, 1, focusedElementAsListViewItem.ActualHeight * rawPixelsPerViewPixel);
                candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Right, hintRect) as Control;
                break;
        }

        if (candidate != null)
        {
            candidate.Focus(FocusState.Keyboard);
            e.Handled = true;
        }
    }
    else
    {
        // Focus is inside the ListViewItem.
        FocusNavigationDirection direction = FocusNavigationDirection.None;
        switch (e.OriginalKey)
        {
            case Windows.System.VirtualKey.GamepadDPadUp:
            case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                direction = FocusNavigationDirection.Up;
                break;
            case Windows.System.VirtualKey.GamepadDPadDown:
            case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                direction = FocusNavigationDirection.Down;
                break;
            case Windows.System.VirtualKey.GamepadDPadLeft:
            case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                direction = FocusNavigationDirection.Left;
                break;
            case Windows.System.VirtualKey.GamepadDPadRight:
            case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                direction = FocusNavigationDirection.Right;
                break;
            default:
                break;
        }

        if (direction != FocusNavigationDirection.None)
        {
            Control candidate = FocusManager.FindNextFocusableElement(direction) as Control;
            if (candidate != null)
            {
                ListViewItem listViewItem = sender as ListViewItem;

                // If the next focusable candidate to the left is outside of ListViewItem,
                // put the focus on ListViewItem.
                if (direction == FocusNavigationDirection.Left &&
                    !listViewItem.IsAncestorOf(candidate))
                {
                    listViewItem.Focus(FocusState.Keyboard);
                }
                else
                {
                    candidate.Focus(FocusState.Keyboard);
                }
            }

            e.Handled = true;
        }
    }
}

private void listview1_ChoosingItemContainer(ListViewBase sender, ChoosingItemContainerEventArgs args)
{
    if (args.ItemContainer == null)
    {
        args.ItemContainer = new ListViewItem();
        args.ItemContainer.KeyDown += OnListViewItemKeyDown;
    }
}
```

```csharp
// DependencyObjectExtensions.cs definition.
public static class DependencyObjectExtensions
{
    public static bool IsAncestorOf(this DependencyObject parent, DependencyObject child)
    {
        DependencyObject current = child;
        bool isAncestor = false;

        while (current != null && !isAncestor)
        {
            if (current == parent)
            {
                isAncestor = true;
            }

            current = VisualTreeHelper.GetParent(current);
        }

        return isAncestor;
    }
}
```
