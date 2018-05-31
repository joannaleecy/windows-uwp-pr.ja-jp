---
author: serenaz
title: Windows ML の概要
description: Windows Machine Learning の概要と、Windows ML を使って開発する方法について説明します。
ms.author: sezhen
ms.date: 03/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Windows Machine Learning
ms.localizationpriority: medium
ms.openlocfilehash: 2ef6ea1a4e1dab23f5ff6a09aec9b8c49c135f5e
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1817663"
---
# <a name="windows-ml-overview"></a><span data-ttu-id="ad0b8-104">Windows ML の概要</span><span class="sxs-lookup"><span data-stu-id="ad0b8-104">Windows ML overview</span></span>

![Windows Machine Learning のグラフィック](images/brain.png)

## <a name="what-is-machine-learning"></a><span data-ttu-id="ad0b8-106">機械学習とは</span><span class="sxs-lookup"><span data-stu-id="ad0b8-106">What is machine learning?</span></span>

<span data-ttu-id="ad0b8-107">機械学習 (ML) は、コンピューターで既存のデータを使って、予期される結果や動作を予測できるようにするものです。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-107">Machine learning (ML) allows computers to use existing data to predict expected outcomes and behaviors.</span></span> <span data-ttu-id="ad0b8-108">ML のアルゴリズムは、事前に収集されたデータを処理することで、新しい入力が提示されたときに適切な出力を予測できるモデルを構築します。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-108">By processing previously collected data, ML algorithms build models that can predict the correct output when presented with a new input.</span></span> <span data-ttu-id="ad0b8-109">たとえば、メール メッセージ (入力) が迷惑メールかそうでないか (出力) を評価するようにモデルをトレーニングできます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-109">For example, a model can be trained to evaluate email messages (input) as spam or not spam (output).</span></span>

<span data-ttu-id="ad0b8-110">モデルを構築するフェーズは "トレーニング" と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-110">The model-building phase is called "training."</span></span> <span data-ttu-id="ad0b8-111">既存のデータでトレーニングされたモデルは、それまでに出現したことのない新しいデータを使って予測を実行できます。これは "推測"、"評価"、または "スコアリング" と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-111">Once trained with existing data, the model can perform predictions with new, previously unseen data, which is called "inferencing," "evaluation," or "scoring."</span></span>

<span data-ttu-id="ad0b8-112">トレーニング済みのモデルでは、多くの場合、厳密な命令セットに従うように記述されたプログラムよりも適切な結果が生成されます。これは特に、入力と出力の組み合わせが多数考えられる複雑なタスクの場合に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-112">Trained models often produce better results than programs written to follow a strict set of instructions, especially for complex tasks with many possible combinations of inputs and outputs.</span></span> <span data-ttu-id="ad0b8-113">たとえば、電子商取引サイトやメディア ストリーミング サイトでは、おすすめアルゴリズムによって何百万人ものユーザーにカスタマイズされたおすすめを提供しますが、これは機械学習なくしてはほとんど不可能です。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-113">For example, recommendation algorithms provide personalized recommendations for millions of users on e-commerce and media streaming sites, which would be nearly impossible without machine learning.</span></span> <span data-ttu-id="ad0b8-114">他に機械学習が活用されている分野として、コンピューター ビジョンがあります。事前にラベル付けされた画像でトレーニングすることで、コンピューターによる画像の分類と識別が可能になります。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-114">Another field that leverages machine learning is computer vision, which allows computers to classify and identify images after training on previously labelled images.</span></span>

<span data-ttu-id="ad0b8-115">機械学習の可能性と適用性は無限に広がります。リサーチとソリューションについては、[Microsoft の人工知能](https://www.microsoft.com/ai)と [Microsoft AI プラットフォーム](https://azure.microsoft.com/en-us/overview/ai-platform/)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-115">The possibilities and applications of machine learning are endless; for more information about research and solutions, visit [Artifical Intelligence at Microsoft](https://www.microsoft.com/ai) and [Microsoft AI platform](https://azure.microsoft.com/en-us/overview/ai-platform/).</span></span> <span data-ttu-id="ad0b8-116">機械学習モデルや AI モデルの構築を検討している場合は、[Azure Machine Learning Services](https://docs.microsoft.com/azure/machine-learning/preview/overview-what-is-azure-ml) もチェックしてください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-116">If you'd like to build Machine Learning and AI models, you can also check out [Azure Machine Learning Services](https://docs.microsoft.com/azure/machine-learning/preview/overview-what-is-azure-ml).</span></span>

## <a name="what-is-windows-ml"></a><span data-ttu-id="ad0b8-117">Windows ML とは</span><span class="sxs-lookup"><span data-stu-id="ad0b8-117">What is Windows ML?</span></span>

<span data-ttu-id="ad0b8-118">Windows ML は、Windows 10 デバイスでトレーニング済みの機械学習モデルを評価するプラットフォームです。これにより開発者は、Windows アプリケーション内で機械学習を利用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-118">Windows ML is a platform that evaluates trained machine learning models on Windows 10 devices, allowing developers to use machine learning within their Windows applications.</span></span>

<span data-ttu-id="ad0b8-119">Windows ML の特色のいくつかを次に示します。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-119">Some highlights of Windows ML include:</span></span>

- **<span data-ttu-id="ad0b8-120">ハードウェア アクセラレータ</span><span class="sxs-lookup"><span data-stu-id="ad0b8-120">Hardware acceleration</span></span>**
    
    <span data-ttu-id="ad0b8-121">DirectX12 対応デバイスでは、Windows ML は GPU を使ってディープ ラーニング モデルの評価を高速化します。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-121">On DirectX12 capable devices, Windows ML accelerates the evaluation of Deep Learning models using the GPU.</span></span> <span data-ttu-id="ad0b8-122">さらに、CPU の最適化により、従来の ML アルゴリズムとディープ ラーニング アルゴリズムの両方で評価のパフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-122">CPU optimizations additionally enable high-performance evaluation of both classical ML and Deep Learning algorithms.</span></span>

- **<span data-ttu-id="ad0b8-123">ローカルの評価</span><span class="sxs-lookup"><span data-stu-id="ad0b8-123">Local evaluation</span></span>**

    <span data-ttu-id="ad0b8-124">Windows ML はローカル ハードウェアで評価を実行するため、接続性、帯域幅、データのプライバシーを心配する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-124">Windows ML evaluates on local hardware, removing concerns of connectivity, bandwidth, and data privacy.</span></span> <span data-ttu-id="ad0b8-125">さらに、ローカルの評価は待ち時間が短く、高いパフォーマンスが実現されるため、評価結果をすばやく得ることができます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-125">Local evaluation also enables low latency and high performance for quick evaluation results.</span></span>

- **<span data-ttu-id="ad0b8-126">画像処理</span><span class="sxs-lookup"><span data-stu-id="ad0b8-126">Image processing</span></span>**

    <span data-ttu-id="ad0b8-127">コンピューター ビジョンのシナリオでは、Windows ML がフレームの前処理を実行し、モデル入力用のカメラ パイプラインのセットアップを提供するため、画像、ビデオ、カメラ データの使用が簡素化され、最適化されます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-127">For computer vision scenarios, Windows ML simplifies and optimizes the use of image, video, and camera data by handling frame pre-processing and providing camera pipeline setup for model input.</span></span>

## <a name="how-to-develop-with-windows-ml"></a><span data-ttu-id="ad0b8-128">Windows ML を使って開発する方法</span><span class="sxs-lookup"><span data-stu-id="ad0b8-128">How to develop with Windows ML</span></span>

> [!VIDEO https://www.youtube.com/embed/8MCDSlm326U]

### <a name="system-requirements"></a><span data-ttu-id="ad0b8-129">システム要件</span><span class="sxs-lookup"><span data-stu-id="ad0b8-129">System requirements</span></span>

<span data-ttu-id="ad0b8-130">Windows ML を使うアプリケーションをビルドするには、[Windows SDK ビルド 17110 以降](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK)が必要です。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-130">To build applications that use Windows ML, you'll need the [Windows SDK - Build 17110 or higher](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK).</span></span>

### <a name="onnx-models"></a><span data-ttu-id="ad0b8-131">ONNX モデル</span><span class="sxs-lookup"><span data-stu-id="ad0b8-131">ONNX models</span></span>

<span data-ttu-id="ad0b8-132">Windows ML を使用するには、事前トレーニング済みの [Open Neural Network Exchange (ONNX)](https://onnx.ai) 形式の機械学習モデルが必要です。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-132">To use Windows ML, you'll need a pre-trained machine learning model in the [Open Neural Network Exchange (ONNX)](https://onnx.ai) format.</span></span> <span data-ttu-id="ad0b8-133">Windows ML は v1.0 リリースの ONNX 形式をサポートしているため、開発者は、異なるトレーニング フレームワークで生成されたモデルを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-133">Windows ML supports the v1.0 release of the ONNX format, which allows developers to use models produced by different training frameworks.</span></span>

<span data-ttu-id="ad0b8-134">一般公開されている ONNX モデルの一覧については、GitHub の [ONNX モデルのページ](https://github.com/onnx/models)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-134">For a list of publicly available ONNX models, see [ONNX Models](https://github.com/onnx/models) on GitHub.</span></span>

<span data-ttu-id="ad0b8-135">Visual Studio Tools for AI で ONNX モデルをトレーニングする方法については、「[モデルのトレーニング](train-ai-model.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-135">To learn how to train an ONNX model with Visual Studio Tools for AI, see [Train a model](train-ai-model.md).</span></span>

### <a name="convert-existing-models-to-onnx"></a><span data-ttu-id="ad0b8-136">既存のモデルの ONNX への変換</span><span class="sxs-lookup"><span data-stu-id="ad0b8-136">Convert existing models to ONNX</span></span>

<span data-ttu-id="ad0b8-137">既に多くのトレーニング フレームワークが ONNX モデルをネイティブにサポートしており、さまざまなフレームワークとライブラリ用のコンバーター ツールが存在します。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-137">Many training frameworks already natively support ONNX models, and there are converter tools for many frameworks and libraries.</span></span> <span data-ttu-id="ad0b8-138">Caffe 2、PyTorch、CNTK、Chainer などのフレームワークからエクスポートする方法については、GitHub の [ONNX チュートリアル](https://github.com/onnx/tutorials)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-138">To learn how to export from frameworks such as Caffe 2, PyTorch, CNTK, Chainer, and more, see [ONNX tutorials](https://github.com/onnx/tutorials) on GitHub.</span></span>

<span data-ttu-id="ad0b8-139">[WinMLTools](https://pypi.org/project/winmltools/) を使って、トレーニング済みの機械学習モデルを Windows ML で受け入れられる ONNX 形式に変換することもできます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-139">You can also use [WinMLTools](https://pypi.org/project/winmltools/) to convert trained machine learning model to the ONNX format accepted by Windows ML.</span></span> <span data-ttu-id="ad0b8-140">WinMLTools では、次の形式からの変換がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-140">WinMLTools supports conversion from these formats:</span></span>

- <span data-ttu-id="ad0b8-141">Core ML</span><span class="sxs-lookup"><span data-stu-id="ad0b8-141">Core ML</span></span>
- <span data-ttu-id="ad0b8-142">Scikit-Learn</span><span class="sxs-lookup"><span data-stu-id="ad0b8-142">Scikit-Learn</span></span>
- <span data-ttu-id="ad0b8-143">XGBoost</span><span class="sxs-lookup"><span data-stu-id="ad0b8-143">XGBoost</span></span>
- <span data-ttu-id="ad0b8-144">LibSVM</span><span class="sxs-lookup"><span data-stu-id="ad0b8-144">LibSVM</span></span>

<span data-ttu-id="ad0b8-145">WinMLTools のインストール方法と使用方法については、「[モデルの変換](conversion-samples.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-145">To learn how to install and use WinMLTools, please see [Convert a model](conversion-samples.md).</span></span>

### <a name="onnx-operators"></a><span data-ttu-id="ad0b8-146">ONNX 演算子</span><span class="sxs-lookup"><span data-stu-id="ad0b8-146">ONNX operators</span></span>

<span data-ttu-id="ad0b8-147">Windows ML では、100 以上の ONNX 演算子が CPU 上でサポートされると共に、DirectX12 互換の GPU では計算が高速化されます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-147">Windows ML supports 100+ ONNX operators on the CPU and accelerates computation on DirectX12 compatible GPUs.</span></span> <span data-ttu-id="ad0b8-148">すべての演算子のシグネチャの一覧については、[ai.onnx](https://github.com/onnx/onnx/blob/rel-1.0/docs/Operators.md) 名前空間 (既定) と [ai.onnx.ml](https://github.com/onnx/onnx/blob/rel-1.0/docs/Operators-ml.md) 名前空間の ONNX 演算子スキーマのドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-148">For a full list of operator signatures, see the ONNX operators schemas documentation for the [ai.onnx](https://github.com/onnx/onnx/blob/rel-1.0/docs/Operators.md) (default) and [ai.onnx.ml](https://github.com/onnx/onnx/blob/rel-1.0/docs/Operators-ml.md) namespaces.</span></span>

<span data-ttu-id="ad0b8-149">Windows ML は、ONNX v1.0 ドキュメントに定義されているすべての演算子をサポートしますが、次の違いがあります。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-149">Windows ML supports all of the operators defined in the ONNX v1.0 documentation with the following differences:</span></span>

- <span data-ttu-id="ad0b8-150">Windows ML でサポートされる "試験的" 演算子:</span><span class="sxs-lookup"><span data-stu-id="ad0b8-150">Operators marked "experimental" supported by Windows ML:</span></span>
    - <span data-ttu-id="ad0b8-151">Affine</span><span class="sxs-lookup"><span data-stu-id="ad0b8-151">Affine</span></span>
    - <span data-ttu-id="ad0b8-152">Crop</span><span class="sxs-lookup"><span data-stu-id="ad0b8-152">Crop</span></span>
    - <span data-ttu-id="ad0b8-153">FC</span><span class="sxs-lookup"><span data-stu-id="ad0b8-153">FC</span></span>
    - <span data-ttu-id="ad0b8-154">Identity</span><span class="sxs-lookup"><span data-stu-id="ad0b8-154">Identity</span></span>
    - <span data-ttu-id="ad0b8-155">ImageScaler</span><span class="sxs-lookup"><span data-stu-id="ad0b8-155">ImageScaler</span></span>
    - <span data-ttu-id="ad0b8-156">MeanVarianceNormalization</span><span class="sxs-lookup"><span data-stu-id="ad0b8-156">MeanVarianceNormalization</span></span>
    - <span data-ttu-id="ad0b8-157">ParametricSoftplus</span><span class="sxs-lookup"><span data-stu-id="ad0b8-157">ParametricSoftplus</span></span>
    - <span data-ttu-id="ad0b8-158">ScaledTanh</span><span class="sxs-lookup"><span data-stu-id="ad0b8-158">ScaledTanh</span></span>
    - <span data-ttu-id="ad0b8-159">ThresholdedRelu</span><span class="sxs-lookup"><span data-stu-id="ad0b8-159">ThresholdedRelu</span></span>
    - <span data-ttu-id="ad0b8-160">Upsample</span><span class="sxs-lookup"><span data-stu-id="ad0b8-160">Upsample</span></span>
- <span data-ttu-id="ad0b8-161">MatMul - 2D より大きい行列の乗算は現在未サポート、CPU でのみサポート</span><span class="sxs-lookup"><span data-stu-id="ad0b8-161">MatMul - greater than 2D matrix multiplication is not currently supported, supported on CPU only</span></span>
- <span data-ttu-id="ad0b8-162">Cast - CPU でのみサポート</span><span class="sxs-lookup"><span data-stu-id="ad0b8-162">Cast - supported on CPU only</span></span>
- <span data-ttu-id="ad0b8-163">現時点ではサポートされない演算子:</span><span class="sxs-lookup"><span data-stu-id="ad0b8-163">The following operators are not supported at this time:</span></span>
    - <span data-ttu-id="ad0b8-164">RandomUniform</span><span class="sxs-lookup"><span data-stu-id="ad0b8-164">RandomUniform</span></span>
    - <span data-ttu-id="ad0b8-165">RandomUniformLike</span><span class="sxs-lookup"><span data-stu-id="ad0b8-165">RandomUniformLike</span></span>
    - <span data-ttu-id="ad0b8-166">RandomNormal</span><span class="sxs-lookup"><span data-stu-id="ad0b8-166">RandomNormal</span></span>
    - <span data-ttu-id="ad0b8-167">RandomNormalLike</span><span class="sxs-lookup"><span data-stu-id="ad0b8-167">RandomNormalLike</span></span>

### <a name="automatic-interface-code-generation"></a><span data-ttu-id="ad0b8-168">インターフェイス コードの自動生成</span><span class="sxs-lookup"><span data-stu-id="ad0b8-168">Automatic interface code generation</span></span>

<span data-ttu-id="ad0b8-169">Windows ML のコード ジェネレーターは、ONNX モデル ファイルを使って、アプリ内のモデルを操作するためのインターフェイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-169">With an ONNX model file, Windows ML's code generator creates an interface to interact with the model in your app.</span></span> <span data-ttu-id="ad0b8-170">生成されたインターフェイスには、モデル、入力、出力を表すラッパー クラスが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-170">The generated interface includes wrapper classes that represent the model, inputs, and outputs.</span></span> <span data-ttu-id="ad0b8-171">生成されたコードによって [Windows ML API](/uwp/api/windows.ai.machinelearning.preview) が自動的に呼び出され、プロジェクト内のモデルの読み込み、バインド、評価を簡単に行うことができます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-171">The generated code calls the [Windows ML API](/uwp/api/windows.ai.machinelearning.preview) for you, allowing you to easily load, bind, and evaluate the model in your project.</span></span> <span data-ttu-id="ad0b8-172">現在、コード ジェネレーターは C# と C++/CX の両方をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-172">The code generator currently supports both C# and C++/CX.</span></span>

<span data-ttu-id="ad0b8-173">UWP を開発する場合、Windows ML の自動コード ジェネレーターは [Visual Studio (Version 15.7 - Preview 1)](https://www.visualstudio.com/vs/preview/) とネイティブに統合されます </span><span class="sxs-lookup"><span data-stu-id="ad0b8-173">For UWP developers, Windows ML's automatic code generator is natively integrated with [Visual Studio (version 15.7 - Preview 1)](https://www.visualstudio.com/vs/preview/).</span></span> <span data-ttu-id="ad0b8-174">(**注**: Visual Studio インストーラーで、オプションの Windows 10 Insider Preview SDK ビルド 17110 をオンにする必要があります)。Visual Studio プロジェクト内で ONNX ファイルを既存の項目として追加するだけで、VS によって Windows ML ラッパー クラスが新しいインターフェイス ファイルに生成されます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-174">(**Note**: Inside the Visual Studio Installer, you'll need to check off the optional Windows 10 Insider Preview SDK, Build 17110.) Inside your Visual Studio project, simply add your ONNX file as an existing item, and VS will generate Windows ML wrapper classes in a new interface file.</span></span>

<span data-ttu-id="ad0b8-175">また、Windows SDK に付属するコマンド ライン ツール `mlgen.exe` を使って Windows ML ラッパー クラスを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-175">You can also use the command line tool `mlgen.exe`, which comes with the Windows SDK, to generate Windows ML wrapper classes.</span></span> <span data-ttu-id="ad0b8-176">このツールは `(SDK_root)\bin\<version>\x64` または `(SDK_root)\bin\<version>\x86` に格納されています。SDK_root は SDK のインストール ディレクトリです。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-176">The tool is located in `(SDK_root)\bin\<version>\x64` or `(SDK_root)\bin\<version>\x86`, where SDK_root is the SDK installation directory.</span></span> <span data-ttu-id="ad0b8-177">ツールを実行するには、次のコマンドを使います。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-177">To run the tool, use the command below.</span></span>

```
mlgen -i INPUT-FILE -l LANGUAGE -n NAMESPACE [-o OUTPUT-FILE]
```

<span data-ttu-id="ad0b8-178">入力パラメーターの定義:</span><span class="sxs-lookup"><span data-stu-id="ad0b8-178">Input parameters definition:</span></span>

- `INPUT-FILE`<span data-ttu-id="ad0b8-179">: ONNX モデル ファイル</span><span class="sxs-lookup"><span data-stu-id="ad0b8-179">: the ONNX model file</span></span>
- `LANGUAGE`<span data-ttu-id="ad0b8-180">: CPPCX または CS</span><span class="sxs-lookup"><span data-stu-id="ad0b8-180">: CPPCX or CS</span></span>
- `NAMESPACE`<span data-ttu-id="ad0b8-181">: 生成されるコードの名前空間</span><span class="sxs-lookup"><span data-stu-id="ad0b8-181">: the namespace of the generated code</span></span>
- `OUTPUT-FILE`<span data-ttu-id="ad0b8-182">: 生成されたコードの出力先のファイル パス。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-182">: file path where the generated code will be written to.</span></span> <span data-ttu-id="ad0b8-183">OUTPUT-FILE を指定しない場合、生成されたコードは標準出力に出力されます。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-183">If OUTPUT-FILE is not specified, the generated code is written to the standard output</span></span>

<span data-ttu-id="ad0b8-184">生成されたコードをアプリで使う方法については、「[モデルの統合](integrate-model.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-184">To learn how to use the generated code in your app, see [Integrate a model](integrate-model.md).</span></span>

## <a name="next-steps"></a><span data-ttu-id="ad0b8-185">次のステップ</span><span class="sxs-lookup"><span data-stu-id="ad0b8-185">Next steps</span></span>

<span data-ttu-id="ad0b8-186">「[使ってみる](get-started.md)」のステップ バイ ステップ チュートリアルを使って、初めての Windows ML アプリを作成してみましょう。</span><span class="sxs-lookup"><span data-stu-id="ad0b8-186">Try creating your first Windows ML app with a step-by-step tutorial in [Get Started](get-started.md).</span></span>