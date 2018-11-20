---
author: Xansky
description: ハイ コントラスト テーマがアクティブになっているときにユニバーサル Windows プラットフォーム (UWP) アプリを使用できることを確かめるために必要な手順について説明します。
ms.assetid: FD7CA6F6-A8F1-47D8-AA6C-3F2EC3168C45
title: ハイ コントラスト テーマ
template: detail.hbs
ms.author: mhopkins
ms.date: 09/28/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7cf8b634cfc7ba66cde107150b54ecec76b2861d
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7417529"
---
# <a name="high-contrast-themes"></a>ハイ コントラスト テーマ  

Windows では、OS やアプリでハイ コントラスト テーマがサポートされていて、必要に応じて有効にすることができます。 ハイ コントラスト テーマは、少ない数のコントラスト カラーで構成されるパレットを使い、インターフェイスを見やすくします。

![淡色テーマと黒のハイ コントラスト テーマで表示された電卓。](images/high-contrast-calculators.png)

*淡色テーマと黒のハイ コントラスト テーマで表示された電卓*

ハイ コントラスト テーマに切り替えるには、*[設定]、[簡単操作]、[ハイ コントラスト]* の順に選択します。

> [!NOTE]
> ハイ コントラスト テーマは、淡色テーマおよび濃色テーマとは異なることに注意してください。淡色テーマと濃色テーマのカラー パレットは色の種類が豊富で、ハイ コントラストとは見なされません。 淡色テーマと濃色テーマについて詳しくは、「[色](../style/color.md)」をご覧ください。

コモン コントロールでは、ハイ コントラストが無償で完全にサポートされていますが、UI をカスタマイズする場合は注意する必要があります。 ハイ コントラストに関する最も一般的なバグは、コントロールにインラインで色をハードコーディングすることで生じます。

```xaml
<!-- Don't do this! -->
<Grid Background="#E6E6E6">

<!-- Instead, create BrandedPageBackgroundBrush and do this. -->
<Grid Background="{ThemeResource BrandedPageBackgroundBrush}">
```

最初の例で `#E6E6E6` をインラインで設定すると、グリッドはすべてのテーマでその背景色を保持します。 ユーザーが黒のハイ コントラスト テーマに切り替えたら、彼らはアプリの背景が黒で表示されることを期待します。 `#E6E6E6` はほぼ白一色であるため、ユーザーによってはアプリを操作できない場合があります。

2 番目の例では、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) 要素の専用プロパティである [**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.resourcedictionary.themedictionaries.aspx) コレクション内の色を参照するために [**{ThemeResource} マークアップ拡張**](../../xaml-platform/themeresource-markup-extension.md)を使っています。 **ThemeDictionaries** により、XAML はユーザーの現在のテーマに基づいて自動的に色を変えることができます。

## <a name="theme-dictionaries"></a>テーマ ディクショナリ

システムの既定の色を変更する必要がある場合は、アプリの ThemeDictionaries コレクションを作成します。

1. まず、適切なプラミングを作成します (プラミングがまだない場合)。 App.xaml で、少なくとも **Default** と **HighContrast** を含む **ThemeDictionaries** コレクションを作成します。
2. **Default** では、必要な種類の [Brush](http://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.aspx) を作成します。通常は、**SolidColorBrush** です。 このクラスに対して、具体的な使用目的を示す *x:Key* 名を指定します。
3. 必要な **Color** を割り当てます。
4. この **Brush** を **HighContrast** にコピーします。

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called
            out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- Optional, Light is used in light theme.
            If included, Default will be used for Dark theme -->
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- HighContrast is used in all high contrast themes -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

最後に、ハイ コントラストで使用する色を決定します。これについては、次のセクションで説明します。

> [!NOTE]
> **HighContrast** のみが、利用可能なキー名というわけではありません。 **HighContrastBlack**、**HighContrastWhite**、**HighContrastCustom** も利用可能なキー名です。 ほとんどの場合、**HighContrast** が必要になります。

## <a name="high-contrast-colors"></a>ハイ コントラストの色

*[設定]、[簡単操作]、[ハイ コントラスト]* の順に選択すると、既定の 4 つのハイ コントラスト テーマが表示されます。 


![ハイ コントラスト設定](images/high-contrast-settings.png)  

*ユーザーがオプションを選ぶと、ページにはプレビューが表示されます。*  

![ハイ コントラスト リソース](images/high-contrast-resources.png)  

*プレビューに表示される色の見本をクリックすると、その値を変更できます。 また各見本は、XAML のカラー リソースに直接マップされます。*  

各 **SystemColor*Color** リソースは、ユーザーがハイ コントラスト テーマに切り替えたときに自動的に色を更新する変数です。 各リソースをいつどこで使用するかについてのガイドラインを以下に示します。

リソース | 用途 |
|--------|-------|
**SystemColorWindowTextColor** | 本文、見出し、一覧など、操作できないテキスト |
| **SystemColorHotlightColor** | ハイパーリンク |
| **SystemColorGrayTextColor** | 無効な UI |
| **SystemColorHighlightTextColor** | 処理中、選択されている、または現在操作されているテキストや UI の前景色 |
| **SystemColorHighlightColor** | 処理中、選択されている、または現在操作されているテキストや UI の背景色 |
| **SystemColorButtonTextColor** | ボタンなど、操作可能な UI の前景色 |
| **SystemColorButtonFaceColor** | ボタンなど、操作可能な UI の背景色 |
| **SystemColorWindowColor** | ページ、ウィンドウ、ポップアップ、およびバーの背景 |

既存のアプリ、スタート画面、またはコモン コントロールを確認すると、ハイ コントラストのデザインの参考になります。

**推奨される事項**

* 可能な限り、背景と前景の組み合わせを考慮します。
* アプリの実行中に、4 つのハイ コントラスト テーマをすべてテストします。 ユーザーがテーマを切り替えたときに、アプリを再起動しなくても良いようにします。
* 一貫性を保ちます。

**非推奨**

* **SystemColor*Color** リソースを使って **HighContrast** テーマの色をハードコーディングしないようにします。
* 見栄えを良くすることを目的としてカラー リソースを選ばないようにします。 カラー リソースはテーマによって変わることに注意してください。
* **SystemColorGrayTextColor** を、セカンダリ テキストの本文やヒント目的の本文に使用しないようにします。


先ほどの例を続けるには、**BrandedPageBackgroundBrush** のリソースを選択する必要があります。 背景に使用されることを名前が示しているため、**SystemColorWindowColor** が最適です。

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called
            out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- Optional, Light is used in light theme.
            If included, Default will be used for Dark theme -->
            <ResourceDictionary x:Key="Light">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="#E6E6E6" />
            </ResourceDictionary>

            <!-- HighContrast is used in all high contrast themes -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackgroundBrush" Color="{ThemeResource SystemColorWindowColor}" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

その後、アプリで背景を設定できます。

```xaml
<Grid Background="{ThemeResource BrandedPageBackgroundBrush}">
```

**\{ThemeResource\}** は、**SystemColorWindowColor** の参照と **BrandedPageBackgroundBrush** の参照とで、2 回使われることに注意してください。 実行時に正しいテーマを使うためには、両方の参照がアプリに必要です。 ここで、アプリでハイ コントラストの機能をテストすると良いでしょう。 ハイ コントラスト テーマに切り替えると、グリッドの背景が自動的に更新されます。 また、別のハイ コントラスト テーマに切り替えたときにも更新されます。

## <a name="when-to-use-borders"></a>境界線を使う状況

ページ、ウィンドウ、ポップアップ、およびバーでは、ハイ コントラストの背景に **SystemColorWindowColor** を使う必要があります。 UI で重要な境界を維持する必要がある場合、ハイ コントラストのみの境界線を追加します。

![ページの他の部分と区別されたナビゲーション ウィンドウ](images/high-contrast-actions-content.png)  

*ナビゲーション ウィンドウとページはハイ コントラストで同じ背景色を共有するので、 分割するには、ハイ コントラストのみの境界線が不可欠です。*


## <a name="list-items"></a>リスト項目

ハイ コントラストでは、ポイント、押下、または選択時に [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) の項目の背景が **SystemColorHighlightColor** に設定されます。 複雑なリスト項目では、項目のポイント、押下、選択時に色の反転に失敗するというバグがよく生じ、 項目が読めなくなってしまいます。

![単色テーマと黒のハイ コントラスト テーマの簡単なリスト](images/high-contrast-list1.png)

*淡色テーマ (左) と黒のハイ コントラスト テーマ (右) の簡単なリスト。 2 番目の項目が選択されています。テキストの色が、ハイ コントラストでは反転されていることに注目してください。*


### <a name="list-items-with-colored-text"></a>テキストに色が付いているリスト項目

問題の原因の 1 つが、ListView の [DataTemplate](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) で TextBlock.Foreground を設定することです。 TextBlock.Foreground は一般的に、視覚的な階層を確立するために設定します。 Foreground プロパティは [ListViewItem](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewitem.aspx) で設定され、DataTemplate 内の TextBlock は、項目がポイント、押下、または選択されたときに適切な Foreground 色を継承します。 ところが、Foreground を設定すると継承が中断されてしまいます。

![淡色テーマと黒のハイ コントラスト テーマの複雑なリスト](images/high-contrast-list2.png)

*淡色テーマ (左) と黒のハイ コントラスト テーマ (右) の複雑なリスト。 ハイ コントラストでは、選択された項目の 2 行目が反転に失敗しています。*  

この問題を回避するには、**ThemeDictionaries** コレクションに含まれている Style を使って、条件付きで Foreground を設定します。 **Foreground** が、**HighContrast** の **SecondaryBodyTextBlockStyle** によって設定されていないため、色が正しく反転します。

```xaml
<!-- In App.xaml... -->
<ResourceDictionary.ThemeDictionaries>
    <ResourceDictionary x:Key="Default">
        <Style
            x:Key="SecondaryBodyTextBlockStyle"
            TargetType="TextBlock"
            BasedOn="{StaticResource BodyTextBlockStyle}">
            <Setter Property="Foreground" Value="{StaticResource SystemControlForegroundBaseMediumBrush}" />
        </Style>
    </ResourceDictionary>

    <ResourceDictionary x:Key="Light">
        <Style
            x:Key="SecondaryBodyTextBlockStyle"
            TargetType="TextBlock"
            BasedOn="{StaticResource BodyTextBlockStyle}">
            <Setter Property="Foreground" Value="{StaticResource SystemControlForegroundBaseMediumBrush}" />
        </Style>
    </ResourceDictionary>

    <ResourceDictionary x:Key="HighContrast">
        <!-- The Foreground Setter is omitted in HighContrast -->
        <Style
            x:Key="SecondaryBodyTextBlockStyle"
            TargetType="TextBlock"
            BasedOn="{StaticResource BodyTextBlockStyle}" />
    </ResourceDictionary>
</ResourceDictionary.ThemeDictionaries>

<!-- Usage in your DataTemplate... -->
<DataTemplate>
    <StackPanel>
        <TextBlock Style="{StaticResource BodyTextBlockStyle}" Text="Double line list item" />

        <!-- Note how ThemeResource is used to reference the Style -->
        <TextBlock Style="{ThemeResource SecondaryBodyTextBlockStyle}" Text="Second line of text" />
    </StackPanel>
</DataTemplate>
```


## <a name="detecting-high-contrast"></a>ハイ コントラストを検出する

[**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) クラスのメンバーを使えば、現在のテーマがハイ コントラストであるかどうかをプログラムで確認することができます。

> [!NOTE]
> アプリが初期化され、既にコンテンツが表示されているスコープから **AccessibilitySettings** コンストラクターを呼び出すようにします。

## <a name="related-topics"></a>関連トピック  
* [アクセシビリティ](accessibility.md)
* [UI コントラストと設定のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231539)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [XAML ハイ コントラスト サンプル](http://go.microsoft.com/fwlink/p/?linkid=254993)
* [**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237)
