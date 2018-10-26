---
author: abbycar
title: ユーザー インターフェイスの追加
description: DirectX UWP ゲームに、2 D のユーザー インターフェイス オーバーレイを追加する方法について説明します。
ms.assetid: fa40173e-6cde-b71b-e307-db90f0388485
ms.author: abigailc
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ユーザー インターフェイス, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 9962cc9043bd650390721715ca73b2e85a219c25
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5555351"
---
# <a name="add-a-user-interface"></a><span data-ttu-id="119bc-104">ユーザー インターフェイスの追加</span><span class="sxs-lookup"><span data-stu-id="119bc-104">Add a user interface</span></span>


<span data-ttu-id="119bc-105">これで、ゲームの 3D の視覚効果が備わっています、ゲームは、プレイヤーにゲームの状態に関するフィードバックを提供できるように一部の 2D 要素を追加することに注力を勧めします。</span><span class="sxs-lookup"><span data-stu-id="119bc-105">Now that our game has its 3D visuals in place, it's time to focus on adding some 2D elements so that the game can provide feedback about game state to the player.</span></span> <span data-ttu-id="119bc-106">これを単純なメニュー オプションを追加することで実現し、ヘッドアップ ディスプレイ コンポーネント上 3-D グラフィックス パイプラインの出力します。</span><span class="sxs-lookup"><span data-stu-id="119bc-106">This can be accomplished by adding simple menu options and heads-up display components on top of the 3-D graphics pipeline output.</span></span>

>[!Note]
><span data-ttu-id="119bc-107">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="119bc-107">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="119bc-108">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="119bc-108">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="119bc-109">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="119bc-109">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="119bc-110">目標</span><span class="sxs-lookup"><span data-stu-id="119bc-110">Objective</span></span>

<span data-ttu-id="119bc-111">Direct2D を使用して、UWP DirectX ゲームを含むにさまざまなユーザー インターフェイスのグラフィックスと動作を追加します。</span><span class="sxs-lookup"><span data-stu-id="119bc-111">Using Direct2D, add a number of user interface graphics and behaviors to our UWP DirectX game including:</span></span>
- <span data-ttu-id="119bc-112">[ムーブ/ルック コント ローラー](tutorial--adding-controls.md)の境界の四角形を含む、ヘッドアップ ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="119bc-112">Heads-up display, including [move-look controller](tutorial--adding-controls.md) boundry rectangles</span></span>
- <span data-ttu-id="119bc-113">ゲームの状態のメニュー</span><span class="sxs-lookup"><span data-stu-id="119bc-113">Game state menus</span></span>


## <a name="the-user-interface-overlay"></a><span data-ttu-id="119bc-114">ユーザー インターフェイスのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="119bc-114">The user interface overlay</span></span>


<span data-ttu-id="119bc-115">DirectX ゲームでテキストやユーザー インターフェイス要素を表示するさまざまな方法はありますを行いましょうフォーカス[Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx)を使ってにします。</span><span class="sxs-lookup"><span data-stu-id="119bc-115">While there are many ways to display text and user interface elements in a DirectX game, we're going to focus on using [Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx).</span></span> <span data-ttu-id="119bc-116">使用します[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038)をテキスト要素の場合。</span><span class="sxs-lookup"><span data-stu-id="119bc-116">We'll also be using [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) for the text elements.</span></span>


<span data-ttu-id="119bc-117">Direct2D では、ピクセル ベースのプリミティブと効果を描画する描画 2D の Api のセットが使用されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-117">Direct2D is a set of 2D drawing APIs used to draw pixel-based primitives and effects.</span></span> <span data-ttu-id="119bc-118">Direct2D で起動するときは、簡単にことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="119bc-118">When starting out with Direct2D, it's best to keep things simple.</span></span> <span data-ttu-id="119bc-119">複雑なレイアウトやインターフェイス動作には、時間と計画が必要です。</span><span class="sxs-lookup"><span data-stu-id="119bc-119">Complex layouts and interface behaviors need time and planning.</span></span> <span data-ttu-id="119bc-120">シミュレーション ゲームや戦略ゲーム、見などの複雑なユーザー インターフェイスがゲームに必要な場合は、代わりに XAML の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="119bc-120">If your game requires a complex user interface, like those found in simulation and strategy games, consider using XAML instead.</span></span>

> [!NOTE]
> <span data-ttu-id="119bc-121">XAML を使った UWP DirectX ゲームのユーザー インターフェイスの開発について詳しくは、[ゲーム サンプルの紹介](tutorial-resources.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="119bc-121">For info about developing a user interface with XAML in a UWP DirectX game, see [Extending the game sample](tutorial-resources.md).</span></span>

<span data-ttu-id="119bc-122">Direct2D は、ユーザー インターフェイスや HTML や XAML のようなレイアウトを具体的には設計されていません。</span><span class="sxs-lookup"><span data-stu-id="119bc-122">Direct2D isn't specifically designed for user interfaces or layouts like HTML and XAML.</span></span> <span data-ttu-id="119bc-123">リスト、ボックスやボタンなどのユーザー インターフェイス コンポーネントも提供しません。</span><span class="sxs-lookup"><span data-stu-id="119bc-123">It doesn't provide user interface components like lists, boxes, or buttons.</span></span> <span data-ttu-id="119bc-124">Div、テーブル、グリッドなどのレイアウト コンポーネントも提供しません。</span><span class="sxs-lookup"><span data-stu-id="119bc-124">It also doesn't provide layout components like divs, tables, or grids.</span></span>


<span data-ttu-id="119bc-125">このゲーム サンプルは、2 つの主要 UI コンポーネントがあります。</span><span class="sxs-lookup"><span data-stu-id="119bc-125">For this game sample we have two major UI components.</span></span>
1. <span data-ttu-id="119bc-126">スコアとゲーム内のコントロールのヘッドアップ ディスプレイ。</span><span class="sxs-lookup"><span data-stu-id="119bc-126">A heads-up display for the score and in-game controls.</span></span>
2. <span data-ttu-id="119bc-127">オーバーレイのゲームの状態のテキストと一時停止情報などのオプションを表示するために使用して、レベル開始オプションです。</span><span class="sxs-lookup"><span data-stu-id="119bc-127">An overlay used to display game state text and options such as pause info and level start options.</span></span>

### <a name="using-direct2d-for-a-heads-up-display"></a><span data-ttu-id="119bc-128">Direct2D を使ったヘッドアップ ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="119bc-128">Using Direct2D for a heads-up display</span></span>

<span data-ttu-id="119bc-129">次の図は、サンプルのゲーム内ヘッドアップ ディスプレイを示しています。</span><span class="sxs-lookup"><span data-stu-id="119bc-129">The following image shows the in-game heads-up display for the sample.</span></span> <span data-ttu-id="119bc-130">シンプルでっきり、3 D ワールドを移動して、ターゲットを撮影に集中するプレイヤーをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="119bc-130">It's simple and uncluttered, allowing the player to focus on navigating the 3D world and shooting targets.</span></span> <span data-ttu-id="119bc-131">優れたインターフェイスやヘッドアップ ディスプレイする必要があることはありませんが複雑になるを処理し、ゲームのイベントに応答するプレイヤーの機能です。</span><span class="sxs-lookup"><span data-stu-id="119bc-131">A good interface or heads-up display must never complicate the ability of the player to process and react to the events in the game.</span></span>

![ゲーム オーバーレイのスクリーン ショット](images/simple-dx-game-ui-overlay.png)

<span data-ttu-id="119bc-133">オーバーレイは、次の基本的なプリミティブで構成されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-133">The overlay consists of the following basic primitives.</span></span>
- <span data-ttu-id="119bc-134">[**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)の右上隅のプレイヤーに通知するテキスト</span><span class="sxs-lookup"><span data-stu-id="119bc-134">[**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038) text in the upper-right corner that informs the player of</span></span> 
    - <span data-ttu-id="119bc-135">成功した場合のヒット数</span><span class="sxs-lookup"><span data-stu-id="119bc-135">Successful hits</span></span>
    - <span data-ttu-id="119bc-136">プレイヤーが行わショットの数</span><span class="sxs-lookup"><span data-stu-id="119bc-136">Number of shots the player has made</span></span>
    - <span data-ttu-id="119bc-137">レベルの残り時間</span><span class="sxs-lookup"><span data-stu-id="119bc-137">Time remaining in the level</span></span>
    - <span data-ttu-id="119bc-138">現在のレベルの数</span><span class="sxs-lookup"><span data-stu-id="119bc-138">Current level number</span></span> 
- <span data-ttu-id="119bc-139">2 つの十字を形成するために使用する行セグメントと交差します。</span><span class="sxs-lookup"><span data-stu-id="119bc-139">Two intersecting line segments used to form a cross hair</span></span>
- <span data-ttu-id="119bc-140">[ムーブ/ルック コント ローラー](tutorial--adding-controls.md)の境界の下隅にある 2 つの四角形です。</span><span class="sxs-lookup"><span data-stu-id="119bc-140">Two rectangles at the bottom corners for the [move-look controller](tutorial--adding-controls.md) boundries.</span></span> 


<span data-ttu-id="119bc-141">オーバーレイのゲーム内ヘッドアップ ディプレイの状態が[**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L234-L358) [**GameHud**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.h)クラスのメソッドで描画されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-141">The in-game heads-up display state of the overlay is drawn in the [**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L234-L358) method of the [**GameHud**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.h) class.</span></span> <span data-ttu-id="119bc-142">以下のメソッド内で UI を表すに Direct2D オーバーレイは、時間の残り、およびレベルの数のヒット数の変更を反映するように更新されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-142">Within this method, the Direct2D overlay that represents our UI is updated to reflect the changes in the number of hits, time remaining, and level number.</span></span>

<span data-ttu-id="119bc-143">追加し、ゲームに初期化されているかどうかは`TotalHits()`、 `TotalShots()`、および`TimeRemaining()` [**swprintf_s**](https://docs.microsoft.com/cpp/c-runtime-library/reference/sprintf-s-sprintf-s-l-swprintf-s-swprintf-s-l)にバッファーし、印刷形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="119bc-143">If the game has been initialized, we add `TotalHits()`, `TotalShots()`, and `TimeRemaining()` to a [**swprintf_s**](https://docs.microsoft.com/cpp/c-runtime-library/reference/sprintf-s-sprintf-s-l-swprintf-s-swprintf-s-l) buffer and specify the print format.</span></span> <span data-ttu-id="119bc-144">[**DrawText**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd742848)方法を使用してを描画し、ことができます。</span><span class="sxs-lookup"><span data-stu-id="119bc-144">We can then draw it using the [**DrawText**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd742848) method.</span></span> <span data-ttu-id="119bc-145">行います同じ現在のレベルのインジケーターの空の番号など、➀ 未完了のレベルを表示して、特定のレベルが完了したことを表示する塗りつぶされた ➊ 番号描画します。</span><span class="sxs-lookup"><span data-stu-id="119bc-145">We do the same for the current level indicator, drawing empty numbers to show uncompleted levels like ➀, and filled numbers like ➊ to show that the specific level was completed.</span></span>


<span data-ttu-id="119bc-146">次のコード スニペットは、 **GameHud::Render**メソッドのプロセスについて説明します</span><span class="sxs-lookup"><span data-stu-id="119bc-146">The following code snippet walks through the **GameHud::Render** method's process for</span></span> 
- <span data-ttu-id="119bc-147">使用してビットマップを作成する[\* \* ID2D1RenderTarget::DrawBitmap \* \*](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371880)</span><span class="sxs-lookup"><span data-stu-id="119bc-147">Creating a Bitmap using [\*\*ID2D1RenderTarget::DrawBitmap \*\*](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371880)</span></span>
- <span data-ttu-id="119bc-148">UI 領域を[**D2D1::RectF**を使用して四角形に分割](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368184)</span><span class="sxs-lookup"><span data-stu-id="119bc-148">Sectioning off UI areas into rectangles using [**D2D1::RectF**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368184)</span></span>
- <span data-ttu-id="119bc-149">**DrawText**を使用してテキスト要素</span><span class="sxs-lookup"><span data-stu-id="119bc-149">Using **DrawText** to make text elements</span></span>

```cpp
void GameHud::Render(_In_ Simple3DGame^ game)
{
    auto d2dContext = m_deviceResources->GetD2DDeviceContext();
    auto windowBounds = m_deviceResources->GetLogicalSize();

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

    // Draw text for number of hits, total shots, and time remaining
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
        
        // Draw the upper right portion of the HUD displaying total hits, shots, and time remaining
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
        // Create a new rectangle and draw the current level info text inside
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
            // Draw the move and fire rectangles
            // Draw the crosshairs
        }
    }
}
```

<span data-ttu-id="119bc-150">メソッドを中断して、移動、さらに、この[**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L320-L358)メソッドの描画の下、ファイアの四角[**ID2D1RenderTarget::DrawRectangle**](https://msdn.microsoft.com/library/windows/desktop/dd371902)と[**ID2D1RenderTarget::DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895)への 2 つの呼び出しを使って十字線。</span><span class="sxs-lookup"><span data-stu-id="119bc-150">Breaking the method down further, this piece of the [**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L320-L358) method draws our move and fire rectangles with [**ID2D1RenderTarget::DrawRectangle**](https://msdn.microsoft.com/library/windows/desktop/dd371902), and crosshairs using two calls to [**ID2D1RenderTarget::DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895).</span></span>

```cpp
        // Check if game is playing
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
            // Draw a rectangle for the touch input of the fire control.
            d2dContext->DrawRectangle(
                D2D1::RectF(
                    windowBounds.Width - GameConstants::TouchRectangleSize,
                    windowBounds.Height - GameConstants::TouchRectangleSize,
                    windowBounds.Width,
                    windowBounds.Height
                    ),
                m_textBrush.Get()
                );

            // Draw two lines to form crosshairs
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
```

<span data-ttu-id="119bc-151">ゲームのウィンドウでの論理サイズを格納します**GameHud::Render**メソッドで、`windowBounds`変数です。</span><span class="sxs-lookup"><span data-stu-id="119bc-151">In the **GameHud::Render** method we store the logical size of the game window in the `windowBounds` variable.</span></span> <span data-ttu-id="119bc-152">これを使用して、 [`GetLogicalSize`](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.h#L41) **DeviceResources**クラスのメソッドです。</span><span class="sxs-lookup"><span data-stu-id="119bc-152">This uses the [`GetLogicalSize`](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.h#L41) method of the **DeviceResources** class.</span></span> 
```cpp
auto windowBounds = m_deviceResources->GetLogicalSize();
```

 <span data-ttu-id="119bc-153">ゲームのウィンドウのサイズの取得は、UI プログラミングに不可欠です。</span><span class="sxs-lookup"><span data-stu-id="119bc-153">Obtaining the size of the game window is essential for UI programming.</span></span> <span data-ttu-id="119bc-154">ウィンドウのサイズは、Dip (デバイスに依存しないピクセル)、1/96 インチとして、DIP が定義されていると呼ばれる単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="119bc-154">The size of the window is given in a measurement called DIPs (device independent pixels), where a DIP is defined as 1/96 of an inch.</span></span> <span data-ttu-id="119bc-155">Direct2D 拡大/縮小実際のピクセルに描画単位描画が発生すると、Windows のドット/インチ (DPI) 設定を使用してこれを行います。</span><span class="sxs-lookup"><span data-stu-id="119bc-155">Direct2D scales the drawing units to actual pixels when the drawing occurs, doing so by using the Windows dots per inch (DPI) setting.</span></span> <span data-ttu-id="119bc-156">同様に、 [**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)を使ってテキストを描画するときは、フォントのサイズにポイントではなく Dip を設定します。</span><span class="sxs-lookup"><span data-stu-id="119bc-156">Similarly, when you draw text using [**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038), you specify DIPs rather than points for the size of the font.</span></span> <span data-ttu-id="119bc-157">DIP は、浮動小数点数として表されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-157">DIPs are expressed as floating point numbers.</span></span>

 

### <a name="displaying-game-state-info"></a><span data-ttu-id="119bc-158">ゲームの状態情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="119bc-158">Displaying game state info</span></span>

<span data-ttu-id="119bc-159">ヘッドアップ ディスプレイ、ゲーム サンプルにはあり 6 つのゲームの状態を表すオーバーレイします。</span><span class="sxs-lookup"><span data-stu-id="119bc-159">Besides the heads-up display, the game sample has an overlay that represents six game states.</span></span> <span data-ttu-id="119bc-160">すべての状態には、プレイヤーが読むテキスト、大きな黒の四角形のプリミティブが機能します。</span><span class="sxs-lookup"><span data-stu-id="119bc-160">All states feature a large black rectangle primitive with text for the player to read.</span></span> <span data-ttu-id="119bc-161">アクティブでないこれらの状態であるために、ムーブ/ルック コント ローラーの四角形と十字線は描画されません。</span><span class="sxs-lookup"><span data-stu-id="119bc-161">The move-look controller rectangles and crosshairs are not drawn because they are not active in these states.</span></span>

<span data-ttu-id="119bc-162">ゲームの状態に合わせて自動的に表示するテキストを切り替えることが可能、 [**GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.h)クラスを使用してオーバーレイが作成されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-162">The overlay is created using the [**GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.h) class, allowing us to switch out what text is displayed to align with the state of the game.</span></span>

![状態とオーバーレイの動作を確認します。](images/simple-dx-game-ui-finaloverlay.png)

<span data-ttu-id="119bc-164">オーバーレイが 2 つのセクションに分割:**状態**と**動作を確認**します。</span><span class="sxs-lookup"><span data-stu-id="119bc-164">The overlay is broken up into two sections: **Status** and **Action**.</span></span> <span data-ttu-id="119bc-165">**状態**のセクションは、**タイトル**と**本文**の四角形にさらに分類されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-165">The **Status** secton is further broken down into **Title** and **Body** rectangles.</span></span> <span data-ttu-id="119bc-166">**操作**のセクションには、1 つの四角形にのみです。</span><span class="sxs-lookup"><span data-stu-id="119bc-166">The **Action** section only has one rectangle.</span></span> <span data-ttu-id="119bc-167">それぞれの四角形では、さまざまな目的があります。</span><span class="sxs-lookup"><span data-stu-id="119bc-167">Each rectangle has a different purpose.</span></span>

-   `titleRectangle` <span data-ttu-id="119bc-168">タイトルのテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="119bc-168">contains the title text.</span></span>
-   `bodyRectangle` <span data-ttu-id="119bc-169">本文のテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="119bc-169">contains the body text.</span></span>
-   `actionRectangle` <span data-ttu-id="119bc-170">特定の操作を実行するプレイヤーに通知するテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="119bc-170">contains the text that informs the player to take a specific action.</span></span>

<span data-ttu-id="119bc-171">ゲームは、6 つの状態を設定することができます。</span><span class="sxs-lookup"><span data-stu-id="119bc-171">The game has six states that can be set.</span></span> <span data-ttu-id="119bc-172">伝える、オーバーレイの**状態**の一部を使用して、ゲームの状態。</span><span class="sxs-lookup"><span data-stu-id="119bc-172">The state of the game conveyed using the **Status** portion of the overlay.</span></span> <span data-ttu-id="119bc-173">多くの次の状態に対応するメソッドを使用して**状態**の四角形が更新されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-173">The **Status** rectangles are updated using a number of methods corresponding with the following states.</span></span>

- <span data-ttu-id="119bc-174">読み込み中</span><span class="sxs-lookup"><span data-stu-id="119bc-174">Loading</span></span>
- <span data-ttu-id="119bc-175">最初の開始/ハイ スコアの統計</span><span class="sxs-lookup"><span data-stu-id="119bc-175">Initial start/high score stats</span></span>
- <span data-ttu-id="119bc-176">レベル開始</span><span class="sxs-lookup"><span data-stu-id="119bc-176">Level start</span></span>
- <span data-ttu-id="119bc-177">ゲームが一時停止</span><span class="sxs-lookup"><span data-stu-id="119bc-177">Game paused</span></span>
- <span data-ttu-id="119bc-178">ゲーム オーバー</span><span class="sxs-lookup"><span data-stu-id="119bc-178">Game over</span></span>
- <span data-ttu-id="119bc-179">ゲームの終了</span><span class="sxs-lookup"><span data-stu-id="119bc-179">Game won</span></span>


<span data-ttu-id="119bc-180">オーバーレイの**操作**部分を更新するには、次のいずれかに設定するアクションのテキストを許可する[**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564)メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="119bc-180">The **Action** portion of the overlay is updated using the [**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564) method, allowing the action text to be set to one of the following.</span></span>
- <span data-ttu-id="119bc-181">「タップして、もう一度プレイ.」</span><span class="sxs-lookup"><span data-stu-id="119bc-181">"Tap to play again..."</span></span>
- <span data-ttu-id="119bc-182">「レベルの読み込み, お待ちください.」</span><span class="sxs-lookup"><span data-stu-id="119bc-182">"Level loading, please wait ..."</span></span>
- <span data-ttu-id="119bc-183">「タップして続行.」</span><span class="sxs-lookup"><span data-stu-id="119bc-183">"Tap to continue ..."</span></span>
- <span data-ttu-id="119bc-184">なし</span><span class="sxs-lookup"><span data-stu-id="119bc-184">None</span></span>

> [!NOTE]
> <span data-ttu-id="119bc-185">どちらの方法が説明されている[ゲームの状態を表す](#representing-game-state)」で詳しくします。</span><span class="sxs-lookup"><span data-stu-id="119bc-185">Both of these methods will be discussed further in the [Representing game state](#representing-game-state) section.</span></span>

<span data-ttu-id="119bc-186">ゲームでは、**状態**および**操作**のセクションで、何が起こってに応じて、テキスト フィールドが調整されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-186">Depending on the what's going on in the game, the **Status** and **Action** section text fields are adjusted.</span></span>
<span data-ttu-id="119bc-187">初期化し、これら 6 つの状態のオーバーレイを描画する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="119bc-187">Let's look at how we initialize and draw the overlay for these six states.</span></span>

### <a name="initializing-and-drawing-the-overlay"></a><span data-ttu-id="119bc-188">オーバーレイの初期化と描画</span><span class="sxs-lookup"><span data-stu-id="119bc-188">Initializing and drawing the overlay</span></span>

<span data-ttu-id="119bc-189">**6 つの状態**を共通の点がいくつかある、リソースとメソッドを行う必要があるとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="119bc-189">The six **Status** states have a few things in common, making the resources and methods they need very similar.</span></span>
    - <span data-ttu-id="119bc-190">黒の四角形を背景として、画面の中央すべて使います。</span><span class="sxs-lookup"><span data-stu-id="119bc-190">They all use a black rectangle in the center of the screen as their background.</span></span>
    - <span data-ttu-id="119bc-191">表示されるテキストは、**タイトル**または**本体**のいずれかのテキストです。</span><span class="sxs-lookup"><span data-stu-id="119bc-191">The displayed text is either **Title** or **Body** text.</span></span>
    - <span data-ttu-id="119bc-192">テキストは Segoe UI フォントが使用され、黒の四角形の上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-192">The text uses the Segoe UI font and is drawn on top of the back rectangle.</span></span> 


<span data-ttu-id="119bc-193">このゲーム サンプルでは、オーバーレイを作成するときに効果を発揮する 4 つのメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="119bc-193">The game sample has four methods that come into play when creating the overlay.</span></span>
 

#### <a name="gameinfooverlaygameinfooverlay"></a><span data-ttu-id="119bc-194">GameInfoOverlay::GameInfoOverlay</span><span class="sxs-lookup"><span data-stu-id="119bc-194">GameInfoOverlay::GameInfoOverlay</span></span>
<span data-ttu-id="119bc-195">[**GameInfoOverlay::GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L30-L78)コンス トラクターにプレイヤーに情報を表示するにはこれを使ってビットマップ サーフェスを維持し、オーバーレイを初期化します。</span><span class="sxs-lookup"><span data-stu-id="119bc-195">The [**GameInfoOverlay::GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L30-L78) constructor initializes the overlay, maintaining the bitmap surface that we will use to display info to the player on.</span></span> <span data-ttu-id="119bc-196">コンス トラクターは、アプリに渡される、これを使ってオーバーレイ オブジェクト自身に描画することができます[**ID2D1DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/hh404479)を作成する[**ID2D1Device**](https://msdn.microsoft.com/library/windows/desktop/hh404478)オブジェクトからファクトリを取得します。</span><span class="sxs-lookup"><span data-stu-id="119bc-196">The constructor obtains a factory from the [**ID2D1Device**](https://msdn.microsoft.com/library/windows/desktop/hh404478) object passed to it, which it uses to create an [**ID2D1DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/hh404479) that the overlay object itself can draw to.</span></span> [<span data-ttu-id="119bc-197">IDWriteFactory::CreateTextFormat</span><span class="sxs-lookup"><span data-stu-id="119bc-197">IDWriteFactory::CreateTextFormat</span></span>](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368203) 


#### <a name="gameinfooverlaycreatedevicedependentresources"></a><span data-ttu-id="119bc-198">Gameinfooverlay::createdevicedependentresources</span><span class="sxs-lookup"><span data-stu-id="119bc-198">GameInfoOverlay::CreateDeviceDependentResources</span></span>
<span data-ttu-id="119bc-199">[**Gameinfooverlay::createdevicedependentresources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)は、テキストを描画するために使用するブラシを作成するための方法です。</span><span class="sxs-lookup"><span data-stu-id="119bc-199">[**GameInfoOverlay::CreateDeviceDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104) is our method for creating brushes that will be used to draw our text.</span></span> <span data-ttu-id="119bc-200">これを行うには、しますにより、作成する[**ID2D1DeviceContext2**](https://msdn.microsoft.com/en-us/library/windows/desktop/dn890789)オブジェクトを取得し、ジオメトリの描画インクとグラデーションなどの機能とメッシュ レンダリングします。</span><span class="sxs-lookup"><span data-stu-id="119bc-200">To do this, we obtain a [**ID2D1DeviceContext2**](https://msdn.microsoft.com/en-us/library/windows/desktop/dn890789) object which enables the creation and drawing of geometry, plus functionality such as ink and gradient mesh rendering.</span></span> <span data-ttu-id="119bc-201">一連の色を folling UI 要素を描画する[**ID2D1SolidColorBrush**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd372207)を使ってブラシを作成します。</span><span class="sxs-lookup"><span data-stu-id="119bc-201">We then create a series of colored brushes using [**ID2D1SolidColorBrush**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd372207) to draw the folling UI elements.</span></span>
- <span data-ttu-id="119bc-202">四角形の背景に黒のブラシ</span><span class="sxs-lookup"><span data-stu-id="119bc-202">Black brush for rectangle backgrounds</span></span>
- <span data-ttu-id="119bc-203">状態のテキストの白のブラシ</span><span class="sxs-lookup"><span data-stu-id="119bc-203">White brush for status text</span></span>
- <span data-ttu-id="119bc-204">アクションのテキストのオレンジ色のブラシ</span><span class="sxs-lookup"><span data-stu-id="119bc-204">Orange brush for action text</span></span>

#### <a name="deviceresourcessetdpi"></a><span data-ttu-id="119bc-205">DeviceResources::SetDpi</span><span class="sxs-lookup"><span data-stu-id="119bc-205">DeviceResources::SetDpi</span></span>
<span data-ttu-id="119bc-206">[**DeviceResources::SetDpi**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L514-L527)メソッドは、ウィンドウの 1 インチあたりのドットを設定します。</span><span class="sxs-lookup"><span data-stu-id="119bc-206">The [**DeviceResources::SetDpi**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L514-L527) method sets the dots per inch of the window.</span></span> <span data-ttu-id="119bc-207">このメソッドは、DPI が変更されする必要があるときに呼び出されます取得ゲームのウィンドウのサイズが変更されたときの動作を再調整します。</span><span class="sxs-lookup"><span data-stu-id="119bc-207">This method gets called when the DPI is changed and needs to be readjusted which happens when the game window is resized.</span></span> <span data-ttu-id="119bc-208">このメソッドは、DPI を更新した後、ウィンドウのサイズが変更されるたびに必要なリソースを再作成を確認する[**deviceresources::createwindowsizedependentresources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L214-L487)も呼び出します。</span><span class="sxs-lookup"><span data-stu-id="119bc-208">After updating the DPI, this method also calls[**DeviceResources::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L214-L487) to make sure necessary resources are recreated every time the window is resized.</span></span>


#### <a name="gameinfooverlaycreatewindowssizedependentresources"></a><span data-ttu-id="119bc-209">GameInfoOverlay::CreateWindowsSizeDependentResources</span><span class="sxs-lookup"><span data-stu-id="119bc-209">GameInfoOverlay::CreateWindowsSizeDependentResources</span></span>
<span data-ttu-id="119bc-210">[**GameInfoOverlay::CreateWindowsSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L108-L225)メソッドは、すべての描画が行われるです。</span><span class="sxs-lookup"><span data-stu-id="119bc-210">The [**GameInfoOverlay::CreateWindowsSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L108-L225) method is where all our drawing takes place.</span></span> <span data-ttu-id="119bc-211">メソッドの手順の概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="119bc-211">The following is an outline of the method's steps.</span></span>
- <span data-ttu-id="119bc-212">次の 3 つの四角形は、セクション**タイトル**、**本文**、および**操作**のテキストの UI テキストを無効に作成されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-212">Three rectangles are created to section off the UI text for the **Title**, **Body**, and **Action** text.</span></span>
    ```cpp 
    m_titleRectangle = D2D1::RectF(
        GameInfoOverlayConstant::SideMargin,
        GameInfoOverlayConstant::TopMargin,
        overlaySize.width - GameInfoOverlayConstant::SideMargin,
        GameInfoOverlayConstant::TopMargin + GameInfoOverlayConstant::TitleHeight
        );
    m_actionRectangle = D2D1::RectF(
        GameInfoOverlayConstant::SideMargin,
        overlaySize.height - (GameInfoOverlayConstant::ActionHeight + GameInfoOverlayConstant::BottomMargin),
        overlaySize.width - GameInfoOverlayConstant::SideMargin,
        overlaySize.height - GameInfoOverlayConstant::BottomMargin
        );
    m_bodyRectangle = D2D1::RectF(
        GameInfoOverlayConstant::SideMargin,
        m_titleRectangle.bottom + GameInfoOverlayConstant::Separator,
        overlaySize.width - GameInfoOverlayConstant::SideMargin,
        m_actionRectangle.top - GameInfoOverlayConstant::Separator
        );
    ```

- <span data-ttu-id="119bc-213">名前付きビットマップが作成`m_levelBitmap`、考慮現在 DPI **CreateBitmap**を使用します。</span><span class="sxs-lookup"><span data-stu-id="119bc-213">A Bitmap is created named `m_levelBitmap`, taking the current DPI into account using **CreateBitmap**.</span></span>
- `m_levelBitmap` <span data-ttu-id="119bc-214">当社の 2D レンダリング[**ID2D1DeviceContext::SetTarget**](https://msdn.microsoft.com/en-us/library/windows/desktop/hh404533)を使用してターゲットとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-214">is set as our 2D render target using [**ID2D1DeviceContext::SetTarget**](https://msdn.microsoft.com/en-us/library/windows/desktop/hh404533).</span></span>
- <span data-ttu-id="119bc-215">ビットマップが行われたすべてのピクセルでクリアされると黒の[**ID2D1RenderTarget::Clear**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371772)を使用します。</span><span class="sxs-lookup"><span data-stu-id="119bc-215">The Bitmap is cleared with every pixel made black using [**ID2D1RenderTarget::Clear**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371772).</span></span>
- <span data-ttu-id="119bc-216">[**ID2D1RenderTarget::BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371768)は、描画を開始すると呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="119bc-216">[**ID2D1RenderTarget::BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371768) is called to initiate drawing.</span></span> 
- <span data-ttu-id="119bc-217">**DrawText**に格納されているテキストを描画すると呼ばれる`m_titleString`、`m_bodyString`と`m_actionString`で対応する**ID2D1SolidColorBrush**を使用してされる四角形です。</span><span class="sxs-lookup"><span data-stu-id="119bc-217">**DrawText** is called to draw the text stored in `m_titleString`, `m_bodyString`, and `m_actionString` in the approperiate rectangle using the corresponding **ID2D1SolidColorBrush**.</span></span>
- <span data-ttu-id="119bc-218">[**ID2D1RenderTarget::EndDraw**](ID2D1RenderTarget::EndDraw)が上のすべての描画操作を停止すると呼ばれる`m_levelBitmap`します。</span><span class="sxs-lookup"><span data-stu-id="119bc-218">[**ID2D1RenderTarget::EndDraw**](ID2D1RenderTarget::EndDraw) is called to stop all drawing operations on `m_levelBitmap`.</span></span>
- <span data-ttu-id="119bc-219">**CreateBitmap**という名前を使用して別のビットマップを作成`m_tooSmallBitmap`表示の構成は、ゲームに対して小さすぎるかどうかにのみ表示、フォールバックとして使用します。</span><span class="sxs-lookup"><span data-stu-id="119bc-219">Another Bitmap is created using **CreateBitmap** named `m_tooSmallBitmap` to use as a fallback, showing only if the display configuration is too small for the game.</span></span>
- <span data-ttu-id="119bc-220">に描画するためのプロセスを繰り返す`m_levelBitmap`の`m_tooSmallBitmap`、今回は、文字列を描画のみ`Paused`本文。</span><span class="sxs-lookup"><span data-stu-id="119bc-220">Repeat process for drawing on `m_levelBitmap` for `m_tooSmallBitmap`, this time only drawing the string `Paused` in the body.</span></span>




<span data-ttu-id="119bc-221">6 つのメソッドを 6 つのオーバーレイの状態のテキストの入力は必要がありますすべてできるようになりました!</span><span class="sxs-lookup"><span data-stu-id="119bc-221">Now all we need are six methods to fill the text of our six overlay states!</span></span>

### <a name="representing-game-state"></a><span data-ttu-id="119bc-222">ゲームの状態を表す</span><span class="sxs-lookup"><span data-stu-id="119bc-222">Representing game state</span></span>


<span data-ttu-id="119bc-223">ゲームの 6 つのオーバーレイの状態の各により、 **GameInfoOverlay**オブジェクトに対応するメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="119bc-223">Each of the six overlay states in the game has a corresponding method in the **GameInfoOverlay** object.</span></span> <span data-ttu-id="119bc-224">これらのメソッドは、さまざまなオーバーレイを描画して、ゲーム自体に関する明示的な情報をプレイヤーに伝えます。</span><span class="sxs-lookup"><span data-stu-id="119bc-224">These methods draw a variation of the overlay to communicate explicit info to the player about the game itself.</span></span> <span data-ttu-id="119bc-225">この通信は、**タイトル**と**本文**文字列で表されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-225">This communication is represented with a **Title** and **Body** string.</span></span> <span data-ttu-id="119bc-226">サンプルでは、リソースとレイアウトの初期化時にこの情報や[**gameinfooverlay::createdevicedependentresources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)メソッドを使用して既に構成されている、ためのみ、オーバーレイの状態に固有の文字列を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="119bc-226">Because the sample already configured the resources and layout for this info when it was initialized and with the [**GameInfoOverlay::CreateDeviceDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104) method, it only needs to provide the overlay state-specific strings.</span></span>

<span data-ttu-id="119bc-227">以下のメソッドのいずれかを呼び出すことで、オーバーレイの**状態**の一部が設定されています。</span><span class="sxs-lookup"><span data-stu-id="119bc-227">The **Status** portion of the overlay is set with a call to one of the following methods.</span></span>

<span data-ttu-id="119bc-228">ゲームの状態</span><span class="sxs-lookup"><span data-stu-id="119bc-228">Game state</span></span> | <span data-ttu-id="119bc-229">状態の set メソッド</span><span class="sxs-lookup"><span data-stu-id="119bc-229">Status set method</span></span> | <span data-ttu-id="119bc-230">状態フィールド</span><span class="sxs-lookup"><span data-stu-id="119bc-230">Status fields</span></span>
:----- | :------- | :---------
<span data-ttu-id="119bc-231">読み込み中</span><span class="sxs-lookup"><span data-stu-id="119bc-231">Loading</span></span> | [<span data-ttu-id="119bc-232">GameInfoOverlay::SetGameLoading</span><span class="sxs-lookup"><span data-stu-id="119bc-232">GameInfoOverlay::SetGameLoading</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L254-L306) |**<span data-ttu-id="119bc-233">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="119bc-233">Title</span></span>**</br><span data-ttu-id="119bc-234">リソースの読み込み</span><span class="sxs-lookup"><span data-stu-id="119bc-234">Loading Resources</span></span> </br>**<span data-ttu-id="119bc-235">本文</span><span class="sxs-lookup"><span data-stu-id="119bc-235">Body</span></span>**</br> <span data-ttu-id="119bc-236">段階的に印刷"."読み込みアクティビティを意味します。</span><span class="sxs-lookup"><span data-stu-id="119bc-236">Incrementally prints "." to imply loading activity.</span></span>
<span data-ttu-id="119bc-237">最初の開始/ハイ スコアの統計</span><span class="sxs-lookup"><span data-stu-id="119bc-237">Initial start/high score stats</span></span> | [<span data-ttu-id="119bc-238">Gameinfooverlay::setgamestats</span><span class="sxs-lookup"><span data-stu-id="119bc-238">GameInfoOverlay::SetGameStats</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L310-L354) |**<span data-ttu-id="119bc-239">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="119bc-239">Title</span></span>**</br><span data-ttu-id="119bc-240">ハイ スコア</span><span class="sxs-lookup"><span data-stu-id="119bc-240">High Score</span></span></br> **<span data-ttu-id="119bc-241">本文</span><span class="sxs-lookup"><span data-stu-id="119bc-241">Body</span></span>**</br> <span data-ttu-id="119bc-242">レベル完了 #</span><span class="sxs-lookup"><span data-stu-id="119bc-242">Levels Completed #</span></span> </br><span data-ttu-id="119bc-243">合計ポイント #</span><span class="sxs-lookup"><span data-stu-id="119bc-243">Total Points #</span></span></br><span data-ttu-id="119bc-244">合計ショット #</span><span class="sxs-lookup"><span data-stu-id="119bc-244">Total Shots #</span></span>
<span data-ttu-id="119bc-245">レベル開始</span><span class="sxs-lookup"><span data-stu-id="119bc-245">Level start</span></span> | [<span data-ttu-id="119bc-246">GameInfoOverlay::SetLevelStart</span><span class="sxs-lookup"><span data-stu-id="119bc-246">GameInfoOverlay::SetLevelStart</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L413-L471) |**<span data-ttu-id="119bc-247">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="119bc-247">Title</span></span>**</br><span data-ttu-id="119bc-248">レベル</span><span class="sxs-lookup"><span data-stu-id="119bc-248">Level #</span></span></br>**<span data-ttu-id="119bc-249">本文</span><span class="sxs-lookup"><span data-stu-id="119bc-249">Body</span></span>**</br><span data-ttu-id="119bc-250">レベルで目的の説明。</span><span class="sxs-lookup"><span data-stu-id="119bc-250">Level objective description.</span></span>
<span data-ttu-id="119bc-251">ゲームが一時停止</span><span class="sxs-lookup"><span data-stu-id="119bc-251">Game paused</span></span> | [<span data-ttu-id="119bc-252">GameInfoOverlay::SetPause</span><span class="sxs-lookup"><span data-stu-id="119bc-252">GameInfoOverlay::SetPause</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L475-L502) |**<span data-ttu-id="119bc-253">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="119bc-253">Title</span></span>**</br><span data-ttu-id="119bc-254">ゲームが一時停止</span><span class="sxs-lookup"><span data-stu-id="119bc-254">Game Paused</span></span></br>**<span data-ttu-id="119bc-255">本文</span><span class="sxs-lookup"><span data-stu-id="119bc-255">Body</span></span>**</br><span data-ttu-id="119bc-256">なし</span><span class="sxs-lookup"><span data-stu-id="119bc-256">None</span></span>
<span data-ttu-id="119bc-257">ゲーム オーバー</span><span class="sxs-lookup"><span data-stu-id="119bc-257">Game over</span></span> | [<span data-ttu-id="119bc-258">GameInfoOverlay::SetGameOver</span><span class="sxs-lookup"><span data-stu-id="119bc-258">GameInfoOverlay::SetGameOver</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |**<span data-ttu-id="119bc-259">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="119bc-259">Title</span></span>**</br><span data-ttu-id="119bc-260">ゲームは終わりました</span><span class="sxs-lookup"><span data-stu-id="119bc-260">Game Over</span></span></br> **<span data-ttu-id="119bc-261">本文</span><span class="sxs-lookup"><span data-stu-id="119bc-261">Body</span></span>**</br> <span data-ttu-id="119bc-262">レベル完了 #</span><span class="sxs-lookup"><span data-stu-id="119bc-262">Levels Completed #</span></span> </br><span data-ttu-id="119bc-263">合計ポイント #</span><span class="sxs-lookup"><span data-stu-id="119bc-263">Total Points #</span></span></br><span data-ttu-id="119bc-264">合計ショット #</span><span class="sxs-lookup"><span data-stu-id="119bc-264">Total Shots #</span></span></br><span data-ttu-id="119bc-265">レベル完了 #</span><span class="sxs-lookup"><span data-stu-id="119bc-265">Levels Completed #</span></span></br><span data-ttu-id="119bc-266">ハイ スコア #</span><span class="sxs-lookup"><span data-stu-id="119bc-266">High Score #</span></span>
<span data-ttu-id="119bc-267">ゲームの終了</span><span class="sxs-lookup"><span data-stu-id="119bc-267">Game won</span></span> | [<span data-ttu-id="119bc-268">GameInfoOverlay::SetGameOver</span><span class="sxs-lookup"><span data-stu-id="119bc-268">GameInfoOverlay::SetGameOver</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |**<span data-ttu-id="119bc-269">Title (タイトル)</span><span class="sxs-lookup"><span data-stu-id="119bc-269">Title</span></span>**</br><span data-ttu-id="119bc-270">勝利しました!</span><span class="sxs-lookup"><span data-stu-id="119bc-270">You WON!</span></span></br> **<span data-ttu-id="119bc-271">本文</span><span class="sxs-lookup"><span data-stu-id="119bc-271">Body</span></span>**</br> <span data-ttu-id="119bc-272">レベル完了 #</span><span class="sxs-lookup"><span data-stu-id="119bc-272">Levels Completed #</span></span> </br><span data-ttu-id="119bc-273">合計ポイント #</span><span class="sxs-lookup"><span data-stu-id="119bc-273">Total Points #</span></span></br><span data-ttu-id="119bc-274">合計ショット #</span><span class="sxs-lookup"><span data-stu-id="119bc-274">Total Shots #</span></span></br><span data-ttu-id="119bc-275">レベル完了 #</span><span class="sxs-lookup"><span data-stu-id="119bc-275">Levels Completed #</span></span></br><span data-ttu-id="119bc-276">ハイ スコア #</span><span class="sxs-lookup"><span data-stu-id="119bc-276">High Score #</span></span>




<span data-ttu-id="119bc-277">[**GameInfoOverlay::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L117-L134)メソッドでは、サンプルは、オーバーレイの特定の地域に対応する 3 つの四角形領域を宣言します。</span><span class="sxs-lookup"><span data-stu-id="119bc-277">With the [**GameInfoOverlay::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L117-L134) method, the sample declared three rectangular areas that correspond to specific regions of the overlay.</span></span>



<span data-ttu-id="119bc-278">これらの領域を念頭に置いて、状態に固有のメソッドの 1 つである **GameInfoOverlay::SetGameStats** と、オーバーレイの描画方法を確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="119bc-278">With these areas in mind, let's look at one of the state-specific methods, **GameInfoOverlay::SetGameStats**, and see how the overlay is drawn.</span></span>

```cpp
void GameInfoOverlay::SetGameStats(int maxLevel, int hitCount, int shotCount)
{
    int length;

    auto d2dContext = m_deviceResources->GetD2DDeviceContext();

    d2dContext->SetTarget(m_levelBitmap.Get());
    d2dContext->BeginDraw();
    d2dContext->SetTransform(D2D1::Matrix3x2F::Identity());
    d2dContext->FillRectangle(&m_titleRectangle, m_backgroundBrush.Get());
    d2dContext->FillRectangle(&m_bodyRectangle, m_backgroundBrush.Get());
    m_titleString = "High Score";

    d2dContext->DrawText(
        m_titleString->Data(),
        m_titleString->Length(),
        m_textFormatTitle.Get(),
        m_titleRectangle,
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
    m_bodyString = ref new Platform::String(wsbuffer, length);
    d2dContext->DrawText(
        m_bodyString->Data(),
        m_bodyString->Length(),
        m_textFormatBody.Get(),
        m_bodyRectangle,
        m_textBrush.Get()
        );

    // We ignore D2DERR_RECREATE_TARGET here. This error indicates that the device
    // is lost. It will be handled during the next call to Present.
    HRESULT hr = d2dContext->EndDraw();
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

<span data-ttu-id="119bc-279">**GameInfoOverlay**オブジェクトを初期化する Direct2D デバイス コンテキストを使用して、このメソッドは黒い背景ブラシを使用してタイトルと本文の四角形を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="119bc-279">Using the Direct2D device context that the **GameInfoOverlay** object initialized, this method fills the title and body rectangles with black using the background brush.</span></span> <span data-ttu-id="119bc-280">また、白のテキスト ブラシを使って、"High Score" 文字列用のテキストをタイトルの四角形に描画し、ゲームの状態の最新情報が含まれている文字列を本文の四角形に描画します。</span><span class="sxs-lookup"><span data-stu-id="119bc-280">It draws the text for the "High Score" string to the title rectangle and a string containing the updates game state information to the body rectangle using the white text brush.</span></span>


<span data-ttu-id="119bc-281">操作の四角形は、後続の呼び出しで[**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564) **GameInfoOverlay::SetAction**によってに対する適切なメッセージを判断するために必要なゲームの状態情報を提供する**GameMain**オブジェクトのメソッドから更新しますプレーヤーでは、「タップして、引き続き」などです。</span><span class="sxs-lookup"><span data-stu-id="119bc-281">The action rectangle is updated by a subsequent call to [**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564) from a method on the **GameMain** object, which provides the game state info needed by **GameInfoOverlay::SetAction** to determine the right message to the player, such as "Tap to continue".</span></span>

<span data-ttu-id="119bc-282">特定の状態のオーバーレイは、このような[**GameMain::SetGameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/GameMain.cpp#L606-L661)メソッドで選択されます。</span><span class="sxs-lookup"><span data-stu-id="119bc-282">The overlay for any given state is chosen in the [**GameMain::SetGameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/GameMain.cpp#L606-L661) method like this:</span></span>

```cpp
void GameMain::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {
    case GameInfoOverlayState::Loading:
        m_uiControl->SetGameLoading();
        break;

    case GameInfoOverlayState::GameStats:
        m_uiControl->SetGameStats(
            m_game->HighScore().levelCompleted + 1,
            m_game->HighScore().totalHits,
            m_game->HighScore().totalShots
            );
        break;

    case GameInfoOverlayState::LevelStart:
        m_uiControl->SetLevelStart(
            m_game->LevelCompleted() + 1,
            m_game->CurrentLevel()->Objective(),
            m_game->CurrentLevel()->TimeLimit(),
            m_game->BonusTime()
            );
        break;

    case GameInfoOverlayState::GameOverCompleted:
        m_uiControl->SetGameOver(
            true,
            m_game->LevelCompleted() + 1,
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::GameOverExpired:
        m_uiControl->SetGameOver(
            false,
            m_game->LevelCompleted(),
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::Pause:
        m_uiControl->SetPause(
            m_game->LevelCompleted() + 1,
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->TimeRemaining()
            );
        break;
    }
}
```

<span data-ttu-id="119bc-283">ゲームがゲームの状態に基づいて、プレイヤーにテキスト情報をやり取りする方法とゲーム全体に表示される内容を切り替える方法が用意されています。</span><span class="sxs-lookup"><span data-stu-id="119bc-283">Now the game has a way to communicate text info to the player based on game state, and we have a way of switching what's displayed to them throughout the game.</span></span>

### <a name="next-steps"></a><span data-ttu-id="119bc-284">次のステップ</span><span class="sxs-lookup"><span data-stu-id="119bc-284">Next steps</span></span>

<span data-ttu-id="119bc-285">次のトピックの「[コントロールの追加](tutorial--adding-controls.md)」では、プレイヤーがこのゲーム サンプルを操作する方法と、入力によってゲームの状態がどのように変わるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="119bc-285">In the next topic, [Adding controls](tutorial--adding-controls.md), we look at how the player interacts with the game sample, and how input changes game state.</span></span>



 




