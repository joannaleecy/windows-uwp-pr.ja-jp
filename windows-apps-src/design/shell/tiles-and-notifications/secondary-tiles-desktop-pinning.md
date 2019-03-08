---
Description: Windows デスクトップ アプリケーションでは、デスクトップ ブリッジを利用して、セカンダリ タイルをピン留めできます。
title: デスクトップ アプリケーションからセカンダリ タイルをピン留めする
label: Pin secondary tiles from desktop application
template: detail.hbs
ms.date: 05/25/2017
ms.topic: article
keywords: Windows 10、デスクトップ ブリッジ、セカンダリ タイル、ピン留め、クイックスタート、コード サンプル、例、デスクトップ アプリケーション、Win32、WinForms、WPF
ms.localizationpriority: medium
ms.openlocfilehash: 1e713f37cd5e5fbf4b2771e76fb7e132b5976629
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57609627"
---
# <a name="pin-secondary-tiles-from-desktop-application"></a><span data-ttu-id="d43f5-104">デスクトップ アプリケーションからセカンダリ タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="d43f5-104">Pin secondary tiles from desktop application</span></span>


<span data-ttu-id="d43f5-105">[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使うと、Windows デスクトップ アプリケーション (Win32、Windows フォーム、WPF など) でセカンダリ タイルをピン留めできます。</span><span class="sxs-lookup"><span data-stu-id="d43f5-105">Thanks to the [Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop), Windows desktop applications (like Win32, Windows Forms, and WPF) can pin secondary tiles!</span></span>

![セカンダリ タイルのスクリーン ショット](images/secondarytiles.png)

> [!IMPORTANT]
> <span data-ttu-id="d43f5-107">**Fall Creators Update が必要です**:。SDK 16299 を対象にして、ビルド 16299 または後にセカンダリ タイルをピン留めを搭載しているデスクトップ ブリッジ アプリから。</span><span class="sxs-lookup"><span data-stu-id="d43f5-107">**Requires Fall Creators Update**: You must target SDK 16299 and be running build 16299 or later to pin secondary tiles from Desktop Bridge apps.</span></span>

<span data-ttu-id="d43f5-108">WPF または WinForms アプリケーションからのセカンダリ タイルの追加は、純粋な UWP アプリとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="d43f5-108">Adding a secondary tile from your WPF or WinForms application is very similar to a pure UWP app.</span></span> <span data-ttu-id="d43f5-109">唯一の違いは、メイン ウィンドウのハンドル (HWND) を指定する必要があることです。</span><span class="sxs-lookup"><span data-stu-id="d43f5-109">The only difference is that you must specify your main window handle (HWND).</span></span> <span data-ttu-id="d43f5-110">これは、タイルをピン留めするときに、モーダル ダイアログが表示され、タイルをピン留めするかどうかをユーザーに確認するためです。</span><span class="sxs-lookup"><span data-stu-id="d43f5-110">This is because when pinning a tile, Windows displays a modal dialog asking the user to confirm whether they would like to pin the tile.</span></span> <span data-ttu-id="d43f5-111">デスクトップ アプリケーションが、SecondaryTile オブジェクトのオーナー ウィンドウを構成しない場合、ダイアログ ボックスを描画する位置を認識することができず、操作は失敗します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-111">If the desktop application doesn't configure the SecondaryTile object with the owner window, Windows doesn't know where to draw the dialog and the operation will fail.</span></span>


## <a name="package-your-app-with-desktop-bridge"></a><span data-ttu-id="d43f5-112">デスクトップ ブリッジを使ったアプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="d43f5-112">Package your app with Desktop Bridge</span></span>

<span data-ttu-id="d43f5-113">デスクトップ ブリッジを使ってアプリをパッケージ化していない場合、UWP API を使用する前に、[デスクトップ ブリッジを使ってアプリをパッケージ化する](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root)必要があります。</span><span class="sxs-lookup"><span data-stu-id="d43f5-113">If you have not packaged your app with the Desktop Bridge, [you must do so first](https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-root) before you can use any UWP APIs.</span></span>


## <a name="enable-access-to-iinitializewithwindow-interface"></a><span data-ttu-id="d43f5-114">IInitializeWithWindow インターフェイスへのアクセスを有効にする</span><span class="sxs-lookup"><span data-stu-id="d43f5-114">Enable access to IInitializeWithWindow interface</span></span>

<span data-ttu-id="d43f5-115">アプリケーションが C# や Visual Basic などのマネージ言語で記述されている場合、次の C# の例に示すように、アプリのコードで [ComImport](https://msdn.microsoft.com/library/system.runtime.interopservices.comimportattribute.aspx) と GUID 属性を使用して IInitializeWithWindow インターフェイスを宣言します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-115">If your application is written in a managed language such as C# or Visual Basic, declare the IInitializeWithWindow interface in your app's code with the [ComImport](https://msdn.microsoft.com/library/system.runtime.interopservices.comimportattribute.aspx) and Guid attribute as shown in the following C# example.</span></span> <span data-ttu-id="d43f5-116">この例では、コード ファイルに System.Runtime.InteropServices 名前空間の using ステートメントが指定されていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="d43f5-116">This example assumes that your code file has a using statement for the System.Runtime.InteropServices namespace.</span></span>

```csharp
[ComImport]
[Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IInitializeWithWindow
{
    void Initialize(IntPtr hwnd);
}
```

<span data-ttu-id="d43f5-117">または、C++ で記述されている場合、コードに **shobjidl.h** ヘッダー ファイルへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-117">Alternatively, if you are using C++, add a reference to the **shobjidl.h** header file in your code.</span></span> <span data-ttu-id="d43f5-118">このヘッダー ファイルには、*IInitializeWithWindow* インターフェイスの宣言が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d43f5-118">This header file contains the declaration of the *IInitializeWithWindow* interface.</span></span>


## <a name="initialize-the-secondary-tile"></a><span data-ttu-id="d43f5-119">セカンダリ タイルを初期化する</span><span class="sxs-lookup"><span data-stu-id="d43f5-119">Initialize the secondary tile</span></span>

<span data-ttu-id="d43f5-120">通常の UWP アプリの場合とまったく同じように、新しいセカンダリ タイル オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-120">Initialize a new secondary tile object exactly like you would with a normal UWP app.</span></span> <span data-ttu-id="d43f5-121">セカンダリ タイルの作成とピン留めについて詳しくは、「[セカンダリ タイルをピン留めする](secondary-tiles-pinning.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d43f5-121">To learn more about creating and pinning secondary tiles, see [Pin secondary tiles](secondary-tiles-pinning.md).</span></span>

```csharp
// Initialize the tile with required arguments
SecondaryTile tile = new SecondaryTile(
    "myTileId5391",
    "Display name",
    "myActivationArgs",
    new Uri("ms-appx:///Assets/Square150x150Logo.png"),
    TileSize.Default);
```


## <a name="assign-the-window-handle"></a><span data-ttu-id="d43f5-122">ウィンドウ ハンドルを割り当てる</span><span class="sxs-lookup"><span data-stu-id="d43f5-122">Assign the window handle</span></span>

<span data-ttu-id="d43f5-123">これは、デスクトップ アプリケーションにとって重要な手順です。</span><span class="sxs-lookup"><span data-stu-id="d43f5-123">This is the key step for desktop applications.</span></span> <span data-ttu-id="d43f5-124">オブジェクトを [IInitializeWithWindow](https://msdn.microsoft.com/library/windows/desktop/hh706981.aspx) オブジェクトにキャストします。</span><span class="sxs-lookup"><span data-stu-id="d43f5-124">Cast the object to an [IInitializeWithWindow](https://msdn.microsoft.com/library/windows/desktop/hh706981.aspx) object.</span></span> <span data-ttu-id="d43f5-125">次に [IInitializeWithWindow.Initialize](https://msdn.microsoft.com/library/windows/desktop/hh706982.aspx) メソッドを呼び出し、モーダル ダイアログのオーナーにするウィンドウのハンドルを渡します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-125">Then, call the [IInitializeWithWindow.Initialize](https://msdn.microsoft.com/library/windows/desktop/hh706982.aspx) method, and pass the handle of the window that you want to be the owner for the modal dialog.</span></span> <span data-ttu-id="d43f5-126">次の C# の例は、アプリのメイン ウィンドウのハンドルをメソッドに渡す方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d43f5-126">The following C# example shows how to pass the handle of your app’s main window to the method.</span></span>

```csharp
// Assign the window handle
IInitializeWithWindow initWindow = (IInitializeWithWindow)(object)tile;
initWindow.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
```


## <a name="pin-the-tile"></a><span data-ttu-id="d43f5-127">タイルをピン留めする</span><span class="sxs-lookup"><span data-stu-id="d43f5-127">Pin the tile</span></span>

<span data-ttu-id="d43f5-128">最後に、通常の UWP アプリと同様、タイルのピン留めを要求します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-128">Finally, request to pin the tile as you would a normal UWP app.</span></span>

```csharp
// Pin the tile
bool isPinned = await tile.RequestCreateAsync();

// TODO: Update UI to reflect whether user can now either unpin or pin
```


## <a name="send-tile-notifications"></a><span data-ttu-id="d43f5-129">タイル通知を送信する</span><span class="sxs-lookup"><span data-stu-id="d43f5-129">Send tile notifications</span></span>

> [!IMPORTANT]
> <span data-ttu-id="d43f5-130">**2018 年 4 月 17134.81 またはそれ以降のバージョンを必要と**:17134.81 以降セカンダリ タイルにデスクトップ ブリッジ アプリからタイルやバッジ通知を送信する現在のビルドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d43f5-130">**Requires April 2018 version 17134.81 or later**: You must be running build 17134.81 or later to send tile or badge notifications to secondary tiles from Desktop Bridge apps.</span></span> <span data-ttu-id="d43f5-131">この.81 サービス更新プログラムの前に、デスクトップ ブリッジ アプリからセカンダリ タイルにタイル通知またはバッジ通知を送信するときに a 0x80070490 *要素が見つかりません*という例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="d43f5-131">Before this .81 servicing update, a 0x80070490 *Element not found* exception would occur when sending tile or badge notifications to secondary tiles from Desktop Bridge apps.</span></span>

<span data-ttu-id="d43f5-132">タイル通知またはバッジ通知の送信は UWP アプリと同じです。</span><span class="sxs-lookup"><span data-stu-id="d43f5-132">Sending tile or badge notifications is the same as UWP apps.</span></span> <span data-ttu-id="d43f5-133">手順については、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d43f5-133">See [Send a local tile notification](sending-a-local-tile-notification.md) to get started.</span></span>


## <a name="resources"></a><span data-ttu-id="d43f5-134">参考資料</span><span class="sxs-lookup"><span data-stu-id="d43f5-134">Resources</span></span>

* [<span data-ttu-id="d43f5-135">完全なコード サンプル</span><span class="sxs-lookup"><span data-stu-id="d43f5-135">Full code sample</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/SecondaryTileSample)
* [<span data-ttu-id="d43f5-136">セカンダリ タイルの概要</span><span class="sxs-lookup"><span data-stu-id="d43f5-136">Secondary tiles overview</span></span>](secondary-tiles.md)
* [<span data-ttu-id="d43f5-137">セカンダリ タイルをピン留めする (UWP)</span><span class="sxs-lookup"><span data-stu-id="d43f5-137">Pin secondary tiles (UWP)</span></span>](secondary-tiles-pinning.md)
* [<span data-ttu-id="d43f5-138">Desktop Bridge</span><span class="sxs-lookup"><span data-stu-id="d43f5-138">Desktop Bridge</span></span>](https://developer.microsoft.com/windows/bridges/desktop)
* [<span data-ttu-id="d43f5-139">デスクトップ ブリッジ コード サンプル</span><span class="sxs-lookup"><span data-stu-id="d43f5-139">Desktop Bridge code samples</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)