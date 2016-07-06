---
author: Xansky
Description: "ハイ コントラスト テーマがアクティブになっているときにユニバーサル Windows プラットフォーム (UWP) アプリを使用できることを確かめるために必要な手順について説明します。"
ms.assetid: FD7CA6F6-A8F1-47D8-AA6C-3F2EC3168C45
title: "ハイ コントラスト テーマ"
label: High-contrast themes
template: detail.hbs
ms.sourcegitcommit: 50c37d71d3455fc2417d70f04e08a9daff2e881e
ms.openlocfilehash: 4201f5a0b08f1fc8d691218da0803ee04ab2c86a

---

# ハイ コントラスト テーマ  

ハイ コントラスト テーマがアクティブになっているときにユニバーサル Windows プラットフォーム (UWP) アプリを使用できることを確かめるために必要な手順について説明します。

UWP アプリは、ハイ コントラスト テーマを既定でサポートします。 ユーザーが、システム設定またはアクセシビリティ ツールでハイ コントラスト テーマが使われるように指定すると、色とスタイルの設定が自動的に変わって、UI のコントロールとコンポーネントにハイ コントラスト レイアウトおよびハイ コントラスト レンダリングが使われます。

この既定のサポートでは、既定のテーマとテンプレートを使います。 これらのテーマとテンプレートではシステム カラーをリソース定義として参照し、システムがハイ コントラスト モードに移行するとリソース ソースが自動的に変更されます。 ただし、コントロールにカスタムのテンプレート、テーマ、スタイルを使う場合は、ハイ コントラストに対して組み込まれているサポートを無効にしないよう注意してください。 スタイル指定に Microsoft Visual Studio 用のいずれかの XAML デザイナーを使っている場合は、既定のテンプレートと大幅に異なるテンプレートを定義するたびに、プライマリ テーマと共に、別のハイ コントラスト テーマが生成されます。 この別のテーマのディクショナリは、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) 要素の専用プロパティである [**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.resourcedictionary.themedictionaries.aspx) コレクションに入れられます。

テーマとコントロール テンプレートについて詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/Hh465374)」をご覧ください。 特定のコントロールの XAML リソース ディクショナリとテーマを調べたり、これらのテーマがどのように構築されているかを確認すると参考になります。またこれらのテーマが、利用可能な各ハイ コントラスト設定に対して、類似しているが異なるリソースをどのように参照しているかということを確認することも参考となります。

## テーマ ディクショナリ

システムの既定の色を変更したり、画像を装飾 (背景画像など) として追加したりする必要がある場合は、アプリ用に **ThemeDictionaries** コレクションを作成します。

* まず、適切なプラミングを作成します (プラミングがまだない場合)。 App.xaml で、**ThemeDictionaries** コレクションを次のように作成します。

``` xaml
 <Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called out below -->
            <ResourceDictionary x:Key="Default">

            </ResourceDictionary>
            <!-- HighContrast is used in any high contrast theme -->
            <ResourceDictionary x:Key="HighContrast">

            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources
```

* **HighContrast** のみが、利用可能なキー名というわけではありません。 **HighContrastBlack**、**HighContrastWhite**、**HighContrastCustom** も利用可能なキー名です。 ほとんどの場合、**HighContrast** が必要になります。
* **Default** では、必要な種類の [**Brush**](http://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.aspx) を作成します。通常は、**SolidColorBrush** です。 このクラスに対して、具体的な使用目的を示す **x:Key** 名を指定します。<br/>
    `<SolidColorBrush x:Key="BrandedPageBackground" />`
* 必要な **Color** を割り当てます。<br/>
    `<SolidColorBrush x:Key="BrandedPageBackground" Color="Red" />`
* この **Brush** を **HighContrast** にコピーします。

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackground" Color="Red" />
            </ResourceDictionary>
            <!-- HighContrast is used in any high contrast theme -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackground" Color="Red" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

* **Brush** の色を決定し、それに合わせて **HighContrast** でその色を変更します。

ハイ コントラストの色を決定するには、ハイ コントラストに関する知識が若干必要になります。 上で作成したプラミングを利用すると、簡単に更新することができます。

## ハイ コントラストの色

ユーザーは、設定ページを使用してハイ コントラストに切り替えることができます。 既定では 4 つのハイ コントラスト テーマがあります。 ユーザーがオプションを選ぶと、ページにはアプリでの色の状態を示すプレビューが表示されます。

![ハイ コントラスト設定](images/high-contrast-settings.png)<br/>
_ハイ コントラスト設定_

 プレビューに表示される各四角形をクリックすると、その値を変更できます。 各四角形は、システム リソースにも直接マップされています。

![ハイ コントラスト リソース](images/high-contrast-resources.png)<br/>
_ハイ コントラスト リソース_

上の図でコールアウトによって示されている名前に _SystemColor_ というプレフィックスを付け、_Color_ というポストフィックスを付けると (例: **SystemColorWindowTextColor**)、これらはユーザーの指定に合わせて動的に更新されます。 これにより、ハイ コントラスト用に特定の色を選ぶ必要がなくなります。 代わりに、使用される色に対応するシステム リソースを選びます。 上記の例では、ページの背景色の名前を **SolidColorBrushBrandedPageBackground** と指定しました。 この色は背景に使用されるため、これを、ハイ コントラストの **SystemColorWindowColor** にマップすることができます。

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackground" Color="Red" />
            </ResourceDictionary>
            <!-- HighContrast is used in any high contrast theme -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackground" Color="{ThemeResource SystemColorWindowColor}" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

8 つのハイ コントラストの色で構成されるパレットを引き続き使用する場合、追加のハイコントラスト **ResourceDictionaries** を作成する必要はありません。 この制限されたパレットでは、複雑な表示状態を表す場合に難しい問題が発生することがあります。 多くの場合、境界線をハイ コントラストの領域のみに追加することで、この問題に対処することができます。

### 推奨と非推奨

* ハイ コントラスト モードでのテストは、早い段階で行い、また頻繁に行います。
* 意図した目的に対応した名前付きの色を使用します。
* **ThemeDictionaries** 内では、**Color**、**Brush**、**Thickness** などのプリミティブを配置します。 **Style** 要素のような複雑なリソースは配置しないでください。 次の例は適切に機能します。

``` xaml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.ThemeDictionaries>
            <!-- Default is a fallback if a more precise theme isn't called out below -->
            <ResourceDictionary x:Key="Default">
                <SolidColorBrush x:Key="BrandedPageBackground" Color="Red" />
            </ResourceDictionary>
            <!-- HighContrast is used in any high contrast theme -->
            <ResourceDictionary x:Key="HighContrast">
                <SolidColorBrush x:Key="BrandedPageBackground" Color="{ThemeResource SystemColorWindowColor}" />
            </ResourceDictionary>
        </ResourceDictionary.ThemeDictionaries>

        <Style x:Key="MyButtonStyle" TargetType="Button">
            <Setter Property="Foreground" Value="{ThemeResource BrandedPageBackground}" />
        </Style>
    </ResourceDictionary>
</Application.Resources>

...

<Button Style="{StaticResource MyButtonStyle}" />
```

* 前景の UI 要素に対してハイ コントラストの前景色を使用します。
* ハイ コントラストの色は、対応する定義済みの色とペアで使用します。 たとえば、**BUTTONTEXT** は常に **BUTTONFACE** と共に使用します (特に前景や背景の場合)。
* 要求される 14:1 のコントラスト比を満たすために、特定の UI 要素に対しては、推奨されるハイ コントラストの色のペアを使用します。
* ハイ コントラストの色のペアを別々に使用したり、ハイ コントラストの色を任意に組み合わせたりしないでください。 このような操作をすると、1 つ以上のプリインストールされたハイ コントラスト テーマで、非表示の UI が作成される場合があります。
* **ThemeDictionaries** コレクションの外部で作成した **Brush** オブジェクトを配置しないでください。
* **StaticResource** を使用して、**ThemeDictionaries** コレクション内のリソースを参照しないでください。 このような参照方法は、アプリの実行中、ユーザーがテーマを変更するまでは機能しているように見えますが、テーマを変更すると機能しなくなります。 代わりに **ThemeResource** を使用してください。
* ハード コーディングされた色の値は使用しないでください。
* 好みの色という理由だけで色を使用しないでください。

詳しくは、「[XAML テーマ リソース](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/xaml-theme-resources)」をご覧ください。

## 境界線を使う状況
ハイ コントラスト モードでは、認識可能な境界の図形を項目内に維持する必要がある場合に、UI 要素に境界線を追加します。 境界線を使用して、ナビゲーションのコンテンツ領域と、操作、コンテンツを区別します。

![ページの他の部分と区別されたナビゲーション ウィンドウ](images/high-contrast-actions-content.png)<br/>
_ページの他の部分と区別されたナビゲーション ウィンドウ_

UI 要素に既定で境界線や背景が_ない_場合、ハイ コントラスト モードの既定の状態に境界線や背景を追加しないでください。

UI 要素に既定で境界線が_ある_場合、ハイ コントラスト モードの境界線を保持してください。

重なり合う色や隣接する色は相互に区別する必要がありますが、こうした色が、必ずしも 14:1 の色コントラスト比を満たすとは限りません。 ただし、このような種類のシナリオでは、3:1 のコントラスト比がベスト プラクティスです。

ハイ コントラストの背景色を使用して、重なり合う UI 要素を区別する場合、これらの要素間のコントラストを確保するための唯一の確実な方法は、境界線を導入することです。

## 有効にされたハイ コントラスト テーマの検出  
[
            **AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) クラスのメンバーを使って、ハイ コントラスト テーマの現在の設定を検出できます。 [
            **HighContrast**](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.accessibilitysettings.highcontrast) プロパティによって、ハイ コントラスト テーマが現在選ばれているかどうかを判断します。 **HighContrast** が **true** の場合は、次に、[**HighContrastScheme**](https://msdn.microsoft.com/library/windows/apps/windows.ui.viewmanagement.accessibilitysettings.highcontrastscheme) プロパティの値を確認し、使われているハイ コントラスト テーマの名前を取得します。 コードの応答が必要な **HighContrastScheme** の一般的な値は、"High Contrast White" と "High Contrast Black" です。 XAML で定義された [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/BR208794) キーにはスペースを含めることはできないため、リソース ディクショナリ内のこれらのテーマのキーは通常、それぞれ "HighContrastWhite" と "HighContrastBlack" になります。 値が別の文字列の場合に備えて、既定のハイ コントラスト テーマ用のフォールバック ロジックも必要です。 このロジックは、[XAML ハイ コントラスト サンプル](http://go.microsoft.com/fwlink/p/?linkid=254993)についてのページで紹介されています。

> [!NOTE]
> アプリが初期化され、既にコンテンツが表示されているスコープから [**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237) コンストラクターを呼び出すようにします。

実行中にハイ コントラスト リソース値を使うようにアプリを切り替えることができます。 この動作は、リソースがスタイルまたはテンプレート XAML で [{ThemeResource} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/Mt185591)を使って要求されている限り有効です。 既定のテーマ (generic.xaml) ではすべてこの {ThemeResource} マークアップ拡張手法が使われているため、既定のコントロール テーマを使う場合はこの動作が得られます。 また、カスタム テンプレートとスタイルでこの {ThemeResource} マークアップ拡張リソース手法を使っている場合は、カスタム コントロールまたはカスタム コントロールのスタイル設定でこれを実行できます。

## 関連トピック  
* [Accessibility (ユーザー補助機能)](accessibility.md)
* [UI コントラストと設定のサンプル](http://go.microsoft.com/fwlink/p/?linkid=231539)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [XAML ハイ コントラスト サンプル](http://go.microsoft.com/fwlink/p/?linkid=254993)
* [**AccessibilitySettings**](https://msdn.microsoft.com/library/windows/apps/BR242237)



<!--HONumber=Jun16_HO4-->


