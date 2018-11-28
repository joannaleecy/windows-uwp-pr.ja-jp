---
ms.assetid: 0C8DEE75-FB7B-4E59-81E3-55F8D65CD982
title: アニメーションの概要
description: Windows ランタイム アニメーション ライブラリのアニメーションを使って、Windows の見た目や操作感を自分のアプリに取り入れることができます。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: de2544bbd8c7abe9b1852268373cc88913a30227
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7833732"
---
# <a name="animations-in-xaml"></a>XAML でのアニメーション

UWP のアニメーションは、アプリに躍動感と双方向性を与えます。 Windows ランタイム アニメーション ライブラリのアニメーションを使って、Windows の見た目や操作感を自分のアプリに取り入れることができます。 ここでは、アニメーションの概要と、それぞれのアニメーションが適用される通常のシナリオ例について説明します。

> [!TIP]
> XAML 用の Windows ランタイム コントロールには、特定の種類のアニメーションが、アニメーション ライブラリから取得される組み込みの動作として含まれています。 こうしたコントロールを利用することで、アニメーション化された見た目や操作感を自分でプログラミングしなくてもアプリに取り入れることができます。

Windows ランタイム アニメーション ライブラリのアニメーションには次のような利点があります。

-   「[アニメーションのガイドライン](https://msdn.microsoft.com/library/windows/apps/Dn611854)」に従った動き
-   ユーザーの気をそらさずに必要な情報を伝える、UI 状態の高速で滑らかな切り替え
-   アプリ内の画面切り替えをユーザーに示す視覚的動作

たとえば、ユーザーがリストに項目を追加すると、新しい項目が即座に表示されてリストが瞬間的に更新されるのではなく、新しい項目が動きを伴ってリストの中に入ります。 他のリスト項目は短時間で移動されて、追加のためのスペースが確保されます。 この画面切り替え動作により、ユーザーはコントロールの動作をはっきりと理解することができます。

Windows 10 バージョン 1607 では、ナビゲーション時にビューの間でアニメーション化する要素が表示されるアニメーションを実装するために、新しい [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) API が導入されました。 この API は、他のアニメーション ライブラリ API とは使用パターンが異なります。 **ConnectedAnimationService** の使用については、[リファレンス ページ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx)をご覧ください。

すべてのシナリオに対応するアニメーションがアニメーション ライブラリに用意されているわけではありません。 XAML でカスタム アニメーションを作ることが必要になる場合もあります。 詳しくは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。

さらに、ScrollViewer のスクロール位置に基づいた項目のアニメーション化など、特定の高度なシナリオでは、開発者がビジュアル レイヤーの相互運用を使ってカスタム アニメーションを実装することが必要になる場合があります。 詳しくは、「[ビジュアル レイヤー](https://msdn.microsoft.com/windows/uwp/composition/visual-layer)」をご覧ください。

## <a name="types-of-animations"></a>アニメーションの種類

Windows ランタイム アニメーション システムとアニメーション ライブラリには、コントロールと UI のその他の部分が動作をアニメーション化できるようにするという、より大きな目的があります。 アニメーションには、いくつかの個別の種類があります。

-   *テーマ切り替え*は、UI で特定の条件が変化したときに自動的に適用されます。定義済みの Windows ランタイム XAML UI 型のコントロールまたは要素が対象になります。 これらのアニメーションは、Windows の外観と操作性をサポートし、すべてのアプリが操作モードを切り替えるときに特定の UI シナリオに対して行うことを定義しているので、*テーマ切り替え*と呼ばれます。 テーマ切り替えは、アニメーション ライブラリの一部です。
-   *テーマ アニメーション*は、定義済み Windows ランタイム XAML UI 型の 1 つ以上のプロパティに対するアニメーションです。 テーマ アニメーションは、特定の 1 要素を対象とし、コントロール内に特定の表示状態で存在するという点でテーマ切り替えとは異なります。一方、テーマ切り替えは、表示状態の外側に存在するコントロールのプロパティに割り当てられ、表示状態間の切り替えに影響を及ぼします。 Windows ランタイム XAML コントロールの多くは、コントロール テンプレートの一部であり、表示状態がアニメーションのきっかけとなるテーマ アニメーションをストーリーボード内に含んでいます。 テンプレートを変更しない限り、UI のコントロールでこの組み込みのテーマ アニメーションを使うことができます。 ただし、テンプレートを置き換えた場合は、組み込みのテーマ アニメーションも削除されます。 テーマ アニメーションを元に戻すには、コントロールの表示状態セット内にテーマ アニメーションを含むストーリーボードを定義する必要があります。 また、ストーリーボードから表示状態内にないテーマ アニメーションを実行し、[**Begin**](https://msdn.microsoft.com/library/windows/apps/BR210491) メソッドを使って開始することもできますが、これは一般的ではありません。 テーマ アニメーションはアニメーション ライブラリの一部です。
-   *視覚的な切り替え*は、コントロールが定義済みの 1 つの表示状態から別の状態に切り替えられたときに適用されます。 これらは、開発者が記述するカスタム アニメーションです。通常は、コントロールのために記述したカスタム テンプレートと、そのテンプレート内の表示状態の定義に関連しています。 アニメーションは状態間の切り替え中だけに実行され、通常は、最大でも数秒間のわずかな時間です。 詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808#VisualTransition)」の「VisualTransition」のセクションをご覧ください。
-   *ストーリーボードに設定されたアニメーション*は、時間の経過と共に Windows ランタイム依存関係プロパティの値をアニメーション化します。 ストーリーボードは、視覚的切り替えの一部として定義することも、実行時にアプリケーションによってトリガーすることもできます。 詳しくは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。 依存関係プロパティとその存在場所について詳しくは、「[依存関係プロパティの概要](https://msdn.microsoft.com/library/windows/apps/Mt185583)」をご覧ください。
-   新しい [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) API によって提供される*接続型アニメーション*により、開発者はナビゲーション時にビューの間で要素がアニメーション化される効果を容易に作成できます。 この API は、Windows 10 バージョン 1607 以降で使うことができます。 詳しくは、「[**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx)」をご覧ください。

## <a name="animations-available-in-the-library"></a>ライブラリに用意されているアニメーション

アニメーション ライブラリには、次のアニメーションが用意されています。 アニメーションの名前をクリックすると、主な使用シナリオ、その定義方法、アニメーション例の詳しい情報が表示されます。

-   [ページ切り替え](#page-transition): [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) 内のページ切り替えをアニメーション化します。
-   [コンテンツ切り替えと開始切り替え](#content-transition-and-entrance-transition): コンテンツの断片やまとまりをアニメーション化して画面に表示したり、画面から消したりします。
-   [フェード イン/アウトとクロスフェード](#fade-in-out-and-crossfade): 一時的な要素またはコントロールを表示し、コンテンツ領域を更新します。
-   [ポインター アップ/ダウン](#pointer-up-down): タイルでのタップまたはクリックの視覚的なフィードバックを提供します。
-   [位置の変更](#reposition): 要素を新しい位置に移動します。
-   [ポップアップの表示/非表示](#show-hide-popup): コンテキストに沿った UI を画面上に表示します。
-   [エッジ (端) UI の表示/非表示](#show-hide-edge-ui): パネルのように大きな UI も含めて、端に基づく UI をスライドして画面に表示したり、画面から消したりします。
-   [リスト項目の変更](#list-item-changes): リストについて項目の追加、項目の削除、項目の並べ替えを行います。
-   [ドラッグ/ドロップ](#drag-drop): ドラッグ アンド ドロップ操作中に視覚的なフィードバックを提供します。

### <a name="page-transition"></a>ページ切り替え

アプリ内でのナビゲーションをアニメーション化するには、ページ切り替えを使います。 ほぼすべてのアプリで、ある種のナビゲーションが使用されるため、ページ切り替えアニメーションはアプリで使用される最も一般的な種類のテーマ アニメーションです。 ページ切り替えの API について詳しくは、「[**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition)」をご覧ください。



### <a name="content-transition-and-entrance-transition"></a>コンテンツ切り替えと開始切り替え

コンテンツ切り替えアニメーション ([**ContentThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243103)) を使って、コンテンツの断片やまとまりを移動して現在の画面に表示したり、画面から消したりします。 たとえば、コンテンツ切り替えアニメーションは、ページが最初に読み込まれたとき、またはページの 1 セクションのコンテンツを変更したときに表示できなかったコンテンツを表示する場合に使われます。

[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) は、ページまたは UI の大きなセクションが最初に読み込まれたときに、コンテンツに適用できるモーションを表します。 したがって、最初にコンテンツを表示するときは、コンテンツ切り替え時とは異なるフィードバックとすることができます。 [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) は、既定のパラメーターを指定した場合の [**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition) と同じですが、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) の外部で使用できます。
 
 
<span id="fade-in-out-and-crossfade"/>

### <a name="fade-inout-and-crossfade"></a>フェード イン/アウトとクロスフェード

フェード イン/アウト アニメーションを使って、一時的な UI またはコントロールを表示したり、非表示にしたりします。 XAML では、これは [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) として表されます。 たとえば、ユーザーの操作により新しいコントロールが表示されるアプリ バーでこのアニメーションを使います。 また、一定期間ユーザーの入力が検出されないとフェード アウトする一時的なスクロール バーとパン インジケーターにもこのアニメーションが適用されます。 アプリで、コンテンツが動的に読み込まれてプレースホルダー項目から最終項目に切り替わるときにもフェード イン アニメーションが使われます。

クロスフェード アニメーションを使って、画面の現在のコンテンツを更新している場合など、項目の状態が変化しているときにスムーズに切り替えます。 XAML アニメーション ライブラリには専用のクロスフェード アニメーション ([**crossFade**](https://msdn.microsoft.com/library/windows/apps/BR212661) と同等のもの) がありませんが、タイミングを重ねて [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) を使うことで同じ結果を実現できます。

<span id="pointer-up-down"/>

### <a name="pointer-updown"></a>ポインター アップ/ダウン

[**PointerUpThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969168) アニメーションと [**PointerDownThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969164) アニメーションを使って、タイルでのタップやクリックが正常に行われたことについてユーザーにフィードバックを提供します。 たとえば、ユーザーがタイルを下にクリックまたはタップすると、ポインター ダウン アニメーションが再生されます。 クリックまたはタップが解放されると、ポインター アップ アニメーションが再生されます。

### <a name="reposition"></a>位置の変更

位置変更アニメーション ([**RepositionThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210421) または [**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429)) を使って、要素を新しい位置に移動します。 たとえば、項目のコントロールでヘッダーを動かすと、位置変更アニメーションが適用されます。

<span id="show-hide-popup"/>

### <a name="showhide-popup"></a>ポップアップの表示/非表示

[**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210383) と [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210391) を使って、[**Popup**](https://msdn.microsoft.com/library/windows/apps/BR227842) や類似のコンテキストに沿った UI を現在の画面に表示し、画面から消します。 [**PopupThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969172) は、ポップアップを簡易非表示にする場合、便利なフィードバックとなるテーマ切り替えです。

<span id="show-hide-edge-ui"/>

### <a name="showhide-edge-ui"></a>エッジ (端) UI の表示/非表示

[**EdgeUIThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh702324) アニメーションを使って、端に基づく小さい UI をスライドして画面に表示したり、画面から消したりします。 たとえば、画面の上部や下部にカスタムのアプリ バーを表示したり、画面の上部にエラーや警告の UI サーフェスを表示したりするときに、これらのアニメーションを使います。

ウィンドウまたはパネルの表示や非表示には [**PaneThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969160) アニメーションを使います。 これはカスタム キーボードや作業ウィンドウのような端に基づく大きな UI 用です。

### <a name="list-item-changes"></a>リスト項目の変更

[**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047) アニメーションは、既にあるリストに項目の追加時または削除時のアニメーション動作を追加するときに使います。 追加時の切り替えの場合、最初にリスト内の既にある項目の位置が変更され、新しい項目用のスペースが確保されてから、新しい項目が追加されます。 削除時の切り替えの場合、リストから項目が削除され、必要に応じて、残りのリスト項目の位置が変更されます。

項目のリスト内の位置が変わった場合に適用される別の [**ReorderThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210409) もあります。 これは、項目を削除してそれを新しい位置に追加するときに使われる関連する削除/追加アニメーションとは異なるアニメーションになります。

これらのアニメーションは、既定の [**ListView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) テンプレートと [**GridView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) テンプレートに含まれているため、これらのコントロールを既に使用している場合、これらのアニメーションを手動で追加する必要はありません。

<span id="drag-drop"/>

### <a name="dragdrop"></a>ドラッグ/ドロップ

ドラッグ アニメーション ([**DragItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243173)、[**DragOverThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243177)) とドロップ アニメーション ([**DropTargetItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243185)) を使って、ユーザーが項目をドラッグまたはドロップするときに視覚的なフィードバックを提供します。

有効にすると、リストにドロップした項目の前後の項目の位置が変更されることがアニメーションによってユーザーに示されます。 このアニメーションを使うと、ユーザーは項目を現在の位置にドロップしたときに、項目がリスト内のどの位置に配置されるかを把握できるため便利です。 アニメーションでは、ドラッグしている項目を、リストの他の 2 つの項目間にドロップできること、およびそれらの項目は移動することを視覚的なフィードバックで示します。

## <a name="using-animations-with-custom-controls"></a>アニメーションとカスタム コントロールの使用

カスタマイズした Windows ランタイム コントロールを作るときに、どのアニメーションを使う必要があるかについての推奨事項を次の表にまとめます。

| UI の種類 | 推奨されるアニメーション |
|---------|-----------------------|
| ダイアログ ボックス | [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) |
| ポップアップ | [**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popinthemeanimation.popinthemeanimation.aspx) と [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popoutthemeanimation.popoutthemeanimation) |
| ヒント | [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) |
| ショートカット メニュー | [**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popinthemeanimation.popinthemeanimation.aspx) と [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popoutthemeanimation.popoutthemeanimation) |
| コマンド バー | [**EdgeUIThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.edgeuithemetransition.edgeuithemetransition) |
| 作業ウィンドウまたは端に基づくパネル | [**PaneThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.panethemetransition.panethemetransition) |
| 各種 UI コンテナーのコンテンツ | [**ContentThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.contentthemetransition.contentthemetransition) |
| コントロールに対して (または他に該当するアニメーションがない場合に) 適用する | [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.fadeinthemeanimation.fadeinthemeanimation.aspx) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) |

 

## <a name="transition-animation-examples"></a>切り替え効果のアニメーションの例

アプリが使うアニメーションは、ユーザーを困惑させることなく、ユーザー インターフェイスを豊かに、魅力的にするものであるのが理想です。 1 つの方法は、切り替え効果のアニメーションを UI に適用することです。画面に何かが出入りするなど、何かの変化が起きたときに、アニメーションによって、その変化にユーザーの注意を惹き付けます。 たとえば、ボタンの場合、単に画面に表示したり画面から消したりするのではなく、フェード イン/フェード アウトさせるようにします。 一貫性のあるお勧めの (標準的な) 切り替え効果アニメーションを作ることができる API を多数用意しました。 ここでは、ボタンがスライドしながら勢いよく画面に表示されるアニメーションの適用方法を紹介します。

```xml
<Button Content="Transitioning Button">
     <Button.Transitions>
         <TransitionCollection> 
             <EntranceThemeTransition/>
         </TransitionCollection>
     </Button.Transitions>
 </Button>
 ```

このコードでは、ボタンの切り替え効果のコレクション (TransitionCollection) に [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) オブジェクトを追加します。 これで、ボタンが最初にレンダリングされるときに、ただ表示されるのではなく、スライドしながら勢いよく画面に表示されるようになります。 アニメーション オブジェクトには、スライドする距離と方向を調整する目的でいくつかのプロパティを設定できますが、API としては、特定のシナリオ、つまり、出入り口 (entrance) を目立たせることを意図した非常に単純なものです。

切り替え効果のアニメーションのテーマをアプリのスタイル リソースで定義して、統一感のある効果を適用することもできます。 先ほどの例に相当する内容を [**Style**](https://msdn.microsoft.com/library/windows/apps/BR208849) を使って実現したのが次のコードです。

```xml
<UserControl.Resources>
     <Style x:Key="DefaultButtonStyle" TargetType="Button">
         <Setter Property="Transitions">
             <Setter.Value>
                 <TransitionCollection>
                     <EntranceThemeTransition/>
                 </TransitionCollection>
             </Setter.Value>
        </Setter>
    </Style>
</UserControl.Resources>
      
<StackPanel x:Name="LayoutRoot">
    <Button Style="{StaticResource DefaultButtonStyle}" Content="Transitioning Button"/>
</StackPanel>
```

これまでの例では、テーマ切り替えを個々のコントロールに適用していましたが、それをオブジェクトのコンテナーに適用すると、もっとおもしろいことが起こります。 コンテナーに含まれているすべての子オブジェクトに、切り替え効果が適用されます。 次の例では、[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) を四角形から成る [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) に適用しています。

```xml
<!-- If you set an EntranceThemeTransition animation on a panel, the
     children of the panel will automatically offset when they animate
     into view to create a visually appealing entrance. -->        
<ItemsControl Grid.Row="1" x:Name="rectangleItems">
    <ItemsControl.ItemContainerTransitions>
        <TransitionCollection>
            <EntranceThemeTransition/>
        </TransitionCollection>
    </ItemsControl.ItemContainerTransitions>
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <WrapGrid Height="400"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
            
    <!-- The sequence children appear depends on their order in 
         the panel's children, not necessarily on where they render
         on the screen. Be sure to arrange your child elements in
         the order you want them to transition into view. -->
    <ItemsControl.Items>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
    </ItemsControl.Items>
</ItemsControl>
```

切り替え効果が適用された [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) の子である四角形が次々に表示され、見ていて楽しい気分になります。同じアニメーションを個々の四角形に適用した場合は、すべての四角形がいっせいに表示されますが、それとは対照的です。

このアニメーションのデモを次に示します。

![子である四角形をビューに切り替えて表示するアニメーション](./images/animation-child-rectangles.gif)

いずれかの子の位置が変化した場合は、コンテナーの子オブジェクトを再度流し込むことができます。 次の例では、[**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) を四角形から成るグリッドに適用しています。 いずれかの四角形を削除すると、その他すべての四角形が新しい位置に再度流し込まれます。

```xml
<Button Content="Remove Rectangle" Click="RemoveButton_Click"/>
        
<ItemsControl Grid.Row="1" x:Name="rectangleItems">
    <ItemsControl.ItemContainerTransitions>
        <TransitionCollection>
                    
            <!-- Without this, there would be no animation when items 
                 are removed. -->
            <RepositionThemeTransition/>
        </TransitionCollection>
    </ItemsControl.ItemContainerTransitions>
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <WrapGrid Height="400"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
            
    <!-- All these rectangles are just to demonstrate how the items
         in the grid re-flow into position when one of the child items
         are removed. -->
    <ItemsControl.Items>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
    </ItemsControl.Items>
</ItemsControl>
```

```cs
private void RemoveButton_Click(object sender, RoutedEventArgs e)
{
    if (rectangleItems.Items.Count > 0)
    {    
        rectangleItems.Items.RemoveAt(0);
    }                         
}
```

```cpp
// .h
private:
void RemoveButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);

//.cpp
void BlankPage::RemoveButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    if (rectangleItems->Items->Size > 0)
    {    
        rectangleItems->Items->RemoveAt(0);
    }
}
```

切り替え効果のアニメーションは、1 つのオブジェクトまたは 1 つのオブジェクト コンテナーに対し複数適用することができます。 たとえば、アニメーションで表示する一連の四角形があり、四角形の位置が変化したときにもアニメーションを適用する必要がある場合、[**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) と [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) を次のように適用します。

```xml
...
<ItemsControl.ItemContainerTransitions>
    <TransitionCollection>
        <EntranceThemeTransition/>                    
        <RepositionThemeTransition/>
    </TransitionCollection>
</ItemsControl.ItemContainerTransitions>
...      
```

切り替え効果には、さまざまな種類が存在し、UI 要素の追加時、削除時、並べ替え時などに、それに応じたアニメーションを適用することができます。 これらの API はすべて、名前に "ThemeTransition" という単語が含まれています。

| API | 説明 |
|-----|-------------|
| [**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition) | [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) 内でのページ ナビゲーションに Windows パーソナリティ アニメーションを提供します。 |
| [**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047) | コントロールの子やコンテンツが追加されたり削除されたりしたときの切り替え動作のアニメーションです。 ここでいうコントロールは通常、項目コンテナーです。 |
| [**ContentThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243103) | コントロールのコンテンツが変化しているときの切り替え動作のアニメーションです。 このアニメーションは、[**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047) に追加する形で適用することができます。 |
| [**EdgeUIThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh702324) | (小さい) エッジ UI の切り替え動作のアニメーションです。 |
| [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) | コントロールが最初に表示されるときの切り替え動作のアニメーションです。 |
| [**PaneThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969160) | パネル (大きなエッジ UI) の切り替え動作のアニメーションです。 |
| [**PopupThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969172) | コントロールのポップイン コンポーネント (オブジェクトに関するツールヒント風の UI など) が表示されるときに適用される切り替え動作のアニメーションです。 |
| [**ReorderThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210409) | リスト ビュー コントロールの項目の順序が変わったときの切り替え動作のアニメーションです。 通常、この変化は、ドラッグ アンド ドロップ操作の結果として起こります。 コントロールやテーマの種類によって、アニメーションの特性が異なる場合があります。 |
| [**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) | コントロールの位置が変わったときの切り替え動作のアニメーションです。 |

 

## <a name="theme-animation-examples"></a>テーマ アニメーションの例

切り替え効果のアニメーションは簡単に適用できます。 しかし、場合によっては、アニメーション効果のタイミングや順序をもっと細かく制御する必要があります。 テーマ アニメーションを使うと、アニメーションの動作に一貫したテーマを使いながら、より細かな制御を行うことができます。 テーマ アニメーションも、カスタム アニメーションよりマークアップを少なくする必要があります。 ここでは、[**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) を使って、四角形をフェード アウトさせています。

```xml
<StackPanel>    
    <StackPanel.Resources>
        <Storyboard x:Name="myStoryboard">
            <FadeOutThemeAnimation TargetName="myRectangle" />
        </Storyboard>
    </StackPanel.Resources>
    <Rectangle PointerPressed="Rectangle_Tapped" x:Name="myRectangle"  
              Fill="Blue" Width="200" Height="300"/>
</StackPanel>
```

```cs
// When the user taps the rectangle, the animation begins.
private void Rectangle_Tapped(object sender, PointerRoutedEventArgs e)
{
    myStoryboard.Begin();
}
```

```vb
' When the user taps the rectangle, the animation begins.
Private Sub Rectangle_Tapped(sender As Object, e As PointerRoutedEventArgs)
    myStoryboard.Begin()
End Sub
```

```cpp
//.h
void Rectangle_Tapped(Platform::Object^ sender, Windows::UI::Xaml::Input::PointerRoutedEventArgs^ e);

//.cpp
void BlankPage::Rectangle_Tapped(Object^ sender, PointerRoutedEventArgs^ e)
{
    myStoryboard->Begin();
}
```

切り替え効果のアニメーションとは異なり、テーマ アニメーションでは、アニメーションを自動的に実行する組み込みのトリガー (切り替え) がありません。 XAML でテーマ アニメーションを定義するときは、[**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490) を使ってそれを格納する必要があります。 アニメーションの既定の動作を変更することもできます。 たとえば、[**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) の [**Duration**](https://msdn.microsoft.com/library/windows/apps/BR243207) の時間値を増やすと、フェード アウトの速度を遅くすることができます。

**注:** 基本的なアニメーション技法を示すためを使用しますアプリ コードに[**ストーリー ボード**](https://msdn.microsoft.com/library/windows/apps/BR210490)のメソッドを呼び出すことによって、アニメーションを開始します。 **Storyboard** クラスの [**Begin**](https://msdn.microsoft.com/library/windows/apps/BR210491)、[**Stop**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.stop)、[**Pause**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.pause.aspx)、[**Resume**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.resume.aspx) の各メソッドを使うと、**Storyboard** アニメーションを実行する方法を制御できます。 ただし、これはライブラリ アニメーションをアプリに含める通常の方法ではありません。 むしろ、通常は、コントロールまたは要素に適用される XAML スタイルとテンプレートにライブラリ アニメーションを統合します。 テンプレートと表示状態の説明はもう少し込み入ったものになります。 ただし、表示状態でライブラリ アニメーションを使用する方法については、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808)」トピックの一部として取り上げています。

 

そのほかにもさまざまなテーマ アニメーションを UI 要素に適用して、アニメーション効果を作ることができます。 これらの API はすべて、名前に "ThemeAnimation" という単語が含まれています。

| API | 説明 |
|-----|-------------|
| [**DragItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243173) | ドラッグされている項目要素に適用される事前構成済みのアニメーションを表します。 |
| [**DragOverThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243177) | ドラッグされている要素の下にある要素に適用される事前構成済みのアニメーションを表します。 |
| [**DropTargetItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243185) | ドロップ先となりうる要素に適用される事前構成済みのアニメーションです。 |
| [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) | 透明から不透明への変化を表す事前構成済みのアニメーションです。コントロールが最初に表示されるときに適用されます。 |
| [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) | 透明から不透明への変化を表す事前構成済みのアニメーションです。コントロールが UI から削除されたり非表示になるときに適用されます。 |
| [**PointerDownThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969164) | 項目または要素をタップまたはクリックするユーザー操作の事前構成済みのアニメーションです。 |
| [**PointerUpThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969168) | ユーザーが項目または要素をタップし、指を離すと実行される事前構成済みのアニメーションです。 |
| [**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210383) | コントロールのポップイン コンポーネントが表示されるときに適用される事前構成済みのアニメーションです。 このアニメーションには、不透明度と変換が組み合わされています。 |
| [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210391) | コントロールのポップイン コンポーネントが閉じたり削除されたりするときに適用される事前構成済みのアニメーションです。 このアニメーションには、不透明度と変換が組み合わされています。 |
| [**RepositionThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210421) | オブジェクトの位置が変更されたときに適用される事前構成済みのアニメーションです。 |
| [**SplitCloseThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210454) | [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) を開閉するときのスタイルのアニメーションでターゲット UI を非表示にする事前構成済みのアニメーションです。 |
| [**SplitOpenThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210472) | [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) を開閉するときのスタイルのアニメーションでターゲット UI を表示する事前構成済みのアニメーションです。 |
| [**DrillInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.drillinthemeanimation) | マスター ページから詳細ページのように、ユーザーが論理階層を順方向に移動するときに実行される事前構成済みのアニメーションを表します。 |
| [**DrillOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.drilloutthemeanimation.aspx) | 詳細ページからマスター ページのように、ユーザーが論理階層を逆方向に移動するときに実行される事前構成済みのアニメーションを表します。 |

 

## <a name="create-your-own-animations"></a>カスタム アニメーションの作成

テーマ アニメーションでは自分のニーズが満たせない場合は、アニメーションを独自に作ることができます。 オブジェクトのプロパティ値のいくつかをアニメーション化することによって、オブジェクトに動きを与えることができます。 たとえば、四角形の幅や [**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932) の角度、ボタンの色の値をアニメーション化することができます。 この種のカスタム アニメーションは、事前構成済みのアニメーションの種類として Windows ランタイムに既に用意されているライブラリ アニメーションと区別するために、"ストーリーボードに設定されたアニメーション" と呼ばれています。 ストーリーボードに設定されたアニメーションの場合、特定の型の値を変更できるアニメーション (**Double** をアニメーションできる [**DoubleAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243136) など) を使い、そのアニメーションを [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490) 内に配置して制御します。

アニメーション化するためには、アニメーション化しているプロパティが*依存関係プロパティ*である必要があります。 依存関係プロパティについて詳しくは、「[依存関係プロパティの概要](https://msdn.microsoft.com/library/windows/apps/Mt185583)」をご覧ください。 ストーリーボードに設定されたカスタム アニメーションの作成について詳しくは、対象に選ぶ方法や制御方法も含め、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。

ストーリーボードに設定されたカスタム アニメーションを定義する際に XAML のアプリ UI 定義で最大となるのは、XAML でコントロールの表示状態を定義する場合です。 これを行うのは、新たにコントロール クラスを作成するか、既にあるコントロールのうち、コントロール テンプレートに表示状態があるものに対してもう一度テンプレートを作成する場合です。 詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808)」をご覧ください。

 

 




