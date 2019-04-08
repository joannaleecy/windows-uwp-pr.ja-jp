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
# <a name="add-a-user-interface"></a>ユーザー インターフェイスの追加


これで、ゲームでは、場所にその 3D ビジュアルが含まれるゲームがプレーヤーにゲームの状態に関するフィードバックを提供できるように、いくつかの 2D 要素を追加することに集中する時間を勧めします。 これは単純なメニュー オプションを追加することで実現でき、3-D グラフィックスの上にヘッドアップ ディスプレイのコンポーネントが出力をパイプラインします。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

Direct2D を使用して、UWP の DirectX ゲームなどを多数のユーザー インターフェイスのグラフィックスと動作を追加します。
- ヘッドアップを表示するなど[移動外観コント ローラー](tutorial--adding-controls.md)四角形の境界
- ゲームの状態のメニュー


## <a name="the-user-interface-overlay"></a>ユーザー インターフェイスのオーバーレイ


DirectX ゲームにテキストおよびユーザー インターフェイス要素を表示するさまざまな方法はありますが、ここにフォーカスを使用して[Direct2D](https://msdn.microsoft.com/library/windows/apps/dd370990.aspx)します。 使用することも[DirectWrite](https://msdn.microsoft.com/library/windows/desktop/dd368038)のテキスト要素です。


Direct2D は、ピクセル ベース プリミティブと効果を描画するために一連の 2D 描画 Api を使用します。 以降 Direct2D では、ときに、複雑にならないことをお勧めします。 複雑なレイアウトやインターフェイス動作には、時間と計画が必要です。 ゲームには、シミュレーションと戦略ゲームなどに見られるよう、複雑なユーザー インターフェイスが必要な場合は、代わりに XAML の使用を検討してください。

> [!NOTE]
> XAML と DirectX の UWP ゲームでのユーザー インターフェイスの開発方法の詳細については、次を参照してください。[ゲームのサンプルを拡張する](tutorial-resources.md)します。

Direct2D はされていないユーザー インターフェイスまたは HTML と XAML のようなレイアウトを具体的には設計されています。 これにより、リスト、ボックス、またはボタンのようなユーザー インターフェイス コンポーネントが用意されていません。 Div、テーブル、またはグリッドなどのレイアウトのコンポーネントも提供されません。


このゲームのサンプルについては、2 つの主な UI コンポーネントがあります。
1. スコアおよびゲーム内のコントロールのヘッドアップ ディスプレイ。
2. オーバーレイのゲームの状態のテキストと一時停止の情報などのオプションを表示するために使用し、レベルがオプションを開始します。

### <a name="using-direct2d-for-a-heads-up-display"></a>Direct2D を使ったヘッドアップ ディスプレイ

次の図は、サンプルのゲームのヘッドアップ ディスプレイを示します。 単純ですっきり、プレーヤーに 3D の世界を移動して、ターゲットを撮影できるようにします。 適切なインターフェイスまたはヘッドアップ ディスプレイをする必要がありますは処理、ゲームでは、イベントに対応してプレイヤーの機能を決して複雑にします。

![ゲーム オーバーレイのスクリーン ショット](images/simple-dx-game-ui-overlay.png)

オーバーレイは、次の基本的なプリミティブで構成されます。
- [**DirectWrite** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)のプレーヤーに通知する右上隅にあるテキスト 
    - 成功したヒット数
    - プレーヤーが行われたショットの数
    - レベルの残りの期間
    - 現在のレベル数 
- 2 つの十字を形成するために使用する線分の交差しません。
- 2 つの四角形の画面の下隅にある、[移動外観コント ローラー](tutorial--adding-controls.md)境界。 


オーバーレイのゲームのヘッドアップ ディスプレイの状態で表示されます、 [ **GameHud::Render** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L234-L358)のメソッド、 [ **GameHud** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.h)クラス。 このメソッド内に残りとレベルの数のヒット数の変更を反映するように、Direct2D のオーバーレイを表す、UI が更新されます。

ゲームが初期化されたかどうかは追加`TotalHits()`、 `TotalShots()`、および`TimeRemaining()`に、 [ **swprintf_s** ](https://docs.microsoft.com/cpp/c-runtime-library/reference/sprintf-s-sprintf-s-l-swprintf-s-swprintf-s-l)バッファーし、印刷の形式を指定します。 使用して描画できますし、 [ **DrawText** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd742848)メソッド。 同じ現在のレベルのインジケーターの描画など ➀、未完了のレベルを表示する空の番号と ➊ など、特定のレベルが完了したことを表示するの塗りつぶされた番号。


次のコード スニペットの説明、 **GameHud::Render**のメソッドの処理 
- 使用して、ビットマップを作成する[* * ID2D1RenderTarget::DrawBitmap * *](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371880)
- UI 領域を使用して四角形に分割[ **D2D1::RectF**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368184)
- 使用して**DrawText**テキスト要素を作成するには

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

この部分にさらに、下のメソッドの重大な[ **GameHud::Render** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameHud.cpp#L320-L358)メソッドは、移行を描画を四角形の起動と[ **ID2D1RenderTarget::DrawRectangle**](https://msdn.microsoft.com/library/windows/desktop/dd371902)、十字線を 2 つの呼び出しを使用して、 [ **ID2D1RenderTarget::DrawLine**](https://msdn.microsoft.com/library/windows/desktop/dd371895)します。

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

**GameHud::Render**メソッドでゲームのウィンドウの論理サイズ格納、`windowBounds`変数。 これを使用して、 [ `GetLogicalSize` ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.h#L41)のメソッド、 **DeviceResources**クラス。 
```cpp
auto windowBounds = m_deviceResources->GetLogicalSize();
```

 ゲームのウィンドウのサイズの取得は、UI プログラミングに不可欠です。 ウィンドウのサイズが 1/96 インチ単位として、DIP が定義されている Dip (デバイス非依存ピクセル) と呼ばれるで与えられます。 Direct2D スケーリング図面の単位を実際のピクセルが図面が発生したときに Windows ドット/インチ (DPI) 設定を使用して、そいます。 同様に、描画するとテキストを使用して[ **DirectWrite**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368038)フォントのサイズの点ではなく、Dip を指定します。 DIP は、浮動小数点数として表されます。

 

### <a name="displaying-game-state-info"></a>ゲームの状態情報を表示します。

ヘッドアップ ディスプレイ、だけでなくは、ゲームのサンプルは、6 つのゲームの状態を表すオーバーレイが。 すべての状態の機能を読み取るプレーヤー テキストに大きな黒い長方形プリミティブ。 非アクティブ状態であるために、コント ローラーの四角形を移動外観や十字線は描画されません。

使用して、オーバーレイを作成、 [ **GameInfoOverlay** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.h)クラス、ゲームの状態の連携を表示するテキストを切り替えることができます。

![状態とオーバーレイのアクション](images/simple-dx-game-ui-finaloverlay.png)

オーバーレイは、2 つのセクションに分割されます。**ステータス**と**アクション**します。 **状態**にさらに分類がセクション**タイトル**と**本文**四角形。 **アクション**セクションには 1 つの四角形。 各四角形は、別の目的があります。

-   `titleRectangle` タイトルのテキストが含まれています。
-   `bodyRectangle` 本文のテキストが含まれています。
-   `actionRectangle` 特定のアクションを実行するプレーヤーを通知するテキストが含まれています。

ゲームでは、設定可能な 6 つの状態があります。 使用して伝達ゲームの状態、**状態**オーバーレイの部分。 **状態**四角形は、さまざまな状態に対応するメソッドを使用して更新されます。

- 読み込み
- 初期の開始/高スコア統計
- レベルの開始
- ゲームの一時停止
- ゲーム オーバー
- 勝利したゲーム


**アクション**を使用して、オーバーレイの部分を更新、 [ **GameInfoOverlay::SetAction** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564)メソッドを次のいずれかに設定するアクション テキストを許可します。
- 「... もう一度再生してタップします」
- 「レベルの読み込み、お待ちください...」
- "Tap to continue..."
- なし

> [!NOTE]
> どちらの方法については、説明でさらに、[ゲームの状態を表す](#representing-game-state)セクション。

によって、ゲームでは、何が起こって、**状態**と**アクション**セクションのテキスト フィールドが調整されます。
初期化し、これら 6 つの状態のオーバーレイを描く方法を見てみましょう。

### <a name="initializing-and-drawing-the-overlay"></a>オーバーレイの初期化と描画

6 つ**ステータス**状態は、いくつかの点を共通のあるリソースのメソッドを行う必要があるとよく似ています。
    - 画面の中央に黒の四角形を使用、すべてが背景と。
    - 表示されるテキストがあるか、**タイトル**または**本文**テキスト。
    - テキストは、Segoe UI フォントが使用され、バックの四角形の上に描画されます。 


ゲームのサンプルでは、オーバーレイを作成するときに影響する 4 つのメソッドがあります。
 

#### <a name="gameinfooverlaygameinfooverlay"></a>GameInfoOverlay::GameInfoOverlay
[ **GameInfoOverlay::GameInfoOverlay** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L30-L78)コンス トラクターに、プレーヤーに情報を表示するに使用するビットマップの画面を維持、オーバーレイを初期化します。 コンス トラクターから工場出荷時の取得、 [ **ID2D1Device** ](https://msdn.microsoft.com/library/windows/desktop/hh404478)オブジェクトの作成に使用するように渡される、 [ **ID2D1DeviceContext** ](https://msdn.microsoft.com/library/windows/desktop/hh404479)オーバーレイはオブジェクト自体を描画できます。 [IDWriteFactory::CreateTextFormat](https://msdn.microsoft.com/en-us/library/windows/desktop/dd368203) 


#### <a name="gameinfooverlaycreatedevicedependentresources"></a>GameInfoOverlay::CreateDeviceDependentResources
[**GameInfoOverlay::CreateDeviceDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)メソッドは、テキストの描画に使用されるブラシを作成します。 これを行うには、取得、 [ **ID2D1DeviceContext2** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dn890789)オブジェクトを作成できるようにし、ジオメトリの描画インクとグラデーションなどの機能とメッシュをレンダリングします。 一連の色のブラシを使用して作成し[ **ID2D1SolidColorBrush** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd372207) folling の UI 要素を描画します。
- 四角形の背景に黒のブラシ
- 状態のテキストのブラシを白
- オレンジ色のブラシをアクション テキスト

#### <a name="deviceresourcessetdpi"></a>DeviceResources::SetDpi
[ **DeviceResources::SetDpi** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L514-L527)メソッドは、ウィンドウのインチあたりのドットを設定します。 このメソッドは、DPI が変更されする必要があるときに呼び出されますゲームのウィンドウのサイズが変更されたときの動作を再調整されます。 このメソッドを DPI を更新した後はも[**DeviceResources::CreateWindowSizeDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Common/DeviceResources.cpp#L214-L487)たびに、ウィンドウのサイズを変更することを確認して必要なリソースが再作成します。


#### <a name="gameinfooverlaycreatewindowssizedependentresources"></a>GameInfoOverlay::CreateWindowsSizeDependentResources
[ **GameInfoOverlay::CreateWindowsSizeDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L108-L225)メソッドは、すべての描画が行われる場所。 メソッドの手順の概要を次に示します。
- UI テキスト セクションに次の 3 つの四角形が作成、**タイトル**、**本文**、および**アクション**テキスト。
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

- ビットマップがという名前が作成`m_levelBitmap`を使用してアカウントを現在の DPI を考慮して**CreateBitmap**します。
- `m_levelBitmap` 2D のレンダー ターゲットを使用して、として設定されて[ **ID2D1DeviceContext::SetTarget**](https://msdn.microsoft.com/en-us/library/windows/desktop/hh404533)します。
- 黒を使用して行われたすべてのピクセルのビットマップがオフになって[ **ID2D1RenderTarget::Clear**](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371772)します。
- [**ID2D1RenderTarget::BeginDraw** ](https://msdn.microsoft.com/en-us/library/windows/desktop/dd371768)描画を開始すると呼びます。 
- **DrawText**に格納されているテキストを描画するために呼び出される`m_titleString`、 `m_bodyString`、および`m_actionString`、対応するを使用して approperiate 四角で**ID2D1SolidColorBrush**します。
- [**ID2D1RenderTarget::EndDraw** ](ID2D1RenderTarget::EndDraw)ですべての描画操作を停止するために呼び出される`m_levelBitmap`します。
- 使用して、もう 1 つのビットマップが作成された**CreateBitmap**という`m_tooSmallBitmap`環境設定の表示が小さすぎるため、ゲームのかどうかのみ表示される、フォールバックとして使用します。
- 描画するためのプロセスを繰り返します`m_levelBitmap`の`m_tooSmallBitmap`、今度は、文字列をのみ描画`Paused`本文。




今すぐ、オーバーレイの 6 つの状態のテキストを入力する 6 つのメソッドだけです。

### <a name="representing-game-state"></a>ゲームの状態を表す


対応するメソッドが、各ゲームでは、6 つのオーバーレイの状態、 **GameInfoOverlay**オブジェクト。 これらのメソッドは、さまざまなオーバーレイを描画して、ゲーム自体に関する明示的な情報をプレイヤーに伝えます。 この通信で表される、**タイトル**と**本文**文字列。 初期化時とでのリソースとこの情報のレイアウトは、既にサンプル構成されているため、 [ **GameInfoOverlay::CreateDeviceDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L82-L104)メソッドだけで済みますを提供するにはオーバーレイ状態固有の文字列。

**状態**オーバーレイの部分は、次の方法の 1 つの呼び出しで設定されます。

ゲームの状態 | メソッドを設定します。 | 状態フィールド
:----- | :------- | :---------
読み込み | [GameInfoOverlay::SetGameLoading](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L254-L306) |**Title**</br>リソースの読み込み </br>**本文**</br> 段階的に出力します"."を読み込み中のアクティビティを暗示します。
初期の開始/高スコア統計 | [GameInfoOverlay::SetGameStats](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L310-L354) |**Title**</br>ハイ スコア</br> **本文**</br> レベルに # が完了しました </br>合計ポイント #</br>合計ショット #
レベルの開始 | [GameInfoOverlay::SetLevelStart](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L413-L471) |**Title**</br>レベル</br>**本文**</br>レベルの目標の説明。
ゲームの一時停止 | [GameInfoOverlay::SetPause](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L475-L502) |**Title**</br>ゲームの一時停止</br>**本文**</br>なし
ゲーム オーバー | [GameInfoOverlay::SetGameOver](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |**Title**</br>ゲームは終わりました</br> **本文**</br> レベルに # が完了しました </br>合計ポイント #</br>合計ショット #</br>レベルに # が完了しました</br>高 # のスコア付け
勝利したゲーム | [GameInfoOverlay::SetGameOver](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L358-L409) |**Title**</br>あなたの勝ちです。</br> **本文**</br> レベルに # が完了しました </br>合計ポイント #</br>合計ショット #</br>レベルに # が完了しました</br>高 # のスコア付け




[ **GameInfoOverlay::CreateWindowSizeDependentResources** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L117-L134)メソッド、サンプルは、オーバーレイの特定のリージョンに対応する 3 つの四角形領域を宣言します。



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

Direct2D デバイス コンテキストを使用している、 **GameInfoOverlay**オブジェクトが初期化されて、このメソッドは黒の背景ブラシを使用してでタイトルと本文の四角形を塗りつぶします。 また、白のテキスト ブラシを使って、"High Score" 文字列用のテキストをタイトルの四角形に描画し、ゲームの状態の最新情報が含まれている文字列を本文の四角形に描画します。


後続の呼び出しによって、アクションの四角形が更新された[ **GameInfoOverlay::SetAction** ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameInfoOverlay.cpp#L522-L564)メソッドから、 **GameMain**オブジェクトで、必要なゲームの状態情報を提供します。によって**GameInfoOverlay::SetAction** 「タップして続行」など、player を適切なメッセージを確認します。

選択された特定の州のオーバーレイ、 [ **GameMain::SetGameInfoOverlay** ](https://github.com/Microsoft/Windows-universal-samples/blob/6370138b150ca8a34ff86de376ab6408c5587f5d/Samples/Simple3DGameXaml/cpp/GameMain.cpp#L606-L661)このようなメソッド。

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

ゲーム全体に表示される内容の切り替えの方法があるし、ゲーム、ゲームの状態に基づいてプレーヤー テキスト情報を通知するためにようになります。

### <a name="next-steps"></a>次のステップ

次のトピックの「[コントロールの追加](tutorial--adding-controls.md)」では、プレイヤーがこのゲーム サンプルを操作する方法と、入力によってゲームの状態がどのように変わるかについて説明します。



 




