---
title: 計算パイプライン
description: Direct3D 計算パイプラインは、グラフィックス パイプラインとほぼ並行して実行できる計算を処理するように設計されています。
ms.assetid: 355B66C6-C0DF-47BA-A9C9-7AFA50B5B614
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 91c95019c327f39a58a7397a66f9d4bbc88f843d
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5885452"
---
# <a name="compute-pipeline"></a><span data-ttu-id="333d7-104">計算パイプライン</span><span class="sxs-lookup"><span data-stu-id="333d7-104">Compute pipeline</span></span>


<span data-ttu-id="333d7-105">\[一部の情報はリリース前の製品に関することであり、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="333d7-105">\[Some information relates to pre-released product which may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="333d7-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。\]</span><span class="sxs-lookup"><span data-stu-id="333d7-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.\]</span></span>


<span data-ttu-id="333d7-107">Direct3D 計算パイプラインは、グラフィックス パイプラインとほぼ並行して実行できる計算を処理するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="333d7-107">The Direct3D compute pipeline is designed to handle calculations that can be done mostly in parallel with the graphics pipeline.</span></span> <span data-ttu-id="333d7-108">計算パイプラインには、プログラム可能な計算シェーダー ステージを介して入力から出力へデータが流れる、わずかなステップしかありません。</span><span class="sxs-lookup"><span data-stu-id="333d7-108">There are only a few steps in the compute pipeline, with data flowing from input to output through the programmable compute shader stage.</span></span>

| | |
|-|-|
|<span data-ttu-id="333d7-109">目的</span><span class="sxs-lookup"><span data-stu-id="333d7-109">Purpose</span></span>|<span data-ttu-id="333d7-110">他のプログラム可能なシェーダーと同様に、[計算シェーダー (CS) ステージ](compute-shader-stage--cs-.md)は、HLSL を使って設計され、実装されています。</span><span class="sxs-lookup"><span data-stu-id="333d7-110">Like other programmable shaders, [Compute Shader (CS) stage](compute-shader-stage--cs-.md) is designed and implemented with HLSL.</span></span> <span data-ttu-id="333d7-111">計算シェーダーは、高速な汎用コンピューティングを提供し、グラフィックス処理装置 (GPU) 上の多数の並列プロセッサを利用します。</span><span class="sxs-lookup"><span data-stu-id="333d7-111">A compute shader provides high-speed general purpose computing and takes advantage of the large numbers of parallel processors on the graphics processing unit (GPU).</span></span> <span data-ttu-id="333d7-112">計算シェーダーは、メモリ共有とスレッド同期機能を提供し、より効果的な並列プログラミング手法を可能にします。</span><span class="sxs-lookup"><span data-stu-id="333d7-112">The compute shader provides memory sharing and thread synchronization features to allow more effective parallel programming methods.</span></span>|
|<span data-ttu-id="333d7-113">入力</span><span class="sxs-lookup"><span data-stu-id="333d7-113">Input</span></span>|<span data-ttu-id="333d7-114">他のプログラム可能なシェーダーとは異なり、入力は抽象定義です。</span><span class="sxs-lookup"><span data-stu-id="333d7-114">Unlike other programmable shaders, the definition of input is abstract.</span></span> <span data-ttu-id="333d7-115">入力は、1 次元、2 次元または 3 次元とすることができ、実行する計算シェーダーの呼び出し回数を決定します。</span><span class="sxs-lookup"><span data-stu-id="333d7-115">The input can be one, two or three-dimensional in nature, determining the number of invocations of the compute shader to execute.</span></span> <span data-ttu-id="333d7-116">1 セットの読み込み呼び出しのために、共有データを定義することができます。</span><span class="sxs-lookup"><span data-stu-id="333d7-116">It is possible to define shared data for one set of invocations to read.</span></span>|
|<span data-ttu-id="333d7-117">出力</span><span class="sxs-lookup"><span data-stu-id="333d7-117">Output</span></span>|<span data-ttu-id="333d7-118">計算シェーダーからの出力データは、大幅に変化する場合がありますが、計算データが必要な場合には、グラフィックス レンダリング パイプラインと同期させることができます。</span><span class="sxs-lookup"><span data-stu-id="333d7-118">Output data from the compute shader, which can be highly varied, can be synchronized with the graphics rendering pipeline when the computed data is required.</span></span>|
| | |




<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">Like other programmable shaders, <a href="#compute-shader-stage--cs-.md">Compute Shader (CS) stage</a> is designed and implemented with HLSL. A compute shader provides high-speed general purpose computing and takes advantage of the large numbers of parallel processors on the graphics processing unit (GPU). The compute shader provides memory sharing and thread synchronization features to allow more effective parallel programming methods.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">Unlike other programmable shaders, the definition of input is abstract. The input can be one, two or three-dimensional in nature, determining the number of invocations of the compute shader to execute. It is possible to define shared data for one set of invocations to read.</td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">Output data from the compute shader, which can be highly varied, can be synchronized with the graphics rendering pipeline when the computed data is required.</td>
</tr>
</tbody>
</table>
-->

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="333d7-119"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="333d7-119"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="333d7-120">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="333d7-120">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 
