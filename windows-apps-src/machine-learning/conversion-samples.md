---
author: wschin
title: 既存の ML モデルを ONNX に変換する
description: WinMLTools を使って scikit-learn や Core ML の既存のモデルを ONNX 形式に変換する方法を、コード サンプルを示して説明します。
ms.author: sezhen
ms.date: 3/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, Windows Machine Learning, WinML, WinMLTools, ONNX, ONNXMLTools, scikit-learn, Core ML
ms.localizationpriority: medium
ms.openlocfilehash: 7b2e9c8b661ccd2b0358882992da6c4f160b49f0
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843002"
---
# <a name="convert-existing-ml-models-to-onnx"></a>既存の ML モデルを ONNX に変換する

[WinMLTools](https://pypi.org/project/winmltools/) を使うと、他のフレームワークでトレーニングされたモデルを ONNX 形式に変換できます。 ここでは、WinMLTools パッケージのインストール方法と、Python コードを使って scikit-learn や Core ML の既存のモデルを ONNX に変換する方法を示します。

## <a name="install-winmltools"></a>WinMLTools のインストール

WinMLTools は、Python バージョン 2.7 および 3.6 をサポートする Python パッケージ (winmltools) です。 データ サイエンス プロジェクトを扱う場合は、Anaconda などのサイエンス向けの Python ディストリビューションをインストールすることをお勧めします。

WinMLTools は、[Python パッケージの標準のインストール手順](https://packaging.python.org/installing/)に従っています。 Python 環境から次のコマンドを実行します。

```
pip install winmltools
```

WinMLTools には次の依存関係があります。

- numpy v1.10.0 以降
- onnxmltools 0.1.0.0 以降
- protobuf v.3.1.0 以降

依存パッケージを更新するには、pip コマンドに '-U' 引数を付けて実行してください。

```
pip install -U winmltools
```

onnxmltools の依存関係について詳しくは、GitHub の [onnxmltools](https://github.com/onnx/onnxmltools) をご覧ください。

WinMLTools の使い方の詳細については、ヘルプ機能でパッケージ固有のドキュメントを参照してください。

```
help(winmltools)
```

> [!NOTE]
> Visual Studio Tools for AI 拡張機能を使用すると、Visual Studio IDE 内の WinMLTools も使用して、よりわかりやすいクリック スルー エクスペリエンスを通じてモデルを ONNX 形式に変換できます。 詳細については、「[VS Tools for AI](https://github.com/Microsoft/vs-tools-for-ai/)」を参照してください。

## <a name="scikit-learn-models"></a>Scikit-learn モデル

次のコード スニペットでは、scikit-learn で線形サポート ベクトル マシンをトレーニングし、モデルを ONNX に変換します。

~~~python
# First, we create a toy data set.
# The training matrix X contains three examples, with two features each.
# The label vector, y, stores the labels of all examples.
X = [[0.5, 1.], [-1., -1.5], [0., -2.]]
y = [1, -1, -1]

# Then, we create a linear classifier and train it.
from sklearn.svm import LinearSVC
linear_svc = LinearSVC()
linear_svc.fit(X, y)

# To convert scikit-learn models, we need to specify the input feature's name and type for our converter. 
# The following line means we have a 2-D float feature vector, and its name is "input" in ONNX.
# The automatic code generator (mlgen) uses the name parameter to generate class names.
from winmltools import convert_sklearn
linear_svc_onnx = convert_sklearn(linear_svc, name='LinearSVC', input_features=[('input', 'float', 2)])    

# Now, we save the ONNX model into binary format.
from winmltools.utils import save_model
save_model(linear_svc_onnx, 'linear_svc.onnx')

# If you'd like to load an ONNX binary file, our tool can also help.
from winmltools.utils import load_model
linear_svc_onnx = load_model('linear_svc.onnx')

# To see the produced ONNX model, we can print its contents or save it in text format.
print(linear_svc_onnx)
from winmltools.utils import save_text
save_text(linear_svc_onnx, 'linear_svc.txt')

# The conversion of linear regression is very similar. See the example below.
from sklearn.svm import LinearSVR
linear_svr = LinearSVR()
linear_svr.fit(X, y)
linear_svr_onnx = convert_sklearn(linear_svr, name='LinearSVR', input_features=[('input', 'float', 2)])   
~~~

ユーザーは、`LinearSVC` を `RandomForestClassifier` などの他の scikit-learn モデルに置き換えることができます。 [自動コード ジェネレーター](overview.md#automatic-interface-code-generation)では、`name` パラメーターを使ってクラス名と変数を生成することに注意してください。 `name` が指定されていない場合は GUID が生成されますが、これは C++/C# などの言語の名前付け規則に準拠しません。 

## <a name="scikit-learn-pipelines"></a>Scikit-learn パイプライン

次に、scikit-learn パイプラインを ONNX に変換する方法を示します。

~~~python
# First, we create a toy data set.
# Notice that the first example's last feature value, 300, is large.
X = [[0.5, 1., 300.], [-1., -1.5, -4.], [0., -2., -1.]]
y = [1, -1, -1]

# Then, we declare a linear classifier.
from sklearn.svm import LinearSVC
linear_svc = LinearSVC()

# One common trick to improve a linear model's performance is to normalize the input data.
from sklearn.preprocessing import Normalizer
normalizer = Normalizer()

# Here, we compose our scikit-learn pipeline. 
# First, we apply our normalization. 
# Then we feed the normalized data into the linear model.
from sklearn.pipeline import make_pipeline
pipeline = make_pipeline(normalizer, linear_svc)
pipeline.fit(X, y)

# Now, we convert the scikit-learn pipeline into ONNX format. 
# Compared to the previous example, notice that the specified feature dimension becomes 3.
# The automatic code generator (mlgen) uses the name parameter to generate class names.
from winmltools import convert_sklearn
pipeline_onnx = convert_sklearn(linear_svc, name='NormalizerLinearSVC', input_features=[('input', 'float', 3)])   

# We can print the fresh ONNX model.
print(pipeline_onnx)

# We can also save the ONNX model into binary file for later use.
from winmltools.utils import save_model
save_model(pipeline_onnx, 'pipeline.onnx')

# Our conversion framework provides limited support of heterogeneous feature values.
# We cannot have numerical types and string type in one feature vector. 
# Let's assume that the first two features are floats and the last feature is integer (encoded a categorical attribute).
X_heter = [[0.5, 1., 300], [-1., -1.5, 400], [0., -2., 100]]

# One popular way to represent categorical is one-hot encoding.
from sklearn.preprocessing import OneHotEncoder
one_hot_encoder = OneHotEncoder(categorical_features=[2])

# Let's initialize a classifier. 
# It will be right after the one-hot encoder in our pipeline.
linear_svc = LinearSVC()

# Then, we form a two-stage pipeline.
another_pipeline = make_pipeline(one_hot_encoder, linear_svc)
another_pipeline.fit(X_heter, y)

# Now, we convert, save, and load the converted model. 
# For heterogeneous feature vectors, we need to seperately specify their types for all homogeneous segments.
# The automatic code generator (mlgen) uses the name parameter to generate class names.
another_pipeline_onnx = convert_sklearn(another_pipeline, name='OneHotLinearSVC', input_features=[('input', 'float', 2), ('another_input', 'int64', 1)])
save_model(another_pipeline_onnx, 'another_pipeline.onnx')
from winmltools.utils import load_model
loaded_onnx_model = load_model('another_pipeline.onnx')

# Of course, we can print the ONNX model to see if anything went wrong.
print(another_pipeline_onnx)
~~~

## <a name="core-ml-models"></a>Core ML モデル

ここでは、サンプルの Core ML モデル ファイルのパスが *example.mlmodel* であると想定します。

~~~python
from coremltools.models.utils import load_spec
# Load model file
model_coreml = load_spec('example.mlmodel')
from winmltools import convert_coreml
# Convert it!
# The automatic code generator (mlgen) uses the name parameter to generate class names.
model_onnx = convert_coreml(model_coreml, name='ExampleModel')   
~~~

`model_onnx` は ONNX の [ModelProto](https://github.com/onnx/onnxmltools/blob/0f453c3f375c1ae928b83a4c7909c82c013a5bff/onnxmltools/proto/onnx-ml.proto#L176) オブジェクトです。 これは 2 つの異なる形式で保存できます。

~~~python
from winmltools.utils import save_model
# Save the produced ONNX model in binary format
save_model(model_onnx, 'example.onnx')
# Save the produced ONNX model in text format
from winmltools.utils import save_text
save_text(model_onnx, 'example.txt')
~~~

**注**: CoreMLTools は Apple から提供される Python パッケージですが、Windows 向けには用意されていません。 このパッケージを Windows にインストールする必要がある場合は、リポジトリからパッケージを直接インストールしてください。

```
pip install git+https://github.com/apple/coremltools
```

## <a name="core-ml-models-with-image-inputs-or-outputs"></a>画像を入力または出力する Core ML モデル

ONNX には画像を表す型がないため、Core ML の画像モデル (画像を入力または出力として使うモデル) を変換するには、前処理と後処理の手順が必要になります。

前処理の目的は、入力画像を ONNX のテンソルとして適切な形式にすることです。 たとえば、*X* が [C, H, W] という形状の Core ML の画像入力であるとします。 ONNX では、変数 *X* は同じ形状の浮動小数点テンソルとなり、*X*[0, :, :]/*X*[1, :, :]/*X*[2, :, :] に画像の赤/緑/青チャネルが格納されます。 Core ML のグレー スケール画像については、ONNX での形式は [1, H, W] テンソルになります。これはチャネルが 1 つしかないためです。

元の Core ML モデルの出力が画像の場合は、ONNX の出力の浮動小数点テンソルを手動で画像に変換します。 基本的な手順は 2 つあります。 最初の手順として、255 より大きい値を 255 に切り詰め、すべての負の値を 0 に変更します。 2 番目の手順として、すべてのピクセル値を整数に丸めます (0.5 を加えてから小数点以下を切り捨てます)。 出力のチャネルの順序 (RGB、BGR など) は Core ML モデルに示されています。 適切な画像出力を生成するには、転置やシャッフルによって目的の形式を回復する必要がある場合があります。

ここで、ONNX と Core ML の形式の違いを示す実際の変換の例として、[GitHub](https://github.com/likedan/Awesome-CoreML-Models) からダウンロードできる FNS-Candy という Core ML モデルを見てみましょう。 以降のコマンドはすべて python 環境で実行します。

まず、Core ML モデルを読み込み、入力形式と出力形式を調べます。

~~~python
from coremltools.models.utils import load_spec
model_coreml = load_spec('FNS-Candy.mlmodel')
model_coreml.description # Print the content of Core ML model description
~~~

画面出力:

~~~
...
input {
    ...
      imageType {
      width: 720
      height: 720
      colorSpace: BGR
    ...
}
...
output {
    ...
      imageType {
      width: 720
      height: 720
      colorSpace: BGR
    ...
}
...
~~~

この場合、入力と出力はどちらも 720x720 の BGR 画像です。 次の手順では、WinMLTools を使って Core ML モデルを変換します。

~~~python
# The automatic code generator (mlgen) uses the name parameter to generate class names.
from onnxmltools import convert_coreml
model_onnx = convert_coreml(model_coreml, name='FNSCandy')    
~~~

ONNX でのモデルの入力形式と出力形式を確認する別の方法として、次のコマンドを使用できます。

~~~python
model_onnx.graph.input # Print out the ONNX input tensor's information
~~~

画面出力:

~~~
...
  tensor_type {
    elem_type: FLOAT
    shape {
      dim {
        dim_param: "None"
      }
      dim {
        dim_value: 3
      }
      dim {
        dim_value: 720
      }
      dim {
        dim_value: 720
      }
    }
  }
...
~~~

生成された ONNX の入力 (以下 *X*) は 4-D テンソルです。 最後の 3 つの軸はそれぞれ C-、H-、W-軸です。 1 次元目は "None" で、この ONNX モデルが任意の数の画像に適用できることを意味します。 このモデルを適用して 2 つの画像を一括で処理する場合、最初の画像は *X*[0, :, :, :] に対応し、2 番目の画像は *X*[1, :, :, :] に対応します。 最初の画像の青/緑/赤のチャネルは *X*[0, 0, :, :]/*X*[0, 1, :, :]/*X*[0, 2, :, :] となり、2 番目の画像も同様です。

~~~python
model_onnx.graph.output # Print out the ONNX output tensor's information
~~~

画面出力:

~~~
...
  tensor_type {
    elem_type: FLOAT
    shape {
      dim {
        dim_param: "None"
      }
      dim {
        dim_value: 3
      }
      dim {
        dim_value: 720
      }
      dim {
        dim_value: 720
      }
    }
  }
...
~~~

ご覧のように、生成される形式は元のモデルの入力形式と同じです。 ただし、これは画像ではありません。画像では、ピクセル値が不動小数点数ではなく整数になります。 再び画像に変換するには、255 より大きい値を 255 に切り詰め、負の値を 0 に変更し、すべての少数を整数に丸めます。