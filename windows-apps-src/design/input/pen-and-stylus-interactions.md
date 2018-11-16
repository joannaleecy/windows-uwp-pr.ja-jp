---
author: Karl-Bridge-Microsoft
Description: Build Universal Windows Platform (UWP) apps that support custom interactions from pen and stylus devices, including digital ink for natural writing and drawing experiences.
title: UWP アプリでのペン操作と Windows Ink
ms.assetid: 3DA4F2D2-5405-42A1-9ED9-3A87BCD84C43
label: Pen interactions and Windows Ink in UWP apps
template: detail.hbs
keywords: Windows Ink, Windows の手書き入力, DirectInk, InkPresenter, InkCanvas, 手書き認識, ユーザー操作, 入力
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a9a9dd4347cc682f384c2d408d30820acf76ce34
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6855251"
---
# <a name="pen-interactions-and-windows-ink-in-uwp-apps"></a>UWP アプリでのペン操作と Windows Ink

![Surface ペン](images/ink/hero-small.png)  
*Surface ペン* ([Microsoft ストア](https://aka.ms/purchasesurfacepen)で購入できます)。

## <a name="overview"></a>概要

ペン入力向けにユニバーサル Windows プラットフォーム (UWP) アプリを最適化して、標準の [**ポインター デバイス**](https://msdn.microsoft.com/library/windows/apps/br225633) 機能と最良の Windows Ink エクスペリエンスをユーザーに提供します。

> [!NOTE]
> ここでは主に、Windows Ink プラットフォームについて説明します。 ポインター入力処理 (マウス、タッチ、タッチパッドに類似) の概要については、「[ポインター入力の処理](handle-pointer-input.md)」をご覧ください。

| ビデオ |   |
| --- | --- |
| <iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Using-Ink-in-Your-UWP-App/player" width="300" height="200" allowFullScreen frameBorder="0"></iframe> | <iframe src="https://channel9.msdn.com/Events/Ignite/2016/BRK2060/player" width="300" height="200" allowFullScreen frameBorder="0"></iframe> |
| *Using ink in your UWP app (UWP アプリでのインクの使用)* | *Windows ペンとインクを使用して、魅力的な enterpriseapps をビルドするには* |

Windows Ink プラットフォームでペン デバイスを使うと、自然な形でデジタルの手書きノート、描画、コメントを作れます。 このプラットフォームは、デジタイザー入力のインク データとしてのキャプチャ、インク データの生成、インク データの管理、出力デバイスのインク ストロークとしてのインク データのレンダリング、手書き認識によるインクからテキストへの変換をサポートします。

アプリでは、ユーザーが筆記や描画を行うときの基本的なペンの位置と動きのキャプチャに加えて、ストロークの筆圧の変化を追跡および収集することもできます。 この情報が、ペン先の形状、サイズ、回転や、インクの色、用途 (プレーン インク、消去、強調表示、選択) などの設定と組み合わされて、紙の上でペン、鉛筆、ブラシを使っているときに近いユーザー エクスペリエンスが実現されます。

> [!NOTE]
> タッチ デジタイザーやマウス デバイスなど、他のポインター ベース デバイスからの手描き入力をアプリでサポートすることもできます。 

インク プラットフォームは非常に柔軟で、 必要に応じてさまざまなレベルの機能をサポートできるようになっています。

Windows Ink UX のガイドラインについては、「[手描き入力コントロール](../controls-and-patterns/inking-controls.md)」をご覧ください。

## <a name="components-of-the-windows-ink-platform"></a>Windows Ink プラットフォームのコンポーネント

| コンポーネント | 説明 |
| --- | --- |
| [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) | XAMLUI プラットフォーム コントロール、既定では、受信し、ペンからのすべての入力をインク ストロークか消去ストロークとして表示します。<br/>InkCanvas の使用方法について詳しくは、「[Windows インク ストロークのテキスト認識](convert-ink-to-text.md)」と「[Windows Ink ストローク データの保存と取得](save-and-load-ink.md)」をご覧ください。 |
| [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) | [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと共にインスタンス化される分離コード オブジェクトです ([**InkCanvas.InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) プロパティによって公開されます)。 **InkCanvas** によって公開される既定の手描き入力機能のすべてと、追加のカスタマイズや個人用設定のための包括的な API のセットを提供します。<br/>InkPresenter の使用方法について詳しくは、「[Windows Ink ストロークのテキスト認識](convert-ink-to-text.md)」と「[Windows Ink ストローク データの保存と取得](save-and-load-ink.md)」をご覧ください。 |
| [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx) | 関連付けられた[**InkCanvas**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)のインク関連機能をアクティブ化するボタンのカスタマイズと拡張可能なコレクションを含む XAMLUI プラットフォーム コントロールです。<br/>InkToolbar の使用方法について詳しくは、「[InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手描き入力アプリに追加する](ink-toolbar.md)」をご覧ください。 |
| [**IInkD2DRenderer**](https://msdn.microsoft.com/library/mt147263) | 既定の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの代わりに、ユニバーサル Windows アプリが指定した Direct2D デバイス コンテキストにインク ストロークをレンダリングできます。 これにより、手描き入力エクスペリエンスの全面的なカスタマイズが実現されます。<br/>詳しくは、「[複雑なインクのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620314)」をご覧ください。 |

## <a name="basic-inking-with-inkcanvas"></a>InkCanvas による基本的な手描き入力

基本的な手描き機能を追加するには、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) UWP プラットフォーム コントロールをアプリの適切なページに配置します。

既定では、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) はペンからの手描き入力のみをサポートしています。 入力は、色と太さの既定の設定 (太さ 2 ピクセルの黒のボールペン) を使ってインク ストロークとしてレンダリングされるか、ストロークの消しゴムとして扱われます (ペンの消しゴムからの入力か、消しゴム ボタンで変更されたペン先からの入力の場合)。

> [!NOTE]
> ペンの消しゴムまたは消しゴム ボタンがない場合は、ペン先からの入力を消去ストロークとして処理するように InkCanvas を構成できます。

次の例では、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) を背景画像にオーバーレイしています。

> [!NOTE]
> InkCanvas の[**高さ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Height)と[**幅**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.frameworkelement.Width)のプロパティは、子要素のサイズを自動的に設定する要素の子である場合を除き、既定では 0 です。 

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink sample"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />            
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

次の一連の画像は、この [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールによってペン入力がどのようにレンダリングされるかを示しています。

| ![空の InkCanvas と背景画像](images/ink_basic_1_small.png) | ![インク ストロークを含む InkCanvas](images/ink_basic_2_small.png) | ![1 つのストロークが消去された InkCanvas](images/ink_basic_3_small.png) |
| --- | --- | ---|
| 空の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) と背景画像。 | インク ストロークを含む [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)。 | ストロークの一部が削除された [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)  (削除が部分ではなく全体にどのように影響するかに注意してください)。 |

[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールでサポートされている手書き入力機能は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) という分離コード オブジェクトによって提供されます。

基本的な手書き入力では [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) のことを気にする必要はありませんが、 [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) の手書き入力動作をカスタマイズしたり構成したりするには、対応する **InkPresenter** オブジェクトにアクセスする必要があります。

## <a name="basic-customization-with-inkpresenter"></a>InkPresenter による基本的なカスタマイズ

[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) オブジェクトは、各 [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールと共にインスタンス化されます。

> [!NOTE]
> [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) を直接インスタンス化することはできません。 代わりに、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) の [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) プロパティを通じてアクセスします。 

[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) には、対応する [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの既定の手書き入力動作のすべてに加えて、ストロークの追加のカスタマイズのための包括的な API のセット、および手描き入力 (標準および変更) の細かい管理を提供します。 たとえば、ストロークのプロパティ、サポートされている入力デバイスの種類、入力をオブジェクトで処理するかアプリに渡して処理するかなどを指定できます。

> [!NOTE]
> 標準のインク入力 (ペン先または消しゴムの先端やボタン) は、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタン、または類似のメカニズムなど) で変更されません。 

既定では、インクはペン入力のみをサポートします。 次の例では、ペンとマウスの両方の入力データをインク ストロークとして解釈するように [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) を構成しています。 [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) へのストロークのレンダリングに使うインク ストロークの最初の属性も設定しています。

マウスとタッチによる手描き入力を有効化するには、[**InkPresenter**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.inking.inkpresenter) の [**InputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkpresenter.InputDeviceTypes) プロパティを、必要な [**CoreInputDeviceTypes**](https://docs.microsoft.com/uwp/api/windows.ui.core.coreinputdevicetypes) 値の組み合わせに設定します。

```csharp
public MainPage()
{
    this.InitializeComponent();

    // Set supported inking device types.
    inkCanvas.InkPresenter.InputDeviceTypes =
        Windows.UI.Core.CoreInputDeviceTypes.Mouse |
        Windows.UI.Core.CoreInputDeviceTypes.Pen;

    // Set initial ink stroke attributes.
    InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
    drawingAttributes.Color = Windows.UI.Colors.Black;
    drawingAttributes.IgnorePressure = false;
    drawingAttributes.FitToCurve = true;
    inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
}
```

インク ストロークの属性は、ユーザー設定やアプリの要件に合わせて動的に設定できます。

次の例では、ユーザーがインクの色を一覧から選べるようにしています。

```xaml
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header"
                   Text="Basic ink customization sample"
                   VerticalAlignment="Center"
                   Style="{ThemeResource HeaderTextBlockStyle}"
                   Margin="10,0,0,0" />
        <TextBlock Text="Color:"
                   Style="{StaticResource SubheaderTextBlockStyle}"
                   VerticalAlignment="Center"
                   Margin="50,0,10,0"/>
        <ComboBox x:Name="PenColor"
                  VerticalAlignment="Center"
                  SelectedIndex="0"
                  SelectionChanged="OnPenColorChanged">
            <ComboBoxItem Content="Black"/>
            <ComboBoxItem Content="Red"/>
        </ComboBox>
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

ユーザーが色を選択したら、その変更を処理して、それに合わせてインク ストロークの属性を更新します。

```csharp
// Update ink stroke color for new strokes.
private void OnPenColorChanged(object sender, SelectionChangedEventArgs e)
{
    if (inkCanvas != null)
    {
        InkDrawingAttributes drawingAttributes =
            inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();

        string value = ((ComboBoxItem)PenColor.SelectedItem).Content.ToString();

        switch (value)
        {
            case "Black":
                drawingAttributes.Color = Windows.UI.Colors.Black;
                break;
            case "Red":
                drawingAttributes.Color = Windows.UI.Colors.Red;
                break;
            default:
                drawingAttributes.Color = Windows.UI.Colors.Black;
                break;
        };

        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
    }
}
```

次の画像は、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によるペン入力の処理とカスタマイズがどのように行われるかを示しています。

| ![既定の黒のインク ストロークを含む InkCanvas](images/ink-basic-custom-1-small.png) | ![ユーザーが選択した赤のインク ストロークを含む InkCanvas](images/ink-basic-custom-2-small.png) |
| --- | --- |
| 既定の黒のインク ストロークを含む [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)。 | ユーザーが選択した赤のインク ストロークを含む [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535)。 | 

手書き入力と消去以外の機能 (ストロークの選択など) を提供するには、アプリで処理するために [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) では未処理のままパススルーする入力をアプリで識別する必要があります。

## <a name="pass-through-input-for-advanced-processing"></a>高度な処理のための入力のパススルー

既定では、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によって、すべての入力がインク ストロークまたは消去ストロークとして処理されます。こうした入力には、セカンダリ ハードウェア アフォーダンス (ペン バレル ボタン、マウスの右ボタンなど) によって変更された入力も含まれます。 ただし、ユーザーは通常、これらのセカンダリ アフォーダンスを使うときに、追加機能や動作の変更を期待します。

場合によっては、アプリの UI でユーザーが選択した内容に基づいて、セカンダリ アフォーダンス (通常はペン先に関連付けられていない機能) を持たないペンのための追加機能、その他の入力デバイスの種類、または変更された動作を公開することも必要になります。

そのような場合のために、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) は、特定の入力を処理しないように構成することができます。 この未処理の入力は、アプリにパススルーされて処理されます。

### <a name="example---use-unprocessed-input-to-implement-stroke-selection"></a>例 - 未処理の入力を使って、ストロークの選択を実装する 

Windows Ink プラットフォームには、変更された入力を必要とする操作のためのサポート (ストロークの選択など) が組み込まれていません。 このような機能をサポートするには、アプリでカスタム ソリューションを提供する必要があります。 

次のコード例は、ペン バレル ボタン (またはマウスの右ボタン) で入力が変更された場合にストロークを選択できるようにする手順を示しています (すべてのコードは MainPage.xaml ファイルと MainPage.xaml.cs ファイルに含まれています)。

1.  まず、MainPage.xaml で UI を設定します。

    ここでは、選択ストロークを描画するためのキャンバスを ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) の下に) 追加しています。 別のレイヤーを使って選択ストロークを描画すると、**InkCanvas** とそのコンテンツに影響を与えずに済みます。

    ![下に選択キャンバスがある空の InkCanvas](images/ink-unprocessed-1-small.png)

      ```xaml
        <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
          <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
          </Grid.RowDefinitions>
          <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header"
              Text="Advanced ink customization sample"
              VerticalAlignment="Center"
              Style="{ThemeResource HeaderTextBlockStyle}"
              Margin="10,0,0,0" />
          </StackPanel>
          <Grid Grid.Row="1">
            <!-- Canvas for displaying selection UI. -->
            <Canvas x:Name="selectionCanvas"/>
            <!-- Inking area -->
            <InkCanvas x:Name="inkCanvas"/>
          </Grid>
        </Grid>
      ```

2.  MainPage.xaml.cs で、選択 UI のいくつかの要素への参照を保持するグローバル変数を宣言します。 具体的には、なげなわ選択ストロークと、選択されたストロークを強調表示する境界の四角形への参照を保持します。

      ```csharp
        // Stroke selection tool.
        private Polyline lasso;
        // Stroke selection area.
        private Rect boundingRect;
      ```

3.  次に、ペンとマウスの両方の入力データをインク ストロークとして解釈するように [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) を構成し、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) へのストロークのレンダリングに使うインク ストロークの最初の属性をいくつか設定します。

    ここで最も重要なのは、[InkPresenter](https://msdn.microsoft.com/library/windows/apps/dn899081) の [**InputProcessingConfiguration**](https://msdn.microsoft.com/library/windows/apps/dn948764) プロパティを使って、変更された入力がアプリで処理されるように指定することです。 **InputProcessingConfiguration.RightDragAction** に [**InkInputRightDragAction.LeaveUnprocessed**](https://msdn.microsoft.com/library/windows/apps/dn948760) という値を割り当てて、変更された入力を指定します。 この値が設定されると、[InkPresenter](https://msdn.microsoft.com/library/windows/apps/dn899081) によって [InkUnprocessedInput](https://docs.microsoft.com/uwp/api/windows.ui.input.inking.inkunprocessedinput) クラス (ユーザーが処理できるポインター イベントのセット) にパススルーされます。

    [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってパススルーされる [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn914712)、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn914711)、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn914713) の各未処理イベントのリスナーが割り当てられます。 選択機能はすべてこれらのイベントのハンドラーに実装します。

    最後に、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) の [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702) イベントと [**StrokesErased**](https://msdn.microsoft.com/library/windows/apps/dn948767) イベントのリスナーを割り当てます。 これらのイベントのハンドラーを使って、新しいストロークが開始された場合や既にあるストロークが消去された場合に選択 UI をクリーンアップします。

    ![既定の黒のインク ストロークを含む InkCanvas](images/ink-unprocessed-2-small.png)

      ```csharp
        public MainPage()
        {
          this.InitializeComponent();

          // Set supported inking device types.
          inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

          // Set initial ink stroke attributes.
          InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
          drawingAttributes.Color = Windows.UI.Colors.Black;
          drawingAttributes.IgnorePressure = false;
          drawingAttributes.FitToCurve = true;
          inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

          // By default, the InkPresenter processes input modified by
          // a secondary affordance (pen barrel button, right mouse
          // button, or similar) as ink.
          // To pass through modified input to the app for custom processing
          // on the app UI thread instead of the background ink thread, set
          // InputProcessingConfiguration.RightDragAction to LeaveUnprocessed.
          inkCanvas.InkPresenter.InputProcessingConfiguration.RightDragAction =
              InkInputRightDragAction.LeaveUnprocessed;

          // Listen for unprocessed pointer events from modified input.
          // The input is used to provide selection functionality.
          inkCanvas.InkPresenter.UnprocessedInput.PointerPressed +=
              UnprocessedInput_PointerPressed;
          inkCanvas.InkPresenter.UnprocessedInput.PointerMoved +=
              UnprocessedInput_PointerMoved;
          inkCanvas.InkPresenter.UnprocessedInput.PointerReleased +=
              UnprocessedInput_PointerReleased;

          // Listen for new ink or erase strokes to clean up selection UI.
          inkCanvas.InkPresenter.StrokeInput.StrokeStarted +=
              StrokeInput_StrokeStarted;
          inkCanvas.InkPresenter.StrokesErased +=
              InkPresenter_StrokesErased;
        }
      ```

4.  次に、[**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn899081) によってパススルーされる [**PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn914712)、[**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn914711)、[**PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn914713) の未処理イベントのハンドラーを定義します。

    なげなわストロークと境界の四角形を含むすべての選択機能をこれらのハンドラーに実装します。

    ![なげなわ選択](images/ink-unprocessed-3-small.png)

      ```csharp
        // Handle unprocessed pointer events from modified input.
        // The input is used to provide selection functionality.
        // Selection UI is drawn on a canvas under the InkCanvas.
        private void UnprocessedInput_PointerPressed(
          InkUnprocessedInput sender, PointerEventArgs args)
        {
          // Initialize a selection lasso.
          lasso = new Polyline()
          {
            Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
              StrokeThickness = 1,
              StrokeDashArray = new DoubleCollection() { 5, 2 },
              };

              lasso.Points.Add(args.CurrentPoint.RawPosition);

              selectionCanvas.Children.Add(lasso);
          }

          private void UnprocessedInput_PointerMoved(
            InkUnprocessedInput sender, PointerEventArgs args)
          {
            // Add a point to the lasso Polyline object.
            lasso.Points.Add(args.CurrentPoint.RawPosition);
          }

          private void UnprocessedInput_PointerReleased(
            InkUnprocessedInput sender, PointerEventArgs args)
          {
            // Add the final point to the Polyline object and
            // select strokes within the lasso area.
            // Draw a bounding box on the selection canvas
            // around the selected ink strokes.
            lasso.Points.Add(args.CurrentPoint.RawPosition);

            boundingRect =
              inkCanvas.InkPresenter.StrokeContainer.SelectWithPolyLine(
                lasso.Points);

            DrawBoundingRect();
          }
      ```

5.  PointerReleased イベント ハンドラーの最後の処理として、選択レイヤーのすべてのコンテンツ (なげなわストローク) をクリアして、なげなわの領域で囲まれたインク ストロークの周りに境界の四角形を 1 つ描画します。

    ![選択範囲の境界の四角形](images/ink-unprocessed-4-small.png)

      ```csharp
        // Draw a bounding rectangle, on the selection canvas, encompassing
        // all ink strokes within the lasso area.
        private void DrawBoundingRect()
        {
          // Clear all existing content from the selection canvas.
          selectionCanvas.Children.Clear();

          // Draw a bounding rectangle only if there are ink strokes
          // within the lasso area.
          if (!((boundingRect.Width == 0) ||
            (boundingRect.Height == 0) ||
            boundingRect.IsEmpty))
            {
              var rectangle = new Rectangle()
              {
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                  StrokeThickness = 1,
                  StrokeDashArray = new DoubleCollection() { 5, 2 },
                  Width = boundingRect.Width,
                  Height = boundingRect.Height
              };

              Canvas.SetLeft(rectangle, boundingRect.X);
              Canvas.SetTop(rectangle, boundingRect.Y);

              selectionCanvas.Children.Add(rectangle);
            }
          }
      ```

6.  最後に、InkPresenter の [**StrokeStarted**](https://msdn.microsoft.com/library/windows/apps/dn914702) イベントと [**StrokesErased**](https://msdn.microsoft.com/library/windows/apps/dn948767) イベントのハンドラーを定義します。

    これらは両方とも同じクリーンアップ関数を呼び出します。これにより、新しいストロークが検出されるたびに現在の選択がクリアされます。

      ```csharp
        // Handle new ink or erase strokes to clean up selection UI.
        private void StrokeInput_StrokeStarted(
          InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
        {
          ClearSelection();
        }

        private void InkPresenter_StrokesErased(
          InkPresenter sender, InkStrokesErasedEventArgs args)
        {
          ClearSelection();
        }
      ```

7.  次の例は、新しいストロークが開始された場合や既にあるストロークが消去された場合に選択キャンバスからすべての選択 UI を削除する関数を示しています。

      ```csharp
        // Clean up selection UI.
        private void ClearSelection()
        {
          var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
          foreach (var stroke in strokes)
          {
            stroke.Selected = false;
          }
          ClearDrawnBoundingRect();
         }

        private void ClearDrawnBoundingRect()
        {
          if (selectionCanvas.Children.Any())
          {
            selectionCanvas.Children.Clear();
            boundingRect = Rect.Empty;
          }
        }
      ```

## <a name="custom-ink-rendering"></a>カスタム インク レンダリング

既定では、手書き入力は待機時間が短いバックグラウンド スレッドで処理され、描画と同時にレンダリングが実行中となります ("ウェット" レンダリングが実行されます)。 ストロークが完了すると (ペンまたは指が画面を離れるか、マウスのボタンが離されると)、UI スレッドでストロークが処理されて、[**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) レイヤーへの "ドライ" レンダリングが行われます (アプリケーション コンテンツの上にレンダリングされてウェット インクが置き換えられます)。

ウェット インク ストロークを "カスタム ドライ レンダリング" することによって、この既定の動作を上書きし、手描き入力エクスペリエンスを完全に制御することができます。 ほとんどのアプリケーションでは、通常、既定の動作で十分ですが、場合によっては、カスタム ドライ レンダリングが必要になります。次に例を示します。
- 大きく複雑なインク ストロークのコレクションをより効率的に管理する場合
- 大きなインク キャンバスでより効率的にパンやズームのサポートを行う場合
- Z オーダーを維持しながら、インクや他のオブジェクト (図形やテキストなど) をインターリーブする場合 
- ドライ レンダリングを行い、インクを DirectX 図形に同期的に変換する場合 (たとえば、ラスタライズされ、アプリケーション コンテンツに (個別の **InkCanvas** レイヤーとしてではなく) 統合される直線や図形など)。

カスタム ドライ レンダリングでは、手書き入力を管理して、既定の [**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) コントロールの代わりにユニバーサル Windows アプリの Direct2D デバイス コンテキストにレンダリングするための [**IInkD2DRenderer**](https://msdn.microsoft.com/library/mt147263) オブジェクトが必要です。

[**ActivateCustomDrying**](https://msdn.microsoft.com/library/windows/apps/dn922012) を ([**InkCanvas**](https://msdn.microsoft.com/library/windows/apps/dn858535) が読み込まれる前に) 呼び出すと、[**SurfaceImageSource**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Media.Imaging.SurfaceImageSource) または [**VirtualSurfaceImageSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.virtualsurfaceimagesource) へのインク ストロークのドライ レンダリングの方法をカスタマイズするための [**InkSynchronizer**](https://msdn.microsoft.com/library/windows/apps/dn903979) オブジェクトが作成されます。 

[**SurfaceImageSource**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Media.Imaging.SurfaceImageSource) と [**VirtualSurfaceImageSource**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.imaging.virtualsurfaceimagesource) はどちらも、アプリがアプリケーションのコンテンツに描画し、組み込むための DirectX 共有サーフェスを提供します。ただし VSIS は、効率的なパンやズームのために、画面よりも大きい仮想サーフェスを提供します。 これらのサーフェスの表示更新は XAML の UI スレッドと同期されるため、インクをいずれかにレンダリングしたとき、同時にウェット インクが InkCanvas から取り除かれる場合があります。 

ドライ インクを [SwapChainPanel](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.swapchainpanel) 用にカスタマイズすることもできますが、UI スレッドとの同期は保証されません。インクを SwapChainPanel にレンダリングしたタイミングと、インクが InkCanvas から取り除かれるタイミングの間にずれが生じる可能性があります。

この機能の完全な例については、「[複雑なインクのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620314)」をご覧ください。

> [!NOTE]
> カスタム ドライ レンダリングと [**InkToolbar**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.inktoolbar.aspx)  
> カスタム ドライの実装によって、アプリが [**InkPresenter**](https://msdn.microsoft.com/library/windows/apps/dn922011) の既定のインク レンダリング動作を上書きすると、レンダリングされたインク ストロークが InkToolbar で利用できなくなり、InkToolbar の組み込みの消去コマンドが正常に機能しなくなります。 消去機能を提供するには、すべてのポインター イベントを処理し、ストロークごとにヒット テストを実行すると共に、組み込みの [すべてのインクのデータを消去] コマンドをオーバーライドする必要があります。

## <a name="other-articles-in-this-section"></a>このセクションの他の記事

| トピック | 説明 |
| --- | --- |
| [インク ストロークの認識](convert-ink-to-text.md) | インク ストロークを手書き認識によりテキストに変換したり、カスタム認識により図形に変換したりします。 |
| [インク ストロークの保存と取得](save-and-load-ink.md) | 埋め込みの Ink Serialized Format (ISF) メタデータを使って、インク ストローク データをグラフィックス交換形式 (GIF) ファイルに保存します。 |
| [UWP 手描き入力アプリへの InkToolbar の追加](ink-toolbar.md) | 既定の InkToolbar をユニバーサル Windows プラットフォーム (UWP) 手書き入力アプリに追加し、カスタム ペン ボタンを InkToolbar に追加して、カスタム ペン ボタンをカスタム ペン定義にバインドします。 |

## <a name="related-articles"></a>関連記事

* [作業の開始: UWP アプリでのインクのサポート](../../get-started/ink-walkthrough.md)
* [ポインター入力の処理](handle-pointer-input.md)
* [入力デバイスの識別](identify-input-devices.md)

**API**

* [**Windows.Devices.Input**](https://msdn.microsoft.com/library/windows/apps/br225648)
* [**Windows.UI.Input.Inking**](https://msdn.microsoft.com/library/windows/apps/br208524)
* [**Windows.UI.Input.Inking.Core**](https://msdn.microsoft.com/library/windows/apps/dn958452)

**サンプル**
* [入門チュートリアル: UWP アプリでのインクのサポート](https://aka.ms/appsample-ink)
* [単純なインクのサンプル (C#/C++)](https://go.microsoft.com/fwlink/p/?LinkID=620312)
* [複雑なインクのサンプル (C++)](https://go.microsoft.com/fwlink/p/?LinkID=620314)
* [インクのサンプル (JavaScript)](https://go.microsoft.com/fwlink/p/?LinkID=620308)
* [塗り絵帳のサンプル](https://aka.ms/cpubsample-coloringbook)
* [Family Notes のサンプル](https://aka.ms/cpubsample-familynotessample)
* [基本的な入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620302)
* [待機時間が短い入力のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=620304)
* [ユーザー操作モードのサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619894)
* [フォーカスの視覚効果のサンプル](https://go.microsoft.com/fwlink/p/?LinkID=619895)

**サンプルのアーカイブ**
* [入力: デバイス機能のサンプル](https://go.microsoft.com/fwlink/p/?linkid=231530)
* [入力: XAML ユーザー入力イベントのサンプル](https://go.microsoft.com/fwlink/p/?linkid=226855)
* [XAML のスクロール、パン、ズームのサンプル](https://go.microsoft.com/fwlink/p/?linkid=251717)
* [入力: GestureRecognizer によるジェスチャと操作](https://go.microsoft.com/fwlink/p/?LinkID=231605)
