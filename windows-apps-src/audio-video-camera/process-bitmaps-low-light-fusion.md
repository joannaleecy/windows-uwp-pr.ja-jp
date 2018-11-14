---
author: laurenhughes
description: この記事では、LowLightFusion クラスを使用してビットマップを処理する方法について説明します。
title: 低光量 Fusion API を使用したビットマップの処理
ms.author: lahugh
ms.date: 03/22/2018
ms.topic: article
keywords: Windows 10, UWP, 低光量 Fusion, ビットマップ, 画像処理
ms.localizationpriority: medium
ms.openlocfilehash: aa1fa0ae298bf9f0403a3a565f44010b022ba1f6
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6444882"
---
# <a name="process-bitmaps-with-the-lowlightfusion-api"></a>LowLightFusion を使用したビットマップの処理

低光量画像は高画質でキャプチャするのが難しい画像です。絞りとセンサー サイズが固定されているモバイル デバイスでは、特にキャプチャするのが難しくなります。 低光量を補正するために、デバイスでは露出時間を長くしたり、センサー ゲインを上げたりする場合がありますが、これにより、モーション ブラーが発生したり、画像のノイズが増えたりする可能性があります。 

[LowLightFusion class](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion) を使用すると、時間的に非常に近接している複数のフレームからのピクセル情報をサンプリングすることによって、低光量画像の画質が向上します。つまり、短時間のバースト画像によって、ノイズとモーション ブラーが減少します。 これは、写真編集アプリなどに追加できる便利な機能です。

この機能は、[AdvancedPhotoCapture クラス](https://docs.microsoft.com/uwp/api/Windows.Media.Capture.AdvancedPhotoCapture)を介して利用することもできます。このクラスでは、必要に応じて、画像のキャプチャの直後に低光量 Fusion アルゴリズムを一連の画像に適用します。 この機能の実装方法については、「[低光量写真](https://docs.microsoft.com/windows/uwp/audio-video-camera/high-dynamic-range-hdr-photo-capture#low-light-photo-capture)のキャプチャ」をご覧ください。

## <a name="prepare-the-images-for-processing"></a>処理する画像を準備する

この例では、[LowLightFusion クラス](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion) および [FileOpenPicker](https://docs.microsoft.com/uwp/api/Windows.Storage.Pickers.FileOpenPicker) を使用して、ユーザーが低光量 Fusion を実行する複数の画像を選択できるようにする方法について説明します。

最初に、アルゴリズムで受け入れる画像の枚数 (フレームとも呼ばれます) を決定し、これらのフレームを格納するリストを作成する必要があります。

[!code-cs[SnippetGetMaxLLFFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetGetMaxLLFFrames)]

低光量 Fusion アルゴリズムで受け入れるフレームの枚数を決定したら、[FileOpenPicker](https://docs.microsoft.com/uwp/api/Windows.Storage.Pickers.FileOpenPicker) を使用して、アルゴリズムで利用される画像をユーザーが選択できるようにすることができます。

[!code-cs[SnippetGetFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetGetFrames)]

適切な枚数のフレームが選択されているので、次に、フレームを [SoftwareBitmaps](https://docs.microsoft.com/uwp/api/Windows.Graphics.Imaging.SoftwareBitmap) にデコードし、SoftwareBitmaps が LowLightFusion の正しい形式になっていることを確認する必要があります。

[!code-cs[SnippetDecodeFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetDecodeFrames)]


## <a name="fuse-the-bitmaps-into-a-single-bitmap"></a>複数のビットマップを 1 つのビットマップに合成する

適切な枚数のフレームが受け付け可能な形式になっているので、次に、**[FuseAsync](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion.fuseasync)** メソッドを使用して、低光量 Fusion アルゴリズムを適用します。 結果として生成される処理済みの画像は、鮮明度が向上しており、SoftwareBitmap の形式になります。 

[!code-cs[SnippetFuseFrames](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetFuseFrames)]

最後に、ユーザーが使い慣れた "通常" の画像形式 (作業を開始したときと同様の画像形式) にエンコードし保存することによって、生成された SoftwareBitmap をクリーンアップします。

[!code-cs[SnippetEncodeFrame](./code/LowLightFusionSample/cs/MainPage.xaml.cs#SnippetEncodeFrame)]


## <a name="before-and-after"></a>適用前と適用後

1 つの入力画像と、低光量 Fusion アルゴリズムを適用した結果の出力画像の例を示します。

> [!div class="mx-tableFixed"] 
| 入力フレーム | 低光量 Fusion による出力 | 
|-------------|-------------------------|
| ![低光量 Fusion アルゴリズムへの入力フレーム](./images/LLF-Input.png) | ![低光量 Fusion アルゴリズムを適用した結果のフレーム](./images/LLF-Output.png) |

照明やバナーの周囲の影の鮮明さが向上したことが、入力フレームから確認できます。

## <a name="related-topics"></a>関連トピック 
[LowLightFusion クラス](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusion)  
[LowLightFusionResult クラス](https://docs.microsoft.com/uwp/api/windows.media.core.lowlightfusionresult)