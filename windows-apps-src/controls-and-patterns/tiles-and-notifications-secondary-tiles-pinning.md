---
author: anbare
Description: "UWP アプリからセカンダリ タイルをピン留めする方法について説明します。"
title: "セカンダリ タイルをピン留めする"
label: Pin secondary tiles
template: detail.hbs
ms.author: wdg-dev-content
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、セカンダリ タイル、ピン留め、クイック スタート、コード サンプル、例"
ms.openlocfilehash: 9525dc91ddd40265d7c7fa9ff8e73509ba3029ab
ms.sourcegitcommit: 6396a69aab081f5c7a9a59739c83538616d3b1c7
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/30/2017
---
# <a name="pin-secondary-tiles"></a><span data-ttu-id="c5b9d-104">セカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="c5b9d-104">Pin secondary tiles</span></span>
<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="c5b9d-105">このトピックでは、UWP アプリのセカンダリ タイルを作り、スタート メニューにピン留めする手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-105">This topic walks you through the steps to create a secondary tile for your UWP app and pin it to the Start menu.</span></span>

![セカンダリ タイルのスクリーン ショット](images/secondarytiles.png)

<span data-ttu-id="c5b9d-107">セカンダリ タイルについて詳しくは、「[セカンダリ タイルの概要](tiles-and-notifications-secondary-tiles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-107">To learn more about secondary tiles, please see the [Secondary tiles overview](tiles-and-notifications-secondary-tiles.md).</span></span>


## <a name="add-namespace"></a><span data-ttu-id="c5b9d-108">名前空間を追加する</span><span class="sxs-lookup"><span data-stu-id="c5b9d-108">Add namespace</span></span>

<span data-ttu-id="c5b9d-109">Windows.UI.StartScreen 名前空間には SecondaryTile クラスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-109">The Windows.UI.StartScreen namespace includes the SecondaryTile class.</span></span>

```csharp
using Windows.UI.StartScreen;
```


## <a name="initialize-the-secondary-tile"></a><span data-ttu-id="c5b9d-110">セカンダリ タイルを初期化する</span><span class="sxs-lookup"><span data-stu-id="c5b9d-110">Initialize the secondary tile</span></span>

<span data-ttu-id="c5b9d-111">セカンダリ タイルは、いくつかの主要なコンポーネントで構成されます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-111">Secondary tiles are composed of a few key components...</span></span>

* <span data-ttu-id="c5b9d-112">**TileId**: 他のセカンダリ タイルからタイルを識別する一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-112">**TileId**: A unique identifier that lets you identify the tile among your other secondary tiles.</span></span>
* <span data-ttu-id="c5b9d-113">**DisplayName**: タイルに表示される名前。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-113">**DisplayName**: The name you want shown on the tile.</span></span>
* <span data-ttu-id="c5b9d-114">**Arguments**: ユーザーがタイルをクリックしたときにアプリに戻される引数。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-114">**Arguments**: The arguments you want passed back to your app when the user clicks your tile.</span></span>
* <span data-ttu-id="c5b9d-115">**Square150x150Logo**: 中サイズのタイルで表示される、必須のロゴ (小サイズのロゴが提供されない場合には、小サイズにサイズ変更されます)。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-115">**Square150x150Logo**: The required logo, displayed on the medium size tile (and resized to small size tile if no small logo provided).</span></span>

<span data-ttu-id="c5b9d-116">上記のすべてのプロパティに初期化された値を提供する**必要があります**。提供されない場合には、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-116">You **MUST** provide initialized values for all of the above properties, or else you will get an exception.</span></span>

<span data-ttu-id="c5b9d-117">さまざまなコンストラクターを使用することができますが、tileId、displayName、引数、square150x150Logo、desiredSize でコンストラクターを使用すると、必須のプロパティをすべて設定するようにできます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-117">There are a variety of constructors you can use, but using the constructor that takes in the tileId, displayName, arguments, square150x150Logo, and desiredSize helps ensure you set all of the required properties.</span></span>

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


## <a name="optional-add-support-for-larger-tile-sizes"></a><span data-ttu-id="c5b9d-118">オプション: より大きいタイル サイズのサポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-118">Optional: Add support for larger tile sizes</span></span>

<span data-ttu-id="c5b9d-119">セカンダリ タイルにリッチなタイル通知を表示する場合、ユーザーがタイルのサイズをワイド サイズや大サイズに変更して、より多くのコンテンツを表示できるようにすることが望まれます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-119">If you're going to be displaying rich tile notifications on your secondary tile, you'll likely want to allow the user to resize their tile to be wide or large, so that they can see even more of your content.</span></span>

<span data-ttu-id="c5b9d-120">ワイド サイズ、大サイズのタイルを有効化するには、*Wide310x150Logo* および *Square310x310Logo* を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-120">To enable wide and large tile sizes, you need to provide the *Wide310x150Logo* and *Square310x310Logo*.</span></span> <span data-ttu-id="c5b9d-121">また、可能であれば、小サイズのタイル用に *Square71x71Logo* を提供します (提供されない場合、小サイズ用に必要な Square150x150Logo は自動的にサイズ変更して作成されます)。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-121">Also, if possible, you should provide the *Square71x71Logo* for the small tile size (otherwise we will downsize your required Square150x150Logo for the small tile).</span></span>

<span data-ttu-id="c5b9d-122">さらに、独自の *Square44x44Logo* を提供すると、通知が表示されるときに右下隅にオプションとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-122">You can also provide a unique *Square44x44Logo*, which is optionally displayed on the bottom right corner when a notification is present.</span></span> <span data-ttu-id="c5b9d-123">提供されない場合には、代わりにプライマリ タイルの *Square44x44Logo* が使用されます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-123">If you don't provide one, the *Square44x44Logo* from your primary tile will be used instead.</span></span>

```csharp
// Enable wide and large tile sizes
tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/CityTiles/Wide310x150Logo.png");
tile.VisualElements.Square310x310Logo = new Uri("ms-appx:///Assets/CityTiles/Square310x310Logo.png");

// Add a small size logo for better looking small tile
tile.VisualElements.Square71x71Logo = new Uri("ms-appx:///Assets/CityTiles/Square71x71Logo.png");

// Add a unique corner logo for the secondary tile
tile.VisualElements.Square44x44Logo = new Uri("ms-appx:///Assets/CityTiles/Square44x44Logo.png");
```


## <a name="optional-enable-showing-the-display-name"></a><span data-ttu-id="c5b9d-124">オプション: 表示名の表示を有効にする</span><span class="sxs-lookup"><span data-stu-id="c5b9d-124">Optional: Enable showing the display name</span></span>

<span data-ttu-id="c5b9d-125">既定では、表示名は表示されません。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-125">By default the display name will NOT be shown.</span></span> <span data-ttu-id="c5b9d-126">中サイズ、ワイド サイズ、大サイズで表示名を表示するには、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-126">To show the display name on medium/wide/large, add the following code.</span></span>

```csharp
// Show the display name on all sizes
tile.VisualElements.ShowNameOnSquare150x150Logo = true;
tile.VisualElements.ShowNameOnWide310x150Logo = true;
tile.VisualElements.ShowNameOnSquare310x310Logo = true;
```


## <a name="pin-the-secondary-tile"></a><span data-ttu-id="c5b9d-127">セカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="c5b9d-127">Pin the secondary tile</span></span>

<span data-ttu-id="c5b9d-128">最後に、タイルのピン留めを要求します。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-128">Finally, request to pin the tile.</span></span> <span data-ttu-id="c5b9d-129">これは UI スレッドから呼び出す必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-129">Note that this must be called from a UI thread.</span></span> <span data-ttu-id="c5b9d-130">デスクトップに、ユーザーにタイルをピン留めするかどうかの確認を求める、ダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-130">On Desktop, a dialog will appear asking the user to confirm whether they would like to pin the tile.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c5b9d-131">デスクトップ ブリッジを使った Windows デスクトップ アプリケーションの場合は、まず「[デスクトップ アプリケーションからピン留めする](tiles-and-notifications-secondary-tiles-desktop-pinning.md)」に記載された追加の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-131">If you are a Windows desktop application using the Desktop Bridge, you must first perform an extra step as described in [Pin from desktop application](tiles-and-notifications-secondary-tiles-desktop-pinning.md)</span></span>

```csharp
// Pin the tile
bool isPinned = await tile.RequestCreateAsync();

// TODO: Update UI to reflect whether user can now either unpin or pin
```


## <a name="check-if-a-secondary-tile-exists"></a><span data-ttu-id="c5b9d-132">セカンダリ タイルが存在するかを確認する</span><span class="sxs-lookup"><span data-stu-id="c5b9d-132">Check if a secondary tile exists</span></span>

<span data-ttu-id="c5b9d-133">既にスタートにピン留めされているアプリのページでは、[ピン留めを外す] ボタンを表示するようにします。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-133">If your user visits a page in your app that they have already pinned to Start, you will want to instead display an "Unpin" button.</span></span>

<span data-ttu-id="c5b9d-134">このため、表示ボタンを選ぶときには、セカンダリ タイルが既にピン留めされているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-134">Therefore, when choosing what button to display, you need to first check whether the secondary tile is currently pinned.</span></span>

```csharp
// Check if the secondary tile is pinned
bool isPinned = SecondaryTile.Exists(tileId);

// TODO: Update UI to reflect whether user can either unpin or pin
```


## <a name="unpinning-a-secondary-tile"></a><span data-ttu-id="c5b9d-135">セカンダリ タイルのピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="c5b9d-135">Unpinning a secondary tile</span></span>

<span data-ttu-id="c5b9d-136">タイルが既にピン留めされているときに、ユーザーが [ピン留めを外す] ボタンをクリックした場合には、タイルのピン留めを外す (削除する) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-136">If the tile is currently pinned, and the user clicks your unpin button, you'll want to unpin (delete) the tile.</span></span>

```csharp
// Initialize a secondary tile with the same tile ID you want removed
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then unpin the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="updating-a-secondary-tile"></a><span data-ttu-id="c5b9d-137">セカンダリ タイルを更新する</span><span class="sxs-lookup"><span data-stu-id="c5b9d-137">Updating a secondary tile</span></span>

<span data-ttu-id="c5b9d-138">ロゴ、表示名、その他のセカンダリ タイル上の情報を更新する場合には、*RequestUpdateAsync* を使用できます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-138">If you need to update the logos, display name, or anything else on the secondary tile, you can use *RequestUpdateAsync*.</span></span>

```csharp
// Initialize a secondary tile with the same tile ID you want to update
SecondaryTile tile = new SecondaryTile(tileId);

// Assign ALL properties, including ones you aren't changing

// And then update it
await tile.UpdateAsync();
```


## <a name="enumerating-all-pinned-secondary-tiles"></a><span data-ttu-id="c5b9d-139">ピン留めされているすべてのセカンダリ タイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="c5b9d-139">Enumerating all pinned secondary tiles</span></span>

<span data-ttu-id="c5b9d-140">ユーザーがピン留めしたすべてのタイルを検出する必要がある場合、*SecondaryTile.Exists* を使用する代わりに、*SecondaryTile.FindAllAsync()* を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-140">If you need to discover all the tiles your user has pinned, instead of using *SecondaryTile.Exists*, you can alternatively use *SecondaryTile.FindAllAsync()*.</span></span>

```csharp
// Get all secondary tiles
var tiles = await SecondaryTile.FindAllAsync();
```


## <a name="send-a-tile-notification"></a><span data-ttu-id="c5b9d-141">タイル通知を送信する</span><span class="sxs-lookup"><span data-stu-id="c5b9d-141">Send a tile notification</span></span>

<span data-ttu-id="c5b9d-142">タイル通知を使って、タイルにリッチ コンテンツを表示する方法については、「[ローカル タイル通知の送信](tiles-and-notifications-sending-a-local-tile-notification.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c5b9d-142">To learn how to display rich content on your tile via tile notifications, please see [Send a local tile notification](tiles-and-notifications-sending-a-local-tile-notification.md).</span></span>


## <a name="related"></a><span data-ttu-id="c5b9d-143">関連</span><span class="sxs-lookup"><span data-stu-id="c5b9d-143">Related</span></span>

* [<span data-ttu-id="c5b9d-144">セカンダリ タイルの概要</span><span class="sxs-lookup"><span data-stu-id="c5b9d-144">Secondary tiles overview</span></span>](tiles-and-notifications-secondary-tiles.md)
* [<span data-ttu-id="c5b9d-145">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="c5b9d-145">Secondary tiles guidance</span></span>](tiles-and-notifications-secondary-tiles-guidance.md)
* [<span data-ttu-id="c5b9d-146">タイル アセット</span><span class="sxs-lookup"><span data-stu-id="c5b9d-146">Tile assets</span></span>](tiles-and-notifications-app-assets.md)
* [<span data-ttu-id="c5b9d-147">タイル コンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="c5b9d-147">Tile content documentation</span></span>](tiles-and-notifications-create-adaptive-tiles.md)
* [<span data-ttu-id="c5b9d-148">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="c5b9d-148">Send a local tile notification</span></span>](tiles-and-notifications-sending-a-local-tile-notification.md)