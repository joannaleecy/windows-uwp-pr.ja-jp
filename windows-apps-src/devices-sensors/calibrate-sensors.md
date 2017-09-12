---
author: mukin
ms.assetid: ECE848C2-33DE-46B0-BAE7-647DB62779BB
title: "センサーの調整"
description: "デバイスの磁力計 (コンパス、傾斜計、方位センサー) に基づくセンサーは、環境の要因に応じて調整が必要になることがあります。"
ms.author: mukin
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 066332395dde8d52d970bc79e2597ccaacaddb18
ms.sourcegitcommit: a2908889b3566882c7494dc81fa9ece7d1d19580
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/31/2017
---
# <a name="calibrate-sensors"></a>センサーの調整

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。\]

**重要な API**

-   [**Windows.Devices.Sensors**](https://msdn.microsoft.com/library/windows/apps/BR206408)
-   [**Windows.Devices.Sensors.Custom**](https://msdn.microsoft.com/library/windows/apps/Dn895032)

デバイスの磁力計 (コンパス、傾斜計、方位センサー) に基づくセンサーは、環境の要因に応じて調整が必要になることがあります。 [**MagnetometerAccuracy**](https://msdn.microsoft.com/library/windows/apps/Dn297552) 列挙値は、デバイスの調整が必要になる場合の対応策を決めるのに役立ちます。

## <a name="when-to-calibrate-the-magnetometer"></a>磁力計を調整するタイミング

[**MagnetometerAccuracy**](https://msdn.microsoft.com/library/windows/apps/Dn297552) 列挙値には、アプリが実行されているデバイスを調整する必要があるかどうかを判断するのに役立つ 4 つの値があります。 デバイスを調整する必要がある場合は、その旨をユーザーに知らせる必要があります。 ただし、あまりに頻繁に調整を行うようユーザーに促さないでください。 10 分に 1 回を超えないようにします。

| 値           | 説明                                                                                                                                                      |-----------------|-------------------|                                                                                                                                              | **Unknown**     | センサー ドライバーは現在の精度を報告できませんでした。 これは、必ずしもデバイスが調整されていないことを意味するわけではありません。 **Unknown** が返された場合の最適な対応策は、開発しているアプリによって決まります。 アプリがセンサーの正確な読み取り値を利用しているのであれば、ユーザーにデバイスの調整を促します。 | | **Unreliable** | 現在、磁力計の精度が著しく低下しています。 この値が最初に返された時点で、アプリからユーザーに必ず調整を求めます。 | | **Approximate** | 特定のアプリに対してデータは十分に正確です。 ユーザーがデバイスを上下または左右に動かしたかどうかがわかればよいだけの仮想現実アプリでは、調整なしで続行できます。 指示を出すためにどの方向に進んでいるか知る必要があるナビゲーション アプリのように、絶対的な進路を必要とするアプリでは、調整を促す必要があります。 | | **High**        | データは正確です。 拡張現実アプリ、ナビゲーション アプリなどの絶対的な進路を知る必要があるアプリでも、調整は必要ありません。 |

## <a name="how-to-calibrate-the-magnetometer"></a>磁力計を調整する方法

この短いビデオでは、磁力計を調整する方法を概説しています。<iframe src="https://hubs-video.ssl.catalog.video.msn.com/embed/727bd0e3-9116-49c3-8af6-0b4339324b71/IA?csid=ux-en-us&MsnPlayerLeadsWith=html&PlaybackMode=Inline&MsnPlayerDisplayShareBar=false&MsnPlayerDisplayInfoButton=false&iframe=true&QualityOverride=HD" width="720" height="405" allowFullScreen="true" frameBorder="0" scrolling="no">One Dev Minute - センサーの調整</iframe>
