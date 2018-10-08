---
author: andrewleader
Description: Notifications Visualizer is a new Universal Windows Platform (UWP) app in the Store that helps developers design adaptive live tiles for Windows 10.
title: Notifications Visualizer
ms.assetid: FCBB7BB1-2C79-484B-8FFC-26FE1934EC1C
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: af8b2489346e1ef81c5cae304802814b79b8b950
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4415870"
---
# <a name="notifications-visualizer"></a><span data-ttu-id="d7f20-103">Notifications Visualizer</span><span class="sxs-lookup"><span data-stu-id="d7f20-103">Notifications Visualizer</span></span>

 


<span data-ttu-id="d7f20-104">Notifications Visualizer は、[Microsoft Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1) の新しいユニバーサル Windows プラットフォーム (UWP) アプリで、Windows 10 のアダプティブ ライブ タイルと対話型トースト通知のデザインに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-104">Notifications Visualizer is a new Universal Windows Platform (UWP) app [in the Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1) that helps developers design adaptive Live Tiles and interactive toast notifications for Windows 10.</span></span>


## <a name="overview"></a><span data-ttu-id="d7f20-105">概要</span><span class="sxs-lookup"><span data-stu-id="d7f20-105">Overview</span></span>

<span data-ttu-id="d7f20-106">Notifications Visualizer では、Visual Studio の XAML エディター/デザイン ビューと同様、XML ペイロードを編集すると、タイルとトースト通知の視覚的なプレビューが即座に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-106">Notifications Visualizer provides instant visual previews of your tile and toast notification as you edit the XML payload, similar to Visual Studio's XAML editor/design view.</span></span> <span data-ttu-id="d7f20-107">このアプリではエラーのチェックも行われます。これにより、有効なタイルまたはトースト通知のペイロードを作成できます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-107">The app also checks for errors, which ensures that you create a valid tile or toast notification payload.</span></span>

<span data-ttu-id="d7f20-108">次のアプリのスクリーンショットは、XML ペイロードと、選択したデバイス上で各サイズのタイルがどのように表示されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="d7f20-108">This screenshot from the app shows the XML payload and how tile sizes appear on a selected device:</span></span>

![コードとタイルが示されている Notifications Visualizer アプリのエディター](images/notif-visualizer-001.png)

 

<span data-ttu-id="d7f20-110">Notifications Visualizer を使うと、アプリ自体を編集、展開しなくても、アダプティブ タイルとトーストのペイロードを作成してテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-110">With Notifications Visualizer, you can create and test adaptive tile and toast payloads without having to edit and deploy your own app.</span></span> <span data-ttu-id="d7f20-111">適切な表示のペイロードが完成したら、そのペイロードをアプリに統合できます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-111">Once you've created a payload with ideal visual results, you can integrate that into your app.</span></span> <span data-ttu-id="d7f20-112">詳しくは、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」および 「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7f20-112">See [Send a local tile notification](sending-a-local-tile-notification.md) and [Send a local toast](send-local-toast.md) to learn more.</span></span>

<span data-ttu-id="d7f20-113">**注**   Notifications Visualizer では Windows のスタート メニューとトースト通知をシミュレートできますが、完全に正確なシミュレーションが常に行われるというわけではありません。また、このシミュレーションでは、一部の高度なペイロード プロパティがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="d7f20-113">**Note**   Notifications Visualizer's simulation of the Windows Start menu and toast notifications isn't always completely accurate, and it doesn't support some advanced payload properties.</span></span> <span data-ttu-id="d7f20-114">タイルやトーストを適切にデザインしたら、意図したとおりに表示されることを確認するために、タイルをスタート メニューにピン留めしたり、トーストを表示したりしてテストします。</span><span class="sxs-lookup"><span data-stu-id="d7f20-114">When you have the tile or toast you want, test it by pinning the tile or popping the toast to verify that it appears as you intend.</span></span>

 

## <a name="features"></a><span data-ttu-id="d7f20-115">機能</span><span class="sxs-lookup"><span data-stu-id="d7f20-115">Features</span></span>

<span data-ttu-id="d7f20-116">Notifications Visualizer にはさまざまなサンプル ペイロードが付属しており、アダプティブ ライブ タイルや対話型トーストの機能を実際に確認して、作成を開始する際の参考にすることができます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-116">Notifications Visualizer comes with a number of sample payloads to showcase what's possible with adaptive Live Tiles and interactive toasts to help you get started.</span></span> <span data-ttu-id="d7f20-117">さまざまなテキスト オプション、グループ/サブグループ、背景画像を試すことができます。また、さまざまなデバイスや画面にタイルがどのように対応するかを確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-117">You can experiment with all the different text options, groups/subgroups, background images, and you can see how the tile adapts to different devices and screens.</span></span> <span data-ttu-id="d7f20-118">サンプルに変更を加えたら、今後利用するために、更新したペイロードをファイルに保存できます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-118">Once you've made changes, you can save your updated payload to a file for future use.</span></span>

<span data-ttu-id="d7f20-119">エディターでは、リアルタイムにエラーと警告が示されます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-119">The editor provides real-time errors and warnings.</span></span> <span data-ttu-id="d7f20-120">たとえば、アプリのペイロードが 5 KB (プラットフォームの上限) より大きい場合、上限を超えていることを示す警告が Notifications Visualizer によって表示されます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-120">For example, if your payload is greater than 5 KB (a platform limitation), Notifications Visualizer warns you that your payload exceeds that limit.</span></span> <span data-ttu-id="d7f20-121">また誤った属性名や値に関する警告も示されるため、視覚的な問題のデバッグに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-121">It gives you warnings for incorrect attribute names or values, which helps you debug visual issues.</span></span>

<span data-ttu-id="d7f20-122">表示名、色、ロゴ、ShowName、バッジの値などのタイルのプロパティを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-122">You can control tile properties like display name, color, logos, ShowName, and badge value.</span></span> <span data-ttu-id="d7f20-123">これらのオプションを使うと、タイルのプロパティとタイル通知のペイロードがどのように影響するのか、およびこれらのオプションによって生成される結果をすぐに理解できます。</span><span class="sxs-lookup"><span data-stu-id="d7f20-123">These options help you instantly understand how your tile properties and tile notification payloads interact, and the results they produce.</span></span>

<span data-ttu-id="d7f20-124">次のアプリのスクリーンショットは、タイル エディターを示しています。</span><span class="sxs-lookup"><span data-stu-id="d7f20-124">This screenshot from the app shows the tile editor:</span></span>

![タイルが示されている Notifications Visualizer のエディター](images/notif-visualizer-004.png)

 

## <a name="related-topics"></a><span data-ttu-id="d7f20-126">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d7f20-126">Related topics</span></span>

* [<span data-ttu-id="d7f20-127">ストアでの Notifications Visualizer の入手</span><span class="sxs-lookup"><span data-stu-id="d7f20-127">Get Notifications Visualizer in the Store</span></span>](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)
* [<span data-ttu-id="d7f20-128">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="d7f20-128">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
* [<span data-ttu-id="d7f20-129">対話型トースト</span><span class="sxs-lookup"><span data-stu-id="d7f20-129">Interactive toasts</span></span>](adaptive-interactive-toasts.md)