---
Description: Windows 10 のライブ タイルをビジュアライザーは、新しいユニバーサル Windows プラットフォーム (UWP) アプリにより、開発者はアダプティブ デザインをストアに通知します。
title: Notifications Visualizer
ms.assetid: FCBB7BB1-2C79-484B-8FFC-26FE1934EC1C
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e2bb5a450aebdf38f3d4f1a710f3537544dcddd6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616677"
---
# <a name="notifications-visualizer"></a><span data-ttu-id="c3b40-104">Notifications Visualizer</span><span class="sxs-lookup"><span data-stu-id="c3b40-104">Notifications Visualizer</span></span>

 


<span data-ttu-id="c3b40-105">通知のビジュアライザーは、新しいユニバーサル Windows プラットフォーム (UWP) アプリ[ストア](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)開発者の適応型ライブ タイルと Windows 10 用の対話型トースト通知を設計するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-105">Notifications Visualizer is a new Universal Windows Platform (UWP) app [in the Store](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1) that helps developers design adaptive Live Tiles and interactive toast notifications for Windows 10.</span></span>


## <a name="overview"></a><span data-ttu-id="c3b40-106">概要</span><span class="sxs-lookup"><span data-stu-id="c3b40-106">Overview</span></span>

<span data-ttu-id="c3b40-107">Notifications Visualizer では、Visual Studio の XAML エディター/デザイン ビューと同様、XML ペイロードを編集すると、タイルとトースト通知の視覚的なプレビューが即座に表示されます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-107">Notifications Visualizer provides instant visual previews of your tile and toast notification as you edit the XML payload, similar to Visual Studio's XAML editor/design view.</span></span> <span data-ttu-id="c3b40-108">このアプリではエラーのチェックも行われます。これにより、有効なタイルまたはトースト通知のペイロードを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-108">The app also checks for errors, which ensures that you create a valid tile or toast notification payload.</span></span>

<span data-ttu-id="c3b40-109">次のアプリのスクリーンショットは、XML ペイロードと、各サイズのタイルが選んだデバイス上でどのように表示されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="c3b40-109">This screenshot from the app shows the XML payload and how tile sizes appear on a selected device:</span></span>

![コードとタイルが示されている Notifications Visualizer アプリのエディター](images/notif-visualizer-001.png)

 

<span data-ttu-id="c3b40-111">Notifications Visualizer を使うと、アプリ自体を編集、展開しなくても、アダプティブ タイルとトーストのペイロードを作成してテストすることができます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-111">With Notifications Visualizer, you can create and test adaptive tile and toast payloads without having to edit and deploy your own app.</span></span> <span data-ttu-id="c3b40-112">適切な表示のペイロードが完成したら、そのペイロードをアプリに統合できます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-112">Once you've created a payload with ideal visual results, you can integrate that into your app.</span></span> <span data-ttu-id="c3b40-113">詳しくは、「[ローカル タイル通知の送信](sending-a-local-tile-notification.md)」および 「[ローカル トースト通知の送信](send-local-toast.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c3b40-113">See [Send a local tile notification](sending-a-local-tile-notification.md) and [Send a local toast](send-local-toast.md) to learn more.</span></span>

<span data-ttu-id="c3b40-114">**注**   Windows スタート メニューおよびトースト通知の通知のビジュアライザーのシミュレーションが完全に正確でない、常に、いくつかの高度なペイロード プロパティをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="c3b40-114">**Note**   Notifications Visualizer's simulation of the Windows Start menu and toast notifications isn't always completely accurate, and it doesn't support some advanced payload properties.</span></span> <span data-ttu-id="c3b40-115">タイルやトーストを適切にデザインしたら、意図したとおりに表示されることを確認するために、タイルをスタート メニューにピン留めしたり、トーストを表示したりしてテストします。</span><span class="sxs-lookup"><span data-stu-id="c3b40-115">When you have the tile or toast you want, test it by pinning the tile or popping the toast to verify that it appears as you intend.</span></span>

 

## <a name="features"></a><span data-ttu-id="c3b40-116">機能</span><span class="sxs-lookup"><span data-stu-id="c3b40-116">Features</span></span>

<span data-ttu-id="c3b40-117">Notifications Visualizer にはさまざまなサンプル ペイロードが付属しており、アダプティブ ライブ タイルや対話型トーストの機能を実際に確認して、作成を開始する際の参考にすることができます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-117">Notifications Visualizer comes with a number of sample payloads to showcase what's possible with adaptive Live Tiles and interactive toasts to help you get started.</span></span> <span data-ttu-id="c3b40-118">さまざまなテキスト オプション、グループ/サブグループ、背景画像を試すことができます。また、さまざまなデバイスや画面にタイルがどのように対応するかを確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-118">You can experiment with all the different text options, groups/subgroups, background images, and you can see how the tile adapts to different devices and screens.</span></span> <span data-ttu-id="c3b40-119">サンプルに変更を加えたら、今後利用するために、更新したペイロードをファイルに保存できます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-119">Once you've made changes, you can save your updated payload to a file for future use.</span></span>

<span data-ttu-id="c3b40-120">エディターでは、リアルタイムにエラーと警告が示されます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-120">The editor provides real-time errors and warnings.</span></span> <span data-ttu-id="c3b40-121">たとえば、アプリのペイロードが 5 KB (プラットフォームの上限) より大きい場合、上限を超えていることを示す警告が Notifications Visualizer によって表示されます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-121">For example, if your payload is greater than 5 KB (a platform limitation), Notifications Visualizer warns you that your payload exceeds that limit.</span></span> <span data-ttu-id="c3b40-122">Notifications Visualizer では誤った属性名や値に関する警告も示され、視覚的な問題をデバッグする際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-122">It gives you warnings for incorrect attribute names or values, which helps you debug visual issues.</span></span>

<span data-ttu-id="c3b40-123">表示名、色、ロゴ、ShowName、バッジの値などのタイルのプロパティを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-123">You can control tile properties like display name, color, logos, ShowName, and badge value.</span></span> <span data-ttu-id="c3b40-124">これらのオプションを使うと、タイルのプロパティとタイル通知のペイロードがどのように影響するのか、およびこれらのオプションによって生成される結果をすぐに理解できます。</span><span class="sxs-lookup"><span data-stu-id="c3b40-124">These options help you instantly understand how your tile properties and tile notification payloads interact, and the results they produce.</span></span>

<span data-ttu-id="c3b40-125">次のアプリのスクリーンショットは、タイル エディターを示しています。</span><span class="sxs-lookup"><span data-stu-id="c3b40-125">This screenshot from the app shows the tile editor:</span></span>

![タイルが示されている Notifications Visualizer のエディター](images/notif-visualizer-004.png)

 

## <a name="related-topics"></a><span data-ttu-id="c3b40-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c3b40-127">Related topics</span></span>

* [<span data-ttu-id="c3b40-128">ストアで通知のビジュアライザーを取得します。</span><span class="sxs-lookup"><span data-stu-id="c3b40-128">Get Notifications Visualizer in the Store</span></span>](https://www.microsoft.com/store/apps/notifications-visualizer/9nblggh5xsl1)
* [<span data-ttu-id="c3b40-129">アダプティブ タイルの作成</span><span class="sxs-lookup"><span data-stu-id="c3b40-129">Create adaptive tiles</span></span>](create-adaptive-tiles.md)
* [<span data-ttu-id="c3b40-130">対話型トースト通知</span><span class="sxs-lookup"><span data-stu-id="c3b40-130">Interactive toasts</span></span>](adaptive-interactive-toasts.md)