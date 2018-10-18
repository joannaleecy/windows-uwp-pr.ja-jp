---
author: serenaz
description: Z 深度または相対値、シャドウがより自然かつ効率的にユーザーが専念をできるように、アプリに奥行きを組み込むの 2 つの方法です。
title: Z 深度と UWP アプリ用のシャドウ
template: detail.hbs
ms.author: sezhen
ms.date: 02/12/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: chigy
design-contact: balrayit
ms.localizationpriority: medium
ms.openlocfilehash: a1433b131b994ee2b1323909bc7c195e00f43cde
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2018
ms.locfileid: "4969050"
---
# <a name="z-depth-and-shadow"></a>Z 深度とシャドウ

![深度の場合は true。](images/elevation-shadow/depth.svg)

Fluent の深度システムは、配置、細字、3 D などの物理的な概念を使用し、デジタルの UI にシャドウを認識するためより階層化された物理環境でします。 Z 深度または相対値、深度とシャドウは 2 つの方法で UWP アプリに奥行きを組み込みます。

## <a name="what-is-z-depth"></a>Z 深度とは何ですか。

Z 深さは 2 つのサーフェスの z 軸に沿って間の距離と、オブジェクトは、ビューアーを閉じる方法を示しています。

![z 深度](images/elevation-shadow/elevation.svg)

### <a name="why-use-z-depth"></a>Z 深度を使用する理由

現実の世界では、マイクロソフトに近いオブジェクトに焦点を傾向があります。 この空間本能デジタル UI に適用可能です。 たとえば、ユーザーに近い要素を表示する場合、ユーザーは本能重点を置きます要素。 移動 UI 要素に近い z 軸で、アプリでタスクを完了自然かつ効率的にユーザーを支援のオブジェクト間で視覚的な階層を確立することができます。 

![コンテンツのメニューで z 深度](images/elevation-shadow/whyelevation.svg)

他を提供するわかりやすい視覚的な階層、z 深度もを作成するエクスペリエンスを実現シームレスに 2D から 3D 環境では、すべてのデバイスとフォーム ファクターでアプリをスケーリングします。 

![2d に 3d での z 深度](images/elevation-shadow/elevation-2d3d.svg)

### <a name="how-is-z-depth-perceived"></a>Z 深度の認識されるかどうか。

現実の世界の奥行きを認識する方法に基づきでは、デジタル UI に近接通信を表示するために使用する方法はいくつか次に示します。

- **スケール**同じサイズの近くのオブジェクトよりも小さい遠くのオブジェクトが表示されます。 メソッドは、このため、通常お勧めできませんを 2D 空間に効果的に説明するは困難です。 ただし、2 D 内のユーザーに近い場所に移動するオブジェクトの有効なシミュレーションを作成するスケールと[シャドウ](#what-is-shadow)を使用することができます。

    ![スケールを近接通信](images/elevation-shadow/elevation-scale.svg)

- **大気**オブジェクトには、遠くと「煙の充満」オーバーレイまたはその他の大気効果に焦点を表示できます。

    ![大気に近接通信](images/elevation-shadow/elevation-atmosphere.svg)

- **モーション**相対速度は、近接通信を示すために使用できます: 近くのオブジェクトをバック グラウンドの高い遠くのオブジェクトよりもすばやく移動します。 この効果を実装する方法については、[視差効果](../motion/parallax.md)を参照してください。

    ![モーションを使って近接通信](images/elevation-shadow/elevation-motion.svg)

### <a name="recommendations-for-z-depth"></a>Z 深度の推奨事項

チェック ボックスをオフに視覚的なフォーカスを提供する管理者特権の平面の数を減らします。 ほとんどのシナリオでは、2 つの平面の十分な: フォア グラウンドの項目 (high の近接通信) とバック グラウンド項目 (低近接通信) のいずれか。 重ならない複数の管理者特権での項目がある場合は、グループ化を平面の数を減らすために同じ平面 (つまり、フォア グラウンド)。

![アプリ内の z 深度](images/elevation-shadow/app-depth.svg)

## <a name="what-is-shadow"></a>シャドウとは何ですか。

![shadow](images/elevation-shadow/shadow.svg)

シャドウは、昇格を認識する方法です。 管理者特権でのオブジェクトの上のライトがある場合は、次のサーフェスが影がします。 オブジェクトが大きいほどより大きなおよび柔らかい影になります。 管理者特権でのオブジェクトは、シャドウを持つ必要はありませんが、シャドウは昇格を示すために注意してください。

シャドウは、UWP アプリでは、意図的なきれいいないする必要があります。 シャドウは、フォーカスと生産性を損ねます場合、は、シャドウの使用を制限します。

ThemeShadow または DropShadow Api のいずれかでは、シャドウを使用できます。

## <a name="themeshadow"></a>ThemeShadow

シャドウ適切にに基づいて x、y、z 座標する ThemeShadow の種類を描画する任意の XAML 要素に適用できます。 ThemeShadow は、その他の環境の仕様にも自動的に調整します。

- 照明、ユーザーのテーマ、アプリの環境、シェルの変更に適応します。
- シャドウ要素昇格に基づいて自動的にを処理します。
- 要素のによって同期が維持に移動し、昇格を変更します。
- 全体にわたってとアプリケーション間で一貫性のあるシャドウを保持します。

次に、淡色テーマと濃色テーマのさまざまな高度に ThemeShadow の例を示します。

![淡色テーマとスマート シャドウ](images/elevation-shadow/smartshadow-light.svg)

![濃色テーマのスマート シャドウ](images/elevation-shadow/smartshadow-dark.svg)

### <a name="themeshadow-in-common-controls"></a>ThemeShadow を共通の制御します。

自動的に次の一般的なコントロールは、ThemeShadow を使用して、シャドウを生じさせるのには。

- [ダイアログとポップアップ](../controls-and-patterns/dialogs.md)
- [NavigationView](../controls-and-patterns/navigationview.md)
- [メディア トランスポート コントロール](../controls-and-patterns/media-playback.md)
- [ショートカット メニュー](../controls-and-patterns/menus.md)
- [コマンド バー](../controls-and-patterns/app-bars.md)
- [自動提案](../controls-and-patterns/auto-suggest-box.md)、[コンボ ボックス](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.ComboBox)、[カレンダー、日付/時刻の選択](../controls-and-patterns/date-and-time.md)、[ヒント](../controls-and-patterns/tooltips.md)
- [アクセス キー](../input/access-keys.md)

### <a name="themeshadow-in-popups"></a>ポップアップで ThemeShadow

ThemeShadow では、シャドウの[ポップアップ](/uwp/api/windows.ui.xaml.controls.primitives.popup)内の任意の XAML 要素に適用されると自動的にキャストします。 下にあるその他のオープンのポップアップの背後にあるアプリのバック グラウンドのコンテンツのシャドウを生じ、されます。

ポップアップを持つ ThemeShadow を使用する、`Shadow`プロパティを XAML 要素に、ThemeShadow を適用します。 次に、昇格要素、背後にある他の要素からなどの z コンポーネントを使用して、`Translation`プロパティ。
ほとんどのポップアップ UI では、アプリのバック グラウンドのコンテンツを基準としたことをお勧めの既定の昇格は 32 の有効ピクセルです。

この例は、アプリのバック グラウンド コンテンツと背後にある他のポップアップにシャドウをキャスト ポップアップ内の四角形を示します。

```xaml
<Popup>
    <Rectangle x:Name="PopupRectangle" Fill="White" Height="48" Width="96">
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

![コード例からシャドウ](images/elevation-shadow/smartshadow-example.svg)

### <a name="themeshadow-in-other-elements"></a>その他の要素で ThemeShadow

ポップアップではない XAML 要素からシャドウをキャストするは、その他の要素でシャドウを受け取ることができる明示的に指定する必要があります、`ThemeShadow.Receivers`コレクションです。

この例は、それらの背後にあるグリッドにシャドウを生じさせる 2 つのボタンを示しています。

```xaml
<Grid x:Name="BackgroundGrid" Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.Resources>
        <ThemeShadow x:Name="SharedShadow" />
    </Grid.Resources>

    <Button x:Name="Button1" Content="Button 1" Shadow="{StaticResource SharedShadow}" Margin="10" />

    <Button x:Name="Button2" Content="Button 2" Shadow="{StaticResource SharedShadow}" Margin="120" />
</Grid>
```

```csharp
/// Add BackgroundGrid as a shadow receiver and elevate the casting buttons above it
SharedShadow.Receivers.Add(BackgroundGrid);

Button1.Translation += new Vector3(0, 0, 16);
Button2.Translation += new Vector3(0, 0, 32);
```

### <a name="performance-best-practices-for-themeshadow"></a>ThemeShadow のパフォーマンスのベスト プラクティス

1. 最低限必要なカスタム レシーバー要素の数に制限します。 

2. 複数の受信者要素が同じ昇格に場合は、代わりに、1 つの親要素をターゲットとしてそれらを結合するしてみてください。

3. 複数の要素のキャスト先と同じ種類レシーバーと同じ要素に影の場合は、共有リソースとして、シャドウを追加し、再利用します。

## <a name="drop-shadow"></a>ドロップ シャドウ

DropShadow はその環境への応答が自動的にではなく、光源を使用しません。 たとえば、実装では、 [DropShadow クラス](https://docs.microsoft.com/uwp/api/windows.ui.composition.dropshadow)を参照してください。

## <a name="which-shadow-should-i-use"></a>どのシャドウを使用する必要がありますか。

| プロパティ | ThemeShadow | DropShadow |
| - | - | - | - |
| **Min SDK** | RS5 | 14393 |
| **適応性** | はい | いいえ |
| **カスタマイズ** | いいえ | はい |
| **光源** | 自動 (既定では、グローバル アプリごとに上書きできますが、) | なし |
| **3D 環境でサポートされています。** | はい | いいえ |

- 一般に、その環境に自動的に対応する、ThemeShadow の使用をお勧めします。
- カスタムの影のシナリオが高度な場合より詳細にカスタマイズできる、DropShadow を使用します。
- 下位互換性、DropShadow を使用します。
- パフォーマンスを懸念するには、シャドウ、数を制限するか、DropShadow を使用します。
- True 3d HMDs、ThemeShadow を使用します。 側から、その親 visual から指定されたオフセット DropShadow を描画するため、空間ではフローティング状態などが検索されます。 その一方で、ThemeShadow はレシーバーとして定義されている視覚効果の上にレンダリングされます。
