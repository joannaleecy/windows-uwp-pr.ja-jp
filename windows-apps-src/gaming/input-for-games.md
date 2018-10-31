---
author: mithom
title: ゲームの入力
description: このセクションでは、ユニバーサル Windows プラットフォーム (UWP) ゲームのゲームパッドなどの入力デバイスを操作する方法を示します。
ms.assetid: 2DD0B384-8776-4599-9E52-4FC0AA682735
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力
ms.localizationpriority: medium
ms.openlocfilehash: bb7d70c20aeb2b91d8a6db863e165e017810e924
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5866630"
---
# <a name="input-for-games"></a>ゲームの入力

このセクションでは、Windows 10 と Xbox One のユニバーサル Windows プラットフォーム (UWP) ゲームで使用可能なさまざまな種類の入力デバイスについて説明し、その基本的な使用方法を示して、ゲームで効果的な入力プログラミングについて推奨するパターンと手法を紹介します。

> **注意**    UWP ゲームに使用できる入力デバイスには、ジャンル固有またはゲーム固有のカスタム入力デバイスなど、他の種類のデバイスもあります。 そのようなデバイスとそのプログラミングについては、このセクションでは説明しません。 カスタム入力デバイスを使いやすくするインターフェイスnについて詳しくは、[Windows.Gaming.Input.Custom](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom) 名前空間をご覧ください。

## <a name="gaming-input-devices"></a>ゲーム入力デバイス

Windows 10 と Xbox One の UWP ゲームおよび UWP アプリ でのゲーム入力デバイスは、[Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) 名前空間によってサポートされています。

### <a name="gamepads"></a>ゲームパッド

ゲームパッドは Xbox One の標準入力デバイスです。一般的に、キーボードやマウスを好まない Windows のゲーマーが選びます。 ゲームパッドでは、デジタルとアナログのさまざまなコントロールを用意して、ほとんどの種類のゲームに適合させています。また、埋め込みバイブレーション モーターを使って触覚的なフィードバックも提供しています。

UWP ゲームでゲームパッドを使用する方法について詳しくは、「[ゲームパッドとバイブレーション](gamepad-and-vibration.md)」をご覧ください。

### <a name="arcade-sticks"></a>アーケード スティック

アーケード スティックは、店頭のアーケード マシンの雰囲気を再現できる完全デジタルの入力デバイスで、格闘ゲームなどのアーケード ゲームに最適な入力デバイスです。

UWP ゲームでのアーケード スティックの使用方法について詳しくは、「[アーケード スティック](arcade-stick.md)」をご覧ください。

### <a name="racing-wheels"></a>レース ホイール

レース ホイールは、実際のレーシングカーのコックピットの操縦性を模した入力デバイスで、自動車やトラックを主役にしたレーシング ゲームに最適な入力デバイスです。 多くのレース ホイールには、単なるバイブレーションではなく、真のフォース フィードバックが備わっています。フォース フィードバックでは、ハンドルなどのコントロール軸に実際の力を加えることができます。

UWP ゲームでのレース ホイールの使用方法について詳しくは、「[レース ホイールとフォースフィードバック](racing-wheel-and-force-feedback.md)」をご覧ください。

### <a name="flight-sticks"></a>フライト スティック

フライト スティックは、航空機や宇宙船のコックピットにあるフライト スティックの操作感を再現するゲームの入力デバイスです。 フライトを迅速かつ正確に制御するのに最適な入力デバイスです。

UWP ゲームでフライト スティックの使用方法の詳細については、[フライト スティック](flight-stick.md)を参照してください。

### <a name="raw-game-controllers"></a>未加工のゲーム コント ローラー

未加工のゲーム コントローラーは、さまざまな種類の一般的なゲーム コントローラーの入力を備えた、ゲーム コントローラーの汎用的な表現です。 これらの入力は、名前のないボタン、スイッチ、軸の単純な配列として公開されます。 未加工のゲーム コントローラーを使用すると、ユーザーが使っているコントローラーの種類に関係なく、カスタム入力マッピングを作成することができます。

UWP ゲームで未加工のゲーム コント ローラーを使用する方法について詳しくは、[未加工のゲーム コント ローラー](raw-game-controller.md)を参照してください。

### <a name="ui-navigation-controllers"></a>UI ナビゲーション コント ローラー

UI ナビゲーション コントローラーは、UI ナビゲーション コマンドの共通ボキャブラリを提供するために存在する論理入力デバイスです。UI ナビゲーション コマンドは、複数の異なるゲームや物理入力デバイス間に一貫性のあるユーザー エクスペリエンスを生み出します。 ゲームのユーザー インターフェイスには、デバイス固有のインターフェイスではなく、UINavigationController インターフェイスを使用するようにします。

UWP ゲームでの UI ナビゲーション コントローラーの使用方法について詳しくは、「[UI ナビゲーション コント ローラー](ui-navigation-controller.md)」をご覧ください。

### <a name="headsets"></a>ヘッドセット

ヘッドセットは、オーディオ キャプチャと再生を行うデバイスです。ヘッドセットを入力デバイス経由で接続すると、特定のユーザーに関連付けられます。 ヘッドセットは、通常ボイス チャット用オンライン ゲームで使用されます。ただし、ゲームの没入性を高めたり、オンライン ゲームとオフライン ゲームの両方でゲームプレイの機能を提供する場合にも使用できます。

UWP ゲームでのヘッドセットの使用方法について詳しくは、「[ヘッドセット](headset.md)」をご覧ください。

### <a name="users"></a>ユーザー

各入力デバイスとそこに接続するヘッドセットに特定のユーザーを関連付け、そのユーザーの ID をそのユーザーのゲームプレイにリンクすることができます。 ユーザー ID は、物理入力デバイスからの入力を論理 UI ナビゲーション コント ローラーからの入力に関連付けるための手段でもあります。

ユーザーと入力デバイスの管理方法について詳しくは、「[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)」をご覧ください。

## <a name="see-also"></a>関連項目

* [ゲームの入力プラクティス](input-practices-for-games.md)
* [Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [Windows.Gaming.Input.Custom 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input.custom)