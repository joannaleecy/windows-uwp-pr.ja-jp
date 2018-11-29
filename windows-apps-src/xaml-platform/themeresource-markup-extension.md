---
description: 現在アクティブなテーマに応じて異なるリソースを取得する追加のシステム ロジックと共に、リソースへの参照を評価して任意の XAML 属性の値を提供します。
title: ThemeResource マークアップ拡張
ms.assetid: 8A1C79D2-9566-44AA-B8E1-CC7ADAD1BCC5
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9466ec598fad090e31768d680b64ffea52688844
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7981882"
---
# <a name="themeresource-markup-extension"></a>{ThemeResource} マークアップ拡張

現在アクティブなテーマに応じて異なるリソースを取得する追加のシステム ロジックと共に、リソースへの参照を評価して任意の XAML 属性の値を提供します。 [{StaticResource} マークアップ拡張](staticresource-markup-extension.md)と同様、リソースは [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) で定義されており、**ThemeResource** の使用は **ResourceDictionary** 内のそのリソースのキーを参照します。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object property="{ThemeResource key}" .../>
```

## <a name="xaml-values"></a>XAML 値

| 用語 | 説明 |
|------|-------------|
| key | 要求されたリソースのキー。 このキーは、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) によって最初に割当てられます。 リソース キーとしては、XamlName の文法で定義されている任意の文字列を使うことができます。 |

## <a name="remarks"></a>注釈

**ThemeResource** は、XAML リソース ディクショナリ内の別の場所で定義されている XAML 属性の値を取得するための手法です。 このマークアップ拡張は、[{StaticResource} マークアップ拡張](staticresource-markup-extension.md)と同じ基本的な目的を果たします。 {StaticResource} マークアップ拡張との動作の違いとして、**ThemeResource** 参照では、システムによってどのテーマが現在使われているかに応じて、一次検索場所として異なるディクショナリを動的に使うことができます。

アプリが最初に起動されると、**ThemeResource** 参照によって行われたすべてのリソース参照が、起動時に使われたテーマに基づいて評価されます。 ただし、ユーザーが後で実行時にアクティブなテーマを変更した場合、システムは、すべての **ThemeResource** 参照を再評価し、(異なっている可能性のある) テーマに固有のリソースを取得した後、ビジュアル ツリーのすべての適切な場所に新しいリソース値を持つアプリを再表示します。 **StaticResource** は、XAML の読み込み時またはアプリの起動時に判定され、実行時には再評価されません  (XAML を動的に再読み込みする表示状態などの他の方法もありますが、これらの方法は、基本的なリソースの評価が [{StaticResource} マークアップ拡張](staticresource-markup-extension.md)によって有効化されるより高いレベルで動作します)。

**ThemeResource** は、要求されたリソースについてキーを指定する 1 個の引数を受け取ります。 リソース キーは常に、Windows ランタイム XAML の文字列です。 リソース キーを最初に指定する方法について詳しくは、「[x:Key 属性](x-key-attribute.md)」をご覧ください。

リソースの定義方法と [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) の適切な使用方法 (サンプル コードを含む) について詳しくは、「[ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)」をご覧ください。

**重要** **StaticResource** と同様、**ThemeResource** は、XAML ファイルの中で辞書的に定義されているリソースへの前方参照を行うことはできません。 そのようなことを試みることはサポートしていません。 前方参照が失敗しなかったとしても、そのようなことを試みるだけでパフォーマンスの低下を招きます。 最善の結果を得るには、前方参照を避けるようにリソース ディクショナリの構成を調整します。

解決できないキーに **ThemeResource** を指定しようとすると、実行時に XAML 解析例外がスローされます。 デザイン ツールでも、警告やエラーが通知されることがあります。

Windows ランタイム XAML プロセッサの実装では、**ThemeResource** のバッキング クラス表現はありません。 コードで最も近いのは、[**Contains**](https://msdn.microsoft.com/library/windows/apps/jj635925) または [**TryGetValue**](https://msdn.microsoft.com/library/windows/apps/jj603139) を呼び出すなど、[**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) のコレクション API を使うことです。

**ThemeResource** はマークアップ拡張です。 通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。 XAML のすべてのマークアップ拡張では、それぞれの属性構文で "{" と "}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。

### <a name="when-and-how-to-use-themeresource-rather-than-staticresource"></a>{StaticResource} ではなく {ThemeResource} を使う状況とその方法

**ThemeResource** がリソース ディクショナリの項目に解決される規則は、通常、**StaticResource** の場合と同じです。 **ThemeResource** 検索は [**ThemeDictionaries**](https://msdn.microsoft.com/library/windows/apps/br208807) のコレクションで参照される [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794) ファイルまで拡張できます。これは、**StaticResource** の場合も同じです。 その違いは、**ThemeResource** では実行時に再評価を行うことができるのに対し、**StaticResource** では再評価を行うことができない点にあります。

各テーマ ディクショナリのキー セットでは、どのテーマがアクティブであるかに関係なく、キーを持つリソースの同じセットを提供する必要があります。 特定のキーを持つリソースが **HighContrast** テーマ ディクショナリに存在する場合、**Light** と **Default** にも同じ名前を持つ別のリソースが存在する必要があります。 そうでないと、ユーザーがテーマを切り替えたときにリソース検索が失敗し、アプリが適切に表示されなくなります。 テーマ ディクショナリには、サブ値を指定するために同じスコープ内からのみ参照されるキーを持つリソースを含めることができます。ただし、これらはすべてのテーマで等価である必要はありません。

通常は、リソースをテーマ ディクショナリに格納し、これらの値がテーマごとに変化するときや、変化する値によってサポートされているときにのみ、**ThemeResource** を使ってこれらのリソースを参照します。 これは、次の種類のリソースに適しています。

-   ブラシ。特に [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) の色。 この使い方は、既定の XAML コントロール テンプレート (generic.xaml) において **ThemeResource** の約 80% を占めています。
-   境界線、オフセット、余白、パディングなどのピクセル値。
-   **FontFamily**、**FontSize** などのフォント プロパティ。
-   通常システムによってスタイルが設定され、動的な表示に使われる、限られた数のコントロールの完全なテンプレート ([**GridViewItem**](https://msdn.microsoft.com/library/windows/apps/hh738501)、[**ListViewItem**](https://msdn.microsoft.com/library/windows/apps/br242919) など)。
-   テキスト表示スタイル (通常はフォントの色、背景、サイズを変更する目的で使われます)。

Windows ランタイムには、特に **ThemeResource** から参照するためのリソースのセットが用意されています。 これらはすべて、Windows ソフトウェア開発キット (Windows SDK) の include/winrt/xaml/design フォルダーにある XAML ファイル themeresources.xaml に記載されています。 themeresources.xaml に定義されているテーマ ブラシと追加のスタイルについて詳しくは、「[XAML テーマ リソース リファレンス](https://msdn.microsoft.com/library/windows/apps/mt187274)」をご覧ください。 ブラシについては、アクティブになる可能性のある 3 種類のテーマごとに、各ブラシの色の値を表形式で示しています。

コントロール テンプレートの表示状態の XAML 定義では、テーマの変更によって変更される可能性がある基になるリソースがある場合は常に **ThemeResource** 参照を使う必要があります。 通常、システム テーマが変更されても、表示状態の変更は発生しません。 この場合、リソースでは、**ThemeResource** 参照を使って、依然アクティブな表示状態に対して値を再評価できるようにする必要があります。 たとえば、特定の UI 部分のブラシの色とそのプロパティの 1 つを変更する表示状態があり、そのブラシの色がテーマごとに異なる場合は、**ThemeResource** 参照を使って、既定のテンプレートのこのプロパティ値と、その既定のテンプレートに対する表示状態の変更を提供する必要があります。

**ThemeResource** は、一連の依存型の値で使われる場合があります。 たとえば、キーを持つリソースである [**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) で使われる [**Color**](https://msdn.microsoft.com/library/windows/apps/hh673723) で **ThemeResource** 参照を使うことがあります。 ただし、キーを持つ **SolidColorBrush** リソースを使う任意の UI プロパティで **ThemeResource** 参照を使うこともあります。この場合、テーマが変更されたときに動的な値の変更を可能にするのはそれぞれの [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) タイプのプロパティです。

**注:** `{ThemeResource}`とテーマ切り替えの実行時のリソースの評価が Windows8.1 XAML でサポートされていますが、Windows8 をターゲットとするアプリの XAML でサポートされていません。

### <a name="system-resources"></a>システム リソース

一部のテーマ リソースは、システム リソース値を基になるサブ値として参照します。 システム リソースは、どの XAML リソース ディクショナリにも含まれていない特殊なリソース値です。 これらの値は、Windows ランタイム XAML サポートの動作に依存してシステム自体から値を転送し、XAML リソースが参照できる形式でその値を表します。 たとえば、"SystemColorButtonFaceColor" という名前の、RGB 色を表すシステム リソースがあります。 この色は、Windows ランタイムと Windows ランタイム アプリだけに限定されないシステム カラーとテーマの観点に基づきます。

通常、システム リソースは、ハイ コントラスト テーマの基になる値です。 ユーザーはハイ コントラスト テーマの色の選択を管理します。ユーザーは、同様に Windows ランタイム アプリに固有ではないシステム機能を使って、これらの選択を行います。 システム リソースを **ThemeResource** 参照として参照すると、Windows ランタイム アプリのハイ コントラスト テーマの既定の動作で、ユーザーによって制御されシステムによって公開される、テーマに固有のこれらの値を使うことができます。 また、これらの参照は、システムによって実行時のテーマの変更が検出された場合に再評価のマークが付けられます。

### <a name="an-example-themeresource-usage"></a>{ThemeResource} の使用例

**ThemeResource** の使い方の例として、既定の generic.xaml ファイルと themeresources.xaml ファイルから抜粋した XAML の例を示します。 ここでは、1 つのテンプレート (既定の [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265)) と、テーマの変更に対応するための 2 つのプロパティ ([**Background**](https://msdn.microsoft.com/library/windows/apps/br209395) と [**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414)) の宣言方法について注目します。

```xml
    <!-- Default style for Windows.UI.Xaml.Controls.Button -->
    <Style TargetType="Button">
        <Setter Property="Background" Value="{ThemeResource ButtonBackgroundThemeBrush}" />
        <Setter Property="Foreground" Value="{ThemeResource ButtonForegroundThemeBrush}"/>
...
```

ここで、これらのプロパティは [**Brush**](/uwp/api/Windows.UI.Xaml.Media.Brush) 値を受け取ります。[**SolidColorBrush**](https://msdn.microsoft.com/library/windows/apps/br242962) リソース (`ButtonBackgroundThemeBrush` と `ButtonForegroundThemeBrush`) の参照には、**ThemeResource** が使われています。

これらの同じプロパティは、[**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) の表示状態のいくつかによっても調整されます。 特に、背景色は、ボタンをクリックしたときに変更されます。 同様に、表示状態のストーリーボードの [**Background**](https://msdn.microsoft.com/library/windows/apps/br209395) と [**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414) のアニメーションでは、[**DiscreteObjectKeyFrame**](https://msdn.microsoft.com/library/windows/apps/br243132) オブジェクトと共に、キー フレーム値として **ThemeResource** を含むブラシへの参照を使っています。

```xml
<VisualState x:Name="Pressed">
  <Storyboard>
    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Border"
        Storyboard.TargetProperty="Background">
      <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonPressedBackgroundThemeBrush}" />
    </ObjectAnimationUsingKeyFrames>
    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
         Storyboard.TargetProperty="Foreground">
       <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource ButtonPressedForegroundThemeBrush}" />
    </ObjectAnimationUsingKeyFrames>
  </Storyboard>
</VisualState>
```

これらのブラシはそれぞれ generic.xaml で事前に定義されています。XAML の前方参照を避けるためには、これらのブラシは、これを使う任意のテンプレートに先だって定義されている必要があります。 "Default" テーマ ディクショナリのための定義を次に示します。

```xml
    <ResourceDictionary.ThemeDictionaries>
        <ResourceDictionary x:Key="Default">
...
            <SolidColorBrush x:Key="ButtonBackgroundThemeBrush" Color="Transparent" />
            <SolidColorBrush x:Key="ButtonForegroundThemeBrush" Color="#FFFFFFFF" />
...
            <SolidColorBrush x:Key="ButtonPressedBackgroundThemeBrush" Color="#FFFFFFFF" />
            <SolidColorBrush x:Key="ButtonPressedForegroundThemeBrush" Color="#FF000000" />
...
```

他の各テーマ ディクショナリにも、次に示すようにこれらのブラシが定義されています。

```xml
        <ResourceDictionary x:Key="HighContrast">
            <!-- High Contrast theme resources -->
...
            <SolidColorBrush x:Key="ButtonBackgroundThemeBrush" Color="{ThemeResource SystemColorButtonFaceColor}" />
            <SolidColorBrush x:Key="ButtonForegroundThemeBrush" Color="{ThemeResource SystemColorButtonTextColor}" />

...
            <SolidColorBrush x:Key="ButtonPressedBackgroundThemeBrush" Color="{ThemeResource SystemColorButtonTextColor}" />
            <SolidColorBrush x:Key="ButtonPressedForegroundThemeBrush" Color="{ThemeResource SystemColorButtonFaceColor}" />
```

この [**Color**](/uwp/api/Windows.UI.Xaml.Media.SolidColorBrush.Color) 値は、システム リソースに対するもう 1 つの **ThemeResource** 参照です。 システム リソースを参照し、テーマの変更に応じてシステム リソースを変更する場合は、**ThemeResource** を使って参照を行う必要があります。

## <a name="windows8-behavior"></a>Windows8 動作

Windows8 **ThemeResource**マークアップ拡張をサポートしていませんが、Windows8.1 で利用できます。 また、Windows8 では、Windows ランタイム アプリのテーマに関連するリソースを動的に切り替えしなかったできません。 XAML テンプレートとスタイルのテーマ変更を認識するには、アプリを再起動する必要がありました。 これは、手順は、優れたユーザー エクスペリエンスのため、アプリは、再コンパイルしてターゲット Windows8.1 を強くお勧めできるように、 **ThemeResource**使用法とスタイルを使用してには、ユーザーがときに、テーマを動的に切り替えることができます。 Windows8 が Windows8.1 で実行されている Windows8 動作を使い続けるためにコンパイルされたアプリ。

## <a name="design-time-tools-support-for-the-themeresource-markup-extension"></a>設計時ツールの **{ThemeResource}** マークアップ拡張のサポート

Microsoft Visual Studio2013 は、XAML ページで、 **{ThemeResource}** マークアップ拡張機能を使用する場合、Microsoft IntelliSense のドロップダウンに可能なキー値を含めることができます。 たとえば、「{ThemeResource」と入力するとすぐに、[XAML テーマ リソース](https://msdn.microsoft.com/library/windows/apps/mt187274)のリソース キーが表示されます。

**{ThemeResource}** の一部としてリソース キーが存在すると、**[定義へ移動]** (F12 キー) 機能でそのリソースを解決して、テーマ リソースが定義されている設計時の generic.xaml を表示できます。 テーマ リソースを何度も定義されるため (テーマごとに)、**[定義へ移動]** ではファイルで見つかった最初の定義に移動します。これは **Default** の定義です。 他の定義が必要な場合は、ファイル内のキー名を検索して、他のテーマの定義を参照できます。

## <a name="related-topics"></a>関連トピック

* [ResourceDictionary と XAML リソースの参照](https://msdn.microsoft.com/library/windows/apps/mt187273)
* [XAML テーマ リソース](https://msdn.microsoft.com/library/windows/apps/mt187274)
* [**ResourceDictionary**](https://msdn.microsoft.com/library/windows/apps/br208794)
* [x:Key 属性](x-key-attribute.md)
 

