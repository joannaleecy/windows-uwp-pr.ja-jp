---
author: jwmsft
description: コントロール テンプレート内のプロパティの値を、template 宣言されたコントロールのその他の公開されているプロパティの値にリンクします。 XAML では、TemplateBinding は ControlTemplate 定義内でのみ使用できます。
title: TemplateBinding マークアップ拡張
ms.assetid: FDE71086-9D42-4287-89ED-8FBFCDF169DC
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8c1812adc9d5610fffd6f9d275b4e093a4fa96e6
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5475317"
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

カスタム コントロールの作成者である場合でも、コントロール テンプレートを今あるコントロールに置き換える場合でも、コントロール テンプレートを定義するうえでは **TemplateBinding** を使うことが欠かせません。 詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)」をご覧ください。

*propertyName* と *targetProperty* では同じプロパティ名を使うことが一般的です。 この場合、コントロール自体でプロパティを定義し、プロパティを、そのいずれかのコンポーネントの直感的な名前を持つ既にあるプロパティに転送します。 たとえば、[**TextBlock**](https://msdn.microsoft.com/library/windows/apps/br209652) をコントロールの合成に組み込んでコントロール自体の **Text** プロパティの表示に使う場合は、コントロール テンプレートの一部として次の XAML を含めることができます。 `<TextBlock Text="{TemplateBinding Text}" .... />`

ソース プロパティとターゲット プロパティの値として使う型は一致する必要があります。 **TemplateBinding** を使うとコンバーターを導入する機会がありません。 値が一致しないと、XAML を解析したときにエラーが発生します。 コンバーターを必要とする場合は、次のようなテンプレート バインドの冗長な形式の構文を使うことができます。 `{Binding RelativeSource={RelativeSource TemplatedParent}, Converter="..." ...}`

XAML の [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391) 定義の外側で **TemplateBinding** を使うと、パーサー エラーが発生します。

親のテンプレート値も別のバインドとして延期される場合は、**TemplateBinding** を使用できます。 **TemplateBinding** の評価は、必要な実行時バインドに値が設定されるまで待機することができます。

**TemplateBinding** は常に一方向バインドです。 関係するプロパティはどちらも依存関係プロパティである必要があります。

**TemplateBinding** はマークアップ拡張です。 通常、マークアップ拡張は、属性値をリテラル値やハンドラー名以外にエスケープする必要があり、特定の型やプロパティに対して型コンバーターを指定するのではなく、よりグローバルにその必要がある場合に実装します。 XAML のすべてのマークアップ拡張では、それぞれの属性構文で "{" と "}" の文字を使います。これは規約であり、これに従って XAML プロセッサは、マークアップ拡張で属性を処理する必要があることを認識します。

**注:** Windows ランタイム XAML プロセッサの実装で、 **TemplateBinding**のバッキング クラス表現はありません。 **TemplateBinding** は、XAML マークアップでのみ使用できます。 コードの動作を再現する方法には単純なものがありません。

### <a name="xbind-in-controltemplate"></a>ControlTemplate で X:bind

次回のメジャー アップデートを Windows 10 以降、 **X:bind**マークアップ拡張を使用することができます[**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391)で**TemplateBinding**を使用した任意の場所です。 

[TargetType](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.controltemplate.targettype#Windows_UI_Xaml_Controls_ControlTemplate_TargetType)プロパティが必要です (オプションではなく) [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391) **X:bind**を使用する場合にします。

**X:bind**をサポートできるようになりましたとして使用できますどちらの[関数のバインディング](../data-binding/function-bindings.md) [ControlTemplate](https://msdn.microsoft.com/library/windows/apps/br209391)でも、双方向バインディング

次の例では、TextBlock.Text Button.Content.ToString() と評価されます。 ControlTemplate で TargetType では、データ ソースとして機能し、親の TemplateBinding と同じ結果を実現します。

```xaml
<ControlTemplate TargetType="Button">
    <Grid>
        <TextBlock Text="{x:Bind Content}" />
    </Grid>
</ControlTemplate>
```

## <a name="related-topics"></a>関連トピック

* [クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)
* [データ バインディングの詳細](https://msdn.microsoft.com/library/windows/apps/mt210946)
* [**ControlTemplate**](https://msdn.microsoft.com/library/windows/apps/br209391)
* [XAML の概要](xaml-overview.md)
* [依存関係プロパティの概要](dependency-properties-overview.md)
 

