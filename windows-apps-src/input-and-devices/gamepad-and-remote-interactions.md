---
author: mijacobs
Description: TODO
title: "ゲームパッドとリモコンの操作"
ms.assetid: 784a08dc-2736-4bd3-bea0-08da16b1bd47
label: Gamepad and remote interactions
template: detail.hbs
isNew: true
ms.author: mijacobs
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: b1ee5409cfca253b3bb084b95365d22526c66920
ms.lasthandoff: 02/07/2017

---

# <a name="gamepad-and-remote-control-interactions"></a>ゲームパッドとリモコンの操作

ユニバーサル Windows プラットフォーム (UWP) アプリでは、ゲームパッドとリモコンの入力がサポートされます。 ゲームパッドとリモコンは、Xbox とテレビのエクスペリエンスのための主要な入力デバイスです。 UWP アプリはこれらの入力デバイスに最適化される必要があります。これは PC ではキーボードとマウスに最適化し、スマートフォンやタブレットではタッチ入力に最適化することと同様です。 Xbox とテレビに最適化する場合には、アプリがこれらの入力デバイスで十分に機能することを確認することが最も重要なステップです。
PC 上の UWP アプリで、ゲームパッドをプラグインして使用できます。これにより検証が容易に行えます。

UWP アプリでのゲームパッドやリモコンを使ったユーザー エクスペリエンスが十分に満足の行くものであることを確認するには、次のことを考慮します。

* [ハードウェア ボタン](designing-for-tv.md#hardware-buttons) -
ゲームパッドとリモコンは異なるボタンと構成を提供します。

* [XY フォーカス ナビゲーションと操作](designing-for-tv.md#xy-focus-navigation-and-interaction) -
ユーザーは XY フォーカス ナビゲーションを使うことで、アプリの UI を移動できます。

* [マウス モード](designing-for-tv.md#mouse-mode) -
マウス モードは、XY フォーカス ナビゲーションでは十分でないときに、アプリでマウスのエクスペリエンスをエミュレートします。

