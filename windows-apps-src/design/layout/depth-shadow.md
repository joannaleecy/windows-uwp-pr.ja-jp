---
author: knicholasa
description: Z 深度、または相対パスは深さを効率的かつ自然には、ユーザーが専念を支援するアプリに組み込む方法は 2 つの深さ、およびシャドウします。
title: Z 深さと UWP アプリのシャドウ
template: detail.hbs
ms.author: nichola
ms.date: 04/19/2019
ms.topic: article
ms.custom: 19H1
keywords: windows 10, uwp
pm-contact: chigy
ms.localizationpriority: medium
ms.openlocfilehash: ab49f13d3938e55750ce523f9e0d4ae241304763
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63817713"
---
# <a name="z-depth-and-shadow"></a>Z 深度とシャドウ

![灰色の 4 つの四角形を示す gif は積み上げ斜めの上に他のいずれかです。 Shadows 表示/非表示にできるように、gif、アニメーション化されます。](images/elevation-shadow/shadow.gif)

UI に要素の階層構造を作成する UI を簡単にスキャンしに集中する重要なことを伝達します。 昇格の転送、UI の要素を選択することを act がソフトウェアで、このような階層を実現するためによく使用されます。 この記事では、z 深さとシャドウを使用して UWP アプリで昇格を作成する方法について説明します。

Z 深さは、z 軸に沿って 2 つの画面間の距離を示すために 3D アプリ作成者の間で使用される用語です。 オブジェクトは、ビューアーに、閉じる方法を示しています。 X に同様の概念を考えて/y 座標、z 方向の。

## <a name="why-use-z-depth"></a>Z 深さを使用する理由

現実の世界では、私たちに近いオブジェクトに集中する傾向があります。 この空間本能デジタル ui にも適用できます。 たとえば、ユーザーに近い要素を移行する場合、ユーザーは本能に集中して要素。 移動 UI 要素により近い z 軸で、ユーザー、アプリで、タスクを効率的かつ自然に完了を支援する、オブジェクト間のビジュアルの階層を確立できます。

## <a name="what-is-shadow"></a>シャドウとは何ですか。

シャドウは、ユーザーの昇格を認識する方法の 1 つです。 管理者特権でのオブジェクトの上のライトは、次の画面で影を作成します。 オブジェクトが大きいほどより大きなおよび柔軟性の高い、シャドウになります。 管理者特権でのオブジェクトの UI には、影ができる必要はありませんが、昇格時の外観を作成できます。

UWP アプリでは、見た目のではなく、意図的な方法で影を使用してください。 多すぎるの影を使用して、低下またはユーザーを集中する影のことを排除します。

標準のコントロールを使用する場合、UI に ThemeShadow 影を自動的に組み込まれる予定です。 ただし、手動で追加できます影の UI に、ThemeShadow または DropShadow Api を使用しています。 

## <a name="themeshadow"></a>ThemeShadow

型を描画するために任意の XAML 要素に適用できる ThemeShadow では、適切にに基づいて x、y、z 座標をシャドウします。 ThemeShadow が他の環境の仕様についても自動的に調整されます。

- ライティング、ユーザーのテーマ、アプリの環境、およびシェルの変更に適応します。
- 要素の z 深さに基づいて自動的に影を適用します。 
- 同期を保つ要素に移動し、昇格を変更します。
- 全体とアプリケーション間で一貫性のあるシャドウを保持します。

次に示します、MenuFlyout で ThemeShadow がどのように実装されています。 MenuFlyout は、エクスペリエンスをメイン画面が 32px に昇格され、各追加のカスケード メニューが開かれた +-8 px から開く メニューの上に組み込まれています。

![3 つのオープンな入れ子になったメニューで、MenuFlyout に適用される ThemeShadow のスクリーン ショット。 最初のメニューは、管理者特権で 32px とバック グラウンドで個別の影の外に出ているなど、前のメニューから表示されたそれに続く各メニューが管理者特権で-8 px 以上。](images/elevation-shadow/themeshadow-menuflyout.png)

### <a name="themeshadow-in-common-controls"></a>ThemeShadow を共通の制御します。

次の一般的なコントロールは、特に明記しない限り、32px 深さからシャドウをキャストするのに ThemeShadow を自動的に使用されます。

- [コンテキスト メニュー](../controls-and-patterns/menus.md)、[コマンド バー](../controls-and-patterns/app-bars.md)、[コマンド バーのフライアウト](../controls-and-patterns/command-bar-flyout.md)、[メニュー バー](../controls-and-patterns/menus.md#create-a-menu-bar)
- [ダイアログとフライアウト](../controls-and-patterns/dialogs.md)(64px に ダイアログ ボックス)
- [NavigationView](../controls-and-patterns/navigationview.md)
- [コンボ ボックス](../controls-and-patterns/combo-box.md)、 [DropDownButton、SplitButton、ToggleSplitButton](../controls-and-patterns/buttons.md)
- [TeachingTip](../controls-and-patterns/dialogs-and-flyouts/teaching-tip.md)
- [AutoSuggestBox](../controls-and-patterns/auto-suggest-box.md) 
- [予定表/日付/時刻の選択](../controls-and-patterns/date-and-time.md)
- [ツールヒント](../controls-and-patterns/tooltips.md)(16 px)
- [メディアの輸送コントロール](../controls-and-patterns/media-playback.md#media-transport-controls)、 [InkToolbar](../controls-and-patterns/inking-controls.md)
- [アニメーションの結び付け](../motion/connected-animation.md)

注:フライアウトは ThemeShadow Windows 10 のバージョンが 1903 または最新の SDK に対してコンパイルされるときにのみ適用されます。

### <a name="themeshadow-in-popups"></a>ポップアップで ThemeShadow

アプリの UI ポップアップを使用するシナリオのユーザーの通知とクイック アクション必要がある場合があります。 これらは、シャドウをアプリの UI で階層を作成するために使用する必要がありますとの優れた例です。

ThemeShadow は影の任意の XAML 要素に適用すると自動的にキャスト、[ポップアップ](/uwp/api/windows.ui.xaml.controls.primitives.popup)します。 その下にあるその他のオープンのポップアップの背後にあるアプリのバック グラウンドのコンテンツにシャドウ、キャストされます。

ポップアップを持つ ThemeShadow を使用する、 `Shadow` ThemeShadow を XAML 要素に適用するプロパティ。 次に、昇格要素、その背後にあるその他の要素からなどの z コンポーネントを使用して、`Translation`プロパティ。
ほとんどのポップアップ UI では、アプリのバック グラウンドのコンテンツを基準とした推奨される既定の昇格は 32 有効ピクセルです。

この例は、アプリのバック グラウンド コンテンツとその背後にあるその他のすべてのポップアップに影を落とすのポップアップで、四角形に示します。

```xaml
<Popup>
    <Rectangle x:Name="PopupRectangle" Fill="Lavender" Height="48" Width="96">
        <Rectangle.Shadow>
            <ThemeShadow />
        </Rectangle.Shadow>
    </Rectangle>
</Popup>
```

```csharp
// Elevate the rectangle by 32px
PopupRectangle.Translation += new Vector3(0, 0, 32);
```

![シャドウが付いた長方形 1 つポップアップします。](images/elevation-shadow/PopupRectangle.png)

### <a name="disabling-default-themeshadow-on-custom-flyout-controls"></a>既定値を無効にするカスタム フライアウトで ThemeShadow 制御します。

コントロールがに基づいて[フライアウト](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.flyout)、 [DatePickerFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.datepickerflyout)、 [MenuFlyout](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.menuflyout)または[TimePickerFlyout](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.timepickerflyout)自動的にキャストする ThemeShadow を使用します。シャドウします。

設定を無効にすることができますし、コントロールのコンテンツで正しい既定シャドウと異なる場合は、 [IsDefaultShadowEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.flyoutpresenter.isdefaultshadowenabled)プロパティを`false`に関連付けられている FlyoutPresenter:

```xaml
<Flyout>
    <Flyout.FlyoutPresenterStyle>
        <Style TargetType="FlyoutPresenter">
            <Setter Property="IsDefaultShadowEnabled" Value="False" />
        </Style>
    </Flyout.FlyoutPresenterStyle>
</Flyout>
```

### <a name="themeshadow-in-other-elements"></a>その他の要素で ThemeShadow

一般にシャドウの使用について慎重に検討し、意味のあるビジュアル階層が導入されている場合に、その使用を制限することをお勧めします。 ただし、これが必要になるシナリオが高度な場合に任意の UI 要素の影をキャストする方法は提供します。

ポップアップに表示されていないされる XAML 要素の影をキャストするは、他の要素の影を受け取ることができる明示的に指定する必要があります、`ThemeShadow.Receivers`コレクション。 受信側は、ビジュアル ツリー内の魔法の先祖をすることはできません。

この例では、その背後のグリッドに影をキャストする 2 つの四角形を示します。

```xaml
<Grid>
    <Grid.Resources>
        <ThemeShadow x:Name="SharedShadow" />
    </Grid.Resources>

    <Grid x:Name="BackgroundGrid" Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" />

    <Rectangle x:Name="Rectangle1" Height="100" Width="100" Fill="Turquoise" Shadow="{StaticResource SharedShadow}" />

    <Rectangle x:Name="Rectangle2" Height="100" Width="100" Fill="Turquoise" Shadow="{StaticResource SharedShadow}" />
</Grid>
```

```csharp
/// Add BackgroundGrid as a shadow receiver and elevate the casting buttons above it
SharedShadow.Receivers.Add(BackgroundGrid);

Rectangle1.Translation += new Vector3(0, 0, 16);
Rectangle2.Translation += new Vector3(120, 0, 32);
```

![相互、影が両方の横にある 2 つ青緑色四角形。](images/elevation-shadow/SharedShadow.png)

### <a name="performance-best-practices-for-themeshadow"></a>ThemeShadow のパフォーマンスのベスト プラクティス

1. システムは、キャスターと受信者のペアが 5 の制限を設定し、これを超えた場合、シャドウ オフになります。 5 キャスターと受信者のペアのシステムによって適用される制限を引き続き使用します。

2. 最低限必要なカスタム レシーバー要素の数を制限します。

3. 複数のレシーバー要素は、同じ権限の昇格では場合を 1 つの親要素をターゲットにする代わりにそれらを結合してみます。

4. 複数の要素は、同一のレシーバー要素の上に影の同じ型にキャストする場合は、共有リソースとして、シャドウを追加し、再利用します。

## <a name="drop-shadow"></a>ドロップ シャドウ

DropShadow がその環境に自動的に応答しないと、光源を使用しません。 たとえば、実装を参照してください、 [DropShadow クラス](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)します。

## <a name="which-shadow-should-i-use"></a>どのシャドウを使用する必要がありますか。

| プロパティ | ThemeShadow | DropShadow |
| - | - | - | - |
| **SDK の最小値** | Windows 10 のバージョンが 1903 | 14393 |
| **適応性** | 〇 | X |
| **カスタマイズ** | X | 〇 |
| **光源** | 自動 (既定では、グローバルですがアプリごとにオーバーライドできます) | なし |
| **3D 環境でサポートされています** | 〇 | X |

- シャドウの目的は、単純な視覚的処理ではなく、意味のある階層を提供することに注意してください。
- 一般に、その環境に自動的に対応する、ThemeShadow の使用をお勧めします。
- パフォーマンスの問題の影の数を制限するか、その他のビジュアルの処理方法を使用して、DropShadow を使用します。
- ビジュアルの階層を実現するシナリオが高度な場合は、その他の視覚的処理 (例: 色) を使用することを検討します。 シャドウが必要な場合は、DropShadow を使用します。
