---
author: Karl-Bridge-Microsoft
Description: Learn how to improve both the usability and the accessibility of your UWP app by providing an intuitive way for users to quickly navigate and interact with an app's visible UI through a keyboard instead of a pointer device (such as touch or mouse).
title: アクセス キーの設計ガイドライン
label: Access keys design guidelines
keywords: キーボード, アクセス キー, keytip, キーのヒント, アクセシビリティ, ナビゲーション, フォーカス, テキスト, 入力, ユーザーの操作
template: detail.hbs
ms.author: kbridge
ms.date: 06/08/2018
ms.topic: article
pm-contact: miguelrb
design-contact: kimsea
dev-contact: niallm
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 844e5d8e9442192d75f2aac07a7a2f82dd0196f3
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7152251"
---
# <a name="access-keys"></a>アクセス キー

アクセス キーは、ポインター デバイス (タッチやマウスなど) の代わりにキーボードを使って、アプリに表示される UI 間をすばやく移動したり、これらの UI を操作したりするための直感的な方法をユーザーに提供して、Windows アプリケーションの使いやすさとアクセシビリティを向上させるキーボード ショートカットです。

キーボード ショートカットを使って Windows アプリケーションの一般的な操作を呼び出す方法について詳しくは、「[アクセラレータ キー](keyboard-accelerators.md)」のトピックをご覧ください。 

> [!NOTE]
> キーボードは、特定の障碍を持つユーザーにとっては不可欠であり ([キーボードのアクセシビリティ](https://docs.microsoft.com/windows/uwp/accessibility/keyboard-accessibility)をご覧ください)、アプリをより効率的に操作することを望むユーザーにとって重要なツールでもあります。

ユニバーサル Windows プラットフォーム (UWP) には、キーボード ベースのアクセス キー、およびキーのヒントと呼ばれる視覚的な合図を利用した関連する UI フィードバックの両方について、さまざまなプラットフォーム コントロールに対応した組み込みのサポートが用意されています。

## <a name="overview"></a>概要

アクセス キーは、Alt キーと 1 つ以上の英数字キー (*ニーモニック*と呼ばれることがあります) の組み合わせであり、通常は同時に押すのではなく順番に押します。

キーのヒントは、ユーザーが Alt キーを押したときにアクセス キーをサポートするコントロールの横に表示されるバッジです。 キーのヒントにはそれぞれ、関連するコントロールをアクティブ化する英数字キーが表示されます。

> [!NOTE]
> 1 文字の英数字を使ったアクセス キーでは、キーボード ショートカットが自動的にサポートされます。 たとえば、Word で Alt キーを押しながら F キーを押すと、キーのヒントが表示されずに [ファイル] メニューが開きます。

Alt キーを押すとアクセス キー機能が初期化され、現在利用可能なキーの組み合わせがすべてキーのヒントに表示されます。 後続のキー入力は、アクセス キー フレームワークによって処理されます。このフレームワークは、有効なアクセス キーが押されるか、、Enter、Esc、Tab、または方向キーを押してアクセス キーを非アクティブ化することでキー入力の処理がアプリに返されるまでは、無効なキーを拒否します。

Microsoft Office アプリでは、アクセス キーが広範にサポートされています。 次の図は、アクセス キーがアクティブになった状態の Word の [ホーム] タブを示しています (数字と複数のキー入力の両方のサポートに注目してください)。

![Microsoft Word におけるアクセス キーの KeyTip バッジ](images/accesskeys/keytip-badges-word.png)

_Microsoft Word におけるアクセス キーの KeyTip バッジ_

コントロールにアクセス キーを追加するには、**AccessKey プロパティ**を使います。 このプロパティの値は、アクセス キーの順序、ショートカット (1 文字の英数字の場合)、キーのヒントを指定します。

``` xaml
<Button Content="Accept" AccessKey="A" Click="AcceptButtonClick" />
```

## <a name="when-to-use-access-keys"></a>アクセス キーを使う場合

UI に適切な場合は必ずアクセス キーを指定し、すべてのカスタム コントロールでアクセス キーをサポートすることをお勧めします。

1.  一度に 1 つのキーのみ押すことができるユーザーや、マウスを使うのが困難なユーザーなど、運動障碍を持つユーザーにとっては、**アクセス キーによりアプリのアクセシビリティが高まります**。

    適切に設計されたキーボード UI はソフトウェアのアクセシビリティの重要な要素であり、 視覚に障碍のあるユーザーや特定の運動障碍のあるユーザーによるアプリ内の移動や、その機能の操作を実現します。 このようなユーザーはマウスを操作できない場合があるため、代わりにさまざまな支援技術 (キーボード強化ツール、スクリーン キーボード、スクリーン拡大機能、スクリーン リーダー、音声入力ユーティリティなど) が不可欠になる可能性があります。 このようなユーザーにとっては、コマンドを包括的にカバーすることが重要です。

2.  キーボードを使った操作を好むパワー ユーザーにとっては、**アクセス キーによりアプリが使いやすくなります**。

    多くの経験豊富なユーザーには、キーボードの使用の方がはるかに好まれます。キーボード ベースのコマンドであれば、すばやく入力することができ、キーボードから手を離す必要がないためです。 このようなユーザーにとっては、効率性と一貫性が重要です。包括性が重要になるのは、特に頻繁に使用するコマンドに対してのみです。

## <a name="set-access-key-scope"></a>アクセス キーのスコープを設定する

アクセス キーをサポートする要素が画面上に多くある場合、**認知的負荷**を軽減するためにアクセス キーのスコープを設定することをお勧めします。 これにより、画面上のアクセス キーの数が最小限に抑えられるため、見つけやすくなり、効率性と生産性が向上します。

たとえば、Microsoft Word には 2 つのアクセス キー スコープが用意されています。リボン タブ用のプライマリ スコープと、選択されたタブ上のコマンドのセカンダリ スコープです。

次の図は、Word における 2 つのアクセス キー スコープを示しています。 最初の図は、ユーザーがタブとその他の最上位レベルのコマンドを選択できるようにするプライマリ アクセス キーを示しています。2 つ目の図は、[ホーム] タブのセカンダリ アクセス キーを示しています。

![Microsoft Word におけるプライマリ アクセス キー](images/accesskeys/primary-access-keys-word.png)
_Microsoft Word におけるプライマリ アクセス キー_

![Microsoft Word におけるセカンダリ アクセス キー](images/accesskeys/secondary-access-keys-word.png)
_Microsoft Word におけるセカンダリ アクセス キー_

アクセス キーは、異なるスコープの要素用に複製することができます。 前の例では、"2" はプライマリ スコープにおける [元に戻す] のアクセス キーであり、セカンダリ スコープにおける "斜体" のアクセス キーでもあります。

アクセス キーのスコープを定義する方法を次に示します。

``` xaml
<CommandBar x:Name="MainCommandBar" AccessKey="M" >
    <AppBarButton AccessKey="G" Icon="Globe" Label="Go"/>
    <AppBarButton AccessKey="S" Icon="Stop" Label="Stop"/>
    <AppBarSeparator/>
    <AppBarButton AccessKey="R" Icon="Refresh" Label="Refresh" IsAccessKeyScope="True">
        <AppBarButton.Flyout>
            <MenuFlyout>
                <MenuFlyoutItem AccessKey="A" Icon="Globe" Text="Refresh A" />
                <MenuFlyoutItem AccessKey="B" Icon="Globe" Text="Refresh B" />
                <MenuFlyoutItem AccessKey="C" Icon="Globe" Text="Refresh C" />
                <MenuFlyoutItem AccessKey="D" Icon="Globe" Text="Refresh D" />
            </MenuFlyout>
        </AppBarButton.Flyout>
    </AppBarButton>
    <AppBarButton AccessKey="B" Icon="Back" Label="Back"/>
    <AppBarButton AccessKey="F" Icon="Forward" Label="Forward"/>
    <AppBarSeparator/>
    <AppBarToggleButton AccessKey="V" Icon="Favorite" Label="Favorite"/>
    <CommandBar.SecondaryCommands>
        <AppBarToggleButton Icon="Like" AccessKey="L" Label="Like"/>
        <AppBarButton Icon="Setting" AccessKey="T" Label="Settings" />
    </CommandBar.SecondaryCommands>
</CommandBar>
```

![CommandBar のプライマリ アクセス キー](images/accesskeys/primary-access-keys-commandbar.png)

_CommandBar のプライマリ スコープとサポートされているアクセス キー_

![CommandBar のセカンダリ アクセス キー](images/accesskeys/secondary-access-keys-commandbar.png)

_CommandBar のセカンダリ スコープとサポートされているアクセス キー_

### <a name="windows-10-creators-update-and-older"></a>Windows 10 Creators Update 以降

Windows 10 Fall Creators Update より前のバージョンでは、CommandBar などの一部のコントロールは、組み込みのアクセス キーのスコープをサポートしていませんでした。

次の例は、親コマンド (Word のリボンに似ています) が呼び出されると使用できるアクセス キー持つ CommandBar の SecondaryCommands をサポートする方法を示しています。

```xaml
<local:CommandBarHack x:Name="MainCommandBar" AccessKey="M" >
    <AppBarButton AccessKey="G" Icon="Globe" Label="Go"/>
    <AppBarButton AccessKey="S" Icon="Stop" Label="Stop"/>
    <AppBarSeparator/>
    <AppBarButton AccessKey="R" Icon="Refresh" Label="Refresh" IsAccessKeyScope="True">
        <AppBarButton.Flyout>
            <MenuFlyout>
                <MenuFlyoutItem AccessKey="A" Icon="Globe" Text="Refresh A" />
                <MenuFlyoutItem AccessKey="B" Icon="Globe" Text="Refresh B" />
                <MenuFlyoutItem AccessKey="C" Icon="Globe" Text="Refresh C" />
                <MenuFlyoutItem AccessKey="D" Icon="Globe" Text="Refresh D" />
            </MenuFlyout>
        </AppBarButton.Flyout>
    </AppBarButton>
    <AppBarButton AccessKey="B" Icon="Back" Label="Back"/>
    <AppBarButton AccessKey="F" Icon="Forward" Label="Forward"/>
    <AppBarSeparator/>
    <AppBarToggleButton AccessKey="V" Icon="Favorite" Label="Favorite"/>
    <CommandBar.SecondaryCommands>
        <AppBarToggleButton Icon="Like" AccessKey="L" Label="Like"/>
        <AppBarButton Icon="Setting" AccessKey="T" Label="Settings" />
    </CommandBar.SecondaryCommands>
</local:CommandBarHack>
```

```csharp
public class CommandBarHack : CommandBar
{
    CommandBarOverflowPresenter secondaryItemsControl;
    Popup overflowPopup;

    public CommandBarHack()
    {
        this.ExitDisplayModeOnAccessKeyInvoked = false;
        AccessKeyInvoked += OnAccessKeyInvoked;
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        Button moreButton = GetTemplateChild("MoreButton") as Button;
        moreButton.SetValue(Control.IsTemplateKeyTipTargetProperty, true);
        moreButton.IsAccessKeyScope = true;

        // SecondaryItemsControl changes
        secondaryItemsControl = GetTemplateChild("SecondaryItemsControl") as CommandBarOverflowPresenter;
        secondaryItemsControl.AccessKeyScopeOwner = moreButton;

        overflowPopup = GetTemplateChild("OverflowPopup") as Popup;
    }

    private void OnAccessKeyInvoked(UIElement sender, AccessKeyInvokedEventArgs args)
    {
        if (overflowPopup != null)
        {
            overflowPopup.Opened += SecondaryMenuOpened;
        }
    }

    private void SecondaryMenuOpened(object sender, object e)
    {
        //This is not neccesay given we are automatically pushing the scope.
        var item = secondaryItemsControl.Items.First();
        if (item != null && item is Control)
        {
            (item as Control).Focus(FocusState.Keyboard);
        }
        overflowPopup.Opened -= SecondaryMenuOpened;
    }
}
```

## <a name="avoid-access-key-collisions"></a>アクセス キーの競合を避ける

アクセス キーの競合は、同じスコープ内の複数の要素が重複するアクセス キーを持っている場合や、同じ英数字で始まる場合に生じます。

システムは、ビジュアル ツリーに追加された最初の要素のアクセス キーを処理し、他のアクセス キーをすべて無視することで、重複するアクセス キーを解決します。

複数のアクセス キーが同じ文字で始まる場合 (たとえば、"A"、"A1"、"AB")、システムは 1 文字のアクセス キーを処理し、他のすべてのアクセス キーを無視します。

競合を避けるには、一意のアクセス キーを使ったり、コマンドのスコープを設定したりします。

## <a name="choose-access-keys"></a>アクセス キーを選ぶ

アクセス キーを選ぶときは、以下の点を考慮してください。

-   単一の文字を使ってキー入力を最小限に抑え、ショートカット キーを既定でサポートする (Alt + アクセス キー)
-   複数文字を使わない
-   アクセス キーの競合を避ける
-   アルファベットの "I" と数字の "1"、アルファベットの "O" と数字の "0" など、他の文字との判別が難しい文字を避ける
-   Word など、有名な他のアプリでよく使われているケースに倣う ("File" の "F"、"Home" の "H" など)
-   コマンド名の先頭の文字を使ったり、思い出しやすいようにコマンドとの関連性が高い文字を使ったりする
    -   先頭の文字が既に割り当てられている場合、コマンド名の先頭の文字にできるだけ近い文字を使う ("Insert" の "N" など)
    -   コマンド名の特徴的な死因を使う ("View" の "W")
    -   コマンド名の母音を使う

## <a name="localize-access-keys"></a>アクセス キーをローカライズする

アプリが複数の言語にローカライズされる場合、**アクセス キーのローカライズも検討**してください。 たとえば、英語 (en-US) における "Home" の "H" とスペイン語 (es-ES) における "Incio" の "I" などです。

以下に示すように、マークアップで x:Uid 拡張を使って、ローカライズされたリソースを適用します。

``` xaml
<Button Content="Home" AccessKey="H" x:Uid="HomeButton" />
```
各言語のリソースは、プロジェクト内の対応する文字列フォルダーに追加されます。

![英語およびスペイン語のリソース文字列フォルダー](images/accesskeys/resource-string-folders.png)

_英語およびスペイン語のリソース文字列フォルダー_

ローカライズされたアクセス キーは、プロジェクトの resources.resw ファイルで指定されます。

![resources.resw ファイルで指定された AccessKey プロパティを指定する](images/accesskeys/resource-resw-file.png)

_resources.resw ファイルで指定された AccessKey プロパティを指定する_

詳しくは、「[Translating UI resources](https://msdn.microsoft.com/library/windows/apps/xaml/Hh965329(v=win.10).aspx)」(UI リソースの翻訳) をご覧ください。

## <a name="key-tip-positioning"></a>キーのヒントを配置する

キーのヒントは、他の UI 要素、他のキーのヒント、画面の端の存在を考慮に入れて、対応する UI 要素を基準にフローティング バッジとして表示されます。

通常、キーのヒントは既定の場所で十分であり、アダプティブ UI の組み込みサポートが提供されます。

![キーのヒントの自動配置の例](images/accesskeys/auto-keytip-position.png)

_キーのヒントの自動配置の例_

ただし、キーのヒントの配置より細かく制御する必要がある場合、次のことをお勧めします。

1.  **明白な関連付けの原則**: ユーザーが、コントロールをキーのヒントと簡単に関連付けることができるようにします。

    a.   キーのヒントは、アクセス キーを持つ要素 (オーナー) の**近く**に配置する必要があります。  
    b.   キーのヒントは、アクセス キーを持つ**有効な要素を覆わないようにする**必要があります。   
    c.   キーのヒントをそのオーナーの近くに配置できない場合、オーナーと重ねる必要があります。 

2.  **見つけやすさ**: ユーザーが、キーのヒントによってコントロールをすばやく見つけることができるようにします。

    a.   キーのヒントが他のキーのヒントと**重なる**のを回避してください。  

3.  **読み取りやすい:** ユーザーがキーのヒントを簡単に読み取ることができるようにします。

    a.   キーのヒントは、ヒント相互および UI 要素に**揃えて**配置する必要があります。
    b.   キーのヒントはできる限り**グループ分け**する必要があります。 

### <a name="relative-position"></a>相対的な配置

要素またはグループごとにキーのヒントの配置をカスタマイズするには、**KeyTipPlacementMode** プロパティを使います。

配置モードは、Top、Bottom、Right、Left、Hidden、Center、Auto です。

![キーのヒントの配置モード](images/accesskeys/keytip-postion-modes.png)

_キーのヒントの配置モード_

コントロールの中心線は、キーのヒントの垂直方向および水平方向の配置の計算に使われます。

次の例は、StackPanel コンテナーの KeyTipPlacementMode プロパティを使って、コントロールのグループに関するキーのヒントの配置を設定する方法を示しています。

``` xaml
<StackPanel Background="{ThemeResource ApplicationPageBackgroundThemeBrush}" KeyTipPlacementMode="Top">
  <Button Content="File" AccessKey="F" />
  <Button Content="Home" AccessKey="H" />
  <Button Content="Insert" AccessKey="N" />
</StackPanel>
```

### <a name="offsets"></a>オフセット

キーのヒントの場所をさらに細かく制御するには、要素の KeyTipHorizontalOffset プロパティと KeyTipVerticalOffset プロパティを使います。

> [!NOTE]
> KeyTipPlacementMode が Auto に設定されているときは、オフセットを設定できません。

KeyTipHorizontalOffset プロパティは、キーのヒントを左または右に移動する距離を指定します。 次の例は、ボタンに対するキーのヒントのオフセットを設定する方法を示しています。

![キーのヒントの配置モード](images/accesskeys/keytip-offsets.png)

_キーのヒントの垂直オフセットと水平オフセットを設定する_

``` xaml
<Button
  Content="File"
  AccessKey="F"
  KeyTipPlacementMode="Bottom"
  KeyTipHorizontalOffset="20"
  KeyTipVerticalOffset="-8" />
```

### <a name="screen-edge-alignment-screen-edge-alignment-listparagraph"></a>画面の端の配置 {#screen-edge-alignment .ListParagraph}

キーのヒントの場所は、キーのヒントが完全に表示されるように画面の端を基準にして自動的に調整されます。 この場合、コントロールとキーのヒントの配置ポイントとの間にある距離が、水平オフセットと垂直オフセットに指定した値と異なることがあります。

![キーのヒントの配置モード](images/accesskeys/keytips-screen-edge.png)

_画面の端によりキーのヒントの位置が自動的に変更される_

## <a name="key-tip-style"></a>キーのヒントのスタイル

プラットフォームのテーマ用に組み込まれているキーのヒントのサポート (ハイ コントラストなど) を使うことをお勧めします。

独自のキーのヒントのスタイルを指定する必要がある場合、KeyTipFontSize (フォント サイズ)、KeyTipFontFamily (フォント ファミリ)、KeyTipBackground (背景)、KeyTipForeground (前景)、KeyTipPadding (パディング)、KeyTipBorderBrush (境界線の色)、KeyTipBorderThemeThickness (境界線の太さ) などのアプリケーション リソースを使います。

![キーのヒントの配置モード](images/accesskeys/keytip-customization.png)

_キーのヒントのカスタマイズ オプション_

この例は、これらのアプリケーション リソースを変更する方法を示しています。

 ```xaml  
<Application.Resources>
  <SolidColorBrush Color="DarkGray" x:Key="MyBackgroundColor" />
  <SolidColorBrush Color="White" x:Key="MyForegroundColor" />
  <SolidColorBrush Color="Black" x:Key="MyBorderColor" />
  <StaticResource x:Key="KeyTipBackground" ResourceKey="MyBackgroundColor" />
  <StaticResource x:Key="KeyTipForeground" ResourceKey="MyForegroundColor" />
  <StaticResource x:Key="KeyTipBorderBrush" ResourceKey="MyBorderColor"/>
  <FontFamily x:Key="KeyTipFontFamily">Consolas</FontFamily>
  <x:Double x:Key="KeyTipContentThemeFontSize">18</x:Double>
  <Thickness x:Key="KeyTipBorderThemeThickness">2</Thickness>
  <Thickness x:Key="KeyTipThemePadding">4,4,4,4</Thickness>
</Application.Resources>
```

## <a name="access-keys-and-narrator"></a>アクセス キーとナレーター

XAML フレームワークには、UI オートメーション クライアントがユーザー インターフェイス内の要素に関する情報を検出できるようにするオートメーション プロパティが表示されます。

UIElement または TextElement コントロールで AccessKey プロパティを指定する場合、[AutomationProperties.AccessKey](https://msdn.microsoft.com/library/windows/apps/hh759763) プロパティを使ってこの値を取得できます。 ナレーターなどのアクセシビリティ クライアントは、要素がフォーカスを取得するたびにこのプロパティの値を読み取ります。

## <a name="related-articles"></a>関連記事

* [キーボード操作](keyboard-interactions.md)
* [キーボード アクセラレータ](keyboard-accelerators.md)

**サンプル**
* [XAML コントロール ギャラリー (別名 XamlUiBasics)](https://github.com/Microsoft/Windows-universal-samples/tree/c2aeaa588d9b134466bbd2cc387c8ff4018f151e/Samples/XamlUIBasics)


