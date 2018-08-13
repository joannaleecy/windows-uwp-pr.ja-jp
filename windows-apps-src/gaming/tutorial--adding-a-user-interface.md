---
author: mtoepke
title: ユーザー インターフェイスの追加
description: これまでは、サンプル ゲームでメイン ゲーム オブジェクトと基本的なレンダリング フレームワークを実装する方法について確認してきました。
ms.assetid: fa40173e-6cde-b71b-e307-db90f0388485
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, ユーザー インターフェイス, DirectX
ms.openlocfilehash: cb8cb8eae3328a9010553b7f3e041b8f2dbd8c02
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.locfileid: "246850"
---
# <a name="add-a-user-interface"></a><span data-ttu-id="34c79-104">ユーザー インターフェイスの追加</span><span class="sxs-lookup"><span data-stu-id="34c79-104">Add a user interface</span></span>


<span data-ttu-id="34c79-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="34c79-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="34c79-106">Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]</span><span class="sxs-lookup"><span data-stu-id="34c79-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>

<span data-ttu-id="34c79-107">これまでは、サンプル ゲームでメイン ゲーム オブジェクトと基本的なレンダリング フレームワークを実装する方法について確認してきました。</span><span class="sxs-lookup"><span data-stu-id="34c79-107">You've seen how the sample game implements the main game object as well as the basic rendering framework.</span></span> <span data-ttu-id="34c79-108">次は、サンプル ゲームでゲームの状態に関するフィードバックをプレイヤーに提供する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="34c79-108">Now, let's look at how the sample game provides feedback about game state to the player.</span></span> <span data-ttu-id="34c79-109">ここでは、単純なメニュー オプションとヘッドアップ ディスプレイ コンポーネントを、3-D グラフィックス パイプラインの出力の上に追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="34c79-109">Here, you learn how you can add simple menu options and heads-up display components on top of the 3-D graphics pipeline output.</span></span>

## <a name="objective"></a><span data-ttu-id="34c79-110">目標</span><span class="sxs-lookup"><span data-stu-id="34c79-110">Objective</span></span>


-   <span data-ttu-id="34c79-111">ユーザー インターフェイスの基本的なグラフィックスと動作をユニバーサル Windows プラットフォーム (UWP) DirectX ゲームに追加する。</span><span class="sxs-lookup"><span data-stu-id="34c79-111">To add basic user interface graphics and behaviors to a Universal Windows Platform (UWP) DirectX game.</span></span>

## <a name="the-user-interface-overlay"></a><span data-ttu-id="34c79-112">ユーザー インターフェイスのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="34c79-112">The user interface overlay</span></span>


<span data-ttu-id="34c79-113">テキスト要素とユーザー インターフェイス要素を DirectX ゲームで表示するにはさまざまな方法がありますが、ここでは、[Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx) (テキスト要素の場合は [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038)) という 1 つの方法を中心に説明します。</span><span class="sxs-lookup"><span data-stu-id="34c79-113">While there are many ways to display text and user interface elements in a DirectX game, we are going to focus on one, [Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx) (with [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) for the text elements).</span></span>

<span data-ttu-id="34c79-114">まず、Direct2D に当てはまらないものを明らかにしてみましょう。</span><span class="sxs-lookup"><span data-stu-id="34c79-114">First, let's be clear about what Direct2D is not.</span></span> <span data-ttu-id="34c79-115">これは、HTML や XAML のようにユーザー インターフェイスやレイアウト向けに特別に設計されたものではありません。</span><span class="sxs-lookup"><span data-stu-id="34c79-115">It's not specifically designed for user interfaces or layouts, like HTML or XAML.</span></span> <span data-ttu-id="34c79-116">また、リスト ボックスやボタンなどのユーザー インターフェイス コンポーネントは提供せず、div、テーブル、グリッドなどのレイアウト コンポーネントも提供しません。</span><span class="sxs-lookup"><span data-stu-id="34c79-116">It doesn't provide user interface components, like list boxes or buttons; and it doesn't provide layout components like divs, tables, or grids.</span></span>

<span data-ttu-id="34c79-117">Direct2D は、ピクセル ベースのプリミティブと効果の描画に使われる 2-D 描画 API セットです。</span><span class="sxs-lookup"><span data-stu-id="34c79-117">Direct2D is a set of 2-D drawing APIs used to draw pixel-based primitives and effects.</span></span> <span data-ttu-id="34c79-118">Direct2D を使って作業を始めるときは、シンプルな状態を保ってください。</span><span class="sxs-lookup"><span data-stu-id="34c79-118">When starting out with Direct2D, keep it simple.</span></span> <span data-ttu-id="34c79-119">複雑なレイアウトやインターフェイス動作には、時間と計画が必要です。</span><span class="sxs-lookup"><span data-stu-id="34c79-119">Complex layouts and interface behaviors need time and planning.</span></span> <span data-ttu-id="34c79-120">シミュレーション ゲームや戦略ゲームで使われているような複雑なユーザー インターフェイスがゲームで必要な場合は、代わりに XAML を使うことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="34c79-120">If your game requires a complex user interface to play, like those found in simulation and strategy games, consider XAML instead.</span></span>

<span data-ttu-id="34c79-121">(XAML を使って UWP DirectX ゲームのユーザー インターフェイスを開発する方法について詳しくは、「[ゲーム サンプルの紹介](tutorial-resources.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="34c79-121">(For info about developing a user interface with XAML in a UWP DirectX game, see [Extending the game sample](tutorial-resources.md).)</span></span>

<span data-ttu-id="34c79-122">このゲーム サンプルには、2 つの主要 UI コンポーネントがあります。スコアとゲーム内コントロールを表示するヘッドアップ ディスプレイと、ゲームの状態のテキストとオプション (一時停止情報やレベル開始オプションなど) を表示するために使うオーバーレイです。</span><span class="sxs-lookup"><span data-stu-id="34c79-122">In this game sample, we have two major UI components: the heads-up display for the score and in-game controls; and an overlay used to display game state text and options (such as pause info and level start options).</span></span>

### <a name="using-direct2d-for-a-heads-up-display"></a><span data-ttu-id="34c79-123">Direct2D を使ったヘッドアップ ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="34c79-123">Using Direct2D for a heads-up display</span></span>

<span data-ttu-id="34c79-124">これは、視覚効果のないゲーム サンプルのゲーム内ヘッドアップ ディスプレイです。</span><span class="sxs-lookup"><span data-stu-id="34c79-124">This is the in-game heads-up display for the game sample without the game visuals.</span></span> <span data-ttu-id="34c79-125">シンプルですっきりしているため、プレイヤーは 3-D の世界のナビゲートと標的を撃つことに集中できます。</span><span class="sxs-lookup"><span data-stu-id="34c79-125">It's simple and uncluttered, allowing the player to focus on navigating the 3-D world and shooting the targets.</span></span> <span data-ttu-id="34c79-126">優れたインターフェイスやヘッドアップ ディスプレイは、プレイヤーがいつでも簡単にゲーム内のイベントを処理したり、イベントに反応したりできるようにします。</span><span class="sxs-lookup"><span data-stu-id="34c79-126">A good interface or heads-up display must never obfuscate the ability of the player to process and react to the events in the game.</span></span>

![ゲーム オーバーレイのスクリーン ショット](images/sample3dgame-overlay-nogame.png)

<span data-ttu-id="34c79-128">ご覧のように、このオーバーレイは、十字線用の交差する 2 つの直線セグメントと、[ムーブ/ルック コントローラー](tutorial--adding-controls.md)用の 2 つの四角形という基本的なプリミティブで構成されています。</span><span class="sxs-lookup"><span data-stu-id="34c79-128">As you can see, the overlay consists of basic primitives: two intersecting line segments for the cross hairs, and two rectangles for the [move-look controller](tutorial--adding-controls.md).</span></span> <span data-ttu-id="34c79-129">右上隅には DirectWrite テキストがあり、現在の命中したヒット数、今までのショット数、レベルの残り時間、現在のレベルをプレイヤーに通知します。</span><span class="sxs-lookup"><span data-stu-id="34c79-129">In the upper-right corner, DirectWrite text informs the player of the current number of successful hits, the number of shots the player has made, the time remaining in the level, and the current level number.</span></span> <span data-ttu-id="34c79-130">オーバーレイのゲーム内ヘッドアップ ディプレイの状態は、**GameHud** クラスの **Render** メソッドで描画され、次のようにコード化されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-130">The in-game heads-up display state of the overlay is drawn in the **Render** method of the **GameHud** class, and is coded like this:</span></span>

```cpp
void GameHud::Render(
    _In_ Simple3DGame^ game,
    _In_ ID2D1DeviceContext* d2dContext,
    _In_ Windows::Foundation::Rect windowBounds
    )
{
    if (m_showTitle)
    {
        d2dContext->DrawBitmap(
            m_logoBitmap.Get(),
            D2D1::RectF(
                GameConstants::Margin,
                GameConstants::Margin,
                m_logoSize.width + GameConstants::Margin,
                m_logoSize.height + GameConstants::Margin
                )
            );
        d2dContext->DrawTextLayout(
            Point2F(m_logoSize.width + 2.0f * GameConstants::Margin, GameConstants::Margin),
            m_titleHeaderLayout.Get(),
            m_textBrush.Get()
            );
        d2dContext->DrawTextLayout(
            Point2F(GameConstants::Margin, m_titleBodyVerticalOffset),
            m_titleBodyLayout.Get(),
            m_textBrush.Get()
            );
    }

    if (game != nullptr)
    {
        // This section is only used after the game state has been initialized.
        static const int bufferLength = 256;
        static char16 wsbuffer[bufferLength];
        int length = swprintf_s(
            wsbuffer,
            bufferLength,
            L"Hits:\t%10d\nShots:\t%10d\nTime:\t%8.1f",
            game->TotalHits(),
            game->TotalShots(),
            game->TimeRemaining()
            );

        d2dContext->DrawText(
            wsbuffer,
            length,
            m_textFormatBody.Get(),
            D2D1::RectF(
                windowBounds.Width - GameConstants::HudRightOffset,
                GameConstants::HudTopOffset,
                windowBounds.Width,
                GameConstants::HudTopOffset + (GameConstants::HudBodyPointSize + GameConstants::Margin) * 3
                ),
            m_textBrush.Get()
            );

        // Using the unicode characters starting at 0x2780 ( ➀ ) for the consecutive levels of the game.
        // For completed levels, start with 0x278A ( ➊ ) (This is 0x2780 + 10).
        uint32 levelCharacter[6];
        for (uint32 i = 0; i < 6; i++)
        {
            levelCharacter[i] = 0x2780 + i + ((static_cast<uint32>(game->LevelCompleted()) == i) ? 10 : 0);
        }
        length = swprintf_s(
            wsbuffer,
            bufferLength,
            L"%lc %lc %lc %lc %lc %lc",
            levelCharacter[0],
            levelCharacter[1],
            levelCharacter[2],
            levelCharacter[3],
            levelCharacter[4],
            levelCharacter[5]
            );
        d2dContext->DrawText(
            wsbuffer,
            length,
            m_textFormatBodySymbol.Get(),
            D2D1::RectF(
                windowBounds.Width - GameConstants::HudRightOffset,
                GameConstants::HudTopOffset + (GameConstants::HudBodyPointSize + GameConstants::Margin) * 3 + GameConstants::Margin,
                windowBounds.Width,
                GameConstants::HudTopOffset + (GameConstants::HudBodyPointSize+ GameConstants::Margin) * 4
                ),
            m_textBrush.Get()
            );

        if (game->IsActivePlay())
        {
            // Draw a rectangle for the touch input for the move control.
            d2dContext->DrawRectangle(
                D2D1::RectF(
                    0.0f,
                    windowBounds.Height - GameConstants::TouchRectangleSize,
                    GameConstants::TouchRectangleSize,
                    windowBounds.Height
                    ),
                m_textBrush.Get()
                );
            // Draw a rectangle for the touch input for the fire control.
            d2dContext->DrawRectangle(
                D2D1::RectF(
                    windowBounds.Width - GameConstants::TouchRectangleSize,
                    windowBounds.Height - GameConstants::TouchRectangleSize,
                    windowBounds.Width,
                    windowBounds.Height
                    ),
                m_textBrush.Get()
                );

            // Draw the cross hairs.
            d2dContext->DrawLine(
                D2D1::Point2F(windowBounds.Width / 2.0f - GameConstants::CrossHairHalfSize, windowBounds.Height / 2.0f),
                D2D1::Point2F(windowBounds.Width / 2.0f + GameConstants::CrossHairHalfSize, windowBounds.Height / 2.0f),
                m_textBrush.Get(),
                3.0f
                );
            d2dContext->DrawLine(
                D2D1::Point2F(windowBounds.Width / 2.0f, windowBounds.Height / 2.0f - GameConstants::CrossHairHalfSize),
                D2D1::Point2F(windowBounds.Width / 2.0f, windowBounds.Height / 2.0f + GameConstants::CrossHairHalfSize),
                m_textBrush.Get(),
                3.0f
                );
        }
    }
}
```

<span data-ttu-id="34c79-131">このコードでは、オーバーレイに設定された Direct2D レンダー ターゲットが、ヒット数、残り時間、レベルの変化に応じて更新されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-131">In this code, the Direct2D render target established for the overlay is updated to reflect the changes in the number of hits, the time remaining, and the level number.</span></span> <span data-ttu-id="34c79-132">四角形は [**DrawRect**](https://msdn.microsoft.com/library/windows/desktop/dd371902) を呼び出すと描画され、十字線は [**DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895) をペアで呼び出すと描画されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-132">The rectangles are drawn with calls to [**DrawRect**](https://msdn.microsoft.com/library/windows/desktop/dd371902), and the cross hairs are drawn with a pair of calls to [**DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895).</span></span>

> <span data-ttu-id="34c79-133">**注**   **GameHud::Render** の呼び出しで、メイン ウィンドウの四角形のサイズを示す [**Windows::Foundation::Rect**](https://msdn.microsoft.com/library/windows/apps/br225994) パラメーターが指定されていることにお気付きでしょうか。</span><span class="sxs-lookup"><span data-stu-id="34c79-133">**Note**   You probably noticed the call to **GameHud::Render** takes a [**Windows::Foundation::Rect**](https://msdn.microsoft.com/library/windows/apps/br225994) parameter, which contains the size of the main window rectangle.</span></span> <span data-ttu-id="34c79-134">これは、UI プログラミングの重要な部分、つまり、DIP (デバイスに依存しないピクセル数、1/96 インチに定義) と呼ばれる単位でのウィンドウ サイズの取得を示しています。</span><span class="sxs-lookup"><span data-stu-id="34c79-134">This demonstrates an essential part of UI programming: obtaining the size of window in a measurement called DIPs (device independent pixels), where a DIP is defined as 1/96 of an inch.</span></span> <span data-ttu-id="34c79-135">Direct2D では、描画の発生時に描画単位を実際のピクセル数に拡大/縮小し、これには、Windows のドット/インチ (DPI) 設定を使います。</span><span class="sxs-lookup"><span data-stu-id="34c79-135">Direct2D scales the drawing units to actual pixels when the drawing occurs, and it does so by using the Windows dots per inch (DPI) setting.</span></span> <span data-ttu-id="34c79-136">同様に、DirectWrite を使ってテキストを描画するときは、フォントのサイズにポイント数ではなく DIP を指定します。</span><span class="sxs-lookup"><span data-stu-id="34c79-136">Similarly, when you draw text using DirectWrite, you specify DIPs rather than points for the size of the font.</span></span> <span data-ttu-id="34c79-137">DIP は、浮動小数点数として表されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-137">DIPs are expressed as floating point numbers.</span></span>

 

### <a name="displaying-game-state-information-with-an-overlay"></a><span data-ttu-id="34c79-138">オーバーレイによるゲームの状態情報の表示</span><span class="sxs-lookup"><span data-stu-id="34c79-138">Displaying game state information with an overlay</span></span>

<span data-ttu-id="34c79-139">ヘッドアップ ディスプレイのほかに、このゲーム サンプルには 5 つのゲームの状態を表すオーバーレイがあり、そのすべてで、大きな黒の四角形のプリミティブに、プレイヤーが読むテキストが表示されます </span><span class="sxs-lookup"><span data-stu-id="34c79-139">Besides the heads-up display, the game sample has an overlay that represents five game states, and all of which feature a large black rectangle primitive with text for the player to read.</span></span> <span data-ttu-id="34c79-140">(ムーブ/ルック コントローラーは、これらの状態ではアクティブではないため、その四角形は描画されません)。これらのオーバーレイの状態は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="34c79-140">(Be aware that the move-look controller rectangles are not drawn, because they are not active in these states.) These overlay states are:</span></span>

-   <span data-ttu-id="34c79-141">ゲーム開始オーバーレイ。</span><span class="sxs-lookup"><span data-stu-id="34c79-141">The game start overlay.</span></span> <span data-ttu-id="34c79-142">この状態は、プレイヤーがゲームを開始すると表示されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-142">We show this when the player starts the game.</span></span> <span data-ttu-id="34c79-143">ゲーム セッション全体のハイ スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="34c79-143">It contains the high score across game sessions.</span></span>

    ![simple3dgamedx の開始画面のスクリーン ショット](images/simple3dgamestart.png)

-   <span data-ttu-id="34c79-145">一時停止状態。</span><span class="sxs-lookup"><span data-stu-id="34c79-145">The pause state.</span></span>

    ![simple3dgamedx の一時停止画面のスクリーン ショット](images/simple3dgame-overlay-pause.png)

-   <span data-ttu-id="34c79-147">レベル開始状態。</span><span class="sxs-lookup"><span data-stu-id="34c79-147">The level start state.</span></span> <span data-ttu-id="34c79-148">この状態は、プレイヤーが新しいレベルを開始すると表示されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-148">We show this when the player starts a new level.</span></span>

    ![simple3dgamedx のレベル開始画面のスクリーン ショット](images/simple3dgame-overlay-newgame.png)

-   <span data-ttu-id="34c79-150">ゲーム オーバー状態。</span><span class="sxs-lookup"><span data-stu-id="34c79-150">The game over state.</span></span> <span data-ttu-id="34c79-151">この状態は、プレイヤーがレベルをクリアできないと表示されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-151">We show this when the player fails a level.</span></span>

    ![simple3dgamedx のゲーム オーバー画面のスクリーン ショット](images/simple3dgame-overlay-gameover.png)

-   <span data-ttu-id="34c79-153">ゲーム統計表示状態。</span><span class="sxs-lookup"><span data-stu-id="34c79-153">The game stat display state.</span></span> <span data-ttu-id="34c79-154">この状態は、プレイヤーがゲームをクリアすると表示されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-154">We show this when the player wins.</span></span> <span data-ttu-id="34c79-155">プレイヤーが獲得した最終スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="34c79-155">It contains the final score the player has achieved.</span></span>

    ![simple3dgamedx のクリア画面](images/simple3dgame-overlay-gamestats.png)

<span data-ttu-id="34c79-157">次は、これら 5 つの状態のオーバーレイを初期化して描画する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="34c79-157">Let's look at how we initialize and draw the overlay for these five states.</span></span>

### <a name="initializing-and-drawing-the-overlay"></a><span data-ttu-id="34c79-158">オーバーレイの初期化と描画</span><span class="sxs-lookup"><span data-stu-id="34c79-158">Initializing and drawing the overlay</span></span>

<span data-ttu-id="34c79-159">これら 5 つの明示的な状態には、共通点がいくつかあります。まず、画面の中央の黒の四角形を背景として使います。次に、表示されるテキストは、タイトル テキストまたは本文テキストです。そして、テキストは Segoe UI フォントであり、黒の四角形の上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-159">The five explicit states have some things in common: one, they all use a black rectangle in the center of the screen as their background; two, the displayed text is either title text or body text; and three, the text uses the Segoe UI font and is drawn on top of the back rectangle.</span></span> <span data-ttu-id="34c79-160">このため、必要とされるリソースと、それらを実装する方法は、よく似ています。</span><span class="sxs-lookup"><span data-stu-id="34c79-160">As a result, the resources they need and the methods that implement them are very similar.</span></span>

<span data-ttu-id="34c79-161">このゲーム サンプルには 4 つのメソッド (**GameInfoOverlay::Initialize**、**GameInfoOverlay::SetDpi**、**GameInfoOverlay::RecreateDirectXResources**、**GameInfoOverlay::RecreateDpiDependentResources**) があり、このオーバーレイの初期化、ドット/インチの設定、DirectWrite リソース (テキスト要素) の再作成、この表示するオーバーレイの構成にそれぞれ使われます。</span><span class="sxs-lookup"><span data-stu-id="34c79-161">The game sample has four methods( **GameInfoOverlay::Initialize**, **GameInfoOverlay::SetDpi**, **GameInfoOverlay::RecreateDirectXResources**, and **GameInfoOverlay::RecreateDpiDependentResources**) that it uses to initialize, set the dots per inch, recreate the DirectWrite resources (the text elements), and construct this overlay for display, respectively.</span></span> <span data-ttu-id="34c79-162">これら 4 つのメソッドのコードは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="34c79-162">This is the code for these four methods:</span></span>

```cpp
void GameInfoOverlay::Initialize(
    _In_ ID2D1Device*         d2dDevice,
    _In_ ID2D1DeviceContext*  d2dContext,
    _In_ IDWriteFactory*      dwriteFactory,
    _In_ float                dpi)
{
    m_initialized = true;

    m_dwriteFactory = dwriteFactory;
    m_dpi = dpi;
    m_d2dDevice = d2dDevice;
    m_d2dContext = d2dContext;

    ComPtr<ID2D1Factory> factory;
    d2dDevice->GetFactory(&factory);

    DX::ThrowIfFailed(
        factory.As(&m_d2dFactory)
        );

    RecreateDirectXResources();
}
```

```cpp
void GameInfoOverlay::SetDpi(float dpi)
{
    if (m_initialized)
    {
        if (dpi != m_dpi)
        {
            m_dpi = dpi;
            RecreateDpiDependentResources();
        }
    }
}
```

```cpp
void GameInfoOverlay::RecreateDirectXResources()
{
    if (!m_initialized)
    {
        return;
    }

    // Create D2D Resources.
    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI",
            nullptr,
            DWRITE_FONT_WEIGHT_MEDIUM,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            32,         // font size
            L"en-us",   // locale
            &m_textFormatTitle
            )
        );

    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI",
            nullptr,
            DWRITE_FONT_WEIGHT_LIGHT,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            24,         // font size
            L"en-us",   // locale
            &m_textFormatBody
            )
        );

    DX::ThrowIfFailed(
        m_textFormatTitle->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_CENTER)
        );
    DX::ThrowIfFailed(
        m_textFormatTitle->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );
    DX::ThrowIfFailed(
        m_textFormatBody->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING)
        );
    DX::ThrowIfFailed(
        m_textFormatBody->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );

    DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(D2D1::ColorF::White),
            &m_textBrush
            )
        );
    DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(D2D1::ColorF::Black),
            &m_backgroundBrush
            )
        );
     DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(0xdb7100, 1.0f),
            &m_actionBrush
            )
        );

     RecreateDpiDependentResources();
}
```

```cpp
void GameInfoOverlay::RecreateDpiDependentResources()
{
    m_levelBitmap = nullptr;

    // Create a D2D bitmap to be used for Game Info Overlay when waiting to
    // start a level or to display game statistics.
    D2D1_BITMAP_PROPERTIES1 properties;
    properties.pixelFormat.format = DXGI_FORMAT_B8G8R8A8_UNORM;
    properties.pixelFormat.alphaMode = D2D1_ALPHA_MODE_PREMULTIPLIED;
    properties.dpiX = m_dpi;
    properties.dpiY = m_dpi;
    properties.bitmapOptions = D2D1_BITMAP_OPTIONS_TARGET;
    properties.colorContext = nullptr;
    DX::ThrowIfFailed(
        m_d2dContext->CreateBitmap(
            D2D1::SizeU(
                static_cast<UINT32>(GameInfoOverlayConstant::Width * m_dpi / 96.0f),
                static_cast<UINT32>(GameInfoOverlayConstant::Height * m_dpi / 96.0f)
                ),
            nullptr,
            0,
            &properties,
            &m_levelBitmap
            )
        );
    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->Clear(D2D1::ColorF(D2D1::ColorF::Black));
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}

```

<span data-ttu-id="34c79-163">**Initialize** メソッドは、渡された [**ID2D1Device**](https://msdn.microsoft.com/library/windows/desktop/hh404478) オブジェクトからファクトリを取得し、これを使ってオーバーレイ オブジェクト自身が中に描画できる [**ID2D1DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/hh404479) を作り、提供された [**IDWriteFactory**](https://msdn.microsoft.com/library/windows/desktop/dd368183) 参照に **m\_dWriteFactory** フィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="34c79-163">The **Initialize** method obtains a factory from the [**ID2D1Device**](https://msdn.microsoft.com/library/windows/desktop/hh404478) object passed to it, which it uses to create an [**ID2D1DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/hh404479) that the overlay object itself can draw into, and sets the **m\_dWriteFactory** field to the provided [**IDWriteFactory**](https://msdn.microsoft.com/library/windows/desktop/dd368183) reference.</span></span> <span data-ttu-id="34c79-164">さらに、コンテキストの DPI も設定します。</span><span class="sxs-lookup"><span data-stu-id="34c79-164">It also sets the DPI for the context.</span></span> <span data-ttu-id="34c79-165">その後、**RecreateDeviceResources** を呼び出してオーバーレイの作成と描画を行います。</span><span class="sxs-lookup"><span data-stu-id="34c79-165">Then, it calls **RecreateDeviceResources** to assemble and draw the overlay.</span></span>

<span data-ttu-id="34c79-166">**RecreateDeviceResources** は、DirectWrite ファクトリ オブジェクトを使って、オーバーレイに表示されるタイトルと本文のテキスト文字列用のフォーマッタ (ブラシ) を作ります。</span><span class="sxs-lookup"><span data-stu-id="34c79-166">**RecreateDeviceResources** uses the DirectWrite factory object to create formatters (brushes) for the title and body text strings that will be displayed on the overlay.</span></span> <span data-ttu-id="34c79-167">テキストの描画用には白のブラシ、背景の描画用には黒のブラシ、操作メッセージの描画用にはオレンジ色のブラシを作ります。</span><span class="sxs-lookup"><span data-stu-id="34c79-167">It creates a white brush to draw the text, a black brush to draw the background, and an orange brush to draw action messages.</span></span> <span data-ttu-id="34c79-168">次に、**RecreateDpiDependentResources** を呼び出し、[**ID2D1DeviceContext::CreateBitmap**](https://msdn.microsoft.com/library/windows/desktop/hh404480) を呼び出してテキストを描画するビットマップを準備します。</span><span class="sxs-lookup"><span data-stu-id="34c79-168">Then, it calls **RecreateDpiDependentResources** to prepare a bitmap to draw the text on by calling [**ID2D1DeviceContext::CreateBitmap**](https://msdn.microsoft.com/library/windows/desktop/hh404480).</span></span> <span data-ttu-id="34c79-169">最後に、**RecreateDpiDependentResources** は、Direct2D デバイス コンテキストのレンダー ターゲットをこのビットマップに設定し、このコンテキストを消去してから、ビットマップの各ピクセルの色を黒に設定します。</span><span class="sxs-lookup"><span data-stu-id="34c79-169">Lastly, **RecreateDpiDependentResources** sets the render target for the Direct2D device context to the bitmap and clears it, which then sets each pixel in the bitmap to the color black.</span></span>

<span data-ttu-id="34c79-170">これで、オーバーレイに必要なのは、表示するテキストのみになりました。</span><span class="sxs-lookup"><span data-stu-id="34c79-170">Now, all the overlay needs is some text to display!</span></span>

### <a name="representing-game-state-in-the-overlay"></a><span data-ttu-id="34c79-171">オーバーレイでのゲームの状態の表示</span><span class="sxs-lookup"><span data-stu-id="34c79-171">Representing game state in the overlay</span></span>

<span data-ttu-id="34c79-172">このゲーム サンプルの 5 つのオーバーレイの状態には、それぞれに対応するメソッドが **GameInfoOverlay** オブジェクトにあります。</span><span class="sxs-lookup"><span data-stu-id="34c79-172">Each of the five overlay states in the game sample has a corresponding method on the **GameInfoOverlay** object.</span></span> <span data-ttu-id="34c79-173">これらのメソッドは、さまざまなオーバーレイを描画して、ゲーム自体に関する明示的な情報をプレイヤーに伝えます。</span><span class="sxs-lookup"><span data-stu-id="34c79-173">These methods draw a variation of the overlay to communicate explicit info to the player about the game itself.</span></span> <span data-ttu-id="34c79-174">この内容は、もちろん、タイトル文字列と本文文字列という 2 つの文字列で表示されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-174">This communication is, of course, represented as two strings: a title string, and a body string.</span></span> <span data-ttu-id="34c79-175">このサンプルでは既にこの情報用のリソースとレイアウトを **RecreateDeviceResources** メソッドに構成しているため、提供が必要なのは、オーバーレイの状態に固有の文字列のみです。</span><span class="sxs-lookup"><span data-stu-id="34c79-175">Because the sample already configured the resources and layout for this info in the **RecreateDeviceResources** method, it only needs to provide the overlay state-specific strings.</span></span>

<span data-ttu-id="34c79-176">ここで、このサンプルの **GameInfoOverlay** クラスの定義では、オーバーレイの各領域に対応する 3 つの四角形領域が次のとおり宣言されています。</span><span class="sxs-lookup"><span data-stu-id="34c79-176">Now, in the definition of the **GameInfoOverlay** class, the sample declared three rectangular areas that correspond to specific regions of the overlay, as shown here:</span></span>

```cpp
static const D2D1_RECT_F titleRectangle = D2D1::RectF(50.0f, 50.0f, GameInfoOverlayConstant::Width - 50.0f, 100.0f);
static const D2D1_RECT_F bodyRectangle = D2D1::RectF(50.0f, 110.0f, GameInfoOverlayConstant::Width - 50.0f, GameInfoOverlayConstant::Height - 50.0f);
static const D2D1_RECT_F actionRectangle = D2D1::RectF(50.0f, GameInfoOverlayConstant::Height - 45.0f, GameInfoOverlayConstant::Width - 50.0f, GameInfoOverlayConstant::Height - 5.0f);
```

<span data-ttu-id="34c79-177">各領域には、固有の目的があります。</span><span class="sxs-lookup"><span data-stu-id="34c79-177">These areas each have a specific purpose:</span></span>

-   <span data-ttu-id="34c79-178">**titleRectangle** は、タイトル テキストが描画される場所です。</span><span class="sxs-lookup"><span data-stu-id="34c79-178">**titleRectangle** is where the title text is drawn.</span></span>
-   <span data-ttu-id="34c79-179">**bodyRectangle** は、本文テキストが描画される場所です。</span><span class="sxs-lookup"><span data-stu-id="34c79-179">**bodyRectangle** is where the body text is drawn.</span></span>
-   <span data-ttu-id="34c79-180">**actionRectangle** は、プレイヤーに特定の操作を実行するように通知するテキストが描画される場所です </span><span class="sxs-lookup"><span data-stu-id="34c79-180">**actionRectangle** is where the text that informs the player to take a specific action is drawn.</span></span> <span data-ttu-id="34c79-181">(これはオーバーレイ ビットマップの左下にあります)。</span><span class="sxs-lookup"><span data-stu-id="34c79-181">(It's in the bottom left of the overlay bitmap.)</span></span>

<span data-ttu-id="34c79-182">これらの領域を念頭に置いて、状態に固有のメソッドの 1 つである **GameInfoOverlay::SetGameStats** と、オーバーレイの描画方法を確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="34c79-182">With these areas in mind, let's look at one of the state-specific methods, **GameInfoOverlay::SetGameStats**, and see how the overlay is drawn.</span></span>

```cpp
void GameInfoOverlay::SetGameStats(int maxLevel, int hitCount, int shotCount)
{
    int length;
    Platform::String^ string;

    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&titleRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&bodyRectangle, m_backgroundBrush.Get());
    string = "High Score";

    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatTitle.Get(),
        titleRectangle,
        m_textBrush.Get()
        );
    length = swprintf_s(
        wsbuffer,
        bufferLength,
        L"Levels Completed %d\nTotal Points %d\nTotal Shots %d",
        maxLevel,
        hitCount,
        shotCount
        );
    string = ref new Platform::String(wsbuffer, length);
    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatBody.Get(),
        bodyRectangle,
        m_textBrush.Get()
        );
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
```

<span data-ttu-id="34c79-183">このメソッドは、**GameInfoOverlay** オブジェクトが **Initialize** と **RecreateDirectXResources** を使って初期化と構成を行った Direct2D デバイス コンテキストと、背景ブラシを使って、タイトルと本文の四角形を黒で塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="34c79-183">Using the Direct2D device context that the **GameInfoOverlay** object initialized and configured using **Initialize** and **RecreateDirectXResources**, this method fills the title and body rectangles with black using the background brush.</span></span> <span data-ttu-id="34c79-184">また、白のテキスト ブラシを使って、"High Score" 文字列用のテキストをタイトルの四角形に描画し、ゲームの状態の最新情報が含まれている文字列を本文の四角形に描画します。</span><span class="sxs-lookup"><span data-stu-id="34c79-184">It draws the text for the "High Score" string to the title rectangle and a string containing the updates game state information to the body rectangle using the white text brush.</span></span>

<span data-ttu-id="34c79-185">操作の四角形は、**DirectXApp** オブジェクトのメソッドから **GameInfoOverlay::SetAction** を後で呼び出すと更新されます。このオブジェクトは、**SetAction** がプレイヤーに対する適切なメッセージ ("続行するにはタップしてください" など) を判断するために必要なゲームの状態情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="34c79-185">The action rectangle is updated by a subsequent call to **GameInfoOverlay::SetAction** from a method on the **DirectXApp** object, which provides the game state info needed by **SetAction** to determine the right message to the player (such as "Tap to continue").</span></span>

<span data-ttu-id="34c79-186">特定の状態用のオーバーレイは、**DirectXApp** の **SetGameInfoOverlay** メソッドで次のように選択されます。</span><span class="sxs-lookup"><span data-stu-id="34c79-186">The overlay for any given state is chosen in the **SetGameInfoOverlay** method on **DirectXApp**, like this:</span></span>

```cpp
void DirectXApp::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {
    case GameInfoOverlayState::Loading:
        m_renderer->InfoOverlay()->SetGameLoading(m_loadingCount);
        break;

    case GameInfoOverlayState::GameStats:
        m_renderer->InfoOverlay()->SetGameStats(
            m_game->HighScore().levelCompleted + 1,
            m_game->HighScore().totalHits,
            m_game->HighScore().totalShots
            );
        break;

    case GameInfoOverlayState::LevelStart:
        m_renderer->InfoOverlay()->SetLevelStart(
            m_game->LevelCompleted() + 1,
            m_game->CurrentLevel()->Objective(),
            m_game->CurrentLevel()->TimeLimit(),
            m_game->BonusTime()
            );
        break;

    case GameInfoOverlayState::GameOverCompleted:
        m_renderer->InfoOverlay()->SetGameOver(
            true,
            m_game->LevelCompleted() + 1,
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::GameOverExpired:
        m_renderer->InfoOverlay()->SetGameOver(
            false,
            m_game->LevelCompleted(),
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::Pause:
        m_renderer->InfoOverlay()->SetPause();
        break;
    }
}
```

<span data-ttu-id="34c79-187">これで、ゲーム サンプルでゲームの状態に基づいたテキスト情報をプレイヤーに表示できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="34c79-187">And now the game sample has a way to communicate text info to the player based on game state.</span></span>

### <a name="next-steps"></a><span data-ttu-id="34c79-188">次のステップ</span><span class="sxs-lookup"><span data-stu-id="34c79-188">Next steps</span></span>

<span data-ttu-id="34c79-189">次のトピックの「[コントロールの追加](tutorial--adding-controls.md)」では、プレイヤーがこのゲーム サンプルを操作する方法と、入力によってゲームの状態がどのように変わるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="34c79-189">In the next topic, [Adding controls](tutorial--adding-controls.md), we look at how the player interacts with the game sample, and how input changes game state.</span></span>

### <a name="complete-sample-code-for-this-section"></a><span data-ttu-id="34c79-190">このセクションのサンプル コード一式</span><span class="sxs-lookup"><span data-stu-id="34c79-190">Complete sample code for this section</span></span>

<span data-ttu-id="34c79-191">GameHud.h</span><span class="sxs-lookup"><span data-stu-id="34c79-191">GameHud.h</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include "Simple3DGame.h"
#include "DirectXSample.h"

ref class Simple3DGame;

ref class GameHud
{
internal:
    GameHud(
        _In_ Platform::String^ titleHeader,
        _In_ Platform::String^ titleBody
        );

    void CreateDeviceIndependentResources(
        _In_ IDWriteFactory* dwriteFactory,
        _In_ IWICImagingFactory* wicFactory
        );

    void CreateDeviceResources(_In_ ID2D1DeviceContext* d2dContext);
    void UpdateForWindowSizeChange(_In_ Windows::Foundation::Rect windowBounds);
    void Render(
        _In_ Simple3DGame^ game,
        _In_ ID2D1DeviceContext* d2dContext,
        _In_ Windows::Foundation::Rect windowBounds
        );

private:
    Microsoft::WRL::ComPtr<IDWriteFactory>              m_dwriteFactory;
    Microsoft::WRL::ComPtr<IWICImagingFactory>          m_wicFactory;

    Microsoft::WRL::ComPtr<ID2D1SolidColorBrush>        m_textBrush;
    Microsoft::WRL::ComPtr<IDWriteTextFormat>           m_textFormatBody;
    Microsoft::WRL::ComPtr<IDWriteTextFormat>           m_textFormatBodySymbol;

    Microsoft::WRL::ComPtr<IDWriteTextFormat>           m_textFormatTitleHeader;
    Microsoft::WRL::ComPtr<IDWriteTextFormat>           m_textFormatTitleBody;
    Microsoft::WRL::ComPtr<ID2D1Bitmap>                 m_logoBitmap;
    Microsoft::WRL::ComPtr<IDWriteTextLayout>           m_titleHeaderLayout;
    Microsoft::WRL::ComPtr<IDWriteTextLayout>           m_titleBodyLayout;

    bool                                                m_showTitle;
    Platform::String^                                   m_titleHeader;
    Platform::String^                                   m_titleBody;

    float                                               m_titleBodyVerticalOffset;
    D2D1_SIZE_F                                         m_logoSize;
    D2D1_SIZE_F                                         m_maxTitleSize;
};
```

<span data-ttu-id="34c79-192">GameHud.cpp</span><span class="sxs-lookup"><span data-stu-id="34c79-192">GameHud.cpp</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "GameHud.h"
#include "GameConstants.h"

using namespace Microsoft::WRL;
using namespace Windows::UI::Core;
using namespace Windows::ApplicationModel;
using namespace Windows::Foundation;
using namespace Windows::Storage;
using namespace Windows::UI::ViewManagement;
using namespace Windows::Graphics::Display;
using namespace D2D1;

//----------------------------------------------------------------------

GameHud::GameHud(
    _In_ Platform::String^ titleHeader,
    _In_ Platform::String^ titleBody
    )
{
    m_titleHeader = titleHeader;
    m_titleBody = titleBody;

    m_showTitle = true;
    m_titleBodyVerticalOffset = GameConstants::Margin;
    m_logoSize = D2D1::SizeF(0.0f, 0.0f);
}

//----------------------------------------------------------------------

void GameHud::CreateDeviceIndependentResources(
    _In_ IDWriteFactory* dwriteFactory,
    _In_ IWICImagingFactory* wicFactory
    )
{
    m_dwriteFactory = dwriteFactory;
    m_wicFactory = wicFactory;

    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI",
            nullptr,
            DWRITE_FONT_WEIGHT_LIGHT,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            GameConstants::HudBodyPointSize,
            L"en-us",
            &m_textFormatBody
            )
        );
    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI Symbol",
            nullptr,
            DWRITE_FONT_WEIGHT_LIGHT,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            GameConstants::HudBodyPointSize,
            L"en-us",
            &m_textFormatBodySymbol
            )
        );
    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI Light",
            nullptr,
            DWRITE_FONT_WEIGHT_LIGHT,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            GameConstants::HudTitleHeaderPointSize,
            L"en-us",
            &m_textFormatTitleHeader
            )
        );
    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI Light",
            nullptr,
            DWRITE_FONT_WEIGHT_LIGHT,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            GameConstants::HudTitleBodyPointSize,
            L"en-us",
            &m_textFormatTitleBody
            )
        );

    DX::ThrowIfFailed(m_textFormatBody->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING));
    DX::ThrowIfFailed(m_textFormatBody->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR));
    DX::ThrowIfFailed(m_textFormatBodySymbol->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING));
    DX::ThrowIfFailed(m_textFormatBodySymbol->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR));
    DX::ThrowIfFailed(m_textFormatTitleHeader->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING));
    DX::ThrowIfFailed(m_textFormatTitleHeader->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR));
    DX::ThrowIfFailed(m_textFormatTitleBody->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING));
    DX::ThrowIfFailed(m_textFormatTitleBody->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR));
}

//----------------------------------------------------------------------

void GameHud::CreateDeviceResources(_In_ ID2D1DeviceContext* d2dContext)
{
    auto location = Package::Current->InstalledLocation;
    Platform::String^ path = Platform::String::Concat(location->Path, "\\");
    path = Platform::String::Concat(path, "windows-sdk.png");

    ComPtr<IWICBitmapDecoder> wicBitmapDecoder;
    DX::ThrowIfFailed(
        m_wicFactory->CreateDecoderFromFilename(
            path->Data(),
            nullptr,
            GENERIC_READ,
            WICDecodeMetadataCacheOnDemand,
            &wicBitmapDecoder
            )
        );

    ComPtr<IWICBitmapFrameDecode> wicBitmapFrame;
    DX::ThrowIfFailed(
        wicBitmapDecoder->GetFrame(0, &wicBitmapFrame)
        );

    ComPtr<IWICFormatConverter> wicFormatConverter;
    DX::ThrowIfFailed(
        m_wicFactory->CreateFormatConverter(&wicFormatConverter)
        );

    DX::ThrowIfFailed(
        wicFormatConverter->Initialize(
            wicBitmapFrame.Get(),
            GUID_WICPixelFormat32bppPBGRA,
            WICBitmapDitherTypeNone,
            nullptr,
            0.0,
            WICBitmapPaletteTypeCustom  // The BGRA format has no palette, so this value is ignored.
            )
        );

    double dpiX = 96.0f;
    double dpiY = 96.0f;
    DX::ThrowIfFailed(
        wicFormatConverter->GetResolution(&dpiX, &dpiY)
        );

    // Create D2D Resources.
    DX::ThrowIfFailed(
        d2dContext->CreateBitmapFromWicBitmap(
            wicFormatConverter.Get(),
            BitmapProperties(
                PixelFormat(DXGI_FORMAT_B8G8R8A8_UNORM, D2D1_ALPHA_MODE_PREMULTIPLIED),
                static_cast<float>(dpiX),
                static_cast<float>(dpiY)
                ),
            &m_logoBitmap
            )
        );

    m_logoSize = m_logoBitmap->GetSize();

    DX::ThrowIfFailed(
        d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(D2D1::ColorF::White),
            &m_textBrush
            )
        );
}

//----------------------------------------------------------------------

void GameHud::UpdateForWindowSizeChange(_In_ Windows::Foundation::Rect windowBounds)
{
    m_maxTitleSize.width = windowBounds.Width - GameConstants::HudSafeWidth;
    m_maxTitleSize.height = windowBounds.Height;

    float headerWidth = m_maxTitleSize.width - (m_logoSize.width + 2 * GameConstants::Margin);

    if (headerWidth > 0)
    {
        // Only resize the text layout for the Title area when there is enough space.
        m_showTitle = true;

        DX::ThrowIfFailed(
            m_dwriteFactory->CreateTextLayout(
                m_titleHeader->Data(),
                m_titleHeader->Length(),
                m_textFormatTitleHeader.Get(),
                headerWidth,
                m_maxTitleSize.height,
                &m_titleHeaderLayout
                )
            );

        DWRITE_TEXT_METRICS metrics = {0};
        DX::ThrowIfFailed(
            m_titleHeaderLayout->GetMetrics(&metrics)
            );

        // Compute the vertical size of the laid out header and logo.  This could change
        // based on the window size and the layout of the text.  In some cases, the text
        // may wrap.
        m_titleBodyVerticalOffset = max(m_logoSize.height + GameConstants::Margin * 2, metrics.height + 2 * GameConstants::Margin);

        DX::ThrowIfFailed(
            m_dwriteFactory->CreateTextLayout(
                m_titleBody->Data(),
                m_titleBody->Length(),
                m_textFormatTitleBody.Get(),
                m_maxTitleSize.width,
                m_maxTitleSize.height - m_titleBodyVerticalOffset,
                &m_titleBodyLayout
                )
            );
    }
    else
    {
        // Not enough horizontal space for the titles, so just turn it off.
        m_showTitle = false;
    }
}

//----------------------------------------------------------------------

void GameHud::Render(
    _In_ Simple3DGame^ game,
    _In_ ID2D1DeviceContext* d2dContext,
    _In_ Windows::Foundation::Rect windowBounds
    )
{
    if (m_showTitle)
    {
        d2dContext->DrawBitmap(
            m_logoBitmap.Get(),
            D2D1::RectF(
                GameConstants::Margin,
                GameConstants::Margin,
                m_logoSize.width + GameConstants::Margin,
                m_logoSize.height + GameConstants::Margin
                )
            );
        d2dContext->DrawTextLayout(
            Point2F(m_logoSize.width + 2.0f * GameConstants::Margin, GameConstants::Margin),
            m_titleHeaderLayout.Get(),
            m_textBrush.Get()
            );
        d2dContext->DrawTextLayout(
            Point2F(GameConstants::Margin, m_titleBodyVerticalOffset),
            m_titleBodyLayout.Get(),
            m_textBrush.Get()
            );
    }

    if (game != nullptr)
    {
        // This section is only used after the game state has been initialized.
        static const int bufferLength = 256;
        static char16 wsbuffer[bufferLength];
        int length = swprintf_s(
            wsbuffer,
            bufferLength,
            L"Hits:\t%10d\nShots:\t%10d\nTime:\t%8.1f",
            game->TotalHits(),
            game->TotalShots(),
            game->TimeRemaining()
            );

        d2dContext->DrawText(
            wsbuffer,
            length,
            m_textFormatBody.Get(),
            D2D1::RectF(
                windowBounds.Width - GameConstants::HudRightOffset,
                GameConstants::HudTopOffset,
                windowBounds.Width,
                GameConstants::HudTopOffset + (GameConstants::HudBodyPointSize + GameConstants::Margin) * 3
                ),
            m_textBrush.Get()
            );

        // Using the unicode characters starting at 0x2780 ( ➀ ) for the consecutive levels of the game.
        // For completed levels start with 0x278A ( ➊ ) (This is 0x2780 + 10).
        uint32 levelCharacter[6];
        for (uint32 i = 0; i < 6; i++)
        {
            levelCharacter[i] = 0x2780 + i + ((static_cast<uint32>(game->LevelCompleted()) == i) ? 10 : 0);
        }
        length = swprintf_s(
            wsbuffer,
            bufferLength,
            L"%lc %lc %lc %lc %lc %lc",
            levelCharacter[0],
            levelCharacter[1],
            levelCharacter[2],
            levelCharacter[3],
            levelCharacter[4],
            levelCharacter[5]
            );
        d2dContext->DrawText(
            wsbuffer,
            length,
            m_textFormatBodySymbol.Get(),
            D2D1::RectF(
                windowBounds.Width - GameConstants::HudRightOffset,
                GameConstants::HudTopOffset + (GameConstants::HudBodyPointSize + GameConstants::Margin) * 3 + GameConstants::Margin,
                windowBounds.Width,
                GameConstants::HudTopOffset + (GameConstants::HudBodyPointSize+ GameConstants::Margin) * 4
                ),
            m_textBrush.Get()
            );

        if (game->IsActivePlay())
        {
            // Draw a rectangle for the touch input for the move control.
            d2dContext->DrawRectangle(
                D2D1::RectF(
                    0.0f,
                    windowBounds.Height - GameConstants::TouchRectangleSize,
                    GameConstants::TouchRectangleSize,
                    windowBounds.Height
                    ),
                m_textBrush.Get()
                );
            // Draw a rectangle for the touch input for the fire control.
            d2dContext->DrawRectangle(
                D2D1::RectF(
                    windowBounds.Width - GameConstants::TouchRectangleSize,
                    windowBounds.Height - GameConstants::TouchRectangleSize,
                    windowBounds.Width,
                    windowBounds.Height
                    ),
                m_textBrush.Get()
                );

            // Draw the cross hairs.
            d2dContext->DrawLine(
                D2D1::Point2F(windowBounds.Width / 2.0f - GameConstants::CrossHairHalfSize, windowBounds.Height / 2.0f),
                D2D1::Point2F(windowBounds.Width / 2.0f + GameConstants::CrossHairHalfSize, windowBounds.Height / 2.0f),
                m_textBrush.Get(),
                3.0f
                );
            d2dContext->DrawLine(
                D2D1::Point2F(windowBounds.Width / 2.0f, windowBounds.Height / 2.0f - GameConstants::CrossHairHalfSize),
                D2D1::Point2F(windowBounds.Width / 2.0f, windowBounds.Height / 2.0f + GameConstants::CrossHairHalfSize),
                m_textBrush.Get(),
                3.0f
                );
        }
    }
}
```

<span data-ttu-id="34c79-193">GameInfoOverlay.h</span><span class="sxs-lookup"><span data-stu-id="34c79-193">GameInfoOverlay.h</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

namespace GameInfoOverlayConstant
{
    static const float Width    = 750.0f;
    static const float Height   = 380.0f;
};

enum class GameInfoOverlayCommand
{
    None,
    TapToContinue,
    PleaseWait,
    PlayAgain,
};

ref class GameInfoOverlay
{
internal:
    GameInfoOverlay();

    void Initialize(
        _In_ ID2D1Device*         d2dDevice,
        _In_ ID2D1DeviceContext*  d2dContext,
        _In_ IDWriteFactory*      dwriteFactory,
        _In_ float                dpi
        );

    void RecreateDirectXResources();
    void SetDpi(float dpi);

    void SetGameLoading(uint32 dots);
    void SetGameStats(int maxLevel, int hitCount, int shotCount);
    void SetGameOver(bool win, int maxLevel, int hitCount, int shotCount, int highScore);
    void SetLevelStart(int level, Platform::String^ objective, float timeLimit, float bonusTime);
    void SetPause();
    void SetAction(GameInfoOverlayCommand action);
    void HideGameInfoOverlay() { m_visible = false; };
    void ShowGameInfoOverlay() { m_visible = true; };
    bool Visible() { return m_visible; };
    ID2D1Bitmap1* Bitmap() { return m_levelBitmap.Get(); }

private:
    void RecreateDpiDependentResources();

    bool                                            m_initialized;
    float                                           m_dpi;
    bool                                            m_visible;

    Microsoft::WRL::ComPtr<ID2D1Factory1>           m_d2dFactory;
    Microsoft::WRL::ComPtr<ID2D1Device>             m_d2dDevice;
    Microsoft::WRL::ComPtr<ID2D1DeviceContext>      m_d2dContext;
    Microsoft::WRL::ComPtr<IDWriteFactory>          m_dwriteFactory;

    Microsoft::WRL::ComPtr<ID2D1Bitmap1>            m_levelBitmap;
    Microsoft::WRL::ComPtr<IDWriteTextFormat>       m_textFormatTitle;
    Microsoft::WRL::ComPtr<IDWriteTextFormat>       m_textFormatBody;
    Microsoft::WRL::ComPtr<ID2D1SolidColorBrush>    m_textBrush;
    Microsoft::WRL::ComPtr<ID2D1SolidColorBrush>    m_backgroundBrush;
    Microsoft::WRL::ComPtr<ID2D1SolidColorBrush>    m_actionBrush;
};
```

<span data-ttu-id="34c79-194">GameInfoOverlay.cpp</span><span class="sxs-lookup"><span data-stu-id="34c79-194">GameInfoOverlay.cpp</span></span>

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "GameInfoOverlay.h"
#include "DirectXSample.h"

using namespace Windows::UI::Core;
using namespace Windows::Foundation;
using namespace Microsoft::WRL;
using namespace Windows::UI::ViewManagement;
using namespace Windows::Graphics::Display;
using namespace D2D1;

static const D2D1_RECT_F titleRectangle = D2D1::RectF(50.0f, 50.0f, GameInfoOverlayConstant::Width - 50.0f, 100.0f);
static const D2D1_RECT_F bodyRectangle = D2D1::RectF(50.0f, 110.0f, GameInfoOverlayConstant::Width - 50.0f, GameInfoOverlayConstant::Height - 50.0f);
static const D2D1_RECT_F actionRectangle = D2D1::RectF(50.0f, GameInfoOverlayConstant::Height - 45.0f, GameInfoOverlayConstant::Width - 50.0f, GameInfoOverlayConstant::Height - 5.0f);
static const int bufferLength = 1000;
static char16 wsbuffer[bufferLength];

GameInfoOverlay::GameInfoOverlay():
    m_initialized(false),
    m_visible(false)
{
}
//----------------------------------------------------------------------
void GameInfoOverlay::Initialize(
    _In_ ID2D1Device*         d2dDevice,
    _In_ ID2D1DeviceContext*  d2dContext,
    _In_ IDWriteFactory*      dwriteFactory,
    _In_ float                dpi)
{
    m_initialized = true;

    m_dwriteFactory = dwriteFactory;
    m_dpi = dpi;
    m_d2dDevice = d2dDevice;
    m_d2dContext = d2dContext;

    ComPtr<ID2D1Factory> factory;
    d2dDevice->GetFactory(&factory);

    DX::ThrowIfFailed(
        factory.As(&m_d2dFactory)
        );

    RecreateDirectXResources();
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetDpi(float dpi)
{
    if (m_initialized)
    {
        if (dpi != m_dpi)
        {
            m_dpi = dpi;
            RecreateDpiDependentResources();
        }
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::RecreateDirectXResources()
{
    if (!m_initialized)
    {
        return;
    }

    // Create D2D resources.
    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI",
            nullptr,
            DWRITE_FONT_WEIGHT_MEDIUM,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            32,         // font size
            L"en-us",   // locale
            &m_textFormatTitle
            )
        );

    DX::ThrowIfFailed(
        m_dwriteFactory->CreateTextFormat(
            L"Segoe UI",
            nullptr,
            DWRITE_FONT_WEIGHT_LIGHT,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            24,         // font size
            L"en-us",   // locale
            &m_textFormatBody
            )
        );

    DX::ThrowIfFailed(
        m_textFormatTitle->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_CENTER)
        );
    DX::ThrowIfFailed(
        m_textFormatTitle->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );
    DX::ThrowIfFailed(
        m_textFormatBody->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_LEADING)
        );
    DX::ThrowIfFailed(
        m_textFormatBody->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_NEAR)
        );

    DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(D2D1::ColorF::White),
            &m_textBrush
            )
        );
    DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(D2D1::ColorF::Black),
            &m_backgroundBrush
            )
        );
     DX::ThrowIfFailed(
        m_d2dContext->CreateSolidColorBrush(
            D2D1::ColorF(0xdb7100, 1.0f),
            &m_actionBrush
            )
        );

     RecreateDpiDependentResources();
}
//----------------------------------------------------------------------
void GameInfoOverlay::RecreateDpiDependentResources()
{
    m_levelBitmap = nullptr;

    // Create a D2D bitmap to be used for Game Info Overlay when waiting to
    // start a level or when displaying game statistics.
    D2D1_BITMAP_PROPERTIES1 properties;
    properties.pixelFormat.format = DXGI_FORMAT_B8G8R8A8_UNORM;
    properties.pixelFormat.alphaMode = D2D1_ALPHA_MODE_PREMULTIPLIED;
    properties.dpiX = m_dpi;
    properties.dpiY = m_dpi;
    properties.bitmapOptions = D2D1_BITMAP_OPTIONS_TARGET;
    properties.colorContext = nullptr;
    DX::ThrowIfFailed(
        m_d2dContext->CreateBitmap(
            D2D1::SizeU(
                static_cast<UINT32>(GameInfoOverlayConstant::Width * m_dpi / 96.0f),
                static_cast<UINT32>(GameInfoOverlayConstant::Height * m_dpi / 96.0f)
                ),
            nullptr,
            0,
            &properties,
            &m_levelBitmap
            )
        );
    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->Clear(D2D1::ColorF(D2D1::ColorF::Black));
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetGameLoading(uint32 dots)
{
    int length;
    Platform::String^ string = "Loading Resources";

    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&titleRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&bodyRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&actionRectangle, m_backgroundBrush.Get());

    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatTitle.Get(),
        titleRectangle,
        m_textBrush.Get()
        );

    dots = dots % 10;
    for (length = 0; length < 25; length++)
    {
        wsbuffer[length] = L' ';
    }
    for (uint32 i = 0; i < dots; i++)
    {
        wsbuffer[length++] = 0x25CF;   // This is a Dot character in the font.
        wsbuffer[length++] = L' ';
        wsbuffer[length++] = L' ';
        wsbuffer[length++] = L' ';
    }

    m_d2dContext->DrawText(
        wsbuffer,
        length,
        m_textFormatBody.Get(),
        bodyRectangle,
        m_actionBrush.Get()
        );

    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetGameStats(int maxLevel, int hitCount, int shotCount)
{
    int length;
    Platform::String^ string;

    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&titleRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&bodyRectangle, m_backgroundBrush.Get());
    string = "High Score";

    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatTitle.Get(),
        titleRectangle,
        m_textBrush.Get()
        );
    length = swprintf_s(
        wsbuffer,
        bufferLength,
        L"Levels Completed %d\nTotal Points %d\nTotal Shots %d",
        maxLevel,
        hitCount,
        shotCount
        );
    string = ref new Platform::String(wsbuffer, length);
    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatBody.Get(),
        bodyRectangle,
        m_textBrush.Get()
        );
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetGameOver(bool win, int maxLevel, int hitCount, int shotCount, int highScore)
{
    int length;
    Platform::String^ string;


    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&titleRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&bodyRectangle, m_backgroundBrush.Get());
    if (win)
    {
        string = "You WON!";
    }
    else
    {
        string = "Game Over";
    }
    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatTitle.Get(),
        titleRectangle,
        m_textBrush.Get()
        );
    length = swprintf_s(
        wsbuffer,
        bufferLength,
        L"Levels Completed %d\nTotal Points %d\nTotal Shots %d\n\nHigh Score %d\n",
        maxLevel,
        hitCount,
        shotCount,
        highScore
        );
    m_d2dContext->DrawText(
        wsbuffer,
        length,
        m_textFormatBody.Get(),
        bodyRectangle,
        m_textBrush.Get()
        );
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetLevelStart(int level, Platform::String^ objective, float timeLimit, float bonusTime)
{
    int length;
    Platform::String^ string;

    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&titleRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&bodyRectangle, m_backgroundBrush.Get());
    length = swprintf_s(wsbuffer, bufferLength, L"Level %d", level);
    m_d2dContext->DrawText(
        wsbuffer,
        length,
        m_textFormatTitle.Get(),
        titleRectangle,
        m_textBrush.Get()
        );

    if (bonusTime > 0.0f)
    {
        length = swprintf_s(
            wsbuffer,
            bufferLength,
            L"Objective: %s\nTime  Limit: %6.1f sec\nBonus Time: %6.1f sec\n",
            objective->Data(),
            timeLimit,
            bonusTime
            );
    }
    else
    {
        length = swprintf_s(
            wsbuffer,
            bufferLength,
            L"Objective: %s\nTime  Limit: %6.1f sec\n",
            objective->Data(),
            timeLimit
            );
    }
    string = ref new Platform::String(wsbuffer, length);
    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatBody.Get(),
        bodyRectangle,
        m_textBrush.Get()
        );
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetPause()
{
    Platform::String^ string;

    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&titleRectangle, m_backgroundBrush.Get());
    m_d2dContext->FillRectangle(&bodyRectangle, m_backgroundBrush.Get());
    string = "Game Paused";

    m_d2dContext->DrawText(
        string->Data(),
        string->Length(),
        m_textFormatTitle.Get(),
        bodyRectangle,
        m_textBrush.Get()
        );
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
//----------------------------------------------------------------------
void GameInfoOverlay::SetAction(GameInfoOverlayCommand action)
{
    Platform::String^ string;

    m_d2dContext->SetTarget(m_levelBitmap.Get());
    m_d2dContext->BeginDraw();
    m_d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    m_d2dContext->FillRectangle(&actionRectangle, m_backgroundBrush.Get());

    switch (action)
    {
    case GameInfoOverlayCommand::PlayAgain:
        string = "Tap to play again ...";
        break;
    case GameInfoOverlayCommand::PleaseWait:
        string = "Level loading, please wait ...";
        break;
    case GameInfoOverlayCommand::TapToContinue:
        string = "Tap to continue ...";
        break;
    default:
        string = "";
        break;
    }
    if (action != GameInfoOverlayCommand::None)
    {
        m_d2dContext->DrawText(
            string->Data(),
            string->Length(),
            m_textFormatBody.Get(),
            actionRectangle,
            m_actionBrush.Get()
            );
    }
    HRESULT hr = m_d2dContext->EndDraw();
    if (hr != D2DERR_RECREATE_TARGET)
    {
        // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
        // D3D device.  All subsequent rendering will be ignored until the device is recreated.
        // This error will be propagated and the appropriate D3D error will be returned from the
        // swapchain->Present(...) call.   At that point, the sample will recreate the device
        // and all associated resources.  As a result, the D2DERR_RECREATE_TARGET doesn't
        // need to be handled here.
        DX::ThrowIfFailed(hr);
    }
}
```

## <a name="related-topics"></a><span data-ttu-id="34c79-195">関連トピック</span><span class="sxs-lookup"><span data-stu-id="34c79-195">Related topics</span></span>


[<span data-ttu-id="34c79-196">DirectX によるシンプルな UWP ゲームの作成</span><span class="sxs-lookup"><span data-stu-id="34c79-196">Create a simple UWP game with DirectX</span></span>](tutorial--create-your-first-metro-style-directx-game.md)

 

 




