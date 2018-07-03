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
# <a name="get-started-with-windows-ml"></a>Windows ML を使ってみる

このチュートリアルでは、トレーニング済みの機械学習モデルを使ってユーザーが描画した数字を認識する、簡単な UWP アプリをビルドします。 このチュートリアルでは、アプリで Windows ML を読み込んで使用する方法に主に焦点を当てています。

## <a name="prerequisites"></a>前提条件

- [Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk) (ビルド 17110 以降)
- [Visual Studio](https://developer.microsoft.com/windows/downloads)

## <a name="1-download-the-sample"></a>1. サンプルをダウンロードする

最初に、GitHub から [MNIST_GetStarted サンプル](https://github.com/Microsoft/Windows-Machine-Learning)をダウンロードする必要があります。 次のような XAML コントロールとイベントを実装したテンプレートが用意されています。

- 数字を描画するための [InkCanvas](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.inkcanvas)。
- 数字の解釈とキャンバスの消去を行う[ボタン](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.button)。
- InkCanvas の出力を [VideoFrame](https://docs.microsoft.com/uwp/api/windows.media.videoframe) に変換するヘルパー ルーチン。

完全な MNIST サンプルも GitHub からダウンロードできます。

## <a name="2-open-project-in-visual-studio-preview"></a>2. Visual Studio Preview でプロジェクトを開く

Visual Studio Preview を起動し、MNIST サンプル アプリケーションを開きます  (ソリューションが利用不可として表示される場合は、右クリックして [プロジェクトの再読み込み] を選択する必要があります)。

ソリューション エクスプローラー内のプロジェクトには、次の 3 つのメイン コード ファイルがあります。

- `MainPage.xaml` - InkCanvas、ボタン、ラベルの UI を作成する XAML コードがすべて含まれています。
- `MainPage.xaml.cs` - アプリケーション コードが含まれています。
- `Helper.cs` - トリミングと画像形式の変換を行うヘルパー ルーチンが含まれています。

![Visual Studio のソリューション エクスプローラーとプロジェクト ファイル](images/get-started1.png)

## <a name="3-build-and-run-project"></a>3. プロジェクトをビルドして実行する

Visual Studio のツール バーで、ソリューション プラットフォームを "ARM" から "x64" に変更して、ローカル コンピューターでプロジェクトを実行できるようにします。

プロジェクトを実行するには、ツール バーの **[デバッグの開始]** ボタンをクリックするか、F5 キーを押します。 アプリケーションが開き、ユーザーが数字を描画できる InkCanvas、数字を解釈する [Recognize] ボタン、解釈された数字がテキストとして表示される空のラベル、InkCanvas を消去する [Clear Digit] ボタンが表示されます。

![アプリケーションのスクリーンショット](images/get-started2.png)

**注**: 17110 よりも後のビルドをダウンロードした場合は、プロジェクトの展開のターゲット バージョンを変更する必要が生じることがあります。 プロジェクト ソリューションの **[プロパティ]** に移動します。 [アプリケーション] タブで、使用中の OS と SDK に合わせてターゲット バージョンを設定します。

## <a name="4-download-a-model"></a>4. モデルをダウンロードする

次に、アプリに追加する機械学習モデルを入手します。 このチュートリアルでは、[Microsoft Cognitive Toolkit (CNTK)](https://docs.microsoft.com/cognitive-toolkit/) を使ってトレーニングされ、[ONNX 形式](https://github.com/onnx/tutorials/blob/master/tutorials/CntkOnnxExport.ipynb)にエクスポートされた事前トレーニング済みの **MNIST モデル**を使用します。

GitHub の MNIST_GetStarted サンプルを使っている場合は、MNIST モデルが既に Assets フォルダーに含まれているので、これを既存の項目としてアプリケーションに追加する必要があります。 また、GitHub の [ONNX Model Zoo](https://github.com/onnx/models) から事前トレーニング済みのモデルをダウンロードすることもできます。

独自のモデルのトレーニングに興味がある場合は、この MNIST モデルのトレーニングに使われた[チュートリアル](train-ai-model.md)をご覧ください。

## <a name="5-add-the-model"></a>5. モデルを追加する

MNIST モデルをダウンロードしたら、ソリューション エクスプローラーの [Assets] フォルダーを右クリックし、**[追加]** > **[既存の項目]** を選択します。 ファイル ピッカーで ONNX モデルの場所を参照し、[追加] をクリックします。

次の 2 つの新しいファイルがプロジェクトに追加されます。

- `MNIST.onnx` - トレーニング済みのモデル。
- `MNIST.cs` - Windows ML によって生成されたコード。

![新しいファイルが追加されたソリューション エクスプローラー](images/get-started3.png)

アプリケーションのコンパイル時にモデルがビルドされるようにするために、`mnist.onnx` ファイルを右クリックし、**[プロパティ]** を選択します。 **[ビルド アクション]** で **[コンテンツ]** を選択します。

ここで、新しく生成された `MNIST.cs` のコードを見てみましょう。 次の 3 つのクラスがあります。

- **MNISTModel** は、機械学習モデルの表現を作成し、特定の入力と出力をモデルにバインドして、モデルを非同期に評価します。 
- **MNISTModelInput** は、モデルが想定する入力の型を初期化します。 この場合、入力は VideoFrame が想定されています。
- **MNISTModelOutput** は、モデルによる出力の型を初期化します。 この場合、出力は "classLabel" という名前の `<long>` 型のリストと、"prediction" という名前の <long, float> 型のディクショナリになります。 `<long, float>`

これらのクラスを使って、プロジェクトでモデルを読み込み、バインドし、評価していきます。

## <a name="6-load-bind-and-evaluate-the-model"></a>6. モデルの読み込み、バインド、評価を行う

Windows ML アプリケーションでは、"読み込み > バインド > 評価" というパターンに従う必要があります。

- 機械学習モデルを読み込む。
- 入力と出力をモデルにバインドする。
- モデルを評価して結果を確認する。

ここでは、`MNIST.cs` に生成されたインターフェイス コードを使って、アプリでモデルを読み込み、バインドし、評価します。

最初に、`MainPage.xaml.cs` でモデル、入力、出力のインスタンスを作成します。

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

その後、LoadModel() でモデルを読み込みます。

```csharp
private async void LoadModel()
{
    //Load a machine learning model
    StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/MNIST.onnx"));
    ModelGen = await MNISTModel.CreateMNISTModel(modelFile);
}
```

次に、入力と出力をモデルにバインドします。 

このモデルでは、VideoFrame 型の入力を想定しています。 `helper.cs` に含まれるヘルパー関数を使って、InkCanvas の内容をコピーし、VideoFrame 型に変換して、モデルにバインドします。

```csharp
private async void recognizeButton_Click(object sender, RoutedEventArgs e)
{
     //Bind model input with contents from InkCanvas
     ModelInput.Input3 = await helper.GetHandWrittenImage(inkGrid);
}
```

出力は、指定された入力を渡して EvaluateAsync() を呼び出すだけです。 モデルからは一致する可能性のある数字のリストが返されるため、返されたリストを解析して、最も可能性の高い数字を決定し、それを表示する必要があります。

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

最後に、InkCanvas を消去して、ユーザーが別の数字を描画できるようにします。

```csharp
private void clearButton_Click(object sender, RoutedEventArgs e)
{
    inkCanvas.InkPresenter.StrokeContainer.Clear();
    numberLabel.Text = "";
}
```

## <a name="7-launch-the-app"></a>7. アプリを起動する

アプリをビルドして起動すると、InkCanvas に描画された数字を認識できるようになります。

![完成したアプリ](images/get-started4.png)

## <a name="8-next-steps"></a>8. 次のステップ

これで初めての Windows ML アプリが完成しました。 Windows ML の使い方を紹介する他のサンプルについては、[サンプル アプリ](samples.md)をチェックしてください。