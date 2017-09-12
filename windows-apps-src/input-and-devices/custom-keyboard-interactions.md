---
author: Karl-Bridge-Microsoft
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.openlocfilehash: 010663320b4011d853c53bc4121f86a14bfbfe0c
ms.sourcegitcommit: a2908889b3566882c7494dc81fa9ece7d1d19580
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/31/2017
---
# <a name="custom-keyboard-interactions"></a>カスタムのキーボード操作

キーボードを使い慣れているパワー ユーザーと、障碍やその他のアクセシビリティ要件を持っているユーザーの両方に対して、総合的で一貫性のあるキーボード エクスペリエンスを UWP アプリやカスタム コントロールで提供する方法を示します。

このトピックでは、PC 上の UWP アプリのカスタム コントロールによってキーボード入力をサポートすることに主な焦点を当てます。 ただし、適切に設計されたキーボード エクスペリエンスは、ナレーターなどのアクセシビリティ ツールをサポートしたり、タッチ キーボードやスクリーン キーボード (OSK) などのソフトウェア キーボードを使ったりするために重要です。

## <a name="providing-2d-directional-inner-navigation-a-namexyfocuskeyboardnavigation"></a>2D 方向内部ナビゲーションを提供する <a name="xyfocuskeyboardnavigation">

キーボード (方向キー)、Xbox ゲームパッド (方向パッドと左スティック ボタン)、Xbox リモコン (方向パッド) によって、カスタム コントロールおよびコントロール グループの 2D 方向内部ナビゲーションをサポートするには、**XYFocusKeyboardNavigation** プロパティを使います。

**注** コントロールまたはコントロール グループの内部ナビゲーション領域のことを*方向領域*と呼びます。

**XYFocusKeyboardNavigation** には、**XYFocusKeyboardNavigationMode** 型の値があります。指定可能な値は、**Auto** (既定)、**Enabled**、**Disabled** です。

このプロパティは、タブ ナビゲーションに影響を与えず、コントロールまたはコントロール グループ内の子要素の内部ナビゲーションにのみ影響を与えます。 方向領域の子要素は、タブ ナビゲーションに含めないでください。

### <a name="default-behavior"></a>既定の動作

方向ナビゲーションの動作は、要素の先祖、つまり継承階層に基づいて決まります。 すべての先祖が既定のモードの場合、つまり **Auto** に設定されている場合、キーボードでは方向ナビゲーションの動作がサポートされません (ゲームパッドとリモコンでは、明示的に **Disabled** に設定されていない限り常に方向ナビゲーションがサポートされます)。

### <a name="custom-behavior"></a>カスタム動作

このプロパティを設定 **Enabled** に設定すると、コントロール内のあらゆる UIElement で 2D 内部ナビゲーションがコントロールによりサポートされます (キーボードの方向キーを使用)。

キーボードの方向キーを使うと、方向領域内にナビゲーションが制限されます (Tab キーを押すと、方向領域の外側のフォーカス可能な次の要素にフォーカスが設定されます)。

**注** これは、ゲームパッドやリモコンの使用時には当てはまりません。この場合、フォーカス可能な次のコントロールまで、方向領域の外側でナビゲーションが続行されます。

このプロパティは、方向キーを使った内部ナビゲーションにのみ影響を与え、Tab キー ナビゲーションには影響を与えません。 すべてのコントロールでは、予想されるタブ オーダー階層が維持されます。

次の図は、方向領域内に含まれる 3 つのボタン (A、B、C) と、方向領域の外側にある 4 つ目のボタン (D) を示しています。

![方向領域](images/keyboard/directional-area.png)

*キーボードの方向キーは、ボタン A-B-C 間でフォーカスを移動できますが、D には移動できません。*

次のコード例は、**XYFocusKeyboardNavigation** が有効なときにナビゲーションが受ける影響を示しています。 前の画像で考えると、A が初期フォーカスを持っていて、Tab キーによりすべてのコントロールが順番に切り替わりますが (A -&gt; B -&gt; C -&gt; D、の後 A に戻る)、方向キーは方向領域に制限されます。

```XAML
<StackPanel Orientation="Horizontal">
      <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
            <Button Content="A" />
            <Button Content="B" />
            <Button Content="C" />
      </StackPanel>
      <Button Content="D" />
</StackPanel>
```

#### <a name="override-directional-navigation"></a>方向ナビゲーションを上書きする

既定のナビゲーション動作を上書きするには、XYFocusRight/XYFocusLeft/XYFocusTop/XYFocusDown プロパティを使います。

以下に、方向領域内に含まれている 3 つのボタン (A、B、C) と方向領域の外側にある 4 つ目のボタン (D) を示す、前の例と同じ図を示します。

![方向領域](images/keyboard/directional-area.png)

*キーボードの方向キーは、A-B-C ボタンの間でフォーカスを移動し、D に出ていくことができる*

このコード例は、方向領域の外側にあるコントロールに移動できるようにすることで、右方向キーの既定のナビゲーション動作を上書きする方法を示しています。 左方向キーを使って方向領域に再度入ることはできない点に注意してください。

```XAML
<StackPanel Orientation="Horizontal">
      <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
            <Button Content="A" />
            <Button Content="B" />
            <Button Content="C" XYFocusRight="{x:Bind ButtonD}" />
      </StackPanel>
      <Button Content="D" x:Name="ButtonD"/>
</StackPanel>
```

詳しくは、このトピックの方向の「[XYFocus ナビゲーション方法](#set-the-tab-navigation-behavior)」をご覧ください。

#### <a name="restrict-navigation-with-disabled"></a>Disabled によってナビゲーションを制限する

方向キー ナビゲーションを方向領域内に制限するには、**XYFocusKeyboardNavigation** を **Disabled** に設定します。

**注** このプロパティを設定しても、コントロールへのキーボード ナビゲーション自体には影響を与えず、コントロールの子要素だけに影響を与えます。

次のコード例では、親 StackPanel の **XYFocusKeyboardNavigation** が **Enabled** に設定され、子要素 C の **XYFocusKeyboardNavigation** が **Disabled** に設定されています。 C の子要素でのみ方向キー ナビゲーションが無効になっています。

```XAML
<StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
        <Button Content="A" />
        <Button Content="B" />
        <Button Content="C" XYFocusKeyboardNavigation="Disabled" >
            ...
        </Button>
</StackPanel>
```

#### <a name="use-nested-directional-areas"></a>入れ子になった方向領域を使う

入れ子になった方向領域を複数レベル設定することができます。 すべての親要素の **XYFocusKeyboardNavigation** が **Enabled** に設定されている場合、領域の境界は方向キー ナビゲーションによって無視されます。

次の図は、入れ子になっている方向領域内に含まれる 3 つのボタン (A、B、C) と、方向領域の外側にある 4 つ目のボタン (D) を示しています。

![入れ子になった方向領域](images/keyboard/nested-directional-area.png)

*キーボードの方向キーは、ボタン A-B-C 間でフォーカスを移動できますが、D には移動できません。*

このコード例は、入れ子になった方向領域が領域の境界を越えた方向キー ナビゲーションをサポートするように指定する方法を示しています。

```XAML
<StackPanel Orientation="Horizontal">
        <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
            <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
                <Button Content="A" />
                <Button Content="B" />
            </StackPanel>
            <Button Content="C" />
        </StackPanel>
        <Button Content="D" />
 </StackPanel>
```

次の図は、A と B が入れ子になった方向領域に含まれていて、C と D が別の領域に含まれている 4 つのボタン (A、B、C、D) を示しています。 親要素の **XYFocusKeyboardNavigation** が **Disabled** に設定されているため、方向キーを使って入れ子になった各領域の境界を超えることはできません。

![非方向領域](images/keyboard/non-directional-area.png)

*キーボードの方向キーでは、A ボタンと B ボタンの間および C ボタンと D ボタンの間はフォーカスを移動できますが、領域間は移動できません。*

このコード例は、入れ子になった方向領域が領域の境界を越えた方向キー ナビゲーションをサポートしないように指定する方法を示しています。

```XAML
<StackPanel Orientation="Horizontal">
  <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
    <Button Content="A" />
    <Button Content="B" />
  </StackPanel>
  <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation="Enabled">
    <Button Content="C" />
    <Button Content="D" />
  </StackPanel>
</StackPanel>
```

入れ子になった方向領域のより複雑な例は次のとおりです。

-   A にフォーカスがある場合、方向キーによって B、C、D に移動できない非方向領域の境界が存在するため、E にのみ移動できる (その逆も同様)
-   B にフォーカスがある場合、D は方向領域の外側にあり、非方向領域の境界によって A と E へのアクセスがブロックされるため、C にのみ移動できる (その逆も同様)
-   D にフォーカスがある場合、方向キー ナビゲーションが不可能なため、コントロール間を移動するには Tab キーを使う必要がある

![入れ子になった非方向領域](images/keyboard/nested-non-directional-area.png)

*キーボードの方向キーでは、A ボタンと E ボタンの間および B ボタンと C ボタンの間はフォーカスを移動できますが、他の領域間は移動できません。*

このコード例は、入れ子になった方向領域が領域の境界を越えた複雑な方向キー ナビゲーションをサポートするように指定する方法を示しています。

```XAML
<StackPanel  Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
  <Button Content="A" />
    <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Disabled">
      <StackPanel Orientation="Horizontal" XYFocusKeyboardNavigation ="Enabled">
        <Button Content="B" />
        <Button Content="C" />
      </StackPanel>
        <Button Content="D" />
    </StackPanel>
  <Button Content="E" />
</StackPanel>
```

## <a name="set-the-tab-navigation-behavior-a-nametab-navigation"></a>タブ ナビゲーションの動作を設定する <a name="tab-navigation">

UIElement.[TabFocusNavigation](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Controls.Control.TabNavigation) プロパティは、そのオブジェクト ツリー全体 (または方向領域) のタブ ナビゲーションの動作を指定します。

[TabFocusNavigation](http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Windows.UI.Xaml.Controls.Control.TabNavigation) には、**TabFocusNavigationMode** 型の値があります。指定可能な値は、**Once**、**Cycle**、**Local** (既定) です。

次の図では、方向領域のタブ ナビゲーションに応じて次の順序でフォーカスが移動します。

-   Once: A、B1、C、A
-   Local: A、B1、B2、B3、B4、B5、C、A
-   Cycle: A、B1、B2、B3、B4、B5、B1、B2、B3、B4、B5、(B を順番に切り替え)

![タブ ナビゲーション](images/keyboard/tab-navigation.png)

*タブ ナビゲーション モードに基づくフォーカスの動作*

次のコード例は、Once モードでの TabFocusNavigation の使い方を示しています。

```XAML
<Button Content="X" Click="OnAClick"/>
<StackPanel Orientation="Horizontal" XYFocusNavigation ="Local"
   TabFocusNavigation ="Local">
   <Button Content="A" Click="OnAClick"/>
   <StackPanel Orientation="Horizontal" TabFocusNavigation ="Once">
        <Button Content="B" Click="OnBClick"/>
        <Button Content="C" Click="OnCClick"/>
        <Button Content="D" Click="OnDClick"/>
   </StackPanel>
   <Button Content="E" Click="OnBClick"/>
</StackPanel>
```

*フォーカスが X にある場合のタブ ナビゲーションは A、B、E、X*

#### <a name="about-tabfocusnavigation-and-tabindex"></a>TabFocusNavigation と TabIndex について

UIElement.TabFocusNavigation プロパティは、TabIndex の処理を含め、Control.TabNavigation プロパティと同じように動作します。

コントロールで TabIndex が指定されていない場合、フレームワークは現在の最大インデックス値 (および優先順位が最も低い) よりも大きいインデックス値を割り当てます。 ビジュアル ツリーの最初の要素を選ぶことによりあいまいさが解決されます。 フレームワークは、スコープごとにタブ インデックスを解決します。 コントロールの子はスコープと見なされ、そのいずれかの子に子がある場合、別のスコープの一部と見なされます。

次の図では、方向領域のタブ ナビゲーションと要素のタブ インデックスに応じて、フォーカスが次の順序で移動します。

-   Once: A、B3、C、A
-   Local: A、B3、B4、B5、B1、B2、C、A
-   Cycle: A、B3、B4、B5、B1、B2、B3、B4、B5、B1、B2、(B を順番に切り替え)

![タブ インデックス](images/keyboard/tab-index.png)

*タブ ナビゲーション モードとタブ インデックスに基づくフォーカスの動作*

方向領域がどのようにスコープと見なされ、優先度が最も高いコントロール (B3) にフォーカス ナビゲーションがどのように移動するかに注目してください。 実際には、A、方向領域、C のスコープと、方向領域のスコープの 2 つのスコープがあります。 方向の領域は TabStop ではないため、フレームワークはスコープを切り替えて最適な候補を探し、子要素を再帰的に切り替えます。
