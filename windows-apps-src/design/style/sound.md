---
Description: Sound helps complete an application's user experience, and gives them that extra audio edge they need to match the feel of Windows across all platforms.
label: Sound
title: サウンド
template: detail.hbs
ms.assetid: 9fa77494-2525-4491-8f26-dc733b6a18f6
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: kisai
design-contact: mattben
dev-contact: joyate
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 74d1d5b04b13795a075e7111ed898243ed59e7b7
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8334095"
---
# <a name="sound"></a><span data-ttu-id="8008d-103">サウンド</span><span class="sxs-lookup"><span data-stu-id="8008d-103">Sound</span></span>

![ヒーロー イメージ](images/header-sound.svg)

<span data-ttu-id="8008d-105">サウンドを使ってアプリを向上させるには、さまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-105">There are many ways to use sound to enhance your app.</span></span> <span data-ttu-id="8008d-106">ユーザーがイベントを音声で認識できるように、サウンドを使って他の UI 要素を補完できます。</span><span class="sxs-lookup"><span data-stu-id="8008d-106">You can use to sound to supplement other UI elements, enabling users to recognize events audibly.</span></span> <span data-ttu-id="8008d-107">視覚障碍のあるユーザーにとって、サウンドは効果的なユーザー インターフェイスの要素となる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-107">Sound can be an effective user interface element for people with visual disabilities.</span></span> <span data-ttu-id="8008d-108">サウンドを使ってユーザーを釘づけにするような雰囲気を作ることができます。たとえば、パズル ゲームのバックグラウンドで風変わりなサウンドトラックを再生したり、ホラー ゲームやサバイバル ゲームで不気味なサウンド効果を使う可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-108">You can use sound to create an atmosphere that immerses the user; for example, you might play a whimsical soundtrack in the background of puzzle game, or use ominous sound effects for a horror/survival game.</span></span>

## <a name="sound-global-api"></a><span data-ttu-id="8008d-109">サウンドのグローバル API</span><span class="sxs-lookup"><span data-stu-id="8008d-109">Sound Global API</span></span>

<span data-ttu-id="8008d-110">UWP には使いやすいサウンド システムが用意されていて、「スイッチを切り替える」だけで、アプリ全体にイマーシブなオーディオ エクスペリエンスを実装することができます。</span><span class="sxs-lookup"><span data-stu-id="8008d-110">UWP provides an easily accessible sound system that allows you to simply "flip a switch" and get an immersive audio experience across your entire app.</span></span>

<span data-ttu-id="8008d-111">[**ElementSoundPlayer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.elementsoundplayer) は、XAML 内の統合的なサウンド システムで、オンにすると、すべての既定のコントロールで自動的にサウンドが再生されます。</span><span class="sxs-lookup"><span data-stu-id="8008d-111">The [**ElementSoundPlayer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.elementsoundplayer) is an integrated sound system within XAML, and when turned on all default controls will play sounds automatically.</span></span>
```C#
ElementSoundPlayer.State = ElementSoundPlayerState.On;
```
<span data-ttu-id="8008d-112">**ElementSoundPlayer** には、3 つの異なる状態、**On**、**Off**、**Auto** があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-112">The **ElementSoundPlayer** has three different states: **On** **Off** and **Auto**.</span></span>

<span data-ttu-id="8008d-113">**Off** に設定すると、アプリの実行環境に関わらず、サウンドが再生されることはありません。</span><span class="sxs-lookup"><span data-stu-id="8008d-113">If set to **Off**, no matter where your app is run, sound will never play.</span></span> <span data-ttu-id="8008d-114">**On** に設定すると、すべてのプラットフォームで、アプリのサウンドが再生されます。</span><span class="sxs-lookup"><span data-stu-id="8008d-114">If set to **On** sounds for your app will play on every platform.</span></span>

<span data-ttu-id="8008d-115">ElementSoundPlayer を有効にすると、空間オーディオ (3D サウンド) も自動的に有効になります。</span><span class="sxs-lookup"><span data-stu-id="8008d-115">Enabling ElementSoundPlayer will automatically enable spatial audio (3D sound) as well.</span></span> <span data-ttu-id="8008d-116">サウンドをオンにしたまま 3D サウンドを無効にするには、ElementSoundPlayer の **SpatialAudioMode** を無効にします。</span><span class="sxs-lookup"><span data-stu-id="8008d-116">To disable 3D sound (while still keeping the sound on), disable the **SpatialAudioMode** of the ElementSoundPlayer:</span></span> 

```C#
ElementSoundPlayer.SpatialAudioMode = ElementSpatialAudioMode.Off
```

<span data-ttu-id="8008d-117">**SpatialAudioMode** プロパティの有効な値は以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8008d-117">The **SpatialAudioMode** property can takes these values:</span></span> 
- <span data-ttu-id="8008d-118">**Auto**: サウンドがオンのときに、空間オーディオがオンになります。</span><span class="sxs-lookup"><span data-stu-id="8008d-118">**Auto**: Spatial audio will turn on when sound is on.</span></span> 
- <span data-ttu-id="8008d-119">**Off**: サウンドがオンでも、空間オーディオは常にオフです。</span><span class="sxs-lookup"><span data-stu-id="8008d-119">**Off**: Spatial audio is always off, even if sound is on.</span></span>
- <span data-ttu-id="8008d-120">**On**: 空間オーディオが常に再生されます。</span><span class="sxs-lookup"><span data-stu-id="8008d-120">**On**: Spatial audio will always play.</span></span>

<span data-ttu-id="8008d-121">空間オーディオと XAML による空間オーディオの処理方法について詳しくは、[「オーディオ グラフ」の「空間オーディオ」](/windows/uwp/audio-video-camera/audio-graphs#spatial-audio)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8008d-121">To learn more about spatial audio and how XAML handles it see [AudioGraph - Spatial Audio](/windows/uwp/audio-video-camera/audio-graphs#spatial-audio).</span></span>

### <a name="sound-for-tv-and-xbox"></a><span data-ttu-id="8008d-122">テレビや Xbox のサウンド</span><span class="sxs-lookup"><span data-stu-id="8008d-122">Sound for TV and Xbox</span></span>

<span data-ttu-id="8008d-123">サウンドは 10 フィート エクスペリエンスの重要なパーツであるため、既定では、**ElementSoundPlayer** の状態は **Auto**、つまり、アプリが Xbox で実行されているときにのみサウンドが再生されます。</span><span class="sxs-lookup"><span data-stu-id="8008d-123">Sound is a key part of the 10-foot experience, and by default, the **ElementSoundPlayer**'s state is **Auto**, meaning that you will only get sound when your app is running on Xbox.</span></span>
<span data-ttu-id="8008d-124">Xbox やテレビ向けの設計について詳しくは、「[Xbox およびテレビ向け設計](http://go.microsoft.com/fwlink/?LinkId=760736)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8008d-124">To understand more about designing for Xbox and TV, please see [Designing for Xbox and TV](http://go.microsoft.com/fwlink/?LinkId=760736).</span></span>

## <a name="sound-volume-override"></a><span data-ttu-id="8008d-125">音量設定のオーバーライド</span><span class="sxs-lookup"><span data-stu-id="8008d-125">Sound Volume Override</span></span>

<span data-ttu-id="8008d-126">アプリ内のすべてのサウンドは、**Volume** コントロールで小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="8008d-126">All sounds within the app can be dimmed with the **Volume** control.</span></span> <span data-ttu-id="8008d-127">しかし、アプリ内のサウンドを*システムの音量より大きく*することができません。</span><span class="sxs-lookup"><span data-stu-id="8008d-127">However, sounds within the app cannot get *louder than the system volume*.</span></span>

<span data-ttu-id="8008d-128">アプリの音量レベルを設定するには、次のように呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8008d-128">To set the app volume level, call:</span></span>
```C#
ElementSoundPlayer.Volume = 0.5;
```
<span data-ttu-id="8008d-129">ここで、最大の音量はシステムの音量に相対的に1.0、最小は 0.0 (本質的にサイレント)です。</span><span class="sxs-lookup"><span data-stu-id="8008d-129">Where maximum volume (relative to system volume) is 1.0, and minimum is 0.0 (essentially silent).</span></span>

## <a name="control-level-state"></a><span data-ttu-id="8008d-130">コントロール レベルの状態</span><span class="sxs-lookup"><span data-stu-id="8008d-130">Control Level State</span></span>

<span data-ttu-id="8008d-131">コントロールの既定のサウンドが望ましくない場合は、これを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="8008d-131">If a control's default sound is not desired, it can be disabled.</span></span> <span data-ttu-id="8008d-132">サウンドを無効にするには、コントロールで **ElementSoundMode** を使います。</span><span class="sxs-lookup"><span data-stu-id="8008d-132">This is done through the **ElementSoundMode** on the control.</span></span>

<span data-ttu-id="8008d-133">**ElementSoundMode** には、**Off** と **Default** の 2 つの状態があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-133">The **ElementSoundMode** has two states: **Off** and **Default**.</span></span> <span data-ttu-id="8008d-134">設定しないと、**Default** になります。</span><span class="sxs-lookup"><span data-stu-id="8008d-134">When not set, it is **Default**.</span></span> <span data-ttu-id="8008d-135">**Off** に設定すると、コントロールが再生するすべてのサウンドはミュートされます (*フォーカスを除く*)。</span><span class="sxs-lookup"><span data-stu-id="8008d-135">If set to **Off**, every sound that control plays will be muted *except for focus*.</span></span>

```XAML
<Button Name="ButtonName" Content="More Info" ElementSoundMode="Off"/>
```

```C#
ButtonName.ElementSoundState = ElementSoundMode.Off;
```

## <a name="is-this-the-right-sound"></a><span data-ttu-id="8008d-136">適切なサウンドの選択</span><span class="sxs-lookup"><span data-stu-id="8008d-136">Is This The Right Sound?</span></span>

<span data-ttu-id="8008d-137">カスタム コントロールを作成したり、既にあるコントロールのサウンドを変更したりするときには、システムが提供するすべてのサウンドの使用法を理解することが重要です。</span><span class="sxs-lookup"><span data-stu-id="8008d-137">When creating a custom control, or changing an existing control's sound, it is important to understand the usages of all the sounds the system provides.</span></span>

<span data-ttu-id="8008d-138">各サウンドは特定の基本的なユーザー操作に関連付けられています。すべての対話式操作で再生するサウンドをカスタマイズできますが、このセクションでは、すべての UWP アプリで一貫したエクスペリエンスを維持するためにサウンドを使う必要がある、というシナリオを説明します。</span><span class="sxs-lookup"><span data-stu-id="8008d-138">Each sound relates to a certain basic user interaction, and although sounds can be customized to play on any interaction, this section serves to illustrate the scenarios where sounds should be used to maintain a consistent experience across all UWP apps.</span></span>

### <a name="invoking-an-element"></a><span data-ttu-id="8008d-139">要素の呼び出し</span><span class="sxs-lookup"><span data-stu-id="8008d-139">Invoking an Element</span></span>

<span data-ttu-id="8008d-140">現在のシステムで最も一般的な、コントロールにトリガーされるサウンドは、**Invoke** サウンドです。</span><span class="sxs-lookup"><span data-stu-id="8008d-140">The most common control-triggered sound in our system today is the **Invoke** sound.</span></span> <span data-ttu-id="8008d-141">このサウンドは、ユーザーがタップ、クリック、入力、スペース、または、ゲームパッドの [A] ボタンを押すことでコントロールを呼び出したときに、再生されます。</span><span class="sxs-lookup"><span data-stu-id="8008d-141">This sound plays when a user invokes a control through a tap/click/enter/space or press of the 'A' button on a gamepad.</span></span>

<span data-ttu-id="8008d-142">通常このサウンドは、ユーザーが[入力デバイス](../input/index.md)を介して明示的に単純なコントロールまたはコントロールの一部を対象としたときにのみ再生されます。</span><span class="sxs-lookup"><span data-stu-id="8008d-142">Typically, this sound is only played when a user explicitly targets a simple control or control part through an [input device](../input/index.md).</span></span>

<span data-ttu-id="8008d-143"><SelectButtonClick.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-143"><SelectButtonClick.mp3 sound clip here></span></span>

<span data-ttu-id="8008d-144">任意のコントロール イベントからこのサウンドを再生するには、シンプルに **ElementSoundPlayer** から Play メソッドを呼び出し、**ElementSound.Invoke** に渡します。</span><span class="sxs-lookup"><span data-stu-id="8008d-144">To play this sound from any control event, simply call the Play method from **ElementSoundPlayer** and pass in **ElementSound.Invoke**:</span></span>
```C#
ElementSoundPlayer.Play(ElementSoundKind.Invoke);
```

### <a name="showing--hiding-content"></a><span data-ttu-id="8008d-145">コンテンツの表示と非表示</span><span class="sxs-lookup"><span data-stu-id="8008d-145">Showing & Hiding Content</span></span>

<span data-ttu-id="8008d-146">XAML には多くのポップアップやダイアログ、閉じることができる UI があり、これらのオーバーレイのいずれかをトリガーするすべての操作で **Show** または **Hide** サウンドを呼び出す必要があります、</span><span class="sxs-lookup"><span data-stu-id="8008d-146">There are many flyouts, dialogs and dismissible UIs in XAML, and any action that triggers one of these overlays should call a **Show** or **Hide** sound.</span></span>

<span data-ttu-id="8008d-147">オーバーレイのコンテンツ ウィンドウをビューに読み込むときに、**Show** サウンドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-147">When an overlay content window is brought into view, the **Show** sound should be called:</span></span>

<span data-ttu-id="8008d-148"><OverlayIn.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-148"><OverlayIn.mp3 sound clip here></span></span>

```C#
ElementSoundPlayer.Play(ElementSoundKind.Show);
```
<span data-ttu-id="8008d-149">逆に、オーバーレイのコンテンツ ウィンドウを閉じる (または簡易非表示にする) ときに、**Hide** サウンドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-149">Conversely when an overlay content window is closed (or is light dismissed), the **Hide** sound should be called:</span></span>

<span data-ttu-id="8008d-150"><OverlayOut.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-150"><OverlayOut.mp3 sound clip here></span></span>

```C#
ElementSoundPlayer.Play(ElementSoundKind.Hide);
```
### <a name="navigation-within-a-page"></a><span data-ttu-id="8008d-151">ページ内でのナビゲーション</span><span class="sxs-lookup"><span data-stu-id="8008d-151">Navigation Within a Page</span></span>

<span data-ttu-id="8008d-152">アプリのページ内でパネルまたはビューの間をナビゲーションする場合 (「[ハブ](../controls-and-patterns/hub.md)」または「[タブとピボット](../controls-and-patterns/tabs-pivot.md)」をご覧ください)、通常は、移動の方向は双方向です。</span><span class="sxs-lookup"><span data-stu-id="8008d-152">When navigating between panels or views within an app's page (see [Hub](../controls-and-patterns/hub.md) or [Tabs and Pivots](../controls-and-patterns/tabs-pivot.md)), there is typically bidirectional movement.</span></span> <span data-ttu-id="8008d-153">つまり、現在表示しているアプリのページを離れずに、次のビュー/パネルまたは前のビュー/パネルに移動できます。</span><span class="sxs-lookup"><span data-stu-id="8008d-153">Meaning you can move to the next view/panel or the previous one, without leaving the current app page you're on.</span></span>

<span data-ttu-id="8008d-154">このナビゲーションの概念に関するオーディオ エクスペリエンスは、**MovePrevious** サウンドと **MoveNext** サウンドに包含されています。</span><span class="sxs-lookup"><span data-stu-id="8008d-154">The audio experience around this navigation concept is encompassed by the **MovePrevious** and **MoveNext** sounds.</span></span>

<span data-ttu-id="8008d-155">リストの*次の項目*と考えられるビュー/パネルに移動するときは、次のように呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8008d-155">When moving to a view/panel that is considered the *next item* in a list, call:</span></span>

<span data-ttu-id="8008d-156"><PageTransitionRight.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-156"><PageTransitionRight.mp3 sound clip here></span></span>

```C#
ElementSoundPlayer.Play(ElementSoundKind.MoveNext);
```
<span data-ttu-id="8008d-157">リストの*前の項目*と考えられるビュー/パネルに移動するときは、次のように呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8008d-157">And when moving to a previous view/panel in a list considered the *previous item*, call:</span></span>

<span data-ttu-id="8008d-158"><PageTransitionLeft.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-158"><PageTransitionLeft.mp3 sound clip here></span></span>

```C#
ElementSoundPlayer.Play(ElementSoundKind.MovePrevious);
```
### <a name="back-navigation"></a><span data-ttu-id="8008d-159">戻るナビゲーション</span><span class="sxs-lookup"><span data-stu-id="8008d-159">Back Navigation</span></span>

<span data-ttu-id="8008d-160">アプリ内で現在のページから前のページにナビゲーションするときは、**GoBack** サウンドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-160">When navigating from the current page to the previous page within an app the **GoBack** sound should be called:</span></span>

<span data-ttu-id="8008d-161"><BackButtonClick.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-161"><BackButtonClick.mp3 sound clip here></span></span>

```C#
ElementSoundPlayer.Play(ElementSoundKind.GoBack);
```
### <a name="focusing-on-an-element"></a><span data-ttu-id="8008d-162">要素へのフォーカス</span><span class="sxs-lookup"><span data-stu-id="8008d-162">Focusing on an Element</span></span>

<span data-ttu-id="8008d-163">マイクロソフトのシステムの **Focus** サウンドは、唯一の暗黙的なサウンドです。</span><span class="sxs-lookup"><span data-stu-id="8008d-163">The **Focus** sound is the only implicit sound in our system.</span></span> <span data-ttu-id="8008d-164">つまり、ユーザーは、何かを直接操作していなくてもサウンドが聞こえます。</span><span class="sxs-lookup"><span data-stu-id="8008d-164">Meaning a user isn't directly interacting with anything, but is still hearing a sound.</span></span>

<span data-ttu-id="8008d-165">フォーカスは、ユーザーがアプリをナビゲーションしたときに、ゲームパッド、キーボード、リモート、キネクトのいずれかで起こります。</span><span class="sxs-lookup"><span data-stu-id="8008d-165">Focusing happens when a user navigates through an app, this can be with the gamepad/keyboard/remote or kinect.</span></span> <span data-ttu-id="8008d-166">通常、**Focus** サウンドは、*PointerEntered またはマウス ホバー イベント時には再生されません*。</span><span class="sxs-lookup"><span data-stu-id="8008d-166">Typically the **Focus** sound *does not play on PointerEntered or mouse hover events*.</span></span>

<span data-ttu-id="8008d-167">コントロールがフォーカスされたときに **Focus** サウンドを再生するように設定するには、次のように呼び出します。</span><span class="sxs-lookup"><span data-stu-id="8008d-167">To set up a control to play the **Focus** sound when your control receives focus, call:</span></span>

<span data-ttu-id="8008d-168"><ElementFocus1.mp3 サウンド クリップ></span><span class="sxs-lookup"><span data-stu-id="8008d-168"><ElementFocus1.mp3 sound clip here></span></span>

```C#
ElementSoundPlayer.Play(ElementSoundKind.Focus);
```
### <a name="cycling-focus-sounds"></a><span data-ttu-id="8008d-169">フォーカス サウンドの循環</span><span class="sxs-lookup"><span data-stu-id="8008d-169">Cycling Focus Sounds</span></span>

<span data-ttu-id="8008d-170">**ElementSound.Focus** 呼び出しの追加機能として、サウンド システムは、既定で、ナビゲーション トリガーごとに 4 つの異なるサウンドを循環させます。</span><span class="sxs-lookup"><span data-stu-id="8008d-170">As an added feature to calling **ElementSound.Focus**, the sound system will, by default, cycle through 4 different sounds on each navigation trigger.</span></span> <span data-ttu-id="8008d-171">つまり、2 つの同じフォーカス サウンドが前後して再生されることはありません。</span><span class="sxs-lookup"><span data-stu-id="8008d-171">Meaning that no two exact focus sounds will play right after the other.</span></span>

<span data-ttu-id="8008d-172">この循環機能の目的は、フォーカス サウンドが単調になることを防ぎ、ユーザーの注意をひかない状態を保つことです。フォーカス サウンドは、最もよく再生されるため、最も繊細なサウンドにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8008d-172">The purpose behind this cycling feature is to keep the focus sounds from becoming monotonous and from being noticeable by the user; focus sounds will be played most often and therefore should be the most subtle.</span></span>

## <a name="related-articles"></a><span data-ttu-id="8008d-173">関連記事</span><span class="sxs-lookup"><span data-stu-id="8008d-173">Related articles</span></span>

* [<span data-ttu-id="8008d-174">Xbox およびテレビ向け設計</span><span class="sxs-lookup"><span data-stu-id="8008d-174">Designing for Xbox and TV</span></span>](http://go.microsoft.com/fwlink/?LinkId=760736)
* [<span data-ttu-id="8008d-175">ElementSoundPlayer クラスのドキュメント</span><span class="sxs-lookup"><span data-stu-id="8008d-175">ElementSoundPlayer class documentation</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.elementsoundplayer)
