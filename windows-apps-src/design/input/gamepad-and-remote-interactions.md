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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7294482"
---
# <a name="gamepad-and-remote-control-interactions"></a><span data-ttu-id="5e2a5-103">ゲームパッドとリモコンの操作</span><span class="sxs-lookup"><span data-stu-id="5e2a5-103">Gamepad and remote control interactions</span></span>

![リモートと方向パッド](images/dpad-remote/dpad-remote.png)

<span data-ttu-id="5e2a5-105">ユニバーサル Windows プラットフォーム (UWP) アプリでは、ゲームパッドとリモコンの入力がサポートされます。ゲームパッドとリモコンは、Xbox とテレビのエクスペリエンスのための主要な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-105">Universal Windows Platform (UWP) apps now support gamepad and remote control input, which are the primary input devices for Xbox and TV experiences.</span></span>

<span data-ttu-id="5e2a5-106">UWP アプリはこれらの入力デバイスに最適化される必要があります。これは PC ではキーボードとマウスに最適化し、スマートフォンやタブレットではタッチ入力に最適化することと同様です。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-106">UWP apps should be optimized for these input device types, just like they are for keyboard and mouse input on a PC, and touch input on a phone or tablet.</span></span>

<span data-ttu-id="5e2a5-107">Xbox とテレビに最適化する場合には、アプリがこれらの入力デバイスで十分に機能することを確認することが重要なステップです。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-107">Making sure that your app works well with these input devices is a critical  step when optimizing for Xbox and the TV.</span></span>

> [!NOTE] 
> <span data-ttu-id="5e2a5-108">PC 上の UWP アプリで、ゲームパッドをプラグインして使用できます。これにより検証が容易に行えます。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-108">You can now plug in and use the gamepad with UWP apps on PC which makes validating the work easy.</span></span>

<span data-ttu-id="5e2a5-109">UWP アプリでのゲームパッドやリモコンを使ったユーザー エクスペリエンスが十分に満足の行くものであることを確認するには、次のことを考慮します。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-109">To ensure a successful and enjoyable user experience for your UWP app when using a gamepad or remote control, you should consider the following:</span></span>

* <span data-ttu-id="5e2a5-110">[ハードウェア ボタン](../devices/designing-for-tv.md#hardware-buttons) - ゲームパッドとリモコンでは、異なるボタンと構成を提供します。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-110">[Hardware buttons](../devices/designing-for-tv.md#hardware-buttons) - The gamepad and remote provide very different buttons and configurations.</span></span>

* <span data-ttu-id="5e2a5-111">[XY フォーカス ナビゲーションと操作](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction) - XY フォーカス ナビゲーションを使って、ユーザーがアプリの UI 間を移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-111">[XY focus navigation and interaction](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction) - XY focus navigation enables the user to navigate around your app's UI.</span></span>

* <span data-ttu-id="5e2a5-112">[マウス モード](../devices/designing-for-tv.md#mouse-mode) - XY フォーカス ナビゲーションでは十分でない場合、マウス モードを使うことで、アプリでマウスのエクスペリエンスをエミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="5e2a5-112">[Mouse mode](../devices/designing-for-tv.md#mouse-mode) - Mouse mode lets your app emulate a mouse experience when XY focus navigation isn't sufficient.</span></span>
