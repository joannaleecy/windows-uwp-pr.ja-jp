---
Description: UWP アプリから開始するセカンダリ タイルをピン留めする方法について説明します。
title: 開始するセカンダリ タイルをピン留め
label: Pin secondary tiles to Start
template: detail.hbs
ms.date: 05/25/2017
ms.topic: article
keywords: Windows 10、UWP、セカンダリ タイル、ピン留め、クイック スタート、コード サンプル、例
ms.localizationpriority: medium
ms.openlocfilehash: 4bebee86c824242cf031503617d4a880ebbb74df
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653157"
---
# <a name="pin-secondary-tiles-to-start"></a><span data-ttu-id="e7e3a-104">開始するセカンダリ タイルをピン留め</span><span class="sxs-lookup"><span data-stu-id="e7e3a-104">Pin secondary tiles to Start</span></span>


<span data-ttu-id="e7e3a-105">このトピックでは、UWP アプリのセカンダリ タイルを作り、スタート メニューにピン留めする手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-105">This topic walks you through the steps to create a secondary tile for your UWP app and pin it to the Start menu.</span></span>

![セカンダリ タイルのスクリーン ショット](images/secondarytiles.png)

<span data-ttu-id="e7e3a-107">セカンダリ タイルについて詳しくは、「[セカンダリ タイルの概要](secondary-tiles.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-107">To learn more about secondary tiles, please see the [Secondary tiles overview](secondary-tiles.md).</span></span>


## <a name="add-namespace"></a><span data-ttu-id="e7e3a-108">名前空間を追加する</span><span class="sxs-lookup"><span data-stu-id="e7e3a-108">Add namespace</span></span>

<span data-ttu-id="e7e3a-109">Windows.UI.StartScreen 名前空間には SecondaryTile クラスが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-109">The Windows.UI.StartScreen namespace includes the SecondaryTile class.</span></span>

```csharp
using Windows.UI.StartScreen;
```


## <a name="initialize-the-secondary-tile"></a><span data-ttu-id="e7e3a-110">セカンダリ タイルを初期化する</span><span class="sxs-lookup"><span data-stu-id="e7e3a-110">Initialize the secondary tile</span></span>

<span data-ttu-id="e7e3a-111">セカンダリ タイルは、いくつかの主要なコンポーネントで構成されます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-111">Secondary tiles are composed of a few key components...</span></span>

* <span data-ttu-id="e7e3a-112">**TileId**:一意の識別子、その他のセカンダリ タイル間でのタイルを識別することができます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-112">**TileId**: A unique identifier that lets you identify the tile among your other secondary tiles.</span></span>
* <span data-ttu-id="e7e3a-113">**DisplayName**:タイルを表示名前です。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-113">**DisplayName**: The name you want shown on the tile.</span></span>
* <span data-ttu-id="e7e3a-114">**引数**:指定する引数渡されたアプリに戻り、ユーザーがタイルをクリックするとします。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-114">**Arguments**: The arguments you want passed back to your app when the user clicks your tile.</span></span>
* <span data-ttu-id="e7e3a-115">**Square150x150Logo**:中程度のサイズに表示される、必要なロゴはタイル (および、小さなサイズのタイルにサイズを変更しない小さいロゴが提供されている場合)。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-115">**Square150x150Logo**: The required logo, displayed on the medium size tile (and resized to small size tile if no small logo provided).</span></span>

<span data-ttu-id="e7e3a-116">上記のすべてのプロパティに初期化された値を提供する**必要があります**。提供されない場合には、例外がスローされます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-116">You **MUST** provide initialized values for all of the above properties, or else you will get an exception.</span></span>

<span data-ttu-id="e7e3a-117">さまざまなコンストラクターを使用することができますが、tileId、displayName、引数、square150x150Logo、desiredSize でコンストラクターを使用すると、必須のプロパティをすべて設定するようにできます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-117">There are a variety of constructors you can use, but using the constructor that takes in the tileId, displayName, arguments, square150x150Logo, and desiredSize helps ensure you set all of the required properties.</span></span>

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


## <a name="optional-add-support-for-larger-tile-sizes"></a><span data-ttu-id="e7e3a-118">省略可能: 大きいタイル サイズのサポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-118">Optional: Add support for larger tile sizes</span></span>

<span data-ttu-id="e7e3a-119">セカンダリ タイルにリッチなタイル通知を表示する場合、ユーザーがタイルのサイズをワイド サイズや大サイズに変更して、より多くのコンテンツを表示できるようにすることが望まれます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-119">If you're going to be displaying rich tile notifications on your secondary tile, you'll likely want to allow the user to resize their tile to be wide or large, so that they can see even more of your content.</span></span>

<span data-ttu-id="e7e3a-120">ワイド サイズ、大サイズのタイルを有効化するには、*Wide310x150Logo* および *Square310x310Logo* を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-120">To enable wide and large tile sizes, you need to provide the *Wide310x150Logo* and *Square310x310Logo*.</span></span> <span data-ttu-id="e7e3a-121">また、可能であれば、小サイズのタイル用に *Square71x71Logo* を提供します (提供されない場合、小サイズ用に必要な Square150x150Logo は自動的にサイズ変更して作成されます)。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-121">Also, if possible, you should provide the *Square71x71Logo* for the small tile size (otherwise we will downsize your required Square150x150Logo for the small tile).</span></span>

<span data-ttu-id="e7e3a-122">さらに、独自の *Square44x44Logo* を提供すると、通知が表示されるときに右下隅にオプションとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-122">You can also provide a unique *Square44x44Logo*, which is optionally displayed on the bottom right corner when a notification is present.</span></span> <span data-ttu-id="e7e3a-123">提供されない場合には、代わりにプライマリ タイルの *Square44x44Logo* が使用されます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-123">If you don't provide one, the *Square44x44Logo* from your primary tile will be used instead.</span></span>

```csharp
// Enable wide and large tile sizes
tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/CityTiles/Wide310x150Logo.png");
tile.VisualElements.Square310x310Logo = new Uri("ms-appx:///Assets/CityTiles/Square310x310Logo.png");

// Add a small size logo for better looking small tile
tile.VisualElements.Square71x71Logo = new Uri("ms-appx:///Assets/CityTiles/Square71x71Logo.png");

// Add a unique corner logo for the secondary tile
tile.VisualElements.Square44x44Logo = new Uri("ms-appx:///Assets/CityTiles/Square44x44Logo.png");
```


## <a name="optional-enable-showing-the-display-name"></a><span data-ttu-id="e7e3a-124">省略可能: 表示名の表示を有効にします。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-124">Optional: Enable showing the display name</span></span>

<span data-ttu-id="e7e3a-125">既定では、表示名は表示されません。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-125">By default the display name will NOT be shown.</span></span> <span data-ttu-id="e7e3a-126">中サイズ、ワイド サイズ、大サイズで表示名を表示するには、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-126">To show the display name on medium/wide/large, add the following code.</span></span>

```csharp
// Show the display name on all sizes
tile.VisualElements.ShowNameOnSquare150x150Logo = true;
tile.VisualElements.ShowNameOnWide310x150Logo = true;
tile.VisualElements.ShowNameOnSquare310x310Logo = true;
```


## <a name="optional-3d-secondary-tiles"></a><span data-ttu-id="e7e3a-127">省略可能: 3D のセカンダリ タイル</span><span class="sxs-lookup"><span data-stu-id="e7e3a-127">Optional: 3D secondary tiles</span></span>
<span data-ttu-id="e7e3a-128">3D アセットを追加して、Windows Mixed Reality に対応することで、さらに高度なセカンダリ タイルを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-128">You can enhance your secondary tile for Windows Mixed Reality by adding 3D assets.</span></span> <span data-ttu-id="e7e3a-129">アプリを Mixed Reality 環境で使用すると、ユーザーは 3D タイルをスタート メニューではなく、Windows Mixed Reality ホームに直接配置できます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-129">Users can place 3D tiles directly in their Windows Mixed Reality home instead of the Start menu when using your app in a Mixed Reality environment.</span></span> <span data-ttu-id="e7e3a-130">たとえば、360° フォト ビューアー アプリに直接リンクした 360° フォトスフィアを作成したり、ユーザーが家具のカタログから椅子の 3D モデルを配置して、選択するとそのオブジェクトの価格やカラー展開に関する詳細ページが開くようにしたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-130">For example, you can create 360° photospheres that link directly into a 360° photo viewer app, or let users place a 3D model of a chair from a furniture catalog that opens a details page about the pricing and color options for that object when selected.</span></span> <span data-ttu-id="e7e3a-131">この機能を使い始めるには、[Mixed Reality の開発者向けドキュメント](https://developer.microsoft.com/windows/mixed-reality/implementing_3d_deep_links_for_your_app_in_the_windows_mixed_reality_home)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-131">To get started, refer to the [Mixed Reality developer documentation](https://developer.microsoft.com/windows/mixed-reality/implementing_3d_deep_links_for_your_app_in_the_windows_mixed_reality_home).</span></span>



## <a name="pin-the-secondary-tile"></a><span data-ttu-id="e7e3a-132">セカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="e7e3a-132">Pin the secondary tile</span></span>

<span data-ttu-id="e7e3a-133">最後に、タイルのピン留めを要求します。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-133">Finally, request to pin the tile.</span></span> <span data-ttu-id="e7e3a-134">これは UI スレッドから呼び出す必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-134">Note that this must be called from a UI thread.</span></span> <span data-ttu-id="e7e3a-135">デスクトップに、ユーザーにタイルをピン留めするかどうかの確認を求める、ダイアログが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-135">On Desktop, a dialog will appear asking the user to confirm whether they would like to pin the tile.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="e7e3a-136">デスクトップ ブリッジを使った Windows デスクトップ アプリケーションの場合は、まず「[デスクトップ アプリケーションからピン留めする](secondary-tiles-desktop-pinning.md)」に記載された追加の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-136">If you are a Windows desktop application using the Desktop Bridge, you must first perform an extra step as described in [Pin from desktop application](secondary-tiles-desktop-pinning.md)</span></span>

```csharp
// Pin the tile
bool isPinned = await tile.RequestCreateAsync();

// TODO: Update UI to reflect whether user can now either unpin or pin
```


## <a name="check-if-a-secondary-tile-exists"></a><span data-ttu-id="e7e3a-137">セカンダリ タイルが存在するかを確認する</span><span class="sxs-lookup"><span data-stu-id="e7e3a-137">Check if a secondary tile exists</span></span>

<span data-ttu-id="e7e3a-138">既にスタートにピン留めされているアプリのページでは、[ピン留めを外す] ボタンを表示するようにします。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-138">If your user visits a page in your app that they have already pinned to Start, you will want to instead display an "Unpin" button.</span></span>

<span data-ttu-id="e7e3a-139">このため、表示ボタンを選ぶときには、セカンダリ タイルが既にピン留めされているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-139">Therefore, when choosing what button to display, you need to first check whether the secondary tile is currently pinned.</span></span>

```csharp
// Check if the secondary tile is pinned
bool isPinned = SecondaryTile.Exists(tileId);

// TODO: Update UI to reflect whether user can either unpin or pin
```


## <a name="unpinning-a-secondary-tile"></a><span data-ttu-id="e7e3a-140">セカンダリ タイルのピン留めを外す</span><span class="sxs-lookup"><span data-stu-id="e7e3a-140">Unpinning a secondary tile</span></span>

<span data-ttu-id="e7e3a-141">タイルが既にピン留めされているときに、ユーザーが [ピン留めを外す] ボタンをクリックした場合には、タイルのピン留めを外す (削除する) 必要があります。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-141">If the tile is currently pinned, and the user clicks your unpin button, you'll want to unpin (delete) the tile.</span></span>

```csharp
// Initialize a secondary tile with the same tile ID you want removed
SecondaryTile toBeDeleted = new SecondaryTile(tileId);

// And then unpin the tile
await toBeDeleted.RequestDeleteAsync();
```


## <a name="updating-a-secondary-tile"></a><span data-ttu-id="e7e3a-142">セカンダリ タイルを更新する</span><span class="sxs-lookup"><span data-stu-id="e7e3a-142">Updating a secondary tile</span></span>

<span data-ttu-id="e7e3a-143">ロゴ、表示名、その他のセカンダリ タイル上の情報を更新する場合には、*RequestUpdateAsync* を使用できます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-143">If you need to update the logos, display name, or anything else on the secondary tile, you can use *RequestUpdateAsync*.</span></span>

```csharp
// Initialize a secondary tile with the same tile ID you want to update
SecondaryTile tile = new SecondaryTile(tileId);

// Assign ALL properties, including ones you aren't changing

// And then update it
await tile.UpdateAsync();
```


## <a name="enumerating-all-pinned-secondary-tiles"></a><span data-ttu-id="e7e3a-144">ピン留めされているすべてのセカンダリ タイルを列挙する</span><span class="sxs-lookup"><span data-stu-id="e7e3a-144">Enumerating all pinned secondary tiles</span></span>

<span data-ttu-id="e7e3a-145">ユーザーがピン留めしたすべてのタイルを検出する必要がある場合、*SecondaryTile.Exists* を使用する代わりに、*SecondaryTile.FindAllAsync()* を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-145">If you need to discover all the tiles your user has pinned, instead of using *SecondaryTile.Exists*, you can alternatively use *SecondaryTile.FindAllAsync()*.</span></span>

```csharp
// Get all secondary tiles
var tiles = await SecondaryTile.FindAllAsync();
```


## <a name="send-a-tile-notification"></a><span data-ttu-id="e7e3a-146">タイル通知を送信する</span><span class="sxs-lookup"><span data-stu-id="e7e3a-146">Send a tile notification</span></span>

<span data-ttu-id="e7e3a-147">タイル通知を使って、タイルにリッチ コンテンツを表示する方法については、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e7e3a-147">To learn how to display rich content on your tile via tile notifications, please see [Send a local tile notification](sending-a-local-tile-notification.md).</span></span>


## <a name="related"></a><span data-ttu-id="e7e3a-148">関連</span><span class="sxs-lookup"><span data-stu-id="e7e3a-148">Related</span></span>

* [<span data-ttu-id="e7e3a-149">セカンダリ タイルの概要</span><span class="sxs-lookup"><span data-stu-id="e7e3a-149">Secondary tiles overview</span></span>](secondary-tiles.md)
* [<span data-ttu-id="e7e3a-150">セカンダリ タイルのガイダンス</span><span class="sxs-lookup"><span data-stu-id="e7e3a-150">Secondary tiles guidance</span></span>](secondary-tiles-guidance.md)
* [<span data-ttu-id="e7e3a-151">タイルの資産</span><span class="sxs-lookup"><span data-stu-id="e7e3a-151">Tile assets</span></span>](app-assets.md)
* [<span data-ttu-id="e7e3a-152">タイルのコンテンツのドキュメント</span><span class="sxs-lookup"><span data-stu-id="e7e3a-152">Tile content documentation</span></span>](create-adaptive-tiles.md)
* [<span data-ttu-id="e7e3a-153">ローカル タイル通知の送信</span><span class="sxs-lookup"><span data-stu-id="e7e3a-153">Send a local tile notification</span></span>](sending-a-local-tile-notification.md)
