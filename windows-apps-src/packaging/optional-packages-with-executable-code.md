---
author: laurenhughes
title: 実行可能コードを使用したオプション パッケージ
description: Visual Studio を使用して、実行可能コードでオプション パッケージを作成する方法について説明します。
ms.author: lahugh
ms.date: 9/30/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: f5660649b6f82135cdb45a8678a3f871a0f5e61d
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4753836"
---
# <a name="optional-packages-with-executable-code"></a>実行可能コードを使用したオプション パッケージ
 
実行可能コードを使用したオプション パッケージは、大規模または複雑なアプリを分割したり、既に公開されたアプリに追加するために役立ちます。 Visual Studio 2017 Version 15.7 および .NET Native 2.1 では、C++ および C# のオプション パッケージから実行可能コードを読み込むことができます。

## <a name="prerequisites"></a>前提条件
- Visual Studio 2017 Version 15.7
- Windows 10 Version 1709
- Windows 10 Version 1709 SDK

最新の開発ツールを取得する方法については、「[Windows 10 用のダウンロードとツール](https://developer.microsoft.com/windows/downloads)」を参照してください。 

> [!NOTE]
> オプション パッケージや関連セットを使用するアプリを Microsoft Store に提出するには、許可が必要です。 Microsoft Store に提出しない場合は、デベロッパー センターから許可を受けずにオプション パッケージや関連セットを基幹業務 (LOB) アプリやエンタープライズ アプリに使用できます。 オプション パッケージや関連セットを使用するアプリの提出許可を得る方法については、「[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)」を参照してください。

## <a name="c-optional-packages-with-executable-code"></a>実行可能コードを使用した C++ オプション パッケージ

C++オプション パッケージからコードを読み込むには、GitHub で [OptionalPackageSample](https://github.com/AppInstaller/OptionalPackageSample) リポジトリを参照してください。 [OptionalPackageDLL](https://github.com/AppInstaller/OptionalPackageSample/tree/master/OptionalPackageDLL) では、メイン パッケージから実行可能なコードを使用してプロジェクトを作成する方法を示します。 MyMainApp プロジェクトでは、OptionalPackageDLL.dll ファイルから[コードを読み込む](https://github.com/AppInstaller/OptionalPackageSample/blob/bf6b4915ff1f3b8abfdaacb1ad9e77184c49fe18/MyMainApp/MainPage.xaml.cpp#L182)方法を示します。

## <a name="c-optional-packages-with-executable-code"></a>実行可能コードを使用した C# オプション パッケージ

C# でオプションのコード パッケージの作成を開始するには、次の手順に従い、ソリューションを構成してください。

1. 最小バージョンを Windows 10 Fall Creators Update SDK (ビルド 16299) 以上に設定して新しい UWP アプリケーションを作成します。

2. 新しい**オプションのコード パッケージ (ユニバーサル Windows)** プロジェクトをソリューションに追加します。 **[最小バージョン]** と **[ターゲット バージョン]** がメイン アプリのバージョンに一致することを確認します。

3. アプリを Microsoft Store に申請する予定である場合は、両方のプロジェクトを右クリックして、**[Microsoft Store] -> [アプリケーションをストアと関連付ける]** の順に選択します。

4. メイン アプリの `Package.appxmanifest` ファイルを開き、`Identity Name` 値を見つけます。 次の手順のためにこの値を書き留めます。

5. オプションのアプリ パッケージの `Package.appxmanifest` ファイルを開き、`uap3:MainAppPackageDependency Name` 値を見つけます。 `uap3:MainAppPackageDependency Name` 値を更新し、前の手順のメイン アプリ パッケージの `Identity Name` 値と一致するようにします。 

    メイン アプリの `Package.appxmanifest` からの `Identity` の例を次に示します。
    ```XML
    <Identity Name="12345.MainAppProject" Publisher="CN=PublisherName" Version="1.0.0.0" />
    ```

    オプションのアプリ ペッケージの `uap3:MainPackageDependency` は、メイン アプリの `Identity` に一致するように更新される必要があります。
    ```XML
    <uap3:MainPackageDependency Name="12345.MainAppProjectTest" />
    ```

6. `Bundle.mapping.txt` ファイルをメイン アプリに追加します。 「[関連セット](https://docs.microsoft.com/windows/uwp/packaging/optional-packages#related-sets)」セクションの手順に従い、両方のアプリを含む関連セットを作成します。 

7. オプション パッケージ プロジェクトをビルドし、`..\[PathToOptionalPackageProject]\bin\[architecture]\[configuration]\Reference` にあるビルドの出力の Reference パッケージ フォルダーに移動します。 `.winmd` ファイル (手順 8) はアーキテクチャに依存しないため、Reference フォルダーへのパスで任意のアーキテクチャを選択できる点に注意してください。

8. メイン アプリ プロジェクトからの参照を、このフォルダーにある `.winmd` ファイルに追加します。 オプション パッケージ プロジェクトで API サーフェイス領域を変更するたびに、この `.winmd` ファイルを更新する**必要があります**。 このリファレンスでは、コンパイルするために必要な情報を含むメイン アプリ プロジェクトが提供されます。

9. メイン アプリ プロジェクトで、プロジェクト ビルドのプロパティに移動し、**[.NET ネイティブ ツール チェーンでコンパイルする]** を選択します。 現在、C# でのオプションのコード パッケージの作成では .NET Native でのデバッグのみがサポートされています。 プロジェクトのデバッグ プロパティに移動し、**[オプションのパッケージの配置]** を選択します。 これにより、メイン アプリ プロジェクトを配置する場合は、両方のパッケージが同期されるようになります。

これらの手順が完了したら、WinRT コンポーネント マネージ プロジェクトであるかのように、オプション パッケージ プロジェクトにコードを追加できます。 メイン アプリ プロジェクト内のコードにアクセスするには、オプション パッケージ プロジェクトで公開されたパブリック メソッドを呼び出します。