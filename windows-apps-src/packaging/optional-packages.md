---
ms.assetid: 3a59ff5e-f491-491c-81b1-6aff15886aad
title: オプション パッケージと関連セットの作成
description: オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。
ms.date: 09/30/2018
ms.topic: article
keywords: Windows 10, UWP, オプション パッケージ, 関連セット, パッケージ拡張機能, Visual Studio
ms.localizationpriority: medium
ms.openlocfilehash: f62d6c99acc75033403fac7a498308cea6f7d3f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594027"
---
# <a name="optional-packages-and-related-set-authoring"></a>オプション パッケージと関連セットの作成
オプション パッケージには、メイン パッケージに統合できるコンテンツが格納されます。 オプション パッケージは、ダウンロード可能なコンテンツ (DLC) 用や、サイズ制約に対応して大規模アプリを分割する場合、元のアプリから分離して追加コンテンツを出荷する場合に便利です。

関連セットとは、オプション パッケージの拡張機能です。これらを使用すると、メイン パッケージとオプション パッケージを通じて、厳密なバージョン セットを適用できます。 また、オプション パッケージからネイティブ コード (C++) を読み込むこともできます。 

## <a name="prerequisites"></a>前提条件

- Visual Studio 2017 Version 15.1
- Windows 10 Version 1703
- Windows 10 Version 1703 SDK

最新の開発ツールをすべて取得する方法については、「[Windows 10 用のダウンロードとツール](https://developer.microsoft.com/windows/downloads)」をご覧ください。

> [!NOTE]
> Microsoft Store に省略可能なパッケージや関連する設定を使用するアプリを送信するには、アクセス許可する必要があります。 オプションのパッケージおよび関連する設定は、いないストアに送信する場合に、パートナー センターの許可なく基幹業務 (LOB) またはエンタープライズのアプリ使用できます。 オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」をご覧ください。

### <a name="code-sample"></a>コード サンプル
この記事を読みながら GitHub で[オプション パッケージのコード サンプル](https://github.com/AppInstaller/OptionalPackageSample)を参照し、Visual Studio でオプション パッケージと関連セットがどのように動作するかを実際に体験して理解することをお勧めします。

## <a name="optional-packages"></a>オプション パッケージ
Visual Studio オプション パッケージを作成するには、以下の手順を実行します。
1. アプリの確認**ターゲット プラットフォームの最小バージョン**に設定されます。10.0.15063.0 またはそれ以降。
2. **メイン パッケージ** プロジェクトから、`Package.appxmanifest` ファイルを開きます。 [パッケージ化] タブに移動し、**[パッケージ ファミリ名]** ("_" 文字の前にある文字列すべて) を書き留めます。
3. **オプション パッケージ** プロジェクトから、`Package.appxmanifest` を右クリックして **[プログラムから開く] > [XML (テキスト) エディター]** を選択します。
4. ファイル内の `<Dependencies>` 要素を見つけます。 以下を追加します。

```XML
<uap3:MainPackageDependency Name="[MainPackageDependency]"/>
```

`[MainPackageDependency]` は、手順 2. の **[パッケージ ファミリ名]** の値に置き換えてください。 これにより、**オプション パッケージ**が**メイン パッケージ**に依存することを指定できます。

手順 1 から 4 を実行してパッケージの依存関係を設定できたら、通常の開発作業に進むことができます。 オプション パッケージからメイン パッケージにコードを読み込むには、関連セットを構築する必要があります。 詳しくは、「[関連セット](#related_sets)」セクションをご覧ください。

Visual Studio は、オプション パッケージを展開するたびにメイン パッケージが再展開されるように構成できます。 Visual Studio でビルド依存関係を設定するには、以下の手順を実行する必要があります。

- オプション パッケージ プロジェクトを右クリックし、**[ビルド依存関係] > [プロジェクト依存関係]** を選択します。
- メイン パッケージ プロジェクトを確認し、[OK] を選択します。 

これで、F5 キーを押すか、オプション パッケージ プロジェクトのビルドを実行するたびに、Visual Studio によってメイン プロジェクトが先にビルドされるようになります。 これにより、メイン プロジェクトとオプション プロジェクトが確実に同期されます。

## 関連セット<a name="related_sets"></a>

オプション パッケージからメイン パッケージにコードを読み込むには、関連セットを構築する必要があります。 関連セットを構築するには、メイン パッケージとオプション パッケージを確実に組み合わせる必要があります。 関連する設定のメタデータは、メイン パッケージの .appxbundle または .msixbundle ファイルで指定されます。 Visual Studio を使用すると、正しいメタデータをファイルに取得できます。 関連セット用にアプリのソリューションを構成するには、次の手順を使用します。

1. メイン パッケージ プロジェクトを右クリックして、**[追加] > [新しいアイテム]** を選択します。
2. そのウィンドウから、[インストールされたテンプレート] で ".txt" を検索し、新しいテキスト ファイルを追加します。
> [!IMPORTANT]
> 新しいテキスト ファイルに `Bundle.Mapping.txt` という名前を付けます。

3. `Bundle.Mapping.txt` ファイル内に、オプション パッケージ プロジェクトや外部パッケージの相対パスをすべて指定します。 `Bundle.Mapping.txt` ファイルのサンプルを次に示します。

```syntax
[OptionalProjects]
"..\ActivatableOptionalPackage1\ActivatableOptionalPackage1.vcxproj"
"..\ActivatableOptionalPackage2\ActivatableOptionalPackage2.vcxproj"

[ExternalPackages]
"..\ActivatableOptionalPackage1\x86\Release\ActivatableOptionalPackage3_1.1.1.0\ ActivatableOptionalPackage3_1.1.1.0.appx"
```

この方法でソリューションが構成されている場合、Visual Studio は関連セットの必要なメタデータをすべて含めて、メイン パッケージのバンドル マニフェストを作成します。 

などのオプションのパッケージに注意してください、`Bundle.Mapping.txt`の関連する設定ファイルは Windows 10 バージョン 1703 以降でのみ動作します。 さらに、アプリの対象プラットフォームの最小バージョンは、10.0.15063.0 以上に設定する必要があります。

## 既知の問題<a name="known_issues"></a>

現在、関連セット オプション プロジェクトのデバッグは Visual Studio でサポートされていません。 この問題を回避するには、アクティブ化を展開および起動 (Ctrl + F5) して、プロセスにデバッガーを手動でアタッチします。 デバッガーをアタッチするには、Visual Studio の [デバッグ] メニューで [プロセスにアタッチ] を選択し、**メイン アプリ プロセス**にデバッガーをアタッチします。