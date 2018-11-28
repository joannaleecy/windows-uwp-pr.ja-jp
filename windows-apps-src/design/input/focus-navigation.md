---
title: キーボード、ゲームパッド、リモコン、アクセシビリティ ツールのフォーカス ナビゲーション
Description: ''
label: ''
template: detail.hbs
keywords: キーボード, ゲーム コントローラー, リモコン, ナビゲーション, 方向内部ナビゲーション, 方向領域, ナビゲーション方法, 入力, ユーザーの操作, アクセシビリティ, 操作性
ms.date: 03/02/2018
ms.topic: article
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4c76e62a4fcccec91fc6b3a083671ff68af2202e
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7849357"
---
# <a name="focus-navigation-for-keyboard-gamepad-remote-control-and-accessibility-tools"></a>キーボード、ゲームパッド、リモコン、アクセシビリティ ツールのフォーカス ナビゲーション

![キーボード、リモート、および方向パッド](images/dpad-remote/dpad-remote-keyboard.png)

フォーカス ナビゲーションを使用すると、キーボードを使い慣れているパワー ユーザーや障碍およびその他のアクセシビリティ要件を持っているユーザーは、総合的で一貫性のあるエクスペリエンスを UWP アプリやカスタム コントロールで利用できるようになります。また、テレビ画面と Xbox One の 10 フィート エクスペリエンスも利用することができます。

## <a name="overview"></a>概要

フォーカス ナビゲーションとは、キーボード、ゲームパッド、リモコンを使用して、ユーザーが UWP アプリケーションの UI 間を移動したり、これらの UI を操作したりできるようにする基本的なメカニズムです。

> [!NOTE] 
> 通常、入力デバイスは、ポインティング デバイス (タッチ、タッチパッド、ペン、マウスなど)、および非ポインティング デバイス (キーボード、ゲームパッド、リモコンなど) に分類されます。

このトピックでは、UWP アプリケーションを最適化し、非ポインティングの入力タイプを必要としているユーザー向けにカスタム操作エクスペリエンスを構築する方法について説明します。 

PC 上の UWP アプリのカスタム コントロールではキーボード入力に焦点を当てていますが、タッチ キーボードやスクリーン キーボード (OSK) などのソフトウェア キーボード、Windows ナレーターなどのアクセシビリティ ツールのサポート、および 10 フィート エクスペリエンスのサポートのために、適切に設計されたキーボード エクスペリエンスも重要となります。

ポインティング デバイスのために UWP アプリケーションでカスタム エクスペリエンスを構築する方法のガイダンスについては、「[ポインター入力の処理](handle-pointer-input.md)」をご覧ください。

キーボード用にアプリとエクスペリエンスを構築する方法の一般的な情報については、「[キーボード操作](keyboard-interactions.md)」をご覧ください。

## <a name="general-guidance"></a>一般的なガイドライン
フォーカス ナビゲーションをサポートする必要があるのは、ユーザーの操作を必要とする UI 要素のみです。操作を必要としない要素 (静的な画像など) では、キーボード フォーカスは必要ありません。 スクリーン リーダー、およびこれに類似したアクセシビリティ ツールでは、こうした静的な要素がフォーカス ナビゲーションの対象となっていない場合でも、これらの要素の読み上げが行われます。 

マウスやタッチなどのポインター デバイスによるナビゲーションとは異なり、フォーカス ナビゲーションは直線的であることを覚えておくことは大切です。 フォーカス ナビゲーションを実装するときは、ユーザーがアプリケーションを操作する方法や論理的なナビゲーションについて考慮してください。 ほとんどの場合、カスタム フォーカス ナビゲーションの動作は、ユーザーのカルチャで適切とされる読み取りパターンに従うようにすることをお勧めします。

フォーカス ナビゲーションでは、その他に次の点も考慮してください。
- コントロールが論理的にグループ化されているか。
- これらのコントロールのグループを重視する必要があるか。 
   - 重視する場合は、これらのグループにサブグループを含めるかどうか。
- レイアウトではカスタムの方向ナビゲーション (方向キー) とタブ オーダーが必要となるか。

[Engineering Software for Accessibility](https://www.microsoft.com/download/details.aspx?id=19262) eBook (アクセシビリティ ソフトウェアのエンジニアリングに関する eBook) の「*Designing the Logical Hierarchy*」(論理的な階層の設計) の章では、これらのことがわかりやすく説明されています。

## <a name="2d-directional-navigation-for-keyboard"></a>キーボードの 2D 方向ナビゲーション

コントロールやコントロール グループの 2D 内部ナビゲーション領域のことを、"方向領域" と呼びます。 フォーカがこのオブジェクトに移動すると、キーボードの方向キー (左、右、上、下) を使用して、方向領域内の子要素間を移動することができます。

![方向領域](images/keyboard/directional-area-small.png)

*コントロール グループの 2D 内部ナビゲーション領域 (方向領域)*

[XYFocusKeyboardNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_XYFocusKeyboardNavigation) プロパティ (設定できる値は [Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)、[Enabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)、[Disabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)) を使用して、キーボードの方向キーでの 2D 内部ナビゲーションを管理できます。

> [!NOTE]  
> タブ オーダーは、このプロパティの影響を受けません。 ナビゲーション エクスペリエンスがわかりにくくならないように、アプリケーションのタブ ナビゲーションの順序では、方向領域の子要素を明示的に*指定しない*ことをお勧めします。 要素のタブ移動動作について詳しくは、[UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) プロパティと [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティをご覧ください。  

### <a name="autohttpsdocsmicrosoftcomuwpapiwindowsuixamlinputxyfocuskeyboardnavigationmode-default-behavior"></a>[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode) (既定の動作)

Auto に設定すると、方向ナビゲーションの動作は要素の先祖 (継承階層) に基づいて決まります。 すべての先祖が既定のモードになっている場合 (**Auto** に設定されている場合)、キーボードを使用した方向ナビゲーションは*サポートされません*。

### [<a name="disabled"></a>Disabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)

**XYFocusKeyboardNavigation** を **Disabled** に設定すると、コントロールとその子要素への方向ナビゲーションがブロックされます。

![XYFocusKeyboardNavigation によって無効になった動作](images/keyboard/xyfocuskeyboardnav-disabled.gif)

*XYFocusKeyboardNavigation によって無効になった動作*

この例では、プライマリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerPrimary) で **XYFocusKeyboardNavigation** が **Enabled** に設定されています。 すべての子要素はこの設定を継承し、方向キーを使用して、これらの子要素への移動が可能になります。 ただし、B3 要素と B4 要素はセカンダリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerSecondary) 内にあり、その **XYFocusKeyboardNavigation** が **Disabled** に設定されています。この設定は、プライマリ コンテナーよりも優先され、セカンダリ コンテナー自体への方向キー ナビゲーションとその子要素間の方向キー ナビゲーションは無効になります。

```XAML
<Grid 
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" 
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="75"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
                Grid.Row="0" 
                FontWeight="ExtraBold" 
                HorizontalTextAlignment="Center"
                TextWrapping="Wrap" 
                Padding="10" />
    <StackPanel Name="ContainerPrimary" 
                XYFocusKeyboardNavigation="Enabled" 
                KeyDown="ContainerPrimary_KeyDown" 
                Orientation="Horizontal" 
                BorderBrush="Green" 
                BorderThickness="2" 
                Grid.Row="1" 
                Padding="10" 
                MaxWidth="200">
        <Button Name="B1" 
                Content="B1" 
                GettingFocus="Btn_GettingFocus" />
        <Button Name="B2" 
                Content="B2" 
                GettingFocus="Btn_GettingFocus" />
        <StackPanel Name="ContainerSecondary" 
                    XYFocusKeyboardNavigation="Disabled" 
                    Orientation="Horizontal" 
                    BorderBrush="Red" 
                    BorderThickness="2">
            <Button Name="B3" 
                    Content="B3" 
                    GettingFocus="Btn_GettingFocus" />
            <Button Name="B4" 
                    Content="B4" 
                    GettingFocus="Btn_GettingFocus" />
        </StackPanel>
    </StackPanel>
</Grid>
```

### [<a name="enabled"></a>Enabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocuskeyboardnavigationmode)

**XYFocusKeyboardNavigation** を **Enabled** に設定すると、コントロールとその [UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) 子オブジェクトそれぞれへの 2D 方向ナビゲーションがサポートされます。

設定すると、方向キーを使用したナビゲーションは、方向領域内の要素に限定されます。 タブ ナビゲーションは影響を受けません。これは、すべてのコントロールはタブ オーダー階層を使用してアクセス可能な状態になっているためです。

![XYFocusKeyboardNavigation によって有効になった動作](images/keyboard/xyfocuskeyboardnav-enabled.gif)

*XYFocusKeyboardNavigation によって有効になった動作*

この例では、プライマリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerPrimary) で **XYFocusKeyboardNavigation** が **Enabled** に設定されています。 すべての子要素はこの設定を継承し、方向キーを使用して、これらの子要素への移動が可能になります。 B3 要素と B4 要素はセカンダリの [StackPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.StackPanel) (ContainerSecondary) 内にあり、その **XYFocusKeyboardNavigation** は設定されていません。このため、プライマリ コンテナーの設定が継承されます。 B5 要素は宣言された方向領域内に存在せず、方向キー ナビゲーションをサポートしていませんが、標準的なタブ ナビゲーションの動作はサポートします。

```xaml
<Grid
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="100"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
               Grid.Row="0"
               FontWeight="ExtraBold"
               HorizontalTextAlignment="Center"
               TextWrapping="Wrap"
               Padding="10" />
    <StackPanel Grid.Row="1"
                Orientation="Horizontal"
                HorizontalAlignment="Center">
        <StackPanel Name="ContainerPrimary"
                    XYFocusKeyboardNavigation="Enabled"
                    KeyDown="ContainerPrimary_KeyDown"
                    Orientation="Horizontal"
                    BorderBrush="Green"
                    BorderThickness="2"
                    Padding="5" Margin="5">
            <Button Name="B1"
                    Content="B1"
                    GettingFocus="Btn_GettingFocus" Margin="5" />
            <Button Name="B2"
                    Content="B2"
                    GettingFocus="Btn_GettingFocus" />
            <StackPanel Name="ContainerSecondary"
                        Orientation="Horizontal"
                        BorderBrush="Red"
                        BorderThickness="2"
                        Margin="5">
                <Button Name="B3"
                        Content="B3"
                        GettingFocus="Btn_GettingFocus"
                        Margin="5" />
                <Button Name="B4"
                        Content="B4"
                        GettingFocus="Btn_GettingFocus"
                        Margin="5" />
            </StackPanel>
        </StackPanel>
        <Button Name="B5"
                Content="B5"
                GettingFocus="Btn_GettingFocus"
                Margin="5" />
    </StackPanel>
</Grid>
```

入れ子になった方向領域を複数レベル設定することができます。 すべての親要素の XYFocusKeyboardNavigation が Enabled に設定されている場合、内部ナビゲーション領域の境界は無視されます。

2D 方向ナビゲーションを明示的にサポートしていない要素に含まれる、2 つの入れ子になった方向領域の例を次に示します。 この場合、2 つの入れ子になった領域間の方向ナビゲーションはサポートされません。

![XYFocusKeyboardNavigation によって有効になり、入れ子になった動作](images/keyboard/xyfocuskeyboardnav-enabled-nested1.gif)

*XYFocusKeyboardNavigation によって有効になり、入れ子になった動作*

3 つの入れ子になった方向領域を使った、より複雑な例を次に示します。

-   B1 にフォーカスがある場合は、XYFocusKeyboardNavigation が Disabled に設定されている方向領域の境界が存在し、方向キーによって B2、B3、B4 には移動できないため、B5 にのみ移動できます (B5 から B1 への移動も同様)
-   B2 にフォーカスがある場合は、方向領域の境界によって B1、B4、B5 への方向キー ナビゲーションが禁止されているため、B3 にのみ移動できます (B3 から B2 への移動も同様)。
-   B4 にフォーカスがある場合は、コントロール間を移動するために Tab キーを使用する必要があります

![XYFocusKeyboardNavigation によって有効になり、複雑な入れ子になった動作](images/keyboard/xyfocuskeyboardnav-enabled-nested2.gif)

*XYFocusKeyboardNavigation によって有効になり、複雑な入れ子になった動作*

## <a name="tab-navigation"></a>タブ ナビゲーション

方向キーはコントロールやコントロール グループ内の 2D 方向ナビゲーションで使用できますが、Tab キーを使用すると、UWP アプリケーションのすべてのコントロール間を移動することができます。 

すべての対話型のコントロールは、既定で Tab キーによるナビゲーションをサポートしています ([IsEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_IsEnabled) プロパティと [IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) プロパティが **true**)。論理的なタブ オーダーは、アプリケーションのコントロール レイアウトからから派生します。 ただし、既定の順序は表示順序と対応するとは限りません。 実際の表示位置は親レイアウト コンテナーと特定のプロパティに依存し、それらを子要素で設定することでレイアウトに影響することがあります。

フォーカスがアプリケーション内をジャンプするようなカスタムのタブ オーダーは使用しないでください。 たとえば、フォーム内のコントロールの一覧には、上から下および左から右へと移動するタブ オーダーが必要です (ロケールによって異なります)。

このセクションでは、アプリに合わせてこのタブ オーダーを完全にカスタマイズする方法について説明します。

### <a name="set-the-tab-navigation-behavior"></a>タブ ナビゲーションの動作を設定する

[UIElement](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement) の [TabFocusNavigation](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.UIElement#Windows_UI_Xaml_UIElement_TabFocusNavigation) プロパティは、オブジェクト ツリー全体 (または方向領域) のタブ ナビゲーションの動作を指定します。

> [!NOTE]
> [ControlTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate) を使わないオブジェクトに対して [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) プロパティの代わりにこのプロパティを使用して、それらのオブジェクトの外観を定義します。

前のセクションで説明したように、ナビゲーション エクスペリエンスがわかりにくくならないように、アプリケーションのタブ ナビゲーションの順序では、方向領域の子要素を明示的に*指定しない*ことをお勧めします。 要素のタブ移動動作について詳しくは、[UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) プロパティと [TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティをご覧ください。   
> Windows 10 Creators Update (ビルド 10.0.15063) より前のバージョンでは、タブ設定は [ControlTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate) オブジェクトに制限されていました。 詳しくは、[Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) をご覧ください。

[TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) は、[KeyboardNavigationMode](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.keyboardnavigationmode) 型の値を保持します。設定できる値は次のとおりです (以下の例はカスタム コントロール グループではありません。また、方向キーでの内部ナビゲーションを必要としていません)。

- **Local** (既定)   
  タブ インデックスは、コンテナー内のローカル サブツリーで認識されます。 この例では、タブ オーダーは B1、B2、B3、B4、B5、B6、B7、B1 です。

   !["Local" タブ ナビゲーションの動作](images/keyboard/tabnav-local.gif)

   *"Local" タブ ナビゲーションの動作*

- **Once**  
  コンテナーとすべての子要素は、フォーカスを 1 回だけ受け取ります。 この例では、タブ オーダーは B1、B2、B7、B1 です (方向キーによる内部ナビゲーションも示されています)。

   !["Once" タブ ナビゲーションの動作](images/keyboard/tabnav-once.gif)

   *"Once" タブ ナビゲーションの動作*

- **Cycle**   
  フォーカスは循環して、コンテナー内のフォーカス可能な最初の要素に戻ります。 この例では、タブ オーダーは B1、B2、B3、B4、B5、B6、B2... です。

   !["Cycle" タブ ナビゲーションの動作](images/keyboard/tabnav-cycle.gif)

   *"Cycle" タブ ナビゲーションの動作*

上記の例で使用されるコードを次に示します (TabFocusNavigation ="Cycle")。

```XAML
<Grid 
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" 
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="300"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
               Grid.Row="0" 
               FontWeight="ExtraBold" 
               HorizontalTextAlignment="Center"
               TextWrapping="Wrap" 
               Padding="10" />
    <StackPanel Name="ContainerPrimary"
                KeyDown="Container_KeyDown" 
                Orientation="Horizontal" 
                HorizontalAlignment="Center"
                BorderBrush="Green" 
                BorderThickness="2" 
                Grid.Row="1" 
                Padding="10" 
                MaxWidth="200">
        <Button Name="B1" 
                Content="B1" 
                GettingFocus="Btn_GettingFocus" 
                Margin="5"/>
        <StackPanel Name="ContainerSecondary" 
                    KeyDown="Container_KeyDown"
                    XYFocusKeyboardNavigation="Enabled" 
                    TabFocusNavigation ="Cycle"
                    Orientation="Vertical" 
                    VerticalAlignment="Center"
                    BorderBrush="Red" 
                    BorderThickness="2"
                    Padding="5" Margin="5">
            <Button Name="B2" 
                    Content="B2" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B3" 
                    Content="B3" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B4" 
                    Content="B4" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B5" 
                    Content="B5" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
            <Button Name="B6" 
                    Content="B6" 
                    GettingFocus="Btn_GettingFocus" 
                    Margin="5"/>
        </StackPanel>
        <Button Name="B7" 
                Content="B7" 
                GettingFocus="Btn_GettingFocus" 
                Margin="5"/>
    </StackPanel>
</Grid>
```

### [<a name="tabindex"></a>TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex)

[TabIndex](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabIndex) を使用して、ユーザーが Tab キーを使用してコントロール間を移動するときに要素がフォーカスを受け取る順序を指定します。 小さい値のタブ インデックスを持つコントロールは、より大きい値のインデックスを持つコントロールより前にフォーカスを受け取ります。

コントロールに [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) が指定されていない場合、スコープに基づいて、ビジュアル ツリーにあるすべての対話型のコントロールで現在最大の値を持つインデックス (および優先順位が最も低いインデックス) よりも大きなインデックス値が割り当てられます。 

コントロールのすべての子要素がスコープと見なされます。また、こうしたスコープの要素のいずれか 1 つにさらに子要素がある場合、それらの子要素は別のスコープと見なされます。 スコープのビジュアル ツリーにある最初の要素を選ぶことにより、あいまいさが解決されます。 

タブ オーダーからコントロールを除外するには、[IsTabStop](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_IsTabStop) プロパティを **false** に設定します。

[TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティを設定することで、既定のタブ オーダーを上書きできます。

> [!NOTE] 
> [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) は、[UIElement.TabFocusNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.uielement#Windows_UI_Xaml_UIElement_TabFocusNavigation) および [Control.TabNavigation](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control#Windows_UI_Xaml_Controls_Control_TabNavigation) と同じように動作します。


フォーカス ナビゲーションが特定の要素の [TabIndex](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Control#Windows_UI_Xaml_Controls_Control_TabIndex) プロパティによってどのような影響を受けるかを次に示します。 

![TabIndex を使用した "Local" タブ ナビゲーションの動作](images/keyboard/tabnav-tabindex.gif)

*TabIndex を使用した "Local" タブ ナビゲーションの動作*

前の例では、次の 2 つのスコープがあります。 
- B1、方向領域 (B2 - B6)、B7
- 方向領域 (B2 - B6)

B3 (方向領域内) がフォーカスを取得すると、スコープが変更され、タブ ナビゲーションが方向領域に移動します。この方向領域では、後続のフォーカスについて最適な候補が指定されています。 この場合、B2 の後に B4、B5、B6 が続きます。 その後で、スコープがもう一度変更され、フォーカスが B1 に移動します。

この例のコードを次に示します。

```xaml
<Grid
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}"
    TabFocusNavigation="Cycle">
    <Grid.RowDefinitions>
        <RowDefinition Height="40"/>
        <RowDefinition Height="300"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <TextBlock Name="KeyPressed"
               Grid.Row="0"
               FontWeight="ExtraBold"
               HorizontalTextAlignment="Center"
               TextWrapping="Wrap"
               Padding="10" />
    <StackPanel Name="ContainerPrimary"
                KeyDown="Container_KeyDown"
                Orientation="Horizontal"
                HorizontalAlignment="Center"
                BorderBrush="Green"
                BorderThickness="2"
                Grid.Row="1"
                Padding="10"
                MaxWidth="200">
        <Button Name="B1"
                Content="B1"
                TabIndex="1"
                ToolTipService.ToolTip="TabIndex = 1"
                GettingFocus="Btn_GettingFocus"
                Margin="5"/>
        <StackPanel Name="ContainerSecondary"
                    KeyDown="Container_KeyDown"
                    TabFocusNavigation ="Local"
                    Orientation="Vertical"
                    VerticalAlignment="Center"
                    BorderBrush="Red"
                    BorderThickness="2"
                    Padding="5" Margin="5">
            <Button Name="B2"
                    Content="B2"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B3"
                    Content="B3"
                    TabIndex="3"
                    ToolTipService.ToolTip="TabIndex = 3"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B4"
                    Content="B4"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B5"
                    Content="B5"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
            <Button Name="B6"
                    Content="B6"
                    GettingFocus="Btn_GettingFocus"
                    Margin="5"/>
        </StackPanel>
        <Button Name="B7"
                Content="B7"
                TabIndex="2"
                ToolTipService.ToolTip="TabIndex = 2"
                GettingFocus="Btn_GettingFocus"
                Margin="5"/>
    </StackPanel>
</Grid>
```

## <a name="2d-directional-navigation-for-keyboard-gamepad-and-remote-control"></a>キーボード、ゲームパッド、リモコンの 2D 方向ナビゲーション

非ポインターの入力タイプ (キーボード、ゲームパッド、リモコン、および Windows ナレーターなどのアクセシビリティ ツール) では、UWP アプリケーションの UI 間を移動したり、これらの UI を操作したりするための、一般的で基本的なメカニズムを共有します。

このセクションでは、お勧めのナビゲーション方法をどのように指定するかについて説明します。また、フォーカス ベースである非ポインターの入力タイプすべてをサポートする一連のナビゲーション方法のプロパティを使用して、アプリケーション内でのフォーカス ナビゲーションを細かく調整する方法についても説明します。

Xbox/テレビ用にアプリとエクスペリエンスを構築する方法の一般的な情報については、「[キーボード操作](keyboard-interactions.md)」と「[Xbox およびテレビ向け設計](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction)」をご覧ください。

### <a name="navigation-strategies"></a>ナビゲーション方法

> ナビゲーション方法は、キーボード、ゲームパッド、リモコン、およびさまざまなアクセシビリティ ツールに適用できます。

次のナビゲーション方法のプロパティを使用すると、方向キーや方向パッド (D パッド) ボタン、または類似した押下操作に基づいて、どのコンピューターがフォーカスを受け取るかを制御することができます。 

-   XYFocusUpNavigationStrategy
-   XYFocusDownNavigationStrategy
-   XYFocusLeftNavigationStrategy
-   XYFocusRightNavigationStrategy

これらのプロパティに設定できる値は、[Auto](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy) (既定)、[NavigationDirectionDistance](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy)、[Projection](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy)、[RectilinearDistance ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.input.xyfocusnavigationstrategy) です。

**Auto** に設定された場合、要素の動作は要素の先祖に基づいて決まります。 すべての要素が **Auto** に設定されている場合、**Projection** が使用されます。

> [!NOTE]
> 前にフォーカスがあった要素やナビゲーション方向の軸までの近さなど、その他の要因により、結果が影響を受ける場合があります。

### <a name="projection"></a>Projection

Projection 方法を使うと、現在フォーカスがある要素の端をナビゲーションの方向に*投影*するときに接触した最初の要素にフォーカスが移動します。

この例では、各フォーカス ナビゲーションの方向は Projection に設定されます。 フォーカスが B3 をバイパスして、B1 から B4 にどのように移動するかについて注意してください。 こうした移動は、B3 が射影ゾーンにないことが原因です。 また、B1 から左に移動するときに、フォーカス候補がどうして識別されないのかについても注意してください。 これは、B1 に対する B2 の相対的な位置によって、B3 が候補から除外されるためです。 B3 が B2 と同じ行にあれば、B3 は左側へのナビゲーションに対して有効な候補となります。 B2 のナビゲーション方向の軸までの近さには遮るものがないため、B2 は有効な候補となります。

![Projection によるナビゲーション方法](images/keyboard/xyfocusnavigationstrategy-projection.gif)

*Projection によるナビゲーション方法*

### <a name="navigationdirectiondistance"></a>NavigationDirectionDistance

NavigationDirectionDistance 方法では、ナビゲーション方向の軸に最も近い要素にフォーカスが移動します。

ナビゲーション方向に対応する境界の四角形の端が*拡張*され、*投影*されて、ターゲットとなる候補が識別されます。 最初に接触した要素がターゲットとして識別されます。 複数の候補がある場合は、最も近い要素がターゲットとして識別されます。 さらに複数の候補がある場合には、最も上で最も左の要素が候補として識別されます。

![NavigationDirectionDistance によるナビゲーション方法](images/keyboard/xyfocusnavigationstrategy-navigationdirectiondistance.gif)

*NavigationDirectionDistance によるナビゲーション方法*

### <a name="rectilineardistance"></a>RectilinearDistance

RectilinearDistance 方法では、2D 直線距離に基づいて最も近い要素にフォーカスが移動します ([タクシー幾何学](https://en.wikipedia.org/wiki/Taxicab_geometry))。

潜在的な各候補までのプライマリ距離とセカンダリ距離を加算することによって、最適な候補が識別されます。 TIE では、要求された方向が上または下の場合は左方向の最初の要素が選択され、要求された方向が左または右の場合は上方向の最初の要素が選択されます。

![RectilinearDistance によるナビゲーション方法](images/keyboard/xyfocusnavigationstrategy-rectilineardistance.gif)

*RectilinearDistance によるナビゲーション方法*

この画像は、B1 にフォーカスがあり、要求された方向が下の場合に、B3 がどのようにして RectilinearDistance のフォーカス候補となるかを示しています。 これは、この例における次の計算に基づいています。
-   距離 (B1、B3、下) は 10 + 0 = 10
-   距離 (B1、B2、下) は 0 + 40 = 30
-   距離 (B1、D、下) は 30 + 0 = 30


## <a name="related-articles"></a>関連記事
- [プログラムによるフォーカス ナビゲーション](focus-navigation-programmatic.md)
- [キーボード操作](keyboard-interactions.md)
- [キーボードのアクセシビリティ](../accessibility/keyboard-accessibility.md) 



