---
title: デバイスの種類
description: Direct3D デバイスの種類には、ハードウェア アブストラクション レイヤー (HAL) デバイスとリファレンス ラスタライザーがあります。
ms.assetid: 64084B23-10C0-4541-8E93-FB323385D2F0
keywords:
- デバイスの種類
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5ddb1dc0e42f88cf65464841388b9addfb4b5748
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8935926"
---
# <a name="device-types"></a>デバイスの種類


Direct3D デバイスの種類には、ハードウェア アブストラクション レイヤー (HAL) デバイスとリファレンス ラスタライザーがあります。

## <a name="span-idhaldevicespanspan-idhaldevicespanspan-idhaldevicespanhal-device"></a><span id="HAL_Device"></span><span id="hal_device"></span><span id="HAL_DEVICE"></span>HAL デバイス


主なデバイスの種類は HAL デバイスで、ハードウェア アクセラレータによるラスタライズと、ハードウェアとソフトウェアの両方の頂点の処理をサポートします。 アプリが実行されているコンピューターに、Direct3D をサポートするディスプレイ アダプターが搭載されている場合、アプリケーションではディスプレイ アダプターを使用して Direct3D を操作する必要があります。 Direct3D HAL デバイスは、変換、照明、ラスタライズ モジュールのすべてまたは一部をハードウェアに実装します。

アプリケーションでは、グラフィックス アダプターに直接アクセスしないでください。 これらは、Direct3D の関数とメソッドを呼び出します。 Direct3D は、HAL を通じてハードウェアにアクセスします。 アプリケーションが実行されているコンピューターが HAL をサポートする場合、HAL デバイスを使用することにより最高のパフォーマンスを実現できます。

## <a name="span-idreferencedevicespanspan-idreferencedevicespanspan-idreferencedevicespanreference-device"></a><span id="Reference_Device"></span><span id="reference_device"></span><span id="REFERENCE_DEVICE"></span>参照デバイス


Direct3D では、参照デバイスまたはリファレンス ラスタライザーと呼ばれる、追加のデバイスの種類がサポートされています。 ソフトウェア デバイスとは異なり、リファレンス ラスタライザーは、すべての Direct3D の機能をサポートします。 このデバイスは、デバッグの目的で使用されるため、DirectX SDK がインストールされているコンピューターでのみ利用できます。 これらの機能は、速度ではなく精度のために実装され、ソフトウェアに実装されるため、結果はそれほど高速ではありません。 リファレンス ラスタライザーは、可能な場合は常に CPU の特殊な命令を使用しますが、これは製品版のアプリケーションで使用することを意図していません。 リファレンス ラスタライザーは、機能のテストやデモの目的でのみ使用してください。

## <a name="span-idhalvsrefspanspan-idhalvsrefspanspan-idhalvsrefspanhal-vs-ref-devices"></a><span id="HAL_vs_REF"></span><span id="hal_vs_ref"></span><span id="HAL_VS_REF"></span>HAL デバイスと REF デバイス


HAL (ハードウェア アブストラクション レイヤー) デバイスおよび REF (リファレンス ラスタライザー) デバイスは、Direct3D デバイスの 2 つの主要な種類です。前者は、ハードウェア サポートに基づいており、非常に高速ですが、すべてがサポートされているわけではありません。後者は、ハードウェア アクセラレータを使用しないため、非常に低速ですが、Direct3D の機能セット全体を適切な方法でサポートすることが保証されています。 一般的に、使用する必要があるのは HAL デバイスのみですが、グラフィックス カードがサポートしていない一部の高度な機能を使用している場合は、REF へのフォールバックが必要になることもあります。

REF を使用することが必要になるその他の機会として、HAL デバイスが奇妙な結果が生成する場合があります。つまり、コードが正しいことが確実であるにもかかわらず、結果が予期したものではない場合です。 REF デバイスは正しく動作することが保証されているため、REF デバイス上でアプリケーションをテストし、奇妙な動作が引き続き発生するかどうかを確認できます。 発生しない場合は、(a) アプリケーションが、グラフィックス カードでサポートしていない機能をサポートしていると想定しているか、(b) ドライバーのバグです。 REF デバイスでもはっせいする場合は、アプリケーションのバグです。

## <a name="span-idhardwarevssoftwarespanspan-idhardwarevssoftwarespanspan-idhardwarevssoftwarespanhardware-vs-software-vertex-processing"></a><span id="Hardware_vs_Software"></span><span id="hardware_vs_software"></span><span id="HARDWARE_VS_SOFTWARE"></span>ハードウェアとソフトウェアでの頂点の処理


ハードウェアとソフトウェアによる頂点処理は、実際には HAL デバイスにのみ適用されます。 パイプラインで頂点をプッシュする場合、頂点を変換 (ワールド、ビュー、プロジェクション マトリックス) し、照明を適用する (D3D の組み込みライトによる) 必要があります。この処理の段階をT&L (変換と照明) と呼びます。 ハードウェアによる頂点処理は、ハードウェアがサポートしている場合、この処理がハードウェアで行われることを意味し、ソフトウェアによる頂点処理は、ソフトウェアで行われます。 一般的なプラクティスでは、最初にハードウェア T&L デバイスを作成し、それが失敗した場合は混在を試します。それでも失敗した場合はソフトウェアを試します  (ソフトウェアが失敗した場合は、あきらめて、エラーを出力して終了します)。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[デバイス](devices.md)

 

 




