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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5929436"
---
# <a name="add-a-user-interface"></a>ユーザー インターフェイスの追加


これで、ゲームの 3D の視覚効果が備わっています、ゲームは、プレイヤーにゲームの状態に関するフィードバックを提供できるように一部の 2D 要素を追加することに注力を勧めします。 これを単純なメニュー オプションを追加することで実現し、ヘッドアップ ディスプレイ コンポーネント上 3-D グラフィックス パイプラインの出力します。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

Direct2D を使用して、UWP DirectX ゲームを含むにさまざまなユーザー インターフェイスのグラフィックスと動作を追加します。
- [ムーブ/ルック コント ローラー](tutorial--adding-controls.md)の境界の四角形を含む、ヘッドアップ ディスプレイ
- ゲームの状態のメニュー


## <a name="the-user-interface-overlay"></a>ユーザー インターフェイスのオーバーレイ


DirectX ゲームでテキストやユーザー インターフェイス要素を表示するさまざまな方法はありますを行いましょうフォーカス[Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx)を使ってにします。 使用します[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038)をテキスト要素の場合。


Direct2D では、ピクセル ベースのプリミティブと効果を描画する描画 2D の Api のセットが使用されます。 Direct2D で起動するときは、簡単にことをお勧めします。 複雑なレイアウトやインターフェイス動作には、時間と計画が必要です。 シミュレーション ゲームや戦略ゲーム、見などの複雑なユーザー インターフェイスがゲームに必要な場合は、代わりに XAML の使用を検討してください。

> [!NOTE]
> XAML を使った UWP DirectX ゲームのユーザー インターフェイスの開発について詳しくは、[ゲーム サンプルの紹介](tutorial-resources.md)を参照してください。

Direct2D は、ユーザー インターフェイスや HTML や XAML のようなレイアウトを具体的には設計されていません。 リスト、ボックスやボタンなどのユーザー インターフェイス コンポーネントも提供しません。 Div、テーブル、グリッドなどのレイアウト コンポーネントも提供しません。


このゲーム サンプルは、2 つの主要 UI コンポーネントがあります。
1. スコアとゲーム内のコントロールのヘッドアップ ディスプレイ。
2. オーバーレイのゲームの状態のテキストと一時停止情報などのオプションを表示するために使用して、レベル開始オプションです。

### <a name="using-direct2d-for-a-heads-up-display"></a>Direct2D を使ったヘッドアップ ディスプレイ

次の図は、サンプルのゲーム内ヘッドアップ ディスプレイを示しています。 シンプルでっきり、3 D ワールドを移動して、ターゲットを撮影に集中するプレイヤーをお勧めします。 優れたインターフェイスやヘッドアップ ディスプレイする必要があることはありませんが複雑になるを処理し、ゲームのイベントに応答するプレイヤーの機能です。

![ゲーム オーバーレイのスクリーン ショット](images/simple-dx-game-ui-overlay.png)

オーバーレイは、次の基本的なプリミティブで構成されます。
- [**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)の右上隅のプレイヤーに通知するテキスト 
    - 成功した場合のヒット数
    - プレイヤーが行わショットの数
    - レベルの残り時間
    - 現在のレベルの数 
- 2 つの十字を形成するために使用する行セグメントと交差します。
- [ムーブ/ルック コント ローラー](tutorial--adding-controls.md)の境界の下隅にある 2 つの四角形です。 


オーバーレイのゲーム内ヘッドアップ ディプレイの状態が[**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L234-L358) [**GameHud**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.h)クラスのメソッドで描画されます。 以下のメソッド内で UI を表すに Direct2D オーバーレイは、時間の残り、およびレベルの数のヒット数の変更を反映するように更新されます。

追加し、ゲームに初期化されているかどうかは`TotalHits()`、 `TotalShots()`、および`TimeRemaining()` [**swprintf_s**](https://docs.microsoft.com/cpp/c-runtime-library/reference/sprintf-s-sprintf-s-l-swprintf-s-swprintf-s-l)にバッファーし、印刷形式を指定します。 [**DrawText**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd742848)方法を使用してを描画し、ことができます。 行います同じ現在のレベルのインジケーターの空の番号など、➀ 未完了のレベルを表示して、特定のレベルが完了したことを表示する塗りつぶされた ➊ 番号描画します。


次のコード スニペットは、 **GameHud::Render**メソッドのプロセスについて説明します 
- 使用してビットマップを作成する[* * ID2D1RenderTarget::DrawBitmap * *](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371880)
- UI 領域を[**D2D1::RectF**を使用して四角形に分割](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368184)
- **DrawText**を使用してテキスト要素

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

メソッドを中断して、移動、さらに、この[**GameHud::Render**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L320-L358)メソッドの描画の下、ファイアの四角[**ID2D1RenderTarget::DrawRectangle**](https://msdn.microsoft.com/library/windows/desktop/dd371902)と[**ID2D1RenderTarget::DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895)への 2 つの呼び出しを使って十字線。

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

ゲームのウィンドウでの論理サイズを格納します**GameHud::Render**メソッドで、`windowBounds`変数です。 これを使用して、 [`GetLogicalSize`](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.h#L41) **DeviceResources**クラスのメソッドです。 
```cpp
auto windowBounds = m_deviceResources->GetLogicalSize();
```

 ゲームのウィンドウのサイズの取得は、UI プログラミングに不可欠です。 ウィンドウのサイズは、Dip (デバイスに依存しないピクセル)、1/96 インチとして、DIP が定義されていると呼ばれる単位で指定します。 Direct2D 拡大/縮小実際のピクセルに描画単位描画が発生すると、Windows のドット/インチ (DPI) 設定を使用してこれを行います。 同様に、 [**DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)を使ってテキストを描画するときは、フォントのサイズにポイントではなく Dip を設定します。 DIP は、浮動小数点数として表されます。

 

### <a name="displaying-game-state-info"></a>ゲームの状態情報を表示します。

ヘッドアップ ディスプレイ、ゲーム サンプルにはあり 6 つのゲームの状態を表すオーバーレイします。 すべての状態には、プレイヤーが読むテキスト、大きな黒の四角形のプリミティブが機能します。 アクティブでないこれらの状態であるために、ムーブ/ルック コント ローラーの四角形と十字線は描画されません。

ゲームの状態に合わせて自動的に表示するテキストを切り替えることが可能、 [**GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.h)クラスを使用してオーバーレイが作成されます。

![状態とオーバーレイの動作を確認します。](images/simple-dx-game-ui-finaloverlay.png)

オーバーレイが 2 つのセクションに分割:**状態**と**動作を確認**します。 **状態**のセクションは、**タイトル**と**本文**の四角形にさらに分類されます。 **操作**のセクションには、1 つの四角形にのみです。 それぞれの四角形では、さまざまな目的があります。

-   `titleRectangle` タイトルのテキストが含まれています。
-   `bodyRectangle` 本文のテキストが含まれています。
-   `actionRectangle` 特定の操作を実行するプレイヤーに通知するテキストが含まれています。

ゲームは、6 つの状態を設定することができます。 伝える、オーバーレイの**状態**の一部を使用して、ゲームの状態。 多くの次の状態に対応するメソッドを使用して**状態**の四角形が更新されます。

- 読み込み中
- 最初の開始/ハイ スコアの統計
- レベル開始
- ゲームが一時停止
- ゲーム オーバー
- ゲームの終了


オーバーレイの**操作**部分を更新するには、次のいずれかに設定するアクションのテキストを許可する[**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564)メソッドを使用します。
- 「タップして、もう一度プレイ.」
- 「レベルの読み込み, お待ちください.」
- 「タップして続行.」
- なし

> [!NOTE]
> どちらの方法が説明されている[ゲームの状態を表す](#representing-game-state)」で詳しくします。

ゲームでは、**状態**および**操作**のセクションで、何が起こってに応じて、テキスト フィールドが調整されます。
初期化し、これら 6 つの状態のオーバーレイを描画する方法を見てみましょう。

### <a name="initializing-and-drawing-the-overlay"></a>オーバーレイの初期化と描画

**6 つの状態**を共通の点がいくつかある、リソースとメソッドを行う必要があるとよく似ています。
    - 黒の四角形を背景として、画面の中央すべて使います。
    - 表示されるテキストは、**タイトル**または**本体**のいずれかのテキストです。
    - テキストは Segoe UI フォントが使用され、黒の四角形の上に描画されます。 


このゲーム サンプルでは、オーバーレイを作成するときに効果を発揮する 4 つのメソッドがあります。
 

#### <a name="gameinfooverlaygameinfooverlay"></a>GameInfoOverlay::GameInfoOverlay
[**GameInfoOverlay::GameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L30-L78)コンス トラクターにプレイヤーに情報を表示するにはこれを使ってビットマップ サーフェスを維持し、オーバーレイを初期化します。 コンス トラクターは、アプリに渡される、これを使ってオーバーレイ オブジェクト自身に描画することができます[**ID2D1DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/hh404479)を作成する[**ID2D1Device**](https://msdn.microsoft.com/library/windows/desktop/hh404478)オブジェクトからファクトリを取得します。 [IDWriteFactory::CreateTextFormat](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368203) 


#### <a name="gameinfooverlaycreatedevicedependentresources"></a>Gameinfooverlay::createdevicedependentresources
[**Gameinfooverlay::createdevicedependentresources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)は、テキストを描画するために使用するブラシを作成するための方法です。 これを行うには、しますにより、作成する[**ID2D1DeviceContext2**](https://msdn.microsoft.com/en-us/library/windows/desktop/dn890789)オブジェクトを取得し、ジオメトリの描画インクとグラデーションなどの機能とメッシュ レンダリングします。 一連の色を folling UI 要素を描画する[**ID2D1SolidColorBrush**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd372207)を使ってブラシを作成します。
- 四角形の背景に黒のブラシ
- 状態のテキストの白のブラシ
- アクションのテキストのオレンジ色のブラシ

#### <a name="deviceresourcessetdpi"></a>DeviceResources::SetDpi
[**DeviceResources::SetDpi**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L514-L527)メソッドは、ウィンドウの 1 インチあたりのドットを設定します。 このメソッドは、DPI が変更されする必要があるときに呼び出されます取得ゲームのウィンドウのサイズが変更されたときの動作を再調整します。 このメソッドは、DPI を更新した後、ウィンドウのサイズが変更されるたびに必要なリソースを再作成を確認する[**deviceresources::createwindowsizedependentresources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L214-L487)も呼び出します。


#### <a name="gameinfooverlaycreatewindowssizedependentresources"></a>GameInfoOverlay::CreateWindowsSizeDependentResources
[**GameInfoOverlay::CreateWindowsSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L108-L225)メソッドは、すべての描画が行われるです。 メソッドの手順の概要を次に示します。
- 次の 3 つの四角形は、セクション**タイトル**、**本文**、および**操作**のテキストの UI テキストを無効に作成されます。
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

- 名前付きビットマップが作成`m_levelBitmap`、考慮現在 DPI **CreateBitmap**を使用します。
- `m_levelBitmap` 当社の 2D レンダリング[**ID2D1DeviceContext::SetTarget**](https://msdn.microsoft.com/en-us/library/windows/desktop/hh404533)を使用してターゲットとして設定されます。
- ビットマップが行われたすべてのピクセルでクリアされると黒の[**ID2D1RenderTarget::Clear**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371772)を使用します。
- [**ID2D1RenderTarget::BeginDraw**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371768)は、描画を開始すると呼ばれます。 
- **DrawText**に格納されているテキストを描画すると呼ばれる`m_titleString`、`m_bodyString`と`m_actionString`で対応する**ID2D1SolidColorBrush**を使用してされる四角形です。
- [**ID2D1RenderTarget::EndDraw**](ID2D1RenderTarget::EndDraw)が上のすべての描画操作を停止すると呼ばれる`m_levelBitmap`します。
- **CreateBitmap**という名前を使用して別のビットマップを作成`m_tooSmallBitmap`表示の構成は、ゲームに対して小さすぎるかどうかにのみ表示、フォールバックとして使用します。
- に描画するためのプロセスを繰り返す`m_levelBitmap`の`m_tooSmallBitmap`、今回は、文字列を描画のみ`Paused`本文。




6 つのメソッドを 6 つのオーバーレイの状態のテキストの入力は必要がありますすべてできるようになりました!

### <a name="representing-game-state"></a>ゲームの状態を表す


ゲームの 6 つのオーバーレイの状態の各により、 **GameInfoOverlay**オブジェクトに対応するメソッドがあります。 これらのメソッドは、さまざまなオーバーレイを描画して、ゲーム自体に関する明示的な情報をプレイヤーに伝えます。 この通信は、**タイトル**と**本文**文字列で表されます。 サンプルでは、リソースとレイアウトの初期化時にこの情報や[**gameinfooverlay::createdevicedependentresources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)メソッドを使用して既に構成されている、ためのみ、オーバーレイの状態に固有の文字列を提供する必要があります。

以下のメソッドのいずれかを呼び出すことで、オーバーレイの**状態**の一部が設定されています。

ゲームの状態 | 状態の set メソッド | 状態フィールド
:----- | :------- | :---------
読み込み中 | [GameInfoOverlay::SetGameLoading](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L254-L306) |**Title (タイトル)**</br>リソースの読み込み </br>**本文**</br> 段階的に印刷"."読み込みアクティビティを意味します。
最初の開始/ハイ スコアの統計 | [Gameinfooverlay::setgamestats](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L310-L354) |**Title (タイトル)**</br>ハイ スコア</br> **本文**</br> レベル完了 # </br>合計ポイント #</br>合計ショット #
レベル開始 | [GameInfoOverlay::SetLevelStart](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L413-L471) |**Title (タイトル)**</br>レベル</br>**本文**</br>レベルで目的の説明。
ゲームが一時停止 | [GameInfoOverlay::SetPause](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L475-L502) |**Title (タイトル)**</br>ゲームが一時停止</br>**本文**</br>なし
ゲーム オーバー | [GameInfoOverlay::SetGameOver](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |**Title (タイトル)**</br>ゲームは終わりました</br> **本文**</br> レベル完了 # </br>合計ポイント #</br>合計ショット #</br>レベル完了 #</br>ハイ スコア #
ゲームの終了 | [GameInfoOverlay::SetGameOver](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |**Title (タイトル)**</br>勝利しました!</br> **本文**</br> レベル完了 # </br>合計ポイント #</br>合計ショット #</br>レベル完了 #</br>ハイ スコア #




[**GameInfoOverlay::CreateWindowSizeDependentResources**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L117-L134)メソッドでは、サンプルは、オーバーレイの特定の地域に対応する 3 つの四角形領域を宣言します。



これらの領域を念頭に置いて、状態に固有のメソッドの 1 つである **GameInfoOverlay::SetGameStats** と、オーバーレイの描画方法を確認してみましょう。

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

**GameInfoOverlay**オブジェクトを初期化する Direct2D デバイス コンテキストを使用して、このメソッドは黒い背景ブラシを使用してタイトルと本文の四角形を塗りつぶします。 また、白のテキスト ブラシを使って、"High Score" 文字列用のテキストをタイトルの四角形に描画し、ゲームの状態の最新情報が含まれている文字列を本文の四角形に描画します。


操作の四角形は、後続の呼び出しで[**GameInfoOverlay::SetAction**](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564) **GameInfoOverlay::SetAction**によってに対する適切なメッセージを判断するために必要なゲームの状態情報を提供する**GameMain**オブジェクトのメソッドから更新しますプレーヤーでは、「タップして、引き続き」などです。

特定の状態のオーバーレイは、このような[**GameMain::SetGameInfoOverlay**](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/GameMain.cpp#L606-L661)メソッドで選択されます。

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

ゲームがゲームの状態に基づいて、プレイヤーにテキスト情報をやり取りする方法とゲーム全体に表示される内容を切り替える方法が用意されています。

### <a name="next-steps"></a>次のステップ

次のトピックの「[コントロールの追加](tutorial--adding-controls.md)」では、プレイヤーがこのゲーム サンプルを操作する方法と、入力によってゲームの状態がどのように変わるかについて説明します。



 




