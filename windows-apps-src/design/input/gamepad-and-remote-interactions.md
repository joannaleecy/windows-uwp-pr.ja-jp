---
author: mijacobs
Description: TODO
title: ゲームパッドとリモコンの操作
ms.assetid: 784a08dc-2736-4bd3-bea0-08da16b1bd47
label: Gamepad and remote interactions
template: detail.hbs
isNew: true
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a3e87fea7dfce66b16ccdf04ef13950c092660c8
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6976003"
---
# <a name="gamepad-and-remote-control-interactions"></a>ゲームパッドとリモコンの操作

![リモートと方向パッド](images/dpad-remote/dpad-remote.png)

ユニバーサル Windows プラットフォーム (UWP) アプリでは、ゲームパッドとリモコンの入力がサポートされます。ゲームパッドとリモコンは、Xbox とテレビのエクスペリエンスのための主要な入力デバイスです。

UWP アプリはこれらの入力デバイスに最適化される必要があります。これは PC ではキーボードとマウスに最適化し、スマートフォンやタブレットではタッチ入力に最適化することと同様です。

Xbox とテレビに最適化する場合には、アプリがこれらの入力デバイスで十分に機能することを確認することが重要なステップです。

> [!NOTE] 
> PC 上の UWP アプリで、ゲームパッドをプラグインして使用できます。これにより検証が容易に行えます。

UWP アプリでのゲームパッドやリモコンを使ったユーザー エクスペリエンスが十分に満足の行くものであることを確認するには、次のことを考慮します。

* [ハードウェア ボタン](../devices/designing-for-tv.md#hardware-buttons) - ゲームパッドとリモコンでは、異なるボタンと構成を提供します。

* [XY フォーカス ナビゲーションと操作](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction) - XY フォーカス ナビゲーションを使って、ユーザーがアプリの UI 間を移動できるようにします。

* [マウス モード](../devices/designing-for-tv.md#mouse-mode) - XY フォーカス ナビゲーションでは十分でない場合、マウス モードを使うことで、アプリでマウスのエクスペリエンスをエミュレートできます。
