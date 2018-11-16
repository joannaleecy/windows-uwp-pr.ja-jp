---
title: デバイスの種類
description: Direct3D デバイスの種類には、ハードウェア アブストラクション レイヤー (HAL) デバイスとリファレンス ラスタライザーがあります。
ms.assetid: 64084B23-10C0-4541-8E93-FB323385D2F0
keywords:
- デバイスの種類
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: cbf7d984226984391da340c74791dad4a6c0d8fb
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6975374"
---
# <a name="device-types"></a><span data-ttu-id="225ab-104">デバイスの種類</span><span class="sxs-lookup"><span data-stu-id="225ab-104">Device types</span></span>


<span data-ttu-id="225ab-105">Direct3D デバイスの種類には、ハードウェア アブストラクション レイヤー (HAL) デバイスとリファレンス ラスタライザーがあります。</span><span class="sxs-lookup"><span data-stu-id="225ab-105">Direct3D device types include Hardware Abstraction Layer (hal) devices and the reference rasterizer.</span></span>

## <a name="span-idhaldevicespanspan-idhaldevicespanspan-idhaldevicespanhal-device"></a><span data-ttu-id="225ab-106"><span id="HAL_Device"></span><span id="hal_device"></span><span id="HAL_DEVICE"></span>HAL デバイス</span><span class="sxs-lookup"><span data-stu-id="225ab-106"><span id="HAL_Device"></span><span id="hal_device"></span><span id="HAL_DEVICE"></span>HAL Device</span></span>


<span data-ttu-id="225ab-107">主なデバイスの種類は HAL デバイスで、ハードウェア アクセラレータによるラスタライズと、ハードウェアとソフトウェアの両方の頂点の処理をサポートします。</span><span class="sxs-lookup"><span data-stu-id="225ab-107">The primary device type is the hal device, which supports hardware accelerated rasterization and both hardware and software vertex processing.</span></span> <span data-ttu-id="225ab-108">アプリが実行されているコンピューターに、Direct3D をサポートするディスプレイ アダプターが搭載されている場合、アプリケーションではディスプレイ アダプターを使用して Direct3D を操作する必要があります。</span><span class="sxs-lookup"><span data-stu-id="225ab-108">If the computer on which your application is running is equipped with a display adapter that supports Direct3D, your application should use it for Direct3D operations.</span></span> <span data-ttu-id="225ab-109">Direct3D HAL デバイスは、変換、照明、ラスタライズ モジュールのすべてまたは一部をハードウェアに実装します。</span><span class="sxs-lookup"><span data-stu-id="225ab-109">Direct3D hal devices implement all or part of the transformation, lighting, and rasterizing modules in hardware.</span></span>

<span data-ttu-id="225ab-110">アプリケーションでは、グラフィックス アダプターに直接アクセスしないでください。</span><span class="sxs-lookup"><span data-stu-id="225ab-110">Applications do not access graphics adapters directly.</span></span> <span data-ttu-id="225ab-111">これらは、Direct3D の関数とメソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="225ab-111">They call Direct3D functions and methods.</span></span> <span data-ttu-id="225ab-112">Direct3D は、HAL を通じてハードウェアにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="225ab-112">Direct3D accesses the hardware through the hal.</span></span> <span data-ttu-id="225ab-113">アプリケーションが実行されているコンピューターが HAL をサポートする場合、HAL デバイスを使用することにより最高のパフォーマンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="225ab-113">If the computer that your application is running on supports the hal, it will gain the best performance by using a hal device.</span></span>

## <a name="span-idreferencedevicespanspan-idreferencedevicespanspan-idreferencedevicespanreference-device"></a><span data-ttu-id="225ab-114"><span id="Reference_Device"></span><span id="reference_device"></span><span id="REFERENCE_DEVICE"></span>参照デバイス</span><span class="sxs-lookup"><span data-stu-id="225ab-114"><span id="Reference_Device"></span><span id="reference_device"></span><span id="REFERENCE_DEVICE"></span>Reference Device</span></span>


<span data-ttu-id="225ab-115">Direct3D では、参照デバイスまたはリファレンス ラスタライザーと呼ばれる、追加のデバイスの種類がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="225ab-115">Direct3D supports an additional device type called a reference device or reference rasterizer.</span></span> <span data-ttu-id="225ab-116">ソフトウェア デバイスとは異なり、リファレンス ラスタライザーは、すべての Direct3D の機能をサポートします。</span><span class="sxs-lookup"><span data-stu-id="225ab-116">Unlike a software device, the reference rasterizer supports every Direct3D feature.</span></span> <span data-ttu-id="225ab-117">このデバイスは、デバッグの目的で使用されるため、DirectX SDK がインストールされているコンピューターでのみ利用できます。</span><span class="sxs-lookup"><span data-stu-id="225ab-117">This device is intended to be used for debugging purposes and is therefore only available on machines where the DirectX SDK has been installed.</span></span> <span data-ttu-id="225ab-118">これらの機能は、速度ではなく精度のために実装され、ソフトウェアに実装されるため、結果はそれほど高速ではありません。</span><span class="sxs-lookup"><span data-stu-id="225ab-118">Because these features are implemented for accuracy rather than speed and are implemented in software, the results are not very fast.</span></span> <span data-ttu-id="225ab-119">リファレンス ラスタライザーは、可能な場合は常に CPU の特殊な命令を使用しますが、これは製品版のアプリケーションで使用することを意図していません。</span><span class="sxs-lookup"><span data-stu-id="225ab-119">The reference rasterizer does make use of special CPU instructions whenever it can, but it is not intended for retail applications.</span></span> <span data-ttu-id="225ab-120">リファレンス ラスタライザーは、機能のテストやデモの目的でのみ使用してください。</span><span class="sxs-lookup"><span data-stu-id="225ab-120">Use the reference rasterizer only for feature testing or demonstration purposes.</span></span>

## <a name="span-idhalvsrefspanspan-idhalvsrefspanspan-idhalvsrefspanhal-vs-ref-devices"></a><span data-ttu-id="225ab-121"><span id="HAL_vs_REF"></span><span id="hal_vs_ref"></span><span id="HAL_VS_REF"></span>HAL デバイスと REF デバイス</span><span class="sxs-lookup"><span data-stu-id="225ab-121"><span id="HAL_vs_REF"></span><span id="hal_vs_ref"></span><span id="HAL_VS_REF"></span>HAL vs. REF Devices</span></span>


<span data-ttu-id="225ab-122">HAL (ハードウェア アブストラクション レイヤー) デバイスおよび REF (リファレンス ラスタライザー) デバイスは、Direct3D デバイスの 2 つの主要な種類です。前者は、ハードウェア サポートに基づいており、非常に高速ですが、すべてがサポートされているわけではありません。後者は、ハードウェア アクセラレータを使用しないため、非常に低速ですが、Direct3D の機能セット全体を適切な方法でサポートすることが保証されています。</span><span class="sxs-lookup"><span data-stu-id="225ab-122">HAL (Hardware Abstraction Layer) devices and REF (REFerence rasterizer) devices are the two main types of Direct3D device; the first is based around the hardware support, and is very fast but might not support everything; while the second uses no hardware acceleration, so is very slow, but is guaranteed to support the entire set of Direct3D features, in the correct way.</span></span> <span data-ttu-id="225ab-123">一般的に、使用する必要があるのは HAL デバイスのみですが、グラフィックス カードがサポートしていない一部の高度な機能を使用している場合は、REF へのフォールバックが必要になることもあります。</span><span class="sxs-lookup"><span data-stu-id="225ab-123">In general you'll only ever need to use HAL devices, but if you're using some advanced feature that your graphics card does not support then you might need to fall back to REF.</span></span>

<span data-ttu-id="225ab-124">REF を使用することが必要になるその他の機会として、HAL デバイスが奇妙な結果が生成する場合があります。つまり、コードが正しいことが確実であるにもかかわらず、結果が予期したものではない場合です。</span><span class="sxs-lookup"><span data-stu-id="225ab-124">The other time you might want to use REF is if the HAL device is producing strange results - that is, you're sure your code is correct, but the result is not what you're expecting.</span></span> <span data-ttu-id="225ab-125">REF デバイスは正しく動作することが保証されているため、REF デバイス上でアプリケーションをテストし、奇妙な動作が引き続き発生するかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="225ab-125">The REF device is guaranteed to behave correctly, so you may wish to test your application on the REF device and see if the strange behavior continues.</span></span> <span data-ttu-id="225ab-126">発生しない場合は、(a) アプリケーションが、グラフィックス カードでサポートしていない機能をサポートしていると想定しているか、(b) ドライバーのバグです。</span><span class="sxs-lookup"><span data-stu-id="225ab-126">If it doesn't, it means that either (a) your application is assuming that the graphics card supports something that it doesn't, or (b) it's a driver bug.</span></span> <span data-ttu-id="225ab-127">REF デバイスでもはっせいする場合は、アプリケーションのバグです。</span><span class="sxs-lookup"><span data-stu-id="225ab-127">If it still doesn't work with the REF device, then it's an application bug.</span></span>

## <a name="span-idhardwarevssoftwarespanspan-idhardwarevssoftwarespanspan-idhardwarevssoftwarespanhardware-vs-software-vertex-processing"></a><span data-ttu-id="225ab-128"><span id="Hardware_vs_Software"></span><span id="hardware_vs_software"></span><span id="HARDWARE_VS_SOFTWARE"></span>ハードウェアとソフトウェアでの頂点の処理</span><span class="sxs-lookup"><span data-stu-id="225ab-128"><span id="Hardware_vs_Software"></span><span id="hardware_vs_software"></span><span id="HARDWARE_VS_SOFTWARE"></span>Hardware vs. Software Vertex Processing</span></span>


<span data-ttu-id="225ab-129">ハードウェアとソフトウェアによる頂点処理は、実際には HAL デバイスにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="225ab-129">Hardware versus Software vertex processing only really applies to HAL devices.</span></span> <span data-ttu-id="225ab-130">パイプラインで頂点をプッシュする場合、頂点を変換 (ワールド、ビュー、プロジェクション マトリックス) し、照明を適用する (D3D の組み込みライトによる) 必要があります。この処理の段階をT&L (変換と照明) と呼びます。</span><span class="sxs-lookup"><span data-stu-id="225ab-130">When you push vertices through the pipeline, they need to be transformed (by the world, view, and projection matrices in turn) and lit (by D3D's built-in lights) - this processing stage is known as T&L (for Transformation & Lighting).</span></span> <span data-ttu-id="225ab-131">ハードウェアによる頂点処理は、ハードウェアがサポートしている場合、この処理がハードウェアで行われることを意味し、ソフトウェアによる頂点処理は、ソフトウェアで行われます。</span><span class="sxs-lookup"><span data-stu-id="225ab-131">Hardware vertex processing means this is done in hardware, if the hardware supports it; ergo, Software vertex processing is done is software.</span></span> <span data-ttu-id="225ab-132">一般的なプラクティスでは、最初にハードウェア T&L デバイスを作成し、それが失敗した場合は混在を試します。それでも失敗した場合はソフトウェアを試します </span><span class="sxs-lookup"><span data-stu-id="225ab-132">The general practice is to try creating a Hardware T&L device first, and if that fails try Mixed, and if that fails try Software.</span></span> <span data-ttu-id="225ab-133">(ソフトウェアが失敗した場合は、あきらめて、エラーを出力して終了します)。</span><span class="sxs-lookup"><span data-stu-id="225ab-133">(If software fails, give up and exit with an error.)</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="225ab-134"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="225ab-134"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="225ab-135">デバイス</span><span class="sxs-lookup"><span data-stu-id="225ab-135">Devices</span></span>](devices.md)

 

 




