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
# <a name="gamepad-and-remote-control-interactions"></a><span data-ttu-id="dda53-103">ゲームパッドとリモコンの操作</span><span class="sxs-lookup"><span data-stu-id="dda53-103">Gamepad and remote control interactions</span></span>

![キーボードとゲームパッドのイメージ](images/keyboard/keyboard-gamepad.jpg)

***<span data-ttu-id="dda53-105">一般的な対話式操作パターンは、ゲームパッド、リモコン、およびキーボードの間で共有されます。</span><span class="sxs-lookup"><span data-stu-id="dda53-105">Common interaction patterns are shared between gamepad, remote control, and keyboard</span></span>***

<span data-ttu-id="dda53-106">アプリがゲームパッドやリモコンで正しく動作するか確認することは、10 フィート エクスペリエンス向けの最適化で最も重要な手順です。</span><span class="sxs-lookup"><span data-stu-id="dda53-106">Making sure that your app works well with gamepad and remote is the most important step in optimizing for 10-foot experiences.</span></span> <span data-ttu-id="dda53-107">操作がある程度制限されたデバイスでユーザーの対話式操作エクスペリエンスを最適化できる、ゲームパッドやリモコン固有の改善点がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="dda53-107">There are several gamepad and remote-specific improvements that you can make to optimize the user interaction experience on a device where their actions are somewhat limited.</span></span>

<span data-ttu-id="dda53-108">ユニバーサル Windows プラットフォーム (UWP) アプリでは、ゲームパッドとリモコンの入力がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="dda53-108">Universal Windows Platform (UWP) apps now support gamepad and remote control input.</span></span> 

<span data-ttu-id="dda53-109">ゲームパッドとリモコンは、Xbox とテレビのエクスペリエンスのための主要な入力デバイスです。</span><span class="sxs-lookup"><span data-stu-id="dda53-109">Gamepads and remote controls are the primary input devices for Xbox and TV experiences.</span></span> 

<span data-ttu-id="dda53-110">UWP アプリはこれらの入力デバイスに最適化される必要があります。これは PC ではキーボードとマウスに最適化し、スマートフォンやタブレットではタッチ入力に最適化することと同様です。</span><span class="sxs-lookup"><span data-stu-id="dda53-110">UWP apps should be optimized for these input device types, just like they are for keyboard and mouse input on a PC, and touch input on a phone or tablet.</span></span> 

<span data-ttu-id="dda53-111">Xbox とテレビに最適化する場合には、アプリがこれらの入力デバイスで十分に機能することを確認することが最も重要なステップです。</span><span class="sxs-lookup"><span data-stu-id="dda53-111">Making sure that your app works well with these input devices is the most important step when optimizing for Xbox and the TV.</span></span>

<span data-ttu-id="dda53-112">PC 上の UWP アプリで、ゲームパッドをプラグインして使用できます。これにより検証が容易に行えます。</span><span class="sxs-lookup"><span data-stu-id="dda53-112">You can now plug in and use the gamepad with UWP apps on PC which makes validating the work easy.</span></span>

<span data-ttu-id="dda53-113">UWP アプリでのゲームパッドやリモコンを使ったユーザー エクスペリエンスが十分に満足の行くものであることを確認するには、次のことを考慮します。</span><span class="sxs-lookup"><span data-stu-id="dda53-113">To ensure a successful and enjoyable user experience for your UWP app when using a gamepad or remote control, you should consider the following:</span></span>

* <span data-ttu-id="dda53-114">[ハードウェア ボタン](../devices/designing-for-tv.md#hardware-buttons) - ゲームパッドとリモコンでは、異なるボタンと構成を提供します。</span><span class="sxs-lookup"><span data-stu-id="dda53-114">[Hardware buttons](../devices/designing-for-tv.md#hardware-buttons) - The gamepad and remote provide very different buttons and configurations.</span></span>

* <span data-ttu-id="dda53-115">[XY フォーカス ナビゲーションと操作](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction) - XY フォーカス ナビゲーションを使って、ユーザーがアプリの UI 間を移動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="dda53-115">[XY focus navigation and interaction](../devices/designing-for-tv.md#xy-focus-navigation-and-interaction) - XY focus navigation enables the user to navigate around your app's UI.</span></span>

* <span data-ttu-id="dda53-116">[マウス モード](../devices/designing-for-tv.md#mouse-mode) - XY フォーカス ナビゲーションでは十分でない場合、マウス モードを使うことで、アプリでマウスのエクスペリエンスをエミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="dda53-116">[Mouse mode](../devices/designing-for-tv.md#mouse-mode) - Mouse mode lets your app emulate a mouse experience when XY focus navigation isn't sufficient.</span></span>
