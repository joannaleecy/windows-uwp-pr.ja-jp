---
author: laurenhughes
ms.assetid: 3a59ff5e-f491-491c-81b1-6aff15886aad
title: オプション パッケージと関連セットの作成
description: オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。
ms.author: lahugh
ms.date: 04/05/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、オプションのパッケージ、関連するセット、パッケージの拡張機能、visual studio
ms.localizationpriority: medium
ms.openlocfilehash: d66a511211396190393e31bfd553149a1e89fad0
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "608857"
---
# <a name="optional-packages-and-related-set-authoring"></a>オプション パッケージと関連セットの作成
オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 これらは、ダウンロード可能なコンテンツ (DLC)] を大きなサイズの制限] アプリを除算するのに便利ですか、送付追加コンテンツの元のアプリから分離します。

関連のセットがオプションのパッケージの拡張--メインと省略可能なパッケージ全体のバージョンの厳格なセットを適用することができます。 また、オプションのパッケージからネイティブ コード (C++) をロードすることもできます。 

## <a name="prerequisites"></a>前提条件

- Visual Studio 2017、バージョン 15.1
- Windows 10 バージョン 1703
- Windows 10、バージョン 1703 SDK

最新の開発ツールのすべてを移動するには、[ダウンロードと Windows 10 用のツール](https://developer.microsoft.com/windows/downloads)を参照してください。

> [!NOTE]
> Microsoft ストアにオプションのパッケージや関連のセットを使用しているアプリを送信するには、アクセス許可する必要があります。 Microsoft Store に提出しない場合は、デベロッパー センターから許可を受けずにオプション パッケージや関連セットを基幹業務 (LOB) アプリやエンタープライズ アプリに使用できます。 オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」を参照してください。

### <a name="code-sample"></a>コード サンプル
この記事をご覧になっているときに、実践的な理解するにはどのようにオプションのパッケージの GitHub で次の[オプションのパッケージ コード サンプル](https://github.com/AppInstaller/OptionalPackageSample)と共にして Visual Studio 内の作業のセットに関連することをお勧めします。

## <a name="optional-packages"></a>オプションのパッケージ
Visual Studio で (オプション) を作成するには、する必要があります。
1. 確認にアプリの**ターゲット プラットフォームの最小バージョン**が設定されて: 10.0.15063.0 します。
2. **パッケージのメイン**プロジェクトから開く、`Package.appxmanifest`ファイル。 「パッケージ」] タブに移動して、「_」の文字の前にすべてのアイテムであることを**パッケージ ファミリ名**をメモします。
3. **省略可能なパッケージ**プロジェクトを右クリックします。、`Package.appxmanifest`を選択して**ファイルを開く > (テキスト) の XML エディター**します。
4. 検索、`<Dependencies>`ファイル内の要素。 次に追加します。

```XML
<uap3:MainPackageDependency Name="[MainPackageDependency]"/>
```

置き換える`[MainPackageDependency]`ステップ 2 から**パッケージ家族の名前**をします。 これは、**省略可能なパッケージ**が、**メインのパッケージ**に依存していることを指定します。

手順 1 から 4 までを設定するパッケージの依存関係を作成したらは、通常どおりに開発を続行することができます。 オプションのパッケージのメインのパッケージにコードを読み込む場合は、関連するセットを作成する必要があります。 詳細については、[関連の設定](#related_sets)] セクションを参照してください。

(オプション) を展開するたびに、メインのパッケージを再配置するのには、visual Studio を構成できます。 Visual studio ビルド依存関係を設定するには、次の必要があります。

- 省略可能なパッケージ プロジェクトを右クリックし、選択**依存関係を構築 > プロジェクトの依存関係]**
- パッケージのメインのプロジェクトをチェックし、"OK"を選択します。 

これで、たびに、f5 キーを入力するか、省略可能なパッケージのプロジェクトを作成すると、Visual Studio プロジェクトをビルド パッケージのメイン最初します。 これにより、メインのプロジェクトと省略可能なプロジェクトとの同期があります。

## 関連する設定<a name="related_sets"></a>

オプションのパッケージのメインのパッケージにコードを読み込む場合は、関連するセットを作成する必要があります。 関連するセットを作成するには、省略可能なパッケージ、パッケージのメインする必要があります密に結合します。 関連するセットのメタデータがで指定された、`.appxbundle`パッケージのメインのファイル。 Visual Studio では、ファイル内で正しいメタデータを取得できます。 関連したアプリのソリューションを構成するには、次の手順に従います。

1. パッケージのメイン プロジェクトを右クリックしてで、選択**追加 > [新しいアイテム]**
2. ウィンドウでは、".txt"インストールされているテンプレートを検索し、新しいテキスト ファイルを追加します。
> [!IMPORTANT]
> 新しいテキスト ファイルを付ける必要があります:`Bundle.Mapping.txt`します。
3. `Bundle.Mapping.txt`ファイルの任意のオプションのパッケージのプロジェクトまたは外部パッケージへの相対パスを指定します。 サンプル`Bundle.Mapping.txt`ファイルは次のように表示する必要があります。

```syntax
[OptionalProjects]
"..\ActivatableOptionalPackage1\ActivatableOptionalPackage1.vcxproj"
"..\ActivatableOptionalPackage2\ActivatableOptionalPackage2.vcxproj"

[ExternalPackages]
"..\ActivatableOptionalPackage1\x86\Release\ActivatableOptionalPackage3_1.1.1.0\ ActivatableOptionalPackage3_1.1.1.0.appx"
```

ソリューションが、このように構成されている、Visual Studio はすべての関連する設定に必要なメタデータ パッケージのメインのバンドル マニフェストに作成されます。 

オプションのパッケージのようなことに注意を`Bundle.Mapping.txt`関連したファイルは、Windows 10、1703 のバージョンでのみ機能します。 さらに、10.0.15063.0 するように、アプリのターゲット プラットフォームの最小バージョンを設定する必要があります。

## 既知の問題<a name="known_issues"></a>

関連する設定オプションのプロジェクトをデバッグは現在サポートされていません Visual Studio でします。 この問題を回避するには、展開し、(ctrl キーを押しながら f5 キーを押して) のライセンス認証を起動してプロセスにデバッガーを手動で追加できます。 デバッガーを添付するには、Visual Studio で"デバッグ] メニューを移動、「を添付するプロセス...」を選択し、**メインのアプリのプロセス**にデバッガーを追加します。