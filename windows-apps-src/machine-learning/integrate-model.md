---
author: serenaz
title: Windows ML でモデルをアプリに統合する
description: 読み込み、バインド、評価のパターンに従って、アプリにモデルを統合します。
ms.author: sezhen
ms.date: 03/22/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, WinML, Windows Machine Learning
ms.localizationpriority: medium
ms.openlocfilehash: 8631c07b45a8642a1de700e424d3ca4f147456fc
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1842579"
---
# <a name="integrate-a-model-into-your-app-with-windows-ml"></a><span data-ttu-id="850d2-104">Windows ML でモデルをアプリに統合する</span><span class="sxs-lookup"><span data-stu-id="850d2-104">Integrate a model into your app with Windows ML</span></span>

<span data-ttu-id="850d2-105">Windows ML の[自動コード生成](overview.md#automatic-interface-code-generation)を使うと、[Windows ML API](/uwp/api/windows.ai.machinelearning.preview) を自動的に呼び出すインターフェイスが作成され、独自のモデルを簡単に操作できるようになります。</span><span class="sxs-lookup"><span data-stu-id="850d2-105">Windows ML's [automatic code generation](overview.md#automatic-interface-code-generation) creates an interface that calls the [Windows ML APIs](/uwp/api/windows.ai.machinelearning.preview) for you, allowing you to easily interact with your model.</span></span> <span data-ttu-id="850d2-106">生成されたインターフェイスのラッパー クラスを使うことで、読み込み、バインド、評価のパターンに従って ML モデルをアプリに統合できます。</span><span class="sxs-lookup"><span data-stu-id="850d2-106">Using the interface's generated wrapper classes, you'll follow the load, bind, and evaluate pattern to integrate your ML model into your app.</span></span>

![読み込み、バインド、評価](images/load-bind-evaluate.png)

<span data-ttu-id="850d2-108">この記事では、「[使ってみる](get-started.md)」で取り上げた MNIST モデルを使って、アプリでモデルの読み込み、バインド、評価を行う方法を示します。</span><span class="sxs-lookup"><span data-stu-id="850d2-108">In this article, we'll use the MNIST model from [Get Started](get-started.md) to demonstrate how to load, bind, and evaluate a model in your app.</span></span>

## <a name="add-the-model"></a><span data-ttu-id="850d2-109">モデルの追加</span><span class="sxs-lookup"><span data-stu-id="850d2-109">Add the model</span></span>

<span data-ttu-id="850d2-110">最初に、ONNX モデルを Visual Studio プロジェクトのアセットに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="850d2-110">First, you'll need to add your ONNX model to your Visual Studio project's Assets.</span></span> <span data-ttu-id="850d2-111">[Visual Studio (Version 15.7 - Preview 1)](https://www.visualstudio.com/vs/preview/) で UWP アプリをビルドする場合は、Visual Studio によって自動的に新しいファイルにラッパー クラスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="850d2-111">If you're building a UWP app with [Visual Studio (version 15.7 - Preview 1)](https://www.visualstudio.com/vs/preview/), then Visual Studio will automatically generate the wrapper classes in a new file.</span></span> <span data-ttu-id="850d2-112">その他のワークフローでは、[mlgen](overview.md#automatic-interface-code-generation) ツールを使ってラッパー クラスを生成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="850d2-112">For other workflows, you'll need to use the [mlgen](overview.md#automatic-interface-code-generation) tool to generate wrapper classes.</span></span>

<span data-ttu-id="850d2-113">Windows ML で生成された MNIST モデルのラッパー クラスを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="850d2-113">Below are the Windows ML generated wrapper classes for the MNIST model.</span></span> <span data-ttu-id="850d2-114">この記事の残りの部分では、これらのクラスをアプリで使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="850d2-114">We'll use the remainder of this article to explain how to use these classes in your app.</span></span>

```csharp
public sealed class MNISTModelInput
{
    public VideoFrame Input3 { get; set; }
}

public sealed class MNISTModelOutput
{
    public IList<float> Plus214_Output_0 { get; set; }
    public MNISTModelOutput()
    {
        this.Plus214_Output_0 = new List<float>();
    }
}

public sealed class MNISTModel
{
    private LearningModelPreview learningModel;
    public static async Task<MNISTModel> CreateMNISTModel(StorageFile file)
    {
        LearningModelPreview learningModel = await LearningModelPreview.LoadModelFromStorageFileAsync(file);
        MNISTModel model = new MNISTModel();
        model.learningModel = learningModel;
        return model;
    }
    public async Task<MNISTModelOutput> EvaluateAsync(MNISTModelInput input) {
        MNISTModelOutput output = new MNISTModelOutput();
        LearningModelBindingPreview binding = new LearningModelBindingPreview(learningModel);
        binding.Bind("Input3", input.Input3);
        binding.Bind("Plus214_Output_0", output.Plus214_Output_0);
        LearningModelEvaluationResultPreview evalResult = await learningModel.EvaluateAsync(binding, string.Empty);
        return output;
    }
}
```

<span data-ttu-id="850d2-115">**注**: アプリケーションのコンパイル時にモデルがビルドされるようにするには、`.onnx` ファイルを右クリックし、**[プロパティ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="850d2-115">**Note**: To make sure your model builds when you compile your application, right click on the `.onnx` file, and select **Properties**.</span></span> <span data-ttu-id="850d2-116">**[ビルド アクション]** で **[コンテンツ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="850d2-116">For **Build Action**, select **Content**.</span></span>

## <a name="load"></a><span data-ttu-id="850d2-117">読み込み</span><span class="sxs-lookup"><span data-stu-id="850d2-117">Load</span></span>

<span data-ttu-id="850d2-118">ラッパー クラスが生成されたら、アプリでモデルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="850d2-118">Once you have the generated wrapper classes, you'll load the model in your app.</span></span>

<span data-ttu-id="850d2-119">MNISTModel クラスは MNIST モデルを表します。モデルを読み込むには、ONNX ファイルをパラメーターとして渡して CreateMNISTModel メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="850d2-119">The MNISTModel class represents the MNIST model, and to load the model, we call the CreateMNISTModel method, passing in the ONNX file as the parameter.</span></span>

```csharp
// Load the model
StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/MNIST.onnx"));
MNISTModel model = MNISTModel.CreateMNISTModel(modelFile);
```

## <a name="bind"></a><span data-ttu-id="850d2-120">バインド</span><span class="sxs-lookup"><span data-stu-id="850d2-120">Bind</span></span>

<span data-ttu-id="850d2-121">生成されたコードには、Input と Output のラッパー クラスも含まれています。</span><span class="sxs-lookup"><span data-stu-id="850d2-121">The generated code also includes Input and Output wrapper classes.</span></span> <span data-ttu-id="850d2-122">Input クラスはモデルが想定する入力を表し、Output クラスはモデルが想定する出力を表します。</span><span class="sxs-lookup"><span data-stu-id="850d2-122">The Input class represents the model's expected inputs, and the Output class represents the model's expected outputs.</span></span>

<span data-ttu-id="850d2-123">モデルの入力オブジェクトを初期化するには、アプリケーション データを渡して Input クラスのコンストラクターを呼び出します。このとき、入力データの型が、モデルが想定する入力型と一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="850d2-123">To initialize the model's input object, call the Input class constructor, passing in your application data, and make sure that your input data matches the input type that your model expects.</span></span> <span data-ttu-id="850d2-124">MNISTModelInput クラスは VideoFrame を想定しているため、ここではヘルパー メソッドを使って入力用の VideoFrame を取得します。</span><span class="sxs-lookup"><span data-stu-id="850d2-124">The MNISTModelInput class expects a VideoFrame, so we use a helper method to get a VideoFrame for the input.</span></span>

```csharp
//Bind the input data to the model
MNISTModelInputs ModelInput = new MNISTModelInputs();
ModelInput.Input3 = await helper.GetHandWrittenImage(inkGrid);
```

<span data-ttu-id="850d2-125">出力オブジェクトは *Null* 値に初期化され、次の手順である評価の完了後にモデルの結果で更新されます。</span><span class="sxs-lookup"><span data-stu-id="850d2-125">Output objects are initialized to *Null* values and will be updated with the model's results after the next step, Evaluate.</span></span>

## <a name="evaluate"></a><span data-ttu-id="850d2-126">評価</span><span class="sxs-lookup"><span data-stu-id="850d2-126">Evaluate</span></span>

<span data-ttu-id="850d2-127">入力が初期化されたら、モデルの EvaluateAsync メソッドを呼び出して、入力データに対してモデルを評価します。</span><span class="sxs-lookup"><span data-stu-id="850d2-127">Once your inputs are initialized, call the model's EvaluateAsync method to evaluate your model on the input data.</span></span> <span data-ttu-id="850d2-128">EvaluateAsync は、入力と出力をモデル オブジェクトにバインドし、入力に対してモデルを評価します。</span><span class="sxs-lookup"><span data-stu-id="850d2-128">EvaluateAsync binds your inputs and outputs to the model object and evaluates the model on the inputs.</span></span>

```csharp
// Evaluate the model
MNISTModelOuput ModelOutput = model.EvaluateAsync(ModelInput);
```

<span data-ttu-id="850d2-129">評価の完了後、出力にはモデルの結果が含まれています。この結果を参照して分析できます。</span><span class="sxs-lookup"><span data-stu-id="850d2-129">After evaluation, your output contains the model's results, which you now can view and analyze.</span></span> <span data-ttu-id="850d2-130">MNIST モデルの出力は一致する可能性のある数字のリストなので、そのリストを反復処理し、最も可能性の高い数字を見つけて表示します。</span><span class="sxs-lookup"><span data-stu-id="850d2-130">Since the MNIST model outputs a list of probabilities, we iterate through the list to find and display the digit with the highest probability.</span></span>

```csharp
 //Iterate through output to determine highest probability digit
float maxProb = 0;
int maxIndex = 0;
for (int i = 0; i < 10; i++)
{
    if (ModelOutput.Plus214_Output_0[i] > maxProb)
    {
        maxIndex = i;
        maxProb = ModelOutput.Plus214_Output_0[i];
    }
}
numberLabel.Text = maxIndex.ToString();
```

## <a name="using-the-windows-ml-apis-directly"></a><span data-ttu-id="850d2-131">Windows ML API の直接使用</span><span class="sxs-lookup"><span data-stu-id="850d2-131">Using the Windows ML APIs directly</span></span>

<span data-ttu-id="850d2-132">Windows ML の自動コード ジェネレーターは、独自のモデルを操作するための便利なインターフェイスを提供しますが、ラッパー クラスは使用しなくてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="850d2-132">Although Windows ML's automatic code generator provides a convenient interface to interact with your model, you don't have to use the wrapper classes.</span></span> <span data-ttu-id="850d2-133">代わりに、アプリで Windows ML API を直接呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="850d2-133">Instead, you can call the Windows ML APIs directly in your app.</span></span>
<span data-ttu-id="850d2-134">その場合も従うパターンは同じです。つまり、モデルを読み込み、入力と出力をバインドし、評価します。</span><span class="sxs-lookup"><span data-stu-id="850d2-134">If you choose to do so, you'll follow the same pattern: load your model, bind your inputs and outputs, and evaluate.</span></span>

<span data-ttu-id="850d2-135">API の使い方について詳しくは、「[Windows ML API リファレンス](/uwp/api/windows.ai.machinelearning.preview)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="850d2-135">For more information on using the APIs, see the [Windows ML API reference](/uwp/api/windows.ai.machinelearning.preview).</span></span>
