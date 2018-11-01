---
author: Xansky
Description: If your app does not provide good keyboard access, users who are blind or have mobility issues can have difficulty using your app or may not be able to use it at all.
ms.assetid: DDAE8C4B-7907-49FE-9645-F105F8DFAD8B
title: キーボードのアクセシビリティ
label: Keyboard accessibility
template: detail.hbs
ms.author: mhopkins
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 41c5e018ee56b6a0d26bf2159f62801aa4ab5c3c
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5888035"
---
# <a name="keyboard-accessibility"></a>キーボードのアクセシビリティ  



アプリに十分なキーボード操作機能が備わっていない場合、視覚障碍や運動障碍のあるユーザーはアプリをうまく使うことができなかったり、まったく使うことができない可能性があります。

<span id="keyboard_navigation_among_UI_elements"/>
<span id="keyboard_navigation_among_ui_elements"/>
<span id="KEYBOARD_NAVIGATION_AMONG_UI_ELEMENTS"/>

## <a name="keyboard-navigation-among-ui-elements"></a>UI 要素間でのキーボード ナビゲーション  
キーボードでコントロールを操作するにはフォーカスが必要です。ポインターを使わずにフォーカスを移すには、UI 設計でタブ ナビゲーションを使ってコントロールにアクセスできるようにする必要があります。 既定では、コントロールのタブ オーダーは、デザイン サーフェイスに追加された順序、XAML で一覧表示された順序、またはプログラムを使ってコンテナーに追加された順序と同じになります。

ほとんどの場合、XML でのコントロールの定義に基づく既定の順序が最適な順序です。これは特に、スクリーン リーダーで読み取られるコントロールの順序と一致するためです。 ただし、既定の順序は表示順序と対応するとは限りません。 実際の表示位置は親レイアウト コンテナーと特定のプロパティに依存し、それらを子要素で設定することでレイアウトに影響することがあります。 アプリのタブ オーダーが適切に設定されていることを確かめるには、この動作を自身でテストする必要があります。 特に、グリッド形式や表形式で表されるレイアウトを使っている場合は、ユーザーが読み進める順序とタブ オーダーが一致しない可能性があります。 それ自体は必ずしも問題になるとは限りませんが、 必ずタッチ可能な UI とキーボードからアクセス可能な UI の両方についてアプリの機能をテストして、どちらの方法でも UI が適切に動作することを確認してください。

タブ オーダーと表示順序は、XAML を調整することで一致させることができます。 また、既定のタブ オーダーは、[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) プロパティを設定して上書きできます。たとえば、次の [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) レイアウトでは、タブ ナビゲーションで列が最初に選ばれるようにしています。

XAML
```xml
<!--Custom tab order.-->
<Grid>
  <Grid.RowDefinitions>...</Grid.RowDefinitions>
  <Grid.ColumnDefinitions>...</Grid.ColumnDefinitions>

  <TextBlock Grid.Column="1" HorizontalAlignment="Center">Groom</TextBlock>
  <TextBlock Grid.Column="2" HorizontalAlignment="Center">Bride</TextBlock>

  <TextBlock Grid.Row="1">First name</TextBlock>
  <TextBox x:Name="GroomFirstName" Grid.Row="1" Grid.Column="1" TabIndex="1"/>
  <TextBox x:Name="BrideFirstName" Grid.Row="1" Grid.Column="2" TabIndex="3"/>

  <TextBlock Grid.Row="2">Last name</TextBlock>
  <TextBox x:Name="GroomLastName" Grid.Row="2" Grid.Column="1" TabIndex="2"/>
  <TextBox x:Name="BrideLastName" Grid.Row="2" Grid.Column="2" TabIndex="4"/>
</Grid>
```

特定のコントロールをタブ オーダーから除外することができます。 基本的に、コントロールを非対話型にするだけで除外することができます ([**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/BR209419) プロパティを **false** に設定するなど)。 無効になったコントロールは自動的にタブ オーダーから除外されます。 ただし、コントロールが無効になっていなくても、タブ オーダーからコントロールを除外したい場合があります。 この場合は、[**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/BR209422) プロパティを **false** に設定します。

通常、フォーカスを設定できる要素はすべて、既定でタブ オーダーに含まれています。 例外は、[**RichTextBlock**](https://msdn.microsoft.com/library/windows/apps/BR227565) などの一部のテキスト表示型です。このような型では、選択中のテキストにクリップボードからアクセスできるように、フォーカスを設定することができます。ただし、静的テキスト要素がタブ オーダーの対象となることは想定されていないため、タブ オーダーには含められません。 通常、これらの要素は対話型ではありません (これらは呼び出すことができず、テキスト入力も必要としませんが、テキスト内の選択ポイントを見つけて調整できる[テキスト コントロール パターン](https://msdn.microsoft.com/library/windows/desktop/Ee671194)はサポートしています)。 テキストに、フォーカスを設定すると操作が可能になるという含みを持たせないでください。 それでも、テキスト要素は、支援技術によって検出され、スクリーン リーダーによって読み上げられますが、これはその要素を実際のタブ オーダーで見つけるのとは異なる技法に依存しています。

[**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) 値を調整する場合も、既定の順序を使う場合も、次のルールが適用されます。

* [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) が 0 の UI 要素は、XAML または子コレクションでの宣言順序に基づいてタブ オーダーに追加されます。
* [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) が 0 を超える UI 要素は、**TabIndex** 値に基づいてタブ オーダーに追加されます。
* [**TabIndex**](https://msdn.microsoft.com/library/windows/apps/BR209461) が 0 未満の UI 要素はタブ オーダーに追加され、値 0 の UI 要素よりも前に表示されます。 これは、HTML による **tabindex** 属性の処理とは異なる場合があります (古い HTML 仕様では、負の値の **tabindex** がサポートされていませんでした)。

<span id="keyboard_navigation_within_a_UI_element"/>
<span id="keyboard_navigation_within_a_ui_element"/>
<span id="KEYBOARD_NAVIGATION_WITHIN_A_UI_ELEMENT"/>

## <a name="keyboard-navigation-within-a-ui-element"></a>UI 要素内でのキーボード ナビゲーション  
コンポジット要素の場合は、含まれている要素間で正しい内部ナビゲーションが実行できることが重要です。 コンポジット要素では、その現在のアクティブな子を管理して、すべての子要素にフォーカスを設定できるようにする場合のオーバーヘッドを減らすことができます。 このようなコンポジット要素もタブ オーダーに含まれ、キーボード ナビゲーション イベント自体を処理します。 複合コントロールには、多くの場合、コントロールのイベント処理の中に既に内部ナビゲーション ロジックが組み込まれています。 たとえば、項目の方向キー トラバーサルは、既定では [**ListView**](https://msdn.microsoft.com/library/windows/apps/BR242878) コントロール、[**GridView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview) コントロール、[**ListBox**](https://msdn.microsoft.com/library/windows/apps/BR242868) コントロール、[**FlipView**](https://msdn.microsoft.com/library/windows/apps/BR242678) コントロールで有効になります。

<span id="keyboard_activation"/>
<span id="KEYBOARD_ACTIVATION"/>

## <a name="keyboard-alternatives-to-pointer-actions-and-events-for-specific-control-elements"></a>特定のコントロール要素に対するポインター操作やイベントの代わりにキーボードを利用  
クリックできる UI 要素をキーボードでも呼び出すことができるようにします。 キーボードで UI 要素を操作するには、要素にフォーカスが必要になります。 フォーカスとタブ ナビゲーションをサポートするのは、[**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) から派生するクラスだけです。

呼び出すことができる UI 要素の場合は、Space キーと Enter キーのキーボード イベント ハンドラーを実装します。 これで、基本のキーボード アクセシビリティのサポートは完全になり、ユーザーはキーボードのみを使って基本のアプリ シナリオを実行できます。つまり、ユーザーはすべての対話型の UI 要素にアクセスしたり、既定の機能をアクティブにすることができます。

UI で使う要素がフォーカスを取得できない場合は、独自のカスタム コントロールを作成できます。 [**IsTabStop**](https://msdn.microsoft.com/library/windows/apps/BR209422) プロパティを **true** に設定して入力フォーカスを有効にし、UI にフォーカス インジケーターが示される表示状態を作成して、フォーカスがある状態を視覚的に示す必要があります。 タブ ストップ、フォーカス、Microsoft UI オートメーションのピアとパターンのサポートを、コンテンツを合成するコントロールで処理するよう、コントロールの合成を使うと簡単になることがよくあります。

たとえば、ポインター入力イベントを [**Image**](https://msdn.microsoft.com/library/windows/apps/BR242752) で処理するのではなく、その要素を [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) でラップすると、ポインター、キーボード、フォーカスのサポートを取得できます。

XAML
```xml
<!--Don't do this.-->
<Image Source="sample.jpg" PointerPressed="Image_PointerPressed"/>

<!--Do this instead.-->
<Button Click="Button_Click"><Image Source="sample.jpg"/></Button>
```

<span id="keyboard_shortcuts"/>
<span id="KEYBOARD_SHORTCUTS"/>

## <a name="keyboard-shortcuts"></a>キーボード ショートカット  
キーボードのナビゲーションのアクティブ化をアプリに実装するだけでなく、ショートカットをアプリの機能に実装することをお勧めします。 基本的なキーボードのサポートとしてはタブ ナビゲーションで十分ですが、複雑なフォームではショートカット キーのサポートも追加すると効果的です。 これにより、キーボードとポインティング デバイスの両方を使うユーザーにも使いやすいアプリになります。

*ショートカット*は、ユーザーが効率的にアプリの機能にアクセスできるようにして、生産性を向上させるためのキーの組み合わせです。 ショートカットには次の 2 つの種類があります。

* *アクセス キー*は、アプリ内の個別の UI 要素へのショートカットです。 アクセス キーは、Alt キーと文字キーの組み合わせで構成されます。
* *ショートカット キー*は、アプリ コマンドへのショートカットです。 アプリにはコマンドに正確に対応する UI がある場合とない場合があります。 ショートカット キーは、Ctrl キーと文字キーの組み合わせで構成されます。

スクリーン リーダーやその他の支援技術を使うユーザーがアプリのショートカット キーを簡単に見つけることができることが重要です。 ヒント、アクセシビリティ対応の名前、アクセシビリティ対応の説明、またはその他の画面上の伝達形式を使ってショートカットが確認できるようにします。 少なくとも、アプリのヘルプ コンテンツにはショートカット キーについて十分な説明を用意しておく必要があります。

スクリーン リーダーでアクセス キーを文書化するには、[**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/Hh759763) 添付プロパティでショートカット キーを示す文字列を設定します。 また、[**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/Hh759762) 添付プロパティでニーモニック以外のショートカット キーを文書化することもできます。ただし、スクリーン リーダーでは通常、どちらのプロパティも同じ方法で扱われます。 ショートカット キーの文書化は、ヒント、オートメーションのプロパティ、ヘルプ ドキュメントなど、複数の方法で行います。

次の例では、メディアを再生、一時停止、停止するボタンのショートカット キーを文書化する方法を示しています。

XAML
```xml
<Grid KeyDown="Grid_KeyDown">

  <Grid.RowDefinitions>
    <RowDefinition Height="Auto" />
    <RowDefinition Height="Auto" />
  </Grid.RowDefinitions>

  <MediaElement x:Name="DemoMovie" Source="xbox.wmv"
    Width="500" Height="500" Margin="20" HorizontalAlignment="Center" />

  <StackPanel Grid.Row="1" Margin="10"
    Orientation="Horizontal" HorizontalAlignment="Center">

    <Button x:Name="PlayButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+P"
      AutomationProperties.AcceleratorKey="Control P">
      <TextBlock>Play</TextBlock>
    </Button>

    <Button x:Name="PauseButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+A"
      AutomationProperties.AcceleratorKey="Control A">
      <TextBlock>Pause</TextBlock>
    </Button>

    <Button x:Name="StopButton" Click="MediaButton_Click"
      ToolTipService.ToolTip="Shortcut key: Ctrl+S"
      AutomationProperties.AcceleratorKey="Control S">
      <TextBlock>Stop</TextBlock>
    </Button>
  </StackPanel>
</Grid>
```

> [!IMPORTANT]
> [**AutomationProperties.AcceleratorKey**](https://msdn.microsoft.com/library/windows/apps/Hh759762) または [**AutomationProperties.AccessKey**](https://msdn.microsoft.com/library/windows/apps/Hh759763) を設定しても、キーボード機能は有効になりません。 使用する必要があるキーなどの情報を支援技術によってユーザーに渡すことができるように、そのような情報が UI オートメーション フレームワークに通知されるだけです。 キー処理の実装は、XAML ではなくコードで行う必要があります。 アプリに対して実際にキーボード ショートカットの動作を実装するには、関連するコントロールに [**KeyDown**](https://msdn.microsoft.com/library/windows/apps/BR208941) イベントや [**KeyUp**](https://msdn.microsoft.com/library/windows/apps/BR208942) イベントのハンドラーをアタッチする必要があります。 また、アクセス キーの下線も自動的には追加されません。 UI で下線付きのテキストを表示する場合は、インラインの [**Underline**](https://msdn.microsoft.com/library/windows/apps/BR209982) 書式設定として、ニーモニックの特定のキーのテキストに明示的に下線を表示する必要があります。

わかりやすくするために、上の例では "Ctrl + A" などの文字列に対するリソースは使っていません。 ただし、ローカライズ時にはショートカット キーについても考慮する必要があります。 ショートカット キーとして使うキーは通常、要素の表示テキスト ラベルに基づいて選ぶため、ショートカット キーをローカライズすることは適切な作業です。

ショートカット キーの実装について詳しくは、Windows ユーザー エクスペリエンス インタラクション ガイドラインの[ショートカット キー](http://go.microsoft.com/fwlink/p/?linkid=221825)に関する説明をご覧ください。

<span id="Implementing_a_key_event_handler"/>
<span id="implementing_a_key_event_handler"/>
<span id="IMPLEMENTING_A_KEY_EVENT_HANDLER"/>

### <a name="implementing-a-key-event-handler"></a>キー イベント ハンドラーの実装  
キー イベントなどの入力イベントでは、*ルーティング イベント*というイベント概念を使います。 ルーティング イベントは、共通コントロールの親が複数の子要素に対するイベントを処理できるような、合成コントロールの子要素をバブルアップすることがあります。 このイベント モデルは、仕様によりフォーカスの設定やタブ オーダーへの追加ができない複数の複合パートが含まれるコントロールに、ショートカット キーの操作を定義するときに役立ちます。

Ctrl キーなどの修飾キーのチェックを含むキー イベント ハンドラーの記述方法を示すコード例については、「[キーボード操作](https://msdn.microsoft.com/library/windows/apps/Mt185607)」をご覧ください。

<span id="Keyboard_navigation_for_custom_controls"/>
<span id="keyboard_navigation_for_custom_controls"/>
<span id="KEYBOARD_NAVIGATION_FOR_CUSTOM_CONTROLS"/>

## <a name="keyboard-navigation-for-custom-controls"></a>カスタム コントロールのキーボード ナビゲーション  
子要素間に空間的な関係が存在する場合は、子要素間を移動するためのキーボード ショートカットとして方向キーを使うことをお勧めします。 ツリー ビュー ノードに、展開折りたたみとノードのアクティブ化を処理するための別のサブ要素がある場合は、左右の方向キーを使って、キーボードの展開折りたたみ機能を提供します。 コントロール コンテンツ内で方向トラバーサルをサポートする指向コントロールがある場合は、適切な方向キーを使ってください。

一般に、カスタム コントロールに対するカスタム キー処理を実装する場合は、クラス ロジックの一部として、[**OnKeyDown**](https://msdn.microsoft.com/library/windows/apps/hh967982.aspx) メソッドと [**OnKeyUp**](https://msdn.microsoft.com/library/windows/apps/hh967983.aspx) メソッドのオーバーライドを組み込みます。

<span id="An_example_of_a_visual_state_for_a_focus_indicator"/>
<span id="an_example_of_a_visual_state_for_a_focus_indicator"/>
<span id="AN_EXAMPLE_OF_A_VISUAL_STATE_FOR_A_FOCUS_INDICATOR"/>

## <a name="an-example-of-a-visual-state-for-a-focus-indicator"></a>フォーカス インジケーターの表示状態の例  
これまで説明したように、ユーザーがフォーカスを合わせることができるカスタム コントロールには視覚的なフォーカス インジケーターが必要です。 一般に、フォーカス インジケーターは、コントロールを囲む通常の四角形の境界線のすぐ外側に、四角形を描画するだけの簡単なものです。 視覚的なフォーカスに使う [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) は、コントロール テンプレートにおけるコントロールの合成の他の部分に対するピア要素ですが、最初はコントロールにフォーカスがないため、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) の値には **Collapsed** が設定されています。 コントロールがフォーカスを取得すると、表示状態が呼び出され、フォーカス表示の **Visibility** が **Visible** に設定されます。 フォーカスが別の場所に移動すると、他の表示状態が呼び出され、**Visibility** が **Collapsed** になります。

既定の XAML コントロールはいずれも、フォーカスを設定できるものであれば、フォーカスを受け取ったときに視覚的なフォーカス インジケーターを適切に表示します。 また、ユーザーが選んでいるテーマに応じて (ハイ コントラスト モードを使っている場合は特に)、外観が異なる可能性があります。UI で XAML コントロールを使っており、コントロール テンプレートを置き換えていない場合は、特に何もしなくても、視覚的なフォーカス インジケーターがコントロールに適切に表示され、動作します。 ただし、コントロールを再テンプレート化する必要がある場合、または XAML コントロールで視覚的なフォーカス インジケーターがどのように実現されているかを理解したい場合のために、このセクションの残りの部分では、XAML とコントロール ロジックにおけるフォーカス インジケーターの処理方法について説明します。

次に示す XAML の例は、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) の既定の XAML テンプレートに含まれています。

XAML
```xml
<ControlTemplate TargetType="Button">
...
    <Rectangle
      x:Name="FocusVisualWhite"
      IsHitTestVisible="False"
      Stroke="{ThemeResource FocusVisualWhiteStrokeThemeBrush}"
      StrokeEndLineCap="Square"
      StrokeDashArray="1,1"
      Opacity="0"
      StrokeDashOffset="1.5"/>
    <Rectangle
      x:Name="FocusVisualBlack"
      IsHitTestVisible="False"
      Stroke="{ThemeResource FocusVisualBlackStrokeThemeBrush}"
      StrokeEndLineCap="Square"
      StrokeDashArray="1,1"
      Opacity="0"
      StrokeDashOffset="0.5"/>
...
</ControlTemplate>
```

ここまでのところでは、これは単なる合成です。 フォーカス インジケーターの表示を制御するには、[**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) プロパティを切り替える表示状態を定義します。 それには、[**VisualStateManager.VisualStateGroups**](https://msdn.microsoft.com/library/windows/apps/Hh738505) 添付プロパティを使います。これは合成を定義するルート要素に適用されます。

XAML
```xml
<ControlTemplate TargetType="Button">
  <Grid>
    <VisualStateManager.VisualStateGroups>
       <!--other visual state groups here-->
       <VisualStateGroup x:Name="FocusStates">
         <VisualState x:Name="Focused">
           <Storyboard>
             <DoubleAnimation
               Storyboard.TargetName="FocusVisualWhite"
               Storyboard.TargetProperty="Opacity"
               To="1" Duration="0"/>
             <DoubleAnimation
               Storyboard.TargetName="FocusVisualBlack"
               Storyboard.TargetProperty="Opacity"
               To="1" Duration="0"/>
         </VisualState>
         <VisualState x:Name="Unfocused" />
         <VisualState x:Name="PointerFocused" />
       </VisualStateGroup>
     <VisualStateManager.VisualStateGroups>
<!--composition is here-->
   </Grid>
</ControlTemplate>
```

指定された状態のうち 1 つのみが [**Visibility**](https://msdn.microsoft.com/library/windows/apps/BR208992) を直接調整し、他の状態が空のように見えることに注意してください。 表示状態の動作は、同じ [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/BR209014) の別の状態がコントロールで使われるとすぐに、前の状態で適用されていたすべてのアニメーションが取り消されるというものです。 合成の既定の **Visibility** は **Collapsed** であるため、四角形は表示されません。 コントロールのロジックでは、[**GotFocus**](https://msdn.microsoft.com/library/windows/apps/BR208927) などのフォーカス イベントをリッスンし、[**GoToState**](https://msdn.microsoft.com/library/windows/apps/BR209025) を使って状態を変更することで、これを制御しています。 既定のコントロールを使っているか、この動作が既に設定されているコントロールを基にカスタマイズしている場合、これは既に自動的に処理されていることがほとんどです。

<span id="Keyboard_accessibility_and_Windows_Phone"/>
<span id="keyboard_accessibility_and_windows_phone"/>
<span id="KEYBOARD_ACCESSIBILITY_AND_WINDOWS_PHONE"/>

## <a name="keyboard-accessibility-and-windows-phone"></a>キーボードのアクセシビリティと Windows Phone
Windows Phone デバイスには、通常、専用のハードウェア キーボードがありません。 ただし、ソフト入力パネル (SIP) は、複数のキーボード アクセシビリティのシナリオをサポートできます。 スクリーン リーダーは、削除も含めて、**テキスト** SIP からのテキスト入力を読み取ることができます。 スクリーン リーダーは、ユーザーがキーをスキャンしていることを検出して、スキャンされたキー名を読み上げるため、ユーザーは指の位置を知ることができます。 また、キーボード指向のアクセシビリティに関する概念の一部は、キーボードをまったく使わない関連の支援技術の動作に割り当てることもできます。 たとえば、SIP が Tab キーを含まない場合でも、ナレーターは、Tab キーを押した場合と同等のタッチ ジェスチャをサポートします。そのため、UI のコントロールを使って便利なタブ オーダーを設定することが、重要なアクセシビリティの原則であることに変わりはありません。 複雑なコントロール内で部品を移動するために使われる方向キーも、ナレーターのタッチ ジェスチャでサポートされます。 テキスト入力用ではないコントロールにフォーカスが移ると、ナレーターはそのコントロールの操作を呼び出すジェスチャをサポートします。

SIP には Ctrl キーや Alt キーがないため、キーボード ショートカットは通常、Windows Phone アプリには関係ありません。

<span id="related_topics"/>

## <a name="related-topics"></a>関連トピック  
* [アクセシビリティ](accessibility.md)
* [キーボード操作](https://msdn.microsoft.com/library/windows/apps/Mt185607)
* [タッチ キーボードのサンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/TouchKeyboard)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)

