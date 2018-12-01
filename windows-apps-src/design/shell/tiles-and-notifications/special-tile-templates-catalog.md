---
Description: Special tile templates are unique templates that are either animated, or just allow you to do things that aren't possible with adaptive tiles.
title: 特別なタイル テンプレート
ms.assetid: 1322C9BA-D5B2-45E2-B813-865884A467FF
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 09647347134463c8dd2d93f6b869796c8def44e2
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8344319"
---
# <a name="special-tile-templates"></a>特別なタイル テンプレート
 

特別なタイル テンプレートは、アニメーション化や、アダプティブ タイルでは不可能な機能を実行できる独特なテンプレートです。 各特別なタイル テンプレート具体的には用にビルドした windows 10、アイコン タイル テンプレートを除くクラシック特別なテンプレートが windows 10 に更新されました。 この記事では、3 つの特別なタイル テンプレートである、アイコン タイル テンプレート、フォト タイル テンプレート、および People タイル テンプレートについて取り上げています。

## <a name="iconic-tile-template"></a>アイコン タイル テンプレート


アイコン テンプレート ("IconWithBadge" テンプレートとも呼ばれます) を使うと、タイルの中央に小さい画像を表示できます。 Windows 10 では、電話とタブレット/デスクトップの両方でテンプレートをサポートしています。

![小サイズと普通サイズのメール タイル](images/iconic-template-mail-2sizes.png)

### <a name="how-to-create-an-iconic-tile"></a>アイコン タイルを作成する方法

次の手順では、windows 10 のアイコン タイルを作成するために必要なすべてについて説明します。 大まかに言うと、まずアイコンの画像アセットを用意する必要があります。次に、アイコン テンプレートを使って通知をタイルに送信し、最後に、タイルに表示される番号を指定するバッジ通知を送信します。

![アイコン タイルの開発フロー](images/iconic-template-dev-flow.png)

**手順 1: 画像アセットを PNG 形式で作成する**

タイルのアイコン アセットを作成し、他のアセットと共にプロジェクト リソースに配置します。 200 x 200 ピクセル以上のアイコンを作成してください。これは最小サイズで、電話やデスクトップ上の小サイズと普通サイズのタイルのどちらにも使うことができます。 最適なユーザー エクスペリエンスを実現するには、各サイズのアイコンを作成します。 これらのアセットにはパディングは必要ありません。 サイズについて詳しくは、次の画像をご覧ください。

透明度を設定し、PNG 形式でアイコン アセットを保存します。 Windows Phone では、透明でないピクセルは白色 (RGB 255, 255, 255) で表示されます。 一貫性と簡素化を保つには、デスクトップのアイコンにも白色を使ってください。

タブレット、ノート PC、デスクトップの Windows 10 では、正方形のアイコン アセットのみがサポートされます。 Windows Phone では、正方形のアセットと、電話アイコンなどの画像に便利な、高さが幅よりも大きいアセット (幅と高さの比率は最大 2:3) の両方がサポートされます。

![小サイズと普通サイズのタイルでのアイコンのサイズ (電話とデスクトップ)](images/iconic-template-sizing-info.png)

![バッジがあるアセットとバッジがないアセットのサイズ調整](images/assetguidance24.png)

正方形のアセットの場合、コンテナー内で自動的に中央に配置されます。

![正方形のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance25.png)

正方形以外のアセットの場合、自動的に水平方向/垂直方向の中央に配置され、コンテナーの幅/高さに合わせてスナップされます。

![正方形以外のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance26a.png)

![正方形以外のアセットのサイズ調整、バッジがある場合とバッジがない場合](images/assetguidance26b.png)

**手順 2: ベース タイルを作成する**

アイコン テンプレートは、プライマリ タイルとセカンダリ タイルのどちらでも使うことができます。 セカンダリ タイルで使う場合は、最初にセカンダリ タイルを作成するか、既にピン留めされているセカンダリ タイルを使う必要があります。 プライマリ タイルは暗黙的にピン留めされるので、このタイルに対しては常に通知を送信することができます。

**手順 3: 通知をタイルに送信する**

この手順は、通知をローカルで送信するのか、サーバー プッシュを使って送信するのかによって異なります。ただし、送信する XML ペイロードは変わりません。 ローカル タイル通知を送信するには、タイル (プライマリ タイルまたはセカンダリ タイル) に対して [**TileUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.TileUpdater) を作成してから、次に示すように、アイコン タイル テンプレートを使うタイルに通知を送信します。 また、[アダプティブ タイル テンプレート](create-adaptive-tiles.md)を使って、ワイド タイルや大きいタイルのバインドを含めることをお勧めします。

XML ペイロードのサンプル コードを次に示します。

```xml
<tile>
  <visual>

    <binding template="TileSquare150x150IconWithBadge">
      <image id="1" src="Iconic.png" alt="alt text"/>
    </binding>
    
    <binding template="TileSquare71x71IconWithBadge">
      <image id="1" src="Iconic.png" alt="alt text"/>
    </binding>

  </visual>
</tile>
```

このアイコン タイル テンプレートの XML ペイロードでは、手順 1. で作成した画像を示す image 要素を使います。 これで、タイルのアイコンの横にバッジを表示する準備ができました。あとは、バッジ通知を送信するだけです。

**手順 4: バッジ通知をタイルに送信する**

手順 3. と同様に、この手順は、通知をローカルで送信するのか、サーバー プッシュを使って送信するのかによって異なります。ただし、送信する XML ペイロードは変わりません。 ローカル バッジ通知を送信するには、タイル (プライマリ タイルまたはセカンダリ タイル) に対して [**BadgeUpdater**](https://docs.microsoft.com/uwp/api/Windows.UI.Notifications.BadgeUpdater) を作成してから、目的の値を使ってバッジ通知を送信します (またはバッジをクリアします)。

XML ペイロードのサンプル コードを次に示します。

```xml
<badge value="2"/>
```

タイルのバッジは状況に応じて適切に更新されます。

**手順 5: 組み立てる**

次の図は、さまざまな API やペイロードがアイコン タイル テンプレートの各要素とどのように関連しているかを示しています。 [タイル通知](https://msdn.microsoft.com/library/windows/apps/hh779724) (&lt;binding&gt; 要素が含まれています) を使って、アイコン テンプレートと画像アセットを指定します。[バッジ通知](https://msdn.microsoft.com/library/windows/apps/hh779719)では、数値を指定し、タイル プロパティによってタイルの表示名や色などを制御します。

![アイコン タイル テンプレートに関連付けられている API とペイロード](images/iconic-template-properties-info.png)

## <a name="photos-tile-template"></a>フォト タイル テンプレート


フォト タイル テンプレートを使うと、ライブ タイルに写真のスライドショーを表示できます。 このテンプレートは、すべてのタイルのサイズ (小サイズのタイルを含む) でサポートされており、各サイズのタイルで同じ動作をします。 次の例は、フォト テンプレートを使った普通サイズのタイルが持つ 5 つのフレームを示しています。 テンプレートには、ズームやクロスフェード アニメーションが用意されており、選んだ写真に対して繰り返し適用し、無限にループすることができます。

![フォト タイル テンプレートを使った画像のスライド ショー](images/photo-tile-template-image01.jpg)

### <a name="how-to-use-the-photos-template"></a>フォト テンプレートを使う方法

[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)がインストールされていれば、フォト テンプレートを簡単に使うことができます。 生の XML を使うこともできますが、このライブラリの利用を強くお勧めします。これにより、開発者は有効な XML や XML エスケープされたコンテンツの生成について考える必要がなくなります。

Windows Phone では、スライド ショーで最大 9 枚の写真を表示できます。タブレット、ノート PC、デスクトップでは、最大で 12 枚の写真を表示できます。

タイル通知の送信について詳しくは、[通知の送信に関する記事](index.md)をご覧ください。


```xml
<!--
 
To use the Photos template...
 
 - On any adaptive tile binding (like TileMedium or TileWide)
   - Set the hint-presentation attribute to "photos"
   - Add up to 12 images as children of the binding.
    
-->
 
<tile>
  <visual>
     
    <binding template="TileMedium" hint-presentation="photos">
       
      <image src="Assets/1.jpg" />
      <image src="ms-appdata:///local/Images/2.jpg"/>
      <image src="http://msn.com/images/3.jpg"/>
       
      <!--TODO: Can have 12 images total-->
       
    </binding>
     
    <!--TODO: Add bindings for other tile sizes-->
     
  </visual>
</tile>
```

```csharp
/*
 
To use the Photos template...
 
 - On any TileBinding object
   - Set Content property to new instance of TileBindingContentPhotos
   - Add up to 12 images to Images property of TileBindingContentPhotos.
 
*/
 
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentPhotos()
            {
                Images =
                {
                    new TileBasicImage() { Source = "Assets/1.jpg" },
                    new TileBasicImage() { Source = "ms-appdata:///local/Images/2.jpg" },
                    new TileBasicImage() { Source = "http://msn.com/images/3.jpg" }
 
                    // TODO: Can have 12 images total
                }
            }
        }
 
        // TODO: Add other tile sizes
    }
};
```

## <a name="people-tile-template"></a>People タイル テンプレート


Windows 10 の People アプリでは、円の中に画像のコレクションを表示する特別なタイル テンプレートを使います。これらの円は、タイル上で垂直方向または水平方向にスライドされます。 このタイル テンプレートが利用可能な windows 10 ビルド 10572、およびはどなたでも、アプリで使うことです。

People タイル テンプレートは、次のサイズのタイルで動作します。

**普通サイズのタイル** (TileMedium)

![普通サイズの People タイル](images/people-tile-medium.png)

 

**ワイド タイル** (TileWide)

![ワイド People タイル](images/people-tile-wide.png)

 

**大きいタイル (デスクトップのみ)** (TileLarge)

![大きい People タイル](images/people-tile-large.png)

 

[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)を使っている場合、People タイル テンプレートを利用するために必要な操作は、*TileBinding* コンテンツ用に新しい *TileBindingContentPeople* オブジェクトを作成することだけです。 *TileBindingContentPeople* クラスには、画像を追加するための Images プロパティがあります。

生の XML を使っている場合は、*hint-presentation* を "people" に設定し、画像を binding 要素の子として追加します。

次の C# コード サンプルは、[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/) を使っていることを前提としています。

```csharp
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentPeople()
            {
                Images =
                {
                    new TileBasicImage() { Source = "Assets/ProfilePics/1.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/2.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/3.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/4.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/5.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/6.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/7.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/8.jpg" },
                    new TileBasicImage() { Source = "Assets/ProfilePics/9.jpg" }
                }
            }
        }
    }
};
```

```xml
<tile>
  <visual>
 
    <binding template="TileMedium" hint-presentation="people">
      <image src="Assets/ProfilePics/1.jpg"/>
      <image src="Assets/ProfilePics/2.jpg"/>
      <image src="Assets/ProfilePics/3.jpg"/>
      <image src="Assets/ProfilePics/4.jpg"/>
      <image src="Assets/ProfilePics/5.jpg"/>
      <image src="Assets/ProfilePics/6.jpg"/>
      <image src="Assets/ProfilePics/7.jpg"/>
      <image src="Assets/ProfilePics/8.jpg"/>
      <image src="Assets/ProfilePics/9.jpg"/>
    </binding>
 
  </visual>
</tile>
```

最適なユーザー エクスペリエンスを実現するには、タイルの各サイズに対して、写真の数を次のように指定することをお勧めします。

-   普通サイズのタイル: 9 枚の写真
-   ワイド タイル: 15 枚の写真
-   大きいタイル: 20 枚の写真

このように写真の枚数を指定することで、空の円をいくつか使うことができます。これにより、タイルが表示中にビジー状態になりません。 写真の数を自由に調整して、最適な表示状態を確認してください。

通知を送信するには、「[通知配信方法の選択](choosing-a-notification-delivery-method.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック


* [GitHub での完全なコード サンプル](https://github.com/WindowsNotifications/quickstart-people-tile-template)
* [Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)
* [タイル、バッジ、および通知](index.md)
* [アダプティブ タイルの作成](create-adaptive-tiles.md)
* [タイルのコンテンツのスキーマ](../tiles-and-notifications/tile-schema.md)
 

 




