---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージを使って、.NET デスクトップ アプリを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, ネイティブ コンパイラを画像します。
ms.localizationpriority: medium
ms.openlocfilehash: d98b576fb51a8f9507802796ab359d0d00d21998
ms.sourcegitcommit: 53ba430930ecec8ea10c95b390fe6e654fe363e1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/06/2018
ms.locfileid: "3413287"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a>ネイティブ イメージを使って、.NET デスクトップ アプリを最適化します。

> [!NOTE]
> 一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

事前、バイナリをコンパイルすることによって、.NET Framework アプリケーションの起動時間を向上できます。 パッケージ化して、Windows ストアを通じて配布大規模なアプリケーションでは、このテクノロジを使用できます。 場合によっては、お客様には、20% のパフォーマンスが向上を確認しました。 [技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)では、このテクノロジについて詳しくを知ることができます。

ネイティブ イメージ コンパイラのプレビュー版の[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)としてリリースされてきましたしました。 このパッケージを適用するには、.NET Framework バージョン 4.6.2 をターゲットとする .NET Framework アプリケーションにまたはそれ以降。 このパッケージは、アプリケーションで使用されるすべてのバイナリへのネイティブのペイロードを含む post ビルド ステップを追加します。 この最適化されたペイロードは、アプリケーションが実行される .NET 4.7.2 で以降の以前のバージョンは、MSIL コードを読み込むときに読み込まれます。

[Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/) [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)が含まれます。 Windows 7、および Windows Server 2008 R2 + を実行している PC で、このバージョンの .NET Framework をインストールすることもできます。

> [!IMPORTANT]
> Windows アプリケーション パッケージ プロジェクトをパッケージ化アプリケーションのネイティブ イメージを生成する場合は、Windows Anniversary Update に、プロジェクトのターゲット プラットフォームの最小バージョンを設定することを確認してください。

## <a name="how-to-produce-native-images"></a>ネイティブ イメージを作成する方法

プロジェクトを構成する次の手順に従います。

1. 4.6.2 として以上ターゲット フレームワークを構成します。

2. ターゲット プラットフォームを x86 または x64 として構成します。 

3. NuGet パッケージを追加します。

4. リリース ビルドを作成します。

## <a name="configure-the-target-framework-as-462-or-above"></a>4.6.2 として以上ターゲット フレームワークを構成します。

.NET Framework 4.6.2 をターゲットにプロジェクトを構成する必要があります、.NET Framework 4.6.2 開発ツールまたはそれ以降。 これらのツールは、.NET デスクトップ開発のワークロードでオプション コンポーネントとして Visual Studio インストーラーを利用します。

![.NET 4.6.2 インストール開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

またはから .NET 開発者パックを取得できます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)

## <a name="configure-the-target-platform-as-x86-or-x64"></a>ターゲット プラットフォームを x86 または x64 として構成します。

ネイティブ イメージ コンパイラは、特定のプラットフォーム用のコードを最適化します。 これを使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象とするアプリケーションを構成する必要があります。

をソリューションに複数のプロジェクトがある場合のみ、エントリ ポイント プロジェクト (ほとんどの場合は、実行可能ファイルを生成するプロジェクト) には x86 または x64 としてコンパイルします。 メイン プロジェクトから参照されるその他のバイナリが AnyCPU としてコンパイルされる場合でも、メイン プロジェクトで指定されたアーキテクチャで処理されます。

プロジェクトを構成するには。

1. ソリューションを右クリックし、し、 **Configuration Manager**を選択します。

2. 選択 **< 新規.>** では、実行可能ファイルを生成するプロジェクトの名前の横にある、**プラットフォーム**のドロップダウン メニュー。

3. **新しいプロジェクトのプラットフォーム**] ダイアログ ボックスで、**設定のコピー** ] ドロップダウン リストを**任意の CPU**に設定されているになっていることを確認します。

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

この手順を繰り返します`Release/x64`x64 を生成する場合のバイナリ。

>[!IMPORTANT]
> AnyCPU 構成は、ネイティブ イメージ コンパイラによってサポートされていません。

## <a name="add-the-nuget-packages"></a>NuGet パッケージを追加します。

ネイティブ イメージ コンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトを追加する必要がある NuGet パッケージとして提供されます。 これは、通常、Windows フォームや WPF プロジェクトです。 そのためには、次の PowerShell コマンドを使用します。

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> プレビュー パッケージは、一覧にないとして NuGet.org で公開されます。 閲覧 NuGet.org かを Visual Studio でのパッケージ マネージャーの UI を使ってそれらを検索しません。 パッケージ マネージャー コンソールから、インストールするただしとタイミングを別のコンピューターから復元されます。 加えますパッケージ完全にアクセスするとき、最初のプレビュー以外のバージョンを公開しています。

## <a name="create-a-release-build"></a>リリース ビルドを作成します。

NuGet パッケージは、リリース ビルドの追加のツールを実行するのには、プロジェクトを構成します。 このツールは、同じバイナリをネイティブ コードを追加します。
ツールのバイナリが処理されることを確認するには、ビルドなど、このいずれかのメッセージが含まれているかどうかを確認する出力を確認できます。

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a>FAQ

**Q します。 .NET Framework 4.7.2 なしのコンピューターでは、新しいバイナリが使用かどうか。**

A. 最適化されたバイナリのメリットは、機能強化 .NET Framework 4.7.2 を実行している場合。 .NET framework の以前のバージョンを実行しているクライアントは、MSIL の最適化されていないコードをバイナリから読み込まれます。

**Q します。 フィードバックや問題を報告する方法はかどうか。**

A. Visual Studio 2017 でフィードバック ツールを使用して、問題を報告します。 [詳細について](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)はです。

**Q します。 既存のバイナリをネイティブ イメージの追加の影響は何ですか。**

A. 最適化されたバイナリには、最終的なファイルが大きいため、マネージ コードとネイティブ コードが含まれています。

**Q します。 このテクノロジを使用してバイナリを解放することができますか。**

A. このバージョンには、現在使用できる Live 移動のライセンスが含まれています。
