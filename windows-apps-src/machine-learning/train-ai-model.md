---
author: serenaz
title: Visual Studio で Windows ML のモデルをトレーニングする方法
description: このステップ バイ ステップ チュートリアルでは、Visual Studio Tools for AI を使って Windows ML のモデルをトレーニングする方法について説明します。
ms.author: sezhen
ms.date: 03/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Windows Machine Learning, Visual Studio
ms.localizationpriority: medium
ms.openlocfilehash: 1b54b0665a2483b8a0be710f505e928c852f4dba
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1842669"
---
# <a name="how-to-train-a-model-for-windows-ml-in-visual-studio"></a><span data-ttu-id="ff481-104">Visual Studio で Windows ML のモデルをトレーニングする方法</span><span class="sxs-lookup"><span data-stu-id="ff481-104">How to train a model for Windows ML in Visual Studio</span></span>

<span data-ttu-id="ff481-105">このチュートリアルでは、ディープ ラーニングおよび AI ソリューションを構築、テスト、展開するための開発者向け拡張機能である [Visual Studio Tools for AI](http://aka.ms/vstoolsforai) を使って、「[使ってみる](get-started.md)」で取り上げた MNIST サンプル アプリのモデルをトレーニングします。</span><span class="sxs-lookup"><span data-stu-id="ff481-105">In this tutorial, we'll use [Visual Studio Tools for AI](http://aka.ms/vstoolsforai), a development extension for building, testing, and deploying Deep Learning & AI solutions, to train a model for the MNIST sample app in [Get Started](get-started.md).</span></span>

<span data-ttu-id="ff481-106">モデルのトレーニングには、[Microsoft Cognitive Toolkit (CNTK)](http://www.microsoft.com/en-us/cognitive-toolkit) フレームワークと [MNIST データセット](http://yann.lecun.com/exdb/mnist/)を使います。データセットには、60,000 件の例から成るトレーニング セットと、10,000 件の手書きの数字の例から成るテスト セットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ff481-106">We'll train the model with the [Microsoft Cognitive Toolkit (CNTK)](http://www.microsoft.com/en-us/cognitive-toolkit) framework and the [MNIST dataset](http://yann.lecun.com/exdb/mnist/), which has a training set of 60,000 examples and a test set of 10,000 examples of handwritten digits.</span></span> <span data-ttu-id="ff481-107">その後、モデルを [Open Neural Network Exchange (ONNX)](https://onnx.ai/) 形式で保存して、Windows ML で使用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ff481-107">We'll then save the model using the [Open Neural Network Exchange (ONNX)](https://onnx.ai/) format to use with Windows ML.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ff481-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="ff481-108">Prerequisites</span></span>
### <a name="install-visual-studio-tools-for-ai"></a><span data-ttu-id="ff481-109">Visual Studio Tools for AI のインストール</span><span class="sxs-lookup"><span data-stu-id="ff481-109">Install Visual Studio Tools for AI</span></span>
<span data-ttu-id="ff481-110">最初に、[Visual Studio](https://www.visualstudio.com/downloads/) をダウンロードしてインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff481-110">To get started, you'll need to download and install [Visual Studio](https://www.visualstudio.com/downloads/).</span></span> <span data-ttu-id="ff481-111">Visual Studio を開いたら、**Visual Studio Tools for AI** 拡張機能をアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="ff481-111">Once you have Visual Studio open, activate the **Visual Studio Tools for AI** extension:</span></span>

1. <span data-ttu-id="ff481-112">Visual Studio のメニュー バーをクリックし、[拡張機能と更新プログラム] を選択します。</span><span class="sxs-lookup"><span data-stu-id="ff481-112">Click on the menu bar in Visual Studio and select "Extensions and Updates..."</span></span>
2. <span data-ttu-id="ff481-113">[オンライン] タブをクリックし、[Visual Studio Marketplace の検索] を選択します。</span><span class="sxs-lookup"><span data-stu-id="ff481-113">Click on "Online" tab and select "Search Visual Studio Marketplace."</span></span>
3. <span data-ttu-id="ff481-114">「Visual Studio Tools for AI」を検索します。</span><span class="sxs-lookup"><span data-stu-id="ff481-114">Search for "Visual Studio Tools for AI."</span></span> 
3. <span data-ttu-id="ff481-115">**[ダウンロード]** ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="ff481-115">Click on the **Download** button.</span></span> 
4. <span data-ttu-id="ff481-116">インストールの完了後、Visual Studio を再起動します。</span><span class="sxs-lookup"><span data-stu-id="ff481-116">After installation, restart Visual Studio.</span></span> 

<span data-ttu-id="ff481-117">Visual Studio を再起動すると、拡張機能がアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="ff481-117">The extension will be active once Visual Studio restarts.</span></span> <span data-ttu-id="ff481-118">問題が発生した場合は、「[Visual Studio 拡張機能の検索と使用](hhttps://docs.microsoft.com/visualstudio/ide/finding-and-using-visual-studio-extensions)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff481-118">If you're having trouble, check out [Finding Visual Studio extensions](hhttps://docs.microsoft.com/visualstudio/ide/finding-and-using-visual-studio-extensions).</span></span>

### <a name="download-sample-code"></a><span data-ttu-id="ff481-119">サンプル コードのダウンロード</span><span class="sxs-lookup"><span data-stu-id="ff481-119">Download sample code</span></span>
<span data-ttu-id="ff481-120">GitHub で、[Samples for AI](https://github.com/Microsoft/samples-for-ai) のリポジトリをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="ff481-120">Download the [Samples for AI](https://github.com/Microsoft/samples-for-ai) repo on GitHub.</span></span> <span data-ttu-id="ff481-121">これらのサンプルでは、TensorFlow、CNTK、Theano などでディープ ラーニングを始める方法がカバーされています。</span><span class="sxs-lookup"><span data-stu-id="ff481-121">The samples cover getting started with deep learning across TensorFlow, CNTK, Theano and more.</span></span>

### <a name="install-cntk"></a><span data-ttu-id="ff481-122">CNTK のインストール</span><span class="sxs-lookup"><span data-stu-id="ff481-122">Install CNTK</span></span>
<span data-ttu-id="ff481-123">[CNTK for Python on Windows](https://docs.microsoft.com/en-us/cognitive-toolkit/setup-windows-python?tabs=cntkpy24) をインストールします。</span><span class="sxs-lookup"><span data-stu-id="ff481-123">Install [CNTK for Python on Windows](https://docs.microsoft.com/en-us/cognitive-toolkit/setup-windows-python?tabs=cntkpy24).</span></span> <span data-ttu-id="ff481-124">Python がまだインストールされていない場合は、Python もインストールする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff481-124">Note that you'll also have to install Python if you haven't already.</span></span>

<span data-ttu-id="ff481-125">または、ディープ ラーニング モデルの開発用にコンピューターを準備する方法として、[開発環境の準備に関するドキュメント](https://github.com/Microsoft/samples-for-ai/blob/master/README.md)には、Python、CNTK、TensorFlow、NVIDIA GPU ドライバー (オプション) などを簡単にインストールできるインストーラーが紹介されています。</span><span class="sxs-lookup"><span data-stu-id="ff481-125">Alternatively, to prepare your machine for deep learning model development, see [Preparing your development environment](https://github.com/Microsoft/samples-for-ai/blob/master/README.md) for a simplified installer for installing Python, CNTK, TensorFlow, NVIDIA GPU drivers (optional) and more.</span></span>

## <a name="1-open-project"></a><span data-ttu-id="ff481-126">1. プロジェクトを開く</span><span class="sxs-lookup"><span data-stu-id="ff481-126">1. Open project</span></span>

<span data-ttu-id="ff481-127">Visual Studio を起動し、**[ファイル]、[開く]、[プロジェクト/ソリューション]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="ff481-127">Launch Visual Studio and select **File > Open > Project/Solution**.</span></span> <span data-ttu-id="ff481-128">Samples for AI のリポジトリから、**examples\cntk\python** フォルダーを選択し、**CNTKPythonExamples.sln** ファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="ff481-128">From the Samples for AI repository, select the **examples\cntk\python** folder, and open the **CNTKPythonExamples.sln** file.</span></span>

![ソリューションを開く](images/open-solution.png)

## <a name="2-train-the-model"></a><span data-ttu-id="ff481-130">2. モデルをトレーニングする</span><span class="sxs-lookup"><span data-stu-id="ff481-130">2. Train the model</span></span>

<span data-ttu-id="ff481-131">MNIST プロジェクトをスタートアップ プロジェクトとして設定します。そのためには、python プロジェクトを右クリックし、**[スタートアップ プロジェクトに設定]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ff481-131">To set the MNIST project as the startup project, right-click on the python project and select **Set as Startup Project**.</span></span>

![ソリューションを開く](images/mnist-startup.png)

<span data-ttu-id="ff481-133">次に、train_mnist_onnx.py ファイルを開き、F5 キーまたは緑色の **[実行]** ボタンを押して、プロジェクトを実行します。</span><span class="sxs-lookup"><span data-stu-id="ff481-133">Next, open the train_mnist_onnx.py file and **Run** the project by pressing F5 or the green Run button.</span></span>

## <a name="3-view-the-model-and-add-it-to-your-app"></a><span data-ttu-id="ff481-134">3. モデルを表示してアプリに追加する</span><span class="sxs-lookup"><span data-stu-id="ff481-134">3. View the model and add it to your app</span></span>

<span data-ttu-id="ff481-135">ここで、トレーニング済みの **mnist.onnx** モデル ファイルが samples-for-ai/examples/cntk/python/MNIST フォルダーにあるはずです。</span><span class="sxs-lookup"><span data-stu-id="ff481-135">Now, the trained **mnist.onnx** model file should be in the samples-for-ai/examples/cntk/python/MNIST folder.</span></span> <span data-ttu-id="ff481-136">このトレーニング済みの **mnist.onnx** モデル ファイルを使って、「[使ってみる](get-started.md)」の MNIST サンプル アプリをビルドできます。</span><span class="sxs-lookup"><span data-stu-id="ff481-136">You can use this trained **mnist.onnx** model file to build the MNIST sample app in [Get Started](get-started.md)!</span></span> 

## <a name="4-learn-more"></a><span data-ttu-id="ff481-137">4. 詳細情報</span><span class="sxs-lookup"><span data-stu-id="ff481-137">4. Learn more</span></span>
<span data-ttu-id="ff481-138">[Azure GPU Virtual Machines](https://docs.microsoft.com/en-us/visualstudio/ai/tensorflow-vm) などを使ってディープ ラーニング モデルのトレーニングを高速化する方法については、[Microsoft の人工知能](https://www.microsoft.com/ai)と [Microsoft Machine Learning テクノロジ](https://docs.microsoft.com/en-us/azure/machine-learning/#More-Microsoft-Machine-Learning-Technologies)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ff481-138">To learn how to speed up training deep learning models by using [Azure GPU Virtual Machines](https://docs.microsoft.com/en-us/visualstudio/ai/tensorflow-vm) and more, visit [Artificial Intelligence at Microsoft](https://www.microsoft.com/ai) and [Microsoft Machine Learning Technologies](https://docs.microsoft.com/en-us/azure/machine-learning/#More-Microsoft-Machine-Learning-Technologies).</span></span>