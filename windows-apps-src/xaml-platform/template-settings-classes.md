---
author: jwmsft
description: Template settings (テンプレート設定) クラス
title: Template settings (テンプレート設定) クラス
ms.assetid: CAE933C6-EF13-465A-9831-AB003AF23907
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4d7b08138ab22d4cf2cbf4fb5273759f000a7c94
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5666618"
---
# <a name="template-settings-classes"></a>Template settings (テンプレート設定) クラス


## <a name="prerequisites"></a>前提条件

UI にコントロールを追加し、コントロールのプロパティを設定して、イベント ハンドラーをアタッチできることを前提としています。 アプリにコントロールを追加する方法については、「[コントロールの追加とイベントの処理](https://msdn.microsoft.com/library/windows/apps/mt228345)」をご覧ください。 読者が既定のテンプレートのコピーを作成、編集して、コントロール用のカスタム テンプレートを定義する方法の基本を知っていることも前提にしています。 これについて詳しくは、「[クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)」をご覧ください。

## <a name="the-scenario-for-templatesettings-classes"></a>**TemplateSettings** クラスのシナリオ

**TemplateSettings** クラスは、コントロールの新しいコントロール テンプレートを定義する際に使用されるプロパティのセットを提供します。 プロパティには、UI 要素の特定部分のサイズのピクセル値などの値があります。 これらの値は、通常は上書きまたはアクセスすることが簡単ではないコントロール ロジックから計算した値であることもあります。 一部のプロパティには、部分の切り替えとアニメーションを制御する **From** および **To** 値としての目的があるため、関連する **TemplateSettings** プロパティがペアになっています。

いくつかの **TemplateSettings** クラスがあります。 それらすべては [**Windows.UI.Xaml.Controls.Primitives**](https://msdn.microsoft.com/library/windows/apps/br209818) 名前空間に含まれています。 ここでは、クラスの一覧、および関連コントロールの **TemplateSettings** プロパティへのリンクを示します。 この **TemplateSettings** プロパティは、コントロールの **TemplateSettings** 値へのアクセス方法であり、プロパティへのテンプレート バインドを確立することができます。

-   [**ComboBoxTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227752): [**ComboBox.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209364) の値。
-   [**GridViewItemTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh738499): [**GridViewItem.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh738503) の値。
-   [**ListViewItemTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh701948): [**ListViewItem.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br242923) の値。
-   [**ProgressBarTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227856): [**ProgressBar.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227537) の値。
-   [**ProgressRingTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh702248): [**ProgressRing.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/hh702581) の値。
-   [**SettingsFlyoutTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/dn298721): [**SettingsFlyout.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/dn252826) の値。
-   [**ToggleSwitchTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209804): [**ToggleSwitch.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209731) の値。
-   [**ToolTipTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br209813): [**ToolTip.TemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227629) の値。

**TemplateSettings** プロパティは常に、コードではなく XAML で使うことを想定しています。 親コントロールの読み取り専用 **TemplateSettings** プロパティの読み取り専用サブプロパティです。 [**Control**](https://msdn.microsoft.com/library/windows/apps/br209390) ベースの新しいクラスを作成し、そのためコントロール ロジックに影響を与える可能性があるカスタム コントロールの高度なシナリオについては、コントロールから再度テンプレートを作成するユーザーに役立つ情報を伝えるために、コントロールにカスタムの **TemplateSettings** プロパティを定義することをお勧めします。 そのプロパティの読み取り専用の値として、テンプレートの測定値、アニメーションの配置などに関係する情報項目ごとに、読み取り専用プロパティを持つコントロールに関連した新しい **TemplateSettings** クラスを定義し、コントロール ロジックを使って初期化されたそのクラスのランタイム インスタンスを呼び出し元に渡します。 **TemplateSettings** クラスは [**DependencyObject**](https://msdn.microsoft.com/library/windows/apps/br242356) から派生し、プロパティでプロパティ変更コールバックに依存関係プロパティ システムを使用できるようにします。 ただし、プロパティの依存関係プロパティの識別子はパブリック API として公開されないため、**TemplateSettings** プロパティは、呼び出し元に対して読み取り専用にすることを意図したものです。

## <a name="how-to-use-templatesettings-in-a-control-template"></a>コントロール テンプレートで **TemplateSettings** を使う方法

次に示す例は、基盤になる既定の XAML コントロール テンプレートに含まれています。 この特定の例は、[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) の既定のテンプレートを基にしています。

```xml
<Ellipse
    x:Name="E1"
    Style="{StaticResource ProgressRingEllipseStyle}"
    Width="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Height="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Margin="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseOffset}"
    Fill="{TemplateBinding Foreground}"/>
```

[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) テンプレートの完全な XAML は数百行あり、これは一部のみの抜粋です。 次の XAML は、進行状況不定の回転アニメーションを示す 6 つの [**Ellipse**](/uwp/api/Windows.UI.Xaml.Shapes.Ellipse) 要素の 1 つであるコントロール部を定義しています。 開発者は、アニメーションの進行状況を表す円が気に入らない場合は、別のグラフィック プリミティブや別の基本図形を使うことができます。 たとえば、正方形に配置した一連の [**Rectangle**](/uwp/api/Windows.UI.Xaml.Shapes.Rectangle) 要素を使った **ProgressRing** を作成できます。 その場合、新しいテンプレートの個別の各 **Rectangle** コンポーネントは次のようになります。

```xml
<Rectangle
    x:Name="R1"
    Width="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Height="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseDiameter}"
    Margin="{Binding RelativeSource={RelativeSource TemplatedParent}, 
        Path=TemplateSettings.EllipseOffset}"
    Fill="{TemplateBinding Foreground}"/>
```

**TemplateSettings** プロパティがここで有用な理由は、[**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/br227538) の基本的なコントロールのロジックに基づく計算値であることです。 計算では、**ProgressRing** の [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/br208709) および [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/br208707) 全体を分割し、テンプレート内のアニメーションの各要素に計算された測定値を割り当てて、テンプレート パーツをコンテンツに合わせてサイズ変更できるようにします。

既定の XAML コントロール テンプレートから抜粋したもう 1 つの使用例を次に示します。ここでは、アニメーションの **From** と **To** であるプロパティ セットのいずれかを示します。 これは、[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) 既定テンプレートからの抜粋です。

```xml
<VisualStateGroup x:Name="DropDownStates">
    <VisualState x:Name="Opened">
        <Storyboard>
            <SplitOpenThemeAnimation
               OpenedTargetName="PopupBorder"
               ContentTargetName="ScrollViewer"
               ClosedTargetName="ContentPresenter"
               ContentTranslationOffset="0"
               OffsetFromCenter="{Binding RelativeSource={RelativeSource TemplatedParent}, 
                 Path=TemplateSettings.DropDownOffset}"
               OpenedLength="{Binding RelativeSource={RelativeSource TemplatedParent}, 
                 Path=TemplateSettings.DropDownOpenedHeight}"
               ClosedLength="{Binding RelativeSource={RelativeSource TemplatedParent},
                 Path=TemplateSettings.DropDownClosedHeight}" />
        </Storyboard>
   </VisualState>
...
</VisualStateGroup>
```

ここでも、テンプレートの XAML は量が多いため、一部のみを抜粋して示しています。 これは、それぞれ同じ [**ComboBoxTemplateSettings**](https://msdn.microsoft.com/library/windows/apps/br227752) プロパティを使用する、複数ある状態とテーマのアニメーションのうちの 1 つにすぎません。 [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/br209348) では、バインドを利用して **ComboBoxTemplateSettings** 値を使うと、テンプレート内の関連アニメーションが共有値に基づく位置で停止および開始し、スムーズに遷移します。

**注:**  **TemplateSettings**値を使用する、コントロール テンプレートの一部としてとき、は、値の型に一致するプロパティを設定することを確認してください。 そうしないと、バインドのターゲットの型を **TemplateSettings** 値の異なるソース型から変換できるように、バインドの値のコンバーターを作成することが必要になる場合があります。 詳しくは、「[**IValueConverter**](https://msdn.microsoft.com/library/windows/apps/br209903)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [クイック スタート: コントロール テンプレート](https://msdn.microsoft.com/library/windows/apps/xaml/hh465374)

