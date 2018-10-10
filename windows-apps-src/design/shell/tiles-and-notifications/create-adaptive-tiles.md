---
author: andrewleader
Description: Adaptive tile templates are a new feature in Windows 10, allowing you to design your own tile notification content using a simple and flexible markup language that adapts to different screen densities.
title: アダプティブ タイルの作成
ms.assetid: 1246B58E-D6E3-48C7-AD7F-475D113600F9
label: Create adaptive tiles
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 761d87654ef340f4b539dbefa0950c58f627d310
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4503369"
---
# <a name="create-adaptive-tiles"></a>アダプティブ タイルの作成

アダプティブ タイル テンプレートは Windows 10 の新機能であり、シンプルで柔軟なマークアップ言語を使って、さまざまな画面密度に合わせて変化する独自のタイル通知コンテンツをデザインできるようになります。 この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリのアダプティブ ライブ タイルを作成する方法について説明します。 アダプティブ タイルのすべての要素と属性の一覧については、「[アダプティブ タイルのスキーマ](../tiles-and-notifications/tile-schema.md)」をご覧ください 

(必要に応じて、Windows 10 の通知をデザインするときは、[Windows 8 タイル テンプレート カタログ](https://msdn.microsoft.com/library/windows/apps/hh761491)のプリセット テンプレートを引き続き使うことができます)。


## <a name="getting-started"></a>概要

**Notifications ライブラリをインストールします。** XML の代わりに C# を使って通知を生成する場合は、[Microsoft.Toolkit.Uwp.Notifications](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) という名前の NuGet パッケージをインストールします (「notifications uwp」を検索してください)。 この記事で示している C# のサンプルでは、NuGet パッケージの Version 1.0.0 を使っています。

**Notifications Visualizer をインストールします。** この無料の UWP アプリは、Visual Studio の XAML エディター/デザイン ビューと同様、タイルの編集時に視覚的なプレビューが即座に表示されるため、アダプティブ ライブ タイルのデザインに便利です。 詳しくは、「[Notifications Visualizer](notifications-visualizer.md)」をご覧になるか、[Notifications Visualizer を Microsoft Store からダウンロード](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)してください。


## <a name="how-to-send-a-tile-notification"></a>タイル通知を送信する方法

詳しくは、「[Quickstart on sending local tile notifications (ローカル タイル通知の送信に関するクイックスタート)](sending-a-local-tile-notification.md)」をご覧ください。 以下では、アダプティブ タイルを使って作成できるあらゆる視覚的 UI について説明します。


## <a name="usage-guidance"></a>使い方のガイダンス


アダプティブ テンプレートはさまざまな種類のフォーム ファクターと通知で動作するようにデザインされています。 グループやサブグループのような要素はコンテンツと共にリンクされますが、それらのグループ自体には特に視覚的な動作はありません。 通知の最終的な外観は、表示先のデバイスがスマートフォン、タブレット、デスクトップ、その他のデバイスのいずれであっても、特定のデバイスに基づきます。

hint は、特定の視覚的な動作を実現するために要素に追加できる省略可能な属性です。 デバイス固有または通知固有の hint を追加できます。

## <a name="a-basic-example"></a>基本的な例


次の例では、アダプティブ タイル テンプレートで何を作成できるかを示しています。

```xml
<tile>
  <visual>
  
    <binding template="TileMedium">
      ...
    </binding>
  
    <binding template="TileWide">
      <text hint-style="subtitle">Jennifer Parker</text>
      <text hint-style="captionSubtle">Photos from our trip</text>
      <text hint-style="captionSubtle">Check out these awesome photos I took while in New Zealand!</text>
    </binding>
  
    <binding template="TileLarge">
      ...
    </binding>
  
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = ...
  
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Jennifer Parker",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
  
                    new AdaptiveText()
                    {
                        Text = "Photos from our trip",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },
  
                    new AdaptiveText()
                    {
                        Text = "Check out these awesome photos I took while in New Zealand!",
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
            }
        },
  
        TileLarge = ...
    }
};
```

**結果:**

![クイック サンプル タイル](images/adaptive-tiles-quicksample.png)

## <a name="tile-sizes"></a>タイルのサイズ


各タイル サイズのコンテンツは XML ペイロード内でそれぞれ個別の [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素で指定します。 template 属性を次のいずれかの値に設定することで、目的のサイズを選びます。

-   TileSmall
-   TileMedium
-   TileWide
-   TileLarge (デスクトップの場合のみ)

次の例では、1 つのタイル通知 XML ペイロード内で、サポートする各タイル サイズを &lt;binding&gt; 要素で指定しています。

```xml
<tile>
  <visual>
  
    <binding template="TileSmall">
      <text>Small</text>
    </binding>
  
    <binding template="TileMedium">
      <text>Medium</text>
    </binding>
  
    <binding template="TileWide">
      <text>Wide</text>
    </binding>
  
    <binding template="TileLarge">
      <text>Large</text>
    </binding>
  
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileSmall = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Small" }
                }
            }
        },
  
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Medium" }
                }
            }
        },
  
        TileWide = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Wide" }
                }
            }
        },
  
        TileLarge = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                Children =
                {
                    new AdaptiveText() { Text = "Large" }
                }
            }
        }
    }
};
```

**結果:**

![アダプティブ タイル サイズ: 小、中、ワイド、大](images/adaptive-tiles-sizes.png)

## <a name="branding"></a>ブランディング


通知ペイロード内で branding 属性を使って、ライブ タイルの下部でブランディング (表示名とコーナー ロゴ) を制御できます。 表示なし ("none")、名前のみ表示 ("name")、ロゴのみ表示 ("logo")、名前とロゴの両方を表示 ("nameAndLogo") のいずれかを選べます。

**注**  Windows Mobile では、コーナー ロゴはサポートされていないため、"logo" と "nameAndLogo" は "name" に既定で設定されます。

 

```xml
<visual branding="logo">
  ...
</visual>
```

```csharp
new TileVisual()
{
    Branding = TileBranding.Logo,
    ...
}
```

**結果:**

![アダプティブ タイル、表示名、ロゴ](images/adaptive-tiles-namelogo.png)

ブランディングは次の 2 つのいずれかの方法で特定のタイル サイズに合わせて適用できます。

1. その属性を [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素で適用する。
2. その属性を [TileVisual](../tiles-and-notifications/tile-schema.md#tilevisual) 要素で適用する。通知ペイロード全体に影響を与えます。binding 要素でブランディングを指定しない場合は、visual 要素で指定したブランディングが使われます。

```xml
<tile>
  <visual branding="nameAndLogo">
 
    <binding template="TileMedium" branding="logo">
      ...
    </binding>
 
    <!--Inherits branding from visual-->
    <binding template="TileWide">
      ...
    </binding>
 
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        Branding = TileBranding.NameAndLogo,

        TileMedium = new TileBinding()
        {
            Branding = TileBranding.Logo,
            ...
        },

        // Inherits branding from Visual
        TileWide = new TileBinding()
        {
            ...
        }
    }
};
```

**既定のブランディングの結果:**

![タイル上の既定のブランディング](images/adaptive-tiles-defaultbranding.png)

通知ペイロード内でブランディングを指定しない場合は、ベース タイルのプロパティによってブランディングが決まります。 ベース タイルに表示名が表示される場合、ブランディングは既定で "name" に設定されます。 表示名が表示されない場合、ブランディングは既定で "none" に設定されます。

**注**   これは、既定のブランディングが "logo" であった Windows 8.x からの変更点です。

 

## <a name="display-name"></a>表示名


**displayName** 属性に任意のテキスト文字列を入力することで、通知の表示名を上書きすることができます。 ブランディングと同様、通知ペイロード全体に影響を与える [TileVisual](../tiles-and-notifications/tile-schema.md#tilevisual) 要素で、または個々のタイルにのみ影響を与える [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素で、表示名を指定できます。

**既知の問題**  Windows Mobile でタイルの ShortName を指定した場合、通知で提供される表示名は使用されません (ShortName が常に表示されます)。 

```xml
<tile>
  <visual branding="nameAndLogo" displayName="Wednesday 22">
 
    <binding template="TileMedium" displayName="Wed. 22">
      ...
    </binding>
 
    <!--Inherits displayName from visual-->
    <binding template="TileWide">
      ...
    </binding>
 
  </visual>
</tile>
```

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        Branding = TileBranding.NameAndLogo,
        DisplayName = "Wednesday 22",

        TileMedium = new TileBinding()
        {
            DisplayName = "Wed. 22",
            ...
        },

        // Inherits DisplayName from Visual
        TileWide = new TileBinding()
        {
            ...
        }
    }
};
```

**結果:**

![アダプティブ タイルの表示名](images/adaptive-tiles-displayname.png)

## <a name="text"></a>テキスト


テキストの表示には、[AdaptiveText](../tiles-and-notifications/tile-schema.md#adaptivetext) 要素を使用します。 ヒントを使用して、テキストの表示方法を変更できます。

```xml
<text>This is a line of text</text>
```


```csharp
new AdaptiveText()
{
    Text = "This is a line of text"
};
```

**結果:**

![アダプティブ タイルのテキスト](images/adaptive-tiles-text.png)

## <a name="text-wrapping"></a>テキストの折り返し


既定では、テキストは折り返されず、タイルの端からはみ出します。 **hint-wrap** 属性を使って、text 要素のテキストの折り返しを設定します。 また、**hint-minLines** と **hint-maxLines** (正の整数のみを受け取り) を使って、行の最小数と最大数を制御することもできます。

```xml
<text hint-wrap="true">This is a line of wrapping text</text>
```


```csharp
new AdaptiveText()
{
    Text = "This is a line of wrapping text",
    HintWrap = true
};
```

**結果:**

![テキストが折り返されるアダプティブ タイル](images/adaptive-tiles-textwrapping.png)

## <a name="text-styles"></a>テキスト スタイル


スタイルを使って、text 要素のフォントのサイズ、色、太さを制御します。 多数のスタイルを使えます。たとえば、各スタイルの "Subtle" バリエーションを使って、テキストの不透明度を 60% に設定して、テキストの色を淡い灰色で暗くすることができます。

```xml
<text hint-style="base">Header content</text>
<text hint-style="captionSubtle">Subheader content</text>
```

```csharp
new AdaptiveText()
{
    Text = "Header content",
    HintStyle = AdaptiveTextStyle.Base
},

new AdaptiveText()
{
    Text = "Subheader content",
    HintStyle = AdaptiveTextStyle.CaptionSubtle
}
```

**結果:**

![アダプティブ タイルのテキスト スタイル](images/adaptive-tiles-textstyles.png)

**注**  hint-style を指定しない場合、スタイルは既定で caption に設定されます。

 

**基本的なテキスト スタイル**

|                                |                           |             |
|--------------------------------|---------------------------|-------------|
| &lt;text hint-style="\*" /&gt; | フォントの高さ               | フォントの太さ |
| caption                        | 12 epx (有効ピクセル) | Regular     |
| body                           | 15 epx                    | Regular     |
| base                           | 15 epx                    | Semibold    |
| subtitle                       | 20 epx                    | Regular     |
| title                          | 24 epx                    | Semilight   |
| subheader                      | 34 epx                    | Light       |
| header                         | 46 epx                    | Light       |

 

**テキスト スタイルの Numeral バリエーション**

次のバリエーションでは、テキストに上下のコンテンツが近づくように、行の高さを減らすことができます。

|                  |
|------------------|
| titleNumeral     |
| subheaderNumeral |
| headerNumeral    |

 

**テキスト スタイルの Subtle バリエーション**

各スタイルの "Subtle" バリエーションでは、テキストの不透明度を 60% に設定して、テキストの色を淡い灰色で暗くすることができます。

|                        |
|------------------------|
| captionSubtle          |
| bodySubtle             |
| baseSubtle             |
| subtitleSubtle         |
| titleSubtle            |
| titleNumeralSubtle     |
| subheaderSubtle        |
| subheaderNumeralSubtle |
| headerSubtle           |
| headerNumeralSubtle    |

 

## <a name="text-alignment"></a>テキストの配置


テキストは、横方向の配置 (左揃え、中央揃え、または右揃え) を設定できます。 英語のように左から右へと表記される言語では、テキストは既定で左揃えになります。 アラビア語のように右から左へと表記される言語では、テキストは既定で右揃えになります。 テキストの配置は要素の **hint-align** 属性で手動で設定できます。

```xml
<text hint-align="center">Hello</text>
```


```csharp
new AdaptiveText()
{
    Text = "Hello",
    HintAlign = AdaptiveTextAlign.Center
};
```

**結果:**

![アダプティブ タイルのテキストの配置](images/adaptive-tiles-textalignment.png)

## <a name="groups-and-subgroups"></a>グループとサブグループ


グループを使って、グループ内のコンテンツが互いに関連していて意味をなすまとまりで表示される必要があることを宣言できます。 たとえば、2 つの text 要素、1 つのヘッダー、1 つのサブヘッダーがあるとすると、ヘッダーのみが表示されても意味をなしません。 要素をサブグループにまとめることで、それらの要素はすべて表示されるか (画面に収まる場合)、まったく表示されません (画面に収まらない場合)。

デバイスや画面間でのエクスペリエンスを最大限に高めるには、複数のグループを用意します。 複数のグループを使うと、タイルをより大きい画面に合わせて調整できます。

**注**  グループの有効な子はサブグループのみです。

 

```xml
<binding template="TileWide" branding="nameAndLogo">
  <group>
    <subgroup>
      <text hint-style="subtitle">Jennifer Parker</text>
      <text hint-style="captionSubtle">Photos from our trip</text>
      <text hint-style="captionSubtle">Check out these awesome photos I took while in New Zealand!</text>
    </subgroup>
  </group>
 
  <text />
 
  <group>
    <subgroup>
      <text hint-style="subtitle">Steve Bosniak</text>
      <text hint-style="captionSubtle">Build 2015 Dinner</text>
      <text hint-style="captionSubtle">Want to go out for dinner after Build tonight?</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Branding = TileBranding.NameAndLogo,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            CreateGroup(
                from: "Jennifer Parker",
                subject: "Photos from our trip",
                body: "Check out these awesome photos I took while in New Zealand!"),

            // For spacing
            new AdaptiveText(),

            CreateGroup(
                from: "Steve Bosniak",
                subject: "Build 2015 Dinner",
                body: "Want to go out for dinner after Build tonight?")
        }
    }
}

...

private static AdaptiveGroup CreateGroup(string from, string subject, string body)
{
    return new AdaptiveGroup()
    {
        Children =
        {
            new AdaptiveSubgroup()
            {
                Children =
                {
                    new AdaptiveText()
                    {
                        Text = from,
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
                    new AdaptiveText()
                    {
                        Text = subject,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },
                    new AdaptiveText()
                    {
                        Text = body,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
            }
        }
    };
}
```

**結果:**

![アダプティブ タイルのグループとサブグループ](images/adaptive-tiles-groups-subgroups.png)

## <a name="subgroups-columns"></a>サブグループ (列)


サブグループを使って、グループのデータを意味をなすまとまりに分けることもできます。 ライブ タイルの場合、このまとまりは視覚的には列になります。

**hint-weight** 属性を使うと、列の幅を制御できます。 **hint-weight** の値は、空いているスペースに適用される重みとして表され、**GridUnitType.Star** と同じ動作になります。 各列の幅を同じにする場合は、各列に 1 の重みを割り当てます。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">hint-weight</td>
<td align="left">幅の割合</td>
</tr>
<tr class="even">
<td align="left">1</td>
<td align="left">25%</td>
</tr>
<tr class="odd">
<td align="left">1</td>
<td align="left">25%</td>
</tr>
<tr class="even">
<td align="left">1</td>
<td align="left">25%</td>
</tr>
<tr class="odd">
<td align="left">1</td>
<td align="left">25%</td>
</tr>
<tr class="even">
<td align="left">重み合計: 4</td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![サブグループ、等列幅](images/adaptive-tiles-subgroups01.png)

ある列の幅を別の列の幅の 2 倍にするには、狭い方の列に 1 の重みを割り当て、広い方の列に 2 の重みを割り当てます。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">hint-weight</td>
<td align="left">幅の割合</td>
</tr>
<tr class="even">
<td align="left">1</td>
<td align="left">33.3%</td>
</tr>
<tr class="odd">
<td align="left">2</td>
<td align="left">66.7%</td>
</tr>
<tr class="even">
<td align="left">重み合計: 3</td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![サブグループ、ある列幅が別の列幅の 2 倍](images/adaptive-tiles-subgroups02.png)

最初の列が全体の幅の 80% を占め、2 番目の列が全体の幅の 20% を占めるようにする場合は、最初の列に 20 の重みを割り当て、2 番目の列に 80 の重みを割り当てます。 重み合計が 100 に等しい場合、重みの値はパーセンテージとして扱われます。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">hint-weight</td>
<td align="left">幅の割合</td>
</tr>
<tr class="even">
<td align="left">20</td>
<td align="left">20%</td>
</tr>
<tr class="odd">
<td align="left">80</td>
<td align="left">80%</td>
</tr>
<tr class="even">
<td align="left">重み合計: 100</td>
<td align="left"></td>
</tr>
</tbody>
</table>

 

![サブグループ、重み合計が 100](images/adaptive-tiles-subgroups03.png)

**注**  8 ピクセルの余白が列の間に自動的に追加されます。

 

サブグループが 3 つ以上あるときは、正の整数のみを受け取る **hint-weight** を指定する必要があります。 1 番目のサブグループの hint-weight を指定しない場合、そのサブグループには 50 の重みが割り当てられます。 hint-weight を指定していない次のサブグループには、100 から前の重みの合計を引いた値に等しい重みが割り当てられます。または、引いた結果がゼロであれば、1 が割り当てられます。 hint-weight を指定していない残りのサブグループには、1 の重みが割り当てられます。

ここで示しているのは、天気タイルのサンプル コードで、等幅の 5 つの列で構成されたタイルになります。

```xml
<binding template="TileWide" displayName="Seattle" branding="name">
  <group>
    <subgroup hint-weight="1">
      <text hint-align="center">Mon</text>
      <image src="Assets\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Tue</text>
      <image src="Assets\Weather\Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-align="center" hint-style="captionsubtle">38°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Wed</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">59°</text>
      <text hint-align="center" hint-style="captionsubtle">43°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Thu</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">62°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    <subgroup hint-weight="1">
      <text hint-align="center">Fri</text>
      <image src="Assets\Weather\Sunny.png" hint-removeMargin="true"/>
      <text hint-align="center">71°</text>
      <text hint-align="center" hint-style="captionsubtle">66°</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    DisplayName = "Seattle",
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°"),
                    CreateSubgroup("Tue", "Cloudy.png", "57°", "38°"),
                    CreateSubgroup("Wed", "Sunny.png", "59°", "43°"),
                    CreateSubgroup("Thu", "Sunny.png", "62°", "42°"),
                    CreateSubgroup("Fri", "Sunny.png", "71°", "66°")
                }
            }
        }
    }
}

...

private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        HintWeight = 1,
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Weather/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

**結果:**

![天気タイルの例](images/adaptive-tiles-weathertile.png)

## <a name="images"></a>画像


&lt;image&gt; 要素を使って、タイル通知に画像を表示します。 画像はタイル コンテンツ (既定) 内に、背景画像としてか、タイルでアニメーション化されるプレビュー画像として、インラインで配置できます。

> [!NOTE]
> 画像は、アプリのパッケージ、アプリのローカル ストレージ、または Web から使用できます。 Fall Creators Update の時点で、Web 画像の上限は通常の接続で 3 MB、従量制課金接続で 1 MB です。 まだ Fall Creators Update を実行していないデバイスでは、Web イメージは 200 KB を上限とします。

 

特に動作が指定されていない場合、幅に合わせて縦横比を保ったまま拡大縮小されます。 次のサンプルでは、2 列とインライン画像を使用したタイルを示しています。 インライン画像は列幅に合わせて拡大されます。

```xml
<binding template="TileMedium" displayName="Seattle" branding="name">
  <group>
    <subgroup>
      <text hint-align="center">Mon</text>
      <image src="Assets\Apps\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-style="captionsubtle" hint-align="center">42°</text>
    </subgroup>
    <subgroup>
      <text hint-align="center">Tue</text>
      <image src="Assets\Apps\Weather\Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-style="captionSubtle" hint-align="center">38°</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    DisplayName = "Seattle",
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°"),
                    CreateSubgroup("Tue", "Cloudy.png", "57°", "38°")
                }
            }
        }
    }
}
...
private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Weather/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

**結果:**

![画像の例](images/adaptive-tiles-images01.png)

&lt;binding&gt; のルート、つまり最初のグループに配置された画像も、空いている高さに合わせて拡大されます。

### <a name="image-alignment"></a>画像の配置

画像は、**hint-align** 属性を使って、左揃え、中央揃え、または右揃えに設定できます。 また、これにより画像は、幅を埋めるように拡大されずに、ネイティブの解像度で表示されます。

```xml
<binding template="TileLarge">
  <image src="Assets/fable.jpg" hint-align="center"/>
</binding>
```

```csharp
TileLarge = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveImage()
            {
                Source = "Assets/fable.jpg",
                HintAlign = AdaptiveImageAlign.Center
            }
        }
    }
}
```

**結果:**

![画像の配置の例 (左、中央、右)](images/adaptive-tiles-imagealignment.png)

### <a name="image-margins"></a>画像の余白

既定では、インライン画像の上または下には、コンテンツとの間に 8 ピクセルの余白が追加されます。 この余白は、画像の **hint-removeMargin** 属性を使って削除できます。 ただし、画像では常にタイルの端から 8 ピクセルの余白が保持され、サブグループ (列) では常に列の間に 8 ピクセルのパディングが保持されます。

```xml
<binding template="TileMedium" branding="none">
  <group>
    <subgroup>
      <text hint-align="center">Mon</text>
      <image src="Assets\Numbers\4.jpg" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-style="captionsubtle" hint-align="center">42°</text>
    </subgroup>
    <subgroup>
      <text hint-align="center">Tue</text>
      <image src="Assets\Numbers\3.jpg" hint-removeMargin="true"/>
      <text hint-align="center">57°</text>
      <text hint-style="captionsubtle" hint-align="center">38°</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    Branding = TileBranding.None,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "4.jpg", "63°", "42°"),
                    CreateSubgroup("Tue", "3.jpg", "57°", "38°")
                }
            }
        }
    }
}

...

private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        HintWeight = 1,
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Numbers/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

![画像の余白削除の例](images/adaptive-tiles-removemargin.png)

### <a name="image-cropping"></a>画像のトリミング

**hint-crop** 属性を使って、画像を円形にトリミングできます。現時点では、"none" (既定) または "circle" のみがサポートされています。

```xml
<binding template="TileLarge" hint-textStacking="center">
  <group>
    <subgroup hint-weight="1"/>
    <subgroup hint-weight="2">
      <image src="Assets/Apps/Hipstame/hipster.jpg" hint-crop="circle"/>
    </subgroup>
    <subgroup hint-weight="1"/>
  </group>
 
  <text hint-style="title" hint-align="center">Hi,</text>
  <text hint-style="subtitleSubtle" hint-align="center">MasterHip</text>
</binding>
```

```csharp
TileLarge = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        TextStacking = TileTextStacking.Center,
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    new AdaptiveSubgroup() { HintWeight = 1 },
                    new AdaptiveSubgroup()
                    {
                        HintWeight = 2,
                        Children =
                        {
                            new AdaptiveImage()
                            {
                                Source = "Assets/Apps/Hipstame/hipster.jpg",
                                HintCrop = AdaptiveImageCrop.Circle
                            }
                        }
                    },
                    new AdaptiveSubgroup() { HintWeight = 1 }
                }
            },
            new AdaptiveText()
            {
                Text = "Hi,",
                HintStyle = AdaptiveTextStyle.Title,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = "MasterHip",
                HintStyle = AdaptiveTextStyle.SubtitleSubtle,
                HintAlign = AdaptiveTextAlign.Center
            }
        }
    }
}
```

**結果:**

![画像のトリミングの例](images/adaptive-tiles-imagecropping.png)

### <a name="background-image"></a>バックグラウンド画像

背景画像を設定するには、&lt;binding&gt; のルートに image 要素を追加し、placement 属性を "background" に設定します。

```xml
<binding template="TileWide">
  <image src="Assets\Mostly Cloudy-Background.jpg" placement="background"/>
  <group>
    <subgroup hint-weight="1">
      <text hint-align="center">Mon</text>
      <image src="Assets\Weather\Mostly Cloudy.png" hint-removeMargin="true"/>
      <text hint-align="center">63°</text>
      <text hint-align="center" hint-style="captionsubtle">42°</text>
    </subgroup>
    ...
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        BackgroundImage = new TileBackgroundImage()
        {
            Source = "Assets/Mostly Cloudy-Background.jpg"
        },

        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    CreateSubgroup("Mon", "Mostly Cloudy.png", "63°", "42°")
                    ...
                }
            }
        }
    }
}

...

private static AdaptiveSubgroup CreateSubgroup(string day, string image, string highTemp, string lowTemp)
{
    return new AdaptiveSubgroup()
    {
        HintWeight = 1,
        Children =
        {
            new AdaptiveText()
            {
                Text = day,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveImage()
            {
                Source = "Assets/Weather/" + image,
                HintRemoveMargin = true
            },
            new AdaptiveText()
            {
                Text = highTemp,
                HintAlign = AdaptiveTextAlign.Center
            },
            new AdaptiveText()
            {
                Text = lowTemp,
                HintAlign = AdaptiveTextAlign.Center,
                HintStyle = AdaptiveTextStyle.CaptionSubtle
            }
        }
    };
}
```

**結果:**

![背景画像の例](images/adaptive-tiles-backgroundimage.png)

### <a name="peek-image"></a>プレビュー画像

タイルでアニメーション化されるプレビュー画像を指定できます。 プレビュー画像はタイルでアニメーション化されます。コンテンツが下にスライドしてプレビューが現れ、上にスライドしてプレビューが隠れます。 プレビュー画像を設定するには、&lt;binding&gt; のルートに image 要素を追加し、placement 属性を "peek" に設定します。

```xml
<binding template="TileMedium" branding="name">
  <image placement="peek" src="Assets/Apps/Hipstame/hipster.jpg"/>
  <text>New Message</text>
  <text hint-style="captionsubtle" hint-wrap="true">Hey, have you tried Windows 10 yet?</text>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Branding = TileBranding.Name,
    Content = new TileBindingContentAdaptive()
    {
        PeekImage = new TilePeekImage()
        {
            Source = "Assets/Apps/Hipstame/hipster.jpg"
        },
        Children =
        {
            new AdaptiveText()
            {
                Text = "New Message"
            },
            new AdaptiveText()
            {
                Text = "Hey, have you tried Windows 10 yet?",
                HintStyle = AdaptiveTextStyle.CaptionSubtle,
                HintWrap = true
            }
        }
    }
}
```

![プレビュー画像の例](images/adaptive-tiles-imagepeeking.png)

**プレビュー画像と背景画像の円トリミング**

円トリミングを行うには、プレビュー画像と背景画像で hint-crop 属性を使用します。

```xml
<image placement="peek" hint-crop="circle" src="Assets/Apps/Hipstame/hipster.jpg"/>
```

```csharp
new TilePeekImage()
{
    HintCrop = TilePeekImageCrop.Circle,
    Source = "Assets/Apps/Hipstame/hipster.jpg"
}
```

結果は次のようになります。

![プレビュー画像と背景画像の円トリミング](images/circlecrop-image.png)

**プレビュー画像と背景画像の両方を使用**

タイル通知でプレビュー画像と背景画像の両方を使用するには、通知ペイロードでプレビュー画像と背景画像の両方を指定します。

結果は次のようになります。

![一緒に使用されているプレビュー画像と背景画像](images/peekandbackground.png)


### <a name="peek-and-background-image-overlays"></a>プレビュー画像と背景画像のオーバーレイ

**hint-overlay** を使って、背景画像とプレビュー画像上に黒のオーバーレイを設定できます。この属性は 0 ～ 100 の整数を受け取ります。0 はオーバーレイなし、100 は完全な黒のオーバーレイを表します。 オーバーレイを使うことで、タイル上のテキストを読みやすく表示できます。

**背景画像での hint-overlay の使用**

ペイロードにテキスト要素が含まれている場合、背景画像のオーバーレイは既定で 20% です (そうでない場合、既定のオーバーレイは 0% です)。

```xml
<binding template="TileWide">
  <image placement="background" hint-overlay="60" src="Assets\Mostly Cloudy-Background.jpg"/>
  ...
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        BackgroundImage = new TileBackgroundImage()
        {
            Source = "Assets/Mostly Cloudy-Background.jpg",
            HintOverlay = 60
        },

        ...
    }
}
```

**結果:**

![画像のオーバーレイの例](images/adaptive-tiles-image-hintoverlay.png)

**プレビュー画像での hint-overlay の使用**

Windows 10 Version 1511 では、背景画像と同様、プレビュー画像のオーバーレイもサポートされています。 プレビュー画像要素の hint-overlay には、0 ～ 100 の整数を指定します。 プレビュー画像の既定のオーバーレイは、0 (オーバーレイなし) です。

```xml
<binding template="TileMedium">
  <image hint-overlay="20" src="Assets\Map.jpg" placement="peek"/>
  ...
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    Content = new TileBindingContentAdaptive()
    {
        PeekImage = new TilePeekImage()
        {
            Source = "Assets/Map.jpg",
            HintOverlay = 20
        },
        ...
    }
}
```

以下の例では、20% の不透明度 (左) と 0% の不透明度 (右) のプレビュー画像を示しています。

![プレビュー画像での hint-overlay](images/hintoverlay.png)

## <a name="vertical-alignment-text-stacking"></a>縦方向の配置 (テキストの積み重ね)


[TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) 要素と [AdaptiveSubgroup](../tiles-and-notifications/tile-schema.md#adaptivesubgroup) 要素のいずれに対しても **hint-textStacking** 属性を使って、タイルのコンテンツの縦方向の配置を制御できます。 既定では、コンテンツは上揃えになりますが、下揃えまたは中央揃えに設定することもできます。

### <a name="text-stacking-on-binding-element"></a>binding 要素でのテキストの積み重ね

テキストの積み重ねを [TileBinding](../tiles-and-notifications/tile-schema.md#tilebinding) レベルで適用すると、ブランディング/バッジ領域の上にある縦方向のスペースに収まるように、通知コンテンツ全体の縦方向の配置が設定されます。

```xml
<binding template="TileMedium" hint-textStacking="center" branding="logo">
  <text hint-style="base" hint-align="center">Hi,</text>
  <text hint-style="captionSubtle" hint-align="center">MasterHip</text>
</binding>
```

```csharp
TileMedium = new TileBinding()
{
    Branding = TileBranding.Logo,
    Content = new TileBindingContentAdaptive()
    {
        TextStacking = TileTextStacking.Center,
        Children =
        {
            new AdaptiveText()
            {
                Text = "Hi,",
                HintStyle = AdaptiveTextStyle.Base,
                HintAlign = AdaptiveTextAlign.Center
            },

            new AdaptiveText()
            {
                Text = "MasterHip",
                HintStyle = AdaptiveTextStyle.CaptionSubtle,
                HintAlign = AdaptiveTextAlign.Center
            }
        }
    }
}
```

![binding 要素でのテキストの積み重ね](images/adaptive-tiles-textstack-bindingelement.png)

### <a name="text-stacking-on-subgroup-element"></a>subgroup 要素でのテキストの積み重ね

テキストの積み重ねを [AdaptiveSubgroup](../tiles-and-notifications/tile-schema.md#adaptivesubgroup) レベルで適用すると、そのグループ内の縦方向のスペースに収まるように、サブグループ (列) コンテンツの縦方向の配置が設定されます。

```xml
<binding template="TileWide" branding="nameAndLogo">
  <group>
    <subgroup hint-weight="33">
      <image src="Assets/Apps/Hipstame/hipster.jpg" hint-crop="circle"/>
    </subgroup>
    <subgroup hint-textStacking="center">
      <text hint-style="subtitle">Hi,</text>
      <text hint-style="bodySubtle">MasterHip</text>
    </subgroup>
  </group>
</binding>
```

```csharp
TileWide = new TileBinding()
{
    Branding = TileBranding.NameAndLogo,
    Content = new TileBindingContentAdaptive()
    {
        Children =
        {
            new AdaptiveGroup()
            {
                Children =
                {
                    // Image column
                    new AdaptiveSubgroup()
                    {
                        HintWeight = 33,
                        Children =
                        {
                            new AdaptiveImage()
                            {
                                Source = "Assets/Apps/Hipstame/hipster.jpg",
                                HintCrop = AdaptiveImageCrop.Circle
                            }
                        }
                    },

                    // Text column
                    new AdaptiveSubgroup()
                    {
                        // Vertical align its contents
                        TextStacking = TileTextStacking.Center,
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "Hi,",
                                HintStyle = AdaptiveTextStyle.Subtitle
                            },

                            new AdaptiveText()
                            {
                                Text = "MasterHip",
                                HintStyle = AdaptiveTextStyle.BodySubtle
                            }
                        }
                    }
                }
            }
        }
    }
}
```

## <a name="related-topics"></a>関連トピック
* [タイルのコンテンツのスキーマ](../tiles-and-notifications/tile-schema.md)
* [ローカル タイル通知の送信](sending-a-local-tile-notification.md)
* [特別なタイル テンプレート](special-tile-templates-catalog.md)
* [UWP コミュニティ ツールキット - Notifications](https://github.com/Microsoft/UWPCommunityToolkit/tree/master/Microsoft.Toolkit.Uwp.Notifications)
* [GitHub の Windows Notifications](https://github.com/WindowsNotifications)

 

 




