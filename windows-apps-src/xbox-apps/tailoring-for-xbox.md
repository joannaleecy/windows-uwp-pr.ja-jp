---
author: payzer
title: Xbox ベスト プラクティス
description: Xbox 用のアプリを最適化する方法を説明します。
ms.author: wdg-dev-content
ms.date: 10/12/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 604e6dc5381a36d4dbda70e3435e5cd6fa44cc04
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5641408"
---
# <a name="xbox-best-practices"></a><span data-ttu-id="88a08-104">Xbox ベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="88a08-104">Xbox best practices</span></span>

<span data-ttu-id="88a08-105">既定では、すべての UWP アプリは何もしなくても Xbox One で動きます。</span><span class="sxs-lookup"><span data-stu-id="88a08-105">By default, all UWP apps will run on Xbox One without any extra effort on your part.</span></span> <span data-ttu-id="88a08-106">ただし、アプリを引き立たせ、ユーザーを楽しませて、Xbox に最適なアプリ エクスペリエンスを備えるには、以下のようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="88a08-106">However, if want your app to shine, delight your customers, and compete with the best app experiences on Xbox, you should follow the practices below.</span></span>
  > [!NOTE]
  > <span data-ttu-id="88a08-107">始める前に、「[Xbox およびテレビ向け設計](../design/devices/designing-for-tv.md)」で示されている設計ガイドラインを確認します。</span><span class="sxs-lookup"><span data-stu-id="88a08-107">Before you start, take a look at the design guidelines laid out in [Designing for Xbox and TV](../design/devices/designing-for-tv.md).</span></span>   

## <a name="to-build-the-best-experiences-for-xbox-one"></a><span data-ttu-id="88a08-108">Xbox One 向けの最適なエクスペリエンスを構築するには</span><span class="sxs-lookup"><span data-stu-id="88a08-108">To build the best experiences for Xbox One</span></span>

### <a name="do-turn-off-mouse-mode"></a><span data-ttu-id="88a08-109">*行うこと:* マウス モードをオフにします</span><span class="sxs-lookup"><span data-stu-id="88a08-109">*Do:* Turn off mouse mode</span></span>

<span data-ttu-id="88a08-110">Xbox ユーザーは、それぞれのコント ローラーを好みます。</span><span class="sxs-lookup"><span data-stu-id="88a08-110">Xbox users love their controllers.</span></span> <span data-ttu-id="88a08-111">コントローラー入力用に最適化するには、[マウス モードを無効](how-to-disable-mouse-mode.md)にし、方向ナビゲーション ([X-Y フォーカス](../design/devices/designing-for-tv.md#xy-focus-navigation-and-interaction)とも呼ばれます) を有効にします。</span><span class="sxs-lookup"><span data-stu-id="88a08-111">To optimize for controller input, [disable mouse mode](how-to-disable-mouse-mode.md) and enable directional navigation (also known as [X-Y focus](../design/devices/designing-for-tv.md#xy-focus-navigation-and-interaction)).</span></span> <span data-ttu-id="88a08-112">フォーカスのトラップとアクセスできない UI に注意します。</span><span class="sxs-lookup"><span data-stu-id="88a08-112">Watch out for focus traps and inaccessible UI.</span></span>

### <a name="do-draw-a-focus-rectangle-that-is-appropriate-for-a-10-foot-experience"></a><span data-ttu-id="88a08-113">*行うこと:* 10 フィート エクスペリエンス向けの適切なフォーカス用の四角形を描画します</span><span class="sxs-lookup"><span data-stu-id="88a08-113">*Do:* Draw a focus rectangle that is appropriate for a 10-foot experience</span></span>

<span data-ttu-id="88a08-114">ほとんどの Xbox ユーザーは室内でテレビに向かって座っているので、標準的なフォーカス用の四角形では 10 フィート離れた場所からでは見えにくいことに留意してください。</span><span class="sxs-lookup"><span data-stu-id="88a08-114">Most Xbox users are sitting across the living room from their TV, so keep in mind that the standard focus rectangle is hard to see from ten feet away.</span></span> <span data-ttu-id="88a08-115">入力フォーカスのある UI 要素がユーザーに常にはっきり見えるようにするには、[フォーカス表示](../design/devices/designing-for-tv.md#focus-visual)のガイドラインに従ってください。</span><span class="sxs-lookup"><span data-stu-id="88a08-115">To ensure that the UI element with the input focus is clearly visible to the user at all times, follow the [Focus visual](../design/devices/designing-for-tv.md#focus-visual) guidelines.</span></span> <span data-ttu-id="88a08-116">XAML では、アプリが Xbox で動いているときは何もしなくてもそのように動作しますが、HTML アプリの場合はカスタム CSS スタイルを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="88a08-116">In XAML you will get this behavior for free when your app runs on Xbox, but HTML apps will need to use a custom CSS style.</span></span>

### <a name="do-integrate-with-the-systemmediatransportcontrols-class"></a><span data-ttu-id="88a08-117">*行うこと:* SystemMediaTransportControls クラスと統合します</span><span class="sxs-lookup"><span data-stu-id="88a08-117">*Do:* Integrate with the SystemMediaTransportControls class</span></span>

<span data-ttu-id="88a08-118">Xbox のユーザーは、Xbox メディア リモコン Cortana (特に、"再生" と "一時停止" の音声コマンド) および Xbox SmartGlass を使用してメディア アプリを操作するのを好みます。</span><span class="sxs-lookup"><span data-stu-id="88a08-118">Xbox users want to control media apps with the Xbox Media Remote, Cortana (especially the "Play" and "Pause" voice commands), and Xbox SmartGlass.</span></span> <span data-ttu-id="88a08-119">これらの機能を自作しないでアプリに組み込むには、[SystemMediaTransportControls](https://msdn.microsoft.com/library/windows/apps/windows.media.systemmediatransportcontrols.aspx) クラスを使用する必要があります。このクラスは、Xbox メディア コントロールに自動的に含まれます。</span><span class="sxs-lookup"><span data-stu-id="88a08-119">To get these features for free your app should use the [SystemMediaTransportControls](https://msdn.microsoft.com/library/windows/apps/windows.media.systemmediatransportcontrols.aspx) class, which is automatically included in the Xbox media controls.</span></span> <span data-ttu-id="88a08-120">アプリでカスタム メディア コントロールを使用する場合は、**SystemMediaTransportControls** クラスと統合してユーザーにこれらの機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="88a08-120">If your app has custom media controls, make sure to integrate with the **SystemMediaTransportControls** class to provide these features to your users.</span></span> <span data-ttu-id="88a08-121">バックグラウンド音楽アプリを作成している場合は、**SystemMediaTransportControls** クラスと統合して、バックグラウンド音楽コントロールが Xbox のマルチタスク タブで正しく動作するようにします。</span><span class="sxs-lookup"><span data-stu-id="88a08-121">If you are creating a background music app, integrate with the **SystemMediaTransportControls** class to ensure that the background music controls work correctly in the Xbox multitasking tab.</span></span>

<!-- ### *Do:* Use adaptive UI to account for snapped apps
One of the unique features of Xbox One is that users can snap apps such as Cortana next to any other app, so your app should respond gracefully when it runs in *fill mode*. Implement [adaptive UI](../get-started/universal-application-platform-guide.md#design-adaptive-ui-with-adaptive-panels) and make sure to test your app during development by snapping an app next to it. -->

### <a name="consider-draw-to-the-edge-of-the-screen"></a><span data-ttu-id="88a08-122">*考慮すること:* 画面の端に描画するようにします</span><span class="sxs-lookup"><span data-stu-id="88a08-122">*Consider:* Draw to the edge of the screen</span></span>

<span data-ttu-id="88a08-123">多くのテレビでは画面の端が切れるので、アプリの重要なコンテンツはすべて、[テレビのセーフ エリア](../design/devices/designing-for-tv.md#tv-safe-area)の内側に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="88a08-123">Many TVs cut off the edges of the display, so all of your app's important content should be displayed within the [TV-safe area](../design/devices/designing-for-tv.md#tv-safe-area).</span></span> <span data-ttu-id="88a08-124">UWP は*オーバースキャン*を使用してコンテンツをテレビのセーフ エリアの内側に維持しますが、この既定の動作ではアプリの周囲に目立つ境界線が描画されることがあります。</span><span class="sxs-lookup"><span data-stu-id="88a08-124">UWP uses *overscan* to keep the content within the TV-safe area, but  this default behavior can draw an obvious border around your app.</span></span> <span data-ttu-id="88a08-125">最善のエクスペリエンスを提供するには、既定の動作を無効にして、「[画面の端に UI を描画する方法](turn-off-overscan.md)」の指示に従ってください。</span><span class="sxs-lookup"><span data-stu-id="88a08-125">To provide the best experience, turn off the default behavior and follow the instructions at [How to draw UI to the edge of the screen](turn-off-overscan.md).</span></span>
> [!IMPORTANT]
  > <span data-ttu-id="88a08-126">オーバースキャンを無効にした場合、対話要素とテキストをテレビのセーフ エリア内に収める処理はアプリで行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="88a08-126">If you disable overscan, it's your responsibility to make sure that interactive elements and text remain within the TV-safe area.</span></span> 

### <a name="consider-use-tv-safe-colors"></a><span data-ttu-id="88a08-127">*考慮すること:* テレビ セーフ カラーを使用します</span><span class="sxs-lookup"><span data-stu-id="88a08-127">*Consider:* Use TV-safe colors</span></span>

<span data-ttu-id="88a08-128">テレビでは、コンピューター モニターほど極端な色の輝度は処理されません。</span><span class="sxs-lookup"><span data-stu-id="88a08-128">TVs don't handle extreme color intensities as well as computer monitors do.</span></span> <span data-ttu-id="88a08-129">不自然な縞模様や色あせた画像が表示されないように、アプリでは高輝度の色を使わないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="88a08-129">Avoid high-intensity colors in your app so that users don't see odd banded effects or a washed-out image.</span></span> <span data-ttu-id="88a08-130">また、テレビの間の違いに留意してください。テレビによって色の表現が大きく異なる場合があります。\*\*</span><span class="sxs-lookup"><span data-stu-id="88a08-130">Also, be aware that differences between TVs mean that colors that look great on *your* TV might look very different to your users.</span></span> <span data-ttu-id="88a08-131">読み取りに[色](../design/devices/designing-for-tv.md#colors)の全員に適切に表示する方法について説明しました。</span><span class="sxs-lookup"><span data-stu-id="88a08-131">Read [Colors](../design/devices/designing-for-tv.md#colors) to understand how to make your app look great to everybody!</span></span>

### <a name="remember-you-can-disable-scaling"></a><span data-ttu-id="88a08-132">*憶えておくこと:* スケーリングを無効にできます</span><span class="sxs-lookup"><span data-stu-id="88a08-132">*Remember:* You can disable scaling</span></span>

<span data-ttu-id="88a08-133">UWP アプリは、コントロールやフォントなどの UI 要素がすべてのデバイスで読みやすいように自動的にスケーリングされます。</span><span class="sxs-lookup"><span data-stu-id="88a08-133">UWP apps are automatically scaled to ensure that UI elements such as controls and fonts are legible on all devices.</span></span> <span data-ttu-id="88a08-134">XAML を使用するアプリは 200% に、HTML を使用するアプリは 150% にスケーリングされます。</span><span class="sxs-lookup"><span data-stu-id="88a08-134">Apps that use XAML are scaled by 200%, while apps that use HTML are scaled by 150%.</span></span> <span data-ttu-id="88a08-135">Xbox でのアプリの表示をさらに細かく制御する場合は、既定の倍率を無効にして、HDTV (1920 x 1080) の実際のピクセル サイズを使用します。</span><span class="sxs-lookup"><span data-stu-id="88a08-135">If you want more control over how your app looks on Xbox, disable the default scale factor to use the actual pixel dimensions of an HDTV (1920x1080).</span></span> <span data-ttu-id="88a08-136">Xbox で適切に表示されるようにアプリを調整する方法については、「[スケーリングを無効にする方法](disable-scaling.md)」および「[有効ピクセルとスケーリング](../design/basics/design-and-ui-intro.md#effective-pixels-and-scaling)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="88a08-136">Take a look at [How to turn off scaling](disable-scaling.md) and [Effective pixels and scaling](../design/basics/design-and-ui-intro.md#effective-pixels-and-scaling) for information about tailoring your app to look great on Xbox.</span></span>

<span data-ttu-id="88a08-137">これらのプラクティスが適用された UWP アプリを見てみるには、次のビデオをチェックしてください。</span><span class="sxs-lookup"><span data-stu-id="88a08-137">If you want to get a glimpse of these practices applied to a UWP app, check out this video!</span></span>
</br>
</br>
<iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Tailoring-your-UWP-app-for-Xbox/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

## <a name="channel-9"></a><span data-ttu-id="88a08-138">Channel 9</span><span class="sxs-lookup"><span data-stu-id="88a08-138">Channel 9</span></span>

<span data-ttu-id="88a08-139">[Channel 9](https://channel9.msdn.com/) の以下の講演は、Xbox でのすばらしいアプリの開発に関する優れたソースです。</span><span class="sxs-lookup"><span data-stu-id="88a08-139">The following talks on [Channel 9](https://channel9.msdn.com/) are a great source of information for building amazing apps on Xbox:</span></span>

- [<span data-ttu-id="88a08-140">Xbox 向けの優れたユニバーサル Windows プラットフォーム (UWP) アプリの開発</span><span class="sxs-lookup"><span data-stu-id="88a08-140">Building Great Universal Windows Platform (UWP) Apps for Xbox</span></span>](https://channel9.msdn.com/Events/Build/2016/B883)
- [<span data-ttu-id="88a08-141">アプリを Xbox One とテレビに対応させる</span><span class="sxs-lookup"><span data-stu-id="88a08-141">Adapt Your App for Xbox One and TV</span></span>](https://channel9.msdn.com/Events/Build/2016/T651-R1)
- [<span data-ttu-id="88a08-142">UWP の開発 1: アダプティブ UI の作成</span><span class="sxs-lookup"><span data-stu-id="88a08-142">UWP Development 1: Building an Adaptive UI</span></span>](https://channel9.msdn.com/Events/Build/2016/L724-R1)
- [<span data-ttu-id="88a08-143">ブラウザーに留まらない Web アプリ: クロスプラットフォームとクロス デバイスの遭遇</span><span class="sxs-lookup"><span data-stu-id="88a08-143">Web Apps Beyond the Browser: Cross-Platform Meets Cross Device</span></span>](https://channel9.msdn.com/Events/Build/2016/B888)

## <a name="app-dev-on-xbox"></a><span data-ttu-id="88a08-144">App Dev on Xbox</span><span class="sxs-lookup"><span data-stu-id="88a08-144">App Dev on Xbox</span></span>

<span data-ttu-id="88a08-145">**App Dev on Xbox**イベントは、Xbox アプリの構築に新しい開発者向けの適切な開始点です。</span><span class="sxs-lookup"><span data-stu-id="88a08-145">The **App Dev on Xbox** event is a great starting point for developers new to building apps on Xbox.</span></span>

* [<span data-ttu-id="88a08-146">記録されたセッションを視聴します。</span><span class="sxs-lookup"><span data-stu-id="88a08-146">Watch the recorded sessions</span></span>](https://developer.microsoft.com/windows/projects/campaigns/app-dev-on-xbox-event#WatchNow)
* [<span data-ttu-id="88a08-147">ブログの投稿を読み取る</span><span class="sxs-lookup"><span data-stu-id="88a08-147">Read the blog posts</span></span>](https://developer.microsoft.com/windows/projects/campaigns/app-dev-on-xbox-event#BlogSeries)

## <a name="see-also"></a><span data-ttu-id="88a08-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="88a08-148">See also</span></span>

- [<span data-ttu-id="88a08-149">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="88a08-149">UWP on Xbox One</span></span>](index.md)
- [<span data-ttu-id="88a08-150">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="88a08-150">Designing for Xbox and TV</span></span>](../design/devices/designing-for-tv.md)
