---
title: ユーザー インターフェイスの追加
description: DirectX の UWP ゲームを 2D のユーザー インターフェイスのオーバーレイを追加する方法について説明します。
ms.assetid: fa40173e-6cde-b71b-e307-db90f0388485
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, ユーザー インターフェイス, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 09005eb12997126a9cad68c388beb0473b19fda3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57609057"
---
# <a name="add-a-user-interface"></a><span data-ttu-id="7068b-104">ユーザー インターフェイスの追加</span><span class="sxs-lookup"><span data-stu-id="7068b-104">Add a user interface</span></span>


<span data-ttu-id="7068b-105">これで、ゲームでは、場所にその 3D ビジュアルが含まれるゲームがプレーヤーにゲームの状態に関するフィードバックを提供できるように、いくつかの 2D 要素を追加することに集中する時間を勧めします。</span><span class="sxs-lookup"><span data-stu-id="7068b-105">Now that our game has its 3D visuals in place, it's time to focus on adding some 2D elements so that the game can provide feedback about game state to the player.</span></span> <span data-ttu-id="7068b-106">これは単純なメニュー オプションを追加することで実現でき、3-D グラフィックスの上にヘッドアップ ディスプレイのコンポーネントが出力をパイプラインします。</span><span class="sxs-lookup"><span data-stu-id="7068b-106">This can be accomplished by adding simple menu options and heads-up display components on top of the 3-D graphics pipeline output.</span></span>

>[!Note]
><span data-ttu-id="7068b-107">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="7068b-107">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="7068b-108">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="7068b-108">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="7068b-109">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7068b-109">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="7068b-110">目標</span><span class="sxs-lookup"><span data-stu-id="7068b-110">Objective</span></span>

<span data-ttu-id="7068b-111">Direct2D を使用して、UWP の DirectX ゲームなどを多数のユーザー インターフェイスのグラフィックスと動作を追加します。</span><span class="sxs-lookup"><span data-stu-id="7068b-111">Using Direct2D, add a number of user interface graphics and behaviors to our UWP DirectX game including:</span></span>
- <span data-ttu-id="7068b-112">ヘッドアップを表示するなど[移動外観コント ローラー](tutorial--adding-controls.md)四角形の境界</span><span class="sxs-lookup"><span data-stu-id="7068b-112">Heads-up display, including [move-look controller](tutorial--adding-controls.md) boundry rectangles</span></span>
- <span data-ttu-id="7068b-113">ゲームの状態のメニュー</span><span class="sxs-lookup"><span data-stu-id="7068b-113">Game state menus</span></span>


## <a name="the-user-interface-overlay"></a><span data-ttu-id="7068b-114">ユーザー インターフェイスのオーバーレイ</span><span class="sxs-lookup"><span data-stu-id="7068b-114">The user interface overlay</span></span>


<span data-ttu-id="7068b-115">DirectX ゲームにテキストおよびユーザー インターフェイス要素を表示するさまざまな方法はありますが、ここにフォーカスを使用して[Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="7068b-115">While there are many ways to display text and user interface elements in a DirectX game, we're going to focus on using [Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx).</span></span> <span data-ttu-id="7068b-116">使用することも[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038)のテキスト要素です。</span><span class="sxs-lookup"><span data-stu-id="7068b-116">We'll also be using [DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038) for the text elements.</span></span>


<span data-ttu-id="7068b-117">Direct2D は、ピクセル ベース プリミティブと効果を描画するために一連の 2D 描画 Api を使用します。</span><span class="sxs-lookup"><span data-stu-id="7068b-117">Direct2D is a set of 2D drawing APIs used to draw pixel-based primitives and effects.</span></span> <span data-ttu-id="7068b-118">以降 Direct2D では、ときに、複雑にならないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7068b-118">When starting out with Direct2D, it's best to keep things simple.</span></span> <span data-ttu-id="7068b-119">複雑なレイアウトやインターフェイス動作には、時間と計画が必要です。</span><span class="sxs-lookup"><span data-stu-id="7068b-119">Complex layouts and interface behaviors need time and planning.</span></span> <span data-ttu-id="7068b-120">ゲームには、シミュレーションと戦略ゲームなどに見られるよう、複雑なユーザー インターフェイスが必要な場合は、代わりに XAML の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="7068b-120">If your game requires a complex user interface, like those found in simulation and strategy games, consider using XAML instead.</span></span>

> [!NOTE]
> <span data-ttu-id="7068b-121">XAML と DirectX の UWP ゲームでのユーザー インターフェイスの開発方法の詳細については、次を参照してください。[ゲームのサンプルを拡張する](tutorial-resources.md)します。</span><span class="sxs-lookup"><span data-stu-id="7068b-121">For info about developing a user interface with XAML in a UWP DirectX game, see [Extending the game sample](tutorial-resources.md).</span></span>

<span data-ttu-id="7068b-122">Direct2D はされていないユーザー インターフェイスまたは HTML と XAML のようなレイアウトを具体的には設計されています。</span><span class="sxs-lookup"><span data-stu-id="7068b-122">Direct2D isn't specifically designed for user interfaces or layouts like HTML and XAML.</span></span> <span data-ttu-id="7068b-123">これにより、リスト、ボックス、またはボタンのようなユーザー インターフェイス コンポーネントが用意されていません。</span><span class="sxs-lookup"><span data-stu-id="7068b-123">It doesn't provide user interface components like lists, boxes, or buttons.</span></span> <span data-ttu-id="7068b-124">Div、テーブル、またはグリッドなどのレイアウトのコンポーネントも提供されません。</span><span class="sxs-lookup"><span data-stu-id="7068b-124">It also doesn't provide layout components like divs, tables, or grids.</span></span>


<span data-ttu-id="7068b-125">このゲームのサンプルについては、2 つの主な UI コンポーネントがあります。</span><span class="sxs-lookup"><span data-stu-id="7068b-125">For this game sample we have two major UI components.</span></span>
1. <span data-ttu-id="7068b-126">スコアおよびゲーム内のコントロールのヘッドアップ ディスプレイ。</span><span class="sxs-lookup"><span data-stu-id="7068b-126">A heads-up display for the score and in-game controls.</span></span>
2. <span data-ttu-id="7068b-127">オーバーレイのゲームの状態のテキストと一時停止の情報などのオプションを表示するために使用し、レベルがオプションを開始します。</span><span class="sxs-lookup"><span data-stu-id="7068b-127">An overlay used to display game state text and options such as pause info and level start options.</span></span>

### <a name="using-direct2d-for-a-heads-up-display"></a><span data-ttu-id="7068b-128">Direct2D を使ったヘッドアップ ディスプレイ</span><span class="sxs-lookup"><span data-stu-id="7068b-128">Using Direct2D for a heads-up display</span></span>

<span data-ttu-id="7068b-129">次の図は、サンプルのゲームのヘッドアップ ディスプレイを示します。</span><span class="sxs-lookup"><span data-stu-id="7068b-129">The following image shows the in-game heads-up display for the sample.</span></span> <span data-ttu-id="7068b-130">単純ですっきり、プレーヤーに 3D の世界を移動して、ターゲットを撮影できるようにします。</span><span class="sxs-lookup"><span data-stu-id="7068b-130">It's simple and uncluttered, allowing the player to focus on navigating the 3D world and shooting targets.</span></span> <span data-ttu-id="7068b-131">適切なインターフェイスまたはヘッドアップ ディスプレイをする必要がありますは処理、ゲームでは、イベントに対応してプレイヤーの機能を決して複雑にします。</span><span class="sxs-lookup"><span data-stu-id="7068b-131">A good interface or heads-up display must never complicate the ability of the player to process and react to the events in the game.</span></span>

![ゲーム オーバーレイのスクリーン ショット](images/simple-dx-game-ui-overlay.png)

<span data-ttu-id="7068b-133">オーバーレイは、次の基本的なプリミティブで構成されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-133">The overlay consists of the following basic primitives.</span></span>
- <span data-ttu-id="7068b-134">[**DirectWrite** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)のプレーヤーに通知する右上隅にあるテキスト</span><span class="sxs-lookup"><span data-stu-id="7068b-134">[**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038) text in the upper-right corner that informs the player of</span></span> 
    - <span data-ttu-id="7068b-135">成功したヒット数</span><span class="sxs-lookup"><span data-stu-id="7068b-135">Successful hits</span></span>
    - <span data-ttu-id="7068b-136">プレーヤーが行われたショットの数</span><span class="sxs-lookup"><span data-stu-id="7068b-136">Number of shots the player has made</span></span>
    - <span data-ttu-id="7068b-137">レベルの残りの期間</span><span class="sxs-lookup"><span data-stu-id="7068b-137">Time remaining in the level</span></span>
    - <span data-ttu-id="7068b-138">現在のレベル数</span><span class="sxs-lookup"><span data-stu-id="7068b-138">Current level number</span></span> 
- <span data-ttu-id="7068b-139">2 つの十字を形成するために使用する線分の交差しません。</span><span class="sxs-lookup"><span data-stu-id="7068b-139">Two intersecting line segments used to form a cross hair</span></span>
- <span data-ttu-id="7068b-140">2 つの四角形の画面の下隅にある、[移動外観コント ローラー](tutorial--adding-controls.md)境界。</span><span class="sxs-lookup"><span data-stu-id="7068b-140">Two rectangles at the bottom corners for the [move-look controller](tutorial--adding-controls.md) boundries.</span></span> 


<span data-ttu-id="7068b-141">オーバーレイのゲームのヘッドアップ ディスプレイの状態で表示されます、 [ **GameHud::Render** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L234-L358)のメソッド、 [ **GameHud** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.h)クラス。</span><span class="sxs-lookup"><span data-stu-id="7068b-141">The in-game heads-up display state of the overlay is drawn in the [**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L234-L358) method of the [**GameHud**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.h) class.</span></span> <span data-ttu-id="7068b-142">このメソッド内に残りとレベルの数のヒット数の変更を反映するように、Direct2D のオーバーレイを表す、UI が更新されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-142">Within this method, the Direct2D overlay that represents our UI is updated to reflect the changes in the number of hits, time remaining, and level number.</span></span>

<span data-ttu-id="7068b-143">ゲームが初期化されたかどうかは追加`TotalHits()`、 `TotalShots()`、および`TimeRemaining()`に、 [ **swprintf_s** ](https://docs.microsoft.com/cpp/c-runtime-library/reference/sprintf-s-sprintf-s-l-swprintf-s-swprintf-s-l)バッファーし、印刷の形式を指定します。</span><span class="sxs-lookup"><span data-stu-id="7068b-143">If the game has been initialized, we add `TotalHits()`, `TotalShots()`, and `TimeRemaining()` to a [**swprintf_s**](https://docs.microsoft.com/cpp/c-runtime-library/reference/sprintf-s-sprintf-s-l-swprintf-s-swprintf-s-l) buffer and specify the print format.</span></span> <span data-ttu-id="7068b-144">使用して描画できますし、 [ **DrawText** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd742848)メソッド。</span><span class="sxs-lookup"><span data-stu-id="7068b-144">We can then draw it using the [**DrawText**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd742848) method.</span></span> <span data-ttu-id="7068b-145">同じ現在のレベルのインジケーターの描画など ➀、未完了のレベルを表示する空の番号と ➊ など、特定のレベルが完了したことを表示するの塗りつぶされた番号。</span><span class="sxs-lookup"><span data-stu-id="7068b-145">We do the same for the current level indicator, drawing empty numbers to show uncompleted levels like ➀, and filled numbers like ➊ to show that the specific level was completed.</span></span>


<span data-ttu-id="7068b-146">次のコード スニペットの説明、 **GameHud::Render**のメソッドの処理</span><span class="sxs-lookup"><span data-stu-id="7068b-146">The following code snippet walks through the **GameHud::Render** method's process for</span></span> 
- <span data-ttu-id="7068b-147">使用して、ビットマップを作成する[\* \* ID2D1RenderTarget::DrawBitmap \* \*](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371880)</span><span class="sxs-lookup"><span data-stu-id="7068b-147">Creating a Bitmap using [\*\*ID2D1RenderTarget::DrawBitmap \*\*](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371880)</span></span>
- <span data-ttu-id="7068b-148">UI 領域を使用して四角形に分割[ **D2D1::RectF**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368184)</span><span class="sxs-lookup"><span data-stu-id="7068b-148">Sectioning off UI areas into rectangles using [**D2D1::RectF**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368184)</span></span>
- <span data-ttu-id="7068b-149">使用して**DrawText**テキスト要素を作成するには</span><span class="sxs-lookup"><span data-stu-id="7068b-149">Using **DrawText** to make text elements</span></span>

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

<span data-ttu-id="7068b-150">この部分にさらに、下のメソッドの重大な[ **GameHud::Render** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L320-L358)メソッドは、移行を描画を四角形の起動と[ **ID2D1RenderTarget::DrawRectangle**](https://msdn.microsoft.com/library/windows/desktop/dd371902)、十字線を 2 つの呼び出しを使用して、 [ **ID2D1RenderTarget::DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895)します。</span><span class="sxs-lookup"><span data-stu-id="7068b-150">Breaking the method down further, this piece of the [**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L320-L358) method draws our move and fire rectangles with [**ID2D1RenderTarget::DrawRectangle**](https://msdn.microsoft.com/library/windows/desktop/dd371902), and crosshairs using two calls to [**ID2D1RenderTarget::DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895).</span></span>

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

<span data-ttu-id="7068b-151">**GameHud::Render**メソッドでゲームのウィンドウの論理サイズ格納、`windowBounds`変数。</span><span class="sxs-lookup"><span data-stu-id="7068b-151">In the **GameHud::Render** method we store the logical size of the game window in the `windowBounds` variable.</span></span> <span data-ttu-id="7068b-152">これを使用して、 [ `GetLogicalSize` ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.h#L41)のメソッド、 **DeviceResources**クラス。</span><span class="sxs-lookup"><span data-stu-id="7068b-152">This uses the [`GetLogicalSize`](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.h#L41) method of the **DeviceResources** class.</span></span> 
```cpp
auto windowBounds = m_deviceResources->GetLogicalSize();
```

 <span data-ttu-id="7068b-153">ゲームのウィンドウのサイズの取得は、UI プログラミングに不可欠です。</span><span class="sxs-lookup"><span data-stu-id="7068b-153">Obtaining the size of the game window is essential for UI programming.</span></span> <span data-ttu-id="7068b-154">ウィンドウのサイズが 1/96 インチ単位として、DIP が定義されている Dip (デバイス非依存ピクセル) と呼ばれるで与えられます。</span><span class="sxs-lookup"><span data-stu-id="7068b-154">The size of the window is given in a measurement called DIPs (device independent pixels), where a DIP is defined as 1/96 of an inch.</span></span> <span data-ttu-id="7068b-155">Direct2D スケーリング図面の単位を実際のピクセルが図面が発生したときに Windows ドット/インチ (DPI) 設定を使用して、そいます。</span><span class="sxs-lookup"><span data-stu-id="7068b-155">Direct2D scales the drawing units to actual pixels when the drawing occurs, doing so by using the Windows dots per inch (DPI) setting.</span></span> <span data-ttu-id="7068b-156">同様に、描画するとテキストを使用して[ **DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)フォントのサイズの点ではなく、Dip を指定します。</span><span class="sxs-lookup"><span data-stu-id="7068b-156">Similarly, when you draw text using [**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038), you specify DIPs rather than points for the size of the font.</span></span> <span data-ttu-id="7068b-157">DIP は、浮動小数点数として表されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-157">DIPs are expressed as floating point numbers.</span></span>

 

### <a name="displaying-game-state-info"></a><span data-ttu-id="7068b-158">ゲームの状態情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="7068b-158">Displaying game state info</span></span>

<span data-ttu-id="7068b-159">ヘッドアップ ディスプレイ、だけでなくは、ゲームのサンプルは、6 つのゲームの状態を表すオーバーレイが。</span><span class="sxs-lookup"><span data-stu-id="7068b-159">Besides the heads-up display, the game sample has an overlay that represents six game states.</span></span> <span data-ttu-id="7068b-160">すべての状態の機能を読み取るプレーヤー テキストに大きな黒い長方形プリミティブ。</span><span class="sxs-lookup"><span data-stu-id="7068b-160">All states feature a large black rectangle primitive with text for the player to read.</span></span> <span data-ttu-id="7068b-161">非アクティブ状態であるために、コント ローラーの四角形を移動外観や十字線は描画されません。</span><span class="sxs-lookup"><span data-stu-id="7068b-161">The move-look controller rectangles and crosshairs are not drawn because they are not active in these states.</span></span>

<span data-ttu-id="7068b-162">使用して、オーバーレイを作成、 [ **GameInfoOverlay** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.h)クラス、ゲームの状態の連携を表示するテキストを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="7068b-162">The overlay is created using the [**GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.h) class, allowing us to switch out what text is displayed to align with the state of the game.</span></span>

![状態とオーバーレイのアクション](images/simple-dx-game-ui-finaloverlay.png)

<span data-ttu-id="7068b-164">オーバーレイは、2 つのセクションに分割されます。**ステータス**と**アクション**します。</span><span class="sxs-lookup"><span data-stu-id="7068b-164">The overlay is broken up into two sections: **Status** and **Action**.</span></span> <span data-ttu-id="7068b-165">**状態**にさらに分類がセクション**タイトル**と**本文**四角形。</span><span class="sxs-lookup"><span data-stu-id="7068b-165">The **Status** secton is further broken down into **Title** and **Body** rectangles.</span></span> <span data-ttu-id="7068b-166">**アクション**セクションには 1 つの四角形。</span><span class="sxs-lookup"><span data-stu-id="7068b-166">The **Action** section only has one rectangle.</span></span> <span data-ttu-id="7068b-167">各四角形は、別の目的があります。</span><span class="sxs-lookup"><span data-stu-id="7068b-167">Each rectangle has a different purpose.</span></span>

-   <span data-ttu-id="7068b-168">`titleRectangle` タイトルのテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7068b-168">`titleRectangle` contains the title text.</span></span>
-   <span data-ttu-id="7068b-169">`bodyRectangle` 本文のテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7068b-169">`bodyRectangle` contains the body text.</span></span>
-   <span data-ttu-id="7068b-170">`actionRectangle` 特定のアクションを実行するプレーヤーを通知するテキストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7068b-170">`actionRectangle` contains the text that informs the player to take a specific action.</span></span>

<span data-ttu-id="7068b-171">ゲームでは、設定可能な 6 つの状態があります。</span><span class="sxs-lookup"><span data-stu-id="7068b-171">The game has six states that can be set.</span></span> <span data-ttu-id="7068b-172">使用して伝達ゲームの状態、**状態**オーバーレイの部分。</span><span class="sxs-lookup"><span data-stu-id="7068b-172">The state of the game conveyed using the **Status** portion of the overlay.</span></span> <span data-ttu-id="7068b-173">**状態**四角形は、さまざまな状態に対応するメソッドを使用して更新されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-173">The **Status** rectangles are updated using a number of methods corresponding with the following states.</span></span>

- <span data-ttu-id="7068b-174">読み込み</span><span class="sxs-lookup"><span data-stu-id="7068b-174">Loading</span></span>
- <span data-ttu-id="7068b-175">初期の開始/高スコア統計</span><span class="sxs-lookup"><span data-stu-id="7068b-175">Initial start/high score stats</span></span>
- <span data-ttu-id="7068b-176">レベルの開始</span><span class="sxs-lookup"><span data-stu-id="7068b-176">Level start</span></span>
- <span data-ttu-id="7068b-177">ゲームの一時停止</span><span class="sxs-lookup"><span data-stu-id="7068b-177">Game paused</span></span>
- <span data-ttu-id="7068b-178">ゲーム オーバー</span><span class="sxs-lookup"><span data-stu-id="7068b-178">Game over</span></span>
- <span data-ttu-id="7068b-179">勝利したゲーム</span><span class="sxs-lookup"><span data-stu-id="7068b-179">Game won</span></span>


<span data-ttu-id="7068b-180">**アクション**を使用して、オーバーレイの部分を更新、 [ **GameInfoOverlay::SetAction** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564)メソッドを次のいずれかに設定するアクション テキストを許可します。</span><span class="sxs-lookup"><span data-stu-id="7068b-180">The **Action** portion of the overlay is updated using the [**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564) method, allowing the action text to be set to one of the following.</span></span>
- <span data-ttu-id="7068b-181">「... もう一度再生してタップします」</span><span class="sxs-lookup"><span data-stu-id="7068b-181">"Tap to play again..."</span></span>
- <span data-ttu-id="7068b-182">「レベルの読み込み、お待ちください...」</span><span class="sxs-lookup"><span data-stu-id="7068b-182">"Level loading, please wait ..."</span></span>
- <span data-ttu-id="7068b-183">"Tap to continue..."</span><span class="sxs-lookup"><span data-stu-id="7068b-183">"Tap to continue ..."</span></span>
- <span data-ttu-id="7068b-184">なし</span><span class="sxs-lookup"><span data-stu-id="7068b-184">None</span></span>

> [!NOTE]
> <span data-ttu-id="7068b-185">どちらの方法については、説明でさらに、[ゲームの状態を表す](#representing-game-state)セクション。</span><span class="sxs-lookup"><span data-stu-id="7068b-185">Both of these methods will be discussed further in the [Representing game state](#representing-game-state) section.</span></span>

<span data-ttu-id="7068b-186">によって、ゲームでは、何が起こって、**状態**と**アクション**セクションのテキスト フィールドが調整されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-186">Depending on the what's going on in the game, the **Status** and **Action** section text fields are adjusted.</span></span>
<span data-ttu-id="7068b-187">初期化し、これら 6 つの状態のオーバーレイを描く方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="7068b-187">Let's look at how we initialize and draw the overlay for these six states.</span></span>

### <a name="initializing-and-drawing-the-overlay"></a><span data-ttu-id="7068b-188">オーバーレイの初期化と描画</span><span class="sxs-lookup"><span data-stu-id="7068b-188">Initializing and drawing the overlay</span></span>

<span data-ttu-id="7068b-189">6 つ**ステータス**状態は、いくつかの点を共通のあるリソースのメソッドを行う必要があるとよく似ています。</span><span class="sxs-lookup"><span data-stu-id="7068b-189">The six **Status** states have a few things in common, making the resources and methods they need very similar.</span></span>
    - <span data-ttu-id="7068b-190">画面の中央に黒の四角形を使用、すべてが背景と。</span><span class="sxs-lookup"><span data-stu-id="7068b-190">They all use a black rectangle in the center of the screen as their background.</span></span>
    - <span data-ttu-id="7068b-191">表示されるテキストがあるか、**タイトル**または**本文**テキスト。</span><span class="sxs-lookup"><span data-stu-id="7068b-191">The displayed text is either **Title** or **Body** text.</span></span>
    - <span data-ttu-id="7068b-192">テキストは、Segoe UI フォントが使用され、バックの四角形の上に描画されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-192">The text uses the Segoe UI font and is drawn on top of the back rectangle.</span></span> 


<span data-ttu-id="7068b-193">ゲームのサンプルでは、オーバーレイを作成するときに影響する 4 つのメソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="7068b-193">The game sample has four methods that come into play when creating the overlay.</span></span>
 

#### <a name="gameinfooverlaygameinfooverlay"></a><span data-ttu-id="7068b-194">GameInfoOverlay::GameInfoOverlay</span><span class="sxs-lookup"><span data-stu-id="7068b-194">GameInfoOverlay::GameInfoOverlay</span></span>
<span data-ttu-id="7068b-195">[ **GameInfoOverlay::GameInfoOverlay** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L30-L78)コンス トラクターに、プレーヤーに情報を表示するに使用するビットマップの画面を維持、オーバーレイを初期化します。</span><span class="sxs-lookup"><span data-stu-id="7068b-195">The [**GameInfoOverlay::GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L30-L78) constructor initializes the overlay, maintaining the bitmap surface that we will use to display info to the player on.</span></span> <span data-ttu-id="7068b-196">コンス トラクターから工場出荷時の取得、 [ **ID2D1Device** ](https://msdn.microsoft.com/library/windows/desktop/hh404478)オブジェクトの作成に使用するように渡される、 [ **ID2D1DeviceContext** ](https://msdn.microsoft.com/library/windows/desktop/hh404479)オーバーレイはオブジェクト自体を描画できます。</span><span class="sxs-lookup"><span data-stu-id="7068b-196">The constructor obtains a factory from the [**ID2D1Device**](https://msdn.microsoft.com/library/windows/desktop/hh404478) object passed to it, which it uses to create an [**ID2D1DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/hh404479) that the overlay object itself can draw to.</span></span> [<span data-ttu-id="7068b-197">IDWriteFactory::CreateTextFormat</span><span class="sxs-lookup"><span data-stu-id="7068b-197">IDWriteFactory::CreateTextFormat</span></span>](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368203) 


#### <a name="gameinfooverlaycreatedevicedependentresources"></a><span data-ttu-id="7068b-198">GameInfoOverlay::CreateDeviceDependentResources</span><span class="sxs-lookup"><span data-stu-id="7068b-198">GameInfoOverlay::CreateDeviceDependentResources</span></span>
<span data-ttu-id="7068b-199">[**GameInfoOverlay::CreateDeviceDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)メソッドは、テキストの描画に使用されるブラシを作成します。</span><span class="sxs-lookup"><span data-stu-id="7068b-199">[**GameInfoOverlay::CreateDeviceDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104) is our method for creating brushes that will be used to draw our text.</span></span> <span data-ttu-id="7068b-200">これを行うには、取得、 [ **ID2D1DeviceContext2** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dn890789)オブジェクトを作成できるようにし、ジオメトリの描画インクとグラデーションなどの機能とメッシュをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="7068b-200">To do this, we obtain a [**ID2D1DeviceContext2**](https://msdn.microsoft.com/en-us/library/windows/desktop/dn890789) object which enables the creation and drawing of geometry, plus functionality such as ink and gradient mesh rendering.</span></span> <span data-ttu-id="7068b-201">一連の色のブラシを使用して作成し[ **ID2D1SolidColorBrush** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd372207) folling の UI 要素を描画します。</span><span class="sxs-lookup"><span data-stu-id="7068b-201">We then create a series of colored brushes using [**ID2D1SolidColorBrush**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd372207) to draw the folling UI elements.</span></span>
- <span data-ttu-id="7068b-202">四角形の背景に黒のブラシ</span><span class="sxs-lookup"><span data-stu-id="7068b-202">Black brush for rectangle backgrounds</span></span>
- <span data-ttu-id="7068b-203">状態のテキストのブラシを白</span><span class="sxs-lookup"><span data-stu-id="7068b-203">White brush for status text</span></span>
- <span data-ttu-id="7068b-204">オレンジ色のブラシをアクション テキスト</span><span class="sxs-lookup"><span data-stu-id="7068b-204">Orange brush for action text</span></span>

#### <a name="deviceresourcessetdpi"></a><span data-ttu-id="7068b-205">DeviceResources::SetDpi</span><span class="sxs-lookup"><span data-stu-id="7068b-205">DeviceResources::SetDpi</span></span>
<span data-ttu-id="7068b-206">[ **DeviceResources::SetDpi** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L514-L527)メソッドは、ウィンドウのインチあたりのドットを設定します。</span><span class="sxs-lookup"><span data-stu-id="7068b-206">The [**DeviceResources::SetDpi**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L514-L527) method sets the dots per inch of the window.</span></span> <span data-ttu-id="7068b-207">このメソッドは、DPI が変更されする必要があるときに呼び出されますゲームのウィンドウのサイズが変更されたときの動作を再調整されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-207">This method gets called when the DPI is changed and needs to be readjusted which happens when the game window is resized.</span></span> <span data-ttu-id="7068b-208">このメソッドを DPI を更新した後はも[**DeviceResources::CreateWindowSizeDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L214-L487)たびに、ウィンドウのサイズを変更することを確認して必要なリソースが再作成します。</span><span class="sxs-lookup"><span data-stu-id="7068b-208">After updating the DPI, this method also calls[**DeviceResources::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L214-L487) to make sure necessary resources are recreated every time the window is resized.</span></span>


#### <a name="gameinfooverlaycreatewindowssizedependentresources"></a><span data-ttu-id="7068b-209">GameInfoOverlay::CreateWindowsSizeDependentResources</span><span class="sxs-lookup"><span data-stu-id="7068b-209">GameInfoOverlay::CreateWindowsSizeDependentResources</span></span>
<span data-ttu-id="7068b-210">[ **GameInfoOverlay::CreateWindowsSizeDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L108-L225)メソッドは、すべての描画が行われる場所。</span><span class="sxs-lookup"><span data-stu-id="7068b-210">The [**GameInfoOverlay::CreateWindowsSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L108-L225) method is where all our drawing takes place.</span></span> <span data-ttu-id="7068b-211">メソッドの手順の概要を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7068b-211">The following is an outline of the method's steps.</span></span>
- <span data-ttu-id="7068b-212">UI テキスト セクションに次の 3 つの四角形が作成、**タイトル**、**本文**、および**アクション**テキスト。</span><span class="sxs-lookup"><span data-stu-id="7068b-212">Three rectangles are created to section off the UI text for the **Title**, **Body**, and **Action** text.</span></span>
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

- <span data-ttu-id="7068b-213">ビットマップがという名前が作成`m_levelBitmap`を使用してアカウントを現在の DPI を考慮して**CreateBitmap**します。</span><span class="sxs-lookup"><span data-stu-id="7068b-213">A Bitmap is created named `m_levelBitmap`, taking the current DPI into account using **CreateBitmap**.</span></span>
- <span data-ttu-id="7068b-214">`m_levelBitmap` 2D のレンダー ターゲットを使用して、として設定されて[ **ID2D1DeviceContext::SetTarget**](https://msdn.microsoft.com/en-us/library/windows/desktop/hh404533)します。</span><span class="sxs-lookup"><span data-stu-id="7068b-214">`m_levelBitmap` is set as our 2D render target using [**ID2D1DeviceContext::SetTarget**](https://msdn.microsoft.com/en-us/library/windows/desktop/hh404533).</span></span>
- <span data-ttu-id="7068b-215">黒を使用して行われたすべてのピクセルのビットマップがオフになって[ **ID2D1RenderTarget::Clear**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371772)します。</span><span class="sxs-lookup"><span data-stu-id="7068b-215">The Bitmap is cleared with every pixel made black using [**ID2D1RenderTarget::Clear**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371772).</span></span>
- <span data-ttu-id="7068b-216">[**ID2D1RenderTarget::BeginDraw** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371768)描画を開始すると呼びます。</span><span class="sxs-lookup"><span data-stu-id="7068b-216">[**ID2D1RenderTarget::BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371768) is called to initiate drawing.</span></span> 
- <span data-ttu-id="7068b-217">**DrawText**に格納されているテキストを描画するために呼び出される`m_titleString`、 `m_bodyString`、および`m_actionString`、対応するを使用して approperiate 四角で**ID2D1SolidColorBrush**します。</span><span class="sxs-lookup"><span data-stu-id="7068b-217">**DrawText** is called to draw the text stored in `m_titleString`, `m_bodyString`, and `m_actionString` in the approperiate rectangle using the corresponding **ID2D1SolidColorBrush**.</span></span>
- <span data-ttu-id="7068b-218">[**ID2D1RenderTarget::EndDraw** ](ID2D1RenderTarget::EndDraw)ですべての描画操作を停止するために呼び出される`m_levelBitmap`します。</span><span class="sxs-lookup"><span data-stu-id="7068b-218">[**ID2D1RenderTarget::EndDraw**](ID2D1RenderTarget::EndDraw) is called to stop all drawing operations on `m_levelBitmap`.</span></span>
- <span data-ttu-id="7068b-219">使用して、もう 1 つのビットマップが作成された**CreateBitmap**という`m_tooSmallBitmap`環境設定の表示が小さすぎるため、ゲームのかどうかのみ表示される、フォールバックとして使用します。</span><span class="sxs-lookup"><span data-stu-id="7068b-219">Another Bitmap is created using **CreateBitmap** named `m_tooSmallBitmap` to use as a fallback, showing only if the display configuration is too small for the game.</span></span>
- <span data-ttu-id="7068b-220">描画するためのプロセスを繰り返します`m_levelBitmap`の`m_tooSmallBitmap`、今度は、文字列をのみ描画`Paused`本文。</span><span class="sxs-lookup"><span data-stu-id="7068b-220">Repeat process for drawing on `m_levelBitmap` for `m_tooSmallBitmap`, this time only drawing the string `Paused` in the body.</span></span>




<span data-ttu-id="7068b-221">今すぐ、オーバーレイの 6 つの状態のテキストを入力する 6 つのメソッドだけです。</span><span class="sxs-lookup"><span data-stu-id="7068b-221">Now all we need are six methods to fill the text of our six overlay states!</span></span>

### <a name="representing-game-state"></a><span data-ttu-id="7068b-222">ゲームの状態を表す</span><span class="sxs-lookup"><span data-stu-id="7068b-222">Representing game state</span></span>


<span data-ttu-id="7068b-223">対応するメソッドが、各ゲームでは、6 つのオーバーレイの状態、 **GameInfoOverlay**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="7068b-223">Each of the six overlay states in the game has a corresponding method in the **GameInfoOverlay** object.</span></span> <span data-ttu-id="7068b-224">これらのメソッドは、さまざまなオーバーレイを描画して、ゲーム自体に関する明示的な情報をプレイヤーに伝えます。</span><span class="sxs-lookup"><span data-stu-id="7068b-224">These methods draw a variation of the overlay to communicate explicit info to the player about the game itself.</span></span> <span data-ttu-id="7068b-225">この通信で表される、**タイトル**と**本文**文字列。</span><span class="sxs-lookup"><span data-stu-id="7068b-225">This communication is represented with a **Title** and **Body** string.</span></span> <span data-ttu-id="7068b-226">初期化時とでのリソースとこの情報のレイアウトは、既にサンプル構成されているため、 [ **GameInfoOverlay::CreateDeviceDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)メソッドだけで済みますを提供するにはオーバーレイ状態固有の文字列。</span><span class="sxs-lookup"><span data-stu-id="7068b-226">Because the sample already configured the resources and layout for this info when it was initialized and with the [**GameInfoOverlay::CreateDeviceDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104) method, it only needs to provide the overlay state-specific strings.</span></span>

<span data-ttu-id="7068b-227">**状態**オーバーレイの部分は、次の方法の 1 つの呼び出しで設定されます。</span><span class="sxs-lookup"><span data-stu-id="7068b-227">The **Status** portion of the overlay is set with a call to one of the following methods.</span></span>

<span data-ttu-id="7068b-228">ゲームの状態</span><span class="sxs-lookup"><span data-stu-id="7068b-228">Game state</span></span> | <span data-ttu-id="7068b-229">メソッドを設定します。</span><span class="sxs-lookup"><span data-stu-id="7068b-229">Status set method</span></span> | <span data-ttu-id="7068b-230">状態フィールド</span><span class="sxs-lookup"><span data-stu-id="7068b-230">Status fields</span></span>
:----- | :------- | :---------
<span data-ttu-id="7068b-231">読み込み</span><span class="sxs-lookup"><span data-stu-id="7068b-231">Loading</span></span> | [<span data-ttu-id="7068b-232">GameInfoOverlay::SetGameLoading</span><span class="sxs-lookup"><span data-stu-id="7068b-232">GameInfoOverlay::SetGameLoading</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L254-L306) |<span data-ttu-id="7068b-233">**タイトル**</span><span class="sxs-lookup"><span data-stu-id="7068b-233">**Title**</span></span></br><span data-ttu-id="7068b-234">リソースの読み込み</span><span class="sxs-lookup"><span data-stu-id="7068b-234">Loading Resources</span></span> </br><span data-ttu-id="7068b-235">**本文**</span><span class="sxs-lookup"><span data-stu-id="7068b-235">**Body**</span></span></br> <span data-ttu-id="7068b-236">段階的に出力します"."を読み込み中のアクティビティを暗示します。</span><span class="sxs-lookup"><span data-stu-id="7068b-236">Incrementally prints "." to imply loading activity.</span></span>
<span data-ttu-id="7068b-237">初期の開始/高スコア統計</span><span class="sxs-lookup"><span data-stu-id="7068b-237">Initial start/high score stats</span></span> | [<span data-ttu-id="7068b-238">GameInfoOverlay::SetGameStats</span><span class="sxs-lookup"><span data-stu-id="7068b-238">GameInfoOverlay::SetGameStats</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L310-L354) |<span data-ttu-id="7068b-239">**タイトル**</span><span class="sxs-lookup"><span data-stu-id="7068b-239">**Title**</span></span></br><span data-ttu-id="7068b-240">ハイ スコア</span><span class="sxs-lookup"><span data-stu-id="7068b-240">High Score</span></span></br> <span data-ttu-id="7068b-241">**本文**</span><span class="sxs-lookup"><span data-stu-id="7068b-241">**Body**</span></span></br> <span data-ttu-id="7068b-242">レベルに # が完了しました</span><span class="sxs-lookup"><span data-stu-id="7068b-242">Levels Completed #</span></span> </br><span data-ttu-id="7068b-243">合計ポイント #</span><span class="sxs-lookup"><span data-stu-id="7068b-243">Total Points #</span></span></br><span data-ttu-id="7068b-244">合計ショット #</span><span class="sxs-lookup"><span data-stu-id="7068b-244">Total Shots #</span></span>
<span data-ttu-id="7068b-245">レベルの開始</span><span class="sxs-lookup"><span data-stu-id="7068b-245">Level start</span></span> | [<span data-ttu-id="7068b-246">GameInfoOverlay::SetLevelStart</span><span class="sxs-lookup"><span data-stu-id="7068b-246">GameInfoOverlay::SetLevelStart</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L413-L471) |<span data-ttu-id="7068b-247">**タイトル**</span><span class="sxs-lookup"><span data-stu-id="7068b-247">**Title**</span></span></br><span data-ttu-id="7068b-248">レベル</span><span class="sxs-lookup"><span data-stu-id="7068b-248">Level #</span></span></br><span data-ttu-id="7068b-249">**本文**</span><span class="sxs-lookup"><span data-stu-id="7068b-249">**Body**</span></span></br><span data-ttu-id="7068b-250">レベルの目標の説明。</span><span class="sxs-lookup"><span data-stu-id="7068b-250">Level objective description.</span></span>
<span data-ttu-id="7068b-251">ゲームの一時停止</span><span class="sxs-lookup"><span data-stu-id="7068b-251">Game paused</span></span> | [<span data-ttu-id="7068b-252">GameInfoOverlay::SetPause</span><span class="sxs-lookup"><span data-stu-id="7068b-252">GameInfoOverlay::SetPause</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L475-L502) |<span data-ttu-id="7068b-253">**タイトル**</span><span class="sxs-lookup"><span data-stu-id="7068b-253">**Title**</span></span></br><span data-ttu-id="7068b-254">ゲームの一時停止</span><span class="sxs-lookup"><span data-stu-id="7068b-254">Game Paused</span></span></br><span data-ttu-id="7068b-255">**本文**</span><span class="sxs-lookup"><span data-stu-id="7068b-255">**Body**</span></span></br><span data-ttu-id="7068b-256">なし</span><span class="sxs-lookup"><span data-stu-id="7068b-256">None</span></span>
<span data-ttu-id="7068b-257">ゲーム オーバー</span><span class="sxs-lookup"><span data-stu-id="7068b-257">Game over</span></span> | [<span data-ttu-id="7068b-258">GameInfoOverlay::SetGameOver</span><span class="sxs-lookup"><span data-stu-id="7068b-258">GameInfoOverlay::SetGameOver</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |<span data-ttu-id="7068b-259">**タイトル**</span><span class="sxs-lookup"><span data-stu-id="7068b-259">**Title**</span></span></br><span data-ttu-id="7068b-260">ゲームは終わりました</span><span class="sxs-lookup"><span data-stu-id="7068b-260">Game Over</span></span></br> <span data-ttu-id="7068b-261">**本文**</span><span class="sxs-lookup"><span data-stu-id="7068b-261">**Body**</span></span></br> <span data-ttu-id="7068b-262">レベルに # が完了しました</span><span class="sxs-lookup"><span data-stu-id="7068b-262">Levels Completed #</span></span> </br><span data-ttu-id="7068b-263">合計ポイント #</span><span class="sxs-lookup"><span data-stu-id="7068b-263">Total Points #</span></span></br><span data-ttu-id="7068b-264">合計ショット #</span><span class="sxs-lookup"><span data-stu-id="7068b-264">Total Shots #</span></span></br><span data-ttu-id="7068b-265">レベルに # が完了しました</span><span class="sxs-lookup"><span data-stu-id="7068b-265">Levels Completed #</span></span></br><span data-ttu-id="7068b-266">高 # のスコア付け</span><span class="sxs-lookup"><span data-stu-id="7068b-266">High Score #</span></span>
<span data-ttu-id="7068b-267">勝利したゲーム</span><span class="sxs-lookup"><span data-stu-id="7068b-267">Game won</span></span> | [<span data-ttu-id="7068b-268">GameInfoOverlay::SetGameOver</span><span class="sxs-lookup"><span data-stu-id="7068b-268">GameInfoOverlay::SetGameOver</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |<span data-ttu-id="7068b-269">**タイトル**</span><span class="sxs-lookup"><span data-stu-id="7068b-269">**Title**</span></span></br><span data-ttu-id="7068b-270">あなたの勝ちです。</span><span class="sxs-lookup"><span data-stu-id="7068b-270">You WON!</span></span></br> <span data-ttu-id="7068b-271">**本文**</span><span class="sxs-lookup"><span data-stu-id="7068b-271">**Body**</span></span></br> <span data-ttu-id="7068b-272">レベルに # が完了しました</span><span class="sxs-lookup"><span data-stu-id="7068b-272">Levels Completed #</span></span> </br><span data-ttu-id="7068b-273">合計ポイント #</span><span class="sxs-lookup"><span data-stu-id="7068b-273">Total Points #</span></span></br><span data-ttu-id="7068b-274">合計ショット #</span><span class="sxs-lookup"><span data-stu-id="7068b-274">Total Shots #</span></span></br><span data-ttu-id="7068b-275">レベルに # が完了しました</span><span class="sxs-lookup"><span data-stu-id="7068b-275">Levels Completed #</span></span></br><span data-ttu-id="7068b-276">高 # のスコア付け</span><span class="sxs-lookup"><span data-stu-id="7068b-276">High Score #</span></span>




<span data-ttu-id="7068b-277">[ **GameInfoOverlay::CreateWindowSizeDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L117-L134)メソッド、サンプルは、オーバーレイの特定のリージョンに対応する 3 つの四角形領域を宣言します。</span><span class="sxs-lookup"><span data-stu-id="7068b-277">With the [**GameInfoOverlay::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L117-L134) method, the sample declared three rectangular areas that correspond to specific regions of the overlay.</span></span>



<span data-ttu-id="7068b-278">これらの領域を念頭に置いて、状態に固有のメソッドの 1 つである **GameInfoOverlay::SetGameStats** と、オーバーレイの描画方法を確認してみましょう。</span><span class="sxs-lookup"><span data-stu-id="7068b-278">With these areas in mind, let's look at one of the state-specific methods, **GameInfoOverlay::SetGameStats**, and see how the overlay is drawn.</span></span>

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

<span data-ttu-id="7068b-279">Direct2D デバイス コンテキストを使用している、 **GameInfoOverlay**オブジェクトが初期化されて、このメソッドは黒の背景ブラシを使用してでタイトルと本文の四角形を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="7068b-279">Using the Direct2D device context that the **GameInfoOverlay** object initialized, this method fills the title and body rectangles with black using the background brush.</span></span> <span data-ttu-id="7068b-280">また、白のテキスト ブラシを使って、"High Score" 文字列用のテキストをタイトルの四角形に描画し、ゲームの状態の最新情報が含まれている文字列を本文の四角形に描画します。</span><span class="sxs-lookup"><span data-stu-id="7068b-280">It draws the text for the "High Score" string to the title rectangle and a string containing the updates game state information to the body rectangle using the white text brush.</span></span>


<span data-ttu-id="7068b-281">後続の呼び出しによって、アクションの四角形が更新された[ **GameInfoOverlay::SetAction** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564)メソッドから、 **GameMain**オブジェクトで、必要なゲームの状態情報を提供します。によって**GameInfoOverlay::SetAction** 「タップして続行」など、player を適切なメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="7068b-281">The action rectangle is updated by a subsequent call to [**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564) from a method on the **GameMain** object, which provides the game state info needed by **GameInfoOverlay::SetAction** to determine the right message to the player, such as "Tap to continue".</span></span>

<span data-ttu-id="7068b-282">選択された特定の州のオーバーレイ、 [ **GameMain::SetGameInfoOverlay** ](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/GameMain.cpp#L606-L661)このようなメソッド。</span><span class="sxs-lookup"><span data-stu-id="7068b-282">The overlay for any given state is chosen in the [**GameMain::SetGameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/GameMain.cpp#L606-L661) method like this:</span></span>

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

<span data-ttu-id="7068b-283">ゲーム全体に表示される内容の切り替えの方法があるし、ゲーム、ゲームの状態に基づいてプレーヤー テキスト情報を通知するためにようになります。</span><span class="sxs-lookup"><span data-stu-id="7068b-283">Now the game has a way to communicate text info to the player based on game state, and we have a way of switching what's displayed to them throughout the game.</span></span>

### <a name="next-steps"></a><span data-ttu-id="7068b-284">次のステップ</span><span class="sxs-lookup"><span data-stu-id="7068b-284">Next steps</span></span>

<span data-ttu-id="7068b-285">次のトピックの「[コントロールの追加](tutorial--adding-controls.md)」では、プレイヤーがこのゲーム サンプルを操作する方法と、入力によってゲームの状態がどのように変わるかについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7068b-285">In the next topic, [Adding controls](tutorial--adding-controls.md), we look at how the player interacts with the game sample, and how input changes game state.</span></span>



 




