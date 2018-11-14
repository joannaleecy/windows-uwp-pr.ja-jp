---
author: eliotcowley
title: ゲーム コントローラーのレジストリ データ
description: UWP ゲームで使用されるコントローラーを有効にするために、PC のレジストリに追加できるデータについて説明します。
ms.assetid: 2DD0B384-8776-4599-9E52-4FC0AA682735
ms.author: wdg-dev-content
ms.date: 06/25/2018
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, レジストリ, カスタム
ms.localizationpriority: medium
ms.openlocfilehash: 4bbd4074c52514b9cb66fd6f2dd189421f61d5ee
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6192272"
---
# <a name="registry-data-for-game-controllers"></a>ゲーム コントローラーのレジストリ データ

> [!NOTE]
> このトピックは、Windows 10 互換のゲーム コントローラーの製造元向けです。開発者の大部分には適用されません。

[Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)を使うと、独立系ハードウェア ベンダー (IHV) は、PC のレジストリにデータを追加して、デバイスが [Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad)、[RacingWheels](https://docs.microsoft.com/uwp/api/windows.gaming.input.racingwheel)、[ArcadeSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightSticks](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.flightstick)、[UINavigationControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller) として表示されるようにできます。 互換性のあるコントローラー用にこのデータを追加することを、すべての IHV に推奨します。 これにより、すべての UWP ゲーム (および WinRT API を使用するすべてのデスクトップ ゲーム) でゲーム コントローラーをサポートできます。

## <a name="mapping-scheme"></a>マッピング スキーム

デバイスのマッピングとして、ベンダー ID (VID) **VVVV**、製品 ID (PID) **PPPP**、使用ページ **UUUU**、使用 ID **XXXX** が、レジストリのこの場所から読み込まれます。

`HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\VVVVPPPPUUUUXXXX`

次の表は、デバイスのルートの場所で予期される値を示します。

<table>
    <tr>
        <th>名前</th>
        <th>種類</th>
        <th>必須かどうか</th>
        <th>情報</th>
    </tr>
    <tr>
        <td>Disabled</td>
        <td>DWORD</td>
        <td>いいえ</td>
        <td>
            <p>この特定のデバイスを無効にすることを示します。</p>
            <ul>
                <li><b>0</b>: デバイスは無効ではありません。</li>
                <li><b>1</b>: デバイスは無効です。</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>説明</td>
        <td>REG_SZ <td>必須ではない</td>
        <td>デバイスの簡単な説明です。</td>
    </tr>
</table>

デバイスのインストーラーが (セットアップ、または [INF ファイル](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)によって) このデータをレジストリに追加する必要があります。

デバイスのルートの場所の下のサブキーは、次のセクションで詳しく説明します。

### <a name="gamepad"></a>Gamepad

次の表は **Gamepad** サブキーの下の必須およびオプションのサブキーを示します。

<table>
    <tr>
        <th>サブキー</th>
        <th>必須かどうか</th>
        <th>情報</th>
    </tr>
    <tr>
        <td>Menu</td>
        <td>必須</td>
        <td rowspan="18" style="vertical-align: middle;">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>View</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>A</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>B</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>X</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Y</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>LeftShoulder</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>RightShoulder</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>LeftThumbstickButton</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>RightThumbstickButton</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>DPadUp</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>DPadDown</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>DPadLeft</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>DPadRight</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Paddle1</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Paddle2</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Paddle3</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Paddle4</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>LeftTrigger</td>
        <td>必須</td>
        <td rowspan="6" style="vertical-align: middle;">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>RightTrigger</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>LeftThumbstickX</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>LeftThumbstickY</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>RightThumbstickX</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>RightThumbstickY</td>
        <td>必須</td>
    </tr>
</table>

> [!NOTE]
> サポートされる **Gamepad** として、ゲーム コントローラーを追加する場合には、サポートされる **UINavigationController** としても、ゲーム コントローラーを追加することを強く推奨します。

### <a name="racingwheel"></a>RacingWheel

次の表は **RacingWheel** サブキーの下の必須およびオプションのサブキーを示します。

<table>
    <tr>
        <th>サブキー</th>
        <th>必須かどうか</th>
        <th>情報</th>
    </tr>
    <tr>
        <td>PreviousGear</td>
        <td>必須</td>
        <td rowspan="30" style="vertical-align: middle;">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>NextGear</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>DPadUp</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>DPadDown</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>DPadLeft</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>DPadRight</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button1</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button2</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button3</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button4</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button5</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button6</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button7</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button8</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button9</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button10</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button11</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button12</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button13</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button14</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button15</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Button16</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>FirstGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SecondGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>ThirdGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>FourthGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>FifthGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SixthGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SeventhGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>ReverseGear</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Wheel</td>
        <td>必須</td>
        <td rowspan="5" style="vertical-align: middle;">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>Throttle</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Brake</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Clutch</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Handbrake</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>MaxWheelAngle</td>
        <td>必須</td>
        <td>「<a href="#properties-mapping">プロパティ マッピング</a>」をご覧ください</td>
    </tr>
</table>

### <a name="arcadestick"></a>ArcadeStick

次の表は **ArcadeStick** サブキーの下の必須およびオプションのサブキーを示します。

<table>
    <tr>
        <th>サブキー</th>
        <th>必須かどうか</th>
        <th>情報</th>
    </tr>
    <tr>
        <td>Action1</td>
        <td>必須</td>
        <td rowspan="12" style="vertical-align: middle;">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>Action2</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Action3</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Action4</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Action5</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Action6</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Special1</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Special2</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>StickUp</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>StickDown</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>StickLeft</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>StickRight</td>
        <td>必須</td>
    </tr>
</table>

### <a name="flightstick"></a>FlightStick

次の表は **FlightStick** サブキーの下の必須およびオプションのサブキーを示します。

<table>
    <tr>
        <th>サブキー</th>
        <th>必須かどうか</th>
        <th>情報</th>
    </tr>
    <tr>
        <td>FirePrimary</td>
        <td>必須</td>
        <td rowspan="2" style="vertical-align: middle;">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>FireSecondary</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Roll</td>
        <td>必須</td>
        <td rowspan="4" style="vertical-align: middle;">「<a href="#axis-mapping">軸のマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>Pitch</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Yaw</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Throttle</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>HatSwitch</td>
        <td>必須</td>
        <td>「<a href="#switch-mapping">スイッチのマッピング</a>」をご覧ください</td>
    </tr>
</table>

### <a name="uinavigation"></a>UINavigation

次の表は **UINavigation** サブキーの下の必須およびオプションのサブキーを示します。

<table>
    <tr>
        <th>サブキー</th>
        <th>必須かどうか</th>
        <th>情報</th>
    </tr>
    <tr>
        <td>Menu</td>
        <td>必須</td>
        <td rowspan="24" style="vertical-align: middle;">「<a href="#button-mapping">ボタンのマッピング</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>View</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Accept</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Cancel</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>PrimaryUp</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>PrimaryDown</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>PrimaryLeft</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>PrimaryRight</td>
        <td>必須</td>
    </tr>
    <tr>
        <td>Context1</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Context2</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Context3</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>Context4</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>PageUp</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>PageDown</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>PageLeft</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>PageRight</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>ScrollUp</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>ScrollDown</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>ScrollLeft</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>ScrollRight</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SecondaryUp</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SecondaryDown</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SecondaryLeft</td>
        <td>必須ではない</td>
    </tr>
    <tr>
        <td>SecondaryRight</td>
        <td>必須ではない</td>
    </tr>
</table>

UI ナビゲーション コントローラーと上記のコマンドについて詳しくは、「[UI ナビゲーション コントローラー](https://docs.microsoft.com/windows/uwp/gaming/ui-navigation-controller)」をご覧ください。

## <a name="keys"></a>キー

次のセクションでは、**Gamepad**、**RacingWheel**、**ArcadeStick**、**FlightStick**、**UINavigation** キーの下のサブキーのそれぞれのコンテンツについて説明します。

### <a name="button-mapping"></a>ボタンのマッピング

次の表は、ボタンのマッピングに必要な値を示します。 たとえば、ゲーム コントローラーの **DPadUp** キーを押すと、**DPadUp** のマッピングには **ButtonIndex** 値が含まれます (**Source** は **Button** です)。 **DPadUp** がスイッチの位置からマッピングされる必要がある場合は、**DPadUp** マッピングには **SwitchIndex** と **SwitchPosition** の値が含まれます (**Source** は **Switch** です)。

<table>
    <tr>
        <th>Source (ソース)</th>
        <th>値の名前</th>
        <th>値の種類</th>
        <th>必須かどうか</th>
        <th>値の情報</th>
    </tr>
    <tr>
        <td>Button</td>
        <td>ButtonIndex</td>
        <td>DWORD</td>
        <td>必須</td>
        <td><b>RawGameController</b> ボタンの配列のインデックス。</td>
    </tr>
    <tr>
        <td rowspan="4" style="vertical-align: middle;">Axis</td>
        <td>AxisIndex</td>
        <td>DWORD</td>
        <td>必須</td>
        <td><b>RawGameController</b> 軸の配列のインデックス。</td>
    </tr>
    <tr>
        <td>Invert</td>
        <td>DWORD</td>
        <td>必須ではない</td>
        <td><b>ThresholdPercent</b> と <b>DebouncePercent</b> 要素を適用する前に、軸の値を反転する必要があることを示します。</td>
    </tr>
    <tr>
        <td>ThresholdPercent</td>
        <td>DWORD</td>
        <td>必須</td>
        <td>マッピングされたボタンの値の (押した状態と離した状態の間の) 遷移の軸の位置を示します。 有効な値の範囲は 0 から 100 です。 軸の値がこの値以上の場合、ボタンが押されたと見なされます。</td>
    </tr>
    <tr>
        <td>DebouncePercent</td>
        <td>DWORD</td>
        <td>必須</td>
        <td>
            <p><b>ThresholdPercent</b> 値の周囲のウィンドウのサイズを定義します。報告されたボタンの状態をデバウンスするために使用されます。 有効な値の範囲は 0 から 100 です。 ボタンの状態の遷移は、軸の値がデバウンス ウィンドウの上限または下限を超えたときにのみ発生します。 たとえば、<b>ThresholdPercent</b> が 50 で、<b>DebouncePercent</b> が 10 の場合には、デバウンスの下限と上限は、全範囲の軸の値で 45% と 55% となります。 軸の値が 55% 以上に達すると、ボタンは押された状態に遷移し、軸の値が 45% 以下に達すると、ボタンはリリースされた状態に戻ります。</p>
            <p>計算されるデバウンス ウィンドウの境界は 0% ～ 100% の間でクランプされます。 たとえば、しきい値が 5% で、デバウンス ウィンドウが 20% の場合、デバウンス ウィンドウの境界は 0% と 15% となります。 しきい値とデバウンスの値にかかわらず、軸の値が 0% ～ 100% にあるボタンの状態は常に、押されるか、または離されるかとして報告されます。</p>
        </td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;">Switch</td>
        <td>SwitchIndex</td>
        <td>DWORD</td>
        <td>必須</td>
        <td><b>RawGameController</b> スイッチの配列のインデックス。</td>
    </tr>
    <tr>
        <td>SwitchPosition</td>
        <td>REG_SZ</td>
        <td>必須</td>
        <td>
            <p>マッピングされたボタンが押されたことを報告するスイッチの位置を示します。 位置の値には、次の文字列のいずれかを指定できます。</p>
            <ul>
                <li>Up</li> 
                <li>UpRight</li>
                <li>Right</li>
                <li>DownRight</li>
                <li>Down</li>
                <li>DownLeft</li>
                <li>Left</li>
                <li>UpLeft</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>IncludeAdjacent</td>
        <td>DWORD</td>
        <td>必須ではない</td>
        <td>隣接するスイッチの位置も、マッピングされたボタンが押されたことを報告することを示します。</td>
    </tr>
</table>

### <a name="axis-mapping"></a>軸のマッピング

次の表は、軸のマッピングに必要な値を示します。

<table>
    <tr>
        <th>Source (ソース)</th>
        <th>値の名前</th>
        <th>値の種類</th>
        <th>必須かどうか</th>
        <th>値の情報</th>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;">Button</td>
        <td>MaxValueButtonIndex</td>
        <td>DWORD</td>
        <td>必須</td>
        <td>
            <p>マッピングされた一方向の軸の値に変換される、<b>RawGameController</b> ボタンの配列のインデックス。</p>
            <table>
                <tr>
                    <th>MaxButton</th>
                    <th>AxisValue</th>
                </tr>
                <tr>
                    <td>FALSE</td>
                    <td>0.0</td>
                </tr>
                <tr>
                    <td>TRUE</td>
                    <td>1.0</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>MinValueButtonIndex</td>
        <td>DWORD</td>
        <td>必須ではない</td>
        <td>
            <p>マッピングされた軸が双方向であることを示します。 <b>MaxButton</b> と <b>MinButton</b> の値は結合され、次に示すように 1 つの双方向の軸となります。</p>
            <table>
                <tr>
                    <th>MinButton</th>
                    <th>MaxButton</th>
                    <th>AxisValue</th>
                </tr>
                <tr>
                    <td>FALSE</td>
                    <td>FALSE</td>
                    <td>0.5</td>
                </tr>
                <tr>
                    <td>FALSE</td>
                    <td>TRUE</td>
                    <td>1.0</td>
                </tr>
                <tr>
                    <td>TRUE</td>
                    <td>FALSE</td>
                    <td>0.0</td>
                </tr>
                <tr>
                    <td>TRUE</td>
                    <td>TRUE</td>
                    <td>0.5</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td rowspan="2" style="vertical-align: middle;">Axis</td>
        <td>AxisIndex</td>
        <td>DWORD</td>
        <td>必須</td>
        <td><b>RawGameController</b> 軸の配列のインデックス。</td>
    </tr>
    <tr>
        <td>Invert</td>
        <td>DWORD</td>
        <td>必須ではない</td>
        <td>マッピングされた軸の値を返す前に反転するかどうかを示します。</td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;">Switch</td>
        <td>SwitchIndex</td>
        <td>DWORD</td>
        <td>必須</td>
        <td><b>RawGameController</b> スイッチの配列のインデックス。
    </tr>
    <tr>
        <td>MaxValueSwitchPosition</td>
        <td>REG_SZ</td>
        <td>必須</td>
        <td>
            <p>次のいずれかの文字列です。</p>
            <ul>
                <li>Up</li>
                <li>UpRight</li>
                <li>Right</li>
                <li>DownRight</li>
                <li>Down</li>
                <li>DownLeft</li>
                <li>Left</li>
                <li>UpLeft</li>
            </ul>
            <p>マッピングされた軸の値が 1.0 として報告されるスイッチの位置を示します。 反対方向の <b>MaxValueSwitchPosition</b> は 0.0 と見なされます。 たとえば、<b>MaxValueSwitchPosition</b> が <b>Up</b> の場合、軸の値は次を意味します。</p>
            <table>
                <tr>
                    <th>スイッチの位置</th>
                    <th>AxisValue</th>
                </tr>
                <tr>
                    <td>Up</td>
                    <td>1.0</td>
                </tr>
                <tr>
                    <td>Center</td>
                    <td>0.5</td>
                </tr>
                <tr>
                    <td>Down</td>
                    <td>0.0</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>IncludeAdjacent</td>
        <td>DWORD</td>
        <td>必須ではない</td>
        <td>
            <p>隣接するスイッチの位置も、マッピングされた軸が 1.0 を報告することを示します。 上記の例では、<b>IncludeAdjacent</b> が設定されている場合、軸は次のようになります。</p>
            <table>
                <tr>
                    <th>スイッチの位置</th>
                    <th>AxisValue</th>
                </tr>
                <tr>
                    <td>Up</td>
                    <td>1.0</td>
                </tr>
                <tr>
                    <td>UpRight</td>
                    <td>1.0</td>
                </tr>
                <tr>
                    <td>UpLeft</td>
                    <td>1.0</td>
                </tr>
                <tr>
                    <td>Center</td>
                    <td>0.5</td>
                </tr>
                <tr>
                    <td>Down</td>
                    <td>0.0</td>
                </tr>
                <tr>
                    <td>DownRight</td>
                    <td>0.0</td>
                </tr>
                <tr>
                    <td>DownLeft</td>
                    <td>0.0</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

### <a name="switch-mapping"></a>スイッチのマッピング

スイッチの位置は、**RawGameController** のボタンの配列のボタンのセットから、またはスイッチの配列のインデックスからマッピングされます。 軸からスイッチの位置をマッピングすることはできません。

<table>
    <tr>
        <th>Source (ソース)</th>
        <th>値の名前</th>
        <th>値の種類</th>
        <th>値の情報</th>
    </tr>
    <tr>
        <td rowspan="10" style="vertical-align: middle;">Button</td>
        <td>ButtonCount</td>
        <td>DWORD</td>
        <td>2、4、または 8</td>
    </tr>
    <tr>
        <td>SwitchKind</td>
        <td>REG_SZ</td>
        <td><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b>
    </tr>
    <tr>
        <td>UpButtonIndex</td>
        <td>DWORD</td>
        <td rowspan="8" style="vertical-align: middle;">「<a href="#buttonindex-values">*ButtonIndex の値</a>」をご覧ください</td>
    </tr>
    <tr>
        <td>DownButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>LeftButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>RightButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>UpRightButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>DownRightButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>DownLeftButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>UpLeftButtonIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td rowspan="9" style="vertical-align: middle;">Axis</td>
        <td>SwitchKind</td>
        <td>REG_SZ</td>
        <td><b>TwoWay</b>、<b>FourWay</b>、または<b>EightWay</b></td>
    </tr>
    <tr>
        <td>XAxisIndex</td>
        <td>DWORD</td>
        <td rowspan="2" style="vertical-align: middle;"><b>YAxisIndex</b> は常に存在します。 <b>XAxisIndex</b> は、<b>SwitchKind</b> が <b>FourWay</b> または <b>EightWay</b> の場合のみ存在します。</td>
    </tr>
    <tr>
        <td>YAxisIndex</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>XDeadZonePercent</td>
        <td>DWORD</td>
        <td rowspan="2" style="vertical-align: middle;">軸の中央位置の周囲のデッド ゾーンのサイズを示します。</td>
    </tr>
    <tr>
        <td>YDeadZonePercent</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>XDebouncePercent</td>
        <td>DWORD</td>
        <td rowspan="2" style="vertical-align: middle;">デッド ゾーンの上限と下限の周囲のウィンドウのサイズを定義します。これは報告されたスイッチの状態のデバウンスに使用されます。</td>
    </tr>
    <tr>
        <td>YDebouncePercent</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td>XInvert</td>
        <td>DWORD</td>
        <td rowspan="2" style="vertical-align: middle;">デッド ゾーンとデバウンス ウィンドウの計算を適用する前に、対応する軸の値を反転する必要があることを示します。</td>
    </tr>
    <tr>
        <td>YInvert</td>
        <td>DWORD</td>
    </tr>
    <tr>
        <td rowspan="3" style="vertical-align: middle;">Switch</td>
        <td>SwitchIndex</td>
        <td>DWORD</td>
        <td><b>RawGameController</b> スイッチの配列のインデックス。
    </tr>
    <tr>
        <td>Invert</td>
        <td>DWORD</td>
        <td>スイッチが位置を、既定の時計回りの順序ではなく、反時計回りの順序で報告することを示します。</td>
    </tr>
    <tr>
        <td>PositionBias</td>
        <td>DWORD</td>
        <td>
            <p>位置の報告の開始点を指定した量だけ移動します。 <b>PositionBias</b> は常に元の開始点から時計回りにカウントされます。値の順序が反転される前に適用されます。</p>
            <p>たとえば、<b>DownRight</b>で始まる位置を反時計回りの順序で報告するスイッチは、<b>Invert</b> フラグを設定して、<b>PositionBias</b> を 5 と設定することによって正規化されます。</p>
            <table>
                <tr>
                    <th>位置</th>
                    <th>報告される値</th>
                    <th>PositionBias と Invert フラグの設定後</th>
                </tr>
                <tr>
                    <td>DownRight</td>
                    <td>0</td>
                    <td>3</td>
                </tr>
                <tr>
                    <td>Right</td>
                    <td>1</td>
                    <td>2</td>
                </tr>
                <tr>
                    <td>UpRight</td>
                    <td>2</td>
                    <td>1</td>
                </tr>
                <tr>
                    <td>Up</td>
                    <td>3</td>
                    <td>0</td>
                </tr>
                <tr>
                    <td>UpLeft</td>
                    <td>4</td>
                    <td>7</td>
                </tr>
                <tr>
                    <td>Left</td>
                    <td>5</td>
                    <td>6</td>
                </tr>
                <tr>
                    <td>DownLeft</td>
                    <td>6</td>
                    <td>5</td>
                </tr>
                <tr>
                    <td>Down</td>
                    <td>7</td>
                    <td>4</td>
                </tr>
            </table>
    </tr>
</table>

#### <a name="buttonindex-values"></a>*ButtonIndex の値

**RawGameController** のボタンの配列への \*ButtonIndex の値のインデックス:

<table>
    <tr>
        <th>ButtonCount</th>
        <th>SwitchKind</th>
        <th>RequiredMappings</th>
    </tr>
    <tr>
        <td>2</td>
        <td>TwoWay</td>
        <td>
            <ul>
                <li>UpButtonIndex</li>
                <li>DownButtonIndex</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>4</td>
        <td>FourWay</td>
        <td>
            <ul>
                <li>UpButtonIndex</li>
                <li>DownButtonIndex</li>
                <li>LeftButtonIndex</li>
                <li>RightButtonIndex</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>4</td>
        <td>EightWay</td>
        <td>
            <ul>
                <li>UpButtonIndex</li>
                <li>DownButtonIndex</li>
                <li>LeftButtonIndex</li>
                <li>RightButtonIndex</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>8</td>
        <td>EightWay</td>
        <td>
            <ul>
                <li>UpButtonIndex</li>
                <li>DownButtonIndex</li>
                <li>LeftButtonIndex</li>
                <li>RightButtonIndex</li>
                <li>UpRightButtonIndex</li>
                <li>DownRightButtonIndex</li>
                <li>DownLeftButtonIndex</li>
                <li>UpLeftButtonIndex</li>
            </ul>
        </td>
    </tr>
</table>

### <a name="properties-mapping"></a>プロパティ マッピング

これらは、別のマッピングの種類の、静的マッピング値です。

<table>
    <tr>
        <th>マッピング</th>
        <th>値の名前</th>
        <th>値の種類</th>
        <th>値の情報</th>
    </tr>
    <tr>
        <td>RacingWheel</td>
        <td>MaxWheelAngle</td>
        <td>DWORD</td>
        <td>ホイールでサポートされている、単一方向の物理ホイールの最大角度を示します。 たとえば、-90 度から 90 度まで回転できるホイールでは、90 を指定します。</td>
    </tr>
</table>

## <a name="labels"></a>Labels

ラベルは、デバイス ルートの下の **Labels** キーの下に存在する必要があります。 **Labels** は 3 つのサブキー: **Buttons**、**Axes**、**Switches** を持つことができます。

### <a name="button-labels"></a>ボタンのラベル

**Buttons** キーは、**RawGameController** のボタンの配列の各ボタンの位置を文字列にマッピングします。 各文字列は、対応する [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) 列挙値に内部的にマッピングされます。 たとえば、ゲームパッドに 10 個のボタンと、**RawGameController** がボタンを解析してボタンを表示する順序がある場合、レポートは次のようになります。

```cpp
Menu,               // Index 0
View,               // Index 1
LeftStickButton,    // Index 2
RightStickButton,   // Index 3
LetterA,            // Index 4
LetterB,            // Index 5
LetterX,            // Index 6
LetterY,            // Index 7
LeftBumper,         // Index 8
RightBumper         // Index 9
```

ラベルは **Buttons** キーの下にこの順序で表示されます。

<table>
    <tr>
        <th>名前</th>
        <th>値 (種類: REG_SZ)</th>
    </tr>
    <tr>
        <td>Button0</td>
        <td>Menu</td>
    </tr>
    <tr>
        <td>Button1</td>
        <td>View</td>
    </tr>
    <tr>
        <td>Button2</td>
        <td>LeftStickButton</td>
    </tr>
    <tr>
        <td>Button3</td>
        <td>RightStickButton</td>
    </tr>
    <tr>
        <td>Button4</td>
        <td>LetterA</td>
    </tr>
    <tr>
        <td>Button5</td>
        <td>LetterB</td>
    </tr>
    <tr>
        <td>Button6</td>
        <td>LetterX</td>
    </tr>
    <tr>
        <td>Button7</td>
        <td>LetterY</td>
    </tr>
    <tr>
        <td>Button8</td>
        <td>LeftBumper</td>
    </tr>
    <tr>
        <td>Button9</td>
        <td>RightBumper</td>
    </tr>
</table>

### <a name="axis-labels"></a>軸ラベル

**Axes** キーは、**RawGameController** の軸の配列の各軸の位置を、ボタンのラベルのように、[GameControllerButtonLabel Enum](https://docs.microsoft.com/en-us/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) に一覧表示されたラベルの 1 つにマッピングします。 「[ボタンのラベル](#button-labels)」の例をご覧ください。

### <a name="switch-labels"></a>スイッチのラベル

**Switches** キーはスイッチの位置をラベルにマッピングします。 値は次の名前付け規則に従います: インデックスが **RawGameController** のスイッチの配列の *x*であるスイッチの位置にラベルを付けるには、次の値を **Switches** サブキーの下に追加します。 

* SwitchxUp 
* SwitchxUpRight 
* SwitchxRight
* SwitchxDownRight
* SwitchxDown
* SwitchxDownLeft
* SwitchxUpLeft
* SwitchxLeft

次の表は、4 方向スイッチの位置が **RawGameController** でインデックス 0 を示しているスイッチにラベルを付ける例を示しています。 

<table>
    <tr>
        <th>名前</th>
        <th>値 (種類: REG_SZ)</th>
    </tr>
    <tr>
        <td>Switch0Up</td>
        <td>XboxUp</td>
    </tr>
    <tr>
        <td>Switch0Right</td>
        <td>XboxRight</td>
    </tr>
    <tr>
        <td>Switch0Down</td>
        <td>XboxDown</td>
    </tr>
    <tr>
        <td>Switch0Left</td>
        <td>XboxLeft</td>
    </tr>
</table>

<!--### Label strings

* XboxBack
* XboxStart
* XboxMenu
* XboxView
* XboxUp
* XboxDown
* XboxLeft
* XboxRight
* XboxA
* XboxB
* XboxX
* XboxY
* XboxLeftBumper
* XboxLeftTrigger
* XboxLeftStickButton
* XboxRightBumper
* XboxRightTrigger
* XboxRightStickButton
* XboxPaddle1
* XboxPaddle2
* XboxPaddle3
* XboxPaddle4
* Mode
* Select
* Menu
* View
* Back
* Start
* Options
* Share
* Up
* Down
* Left
* Right
* LetterA
* LetterB
* LetterC
* LetterL
* LetterR
* LetterX
* LetterY
* LetterZ
* Cross
* Circle
* Square
* Triangle
* LeftBumper
* LeftTrigger
* LeftStickButton
* Left1
* Left2
* Left3
* RightBumper
* RightTrigger
* RightStickButton
* Right1
* Right2
* Right3
* Paddle1
* Paddle2
* Paddle3
* Paddle4
* Plus
* Minus
* DownLeftArrow
* DialLeft
* DialRight
* Suspension-->

## <a name="example-registry-file"></a>レジストリ ファイルの例

これらのマッピングと値のすべての例を示すため、汎用の **RacingWheel** のレジストリ ファイルを示す次の例をご覧ください。

```
Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004]
"Description" = "Example Wheel Device"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\Labels\Buttons]
"Button0" = "LetterA"
"Button1" = "LetterB"
"Button2" = "LetterX"
"Button3" = "LetterY"
"Button6" = "Menu"
"Button7" = "View"
"Button8" = "RightStickButton"
"Button9" = "LeftStickButton"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\Labels\Switches]
"Switch0Down" = "Down"
"Switch0Left" = "Left"
"Switch0Right" = "Right"
"Switch0Up" = "Up"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel]
"MaxWheelAngle" = dword:000001c2

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Brake]
"AxisIndex" = dword:00000002
"Invert" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button1]
"ButtonIndex" = dword:00000000

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button2]
"ButtonIndex" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button3]
"ButtonIndex" = dword:00000002

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button4]
"ButtonIndex" = dword:00000003

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button5]
"ButtonIndex" = dword:00000009

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button6]
"ButtonIndex" = dword:00000008

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button7]
"ButtonIndex" = dword:00000007

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Button8]
"ButtonIndex" = dword:00000006

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Clutch]
"AxisIndex" = dword:00000003
"Invert" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadDown]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Down"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadLeft]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Left"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadRight]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Right"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\DPadUp]
"IncludeAdjacent" = dword:00000001
"SwitchIndex" = dword:00000000
"SwitchPosition" = "Up"

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\FifthGear]
"ButtonIndex" = dword:00000010

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\FirstGear]
"ButtonIndex" = dword:0000000c

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\FourthGear]
"ButtonIndex" = dword:0000000f

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\NextGear]
"ButtonIndex" = dword:00000004

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\PreviousGear]
"ButtonIndex" = dword:00000005

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\ReverseGear]
"ButtonIndex" = dword:0000000b

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\SecondGear]
"ButtonIndex" = dword:0000000d

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\SixthGear]
"ButtonIndex" = dword:00000011

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\ThirdGear]
"ButtonIndex" = dword:0000000e

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Throttle]
"AxisIndex" = dword:00000001
"Invert" = dword:00000001

[HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\GameInput\Devices\1234567800010004\RacingWheel\Wheel]
"AxisIndex" = dword:00000000
"Invert" = dword:00000000
```

## <a name="see-also"></a>関連項目

* [Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [Windows.Gaming.Input.Custom 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom)
* [INF ファイル](https://docs.microsoft.com/windows-hardware/drivers/install/inf-files)