---
author: QuinnRadich
Description: Lets the user set a value in a given range.
title: スライダー
ms.assetid: 7EC7EA33-BE7E-4FD5-B205-B8FA7B729ACC
label: Sliders
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: ksulliv
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 2b6512782d5fa3423dcfee98c98223d77995deeb
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7150398"
---
# <a name="sliders"></a>スライダー

 

スライダーはユーザーがトラックに沿って thumb コントロールを動かすことで値の範囲から選択できるようにするコントロールです。

> **重要な API**: [Slider クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx)、[Value プロパティ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx)、[ValueChanged イベント](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx)

![スライダー コントロール](images/controls/slider.png)


## <a name="is-this-the-right-control"></a>適切なコントロールの選択

定義された連続的な値 (音量や明るさなど) または個別の値の範囲 (画面解像度の設定など) をユーザーが設定できるようにする場合に、スライダーを使います。

スライダーは、ユーザーが値を数値でなく相対的な量であると考えている場合に適しています。 たとえば、ユーザーはオーディオの音量を数値の 2 や 5 ではなく、低や中に設定しようと考えます。

二者択一の設定には、スライダーは使いません。 代わりに[トグル スイッチ](toggles.md)を使います。

スライダーを使うかどうかを決める際には、他にも次のような点を考慮します。

-   **設定が相対的な量のように見えるか?** 見えない場合は、[ラジオ ボタン](radio-button.md)または[リスト ボックス](lists.md)を使います。
-   **設定は正確な既知の数値か?** その場合は、数値[テキスト ボックス](text-box.md)を使います。
-   **設定の変更による効果をすぐに確認できると、ユーザーにとって便利か?** 便利である場合は、スライダーを使います。 たとえば、色合い、鮮やかさ、明度の値を変更した場合の効果をすぐに確認できると、ユーザーは色をより簡単に選べるようになります。
-   **設定に 4 つ以上の値の範囲があるか?** ない場合は、[ラジオ ボタン](radio-button.md)を使います。
-   **ユーザーが値を変えられるか?** スライダーは、ユーザーの操作用です。 ユーザーが値を変えられない場合は、代わりに読み取り専用のテキストを使います。

スライダーと数値テキスト ボックスのどちらを使うかを決める際に、次の場合には数値テキスト ボックスを使います。

-   画面領域が狭い。
-   ユーザーがキーボードを使おうとする可能性が高い。

次の場合にはスライダーを使います。

-   ユーザーにとって、すぐに結果がわかると便利。

## <a name="examples"></a>例

<table>
<th align="left">XAML コントロール ギャラリー<th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Slider">アプリを開き、Slider の動作を確認</a>してください。</p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">ソース コード (GitHub) を入手する</a></li>
    </ul>
</td>
</tr>
</table>

Windows Phone の音量を制御するためのスライダー。

![Windows Phone の音量を制御するためのスライダー](images/control-examples/slider-phone.png)

Windows 画面設定でテキスト サイズを変更するためのスライダー。

![Windows 画面設定でテキスト サイズを変更するためのスライダー](images/control-examples/slider-display-settings.png)

## <a name="create-a-slider"></a>スライダーの作成

XAML でスライダーを作成する方法を次に示します。

```xaml
<Slider x:Name="volumeSlider" Header="Volume" Width="200"
        ValueChanged="Slider_ValueChanged"/>
```

コードでスライダーを作成する方法を次に示します。

```csharp
Slider volumeSlider = new Slider();
volumeSlider.Header = "Volume";
volumeSlider.Width = 200;
volumeSlider.ValueChanged += Slider_ValueChanged;

// Add the slider to a parent container in the visual tree.
stackPanel1.Children.Add(volumeSlider);
```

[Value](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx) プロパティからスライダーの値を取得および設定します。 値の変更に応答するには、Value プロパティにバインドするデータ バインディングを使うか、[ValueChanged](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx) イベントを処理します。

```csharp
private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
{
    Slider slider = sender as Slider;
    if (slider != null)
    {
        media.Volume = slider.Value;
    }
}
```

## <a name="recommendations"></a>推奨事項

-   コントロールのサイズは、ユーザーが値を簡単に設定できる大きさにします。 個別の値を設定する場合は、ユーザーがマウスを使って値を簡単に選べるようにします。 スライダーのエンドポイントが、常にビューの境界内にあることを確認します。
-   ユーザーが選んでいるときまたは選んだ後で、すぐに結果が確認できるようにします (それが実際的な場合)。 たとえば、Windows のボリューム コントロールは、選ばれたオーディオ音量を示すためにビープ音を鳴らします。
-   値の範囲を示すためにラベルを使います。 例外: スライダーが垂直方向で、上部のラベルが最大、高、多などの場合、下部の意味は明らかであるため、ラベルを省略できます。
-   スライダーを無効にする場合は、関連するすべてのラベルまたはフィードバックの視覚効果も無効にします。
-   スライダーのフロー方向や向きを設定するときには、テキストの方向を考慮してください。 言語によって、左から右に書く場合と、右から左に書く場合があります。
-   スライダーは、進行状況インジケーターとしては使いません。
-   スライダーのつまみは、既定のサイズのままにします。
-   値の範囲が広く、ユーザーが選ぶのは範囲内のいくつかの代表的な値であることがほとんどの場合は、連続的なスライダーを作成しません。 代わりに、それらの値だけを、許可される間隔として使います。 たとえば、時間の最大値は 1 か月であっても、ユーザーが 1 分、1 時間、1 日、1 か月のいずれかを選ぶ場合は、4 つの間隔位置だけのスライダーを作成します。

## <a name="additional-usage-guidance"></a>その他の使い方のガイダンス

### <a name="choosing-the-right-layout-horizontal-or-vertical"></a>適切なレイアウトの選択: 水平または垂直

スライダーは、水平方向または垂直方向に向きを設定できます。 次のガイドラインを使って、使うレイアウトを決めます。

-   自然な方向を使います。 たとえば、スライダーが現実世界の値を表していて、通常は垂直方向に表示される場合 (気温など) は、垂直方向にします。
-   ビデオ アプリのように、メディア内をシークするためにコントロールが使われる場合は、水平方向にします。
-   1 つの方向 (水平または垂直) にパンするページでスライダーを使う場合は、パンの方向とは異なる方向をスライダーに使います。 そうしないと、ユーザーはページをパンしようとしてスライダーをスワイプし、誤って値を変えてしまう場合があります。
-   使用する方向がまだ決まらない場合は、ページ レイアウトに適した方を使います。

### <a name="range-direction"></a>範囲方向

範囲方向とは、現在の値から最大値へスライダーを動かす方向のことです。

-   垂直方向スライダーでは、読みの方向に関係なく、最大値をスライダーの上部に配置します。 たとえば、音量スライダーでは、最大の音量設定を常にスライダーの上部に配置します。 他の種類の値 (曜日など) では、ページの読みの方向に従います。
-   水平方向のスタイルでは、ページ レイアウトが左から右への場合は、低い方の値をスライダーの左側に配置します。ページ レイアウトが右から左への場合は、右側に配置します。
-   前のガイドラインの 1 つの例外は、メディア シーク バーです。このバーでは、低い方の値を常にスライダーの左側に配置します。

### <a name="steps-and-tick-marks"></a>間隔と目盛り

-   スライダーで最小値から最大値までの任意の値を許可するのではない場合は、間隔位置を使います。たとえば、購入する映画のチケットの数を指定するためにスライダーを使う場合、浮動小数点値は許可しません。 間隔の値を 1 にします。
-   間隔 (スナップ位置とも言います) を指定する場合、最後のステップがスライダーの最大値に揃うようにします。
-   主な、または重要な値の位置をユーザーに示す場合は、目盛りを使います。 たとえば、ズームを制御するスライダーでは、50%、100%、200% の目盛りを設定します。
-   設定のおおよその値をユーザーが知る必要がある場合に、目盛りを表示します。
-   選択した設定の正確な値を、コントロールを操作しなくてもユーザーが確認できるようにするには、目盛りと値ラベルを表示します。 または、値ヒントを使って、正確な値が見られるようにします。
-   間隔位置が明白でない場合は、常に目盛りを表示します。 たとえば、スライダーの幅が 200 ピクセルで、200 のスナップ位置がある場合は、ユーザーはスナップの動作に気付かないので、目盛りを非表示にできます。 しかし、スナップ位置が 10 個しかない場合は、目盛りを表示します。

### <a name="labels"></a>ラベル

-   **スライダー ラベル**

    スライダー ラベルは、スライダーの使用目的を示します。

    -   ラベルを使うときは末尾に句点を付けません (これはすべてのコントロール ラベルでの規則です)。
    -   スライダーのあるフォームで、ほとんどのラベルがコントロールの上にある場合は、ラベルをスライダーの上に配置します。
    -   スライダーのあるフォームで、ほとんどのラベルがコントロールの横にある場合は、ラベルをスライダーの横に配置します。
    -   ユーザーがスライダーにタッチするときに、指でラベルが見えなくなる場合があるので、ラベルをスライダーの下には配置しません。
-   **範囲ラベル**

    範囲 (容量) ラベルは、スライダーの最小値と最大値を示します。

    -   垂直方向であることによって明白である場合以外は、スライダーの範囲の両端をラベルに表示します。
    -   各ラベルは、できれば 1 ワードだけにします。
    -   末尾に句点を付けません。
    -   これらのラベルは、説明的で対比的なものにします。 例: 最大/最小、多/少、低/高、小/大
-   **値ラベル**

    値ラベルは、スライダーの現在の値を表示します。

    -   値ラベルが必要な場合は、スライダーの下に表示します。
    -   テキストをコントロールに対して中央に配置し、単位 (ピクセルなど) を付記します。
    -   スライダーのつまみはスクラブ中に隠れるため、ラベルや他の視覚効果で現在の値を表示することをお勧めします。 スライダー設定のテキスト サイズは、スライダー以外の適切なサイズのサンプル テキストに連動させることができます。

### <a name="appearance-and-interaction"></a>外観と操作

スライダーはトラックとつまみで構成されます。 トラックは入力できる値の範囲を表すバーです (オプションでさまざまなスタイルの目盛りを表示できます)。 つまみは、ユーザーがトラックをタップするか、トラックを前後にスクラブして位置を調整できるセレクターです。

スライダーには大きなタッチ ターゲットが設定されています。 タッチのアクセシビリティを維持するには、スライダーを表示の端から十分に離して配置する必要があります。

カスタム スライダーを設計する際は、余分な要素をできるだけなくし、ユーザーに必要なすべての情報を示す方法を検討してください。 ユーザーが設定を理解できるように単位を表示する必要がある場合は、値ラベルを使います。これらの値を視覚的に示す方法を工夫してください。 たとえば、音量を調整するスライダーでは、スライダーの最小の端に音波のないスピーカーのグラフィック、最大の端に音波のあるスピーカーのグラフィックを表示できます。

## <a name="get-the-sample-code"></a>サンプル コードを入手する

- [XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形ですべての XAML コントロールを参照できます。

## <a name="related-topics"></a>関連トピック
- [トグル スイッチ](toggles.md)
- [Slider クラス](https://msdn.microsoft.com/library/windows/apps/br209614)
