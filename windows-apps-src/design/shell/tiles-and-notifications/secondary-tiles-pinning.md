---
Description: Learn how to pin a secondary tile to Start from your UWP app.
title: スタート画面にセカンダリ タイルをピン留め
label: Pin secondary tiles to Start
template: detail.hbs
ms.date: 05/25/2017
ms.topic: article
keywords: Windows 10、UWP、セカンダリ タイル、ピン留め、クイック スタート、コード サンプル、例
ms.localizationpriority: medium
ms.openlocfilehash: 4bebee86c824242cf031503617d4a880ebbb74df
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8352486"
---
# <a name="pin-secondary-tiles-to-start"></a>スタート画面にセカンダリ タイルをピン留め


このトピックでは、UWP アプリのセカンダリ タイルを作り、スタート メニューにピン留めする手順について説明します。

![セカンダリ タイルのスクリーン ショット](images/secondarytiles.png)

セカンダリ タイルについて詳しくは、「[セカンダリ タイルの概要](secondary-tiles.md)」をご覧ください。


## <a name="add-namespace"></a>名前空間を追加する

Windows.UI.StartScreen 名前空間には SecondaryTile クラスが含まれています。

```csharp
using Windows.UI.StartScreen;
```


## <a name="initialize-the-secondary-tile"></a>セカンダリ タイルを初期化する

セカンダリ タイルは、いくつかの主要なコンポーネントで構成されます。

* **TileId**: 他のセカンダリ タイルからタイルを識別する一意の識別子。
* **DisplayName**: タイルに表示される名前。
* **Arguments**: ユーザーがタイルをクリックしたときにアプリに戻される引数。
* **Square150x150Logo**: 中サイズのタイルで表示される、必須のロゴ (小サイズのロゴが提供されない場合には、小サイズにサイズ変更されます)。

上記のすべてのプロパティに初期化された値を提供する**必要があります**。提供されない場合には、例外がスローされます。

さまざまなコンストラクターを使用することができますが、tileId、displayName、引数、square150x150Logo、desiredSize でコンストラクターを使用すると、必須のプロパティをすべて設定するようにできます。

```csharp
// Construct a unique tile ID, which you will need to use later for updating the tile
string tileId = "City" + zipCode;

// Use a display name you like
string displayName = cityName;

// Provide all the required info in arguments so that when user
// clicks your tile, you can navigate them to the correct content
string arguments = "action=viewCity&zipCode=" + zipCode;

// Initialize the tile with required arguments
SecondaryTile tile = new SecondaryTile(
    tileId,
    displayName,
    arguments,
    new Uri("ms-appx:///Assets/CityTiles/Square150x150Logo.png"),
    TileSize.Default);
```


## <a name="optional-add-support-for-larger-tile-sizes"></a>オプション: より大きいタイル サイズのサポートを追加します。

セカンダリ タイルにリッチなタイル通知を表示する場合、ユーザーがタイルのサイズをワイド サイズや大サイズに変更して、より多くのコンテンツを表示できるようにすることが望まれます。

ワイド サイズ、大サイズのタイルを有効化するには、*Wide310x150Logo* および *Square310x310Logo* を提供する必要があります。 また、可能であれば、小サイズのタイル用に *Square71x71Logo* を提供します (提供されない場合、小サイズ用に必要な Square150x150Logo は自動的にサイズ変更して作成されます)。

さらに、独自の *Square44x44Logo* を提供すると、通知が表示されるときに右下隅にオプションとして表示されます。 提供されない場合には、代わりにプライマリ タイルの *Square44x44Logo* が使用されます。

```csharp
// Enable wide and large tile sizes
tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/CityTiles/Wide310x150Logo.png");
tile.VisualElements.Square310x310Logo = new Uri("ms-appx:///Assets/CityTiles/Square310x310Logo.png");

// Add a small size logo for better looking small tile
tile.VisualElements.Square71x71Logo = new Uri("ms-appx:///Assets/CityTiles/Square71x71Logo.png");

// Add a unique corner logo for the secondary tile
tile.VisualElements.Square44x44Logo = new Uri("ms-appx:///Assets/CityTiles/Square44x44Logo.png");
```


## <a name="optional-enable-showing-the-display-name"></a>オプション: 表示名の表示を有効にする

既定では、表示名は表示されません。 中サイズ、ワイド サイズ、大サイズで表示名を表示するには、次のコードを追加します。

```csharp
// Show the display name on all sizes
tile.VisualElements.ShowNameOnSquare150x150Logo = true;
tile.VisualElements.ShowNameOnWide310x150Logo = true;
tile.VisualElements.ShowNameOnSquare310x310Logo = true;
```


## <a name="optional-3d-secondary-tiles"></a>オプション: 3D セカンダリ タイル
3D アセットを追加して、Windows Mixed Reality に対応することで、さらに高度なセカンダリ タイルを作成できます。 アプリを Mixed Reality 環境で使用すると、ユーザーは 3D タイルをスタート メニューではなく、Windows Mixed Reality ホームに直接配置できます。 たとえば、360° フォト ビューアー アプリに直接リンクした 360° フォトスフィアを作成したり、ユーザーが家具のカタログから椅子の 3D モデルを配置して、選択するとそのオブジェクトの価格やカラー展開に関する詳細ページが開くようにしたりすることができます。 この機能を使い始めるには、[Mixed Reality の開発者向けドキュメント](https://developer.microsoft.com/windows/mixed-reality/implementing_3d_deep_links_for_your_app_in_the_windows_mixed_reality_home)をご覧ください。



## <a name="pin-the-secondary-tile"></a>セカンダリ タイルをピン留めする

最後に、タイルのピン留めを要求します。 これは UI スレッドから呼び出す必要があることに注意してください。 デスクトップに、ユーザーにタイルをピン留めするかどうかの確認を求める、ダイアログが表示されます。

> [!IMPORTANT]
> デスクトップ ブリッジを使った Windows デスクトップ アプリケーションの場合は、まず「[デスクトップ アプリケーションからピン留めする](secondary-tiles-desktop-pinning.md)」に記載された追加の手順を実行する必要があります。

```csharp
// Pin the tile
bool isPinned = await tile.RequestCreateAsync();

// TODO: Update UI to reflect whether user can now either unpin or pin
```


## <a name="check-if-a-secondary-tile-exists"></a>セカンダリ タイルが存在するかを確認する

既にスタートにピン留めされているアプリのページでは、[ピン留めを外す] ボタンを表示するようにします。

このため、表示ボタンを選ぶときには、セカンダリ タイルが既にピン留めされているかどうかを確認する必要があります。

```csharp
// Check if the secondary tile is pinned
bool isPinned = SecondaryTile.Exists(tileId);

// TODO: Update UI to reflect whether user can either unpin or pin
```


## <a name="unpinning-a-secondary-tile"></a>セカンダリ タイルのピン留めを外す

タイルが既にピン留めされているときに、ユーザーが [ピン留めを外す] ボタンをクリックした場合には、タイルのピン留めを外す (削除する) 必要があります。

```csharp
// Initialize a secondary tile with the same tile ID you want removed
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then unpin the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="updating-a-secondary-tile"></a>セカンダリ タイルを更新する

ロゴ、表示名、その他のセカンダリ タイル上の情報を更新する場合には、*RequestUpdateAsync* を使用できます。

```csharp
// Initialize a secondary tile with the same tile ID you want to update
SecondaryTile tile = new SecondaryTile(tileId);

// Assign ALL properties, including ones you aren't changing

// And then update it
await tile.UpdateAsync();
```


## <a name="enumerating-all-pinned-secondary-tiles"></a>ピン留めされているすべてのセカンダリ タイルを列挙する

ユーザーがピン留めしたすべてのタイルを検出する必要がある場合、*SecondaryTile.Exists* を使用する代わりに、*SecondaryTile.FindAllAsync()* を使用することができます。

```csharp
// Get all secondary tiles
var tiles = await SecondaryTile.FindAllAsync();
```


## <a name="send-a-tile-notification"></a>タイル通知を送信する

タイル通知を使って、タイルにリッチ コンテンツを表示する方法については、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」をご覧ください。


## <a name="related"></a>関連

* [セカンダリ タイルの概要](secondary-tiles.md)
* [セカンダリ タイルのガイダンス](secondary-tiles-guidance.md)
* [タイル アセット](app-assets.md)
* [タイル コンテンツのドキュメント](create-adaptive-tiles.md)
* [ローカル タイル通知の送信](sending-a-local-tile-notification.md)
