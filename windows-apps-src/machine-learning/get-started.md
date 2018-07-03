---
author: serenaz
title: Windows ML を使ってみる
description: このステップ バイ ステップ チュートリアルを使って、初めての Windows ML アプリを作成しましょう。
ms.author: sezhen
ms.date: 03/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, Windows Machine Learning, WinML, Windows ML
ms.localizationpriority: medium
ms.openlocfilehash: eec2ada8e3aadad134381a93bca2652133912b2e
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843625"
---
# <a name="get-started-with-windows-ml"></a><span data-ttu-id="ac364-104">Windows ML を使ってみる</span><span class="sxs-lookup"><span data-stu-id="ac364-104">Get started with Windows ML</span></span>

<span data-ttu-id="ac364-105">このチュートリアルでは、トレーニング済みの機械学習モデルを使ってユーザーが描画した数字を認識する、簡単な UWP アプリをビルドします。</span><span class="sxs-lookup"><span data-stu-id="ac364-105">In this tutorial, we'll build a simple UWP app that uses a trained machine learning model to recognize a numeric digit drawn by the user.</span></span> <span data-ttu-id="ac364-106">このチュートリアルでは、アプリで Windows ML を読み込んで使用する方法に主に焦点を当てています。</span><span class="sxs-lookup"><span data-stu-id="ac364-106">This tutorial primarily focuses on how to load and use Windows ML in your app.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="ac364-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="ac364-107">Prerequisites</span></span>

- <span data-ttu-id="ac364-108">[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) (ビルド 17110 以降)</span><span class="sxs-lookup"><span data-stu-id="ac364-108">[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) (Build 17110 or higher)</span></span>
- [<span data-ttu-id="ac364-109">Visual Studio</span><span class="sxs-lookup"><span data-stu-id="ac364-109">Visual Studio</span></span>](https://developer.microsoft.com/windows/downloads)

## <a name="1-download-the-sample"></a><span data-ttu-id="ac364-110">1. サンプルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="ac364-110">1. Download the sample</span></span>

<span data-ttu-id="ac364-111">最初に、GitHub から [MNIST_GetStarted サンプル](https://github.com/Microsoft/Windows-Machine-Learning)をダウンロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac364-111">First, you'll need to download our [MNIST_GetStarted sample](https://github.com/Microsoft/Windows-Machine-Learning) from GitHub.</span></span> <span data-ttu-id="ac364-112">次のような XAML コントロールとイベントを実装したテンプレートが用意されています。</span><span class="sxs-lookup"><span data-stu-id="ac364-112">We've provided a template with implemented XAML controls and events, including:</span></span>

- <span data-ttu-id="ac364-113">数字を描画するための [InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)。</span><span class="sxs-lookup"><span data-stu-id="ac364-113">An [InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas) to draw the digit.</span></span>
- <span data-ttu-id="ac364-114">数字の解釈とキャンバスの消去を行う[ボタン](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.button)。</span><span class="sxs-lookup"><span data-stu-id="ac364-114">[Buttons](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.button) to interpret the digit and clear the canvas.</span></span>
- <span data-ttu-id="ac364-115">InkCanvas の出力を [VideoFrame](https://docs.microsoft.com/uwp/api/windows.media.videoframe) に変換するヘルパー ルーチン。</span><span class="sxs-lookup"><span data-stu-id="ac364-115">Helper routines to convert the InkCanvas output to a [VideoFrame](https://docs.microsoft.com/uwp/api/windows.media.videoframe).</span></span>

<span data-ttu-id="ac364-116">完全な MNIST サンプルも GitHub からダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="ac364-116">A completed MNIST sample is also available to download from GitHub.</span></span>

## <a name="2-open-project-in-visual-studio-preview"></a><span data-ttu-id="ac364-117">2. Visual Studio Preview でプロジェクトを開く</span><span class="sxs-lookup"><span data-stu-id="ac364-117">2. Open project in Visual Studio Preview</span></span>

<span data-ttu-id="ac364-118">Visual Studio Preview を起動し、MNIST サンプル アプリケーションを開きます </span><span class="sxs-lookup"><span data-stu-id="ac364-118">Launch Visual Studio Preview, and open the MNIST sample application.</span></span> <span data-ttu-id="ac364-119">(ソリューションが利用不可として表示される場合は、右クリックして [プロジェクトの再読み込み] を選択する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="ac364-119">(If the solution is shown as unavailable, you'll need to right-click and select "Reload Project.")</span></span>

<span data-ttu-id="ac364-120">ソリューション エクスプローラー内のプロジェクトには、次の 3 つのメイン コード ファイルがあります。</span><span class="sxs-lookup"><span data-stu-id="ac364-120">Inside the solution explorer, the project has three main code files:</span></span>

- `MainPage.xaml` <span data-ttu-id="ac364-121">- InkCanvas、ボタン、ラベルの UI を作成する XAML コードがすべて含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac364-121">- All of our XAML code to create the UI for the InkCanvas, buttons, and labels.</span></span>
- `MainPage.xaml.cs` <span data-ttu-id="ac364-122">- アプリケーション コードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac364-122">- Where our application code lives.</span></span>
- `Helper.cs` <span data-ttu-id="ac364-123">- トリミングと画像形式の変換を行うヘルパー ルーチンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ac364-123">- Helper routines to crop and convert image formats.</span></span>

![Visual Studio のソリューション エクスプローラーとプロジェクト ファイル](images/get-started1.png)

## <a name="3-build-and-run-project"></a><span data-ttu-id="ac364-125">3. プロジェクトをビルドして実行する</span><span class="sxs-lookup"><span data-stu-id="ac364-125">3. Build and run project</span></span>

<span data-ttu-id="ac364-126">Visual Studio のツール バーで、ソリューション プラットフォームを "ARM" から "x64" に変更して、ローカル コンピューターでプロジェクトを実行できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ac364-126">In the Visual Studio toolbar, change the Solution Platform from "ARM" to "x64" to run the project on your local machine.</span></span>

<span data-ttu-id="ac364-127">プロジェクトを実行するには、ツール バーの **[デバッグの開始]** ボタンをクリックするか、F5 キーを押します。</span><span class="sxs-lookup"><span data-stu-id="ac364-127">To run the project, click the **Start Debugging** button on the toolbar, or press F5.</span></span> <span data-ttu-id="ac364-128">アプリケーションが開き、ユーザーが数字を描画できる InkCanvas、数字を解釈する [Recognize] ボタン、解釈された数字がテキストとして表示される空のラベル、InkCanvas を消去する [Clear Digit] ボタンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ac364-128">The application should show an InkCanvas where users can write a digit, a "Recognize" button to interpret the number, an empty label field where the interpreted digit will be displayed as text, and a "Clear Digit" button to clear the InkCanvas.</span></span>

![アプリケーションのスクリーンショット](images/get-started2.png)

<span data-ttu-id="ac364-130">**注**: 17110 よりも後のビルドをダウンロードした場合は、プロジェクトの展開のターゲット バージョンを変更する必要が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="ac364-130">**Note**: If you downloaded a Build higher than 17110, then you might need to change the project's deployment target version.</span></span> <span data-ttu-id="ac364-131">プロジェクト ソリューションの **[プロパティ]** に移動します。</span><span class="sxs-lookup"><span data-stu-id="ac364-131">Under the project solution, go to **Properties**.</span></span> <span data-ttu-id="ac364-132">[アプリケーション] タブで、使用中の OS と SDK に合わせてターゲット バージョンを設定します。</span><span class="sxs-lookup"><span data-stu-id="ac364-132">In the Application tab, set the target version to match your OS and SDK.</span></span>

## <a name="4-download-a-model"></a><span data-ttu-id="ac364-133">4. モデルをダウンロードする</span><span class="sxs-lookup"><span data-stu-id="ac364-133">4. Download a model</span></span>

<span data-ttu-id="ac364-134">次に、アプリに追加する機械学習モデルを入手します。</span><span class="sxs-lookup"><span data-stu-id="ac364-134">Next, let's get a machine learning model to add to our app.</span></span> <span data-ttu-id="ac364-135">このチュートリアルでは、[Microsoft Cognitive Toolkit (CNTK)](https://docs.microsoft.com/cognitive-toolkit/) を使ってトレーニングされ、[ONNX 形式](https://github.com/onnx/tutorials/blob/master/tutorials/CntkOnnxExport.ipynb)にエクスポートされた事前トレーニング済みの **MNIST モデル**を使用します。</span><span class="sxs-lookup"><span data-stu-id="ac364-135">For this tutorial, we'll use a pre-trained **MNIST model** that was trained with the [Microsoft Cognitive Toolkit (CNTK)](https://docs.microsoft.com/cognitive-toolkit/) and [exported to ONNX format](https://github.com/onnx/tutorials/blob/master/tutorials/CntkOnnxExport.ipynb).</span></span>

<span data-ttu-id="ac364-136">GitHub の MNIST_GetStarted サンプルを使っている場合は、MNIST モデルが既に Assets フォルダーに含まれているので、これを既存の項目としてアプリケーションに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac364-136">If you are using the MNIST_GetStarted sample from GitHub, the MNIST model has already been included in your Assets folder, and you will need to add it to your application as an existing item.</span></span> <span data-ttu-id="ac364-137">また、GitHub の [ONNX Model Zoo](https://github.com/onnx/models) から事前トレーニング済みのモデルをダウンロードすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ac364-137">You can also download the pre-trained model from the [ONNX Model Zoo](https://github.com/onnx/models) on GitHub.</span></span>

<span data-ttu-id="ac364-138">独自のモデルのトレーニングに興味がある場合は、この MNIST モデルのトレーニングに使われた[チュートリアル](train-ai-model.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ac364-138">If you're interested in training your own model, you can follow this [tutorial](train-ai-model.md) that we used to train this MNIST model.</span></span>

## <a name="5-add-the-model"></a><span data-ttu-id="ac364-139">5. モデルを追加する</span><span class="sxs-lookup"><span data-stu-id="ac364-139">5. Add the model</span></span>

<span data-ttu-id="ac364-140">MNIST モデルをダウンロードしたら、ソリューション エクスプローラーの [Assets] フォルダーを右クリックし、**[追加]** > **[既存の項目]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ac364-140">After downloading the MNIST model, right click on the Assets folder in the Solution Explorer, and select "**Add** > **Existing Item**".</span></span> <span data-ttu-id="ac364-141">ファイル ピッカーで ONNX モデルの場所を参照し、[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ac364-141">Point the file picker to the location of your ONNX model, and click add.</span></span>

<span data-ttu-id="ac364-142">次の 2 つの新しいファイルがプロジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="ac364-142">The project should now have two new files:</span></span>

- `MNIST.onnx` <span data-ttu-id="ac364-143">- トレーニング済みのモデル。</span><span class="sxs-lookup"><span data-stu-id="ac364-143">- your trained model.</span></span>
- `MNIST.cs` <span data-ttu-id="ac364-144">- Windows ML によって生成されたコード。</span><span class="sxs-lookup"><span data-stu-id="ac364-144">- the Windows ML generated code.</span></span>

![新しいファイルが追加されたソリューション エクスプローラー](images/get-started3.png)

<span data-ttu-id="ac364-146">アプリケーションのコンパイル時にモデルがビルドされるようにするために、`mnist.onnx` ファイルを右クリックし、**[プロパティ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ac364-146">To make sure the model builds when we compile our application, right click on the `mnist.onnx` file, and select **Properties**.</span></span> <span data-ttu-id="ac364-147">**[ビルド アクション]** で **[コンテンツ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="ac364-147">For **Build Action**, select **Content**.</span></span>

<span data-ttu-id="ac364-148">ここで、新しく生成された `MNIST.cs` のコードを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="ac364-148">Now, let's take a look at the newly generated code in the `MNIST.cs` file.</span></span> <span data-ttu-id="ac364-149">次の 3 つのクラスがあります。</span><span class="sxs-lookup"><span data-stu-id="ac364-149">We have three classes:</span></span>

- <span data-ttu-id="ac364-150">**MNISTModel** は、機械学習モデルの表現を作成し、特定の入力と出力をモデルにバインドして、モデルを非同期に評価します。</span><span class="sxs-lookup"><span data-stu-id="ac364-150">**MNISTModel** creates the machine learning model representation, binds the specific inputs and outputs to model, and evaluates the model asynchronously.</span></span> 
- <span data-ttu-id="ac364-151">**MNISTModelInput** は、モデルが想定する入力の型を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ac364-151">**MNISTModelInput** initializes the input types that the model expects.</span></span> <span data-ttu-id="ac364-152">この場合、入力は VideoFrame が想定されています。</span><span class="sxs-lookup"><span data-stu-id="ac364-152">In this case, the input expects a VideoFrame.</span></span>
- <span data-ttu-id="ac364-153">**MNISTModelOutput** は、モデルによる出力の型を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ac364-153">**MNISTModelOutput** initializes the types that the model will output.</span></span> <span data-ttu-id="ac364-154">この場合、出力は "classLabel" という名前の `<long>` 型のリストと、"prediction" という名前の <long, float> 型のディクショナリになります。</span><span class="sxs-lookup"><span data-stu-id="ac364-154">In this case, the output will be a list called "classLabel" of type `<long>` and a Dictionary called "prediction" of type</span></span> `<long, float>`

<span data-ttu-id="ac364-155">これらのクラスを使って、プロジェクトでモデルを読み込み、バインドし、評価していきます。</span><span class="sxs-lookup"><span data-stu-id="ac364-155">We'll now use these classes to load, bind, and evaluate the model in our project.</span></span>

## <a name="6-load-bind-and-evaluate-the-model"></a><span data-ttu-id="ac364-156">6. モデルの読み込み、バインド、評価を行う</span><span class="sxs-lookup"><span data-stu-id="ac364-156">6. Load, bind, and evaluate the model</span></span>

<span data-ttu-id="ac364-157">Windows ML アプリケーションでは、"読み込み > バインド > 評価" というパターンに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac364-157">For Windows ML applications, the pattern we want to follow is: Load > Bind > Evaluate.</span></span>

- <span data-ttu-id="ac364-158">機械学習モデルを読み込む。</span><span class="sxs-lookup"><span data-stu-id="ac364-158">Load the machine learning model.</span></span>
- <span data-ttu-id="ac364-159">入力と出力をモデルにバインドする。</span><span class="sxs-lookup"><span data-stu-id="ac364-159">Bind inputs and outputs to the model.</span></span>
- <span data-ttu-id="ac364-160">モデルを評価して結果を確認する。</span><span class="sxs-lookup"><span data-stu-id="ac364-160">Evaluate the model and view results.</span></span>

<span data-ttu-id="ac364-161">ここでは、`MNIST.cs` に生成されたインターフェイス コードを使って、アプリでモデルを読み込み、バインドし、評価します。</span><span class="sxs-lookup"><span data-stu-id="ac364-161">We'll use the interface code generated in `MNIST.cs` to load, bind, and evaluate the model in our app.</span></span>

<span data-ttu-id="ac364-162">最初に、`MainPage.xaml.cs` でモデル、入力、出力のインスタンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="ac364-162">First, in `MainPage.xaml.cs`, let's instantiate the model, inputs, and outputs.</span></span>

```csharp
namespace MNIST_Demo
{
    public sealed partial class MainPage : Page
    {
        private MNISTModel ModelGen = new MNISTModel();
        private MNISTModelInput ModelInput = new MNISTModelInput();
        private MNISTModelOutput ModelOutput = new MNISTModelOutput();
        ...
    }
}
```

<span data-ttu-id="ac364-163">その後、LoadModel() でモデルを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="ac364-163">Then, in LoadModel(), we'll load the model.</span></span>

```csharp
private async void LoadModel()
{
    //Load a machine learning model
    StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/MNIST.onnx"));
    ModelGen = await MNISTModel.CreateMNISTModel(modelFile);
}
```

<span data-ttu-id="ac364-164">次に、入力と出力をモデルにバインドします。</span><span class="sxs-lookup"><span data-stu-id="ac364-164">Next, we want to bind our inputs and outputs to the model.</span></span> 

<span data-ttu-id="ac364-165">このモデルでは、VideoFrame 型の入力を想定しています。</span><span class="sxs-lookup"><span data-stu-id="ac364-165">In this case, our model is expecting an input of type VideoFrame.</span></span> <span data-ttu-id="ac364-166">`helper.cs` に含まれるヘルパー関数を使って、InkCanvas の内容をコピーし、VideoFrame 型に変換して、モデルにバインドします。</span><span class="sxs-lookup"><span data-stu-id="ac364-166">Using our included helper functions in `helper.cs`, we will copy the contents of the InkCanvas, convert it to type VideoFrame, and bind it to our model.</span></span>

```csharp
private async void recognizeButton_Click(object sender, RoutedEventArgs e)
{
     //Bind model input with contents from InkCanvas
     ModelInput.Input3 = await helper.GetHandWrittenImage(inkGrid);
}
```

<span data-ttu-id="ac364-167">出力は、指定された入力を渡して EvaluateAsync() を呼び出すだけです。</span><span class="sxs-lookup"><span data-stu-id="ac364-167">For output, we simply call EvaluateAsync() with the specified input.</span></span> <span data-ttu-id="ac364-168">モデルからは一致する可能性のある数字のリストが返されるため、返されたリストを解析して、最も可能性の高い数字を決定し、それを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ac364-168">Since the model returns a list of digits with a corresponding probability, we need to parse the returned list to determine which digit had the highest probability and display that one.</span></span>

```csharp
private async void recognizeButton_Click(object sender, RoutedEventArgs e)
{
    //Bind model input with contents from InkCanvas
    ModelInput.Input3 = await helper.GetHandWrittenImage(inkGrid);
    
    //Evaluate the model
    ModelOutput = await ModelGen.EvaluateAsync(ModelInput);
            
    //Iterate through evaluation output to determine highest probability digit
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
}
```

<span data-ttu-id="ac364-169">最後に、InkCanvas を消去して、ユーザーが別の数字を描画できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ac364-169">Finally, we'll want to clear out the InkCanvas to allow users to draw another number.</span></span>

```csharp
private void clearButton_Click(object sender, RoutedEventArgs e)
{
    inkCanvas.InkPresenter.StrokeContainer.Clear();
    numberLabel.Text = "";
}
```

## <a name="7-launch-the-app"></a><span data-ttu-id="ac364-170">7. アプリを起動する</span><span class="sxs-lookup"><span data-stu-id="ac364-170">7. Launch the app</span></span>

<span data-ttu-id="ac364-171">アプリをビルドして起動すると、InkCanvas に描画された数字を認識できるようになります。</span><span class="sxs-lookup"><span data-stu-id="ac364-171">Once we build and launch the app, we'll be able to recognize a number drawn on the InkCanvas.</span></span>

![完成したアプリ](images/get-started4.png)

## <a name="8-next-steps"></a><span data-ttu-id="ac364-173">8. 次のステップ</span><span class="sxs-lookup"><span data-stu-id="ac364-173">8. Next steps</span></span>

<span data-ttu-id="ac364-174">これで初めての Windows ML アプリが完成しました。</span><span class="sxs-lookup"><span data-stu-id="ac364-174">That's it - you've made your first Windows ML app!</span></span> <span data-ttu-id="ac364-175">Windows ML の使い方を紹介する他のサンプルについては、[サンプル アプリ](samples.md)をチェックしてください。</span><span class="sxs-lookup"><span data-stu-id="ac364-175">For more samples that demonstrate how to use Windows ML, check out [Sample apps](samples.md).</span></span>