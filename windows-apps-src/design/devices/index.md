---
author: mijacobs
Description: Getting to know the devices that support Universal Windows Platform (UWP) apps will help you offer the best user experience for each form factor.
title: ユニバーサル Windows プラットフォーム (UWP) アプリ用デバイスの基本情報
ms.assetid: 7665044E-F007-495D-8D56-CE7C2361CDC4
label: Device primer
template: detail.hbs
keywords: デバイス, 入力, 操作
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 6f5e6c96c67052f1933bf4fb69988ae1eae27ee0
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5920233"
---
#  <a name="device-primer-for-universal-windows-platform-uwp-apps"></a><span data-ttu-id="d0f3d-103">ユニバーサル Windows プラットフォーム (UWP) アプリ用デバイスの基本情報</span><span class="sxs-lookup"><span data-stu-id="d0f3d-103">Device primer for Universal Windows Platform (UWP) apps</span></span>



![Windows デバイス](images/device-primer/device-primer-ramp.png)

<span data-ttu-id="d0f3d-105">ユニバーサル Windows プラットフォーム (UWP) アプリをサポートするデバイスを理解すると、各フォーム ファクター向けの最適なユーザー エクスペリエンスを提供するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-105">Getting to know the devices that support Universal Windows Platform (UWP) apps will help you offer the best user experience for each form factor.</span></span> <span data-ttu-id="d0f3d-106">特定のデバイス向けのアプリを設計するときは、アプリがデバイスにどのように表示されるか、そのデバイスでアプリがいつどこでどのように使われるか、ユーザーがそのデバイスをどのように操作するかについて、特に考慮する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-106">When designing for a particular device, the main considerations include how the app will appear on that device, where, when, and how the app will be used on that device, and how the user will interact with that device.</span></span>

## <a name="pcs-and-laptops"></a><span data-ttu-id="d0f3d-107">PC とノート PC</span><span class="sxs-lookup"><span data-stu-id="d0f3d-107">PCs and laptops</span></span>


<span data-ttu-id="d0f3d-108">Windows PC とノート PC には、多種多様なデバイスと画面サイズがあります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-108">Windows PCs and laptops include a wide array of devices and screen sizes.</span></span> <span data-ttu-id="d0f3d-109">一般に、PC やノート PC は電話やタブレットより多くの情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-109">In general, PCs and laptops can display more info than phone or tablets.</span></span>

<span data-ttu-id="d0f3d-110">画面サイズ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-110">Screen sizes</span></span>
-   <span data-ttu-id="d0f3d-111">13" 以上</span><span class="sxs-lookup"><span data-stu-id="d0f3d-111">13” and greater</span></span>

![PC](images/device-primer/device-primer-desktop.png)

<span data-ttu-id="d0f3d-113">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="d0f3d-113">Typical usage</span></span>
-   <span data-ttu-id="d0f3d-114">デスクトップとノート PC のアプリは共有で使われますが、一度に使うことができるのは 1 人のユーザーだけであり、通常は長時間使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-114">Apps on desktops and laptops see shared use, but by one user at a time, and usually for longer periods.</span></span>

<span data-ttu-id="d0f3d-115">UI に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="d0f3d-115">UI considerations</span></span>
-   <span data-ttu-id="d0f3d-116">アプリは、ユーザーが決めたウィンドウ表示のサイズにすることができます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-116">Apps can have a windowed view, the size of which is determined by the user.</span></span> <span data-ttu-id="d0f3d-117">ウィンドウのサイズによっては、1 ～ 3 つのフレームを表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-117">Depending on window size, there can be between one and three frames.</span></span> <span data-ttu-id="d0f3d-118">大型のモニターでは、アプリは 3 つを超えるフレームを表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-118">On larger monitors, the app can have more than three frames.</span></span>

-   <span data-ttu-id="d0f3d-119">アプリをデスクトップまたはノート PC で使う場合、ユーザーがアプリのファイルを制御できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-119">When using an app on a desktop or laptop, the user has control over app files.</span></span> <span data-ttu-id="d0f3d-120">アプリの設計者は、アプリのコンテンツを管理するメカニズムを必ず用意してください。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-120">As an app designer, be sure to provide the mechanisms to manage your app’s content.</span></span> <span data-ttu-id="d0f3d-121">[名前を付けて保存] や [最近使ったファイル] などのコマンドや機能を含めることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-121">Consider including commands and features such as "Save As", "Recent files", and so on.</span></span>

-   <span data-ttu-id="d0f3d-122">システムの戻るボタンはオプションです。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-122">System back is optional.</span></span> <span data-ttu-id="d0f3d-123">アプリの開発者が表示するように選択した場合、アプリのタイトル バーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-123">When an app developer chooses to show it, it appears in the app title bar.</span></span>

<span data-ttu-id="d0f3d-124">入力</span><span class="sxs-lookup"><span data-stu-id="d0f3d-124">Inputs</span></span>
-   <span data-ttu-id="d0f3d-125">マウス</span><span class="sxs-lookup"><span data-stu-id="d0f3d-125">Mouse</span></span>
-   <span data-ttu-id="d0f3d-126">キーボード</span><span class="sxs-lookup"><span data-stu-id="d0f3d-126">Keyboard</span></span>
-   <span data-ttu-id="d0f3d-127">タッチ (ノート PC とオールインワン型デスクトップ)。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-127">Touch on laptops and all-in-one desktops.</span></span>
-   <span data-ttu-id="d0f3d-128">Xbox コントローラーなどのゲームパッドが使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-128">Gamepads, such as the Xbox controller, are sometimes used.</span></span>

<span data-ttu-id="d0f3d-129">デバイスの標準的な機能</span><span class="sxs-lookup"><span data-stu-id="d0f3d-129">Typical device capabilities</span></span>
-   <span data-ttu-id="d0f3d-130">カメラ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-130">Camera</span></span>
-   <span data-ttu-id="d0f3d-131">マイク</span><span class="sxs-lookup"><span data-stu-id="d0f3d-131">Microphone</span></span>

## <a name="tablets-and-2-in-1s"></a><span data-ttu-id="d0f3d-132">タブレットと 2 in 1</span><span class="sxs-lookup"><span data-stu-id="d0f3d-132">Tablets and 2-in-1s</span></span>


<span data-ttu-id="d0f3d-133">超軽量のタブレット コンピューターは、タッチスクリーン、カメラ、マイク、および加速度計を備えています。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-133">Ultra-portable tablet computers are equipped with touchscreens, cameras, microphones, and accelerometers.</span></span> <span data-ttu-id="d0f3d-134">タブレットの画面サイズは、通常は 7 ～ 13.3 インチです。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-134">Tablet screen sizes usually range from 7” to 13.3”.</span></span> <span data-ttu-id="d0f3d-135">2 in 1 デバイスは、構成によって (通常は、画面をたたむか直立させて切り替えます)、タブレットまたはキーボードとマウスを使ったノート PC として利用できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-135">2-in-1 devices can act like either a tablet or a laptop with a keyboard and mouse, depending on the configuration (usually involving folding the screen back or tilting it upright).</span></span>

<span data-ttu-id="d0f3d-136">画面サイズ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-136">Screen sizes</span></span>
- <span data-ttu-id="d0f3d-137">タブレットの場合、7 ～ 13.3 インチ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-137">7” to 13.3” for tablet</span></span>
- <span data-ttu-id="d0f3d-138">2 in 1 の場合は 13.3 インチ以上</span><span class="sxs-lookup"><span data-stu-id="d0f3d-138">13.3" and greater for 2-in-1</span></span>

![タブレット デバイス](images/device-primer/device-primer-tablet.png)

<span data-ttu-id="d0f3d-140">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="d0f3d-140">Typical usage</span></span>
-   <span data-ttu-id="d0f3d-141">タブレットは、約 80% がその所有者によって使われ、残りの約 20% が共有されています。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-141">About 80% of tablet use is by the owner, with the other 20% being shared use.</span></span>
-   <span data-ttu-id="d0f3d-142">最も一般的なのは、自宅でテレビを視聴しているときのコンパニオン デバイスとして使うことです。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-142">It’s most commonly used at home as a companion device while watching TV.</span></span>
-   <span data-ttu-id="d0f3d-143">電話とファブレットよりも長い時間使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-143">It’s used for longer periods than phones and phablets.</span></span>
-   <span data-ttu-id="d0f3d-144">テキストは一気に入力されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-144">Text is entered in short bursts.</span></span>

<span data-ttu-id="d0f3d-145">UI に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="d0f3d-145">UI considerations</span></span>
-   <span data-ttu-id="d0f3d-146">タブレットは、横方向でも縦方向でも一度に 2 つのフレームを表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-146">In both landscape and portrait orientations, tablets allow two frames at a time.</span></span>
-   <span data-ttu-id="d0f3d-147">システムの戻るボタンはナビゲーション バーに配置されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-147">System back is located on the navigation bar.</span></span>

<span data-ttu-id="d0f3d-148">入力</span><span class="sxs-lookup"><span data-stu-id="d0f3d-148">Inputs</span></span>
-   <span data-ttu-id="d0f3d-149">タッチ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-149">Touch</span></span>
-   <span data-ttu-id="d0f3d-150">スタイラス</span><span class="sxs-lookup"><span data-stu-id="d0f3d-150">Stylus</span></span>
-   <span data-ttu-id="d0f3d-151">外部キーボード (ときどき)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-151">External keyboard (occasionally)</span></span>
-   <span data-ttu-id="d0f3d-152">マウス (ときどき)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-152">Mouse (occasionally)</span></span>
-   <span data-ttu-id="d0f3d-153">音声 (ときどき)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-153">Voice (occasionally)</span></span>

<span data-ttu-id="d0f3d-154">デバイスの標準的な機能</span><span class="sxs-lookup"><span data-stu-id="d0f3d-154">Typical device capabilities</span></span>
-   <span data-ttu-id="d0f3d-155">カメラ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-155">Camera</span></span>
-   <span data-ttu-id="d0f3d-156">マイク</span><span class="sxs-lookup"><span data-stu-id="d0f3d-156">Microphone</span></span>
-   <span data-ttu-id="d0f3d-157">移動センサー (複数)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-157">Movement sensors</span></span>
-   <span data-ttu-id="d0f3d-158">位置センサー (複数)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-158">Location sensors</span></span>

> [!NOTE]
> <span data-ttu-id="d0f3d-159">PC の考慮事項のほとんどが 2 in 1 にも当てはまります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-159">Most of the considerations for PCs and laptops apply to 2-in-1s as well.</span></span>

## <a name="xbox-and-tv"></a><span data-ttu-id="d0f3d-160">Xbox とテレビ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-160">Xbox and TV</span></span>

<span data-ttu-id="d0f3d-161">ソファーに座りながらゲームパッドやリモコンを使って部屋の反対側にあるテレビを操作することを、**10 フィート エクスペリエンス**といいます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-161">The experience of sitting on your couch across the room, using a gamepad or remote to interact with your TV, is called the **10-foot experience**.</span></span> <span data-ttu-id="d0f3d-162">通常は画面から約 10 フィート (約 3 m) の距離に座るため、このように呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-162">It is so named because the user is generally sitting approximately 10 feet away from the screen.</span></span> <span data-ttu-id="d0f3d-163">この場合、たとえば PC の操作 (*2 フィート* エクスペリエンスと呼ばれます) には見られない、特有の課題があります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-163">This provides unique challenges that aren't present in, say, the *2-foot* experience, or interacting with a PC.</span></span> <span data-ttu-id="d0f3d-164">テレビ画面に接続し、ゲームパッドやリモコンを使うこともある Xbox One やその他のデバイス向けアプリを開発している場合、この点を常に意識しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-164">If you are developing an app for Xbox One or any other device that's connected to a TV screen and might use a gamepad or remote for input, you should always keep this in mind.</span></span>

<span data-ttu-id="d0f3d-165">10 フィート エクスペリエンスを提供する UWP アプリの設計は、ここに記載されているその他のデバイス カテゴリでの設計とは非常に異なります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-165">Designing your UWP app for the 10-foot experience is very different from designing for any of the other device categories listed here.</span></span> <span data-ttu-id="d0f3d-166">詳しくは、「[Xbox およびテレビ向け設計](designing-for-tv.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-166">For more information, see [Designing for Xbox and TV](designing-for-tv.md).</span></span>

<span data-ttu-id="d0f3d-167">画面サイズ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-167">Screen sizes</span></span>
- <span data-ttu-id="d0f3d-168">24 インチ以上</span><span class="sxs-lookup"><span data-stu-id="d0f3d-168">24" and up</span></span>

![Xbox とテレビ](images/device-primer/device-primer-tv-and-xbox.png)

<span data-ttu-id="d0f3d-170">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="d0f3d-170">Typical usage</span></span>
- <span data-ttu-id="d0f3d-171">多くの場合は、複数のユーザーが共有して使用しますが、1 人だけで使用することもよくあります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-171">Often shared among several people, though is also often used by just one person.</span></span>
- <span data-ttu-id="d0f3d-172">通常は長時間使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-172">Usually used for longer periods.</span></span>
- <span data-ttu-id="d0f3d-173">最もよく使用される場所は自宅で、一か所に据え置かれます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-173">Most commonly used at home, staying in one place.</span></span>
- <span data-ttu-id="d0f3d-174">ゲームパッドやリモコンを使ってのテキスト入力は時間がかかるため、テキスト入力が求められることはほとんどありません。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-174">Rarely asks for text input because it takes longer with a gamepad or remote.</span></span>
- <span data-ttu-id="d0f3d-175">画面の向きは固定されています。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-175">Orientation of the screen is fixed.</span></span>
- <span data-ttu-id="d0f3d-176">通常、一度に 1 つのアプリのみを実行しますが、画面の端にアプリをスナップできる場合があります (Xbox など)。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-176">Usually only runs one app at a time, but it may be possible to snap apps to the side (such as on Xbox).</span></span>

<span data-ttu-id="d0f3d-177">UI に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="d0f3d-177">UI considerations</span></span>
- <span data-ttu-id="d0f3d-178">アプリのサイズは、他のアプリが画面の端にスナップされていない限り、通常は変化しません。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-178">Apps usually stay the same size, unless another app is snapped to the side.</span></span>
- <span data-ttu-id="d0f3d-179">システムの戻るボタン、ほとんどの Xbox アプリで提供される便利な機能で、ゲームパッドの B ボタンを使用してアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-179">System back is useful functionality that is offered in most Xbox apps, accessed using the B button on the gamepad.</span></span>
- <span data-ttu-id="d0f3d-180">通常、ユーザーは画面から約 10 フィート (約 3 m) の距離に座るため、読み取れるように十分な大きさで明瞭な UI が必要です。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-180">Since the customer is sitting approximately 10 feet away from the screen, make sure that UI is large and clear enough to be visible.</span></span>

<span data-ttu-id="d0f3d-181">入力</span><span class="sxs-lookup"><span data-stu-id="d0f3d-181">Inputs</span></span>
- <span data-ttu-id="d0f3d-182">ゲームパッド (Xbox コントローラーなど)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-182">Gamepad (such as an Xbox controller)</span></span>
- <span data-ttu-id="d0f3d-183">リモコン</span><span class="sxs-lookup"><span data-stu-id="d0f3d-183">Remote</span></span>
- <span data-ttu-id="d0f3d-184">音声 (Kinect やヘッドセットを使用する場合)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-184">Voice (occasionally, if the customer has a Kinect or headset)</span></span>

<span data-ttu-id="d0f3d-185">デバイスの標準的な機能</span><span class="sxs-lookup"><span data-stu-id="d0f3d-185">Typical device capabilities</span></span>
- <span data-ttu-id="d0f3d-186">カメラ (Kinect を使用する場合)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-186">Camera (occasionally, if the customer has a Kinect)</span></span>
- <span data-ttu-id="d0f3d-187">マイク (Kinect やヘッドセットを使用する場合)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-187">Microphone (occasionally, if the customer has a Kinect or headset)</span></span>
- <span data-ttu-id="d0f3d-188">移動センサー (Kinect を使用する場合)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-188">Movement sensors (occasionally, if the customer has a Kinect)</span></span>

## <a name="phones-and-phablets"></a><span data-ttu-id="d0f3d-189">電話とファブレット</span><span class="sxs-lookup"><span data-stu-id="d0f3d-189">Phones and phablets</span></span>


<span data-ttu-id="d0f3d-190">すべてのコンピューティング デバイスの中で最も広く使われている電話では、限られた画面領域と基本的な入力方法を使って、さまざまな操作を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-190">The most widely-used of all computing devices, phones can do a lot with limited screen real estate and basic inputs.</span></span> <span data-ttu-id="d0f3d-191">電話にはさまざまなサイズがあり、大きい電話はファブレットと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-191">Phones are available in a variety of sizes; larger phones are called phablets.</span></span> <span data-ttu-id="d0f3d-192">ファブレットでのアプリのエクスペリエンスは、電話でのエクスペリエンスと似ていますが、画面領域が大きくなることで、コンテンツ操作時に重要な変更が可能になります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-192">App experiences on phablets are similar to those on phones, but the increased screen real estate of phablets enable some key changes in content consumption.</span></span>

<span data-ttu-id="d0f3d-193">互換性のある windows 10 モバイル デバイスの新しいエクスペリエンスで電話用 Continuum は、ユーザーは電話をモニターに接続し、でも、マウスやキーボードを使用してラップトップように使う。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-193">With Continuum for Phones, a new experience for compatible Windows10 mobile devices, users can connect their phones to a monitor and even use a mouse and keyboard to make their phones work like a laptop.</span></span> <span data-ttu-id="d0f3d-194">詳しくは、「[電話用 Continuum](http://go.microsoft.com/fwlink/p/?LinkID=699431)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-194">(For more info, see the [Continuum for Phone article](http://go.microsoft.com/fwlink/p/?LinkID=699431).)</span></span>

<span data-ttu-id="d0f3d-195">画面サイズ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-195">Screen sizes</span></span>
-   <span data-ttu-id="d0f3d-196">電話の場合、4" ～ 5"</span><span class="sxs-lookup"><span data-stu-id="d0f3d-196">4'' to 5'' for phone</span></span>
-   <span data-ttu-id="d0f3d-197">ファブレットの場合、5.5" ～ 7"</span><span class="sxs-lookup"><span data-stu-id="d0f3d-197">5.5'' to 7'' for phablet</span></span>

![Windows Phone](images/device-primer/device-primer-phablet.png)

<span data-ttu-id="d0f3d-199">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="d0f3d-199">Typical usage</span></span>
-   <span data-ttu-id="d0f3d-200">主に縦向きで使われます。これはほとんどの場合、片手で電話を持つのが簡単であること、その方法で完全に電話を操作できることが理由ですが、写真やビデオの表示、本の閲覧、テキストの作成など、横向きが適切なエクスペリエンスもあります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-200">Primarily used in portrait orientation, mostly due to the ease of holding the phone with one hand and being able to fully interact with it that way, but there are some experiences that work well in landscape, such as viewing photos and video, reading a book, and composing text.</span></span>
-   <span data-ttu-id="d0f3d-201">ほとんどの場合、そのデバイスの所有者である 1 人のユーザーによって使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-201">Mostly used by just one person, the owner of the device.</span></span>
-   <span data-ttu-id="d0f3d-202">常に手近にあり、通常はポケットやバッグに入れられます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-202">Always within reach, usually stashed in a pocket or a bag.</span></span>
-   <span data-ttu-id="d0f3d-203">短時間使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-203">Used for brief periods of time.</span></span>
-   <span data-ttu-id="d0f3d-204">ユーザーは、電話を使うときによくマルチタスクを実行します。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-204">Users are often multitasking when using the phone.</span></span>
-   <span data-ttu-id="d0f3d-205">テキストは一気に入力されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-205">Text is entered in short bursts.</span></span>

<span data-ttu-id="d0f3d-206">UI に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="d0f3d-206">UI considerations</span></span>
-   <span data-ttu-id="d0f3d-207">電話の画面の小さいサイズでは、横方向でも縦方向でも、一度に 1 つのフレームのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-207">The small size of a phone's screen allows only one frame at a time to be viewed in both portrait and landscape orientations.</span></span> <span data-ttu-id="d0f3d-208">電話のすべての階層型ナビゲーション パターンでは「ドリルダウン」モデルを使い、ユーザーが単一フレームの UI レイヤーを移動するようにします。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-208">All hierarchical navigation patterns on a phone use the "drill" model, with the user navigating through single-frame UI layers.</span></span>

-   <span data-ttu-id="d0f3d-209">電話と同じように、縦モードのファブレットには、一度に 1 つのフレームのみを表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-209">Similar to phones, phablets in portrait mode can view only one frame at a time.</span></span> <span data-ttu-id="d0f3d-210">ただし、ファブレットで使うことができる画面領域は大きいため、ユーザーはファブレットを横方向に回転させてそのまま保持することで、2 つのアプリ フレームを同時に表示できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-210">But with the greater screen real estate available on a phablet, users have the ability to rotate to landscape orientation and stay there, so two app frames can be visible at a time.</span></span>

-   <span data-ttu-id="d0f3d-211">横方向と縦方向の両方で、スクリーン キーボードが表示されているときに、アプリ バーを表示するための十分な画面領域があることを確認します。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-211">In both landscape and portrait orientations, be sure that there's enough screen real estate for the app bar when the on-screen keyboard is up.</span></span>

<span data-ttu-id="d0f3d-212">入力</span><span class="sxs-lookup"><span data-stu-id="d0f3d-212">Inputs</span></span>
-   <span data-ttu-id="d0f3d-213">タッチ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-213">Touch</span></span>
-   <span data-ttu-id="d0f3d-214">音声</span><span class="sxs-lookup"><span data-stu-id="d0f3d-214">Voice</span></span>

<span data-ttu-id="d0f3d-215">デバイスの標準的な機能</span><span class="sxs-lookup"><span data-stu-id="d0f3d-215">Typical device capabilities</span></span>
-   <span data-ttu-id="d0f3d-216">マイク</span><span class="sxs-lookup"><span data-stu-id="d0f3d-216">Microphone</span></span>
-   <span data-ttu-id="d0f3d-217">カメラ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-217">Camera</span></span>
-   <span data-ttu-id="d0f3d-218">移動センサー (複数)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-218">Movement sensors</span></span>
-   <span data-ttu-id="d0f3d-219">位置センサー (複数)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-219">Location sensors</span></span>

 

## <a name="surface-hub-devices"></a><span data-ttu-id="d0f3d-220">Surface Hub デバイス</span><span class="sxs-lookup"><span data-stu-id="d0f3d-220">Surface Hub devices</span></span>


<span data-ttu-id="d0f3d-221">Microsoft Surface Hub は、複数のユーザーによる同時使用のために設計された大画面のチーム コラボレーション デバイスです。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-221">Microsoft Surface Hub is a large-screen team collaboration device designed for simultaneous use by multiple users.</span></span>

<span data-ttu-id="d0f3d-222">画面サイズ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-222">Screen sizes</span></span>
-   <span data-ttu-id="d0f3d-223">55" および 84"</span><span class="sxs-lookup"><span data-stu-id="d0f3d-223">55” and 84''</span></span>

![Surface Hub](images/device-primer/device-primer-surfacehub3.png)

<span data-ttu-id="d0f3d-225">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="d0f3d-225">Typical usage</span></span>
-   <span data-ttu-id="d0f3d-226">Surface Hub 上のアプリは、会議などで短時間共有して使われます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-226">Apps on Surface Hub see shared use for short periods of time, such as in meetings.</span></span>

-   <span data-ttu-id="d0f3d-227">ほとんどの場合、Surface Hub デバイス固定された状態で使われ、移動することはめったにありません。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-227">Surface Hub devices are mostly stationary and rarely moved.</span></span>

<span data-ttu-id="d0f3d-228">UI に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="d0f3d-228">UI considerations</span></span>
-   <span data-ttu-id="d0f3d-229">Surface Hub 上のアプリは 4 つの状態のいずれかで表示されます。全画面 (標準の全画面表示)、バックグラウンド (アプリの実行中に非表示になり、タスク スイッチャーで利用可能)、フィル (利用可能なステージ エリアを使う固定表示)、スナップ (ステージの右端または左端を使う可変表示) です。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-229">Apps on Surface Hub can appear in one of four states - full (standard full-screen view), background (hidden from view while the app is still running, available in task switcher), fill (a fixed view that occupies the available stage area), and snapped (variable view that occupies the right or left sides of the stage).</span></span>
-   <span data-ttu-id="d0f3d-230">スナップ モードまたはフィル モードでは、Skype サイドバーが表示され、アプリは横方向に縮小されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-230">In snapped mode or fill modes, the system displays the Skype sidebar and shrinks the app horizontally.</span></span>
-   <span data-ttu-id="d0f3d-231">システムの戻るボタンはオプションです。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-231">System back is optional.</span></span> <span data-ttu-id="d0f3d-232">アプリの開発者が表示するように選択した場合、アプリのタイトル バーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-232">When an app developer chooses to show it, it appears in the app title bar.</span></span>

<span data-ttu-id="d0f3d-233">入力</span><span class="sxs-lookup"><span data-stu-id="d0f3d-233">Inputs</span></span>
-   <span data-ttu-id="d0f3d-234">タッチ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-234">Touch</span></span>
-   <span data-ttu-id="d0f3d-235">ペン</span><span class="sxs-lookup"><span data-stu-id="d0f3d-235">Pen</span></span>
-   <span data-ttu-id="d0f3d-236">音声</span><span class="sxs-lookup"><span data-stu-id="d0f3d-236">Voice</span></span>
-   <span data-ttu-id="d0f3d-237">キーボード (スクリーン/リモート)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-237">Keyboard (on-screen/remote)</span></span>
-   <span data-ttu-id="d0f3d-238">タッチパッド (リモート)</span><span class="sxs-lookup"><span data-stu-id="d0f3d-238">Touchpad (remote)</span></span>

<span data-ttu-id="d0f3d-239">デバイスの標準的な機能</span><span class="sxs-lookup"><span data-stu-id="d0f3d-239">Typical device capabilities</span></span>
-   <span data-ttu-id="d0f3d-240">カメラ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-240">Camera</span></span>
-   <span data-ttu-id="d0f3d-241">マイク</span><span class="sxs-lookup"><span data-stu-id="d0f3d-241">Microphone</span></span>

 

## <a name="windows-iot-devices"></a><span data-ttu-id="d0f3d-242">Windows IoT デバイス</span><span class="sxs-lookup"><span data-stu-id="d0f3d-242">Windows IoT devices</span></span>


<span data-ttu-id="d0f3d-243">Windows IoT デバイスは、最新クラスのデバイスであり、主に小型のエレクトロニクス、センサー、接続機能が物理オブジェクト内に埋め込まれたものです。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-243">Windows IoT devices are an emerging class of devices centered around embedding small electronics, sensors, and connectivity within physical objects.</span></span> <span data-ttu-id="d0f3d-244">通常、これらのデバイスはネットワークまたはインターネット経由で接続され、感知した実際のデータについて報告します。場合によっては、それに対して処理を実行することもあります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-244">These devices are usually connected through a network or the Internet to report on the real-world data they sense, and in some cases act on it.</span></span> <span data-ttu-id="d0f3d-245">デバイスには、画面がない場合 ("ヘッドレス" デバイスとも呼ばれます) と、一般的に 3.5" 以下の小さい画面に接続される場合 ("ヘッド付き" デバイスとも呼ばれます) があります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-245">Devices can either have no screen (also known as “headless” devices) or are connected to a small screen (known as “headed” devices) with a screen size usually 3.5” or smaller.</span></span>

<span data-ttu-id="d0f3d-246">画面サイズ</span><span class="sxs-lookup"><span data-stu-id="d0f3d-246">Screen sizes</span></span>
-   <span data-ttu-id="d0f3d-247">3.5" 以下</span><span class="sxs-lookup"><span data-stu-id="d0f3d-247">3.5'' or smaller</span></span>
-   <span data-ttu-id="d0f3d-248">一部のデバイスには画面がない</span><span class="sxs-lookup"><span data-stu-id="d0f3d-248">Some devices have no screen</span></span>

![IoT デバイス](images/device-primer/device-primer-iot-device.png)

<span data-ttu-id="d0f3d-250">一般的な使い方</span><span class="sxs-lookup"><span data-stu-id="d0f3d-250">Typical usage</span></span>
-   <span data-ttu-id="d0f3d-251">通常、ネットワークまたはインターネット経由で接続されており、感知した実際のデータについて報告します。場合によっては、それに対して処理を実行することもあります。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-251">Usually connected through a network or the Internet to report on the real-world data they sense, and in some cases act on it.</span></span>
-   <span data-ttu-id="d0f3d-252">これらのデバイスは電話やその他の大型デバイスとは異なり、一度に 1 つのアプリケーションのみ実行できます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-252">These devices can only run one application at a time unlike phones or other larger devices.</span></span>
-   <span data-ttu-id="d0f3d-253">常に操作するデバイスではありませんが、必要なときに利用でき、必要でないときに邪魔になりません。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-253">It isn’t something that is interacted with all the time, but instead is available when you need it, out of the way when you don’t.</span></span>
-   <span data-ttu-id="d0f3d-254">アプリには専用のバック アフォーダンスはなく、これは開発者の責任です。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-254">App doesn’t have a dedicated back affordance, that is the developers responsibility.</span></span>

<span data-ttu-id="d0f3d-255">UI に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="d0f3d-255">UI considerations</span></span>
-   <span data-ttu-id="d0f3d-256">"ヘッドレス "デバイスには画面がありません。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-256">"headless" devices have no screen.</span></span>
-   <span data-ttu-id="d0f3d-257">"ヘッド付き" デバイスの画面は最小限で、画面サイズと機能が制限されているため、必要なもののみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-257">Display for “headed” devices is minimal, only showing what is necessary due to limited screen real estate and functionality.</span></span>
-   <span data-ttu-id="d0f3d-258">ほとんどの場合、向きはロックされるため、アプリでは 1 つの表示方向を考慮するだけで済みます。</span><span class="sxs-lookup"><span data-stu-id="d0f3d-258">Orientation is most times locked, so your app only needs to consider one display direction.</span></span>

<span data-ttu-id="d0f3d-259">入力</span><span class="sxs-lookup"><span data-stu-id="d0f3d-259">Inputs</span></span>
-   <span data-ttu-id="d0f3d-260">デバイスに応じて可変</span><span class="sxs-lookup"><span data-stu-id="d0f3d-260">Variable, depending on the device</span></span>

<span data-ttu-id="d0f3d-261">デバイスの標準的な機能</span><span class="sxs-lookup"><span data-stu-id="d0f3d-261">Typical device capabilities</span></span>
-   <span data-ttu-id="d0f3d-262">デバイスに応じて可変</span><span class="sxs-lookup"><span data-stu-id="d0f3d-262">Variable, depending on the device</span></span>