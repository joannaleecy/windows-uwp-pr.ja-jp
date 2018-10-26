---
title: デバイス
description: Direct3D デバイスは、Direct3D のレンダリング コンポーネントです。 デバイスは、レンダリングの状態をカプセル化して格納します。また、変換や照明の操作、サーフェスへのイメージのラスタライズを実行します。
ms.assetid: BC903462-A32A-46BA-8411-FB294F5D2CD9
keywords:
- デバイス
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: d1c35af3dd1f8826fbd61268c5c47cef9d77146a
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5642411"
---
# <a name="devices"></a><span data-ttu-id="b6044-105">デバイス</span><span class="sxs-lookup"><span data-stu-id="b6044-105">Devices</span></span>


<span data-ttu-id="b6044-106">Direct3D デバイスは、Direct3D のレンダリング コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="b6044-106">A Direct3D device is the rendering component of Direct3D.</span></span> <span data-ttu-id="b6044-107">デバイスは、レンダリングの状態をカプセル化して格納します。また、変換や照明の操作、サーフェスへのイメージのラスタライズを実行します。</span><span class="sxs-lookup"><span data-stu-id="b6044-107">A device encapsulates and stores the rendering state, performs transformations and lighting operations, and rasterizes an image to a surface.</span></span>

<span data-ttu-id="b6044-108">アーキテクチャとしては、次の図に示すように、変換モジュール、照明モジュール、ラスタライズ モジュールが Direct3D デバイスに含まれます。</span><span class="sxs-lookup"><span data-stu-id="b6044-108">Architecturally, Direct3D devices contain a transformation module, a lighting module, and a rasterizing module, as the following diagram shows.</span></span>

![Direct3D デバイスのアーキテクチャの図](images/d3ddev.png)

<span data-ttu-id="b6044-110">Direct3D では、主に 2 種類の Direct3D デバイスをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b6044-110">Direct3D supports two main types of Direct3D devices:</span></span>

-   <span data-ttu-id="b6044-111">ハードウェア アクセラレータによるラスタライズと、ハードウェアとソフトウェアの両方の頂点処理によるシェーディングを備えた HAL デバイス</span><span class="sxs-lookup"><span data-stu-id="b6044-111">A hal device with hardware-accelerated rasterization and shading with both hardware and software vertex processing</span></span>
-   <span data-ttu-id="b6044-112">参照デバイス</span><span class="sxs-lookup"><span data-stu-id="b6044-112">A reference device</span></span>

<span data-ttu-id="b6044-113">これらのデバイスは、2 つの独立したドライバーです。</span><span class="sxs-lookup"><span data-stu-id="b6044-113">These devices are two separate drivers.</span></span> <span data-ttu-id="b6044-114">ソフトウェア デバイスと参照デバイスはソフトウェア ドライバーによって表され、HAL デバイスはハードウェア ドライバーで表されます。</span><span class="sxs-lookup"><span data-stu-id="b6044-114">Software and reference devices are represented by software drivers, and the hal device is represented by a hardware driver.</span></span> <span data-ttu-id="b6044-115">これらのデバイスを活用する最も一般的な方法は、アプリケーションを出荷する際には HAL デバイスを使用し、機能テストには参照デバイスを使用することです。</span><span class="sxs-lookup"><span data-stu-id="b6044-115">The most common way to take advantage of these devices is to use the hal device for shipping applications, and the reference device for feature testing.</span></span> <span data-ttu-id="b6044-116">これらは、特定のデバイス (まだリリースされていない開発中のハードウェアなど) をエミュレートするために、サード パーティによって提供されます。</span><span class="sxs-lookup"><span data-stu-id="b6044-116">These are provided by third parties to emulate particular devices - for example, developmental hardware that has not yet been released.</span></span>

<span data-ttu-id="b6044-117">アプリケーションが作成する Direct3D デバイスは、アプリケーションが実行されるハードウェアの機能に対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6044-117">The Direct3D device that an application creates must correspond to the capabilities of the hardware on which the application is running.</span></span> <span data-ttu-id="b6044-118">Direct3D は、コンピューターにインストールされている 3D ハードウェアにアクセスするか、ソフトウェアで 3D ハードウェアの機能をエミュレートすることにより、レンダリング機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="b6044-118">Direct3D provides rendering capabilities, either by accessing 3D hardware that is installed in the computer or by emulating the capabilities of 3D hardware in software.</span></span> <span data-ttu-id="b6044-119">したがって、Direct3D では、ハードウェアへのアクセスとソフトウェア エミュレーションの両方についてデバイスを提供します。</span><span class="sxs-lookup"><span data-stu-id="b6044-119">Therefore, Direct3D provides devices for both hardware access and software emulation.</span></span>

<span data-ttu-id="b6044-120">ハードウェア アクセラレータによるデバイスは、ソフトウェア デバイスよりも優れたパフォーマンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="b6044-120">Hardware-accelerated devices give much better performance than software devices.</span></span> <span data-ttu-id="b6044-121">HAL デバイスは、Direct3D がサポートしているすべてのグラフィック アダプターで利用できます。</span><span class="sxs-lookup"><span data-stu-id="b6044-121">The hal device type is available on all Direct3D supported graphic adapters.</span></span> <span data-ttu-id="b6044-122">ほとんどの場合、アプリケーションは、ハードウェア アクセラレーションを備えたコンピューターを対象にしており、ローエンドのコンピューターに対応するためにソフトウェア エミュレーションを利用します。</span><span class="sxs-lookup"><span data-stu-id="b6044-122">In most cases, applications target computers that have hardware acceleration and rely on software emulation to accommodate lower-end computers.</span></span>

<span data-ttu-id="b6044-123">参照デバイスを除いて、ソフトウェア デバイスが、常にハードウェア デバイスと同じ機能をサポートするとは限りません。</span><span class="sxs-lookup"><span data-stu-id="b6044-123">With the exception of the reference device, software devices do not always support the same features as a hardware device.</span></span> <span data-ttu-id="b6044-124">アプリケーションでは、常にデバイスの機能を照会して、サポートされている機能を特定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6044-124">Applications should always query for device capabilities to determine which features are supported.</span></span>

<span data-ttu-id="b6044-125">Direct3D 9 で提供されるソフトウェア デバイスと参照デバイスの動作は、HAL デバイスの動作と同じであるため、HAL デバイスで動作するように作成されたアプリケーション コードは、変更することなく、ソフトウェア デバイスや参照デバイスで動作します。</span><span class="sxs-lookup"><span data-stu-id="b6044-125">Because the behavior of the software and reference devices provided with Direct3D 9 is identical to that of the hal device, application code authored to work with the hal device will work with the software or reference devices without modifications.</span></span> <span data-ttu-id="b6044-126">提供されるソフトウェア デバイスや参照デバイスの動作は HAL デバイスの動作と同じですが、デバイスの機能は異なり、特定のソフトウェア デバイスで実装されている機能はかなり少ない場合があります。</span><span class="sxs-lookup"><span data-stu-id="b6044-126">The provided software or reference device behavior is identical to that of the hal device, but the device capabilities do vary, and a particular software device may implement a much smaller set of capabilities.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="b6044-127"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="b6044-127"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="b6044-128">トピック</span><span class="sxs-lookup"><span data-stu-id="b6044-128">Topic</span></span></th>
<th align="left"><span data-ttu-id="b6044-129">説明</span><span class="sxs-lookup"><span data-stu-id="b6044-129">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="device-types.md"><span data-ttu-id="b6044-130">デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="b6044-130">Device types</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="b6044-131">Direct3D デバイスの種類には、ハードウェア アブストラクション レイヤー (HAL) デバイスとリファレンス ラスタライザーがあります。</span><span class="sxs-lookup"><span data-stu-id="b6044-131">Direct3D device types include Hardware Abstraction Layer (hal) devices and the reference rasterizer.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="windowed-vs--full-screen-mode.md"><span data-ttu-id="b6044-132">ウィンドウ モードと全画面表示モード</span><span class="sxs-lookup"><span data-stu-id="b6044-132">Windowed vs. full-screen mode</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="b6044-133">Direct3D アプリケーションは、ウィンドウ モードと全画面表示モードのどちらでも実行できます。</span><span class="sxs-lookup"><span data-stu-id="b6044-133">Direct3D applications can run in either of two modes: windowed or full-screen.</span></span> <span data-ttu-id="b6044-134"><em>ウィンドウ モード</em>では、アプリケーションは実行中のすべてのアプリケーションとデスクトップの利用可能な画面領域を共有します。</span><span class="sxs-lookup"><span data-stu-id="b6044-134">In <em>windowed mode</em>, the application shares the available desktop screen space with all running applications.</span></span> <span data-ttu-id="b6044-135"><em>全画面表示モード</em>では、アプリケーションが実行されるウィンドウがデスクトップ全体に表示され、実行中のすべてのアプリケーション (開発環境を含む) が非表示になります。</span><span class="sxs-lookup"><span data-stu-id="b6044-135">In <em>full-screen mode</em>, the window that the application runs in covers the entire desktop, hiding all running applications (including your development environment).</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="lost-devices.md"><span data-ttu-id="b6044-136">失われたデバイス</span><span class="sxs-lookup"><span data-stu-id="b6044-136">Lost devices</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="b6044-137">Direct3D デバイスは、稼働状態または喪失状態に設定できます。</span><span class="sxs-lookup"><span data-stu-id="b6044-137">A Direct3D device can be in either an operational state or a lost state.</span></span> <span data-ttu-id="b6044-138"><em>稼働</em>状態は、デバイスが実行され、期待どおりにすべてのレンダリングが表示される、デバイスの通常の状態です。</span><span class="sxs-lookup"><span data-stu-id="b6044-138">The <em>operational</em> state is the normal state of the device in which the device runs and presents all rendering as expected.</span></span> <span data-ttu-id="b6044-139">全画面表示のアプリケーションでキーボード フォーカスが失われるなどのイベントによって、レンダリングが不可能になると、デバイスは<em>喪失</em>状態に移行します。</span><span class="sxs-lookup"><span data-stu-id="b6044-139">The device makes a transition to the <em>lost</em> state when an event, such as the loss of keyboard focus in a full-screen application, causes rendering to become impossible.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="swap-chains.md"><span data-ttu-id="b6044-140">スワップ チェーン</span><span class="sxs-lookup"><span data-stu-id="b6044-140">Swap chains</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="b6044-141">スワップ チェーンは、ユーザーにフレームを表示するために使用されるバッファーのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="b6044-141">A swap chain is a collection of buffers that are used for displaying frames to the user.</span></span> <span data-ttu-id="b6044-142">アプリケーションが表示する新しいフレームを提供するたびに、スワップ チェーンの最初のバッファーが、表示されているバッファーの場所を取得します。</span><span class="sxs-lookup"><span data-stu-id="b6044-142">Each time an application presents a new frame for display, the first buffer in the swap chain takes the place of the displayed buffer.</span></span> <span data-ttu-id="b6044-143">このプロセスは、<em>スワップ</em>または<em>フリップ</em>と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="b6044-143">This process is called <em>swapping</em> or <em>flipping</em>.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="introduction-to-rasterization-rules.md"><span data-ttu-id="b6044-144">ラスター化規則の概要</span><span class="sxs-lookup"><span data-stu-id="b6044-144">Introduction to rasterization rules</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="b6044-145">多くの場合、頂点として指定される点は、画面上のピクセルと正確には一致しません。</span><span class="sxs-lookup"><span data-stu-id="b6044-145">Often, the points specified for vertices do not precisely match the pixels on the screen.</span></span> <span data-ttu-id="b6044-146">この場合、Direct3D は、三角形ラスタライズ規則を適用して、どのピクセルを特定の三角形に適用するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="b6044-146">When this happens, Direct3D applies triangle rasterization rules to decide which pixels apply to a given triangle.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="b6044-147"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="b6044-147"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="b6044-148">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="b6044-148">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




