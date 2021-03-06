---
description: コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。 XAML では、TemplateBinding は ControlTemplate 定義内でのみ使用できます。
title: TemplateBinding マークアップ拡張
ms.assetid: FDE71086-9D42-4287-89ED-8FBFCDF169DC
ms.date: 10/29/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9ade10b4d5e2653eb214d93c2c9166e6a3e3defc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661807"
---
# <a name="templatebinding-markup-extension"></a>{TemplateBinding} マークアップ拡張

コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。 XAML では、**TemplateBinding** は [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義内でのみ使用できます。

## <a name="xaml-attribute-usage"></a>XAML 属性の使用方法

``` syntax
<object propertyName="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-attribute-usage-for-setter-property-in-template-or-style"></a>XAML 属性の使用方法 (テンプレートまたはスタイルの Setter プロパティの場合)

``` syntax
<Setter Property="propertyName" Value="{TemplateBinding sourceProperty}" .../>
```

## <a name="xaml-values"></a>XAML 値

| 用語 | 説明 |
|------|-------------|
| propertyName | setter 構文で設定されるプロパティの名前。 これは依存関係プロパティであることが必要です。 |
| sourceProperty | template 宣言された型に存在する、別の依存関係プロパティの名前。 |

## <a name="remarks"></a>注釈

カスタム コントロールの作成者である場合でも、コントロール テンプレートを今あるコントロールに置き換える場合でも、コントロール テンプレートを定義するうえでは **TemplateBinding** を使うことが欠かせません。 詳細については、次を参照してください。[クイック スタート。コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)します。

*propertyName* と *targetProperty* では同じプロパティ名を使うことが一般的です。 この場合、コントロール自体でプロパティを定義し、プロパティを、そのいずれかのコンポーネントの直感的な名前を持つ既にあるプロパティに転送します。 たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) をコントロールの合成に組み込んでコントロール自体の **Text** プロパティの表示に使う場合は、コントロール テンプレートの一部として次の XAML を含めることができます。`<TextBlock Text="{TemplateBinding Text}" .... />`

ソース プロパティとターゲット プロパティの値として使う型は一致する必要があります。 **TemplateBinding** を使うとコンバーターを導入する機会がありません。 値が一致しないと、XAML を解析したときにエラーが発生します。 コンバーターを必要とする場合は、次のようなテンプレート バインドの冗長な形式の構文を使うことができます。`{Binding RelativeSource={RelativeSource TemplatedParent}, Converter="..." ...}`

XAML の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義の外側で **TemplateBinding** を使うと、パーサー エラーが発生します。

親のテンプレート値も別のバインドとして延期される場合は、**TemplateBinding** を使用できます。 **TemplateBinding** の評価は、必要な実行時バインドに値が設定されるまで待機することができます。

**TemplateBinding** は常に一方向バインドです。 関係するプロパティはどちらも依存関係プロパティである必要があります。

**TemplateBinding** はマークアップ拡張です。 通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。 XAML のすべてのマークアップ拡張では、それぞれの属性構文で "{" と "}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。

**注**  Windows ランタイム XAML でプロセッサの実装のバッキング クラスの表現はありません**TemplateBinding**します。 **TemplateBinding** は、XAML マークアップでのみ使用できます。 コードの動作を再現する方法には単純なものがありません。

### <a name="xbind-in-controltemplate"></a>X:bind の ControlTemplate

> [!NOTE]
> Windows 10、バージョンは 1809 ControlTemplate に x: バインドを使用する必要があります ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降。 ターゲット バージョンについて詳しくは、「[バージョン アダプティブ コード](https://msdn.microsoft.com/windows/uwp/debug-test-perf/version-adaptive-code)」をご覧ください。

使用できます Windows 10、バージョンは 1809、以降では、 **X:bind**マークアップ拡張機能使用する任意の場所**TemplateBinding**で、 [ **ControlTemplate** ](https://msdn.microsoft.com/library/windows/apps/br209391). 

[TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype)プロパティは (オプションではなく) が必要で[ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)を使用する場合**X:bind**します。

**X:bind**サポート、両方を使用することができます[関数バインド](../data-binding/function-bindings.md)で双方向のバインディングと、 [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)します。

この例で、 **TextBlock.Text**にプロパティが評価される**Button.Content.ToString**します。 ControlTemplate の TargetType では、データ ソースとして機能し、TemplateBinding を親と同じ結果を実現します。

```xaml
<ControlTemplate TargetType="Button">
    <Grid>
        <TextBlock Text="{x:Bind Content, Mode=OneWay}"/>
    </Grid>
</ControlTemplate>
```

## <a name="related-topics"></a>関連トピック

* [クイック スタート:コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)
* [データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391)
* [XAML の概要](xaml-overview.md)
* [依存関係プロパティの概要](dependency-properties-overview.md)
 

