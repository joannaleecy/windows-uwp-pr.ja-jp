---
author: Jwmsft
Description: "スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。"
MS-HAID: dev\_ctrl\_layout\_txt.styling\_controls
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "XAML スタイル"
ms.assetid: AB469A46-FAF5-42D0-9340-948D0EDF4150
label: XAML styles
template: detail.hbs
translationtype: Human Translation
ms.sourcegitcommit: eb6744968a4bf06a3766c45b73b428ad690edc06
ms.openlocfilehash: 3aad0049bdd43935fa61b6146b81030494ff5bdb

---
# XAML スタイル

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 



XAML フレームワークを使って、さまざまな方法でアプリの外観をカスタマイズできます。 スタイルを使うと、コントロールのプロパティに値を設定し、その設定を再利用することで、複数のコントロールの外観を統一できます。

## スタイルの基本

スタイルを使うと、視覚的なプロパティの設定を、再利用可能なリソースとして抽出できます。 次の例は、[**BorderBrush**](https://msdn.microsoft.com/library/windows/apps/br209397)、[**BorderThickness**](https://msdn.microsoft.com/library/windows/apps/br209399)、[**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414) の各プロパティを設定するスタイルを適用した 3 つのボタンを示しています。 スタイルを適用することで、これらのプロパティを各コントロールで個別に設定しなくて済み、また、コントロールに同じ外観を持たせることができます。

![スタイルを適用したボタン](images/styles-rainbow-buttons.png)

スタイルは、XAML を使ってコントロールに対してインラインで定義するか、再利用可能なリソースとして定義できます。 リソースは、個々のページの XAML ファイル、App.xaml ファイル、別個のリソース ディクショナリ XAML ファイルのいずれかに定義します。 リソース ディクショナリ XAML ファイルはアプリ間で共有できます。また、単一のアプリで複数のリソース ディクショナリをマージすることも可能です。 リソースを定義する場所は、リソースが使われる範囲によって決まります。 ページ レベルのリソースは定義元のページでしか利用できません。 App.xaml とページ内の両方で同じキーが定義されている場合、ページ内のリソースが App.xaml 内のリソースよりも優先されます。 リソースが別個のリソース ディクショナリ ファイルで定義されている場合、そのスコープはリソース ディクショナリが参照される場所によって決まります。

[**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) の定義では、1 つの [**TargetType**](https://msdn.microsoft.com/library/windows/apps/br208857) 属性と、1 つ以上の [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 要素が必要になります。 **TargetType** 属性は、スタイルを適用する [**FrameworkElement**](https://msdn.microsoft.com/library/windows/apps/br208706) 型を指定する文字列です。 **TargetType** の値では、Windows ランタイムか、参照先アセンブリ内で使用できるカスタム型で定義される **FrameworkElement** から派生した型を指定する必要があります。 適用しようとしているスタイルの **TargetType** 属性の指定内容と異なるコントロールやコントロールの型にスタイルを適用しようとすると、例外が発生します。

それぞれの [**Setter**](https://msdn.microsoft.com/library/windows/apps/br208817) 要素に、[**Property**](https://msdn.microsoft.com/library/windows/apps/br208836) と [**Value**](https://msdn.microsoft.com/library/windows/apps/br208838) が必要です。 この 2 つのプロパティは、それぞれ、その設定が適用されるコントロールのプロパティと、そのプロパティに対して設定される値を指定します。 **Setter.Value** は、属性構文またはプロパティ要素構文を使って設定できます。 次の XAML は前に示したボタンに適用されたスタイルを示しています。 この XAML では、最初の 2 つの **Setter** 要素に属性構文を使っていますが、[**BorderBrush**](https://msdn.microsoft.com/library/windows/apps/br209397) プロパティ用の最後の **Setter** にはプロパティ要素構文を使っています。 この例では [x:Key attribute](../xaml-platform/x-key-attribute.md) 属性を使っていないため、スタイルはボタンに対して暗黙的に適用されます。 スタイルの暗黙的または明示的な適用については、次のセクションで説明します。

```XAML
<Page.Resources>
    <Style TargetType="Button">
        <Setter Property="BorderThickness" Value="5" />
        <Setter Property="Foreground" Value="Blue" />
        <Setter Property="BorderBrush" >
            <Setter.Value>
                <LinearGradientBrush StartPoint="0.5,0" EndPoint="0.5,1">
                    <GradientStop Color="Yellow" Offset="0.0" />
                    <GradientStop Color="Red" Offset="0.25" />
                    <GradientStop Color="Blue" Offset="0.75" />
                    <GradientStop Color="LimeGreen" Offset="1.0" />
                </LinearGradientBrush>
            </Setter.Value>
        </Setter>
    </Style>
</Page.Resources>

<StackPanel Orientation="Horizontal">
    <Button Content="Button"/>
    <Button Content="Button"/>
    <Button Content="Button"/>
</StackPanel>
```

## 暗黙的または明示的なスタイルの適用

スタイルをリソースとして定義した場合、それをコントロールに適用するには 2 つの方法があります。

-   暗黙的な適用。[**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) に対して [**TargetType**](https://msdn.microsoft.com/library/windows/apps/br208857) のみを指定します。
-   明示的な適用。[**Style**](https://msdn.microsoft.com/library/windows/apps/br208849) に対して [**TargetType**](https://msdn.microsoft.com/library/windows/apps/br208857) と [x:Key attribute](../xaml-platform/x-key-attribute.md) 属性を設定した後、ターゲット コントロールの [**Style**](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティに、明示的キーを使う [{StaticResource} マークアップ拡張](https://msdn.microsoft.com/library/windows/apps/mt185588)参照を設定します。

スタイルに [x:Key attribute](../xaml-platform/x-key-attribute.md) 属性が含まれる場合、そのスタイルをコントロールに適用するには、コントロールの [**Style**](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティをキーで指定されたスタイルに設定する必要があります。 一方、x:Key attribute 属性を含まないスタイルは、ターゲットとなる型のすべてのコントロールに自動的に適用されます。それ以外の場合、これには明示的なスタイル設定がありません。

次の 2 つのボタンは、暗黙的なスタイルと明示的なスタイルを示しています。

![暗黙的および明示的にスタイルが適用されたボタン。](images/styles-buttons-implicit-explicit.png)

この例では、最初のスタイルには [x:Key attribute](../xaml-platform/x-key-attribute.md) 属性が含まれ、ターゲットとなる型は [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) です。 最初のボタンの [**Style**](https://msdn.microsoft.com/library/windows/apps/br208743) プロパティはこのキーに設定されているため、このスタイルは明示的に適用されます。 2 番目のスタイルは、ターゲットとなる型が **Button** で、スタイルに x:Key 属性が含まれないため、2 番目のボタンに暗黙的に適用されます。

```XAML
<Page.Resources>
    <Style x:Key="PurpleStyle" TargetType="Button">
        <Setter Property="FontFamily" Value="Lucida Sans Unicode"/>
        <Setter Property="FontStyle" Value="Italic"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="Foreground" Value="MediumOrchid"/>
    </Style>

    <Style TargetType="Button">
        <Setter Property="FontFamily" Value="Lucida Sans Unicode"/>
        <Setter Property="FontStyle" Value="Italic"/>
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="RenderTransform">
            <Setter.Value>
                <RotateTransform Angle="25"/>
            </Setter.Value>
        </Setter>
        <Setter Property="BorderBrush" Value="Orange"/>
        <Setter Property="BorderThickness" Value="2"/>
        <Setter Property="Foreground" Value="Orange"/>
    </Style>
</Page.Resources>

<Grid x:Name="LayoutRoot">
    <Button Content="Button" Style="{StaticResource PurpleStyle}"/>
    <Button Content="Button" />
</Grid>
```

## 継承スタイルの使用

スタイルを管理しやすくし、スタイルの再利用を最適化するために、他のスタイルから継承するスタイルを作成できます。 継承したスタイルを作成するには、[**BasedOn**](https://msdn.microsoft.com/library/windows/apps/br208852) プロパティを使います。 他のスタイルから継承するスタイルは、同じ型のコントロール、または基本スタイルのターゲットとなる型から派生したコントロールをターゲットとする必要があります。 たとえば、基本スタイルのターゲットが [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/br209365) である場合、このスタイルに基づくスタイルは、**ContentControl**、または **ContentControl** から派生した型 ([**Button**](https://msdn.microsoft.com/library/windows/apps/br209265)、[**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/br209527) など) をターゲットにできます。 継承スタイルに対して設定しない値は、基本スタイルから継承されます。 基本スタイルから値を変更するには、継承スタイルに値を設定して上書きします。 次の例は、同じ基本スタイルから継承したスタイルを持つ **Button** と [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) を示しています。

![継承スタイルを使ってスタイルを適用したボタン。](images/styles-buttons-based-on.png)

基本スタイルは [**ContentControl**](https://msdn.microsoft.com/library/windows/apps/br209365) をターゲットとし、[**Height**](https://msdn.microsoft.com/library/windows/apps/br208718) プロパティと [**Width**](https://msdn.microsoft.com/library/windows/apps/br208751) プロパティを設定します。 このスタイルに基づくスタイルは、**ContentControl** から派生した [**CheckBox**](https://msdn.microsoft.com/library/windows/apps/br209316) と [**Button**](https://msdn.microsoft.com/library/windows/apps/br209265) をターゲットとします。 各継承スタイルでは、[**BorderBrush**](https://msdn.microsoft.com/library/windows/apps/br209397) プロパティと [**Foreground**](https://msdn.microsoft.com/library/windows/apps/br209414) プロパティに異なる色を設定しています。 (通常、**CheckBox** の周囲には境界線を配置しません。 ここでは、スタイルの効果を示すためにこのように設定しています)。

```XAML
<Page.Resources>
    <Style x:Key="BasicStyle" TargetType="ContentControl">
        <Setter Property="Width" Value="130" />
        <Setter Property="Height" Value="30" />
    </Style>

    <Style x:Key="ButtonStyle" TargetType="Button"
           BasedOn="{StaticResource BasicStyle}">
        <Setter Property="BorderBrush" Value="Orange" />
        <Setter Property="BorderThickness" Value="2" />
        <Setter Property="Foreground" Value="Red" />
    </Style>

    <Style x:Key="CheckBoxStyle" TargetType="CheckBox"
           BasedOn="{StaticResource BasicStyle}">
        <Setter Property="BorderBrush" Value="Blue" />
        <Setter Property="BorderThickness" Value="2" />
        <Setter Property="Foreground" Value="Green" />
    </Style>
</Page.Resources>

<StackPanel>
    <Button Content="Button" Style="{StaticResource ButtonStyle}" Margin="0,10"/>
    <CheckBox Content="CheckBox" Style="{StaticResource CheckBoxStyle}"/>
</StackPanel>
```

## ツールを使ってスタイルを簡単に操作

コントロールにスタイルをすばやく適用する方法の 1 つは、Microsoft Visual Studio の XAML デザイン サーフェイスでコントロールを右クリックし、**[スタイルの編集]** または **[テンプレートの編集]** (右クリックしたコントロールによって異なる) をクリックすることです。 その後、**[リソースの適用]** をクリックして既にあるスタイルを適用するか、または **[空アイテムの作成]** をクリックして新しいスタイルを定義できます。 空のスタイルを作成する場合は、ページ、App.xaml ファイル、または別のリソース ディクショナリにそのスタイルを定義できます。

## 既定のシステム スタイルの変更

可能であれば、Windows ランタイムの既定の XAML リソースからのスタイルを使う必要があります。 独自のスタイルを定義する必要がある場合は、できるだけこれらの既定のスタイルから継承したスタイルを作成します (このクイック スタートで既に説明したように継承スタイルを使います。元の既定のスタイルのコピーを編集することから始めます)。

## テンプレート プロパティ

スタイル setter は、[**Control**](https://msdn.microsoft.com/library/windows/apps/br209390) の [**Template**](https://msdn.microsoft.com/library/windows/apps/br209465) プロパティに使うことができ、実際に、一般的な XAML スタイルとアプリの XAML リソースの主要な部分を構成しています。 詳しくは、「[コントロール テンプレート](control-templates.md)」をご覧ください。



<!--HONumber=Aug16_HO3-->


