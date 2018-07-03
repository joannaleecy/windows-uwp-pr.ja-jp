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
# <a name="integrate-a-model-into-your-app-with-windows-ml"></a>Windows ML でモデルをアプリに統合する

Windows ML の[自動コード生成](overview.md#automatic-interface-code-generation)を使うと、[Windows ML API](/uwp/api/windows.ai.machinelearning.preview) を自動的に呼び出すインターフェイスが作成され、独自のモデルを簡単に操作できるようになります。 生成されたインターフェイスのラッパー クラスを使うことで、読み込み、バインド、評価のパターンに従って ML モデルをアプリに統合できます。

![読み込み、バインド、評価](images/load-bind-evaluate.png)

この記事では、「[使ってみる](get-started.md)」で取り上げた MNIST モデルを使って、アプリでモデルの読み込み、バインド、評価を行う方法を示します。

## <a name="add-the-model"></a>モデルの追加

最初に、ONNX モデルを Visual Studio プロジェクトのアセットに追加する必要があります。 [Visual Studio (Version 15.7 - Preview 1)](https://www.visualstudio.com/vs/preview/) で UWP アプリをビルドする場合は、Visual Studio によって自動的に新しいファイルにラッパー クラスが作成されます。 その他のワークフローでは、[mlgen](overview.md#automatic-interface-code-generation) ツールを使ってラッパー クラスを生成する必要があります。

Windows ML で生成された MNIST モデルのラッパー クラスを以下に示します。 この記事の残りの部分では、これらのクラスをアプリで使用する方法について説明します。

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

**注**: アプリケーションのコンパイル時にモデルがビルドされるようにするには、`.onnx` ファイルを右クリックし、**[プロパティ]** を選択します。 **[ビルド アクション]** で **[コンテンツ]** を選択します。

## <a name="load"></a>読み込み

ラッパー クラスが生成されたら、アプリでモデルを読み込みます。

MNISTModel クラスは MNIST モデルを表します。モデルを読み込むには、ONNX ファイルをパラメーターとして渡して CreateMNISTModel メソッドを呼び出します。

```csharp
// Load the model
StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/MNIST.onnx"));
MNISTModel model = MNISTModel.CreateMNISTModel(modelFile);
```

## <a name="bind"></a>バインド

生成されたコードには、Input と Output のラッパー クラスも含まれています。 Input クラスはモデルが想定する入力を表し、Output クラスはモデルが想定する出力を表します。

モデルの入力オブジェクトを初期化するには、アプリケーション データを渡して Input クラスのコンストラクターを呼び出します。このとき、入力データの型が、モデルが想定する入力型と一致している必要があります。 MNISTModelInput クラスは VideoFrame を想定しているため、ここではヘルパー メソッドを使って入力用の VideoFrame を取得します。

```csharp
//Bind the input data to the model
MNISTModelInputs ModelInput = new MNISTModelInputs();
ModelInput.Input3 = await helper.GetHandWrittenImage(inkGrid);
```

出力オブジェクトは *Null* 値に初期化され、次の手順である評価の完了後にモデルの結果で更新されます。

## <a name="evaluate"></a>評価

入力が初期化されたら、モデルの EvaluateAsync メソッドを呼び出して、入力データに対してモデルを評価します。 EvaluateAsync は、入力と出力をモデル オブジェクトにバインドし、入力に対してモデルを評価します。

```csharp
// Evaluate the model
MNISTModelOuput ModelOutput = model.EvaluateAsync(ModelInput);
```

評価の完了後、出力にはモデルの結果が含まれています。この結果を参照して分析できます。 MNIST モデルの出力は一致する可能性のある数字のリストなので、そのリストを反復処理し、最も可能性の高い数字を見つけて表示します。

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

## <a name="using-the-windows-ml-apis-directly"></a>Windows ML API の直接使用

Windows ML の自動コード ジェネレーターは、独自のモデルを操作するための便利なインターフェイスを提供しますが、ラッパー クラスは使用しなくてもかまいません。 代わりに、アプリで Windows ML API を直接呼び出すことができます。
その場合も従うパターンは同じです。つまり、モデルを読み込み、入力と出力をバインドし、評価します。

API の使い方について詳しくは、「[Windows ML API リファレンス](/uwp/api/windows.ai.machinelearning.preview)」をご覧ください。
