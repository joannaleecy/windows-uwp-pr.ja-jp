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
# <a name="windows-ml-overview"></a>Windows ML の概要

![Windows Machine Learning のグラフィック](images/brain.png)

## <a name="what-is-machine-learning"></a>機械学習とは

機械学習 (ML) は、コンピューターで既存のデータを使って、予期される結果や動作を予測できるようにするものです。 ML のアルゴリズムは、事前に収集されたデータを処理することで、新しい入力が提示されたときに適切な出力を予測できるモデルを構築します。 たとえば、メール メッセージ (入力) が迷惑メールかそうでないか (出力) を評価するようにモデルをトレーニングできます。

モデルを構築するフェーズは "トレーニング" と呼ばれます。 既存のデータでトレーニングされたモデルは、それまでに出現したことのない新しいデータを使って予測を実行できます。これは "推測"、"評価"、または "スコアリング" と呼ばれます。

トレーニング済みのモデルでは、多くの場合、厳密な命令セットに従うように記述されたプログラムよりも適切な結果が生成されます。これは特に、入力と出力の組み合わせが多数考えられる複雑なタスクの場合に当てはまります。 たとえば、電子商取引サイトやメディア ストリーミング サイトでは、おすすめアルゴリズムによって何百万人ものユーザーにカスタマイズされたおすすめを提供しますが、これは機械学習なくしてはほとんど不可能です。 他に機械学習が活用されている分野として、コンピューター ビジョンがあります。事前にラベル付けされた画像でトレーニングすることで、コンピューターによる画像の分類と識別が可能になります。

機械学習の可能性と適用性は無限に広がります。リサーチとソリューションについては、[Microsoft の人工知能](https://www.microsoft.com/ai)と [Microsoft AI プラットフォーム](https://azure.microsoft.com/en-us/overview/ai-platform/)に関するページをご覧ください。 機械学習モデルや AI モデルの構築を検討している場合は、[Azure Machine Learning Services](https://docs.microsoft.com/azure/machine-learning/preview/overview-what-is-azure-ml) もチェックしてください。

## <a name="what-is-windows-ml"></a>Windows ML とは

Windows ML は、Windows 10 デバイスでトレーニング済みの機械学習モデルを評価するプラットフォームです。これにより開発者は、Windows アプリケーション内で機械学習を利用できるようになります。

Windows ML の特色のいくつかを次に示します。

- **ハードウェア アクセラレータ**
    
    DirectX12 対応デバイスでは、Windows ML は GPU を使ってディープ ラーニング モデルの評価を高速化します。 さらに、CPU の最適化により、従来の ML アルゴリズムとディープ ラーニング アルゴリズムの両方で評価のパフォーマンスが向上します。

- **ローカルの評価**

    Windows ML はローカル ハードウェアで評価を実行するため、接続性、帯域幅、データのプライバシーを心配する必要がありません。 さらに、ローカルの評価は待ち時間が短く、高いパフォーマンスが実現されるため、評価結果をすばやく得ることができます。

- **画像処理**

    コンピューター ビジョンのシナリオでは、Windows ML がフレームの前処理を実行し、モデル入力用のカメラ パイプラインのセットアップを提供するため、画像、ビデオ、カメラ データの使用が簡素化され、最適化されます。

## <a name="how-to-develop-with-windows-ml"></a>Windows ML を使って開発する方法

> [!VIDEO https://www.youtube.com/embed/8MCDSlm326U]

### <a name="system-requirements"></a>システム要件

Windows ML を使うアプリケーションをビルドするには、[Windows SDK ビルド 17110 以降](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK)が必要です。

### <a name="onnx-models"></a>ONNX モデル

Windows ML を使用するには、事前トレーニング済みの [Open Neural Network Exchange (ONNX)](https://onnx.ai) 形式の機械学習モデルが必要です。 Windows ML は v1.0 リリースの ONNX 形式をサポートしているため、開発者は、異なるトレーニング フレームワークで生成されたモデルを使うことができます。

一般公開されている ONNX モデルの一覧については、GitHub の [ONNX モデルのページ](https://github.com/onnx/models)をご覧ください。

Visual Studio Tools for AI で ONNX モデルをトレーニングする方法については、「[モデルのトレーニング](train-ai-model.md)」をご覧ください。

### <a name="convert-existing-models-to-onnx"></a>既存のモデルの ONNX への変換

既に多くのトレーニング フレームワークが ONNX モデルをネイティブにサポートしており、さまざまなフレームワークとライブラリ用のコンバーター ツールが存在します。 Caffe 2、PyTorch、CNTK、Chainer などのフレームワークからエクスポートする方法については、GitHub の [ONNX チュートリアル](https://github.com/onnx/tutorials)をご覧ください。

[WinMLTools](https://pypi.org/project/winmltools/) を使って、トレーニング済みの機械学習モデルを Windows ML で受け入れられる ONNX 形式に変換することもできます。 WinMLTools では、次の形式からの変換がサポートされています。

- Core ML
- Scikit-Learn
- XGBoost
- LibSVM

WinMLTools のインストール方法と使用方法については、「[モデルの変換](conversion-samples.md)」をご覧ください。

### <a name="onnx-operators"></a>ONNX 演算子

Windows ML では、100 以上の ONNX 演算子が CPU 上でサポートされると共に、DirectX12 互換の GPU では計算が高速化されます。 すべての演算子のシグネチャの一覧については、[ai.onnx](https://github.com/onnx/onnx/blob/rel-1.0/docs/Operators.md) 名前空間 (既定) と [ai.onnx.ml](https://github.com/onnx/onnx/blob/rel-1.0/docs/Operators-ml.md) 名前空間の ONNX 演算子スキーマのドキュメントをご覧ください。

Windows ML は、ONNX v1.0 ドキュメントに定義されているすべての演算子をサポートしますが、次の違いがあります。

- Windows ML でサポートされる "試験的" 演算子:
    - Affine
    - Crop
    - FC
    - Identity
    - ImageScaler
    - MeanVarianceNormalization
    - ParametricSoftplus
    - ScaledTanh
    - ThresholdedRelu
    - Upsample
- MatMul - 2D より大きい行列の乗算は現在未サポート、CPU でのみサポート
- Cast - CPU でのみサポート
- 現時点ではサポートされない演算子:
    - RandomUniform
    - RandomUniformLike
    - RandomNormal
    - RandomNormalLike

### <a name="automatic-interface-code-generation"></a>インターフェイス コードの自動生成

Windows ML のコード ジェネレーターは、ONNX モデル ファイルを使って、アプリ内のモデルを操作するためのインターフェイスを作成します。 生成されたインターフェイスには、モデル、入力、出力を表すラッパー クラスが含まれます。 生成されたコードによって [Windows ML API](/uwp/api/windows.ai.machinelearning.preview) が自動的に呼び出され、プロジェクト内のモデルの読み込み、バインド、評価を簡単に行うことができます。 現在、コード ジェネレーターは C# と C++/CX の両方をサポートしています。

UWP を開発する場合、Windows ML の自動コード ジェネレーターは [Visual Studio (Version 15.7 - Preview 1)](https://www.visualstudio.com/vs/preview/) とネイティブに統合されます  (**注**: Visual Studio インストーラーで、オプションの Windows 10 Insider Preview SDK ビルド 17110 をオンにする必要があります)。Visual Studio プロジェクト内で ONNX ファイルを既存の項目として追加するだけで、VS によって Windows ML ラッパー クラスが新しいインターフェイス ファイルに生成されます。

また、Windows SDK に付属するコマンド ライン ツール `mlgen.exe` を使って Windows ML ラッパー クラスを作成することもできます。 このツールは `(SDK_root)\bin\<version>\x64` または `(SDK_root)\bin\<version>\x86` に格納されています。SDK_root は SDK のインストール ディレクトリです。 ツールを実行するには、次のコマンドを使います。

```
mlgen -i INPUT-FILE -l LANGUAGE -n NAMESPACE [-o OUTPUT-FILE]
```

入力パラメーターの定義:

- `INPUT-FILE`: ONNX モデル ファイル
- `LANGUAGE`: CPPCX または CS
- `NAMESPACE`: 生成されるコードの名前空間
- `OUTPUT-FILE`: 生成されたコードの出力先のファイル パス。 OUTPUT-FILE を指定しない場合、生成されたコードは標準出力に出力されます。

生成されたコードをアプリで使う方法については、「[モデルの統合](integrate-model.md)」をご覧ください。

## <a name="next-steps"></a>次のステップ

「[使ってみる](get-started.md)」のステップ バイ ステップ チュートリアルを使って、初めての Windows ML アプリを作成してみましょう。