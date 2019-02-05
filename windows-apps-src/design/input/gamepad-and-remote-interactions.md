---
author: Karl-Bridge-Microsoft
Description: Optimize your app for input from Xbox gamepad and remote control.
title: ゲームパッドとリモコンの操作
ms.assetid: 784a08dc-2736-4bd3-bea0-08da16b1bd47
label: Gamepad and remote interactions
template: detail.hbs
isNew: true
ms.author: kbridge
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 022724064ad1e7f5551b6676bf256ca5cf6e4b8e
ms.sourcegitcommit: bf600a1fb5f7799961914f638061986d55f6ab12
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/05/2019
ms.locfileid: "9048559"
---
# <a name="gamepad-and-remote-control-interactions"></a>ゲームパッドとリモコンの操作

![キーボードとゲームパッドのイメージ](images/keyboard/keyboard-gamepad.jpg)

***一般的な対話式操作パターンは、ゲームパッド、リモコン、およびキーボードの間で共有されます。***

アプリがゲームパッドやリモコンで正しく動作するか確認することは、10 フィート エクスペリエンス向けの最適化で最も重要な手順です。 操作がある程度制限されたデバイスでユーザーの対話式操作エクスペリエンスを最適化できる、ゲームパッドやリモコン固有の改善点がいくつかあります。

ユニバーサル Windows プラットフォーム (UWP) アプリでは、ゲームパッドとリモコンの入力がサポートされます。 

ゲームパッドとリモコンは、Xbox とテレビのエクスペリエンスのための主要な入力デバイスです。 

UWP アプリはこれらの入力デバイスに最適化される必要があります。これは PC ではキーボードとマウスに最適化し、スマートフォンやタブレットではタッチ入力に最適化することと同様です。 

Xbox とテレビに最適化する場合には、アプリがこれらの入力デバイスで十分に機能することを確認することが最も重要なステップです。

PC 上の UWP アプリで、ゲームパッドをプラグインして使用できます。これにより検証が容易に行えます。

UWP アプリでのゲームパッドやリモコンを使ったユーザー エクスペリエンスが十分に満足の行くものであることを確認するには、次のことを考慮します。

* [ハードウェア ボタン](../devices/designing-for-tv.md#hardware-buttons) - ゲームパッドとリモコンでは、異なるボタンと構成を提供します。

* [XY フォーカス ナビゲーションと操作](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction) - XY フォーカス ナビゲーションを使って、ユーザーがアプリの UI 間を移動できるようにします。

* [マウス モード](../devices/designing-for-tv.md#mouse-mode) - XY フォーカス ナビゲーションでは十分でない場合、マウス モードを使うことで、アプリでマウスのエクスペリエンスをエミュレートできます。
