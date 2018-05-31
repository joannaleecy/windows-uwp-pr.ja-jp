---
author: serenaz
title: Windows ML
description: Windows ML を使うと、Windows アプリに機械学習モデルを統合できます。 このプラットフォームにより、Windows 10 デバイスでハードウェア アクセラレーションに対応したローカルな評価が可能になります。
ms.author: sezhen
ms.date: 03/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, WinML, Windows Machine Learning
ms.localizationpriority: medium
ms.openlocfilehash: 658e0ec73afeb3f600bcb7764ee672908a64f36b
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1815377"
---
# <a name="windows-ml"></a><span data-ttu-id="024a4-105">Windows ML</span><span class="sxs-lookup"><span data-stu-id="024a4-105">Windows ML</span></span>

<span data-ttu-id="024a4-106">Windows Machine Learning (ML) を使うと、アプリケーションにトレーニング済みの機械学習モデルを組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="024a4-106">Windows Machine Learning (ML) allows you to use trained machine learning models in your applications.</span></span> <span data-ttu-id="024a4-107">このプラットフォームでは、トレーニング済みのモデルを Windows 10 デバイスでローカルに評価します。デバイスの CPU または GPU が利用されるため、ハードウェア アクセラレーションの利いたパフォーマンスを得ることができます。また、従来の ML アルゴリズムとディープ ラーニングの両方の評価を計算できます。</span><span class="sxs-lookup"><span data-stu-id="024a4-107">The platform evaluates trained models locally on Windows 10 devices, providing hardware-accelerated performance by leveraging the device's CPU or GPU, and computes evaluations for both classical ML algorithms and Deep Learning.</span></span>

![Windows Machine Learning](images/winml-graphic.png)

## <a name="in-this-section"></a><span data-ttu-id="024a4-109">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="024a4-109">In this section</span></span>

| <span data-ttu-id="024a4-110">トピック</span><span class="sxs-lookup"><span data-stu-id="024a4-110">Topic</span></span> | <span data-ttu-id="024a4-111">説明</span><span class="sxs-lookup"><span data-stu-id="024a4-111">Description</span></span> |
| - | - |
| [<span data-ttu-id="024a4-112">概要</span><span class="sxs-lookup"><span data-stu-id="024a4-112">Overview</span></span>](overview.md) | <span data-ttu-id="024a4-113">Windows ML の概要と、トレーニング済みのモデルをアプリで使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="024a4-113">Learn about Windows ML and how to use trained models in your app.</span></span> |
| [<span data-ttu-id="024a4-114">使ってみる</span><span class="sxs-lookup"><span data-stu-id="024a4-114">Get started</span></span>](get-started.md) | <span data-ttu-id="024a4-115">このステップ バイ ステップ チュートリアルを使って、初めての Windows ML アプリを作成しましょう。</span><span class="sxs-lookup"><span data-stu-id="024a4-115">Create your first Windows ML app with this step-by-step tutorial.</span></span> |
| [<span data-ttu-id="024a4-116">モデルのトレーニング</span><span class="sxs-lookup"><span data-stu-id="024a4-116">Train a model</span></span>](train-ai-model.md) | <span data-ttu-id="024a4-117">Visual Studio Tools for AI を使って Windows ML のモデルをトレーニングします。</span><span class="sxs-lookup"><span data-stu-id="024a4-117">Train a model for Windows ML using Visual Studio Tools for AI.</span></span> |
| [<span data-ttu-id="024a4-118">モデルの変換</span><span class="sxs-lookup"><span data-stu-id="024a4-118">Convert a model</span></span>](conversion-samples.md) | <span data-ttu-id="024a4-119">既存のモデルを Windows ML で使う ONNX 形式に変換します。</span><span class="sxs-lookup"><span data-stu-id="024a4-119">Convert existing models to ONNX format to use with Windows ML.</span></span> |
| [<span data-ttu-id="024a4-120">モデルの統合</span><span class="sxs-lookup"><span data-stu-id="024a4-120">Integrate a model</span></span>](integrate-model.md) | <span data-ttu-id="024a4-121">読み込み、バインド、評価のパターンに従って、アプリにモデルを統合します。</span><span class="sxs-lookup"><span data-stu-id="024a4-121">Integrate a model into your app by following the load, bind, and evaluate pattern.</span></span> |
| [<span data-ttu-id="024a4-122">サンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="024a4-122">Sample apps</span></span>](samples.md) | <span data-ttu-id="024a4-123">Windows ML の使い方を示すサンプル UWP アプリを紹介します。</span><span class="sxs-lookup"><span data-stu-id="024a4-123">See sample UWP apps that demonstrate how to use Windows ML.</span></span> |

## <a name="related-topics"></a><span data-ttu-id="024a4-124">関連トピック</span><span class="sxs-lookup"><span data-stu-id="024a4-124">Related topics</span></span>

- [<span data-ttu-id="024a4-125">Windows.AI.MachineLearning.Preview API</span><span class="sxs-lookup"><span data-stu-id="024a4-125">Windows.AI.MachineLearning.Preview APIs</span></span>](/uwp/api/windows.ai.machinelearning.preview)
- [<span data-ttu-id="024a4-126">Windows ML COM API</span><span class="sxs-lookup"><span data-stu-id="024a4-126">Windows ML COM APIs</span></span>](https://msdn.microsoft.com/en-us/library/windows/desktop/mt845849.aspx)