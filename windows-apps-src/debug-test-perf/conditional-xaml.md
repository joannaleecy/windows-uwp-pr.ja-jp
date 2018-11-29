---
title: 条件付き XAML
description: 以前のバージョンとの互換性を保ちながら、XAML マークアップで新しい API を使います
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3c75a6c487fe4a7f7cb56deff869b36309a4b9c7
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7972298"
---
# <a name="conditional-xaml"></a>条件付き XAML

*条件付き XAML* は、XAML マークアップで [ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.isapicontractpresent) メソッドを使う方法を提供するものです。 これにより、分離コードを使わなくても、API の有無に基づいてマークアップでプロパティの設定やオブジェクトのインスタンス化を行うことができます。 要素や属性が選択的に解析され、実行時に利用できるかどうかが判断されます。 条件ステートメントは実行時に評価されます。条件付き XAML タグで修飾された要素は、**true** と評価された場合に解析され、そうでない場合は無視されます。

条件付き XAML は Creators Update (Version 1703、ビルド 15063) 以降で使用できます。 条件付き XAML を使用するには、Visual Studio プロジェクトの最小バージョンとしてビルド 15063 (Creators Update) 以降を選択し、ターゲット バージョンを最小バージョンよりも後のバージョンに設定する必要があります。 Visual Studio プロジェクトの構成について詳しくは、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。

> [!NOTE]
> ビルド 15063 より前のバージョンを最小バージョンとするバージョン アダプティブ アプリを作成するには、XAML ではなく[バージョン アダプティブ コード](version-adaptive-code.md)を使う必要があります。

ApiInformation に関する重要な背景情報と API コントラクトについては、「[バージョン アダプティブ アプリ](version-adaptive-apps.md)」をご覧ください。

## <a name="conditional-namespaces"></a>条件付き名前空間

XAML で条件メソッドを使うには、最初にページの最上部で条件付き [XAML 名前空間](../xaml-platform/xaml-namespaces-and-namespace-mapping.md)を宣言する必要があります。 条件付き名前空間の擬似コード例を次に示します。

```xaml
xmlns:myNamespace="schema?conditionalMethod(parameter)"
```

条件付き名前空間は、'?' を区切り文字として 2 つの部分に分けられます。 

- 区切り文字の前のコンテンツには、参照しようとしている API を含む名前空間またはスキーマを指定します。 
- 区切り文字 '?' の後のコンテンツは、条件付き名前空間が **true** と **false** のどちらに評価されるかを決定する条件メソッドを表します。

ほとんどの場合、スキーマは、次に示す既定の XAML 名前空間になります。

```xaml
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
```

条件付き XAML では、次の条件メソッドがサポートされます。

メソッド | 逆条件
------ | -------
IsApiContractPresent(ContractName, VersionNumber) | IsApiContractNotPresent(ContractName, VersionNumber)
IsTypePresent(ControlType) | IsTypeNotPresent(ControlType)
IsPropertyPresent(ControlType, PropertyName) | IsPropertyNotPresent(ControlType, PropertyName)

この記事の後のセクションで、これらのメソッドについてさらに説明します。

> [!NOTE]
> IsApiContractPresent と IsApiContractNotPresent を使うことをお勧めします。 その他の条件は、Visual Studio のデザイン エクスペリエンスでは完全にはサポートされていません。

## <a name="create-a-namespace-and-set-a-property"></a>名前空間の作成とプロパティの設定

この例では、アプリが Fall Creators Update 以降で実行されている場合に、テキスト ブロックのコンテンツとして "Hello, Conditional XAML" と表示します。以前のバージョンで実行されている場合、コンテンツは何も表示されません。

まず、"contract5Present" というプレフィックスのカスタム名前空間を定義し、[TextBlock.Text](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.textblock.Text) プロパティを含むスキーマとして、既定の XAML 名前空間 (http://schemas.microsoft.com/winfx/2006/xaml/presentation) を使います。 これを条件付き名前空間にするために、スキーマの後に区切り文字 '?'  を追加します。

次に、Fall Creators Update 以降を実行しているデバイスで **true** を返す条件を定義します。 ApiInformation の **IsApiContractPresent** メソッドを使って、UniversalApiContract の 5 番目のバージョンをチェックします。 バージョン 5 の UniversalApiContract は Fall Creators Update (SDK 16299) でリリースされました。

```xaml
xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
```

名前空間を定義したら、TextBox の Text プロパティに名前空間プレフィックスを追加して、実行時に条件付きで設定されるプロパティとなるように指定します。

```xaml
<TextBlock contract5Present:Text="Hello, Conditional XAML"/>
```

XAML 全体は次のようになります。

```xaml
<Page
    x:Class="ConditionalTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <TextBlock contract5Present:Text="Hello, Conditional XAML"/>
    </Grid>
</Page>
```

この例を Fall Creators Update で実行すると、"Hello, Conditional XAML" というテキストが表示されます。Creators Update で実行した場合、テキストは表示されません。

条件付き XAML を使うと、以前にはコードで実行していた API チェックをマークアップ内で実行できるようになります。 同じチェックを実行するコードは次のようになります。

```csharp
if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5))
{
    textBlock.Text = "Hello, Conditional XAML";
}
```

IsApiContractPresent メソッドは *contractName* パラメーターとして文字列を受け取りますが、XAML 名前空間の宣言では引用符 (" ") を付けないことに注意してください。

## <a name="use-ifelse-conditions"></a>if/else 条件の使用

前の例では、アプリが Fall Creators Update で実行されている場合にのみ Text プロパティが設定されます。 では、Creators Update での実行時に別のテキストを表示したい場合はどうすればよいでしょうか。 たとえば、次のように条件修飾子のない Text プロパティを設定したとします。

```xaml
<!-- DO NOT USE -->
<TextBlock Text="Hello, World" contract5Present:Text="Hello, Conditional XAML"/>
```

これは Creators Update で実行した場合は正しく動作しますが、Fall Creators Update で実行すると、Text プロパティが複数回設定されているというエラーが発生します。

異なるバージョンの Windows 10 でアプリが実行されているときに別のテキストを設定するには、別の条件を使う必要があります。 条件付き XAML では、このような if/else 条件のシナリオを作成できるように、サポートされている ApiInformation メソッドのそれぞれに対して反対の判定を行うメソッドが用意されています。

IsApiContractPresent メソッドは、指定したコントラクトとバージョン番号が現在のデバイスに含まれている場合に **true** を返します。 たとえば、ユニバーサル API コントラクトの 4 番目のバージョンである Creators Update でアプリが実行されているとします。

このとき、パラメーターを変えて IsApiContractPresent を呼び出すと、結果は次のようになります。

- IsApiContractPresent(Windows.Foundation.UniversalApiContract, 5) = **false**
- IsApiContractPresent(Windows.Foundation.UniversalApiContract, 4) = true
- IsApiContractPresent(Windows.Foundation.UniversalApiContract, 3) = true
- IsApiContractPresent(Windows.Foundation.UniversalApiContract, 2) = true
- IsApiContractPresent(Windows.Foundation.UniversalApiContract, 1) = true

IsApiContractNotPresent は、IsApiContractPresent の反対の結果を返します。 IsApiContractNotPresent の呼び出し結果は次のようになります。

- IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 5) = **true**
- IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 4) = false
- IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 3) = false
- IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 2) = false
- IsApiContractNotPresent(Windows.Foundation.UniversalApiContract, 1) = false

逆条件を使うには、**IsApiContractNotPresent** 条件を使う 2 つ目の条件付き XAML 名前空間を作成します。 この例では、"contract5NotPresent" というプレフィックスを使います。

```xaml
xmlns:contract5NotPresent="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractNotPresent(Windows.Foundation.UniversalApiContract,5)"

xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
```

両方の名前空間を定義し、次のようにプロパティをプレフィックスで修飾すれば、実行時には一方のプロパティだけが設定されるため、Text プロパティを 2 回記述することができます。

```xaml
<TextBlock contract5NotPresent:Text="Hello, World"
           contract5Present:Text="Hello, Fall Creators Update"/>
```

別の例として、ボタンの背景を設定する場合を考えます。 Fall Creators Update 以降では[アクリル素材](../design/style/acrylic.md)機能を利用できるので、アプリが Fall Creators Update で実行されているときは、背景にアクリルを適用することにします。 この機能は以前のバージョンでは利用できないため、その場合は背景を赤に設定します。

```xaml
<Button Content="Button"
        contract5NotPresent:Background="Red"
        contract5Present:Background="{ThemeResource SystemControlAcrylicElementBrush}"/>
```

## <a name="create-controls-and-bind-properties"></a>コントロールの作成とプロパティのバインド

ここまでは条件付き XAML を使ってプロパティを設定する方法を見てきましたが、実行時に利用できる API コントラクトに基づいて、条件付きでコントロールをインスタンス化することもできます。

ここでは、アプリが Fall Creators Update で実行されている場合に、Fall Creators Update で利用できる [ColorPicker](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.colorpicker) コントロールをインスタンス化します。 ColorPicker は Fall Creators Update より前のバージョンでは利用できないため、アプリが以前のバージョンで実行されている場合は、[ComboBox](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.combobox) を使って色を選択する簡単なインターフェイスをユーザーに提示します。

```xaml
<contract5Present:ColorPicker x:Name="colorPicker"
                              Grid.Column="1"
                              VerticalAlignment="Center"/>

<contract5NotPresent:ComboBox x:Name="colorComboBox"
                              PlaceholderText="Pick a color"
                              Grid.Column="1"
                              VerticalAlignment="Center">
```

条件修飾子は、さまざまな形式の [XAML プロパティ構文](../xaml-platform/xaml-syntax-guide.md)で使うことができます。 次の例では、四角形の Fill プロパティを設定するために、Fall Creators Update に対してはプロパティ要素構文を使い、以前のバージョンに対しては属性構文を使っています。

```xaml
<Rectangle x:Name="colorRectangle" Width="200" Height="200"
           contract5NotPresent:Fill="{x:Bind ((SolidColorBrush)((FrameworkElement)colorComboBox.SelectedItem).Tag), Mode=OneWay}">
    <contract5Present:Rectangle.Fill>
        <SolidColorBrush contract5Present:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
    </contract5Present:Rectangle.Fill>
</Rectangle>
```

あるプロパティを、条件付き名前空間に依存する別のプロパティにバインドする場合は、両方のプロパティで同じ条件を使う必要があります。 次の例では、`colorPicker.Color` は "contract5Present" 条件付き名前空間に依存するため、SolidColorBrush.Color プロパティにも "contract5Present" プレフィックスを付ける必要があります  (または、Color プロパティの代わりに SolidColorBrush に "contract5Present" プレフィックスを付けることもできます)。そうしないと、コンパイル時エラーが発生します。

```xaml
<SolidColorBrush contract5Present:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
```

以下に、これらのシナリオを実装した XAML 全体を示します。 この例には、1 つの四角形と、その四角形の色を設定する UI が含まれています。

アプリが Fall Creators Update で実行された場合は、ColorPicker を使って色をユーザーが設定できるようにします。 ColorPicker は Fall Creators Update より前のバージョンでは利用できないため、アプリが以前のバージョンで実行されている場合は、コンボ ボックスを使って色を選択する簡単なインターフェイスをユーザーに提示します。

```xaml
<Page
    x:Class="ConditionalTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:contract5Present="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractPresent(Windows.Foundation.UniversalApiContract,5)"
    xmlns:contract5NotPresent="http://schemas.microsoft.com/winfx/2006/xaml/presentation?IsApiContractNotPresent(Windows.Foundation.UniversalApiContract,5)">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>

        <Rectangle x:Name="colorRectangle" Width="200" Height="200"
                   contract5NotPresent:Fill="{x:Bind ((SolidColorBrush)((FrameworkElement)colorComboBox.SelectedItem).Tag), Mode=OneWay}">
            <contract5Present:Rectangle.Fill>
                <SolidColorBrush contract5Present:Color="{x:Bind colorPicker.Color, Mode=OneWay}"/>
            </contract5Present:Rectangle.Fill>
        </Rectangle>

        <contract5Present:ColorPicker x:Name="colorPicker"
                                      Grid.Column="1"
                                      VerticalAlignment="Center"/>

        <contract5NotPresent:ComboBox x:Name="colorComboBox"
                                      PlaceholderText="Pick a color"
                                      Grid.Column="1"
                                      VerticalAlignment="Center">
            <ComboBoxItem>Red
                <ComboBoxItem.Tag>
                    <SolidColorBrush Color="Red"/>
                </ComboBoxItem.Tag>
            </ComboBoxItem>
            <ComboBoxItem>Blue
                <ComboBoxItem.Tag>
                    <SolidColorBrush Color="Blue"/>
                </ComboBoxItem.Tag>
            </ComboBoxItem>
            <ComboBoxItem>Green
                <ComboBoxItem.Tag>
                    <SolidColorBrush Color="Green"/>
                </ComboBoxItem.Tag>
            </ComboBoxItem>
        </contract5NotPresent:ComboBox>
    </Grid>
</Page>
```

## <a name="related-articles"></a>関連記事

- [UWP アプリ ガイド](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide)
- [API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)
- [API コントラクト](https://channel9.msdn.com/Events/Build/2015/3-733) (Build 2015 のビデオ)