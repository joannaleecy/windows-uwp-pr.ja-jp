---
author: mijacobs
Description: "Notifications Visualizer は、ストアの新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルをデザインする際に役立ちます。"
title: Notifications Visualizer
ms.assetid: FCBB7BB1-2C79-484B-8FFC-26FE1934EC1C
label: TBD
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 04e1a2e4c2bff8c7d7f75604e5665c3525f72174
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="notifications-visualizer"></a><span data-ttu-id="a6b86-104">Notifications Visualizer</span><span class="sxs-lookup"><span data-stu-id="a6b86-104">Notifications Visualizer</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 


<span data-ttu-id="a6b86-105">Notifications Visualizer は、[ストア](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)の新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルをデザインする際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-105">Notifications Visualizer is a new Universal Windows Platform (UWP) app in [the Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1) that helps developers design adaptive live tiles for Windows 10.</span></span>

## <a name="overview"></a><span data-ttu-id="a6b86-106">概要</span><span class="sxs-lookup"><span data-stu-id="a6b86-106">Overview</span></span>


<span data-ttu-id="a6b86-107">Notifications Visualizer アプリでは、Visual Studio の XAML エディター/デザイン ビューと同様に、タイルの編集時に視覚的なプレビューが即座に表示されます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-107">The Notifications Visualizer app provides instant visual previews of your tile as you edit, similar to Visual Studio's XAML editor/design view.</span></span> <span data-ttu-id="a6b86-108">このアプリではエラーのチェックも行われます。これにより、有効なタイルのペイロードを作成できます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-108">The app also checks for errors, which ensures that you create a valid tile payload.</span></span>

<span data-ttu-id="a6b86-109">次のアプリのスクリーンショットは、XML ペイロードと、各サイズのタイルが選んだデバイス上でどのように表示されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="a6b86-109">This screenshot from the app shows the XML payload and how tile sizes appear on a selected device:</span></span>

![コードとタイルが示されている Notifications Visualizer アプリのエディター](images/notif-visualizer-001.png)

 

<span data-ttu-id="a6b86-111">Notifications Visualizer を使うと、アプリ自体の編集や展開を行わなくても、アダプティブ タイルのペイロードを作成しテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-111">With Notifications Visualizer, you can create and test adaptive tile payloads without having to edit and deploy the app itself.</span></span> <span data-ttu-id="a6b86-112">目的に合った視覚効果を得ることができるようにペイロードを作成したら、そのペイロードをアプリに統合できます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-112">Once you've created a payload with ideal visual results you can integrate that into your app.</span></span> <span data-ttu-id="a6b86-113">詳しくは、「[ローカル タイル通知の送信](tiles-and-notifications-sending-a-local-tile-notification.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a6b86-113">See [Send a local tile notification](tiles-and-notifications-sending-a-local-tile-notification.md) to learn more.</span></span>

<span data-ttu-id="a6b86-114">**注**   Notifications Visualizer では Windows のスタート メニューをシミュレートできますが、完全に正確なシミュレーションが常に行われるというわけではありません。また、このシミュレーションでは、[baseUri](https://msdn.microsoft.com/library/windows/apps/br208712) などの一部のプロパティがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a6b86-114">**Note**   Notifications Visualizer's simulation of the Windows Start menu isn't always completely accurate, and it doesn't support some payload properties like [baseUri](https://msdn.microsoft.com/library/windows/apps/br208712).</span></span> <span data-ttu-id="a6b86-115">タイルを目的に合うようにデザインしたら、意図したとおりに表示されることを確認するために、タイルを実際の [スタート] メニューにピン留めしてテストします。</span><span class="sxs-lookup"><span data-stu-id="a6b86-115">When you have the tile design you want, test it by pinning the tile to the actual Start menu to verify that it appears as you intend.</span></span>

 

## <a name="features"></a><span data-ttu-id="a6b86-116">機能</span><span class="sxs-lookup"><span data-stu-id="a6b86-116">Features</span></span>


<span data-ttu-id="a6b86-117">Notifications Visualizer にはさまざまなサンプル ペイロードが付属しており、アダプティブ ライブ タイルを使ってできることを確認できます。これらのサンプル ペイロードは作業を始める際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-117">Notifications Visualizer comes with a number of sample payloads to showcase what's possible with adaptive live tiles and to help you get started.</span></span> <span data-ttu-id="a6b86-118">さまざまなテキスト オプション、グループ/サブグループ、背景画像を試すことができます。また、さまざまなデバイスや画面にタイルがどのように対応するかを確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-118">You can experiment with all the different text options, groups/subgroups, background images, and you can see how the tile adapts to different devices and screens.</span></span> <span data-ttu-id="a6b86-119">サンプルに変更を加えたら、今後利用するために、更新したペイロードをファイルに保存できます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-119">Once you've made changes, you can save your updated payload to a file for future use.</span></span>

<span data-ttu-id="a6b86-120">エディターでは、リアルタイムにエラーと警告が示されます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-120">The editor provides real-time errors and warnings.</span></span> <span data-ttu-id="a6b86-121">たとえば、アプリのペイロードが 5 KB (プラットフォームの上限) 未満に制限されている場合、ペイロードがこの制限を超えると、Notifications Visualizer から警告が示されます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-121">For example, if your app payload is limited to less than 5 KB (a platform limitation), Notifications Visualizer warns you if your payload exceeds that limit.</span></span> <span data-ttu-id="a6b86-122">Notifications Visualizer では誤った属性名や値に関する警告も示され、視覚的な問題をデバッグする際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-122">It gives you warnings for incorrect attribute names or values, which helps you debug visual issues.</span></span>

<span data-ttu-id="a6b86-123">表示名、色、ロゴ、ShowName、バッジの値などのタイルのプロパティを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-123">You can control tile properties like display name, color, logos, ShowName, badge value.</span></span> <span data-ttu-id="a6b86-124">これらのオプションを使うと、タイルのプロパティとタイル通知のペイロードがどのように影響するのか、およびこれらのオプションによって生成される結果をすぐに理解できます。</span><span class="sxs-lookup"><span data-stu-id="a6b86-124">These options help you instantly understand how your tile properties and tile notification payloads interact, and the results they produce.</span></span>

<span data-ttu-id="a6b86-125">次のアプリのスクリーンショットは、タイル エディターを示しています。</span><span class="sxs-lookup"><span data-stu-id="a6b86-125">This screenshot from the app shows the tile editor:</span></span>

![タイルが示されている Notifications Visualizer のエディター](images/notif-visualizer-004.png)

 

## <a name="related-topics"></a><span data-ttu-id="a6b86-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a6b86-127">Related topics</span></span>


* [<span data-ttu-id="a6b86-128">ストアでの Notifications Visualizer の入手</span><span class="sxs-lookup"><span data-stu-id="a6b86-128">Get Notifications Visualizer in the Store</span></span>](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)
* [<span data-ttu-id="a6b86-129">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="a6b86-129">Create adaptive tiles</span></span>](tiles-and-notifications-create-adaptive-tiles.md)
* [<span data-ttu-id="a6b86-130">アダプティブ タイル テンプレート: スキーマとドキュメント</span><span class="sxs-lookup"><span data-stu-id="a6b86-130">Adaptive tile templates: schema and documentation</span></span>](tiles-and-notifications-adaptive-tiles-schema.md)
* [<span data-ttu-id="a6b86-131">Tiles and toasts (タイルとトースト) (MSDN ブログ)</span><span class="sxs-lookup"><span data-stu-id="a6b86-131">Tiles and toasts (MSDN blog)</span></span>](http://blogs.msdn.com/b/tiles_and_toasts/)