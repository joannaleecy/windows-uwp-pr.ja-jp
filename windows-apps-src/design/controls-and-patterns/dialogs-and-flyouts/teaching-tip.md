---
ms.openlocfilehash: 15379e51f8c272d0cc1e888684322104186bb200
ms.sourcegitcommit: 7a1d5198345d114c58287d8a047eadc4fe10f012
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/08/2019
ms.locfileid: "59249504"
---
# <a name="teaching-tip"></a>教育のヒント

教育のヒントは、半永続的なと、豊富なコンテンツのポップアップで、コンテキスト情報を提供します。 通知、通知、および感を高めることがあり、重要な新しい機能についてユーザーに知らせることがよく使用されます。

**重要な Api:**[TeachingTip クラス](https://docs.microsoft.com/en-us/uwp/api/microsoft.ui.xaml.controls.teachingtip)

教育のヒントがあります光無視または明示的なアクションを閉じる必要があります。 教育のヒントを末尾に特定の UI 要素をターゲットにして末尾またはターゲットなしでも使用します。

## <a name="is-this-the-right-control"></a>適切なコントロールの選択 

使用して、 **TeachingTip**経験の向上またはタスクの完了方法をユーザーに教えるされる重要でないオプションのユーザーに通知する新規または重要な更新プログラムと機能にユーザーの注意を集中するコントロール。 

教育のヒントは一時的であるためにはならないユーザー エラーまたは状態に関する重要な変更についてのプロンプトの推奨されるコントロールです。


## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="../images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p>ある場合、 <strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong>アプリをインストールするには、ここをクリックして<a href="xamlcontrolsgallery:/item/TeachingTip">アプリを開き、アクションで TeachingTip を参照してください。</a>します。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

教育のヒントには、これらの注目すべきものを含む、いくつかの構成を持つことができます。

特定の UI 要素を表示する情報のコンテキストの鮮明さを強化するためには、その末尾で教育ヒント対象にできます。 

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-targeted.png)

表示される情報は、特定の UI 要素には関連しません、ときに、末尾を削除することによって nontargeted 教育ヒントを作成できます。

![右下隅に教育ヒントを使ってサンプル アプリです。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-non-targeted.png)

教育ヒントは、上の隅で、"X"ボタンまたは下部にある [閉じる] ボタンを使用して閉じることをユーザーに要求できます。 教育ヒント可能性がありますもされる光-閉じる閉じるボタンが有効な場合は、ユーザーがスクロールしたり、アプリケーションの他の要素とやり取り教育ヒントを閉じる代わりにします。 この動作によりライト-無視のヒントは、最適なソリューション、ヒントは、スクロール可能な領域に配置する必要がある場合。 

![使ってサンプル アプリの右下隅で教育ヒントのライトの破棄します。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」](../images/teaching-tip-light-dismiss.png)


### <a name="create-a-teaching-tip"></a>教育ヒントを作成します。

ここでは、対象となる教育の XAML コントロールのタイトルとサブタイトル TeachingTip の既定の外観を示すヒントします。 教育のヒントに含まれる任意の場所、要素ツリーまたは分離コードに注意してください。 次の例には ResourceDictionary にあります。

XAML
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

C#
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

次ページ ボタンを含むと教えるヒントが表示されるときに、結果を示します。

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-targeted.png)

### <a name="non-targeted-tips"></a>非対象のヒント

すべてのヒントは、画面に表示される要素に関連します。 これらのシナリオでは、ターゲット プロパティを設定しないし、教育ヒントは xaml ルートの端を基準とした代わりに表示されます。 ただし、教育ヒントでは、末尾に「折りたたまれた」TailVisibility プロパティを設定して、UI 要素の相対的な位置を維持したまま削除することができます。 次の例では、教育の対象外のヒントの。

XAML
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to.">
</controls:TeachingTip>
```

この例では、TeachingTip が要素ツリーではなく ResourceDictionary または分離コードに注意してください。 これは、動作に影響はありません。TeachingTip はのみを表示する場合、し、レイアウト スペースを占有します。

![右下隅に教育ヒントを使ってサンプル アプリです。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-non-targeted.png)

### <a name="preferred-placement"></a>推奨される配置

教育ヒント レプリケート フライアウトの[FlyoutPlacementMode](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Primitives.FlyoutPlacementMode) TeachingTipPlacementMode プロパティを使用して配置動作。 既定の配置モードは、ターゲット上の対象となる教育ヒントと対象外の教育ヒントが xaml ルートの下部中央に配置しようとします。 として、フライアウトで推奨される配置モードは、教育のヒントを表示する余裕を確保していない場合別の配置モードが自動的に選択されます。 

Gamepad 入力を予測するアプリケーションを参照してください[ゲームパッドとリモート制御の相互作用]( https://docs.microsoft.com/en-us/windows/uwp/design/input/gamepad-and-remote-interactions#xy-focus-navigation-and-interaction)します。 アプリの UI のすべての可能な構成を使用して各教育ヒントのゲームパッド アクセシビリティをテストすることをお勧めします。

左にシフトして、教育ヒントの本文と共に、そのターゲットの下部中央に末尾に「斜め」に設定、PreferredPlacement を対象となる教育ヒントが表示されます。

XAML
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

![[保存] ボタンの左下にある教育 tip によって対象を使ってサンプル アプリです。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-targeted-preferred-placement.png)


「斜め」に設定、PreferredPlacement と教育の対象外のヒントは、xaml のルートの左下隅に表示されます。

XAML
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    PreferredPlacement="BottomLeft">
</controls:TeachingTip>
```

![左下隅に教育ヒントを使ってサンプル アプリです。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-non-targeted-preferred-placement.png)

次の図は、ヒントの講義を対象に指定可能なすべての 13 PreferredPlacement モードの結果を示しています。
![3 つのオブジェクト ラベルが付いた「ターゲット」周囲に教育ヒントの推奨される対象の配置モードを表示するために使用するヒントの講義を対象とします。 末尾を使用してターゲットを指し示す"Center"というラベルの付いた対象となる教育ヒントは、最初のターゲットの途中で中央に配置します。 末尾に target 下"Top"を指すというラベルの付いた対象となる教育ヒントは、最初のターゲット上中央に配置します。 末尾に target 左を指す"Right"というラベルの付いた対象となる教育ヒントは、最初のターゲットの右中央に配置します。 末尾に target 上向き"Bottom"というラベルの付いた対象となる教育ヒントは、最初の目標を下回って中央に配置します。 最初のターゲットの左側の末尾を使用してターゲットにポイントを"Left"というラベルの付いた対象となる教育ヒントは、中央に配置します。 2 つ目のターゲットの左側には教育ヒント target 右を指す"LeftTop"とは、本文は前に移動します。 2 つ目の目標を上回っては教育ヒント「左」下を向き、ターゲットにして、本体がシフトされた左。 2 つ目の右側には、ターゲットは、ポイントが、ターゲットのまま、そのが本文の下に移動"RightBottom"というラベルの付いた教育ヒントです。 以下の 2 つ目のターゲットは教育のヒントをターゲット指し示す"BottomRight"とが本文だけシフトし右方向。 3 番目の目標を上回っては教育ヒント target 下を向き「右」とは、本文にシフトし右方向。 3 番目の右側には、ターゲットは、ターゲットのままでポイントが本体の前に移動して"RightTop"というラベルの付いた教育ヒントです。 以下の 3 番目のターゲットは教育のヒント「斜め」をターゲット指し示すし、本文がシフトされた左。 3 番目のターゲットの左側には教育ヒント target 右を指す"LeftBottom"とは本文の下に移動します。](../images/teaching-tip-targeted-preferred-placement-modes.png)

次の図は、教育の対象外のヒントを設定できるすべての 13 PreferredPlacement モードの結果を示しています。
![教育ヒントの推奨される配置の対象外のモードを示すために 9 つの対象外の教育ヒントを表示するアプリ ウィンドウです。 アプリの左上隅にある教育ヒントのラベルは「左上端または LeftTop」 "Top"というラベルが付いた、アプリの上端を中心と教育のヒント アプリの右上隅にある教育ヒントが「右または RightTop」というラベルが付いた "Left"というラベルが付いた、アプリの左端を中心と教育のヒント "Center"というラベルが付いた、アプリの中央に教育のヒント
「権限」というラベルが付いた、アプリの右端を中心と教育のヒント アプリの左下隅で教育ヒントが「斜めまたは LeftBottom」というラベルが付いた アプリの下端を中心と教育のヒントは、"Bottom"というラベルが付いた アプリの右下隅で教育ヒントが「BottomRight または RightBottom」というラベルが付いた](../images/teaching-tip-non-targeted-preferred-placement-modes.png)

### <a name="add-a-placement-margin"></a>配置の余白を追加します。  

そのターゲットとは別に対象となる教育ヒントを設定する距離と教育の対象外のヒントを PlacementMargin プロパティを使用して xaml ルートの端とは別に設定がどの程度を制御できます。 ような[余白](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.frameworkelement.margin)PlacementMargin が 4 つの値、– left、right、top、および下 – のみ、関連する値が使用されます。 たとえば、ヒントは、ターゲットのまたは xaml ルートの左端のままにした場合に PlacementMargin.Left が適用されます。

次の例では、すべてのセットを 80 PlacementMargin の左/右/上下の対象外のヒントを示します。

XAML
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    PreferredPlacement="BottomLeft"
    PlacementMargin="80">
</controls:TeachingTip>
```

![教育ヒントを表示、方向が、完全なに対する、右下隅に配置されているサンプル アプリです。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-placement-margin.png)


### <a name="add-content"></a>コンテンツを追加します。

コンテンツは、コンテンツのプロパティを使用して、教育ヒントに追加できます。 により教育ヒントのサイズよりも表示する複数のコンテンツがある場合、コンテンツ エリアをスクロールするようにする場合、スクロール バーを自動的に有効になります。 

XAML
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

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育のヒントのコンテンツ領域には、チェック ボックスをオン「の起動時にヒントを表示しない」と「設定を変更する、ヒントの設定に変わった場合」というテキストの下には、「設定」が、アプリの設定ページへのリンクです。 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-content.png)

### <a name="add-buttons"></a>ボタンを追加します。

既定では、標準の"閉じるボタンの X"は教育のヒントのタイトルの横にある表示します。 教育ヒントの下部に移動する場合、ボタン、CloseButtonContent プロパティを使用して閉じる ボタンをカスタマイズできます。

**注:[閉じる] ボタンには表示されませんが有効なヒントを光無視**

ActionButtonContent プロパティ (および必要に応じて、ActionButtonCommand および ActionButtonCommandParameter プロパティ) を設定して、カスタム アクション ボタンを追加できます。

XAML
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

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育のヒントのコンテンツ領域には、チェック ボックスをオン「の起動時にヒントを表示しない」と「設定を変更する、ヒントの設定に変わった場合」というテキストの下には、「設定」が、アプリの設定ページへのリンクです。 教育の下部には 2 つのボタン、"Disable"を読み取る左側の灰色の 1 つと読み取りが右側に青い折れ線「ぞ!」](../images/teaching-tip-buttons.png)

### <a name="hero-content"></a>ヒーローのコンテンツ

Edge のコンテンツをエッジは、HeroContent プロパティを設定して、教育のヒントに追加できます。 HeroContentPlacement プロパティを設定して、上または教育ヒントの下にヒーローのコンテンツの場所を設定できます。

XAML
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

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育のヒントの下部にあるのファイルをクラウドに配置マンガ男性の境界線の境界線イメージです。 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-hero-content.png)

### <a name="add-an-icon"></a>アイコンを追加します。

タイトルとサブタイトル IconSource プロパティを使用して横にあるアイコンを追加できます。 推奨されるアイコンのサイズには、16 px、24px、32px などがあります。 

XAML
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

![教育ヒントを表示、保存対象とするサンプル アプリをクリックします。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 タイトルとサブタイトルの左側に、フロッピー ディスク アイコンです。 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-icon.png)

### <a name="enable-light-dismiss"></a>有効にする の light 無視します。

ライト無視の機能が既定で無効になっていますが、教育ヒントは無視、例については、ユーザーがスクロールしたり、アプリケーションの他の要素とやり取りできるように有効にできます。 この動作によりライト-無視のヒントは、最適なソリューション、ヒントは、スクロール可能な領域に配置する必要がある場合。 

閉じるボタンが自動的に識別するために light-dismiss が有効な教育ヒントから削除されます、ユーザー動作のライト無視します。 

XAML
```XAML
<Button x:Name="SaveButton" Content="Save" />

<controls:TeachingTip x:Name="AutoSaveTip"
    Title="Saving automatically"
    Subtitle="We save your changes as you go - so you never have to."
    IsLightDismissEnabled="True">
</controls:TeachingTip>
```

![使ってサンプル アプリの右下隅で教育ヒントのライトの破棄します。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」](../images/teaching-tip-light-dismiss.png)

### <a name="escaping-the-xaml-root-bounds"></a>Xaml のルートの境界をエスケープ

Windows のバージョンの 19 H 1 と、教育上のヒントは ShouldConstrainToRootBounds プロパティを設定して xaml ルートと、画面の境界をエスケープできます。 このプロパティが有効にすると、教育ヒントしようとしません xaml ルートも画面の境界で状態を維持し、セットの位置では常に PreferredPlacement モード。 IsLightDismissEnabled プロパティを有効にして、ユーザーの最適なエクスペリエンスを確実に xaml ルートの中央に最も近い PreferredPlacement モードを設定することをお勧めします。

以前のバージョンの Windows では、このプロパティは無視され、教育のヒントは、xaml ルートの境界内で常に存在します。

XAML
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

![アプリの右下隅の外部で教育ヒントを使ってサンプル アプリです。 ヒントのタイトルが「自動的に保存」を読み取り、字幕の読み取り「変更を保存していく - ためする必要はありません」 教育の先端の右上隅の閉じるボタンがあります。](../images/teaching-tip-escape-xaml-root.png)

### <a name="canceling-and-deferring-close"></a>キャンセルして、閉じるを保留します。

Closing イベントは、キャンセルや教育ヒントの終了を遅延を使用できます。 教育のヒントを開いたまままたはアクションまたはカスタム アニメーションが開始する時間を許可するために使用できます。 教育ヒントの終了が取り消されると、IsOpen が true に戻るには、ただし、そのまま残ります false、遅延中にします。 プログラムの終了を取り消すこともできます。 

**注:配置オプションは、完全に表示するヒントを教育許可しない場合、教育のヒントはせず、アクセス可能な閉じるボタンを表示するのではなく、強制的に終了するイベントのライフ サイクルを反復処理します。 Closing イベントをキャンセルすると、アプリ教育ヒントがアクセス可能な閉じる ボタンを行わずに開く残ることがあります。**

XAML
```XAML
<controls:TeachingTip x:Name="EnableNewSettingsTip"
    Title="New ways to protect your privacy!"
    Subtitle="Please close this tip and review our updated privacy policy and privacy settings."
    Closing="OnTipClosing">
</controls:TeachingTip>
```

C#
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

## <a name="remarks"></a>注釈

### <a name="related-articles"></a>関連記事 

* [ダイアログとポップアップ](https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/dialogs-and-flyouts/index)

### <a name="recommendations"></a>推奨事項
* ヒントは永続的であり、情報や、アプリケーションのエクスペリエンスに重要なオプションを含めることはできません。 
* 頻度が高すぎる教育ヒントが表示されないようにしてください。 教育のヒントが最も高い長いセッション全体、または複数のセッション間で交互にいるときに、個々 の注意を受け取る各します。    
* 簡潔なヒントと、トピックをクリアしてください。 調査によると平均すると、ユーザー、3 ~ 5 の単語を読み取るし、のみのみチップと対話するかどうかを決定する前に 2 ~ 3 の単語を理解します。
* 教育ヒントのゲームパッドのアクセシビリティは保証されません。 Gamepad 入力を予測するアプリケーションを参照してください[ゲームパッドとリモート制御の相互作用]( https://docs.microsoft.com/en-us/windows/uwp/design/input/gamepad-and-remote-interactions#xy-focus-navigation-and-interaction)します。 アプリの UI のすべての可能な構成を使用して各教育ヒントのゲームパッド アクセシビリティをテストすることをお勧めします。
* Xaml のルートをエスケープする教育チップを有効にするときに、IsLightDismissEnabled プロパティを有効にして、xaml のルートの中央に最も近い PreferredPlacement モードを設定することをお勧めします。 

### <a name="reconfiguring-an-open-teaching-tip"></a>開いている教育ヒントの再構成

教育のヒントが開いており、すぐに反映中には、一部のコンテンツとプロパティを再構成できます。 その他のコンテンツとプロパティ、光を無視し、明示的な閉じるアイコンのプロパティ、操作と閉じるボタン、および再構成の間などがすべて、教育スタイラスの先端をこれらのプロパティを有効にする変更を閉じてで必要があります。 教育スタイラスの先端を削除する前に、閉じるボタンがあるからジョンソン動作を変更する手動の無視を光閉じます教育ヒントが開いている間に注意してください、光を閉じる動作が有効になっているし、ヒントは止まったまま画面に表示されます。
