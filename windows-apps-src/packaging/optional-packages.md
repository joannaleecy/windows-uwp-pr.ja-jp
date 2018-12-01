---
ms.assetid: 3a59ff5e-f491-491c-81b1-6aff15886aad
title: オプション パッケージと関連セットの作成
description: オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。
ms.date: 09/30/2018
ms.topic: article
keywords: windows 10、uwp、オプション パッケージ、関連セット, パッケージの拡張機能、visual studio
ms.localizationpriority: medium
ms.openlocfilehash: e19f9673090501d59e260a698f9968a8f98f1cd5
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8348913"
---
# <a name="optional-packages-and-related-set-authoring"></a>オプション パッケージと関連セットの作成
オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 これらは、ダウンロード可能なコンテンツ (DLC) のサイズ制限、大規模なアプリを分割するのに便利ですか、元のアプリから分離して追加コンテンツを出荷します。

関連セットは省略可能なパッケージの拡張機能--メインおよびオプションのパッケージ間でのバージョンの厳密なセットを適用することができます。 オプション パッケージからネイティブ コード (C++) をロードすることもできます。 

## <a name="prerequisites"></a>前提条件

- Visual Studio 2017 version 15.1
- Windows 10 バージョン 1703
- Windows 10 バージョン 1703 SDK

すべての最新の開発ツールを取得するのには、[ダウンロードと Windows 10 向けのツール](https://developer.microsoft.com/windows/downloads)を参照してください。

> [!NOTE]
> オプション パッケージや関連セットを使用して、Microsoft Store アプリを送信するには、アクセス許可する必要があります。 オプション パッケージや関連セットは、ストアに提出しない場合に、パートナー センターのアクセス許可のない基幹業務 (LOB) や企業のアプリ使用できます。 オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」を参照してください。

### <a name="code-sample"></a>コード サンプル
この記事を表示しているときに、実践的な理解するにはどのオプション パッケージの GitHub で次の[オプション パッケージのコード サンプル](https://github.com/AppInstaller/OptionalPackageSample)と共にして関連の Visual Studio 内で作業を設定することをお勧めします。

## <a name="optional-packages"></a>オプション パッケージ
Visual Studio でオプション パッケージを作成するには、する必要があります。
1. 確認にアプリの**ターゲット プラットフォームの最小バージョン**が設定されます: 10.0.15063.0 します。
2. **メイン パッケージ**プロジェクトを開き、`Package.appxmanifest`ファイル。 "Packaging"タブに移動し、「_」文字の前にすべてのものであることを**パッケージ ファミリ名**をメモします。
3. **オプション パッケージ**プロジェクトを右クリックして、`Package.appxmanifest`選択**で開く > XML (テキスト) エディター**します。
4. 検索、`<Dependencies>`ファイル内の要素です。 次に追加します。

```XML
<uap3:MainPackageDependency Name="[MainPackageDependency]"/>
```

置換`[MainPackageDependency]`手順 2 から**パッケージ ファミリ名**。 **オプション パッケージ**は、**メイン パッケージ**に依存するこれを指定します。

4 を通じて手順 1 からセットアップ、パッケージの依存関係を作成したらは、通常どおりに開発を続行することができます。 オプション パッケージからメイン パッケージにコードを読み込む場合は、関連セットをビルドする必要があります。 詳細については、[関連の設定](#related_sets)のセクションを参照してください。

Visual Studio は、オプション パッケージを展開するたびに、メイン パッケージを再展開するように構成できます。 Visual Studio でビルド依存関係を設定するには、次の必要があります。

- オプション パッケージ プロジェクトを右クリックし、選択**依存関係の構築 > プロジェクトの依存関係.**
- メイン パッケージ プロジェクトを確認し、[OK] を選択します。 

これで、f5 キーを入力またはオプション パッケージ プロジェクトをビルドするたびに Visual Studio プロジェクトをビルドしますメイン パッケージ最初にします。 これにより、メイン プロジェクトとオプションのプロジェクトが同期されます。

## 関連セット<a name="related_sets"></a>

オプション パッケージからメイン パッケージにコードを読み込む場合は、関連セットをビルドする必要があります。 関連セットをビルドするには、メイン パッケージとオプション パッケージする必要があります密接な連携します。 関連セットのメタデータは、メイン パッケージの .appxbundle または .msixbundle ファイルで指定されます。 Visual Studio では、ファイル内で適切なメタデータを取得できます。 関連セットのアプリのソリューションを構成するには、次の手順を使用します。

1. メイン パッケージ プロジェクトを右クリックしてで、選択**追加 > 新しい項目]**
2. ウィンドウで、".txt"のインストールされたテンプレートを検索し、新しいテキスト ファイルを追加します。
> [!IMPORTANT]
> 新しいテキスト ファイルの名前にする必要があります:`Bundle.Mapping.txt`します。
3. `Bundle.Mapping.txt`ファイル、オプション パッケージ プロジェクトや外部パッケージへの相対パスを指定します。 サンプル`Bundle.Mapping.txt`ファイルは次のようになります。

```syntax
[OptionalProjects]
"..\ActivatableOptionalPackage1\ActivatableOptionalPackage1.vcxproj"
"..\ActivatableOptionalPackage2\ActivatableOptionalPackage2.vcxproj"

[ExternalPackages]
"..\ActivatableOptionalPackage1\x86\Release\ActivatableOptionalPackage3_1.1.1.0\ ActivatableOptionalPackage3_1.1.1.0.appx"
```

ソリューションにこのように構成されると、Visual Studio はすべての関連セットに必要なメタデータをメイン パッケージのバンドル マニフェストを作成します。 

などのオプション パッケージ、注意、`Bundle.Mapping.txt`関連セットのファイルは Windows 10 バージョン 1703 でのみ動作します。 さらに、アプリのターゲット プラットフォームの最小バージョンは、10.0.15063.0 に設定する必要があります。

## 既知の問題<a name="known_issues"></a>

関連セットの省略可能なプロジェクトのデバッグは現在サポートされていません Visual Studio でします。 この問題を回避するには、展開し起動アクティブ化 (Ctrl + f5 キーを押します) して手動でのプロセスにデバッガーをアタッチできます。 デバッガーをアタッチするには、Visual Studio で"Debug"メニューに移動します] をクリックします"をアタッチするプロセスを**メイン アプリのプロセス**にデバッガーをアタッチします。