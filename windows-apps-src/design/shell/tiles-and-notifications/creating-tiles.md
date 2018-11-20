---
author: mijacobs
Description: A tile is an app's representation on the Start menu. Every app has a tile. When you create a new Universal Windows Platform (UWP) app project in Microsoft Visual Studio, it includes a default tile that displays your app's name and logo.
title: タイル
ms.assetid: 09C7E1B1-F78D-4659-8086-2E428E797653
label: Tiles
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f4388b67335bce497987ab22e3b281cf86e029af
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7307562"
---
# <a name="tiles-for-uwp-apps"></a><span data-ttu-id="8363d-103">UWP アプリのタイル</span><span class="sxs-lookup"><span data-stu-id="8363d-103">Tiles for UWP apps</span></span>

 

<span data-ttu-id="8363d-104">*タイル*とは、[スタート] メニュー上でアプリを表すものです。</span><span class="sxs-lookup"><span data-stu-id="8363d-104">A *tile* is an app's representation on the Start menu.</span></span> <span data-ttu-id="8363d-105">すべてのアプリにはタイルがあります。</span><span class="sxs-lookup"><span data-stu-id="8363d-105">Every app has a tile.</span></span> <span data-ttu-id="8363d-106">Microsoft Visual Studio で作成した新しいユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトには、アプリの名前とロゴを表示する既定のタイルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="8363d-106">When you create a new Universal Windows Platform (UWP) app project in Microsoft Visual Studio, it includes a default tile that displays your app's name and logo.</span></span><span data-ttu-id="8363d-107">このタイルは、アプリを初めてインストールしたときに Windows に表示されます。</span><span class="sxs-lookup"><span data-stu-id="8363d-107">Windows displays this tile when your app is first installed.</span></span> <span data-ttu-id="8363d-108">アプリをインストールしたら、新しい情報 (ニュース ヘッドライン、最新の未読メッセージの件名など) をユーザーに伝えるようにタイルを変更するなど、通知を通じてタイルの内容を変更できます。</span><span class="sxs-lookup"><span data-stu-id="8363d-108">After your app is installed, you can change your tile's content through notifications; for example, you can change the tile to communicate new information to the user, such as news headlines, or the subject of the most recent unread message.</span></span>

## <a name="configure-the-default-tile"></a><span data-ttu-id="8363d-109">既定のタイルを構成する</span><span class="sxs-lookup"><span data-stu-id="8363d-109">Configure the default tile</span></span>


<span data-ttu-id="8363d-110">Visual Studio で新しいプロジェクトを作成すると、アプリの名前とロゴを表示する単純な既定のタイルが作成されます。</span><span class="sxs-lookup"><span data-stu-id="8363d-110">When you create a new project in Visual Studio, it creates a simple default tile that displays your app's name and logo.</span></span>

<span data-ttu-id="8363d-111">タイルを編集するには、メインの UWP プロジェクトの **Package.appxmanifest** ファイルをダブル クリックし、デザイナーを開きます (またはファイルを右クリックして、[コードの表示] を選びます)。</span><span class="sxs-lookup"><span data-stu-id="8363d-111">To edit your tile, double click the **Package.appxmanifest** file in your main UWP project to open the designer (or right click the file and select View Code).</span></span>

```XML
  <Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="ExampleApp.App">
      <uap:VisualElements
        DisplayName="ExampleApp"
        Square150x150Logo="Assets\Square150x150Logo.png"
        Square44x44Logo="Assets\Square44x44Logo.png"
        Description="ExampleApp"
        BackgroundColor="#464646">
        <uap:SplashScreen Image="Assets\SplashScreen.png" />
      </uap:VisualElements>
    </Application>
  </Applications>
```

<span data-ttu-id="8363d-112">いくつか更新する必要がある項目があります。</span><span class="sxs-lookup"><span data-stu-id="8363d-112">There are a few items you should update:</span></span>

-   <span data-ttu-id="8363d-113">DisplayName: この値はタイルに表示する名前に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8363d-113">DisplayName: Replace this value with the name you want to display on your tile.</span></span>
-   <span data-ttu-id="8363d-114">ShortName: タイル上の表示名を収めるスペースには限りがあるため、アプリの名前が切り詰められないような名前を指定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8363d-114">ShortName: Because there is limited room for your display name to fit on tiles, we recommend that you to specify a ShortName as well, to make sure your app's name doesn’t get truncated.</span></span>
-   <span data-ttu-id="8363d-115">ロゴ イメージ:</span><span class="sxs-lookup"><span data-stu-id="8363d-115">Logo images:</span></span>

    <span data-ttu-id="8363d-116">ここに挙げた画像を、自分で用意したものに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="8363d-116">You should replace these images with your own.</span></span> <span data-ttu-id="8363d-117">さまざまな倍率に応じて複数の画像を指定することができますが、必ずしもすべて指定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8363d-117">You have the option of supplying images for different visual scales, but you are not required to supply them all.</span></span> <span data-ttu-id="8363d-118">多種多様なデバイスでアプリを適切に表示するために、各画像の複数のスケール バージョン (100%、200%、400%) を用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8363d-118">To ensure that you app looks good on a range of devices, we recommend that you provide 100%, 200%, and 400% scale versions of each image.</span></span> <span data-ttu-id="8363d-119">これらのアセットの生成について詳しくは、「[タイルとアイコン アセット](app-assets.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8363d-119">See [Tile and icon assets](app-assets.md) to learn more about generating these assets.</span></span>

    <span data-ttu-id="8363d-120">拡大/縮小された画像の名前付け規則は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8363d-120">Scaled images follow this naming convention:</span></span>
    
    <span data-ttu-id="8363d-121">*&lt;画像名&gt;*.scale-*&lt;倍率&gt;*.*&lt;画像ファイルの拡張子&gt;*</span><span class="sxs-lookup"><span data-stu-id="8363d-121">*&lt;image name&gt;*.scale-*&lt;scale factor&gt;*.*&lt;image file extension&gt;*</span></span> 

    <span data-ttu-id="8363d-122">例: SplashScreen.scale-100.png</span><span class="sxs-lookup"><span data-stu-id="8363d-122">For example: SplashScreen.scale-100.png</span></span>

    <span data-ttu-id="8363d-123">画像を参照するときには、*&lt;画像名&gt;*.*&lt;画像ファイルの拡張子&gt;* という形式で参照します (この例では "SplashScreen.png")。</span><span class="sxs-lookup"><span data-stu-id="8363d-123">When you refer to the image, you refer to it as *&lt;image name&gt;*.*&lt;image file extension&gt;* ("SplashScreen.png" in this example).</span></span> <span data-ttu-id="8363d-124">指定した画像からデバイスに合わせて拡大/縮小された画像が自動的に選択されます。</span><span class="sxs-lookup"><span data-stu-id="8363d-124">The system will automatically select the appropriate scaled image for the device from the images you've provided.</span></span>

-   <span data-ttu-id="8363d-125">強制ではありませんが、幅広で大きいタイル サイズに合ったロゴを用意して、ユーザーの側でアプリのタイルをそのサイズに変更できるようにすることを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8363d-125">You don't have to, but we highly recommend supplying logos for wide and large tile sizes so that the user can resize your app's tile to those sizes.</span></span> <span data-ttu-id="8363d-126">追加の画像を指定するには、**DefaultTile** 要素を作成し、**Wide310x150Logo** および **Square310x310Logo** 属性を使って、その画像を指定します。</span><span class="sxs-lookup"><span data-stu-id="8363d-126">To provide these additional images, you create a **DefaultTile** element and use the **Wide310x150Logo** and **Square310x310Logo** attributes to specify the additional images:</span></span>
```    XML
  <Applications>
        <Application Id="App"
          Executable="$targetnametoken$.exe"
          EntryPoint="ExampleApp.App">
          <uap:VisualElements
            DisplayName="ExampleApp"
            Square150x150Logo="Assets\Square150x150Logo.png"
            Square44x44Logo="Assets\Square44x44Logo.png"
            Description="ExampleApp"
            BackgroundColor="#464646">
            <uap:DefaultTile
              Wide310x150Logo="Assets\Wide310x150Logo.png"
              Square310x310Logo="Assets\Square310x310Logo.png">
            </uap:DefaultTile>
            <uap:SplashScreen Image="Assets\SplashScreen.png" />
          </uap:VisualElements>
        </Application>
      </Applications>
```

## <a name="use-notifications-to-customize-your-tile"></a><span data-ttu-id="8363d-127">通知を使ってタイルをカスタマイズする</span><span class="sxs-lookup"><span data-stu-id="8363d-127">Use notifications to customize your tile</span></span>


<span data-ttu-id="8363d-128">アプリをインストールした後は、通知を使ってタイルをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="8363d-128">After your app is installed, you can use notifications to customize your tile.</span></span> <span data-ttu-id="8363d-129">これは、アプリを初めてを起動したときや、プッシュ通知など、イベントへの応答として実行できます。</span><span class="sxs-lookup"><span data-stu-id="8363d-129">You can do this the first time your app launches or in response to an event, such as a push notification.</span></span>

<span data-ttu-id="8363d-130">タイル通知を送信する方法については、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8363d-130">To learn how to send tile notifications, see [Send a local tile notification](sending-a-local-tile-notification.md).</span></span>
