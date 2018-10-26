---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージを使って、.NET デスクトップ アプリを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
keywords: windows 10, ネイティブ コンパイラを画像します。
ms.localizationpriority: medium
ms.openlocfilehash: 231d5aa895cb4cf63ade01660df61e32424e67c7
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5549116"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a>ネイティブ イメージを使って、.NET デスクトップ アプリを最適化します。

> [!NOTE]
> 一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

事前、バイナリをコンパイルすることによって、.NET Framework アプリケーションの起動時間を向上できます。 パッケージ化して、Windows ストアを通じて配布大規模なアプリケーションでは、このテクノロジを使用できます。 場合によっては、お客様には、20% のパフォーマンスが向上を確認しました。 [技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)では、このテクノロジについて詳しくを知ることができます。

ネイティブ イメージ コンパイラのプレビュー版の[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)としてリリースされてきましたしました。 このパッケージを適用するには、.NET Framework バージョン 4.6.2 をターゲットとする .NET Framework アプリケーションにまたはそれ以降。 このパッケージは、アプリケーションで使用されるすべてのバイナリにネイティブのペイロードが含まれている post ビルド ステップを追加します。 この最適化されたペイロードは、アプリケーションが実行される .NET 4.7.2 で以降の以前のバージョンの MSIL コードがまだ読み込み中に読み込まれます。

[Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/) [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)が含まれます。 このバージョンの .NET Framework は、Windows 7 + および Windows Server 2008 R2 + を実行している PC でインストールすることもできます。

> [!IMPORTANT]
> Windows アプリケーション パッケージ プロジェクトをパッケージ化アプリケーションのネイティブ イメージを作成する場合は、プロジェクトのターゲット プラットフォームの最小バージョンを Windows Anniversary Update に設定することを確認してください。

## <a name="how-to-produce-native-images"></a>ネイティブ イメージを作成する方法

次の手順をプロジェクトを構成します。

1. 4.6.2 として以上ターゲット フレームワークを構成します。

2. ターゲット プラットフォームを x86 または x64 として構成します。 

3. NuGet パッケージを追加します。

4. リリース ビルドを作成します。

## <a name="configure-the-target-framework-as-462-or-above"></a>4.6.2 として以上ターゲット フレームワークを構成します。

.NET Framework 4.6.2 をターゲットにプロジェクトを構成する必要があります、.NET Framework 4.6.2 開発ツールまたはそれ以降。 これらのツールは、.NET デスクトップ開発のワークロードでオプション コンポーネントとして Visual Studio インストーラーを利用します。

![.NET 4.6.2 インストール開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

またはから .NET 開発者パックを取得できます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)

## <a name="configure-the-target-platform-as-x86-or-x64"></a>ターゲット プラットフォームを x86 または x64 として構成します。

ネイティブ イメージ コンパイラは、特定のプラットフォーム用のコードを最適化します。 これを使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象としたアプリケーションを構成する必要があります。

ソリューションに複数のプロジェクトがあれば、のみ、エントリ ポイント プロジェクト (ほとんどの場合は、実行可能ファイルを生成するプロジェクト) には x86 または x64 としてコンパイルします。 メイン プロジェクトから参照されるその他のバイナリが AnyCPU としてコンパイルされている場合でも、メイン プロジェクトで指定されたアーキテクチャで処理されます。

プロジェクトを構成します。

1. ソリューションを右クリックして、 **Configuration Manager**を選択してください。

2. 選択 **< 新規.>** **プラットフォーム**ドロップダウン メニューで、実行可能ファイルを生成するプロジェクトの名前の横にあります。

3. **新しいプロジェクトのプラットフォーム**] ダイアログ ボックスで、**設定のコピー元**のドロップダウン リストを**任意の CPU**に設定されているになっていることを確認します。

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

この手順を繰り返します`Release/x64`x64 を生成する場合のバイナリします。

>[!IMPORTANT]
> AnyCPU 構成は、ネイティブ イメージ コンパイラによってサポートされていません。

## <a name="add-the-nuget-packages"></a>NuGet パッケージを追加します。

ネイティブ イメージ コンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージとして提供されます。 これは、通常、Windows フォームや WPF プロジェクトです。 そのためには、次の PowerShell コマンドを使用します。

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> プレビュー パッケージは、一覧にないとして NuGet.org で公開されます。 閲覧 NuGet.org によってまたはパッケージ マネージャーの UI を使用して、Visual Studio では検出されません。 パッケージ マネージャー コンソールから、インストールするただしとタイミングを別のコンピューターから復元されます。 加えますパッケージ完全にアクセスするとき、最初のプレビューでないバージョンを公開しています。

## <a name="create-a-release-build"></a>リリース ビルドを作成します。

NuGet パッケージは、リリース ビルドするための追加のツールを実行するプロジェクトを構成します。 このツールは、同じバイナリをネイティブ コードを追加します。
ツールのバイナリが処理されることを確認するには、ビルドなど、このいずれかのメッセージが含まれているかどうかを確認する出力を確認できます。

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a>FAQ

**Q します。 .NET Framework 4.7.2 なしのマシンでは、新しいバイナリが使用かどうか。**

A. 最適化されたバイナリのメリットは、機能強化 .NET Framework 4.7.2 で実行されている場合。 .NET framework の以前のバージョンを実行しているクライアントは、MSIL の最適化されていないコードをバイナリから読み込まれます。

**Q します。 フィードバックを提供または問題の報告する方法は?**

A. Visual Studio 2017 でフィードバック ツールを使用して問題を報告します。 [詳細について](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)はです。

**Q します。 ネイティブ イメージに追加する既存のバイナリへの影響は何ですか。**

A. 最適化されたバイナリには、最終的なファイルを大きくするマネージとネイティブ コードが含まれています。

**Q します。 このテクノロジを使用してバイナリをリリースすることができますか。**

A. このバージョンには、現在使用できる Live 移動のライセンスが含まれています。
