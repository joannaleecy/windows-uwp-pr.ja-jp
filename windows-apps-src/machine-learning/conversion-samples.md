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
ms.openlocfilehash: 882efca26730c990093a89a5ed3ff4b5587e05bf
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832680"
---
# <a name="convert-existing-ml-models-to-onnx"></a><span data-ttu-id="e71bd-104">既存の ML モデルを ONNX に変換する</span><span class="sxs-lookup"><span data-stu-id="e71bd-104">Convert existing ML models to ONNX</span></span>

<span data-ttu-id="e71bd-105">[WinMLTools](https://aka.ms/winmltools) を使うと、他のフレームワークでトレーニングされたモデルを ONNX 形式に変換できます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-105">[WinMLTools](https://aka.ms/winmltools) allows users to convert models trained in other frameworks to ONNX format.</span></span> <span data-ttu-id="e71bd-106">ここでは、WinMLTools パッケージのインストール方法と、Python コードを使って scikit-learn や Core ML の既存のモデルを ONNX に変換する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-106">Here we demonstrate how to install the WinMLTools package and how to convert existing models in scikit-learn and Core ML into ONNX via Python code.</span></span>

## <a name="install-winmltools"></a><span data-ttu-id="e71bd-107">WinMLTools のインストール</span><span class="sxs-lookup"><span data-stu-id="e71bd-107">Install WinMLTools</span></span>

<span data-ttu-id="e71bd-108">WinMLTools は、Python バージョン 2.7 および 3.6 をサポートする Python パッケージ (winmltools) です。</span><span class="sxs-lookup"><span data-stu-id="e71bd-108">WinMLTools is a Python package (winmltools) that supports Python versions 2.7 and 3.6.</span></span> <span data-ttu-id="e71bd-109">データ サイエンス プロジェクトを扱う場合は、Anaconda などのサイエンス向けの Python ディストリビューションをインストールすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e71bd-109">If you are working on a data science project, we recommend installing a scientific Python distribution such as Anaconda.</span></span>

<span data-ttu-id="e71bd-110">WinMLTools は、[Python パッケージの標準のインストール手順](https://packaging.python.org/installing/)に従っています。</span><span class="sxs-lookup"><span data-stu-id="e71bd-110">WinMLTools follows the [standard python package installation process](https://packaging.python.org/installing/).</span></span> <span data-ttu-id="e71bd-111">Python 環境から次のコマンドを実行します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-111">From your python environment, run:</span></span>

```
pip install winmltools
```

<span data-ttu-id="e71bd-112">WinMLTools には次の依存関係があります。</span><span class="sxs-lookup"><span data-stu-id="e71bd-112">WinMLTools has the following dependencies:</span></span>

- <span data-ttu-id="e71bd-113">numpy v1.10.0 以降</span><span class="sxs-lookup"><span data-stu-id="e71bd-113">numpy v1.10.0+</span></span>
- <span data-ttu-id="e71bd-114">onnxmltools 0.1.0.0 以降</span><span class="sxs-lookup"><span data-stu-id="e71bd-114">onnxmltools 0.1.0.0+</span></span>
- <span data-ttu-id="e71bd-115">protobuf v.3.1.0 以降</span><span class="sxs-lookup"><span data-stu-id="e71bd-115">protobuf v.3.1.0+</span></span>

<span data-ttu-id="e71bd-116">依存パッケージを更新するには、pip コマンドに '-U' 引数を付けて実行してください。</span><span class="sxs-lookup"><span data-stu-id="e71bd-116">To update the dependent packages, please run the pip command with ‘-U’ argument.</span></span>

```
pip install -U winmltools
```

<span data-ttu-id="e71bd-117">onnxmltools の依存関係について詳しくは、GitHub の [onnxmltools](https://github.com/onnx/onnxmltools) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e71bd-117">Please follow [onnxmltools](https://github.com/onnx/onnxmltools) on GitHub for further information on onnxmltools dependencies.</span></span>

<span data-ttu-id="e71bd-118">WinMLTools の使い方について詳しくは、ヘルプ機能でパッケージ固有のドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e71bd-118">Additional details on how to use WinMLTools can be found on the package specific documentation with the help function.</span></span>

```
help(winmltools)
```

## <a name="scikit-learn-models"></a><span data-ttu-id="e71bd-119">Scikit-learn モデル</span><span class="sxs-lookup"><span data-stu-id="e71bd-119">Scikit-learn models</span></span>

<span data-ttu-id="e71bd-120">次のコード スニペットでは、scikit-learn で線形サポート ベクトル マシンをトレーニングし、モデルを ONNX に変換します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-120">The following code snippet trains a linear support vector machine in scikit-learn and converts the model into ONNX.</span></span>

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

<span data-ttu-id="e71bd-121">ユーザーは、`LinearSVC` を `RandomForestClassifier` などの他の scikit-learn モデルに置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-121">Users can replace `LinearSVC` with other scikit-learn models such as `RandomForestClassifier`.</span></span> <span data-ttu-id="e71bd-122">[自動コード ジェネレーター](overview.md#automatic-interface-code-generation)では、`name` パラメーターを使ってクラス名と変数を生成することに注意してください。</span><span class="sxs-lookup"><span data-stu-id="e71bd-122">Please note that the [automatic code generator](overview.md#automatic-interface-code-generation) uses the `name` parameter to generate class names and variables.</span></span> <span data-ttu-id="e71bd-123">`name` が指定されていない場合は GUID が生成されますが、これは C++/C# などの言語の名前付け規則に準拠しません。</span><span class="sxs-lookup"><span data-stu-id="e71bd-123">If `name` is not provided, then a GUID is generated, which will not comply with variable naming conventions for languages like C++/C#.</span></span> 

## <a name="scikit-learn-pipelines"></a><span data-ttu-id="e71bd-124">Scikit-learn パイプライン</span><span class="sxs-lookup"><span data-stu-id="e71bd-124">Scikit-learn pipelines</span></span>

<span data-ttu-id="e71bd-125">次に、scikit-learn パイプラインを ONNX に変換する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-125">Next, we show how scikit-learn pipelines can be converted into ONNX.</span></span>

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

## <a name="core-ml-models"></a><span data-ttu-id="e71bd-126">Core ML モデル</span><span class="sxs-lookup"><span data-stu-id="e71bd-126">Core ML models</span></span>

<span data-ttu-id="e71bd-127">ここでは、サンプルの Core ML モデル ファイルのパスが *example.mlmodel* であると想定します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-127">Here, we assume that the path of an example Core ML model file is *example.mlmodel*.</span></span>

~~~python
from coremltools.models.utils import load_spec
# Load model file
model_coreml = load_spec('example.mlmodel')
from winmltools import convert_coreml
# Convert it!
# The automatic code generator (mlgen) uses the name parameter to generate class names.
model_onnx = convert_coreml(model_coreml, name='ExampleModel')   
~~~

<span data-ttu-id="e71bd-128">`model_onnx` は ONNX の [ModelProto](https://github.com/onnx/onnxmltools/blob/0f453c3f375c1ae928b83a4c7909c82c013a5bff/onnxmltools/proto/onnx-ml.proto#L176) オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="e71bd-128">The `model_onnx` is an ONNX [ModelProto](https://github.com/onnx/onnxmltools/blob/0f453c3f375c1ae928b83a4c7909c82c013a5bff/onnxmltools/proto/onnx-ml.proto#L176) object.</span></span> <span data-ttu-id="e71bd-129">これは 2 つの異なる形式で保存できます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-129">We can save it in two different formats.</span></span>

~~~python
from winmltools.utils import save_model
# Save the produced ONNX model in binary format
save_model(model_onnx, 'example.onnx')
# Save the produced ONNX model in text format
from winmltools.utils import save_text
save_text(model_onnx, 'example.txt')
~~~

<span data-ttu-id="e71bd-130">**注**: CoreMLTools は Apple から提供される Python パッケージですが、Windows 向けには用意されていません。</span><span class="sxs-lookup"><span data-stu-id="e71bd-130">**Note**: CoreMLTools is a Python package provided by Apple, but is not available on Windows.</span></span> <span data-ttu-id="e71bd-131">このパッケージを Windows にインストールする必要がある場合は、リポジトリからパッケージを直接インストールしてください。</span><span class="sxs-lookup"><span data-stu-id="e71bd-131">If you need to install the package on Windows, install the package directly from the repo:</span></span>

```
pip install git+https://github.com/apple/coremltools
```

## <a name="core-ml-models-with-image-inputs-or-outputs"></a><span data-ttu-id="e71bd-132">画像を入力または出力する Core ML モデル</span><span class="sxs-lookup"><span data-stu-id="e71bd-132">Core ML models with image inputs or outputs</span></span>

<span data-ttu-id="e71bd-133">ONNX には画像を表す型がないため、Core ML の画像モデル (画像を入力または出力として使うモデル) を変換するには、前処理と後処理の手順が必要になります。</span><span class="sxs-lookup"><span data-stu-id="e71bd-133">Because of the lack of image types in ONNX, converting Core ML image models (i.e., models using images as inputs or outputs) requires some pre-processing and post-processing steps.</span></span>

<span data-ttu-id="e71bd-134">前処理の目的は、入力画像を ONNX のテンソルとして適切な形式にすることです。</span><span class="sxs-lookup"><span data-stu-id="e71bd-134">The objective of pre-processing is to make sure the input image is properly formatted as an ONNX tensor.</span></span> <span data-ttu-id="e71bd-135">たとえば、*X* が [C, H, W] という形状の Core ML の画像入力であるとします。</span><span class="sxs-lookup"><span data-stu-id="e71bd-135">Assume *X* is an image input with shape [C, H, W] in Core ML.</span></span> <span data-ttu-id="e71bd-136">ONNX では、変数 *X* は同じ形状の浮動小数点テンソルとなり、*X*[0, :, :]/*X*[1, :, :]/*X*[2, :, :] に画像の赤/緑/青チャネルが格納されます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-136">In ONNX, the variable *X* would be a floating-point tensor with the same shape and *X*[0, :, :]/*X*[1, :, :]/*X*[2, :, :] stores the image's red/green/blue channel.</span></span> <span data-ttu-id="e71bd-137">Core ML のグレー スケール画像については、ONNX での形式は [1, H, W] テンソルになります。これはチャネルが 1 つしかないためです。</span><span class="sxs-lookup"><span data-stu-id="e71bd-137">For gray scale images in Core ML, their format are [1, H, W]-tensors in ONNX because we only have one channel.</span></span>

<span data-ttu-id="e71bd-138">元の Core ML モデルの出力が画像の場合は、ONNX の出力の浮動小数点テンソルを手動で画像に変換します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-138">If the original Core ML model outputs an image, manually convert ONNX's floating-point output tensors back into images.</span></span> <span data-ttu-id="e71bd-139">基本的な手順は 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="e71bd-139">There are two basic steps.</span></span> <span data-ttu-id="e71bd-140">最初の手順として、255 より大きい値を 255 に切り詰め、すべての負の値を 0 に変更します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-140">The first step is to truncate values greater than 255 to 255 and change all negative values to 0.</span></span> <span data-ttu-id="e71bd-141">2 番目の手順として、すべてのピクセル値を整数に丸めます (0.5 を加えてから小数点以下を切り捨てます)。</span><span class="sxs-lookup"><span data-stu-id="e71bd-141">The second step is to round all pixel values to integers (by adding 0.5 and then truncating the decimals).</span></span> <span data-ttu-id="e71bd-142">出力のチャネルの順序 (RGB、BGR など) は Core ML モデルに示されています。</span><span class="sxs-lookup"><span data-stu-id="e71bd-142">The output channel order (e.g., RGB or BGR) is indicated in the Core ML model.</span></span> <span data-ttu-id="e71bd-143">適切な画像出力を生成するには、転置やシャッフルによって目的の形式を回復する必要がある場合があります。</span><span class="sxs-lookup"><span data-stu-id="e71bd-143">To generate proper image output, we may need to transpose or shuffle to recover the desired format.</span></span>

<span data-ttu-id="e71bd-144">ここで、ONNX と Core ML の形式の違いを示す実際の変換の例として、[GitHub](https://github.com/likedan/Awesome-CoreML-Models) からダウンロードできる FNS-Candy という Core ML モデルを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="e71bd-144">Here we consider a Core ML model, FNS-Candy, downloaded from [GitHub](https://github.com/likedan/Awesome-CoreML-Models), as a concrete conversion example to demonstrate the difference between ONNX and Core ML formats.</span></span> <span data-ttu-id="e71bd-145">以降のコマンドはすべて python 環境で実行します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-145">Note that all the subsequent commands are executed in a python enviroment.</span></span>

<span data-ttu-id="e71bd-146">まず、Core ML モデルを読み込み、入力形式と出力形式を調べます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-146">First, we load the Core ML model and examine its input and output formats.</span></span>

~~~python
from coremltools.models.utils import load_spec
model_coreml = load_spec('FNS-Candy.mlmodel')
model_coreml.description # Print the content of Core ML model description
~~~

<span data-ttu-id="e71bd-147">画面出力:</span><span class="sxs-lookup"><span data-stu-id="e71bd-147">Screen output:</span></span>

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

<span data-ttu-id="e71bd-148">この場合、入力と出力はどちらも 720x720 の BGR 画像です。</span><span class="sxs-lookup"><span data-stu-id="e71bd-148">In this case, both the input and output are 720x720 BGR-image.</span></span> <span data-ttu-id="e71bd-149">次の手順では、WinMLTools を使って Core ML モデルを変換します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-149">Our next step is to convert the Core ML model with WinMLTools.</span></span>

~~~python
# The automatic code generator (mlgen) uses the name parameter to generate class names.
from onnxmltools import convert_coreml
model_onnx = convert_coreml(model_coreml, name='FNSCandy')    
~~~

<span data-ttu-id="e71bd-150">ONNX でのモデルの入力形式と出力形式を確認する別の方法として、次のコマンドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-150">An alternative method to view the model input and output formats in ONNX, is to use the following command:</span></span>

~~~python
model_onnx.graph.input # Print out the ONNX input tensor's information
~~~

<span data-ttu-id="e71bd-151">画面出力:</span><span class="sxs-lookup"><span data-stu-id="e71bd-151">Screen output:</span></span>

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

<span data-ttu-id="e71bd-152">生成された ONNX の入力 (以下 *X*) は 4-D テンソルです。</span><span class="sxs-lookup"><span data-stu-id="e71bd-152">The produced input (denoted by *X*) in ONNX is a 4-D tensor.</span></span> <span data-ttu-id="e71bd-153">最後の 3 つの軸はそれぞれ C-、H-、W-軸です。</span><span class="sxs-lookup"><span data-stu-id="e71bd-153">The last 3 axes are C-, H-, and W-axes, respectively.</span></span> <span data-ttu-id="e71bd-154">1 次元目は "None" で、この ONNX モデルが任意の数の画像に適用できることを意味します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-154">The first dimension is "None" which means that this ONNX model can be applied to any number of images.</span></span> <span data-ttu-id="e71bd-155">このモデルを適用して 2 つの画像を一括で処理する場合、最初の画像は *X*[0, :, :, :] に対応し、2 番目の画像は *X*[1, :, :, :] に対応します。</span><span class="sxs-lookup"><span data-stu-id="e71bd-155">To apply this model to process a batch of 2 images, the first image corresponds to *X*[0, :, :, :] while *X*[1, :, :, :] corresponds to the second image.</span></span> <span data-ttu-id="e71bd-156">最初の画像の青/緑/赤のチャネルは *X*[0, 0, :, :]/*X*[0, 1, :, :]/*X*[0, 2, :, :] となり、2 番目の画像も同様です。</span><span class="sxs-lookup"><span data-stu-id="e71bd-156">The blue/green/red channels of the first image are *X*[0, 0, :, :]/*X*[0, 1, :, :]/*X*[0, 2, :, :], and similar for the second image.</span></span>

~~~python
model_onnx.graph.output # Print out the ONNX output tensor's information
~~~

<span data-ttu-id="e71bd-157">画面出力:</span><span class="sxs-lookup"><span data-stu-id="e71bd-157">Screen output:</span></span>

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

<span data-ttu-id="e71bd-158">ご覧のように、生成される形式は元のモデルの入力形式と同じです。</span><span class="sxs-lookup"><span data-stu-id="e71bd-158">As you can see, the produced format is identical to the original model input format.</span></span> <span data-ttu-id="e71bd-159">ただし、これは画像ではありません。画像では、ピクセル値が不動小数点数ではなく整数になります。</span><span class="sxs-lookup"><span data-stu-id="e71bd-159">However, in this case, it's not an image because the pixel values are integers, not floating-point numbers.</span></span> <span data-ttu-id="e71bd-160">再び画像に変換するには、255 より大きい値を 255 に切り詰め、負の値を 0 に変更し、すべての少数を整数に丸めます。</span><span class="sxs-lookup"><span data-stu-id="e71bd-160">To convert back to an image, truncate values greater than 255 to 255, change negative values to 0, and round all decimals to integers.</span></span>