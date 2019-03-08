---
Description: このガイドでは、ネイティブ イメージ アプリケーション バイナリを最適化するために、Visual Studio ソリューションを構成する方法について説明します。
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージで .NET デスクトップ アプリを最適化します。
ms.date: 06/11/2018
ms.topic: article
keywords: windows 10、ネイティブ イメージ コンパイラ
ms.localizationpriority: medium
ms.openlocfilehash: 3071b843a1605d765ab5b087d5e1bfb96a220218
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642877"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a>ネイティブ イメージで .NET デスクトップ アプリを最適化します。

> [!NOTE]
> 一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

バイナリを事前コンパイルすることで、.NET Framework アプリケーションの起動時間を向上できます。 Microsoft Store を介して配布のパッケージ化とする大規模なアプリケーションでは、このテクノロジを使用できます。 場合によっては、20% のパフォーマンスが向上が見しました。 このテクノロジに関する詳細については、[の技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)します。

としてネイティブ イメージのコンパイラのプレビュー バージョンをリリースしました、 [NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)します。 このパッケージを適用するには、.NET Framework バージョン 4.6.2 を対象とする任意の .NET Framework アプリケーションまたはそれ以降。 このパッケージは、アプリケーションで使用されるすべてのバイナリをネイティブ ペイロードを含む投稿ビルド ステップを追加します。 この最適化されたペイロードは、以前のバージョンの MSIL コードはまだ読み込み中に .NET 4.7.2 以降をアプリケーションが実行時に読み込まれます。

[.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)に含まれている、 [Windows 10 April 2018 update](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)します。 Windows 7 以降および Windows Server 2008 R2 以降を実行する PC で、このバージョンの .NET Framework をインストールすることもできます。

> [!IMPORTANT]
> Windows アプリケーション パッケージ プロジェクトでパッケージ化、アプリケーションのネイティブ イメージを生成する場合は、Windows Anniversary Update に、プロジェクトのターゲット プラットフォームの最小バージョンを設定することを確認してください。

## <a name="how-to-produce-native-images"></a>ネイティブ イメージを生成する方法

プロジェクトを構成する次の手順に従います。

1. 4.6.2 またはの上に、ターゲット フレームワークを構成します。

2. ターゲット プラットフォームを x86 または x64 として構成します。 

3. NuGet パッケージを追加します。

4. リリース ビルドを作成します。

## <a name="configure-the-target-framework-as-462-or-above"></a>4.6.2 またはの上に、ターゲット フレームワークを構成します。

ターゲット .NET Framework 4.6.2 にプロジェクトを構成する必要があります、.NET Framework 4.6.2 開発ツールまたはそれ以降。 これらのツールは、.NET デスクトップ開発ワークロードの下のオプション コンポーネントとして、Visual Studio インストーラーで使用できます。

![.NET 4.6.2 をインストールする開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

またはから .NET の開発者パックを取得できます。 [https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)

## <a name="configure-the-target-platform-as-x86-or-x64"></a>ターゲット プラットフォームを x86 または x64 として構成します。

ネイティブ イメージのコンパイラでは、特定のプラットフォーム コードを最適化します。 これを使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象とするアプリケーションを構成する必要があります。

ソリューション内に複数のプロジェクトがある場合のみエントリ ポイント プロジェクトは、(ほとんどの場合、実行可能ファイルを生成するプロジェクト) が x86 または x64 としてコンパイルします。 メイン プロジェクトから参照されているその他のバイナリは、AnyCPU としてコンパイルする場合でも、メインのプロジェクトで指定されたアーキテクチャと処理されます。

プロジェクトを構成するには。

1. ソリューションを右クリックし、 **Configuration Manager**します。

2. 選択 **< 新規作成.>** で、**プラットフォーム**実行可能ファイルを生成するプロジェクトの名前の横にあるドロップダウン メニュー。

3. **新しいプロジェクト プラットフォーム** ダイアログ ボックスに、必ず、**設定のコピー元**にドロップダウン リストが設定されている**Any CPU**。

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

この手順を繰り返します`Release/x64`x64 を生成する場合のバイナリです。

>[!IMPORTANT]
> ネイティブ イメージのコンパイラでは、AnyCPU 構成はサポートされていません。

## <a name="add-the-nuget-packages"></a>NuGet パッケージを追加します。

ネイティブ イメージのコンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージとして提供されます。 これは、通常、Windows フォームまたは WPF プロジェクトです。 そのためには、次の PowerShell コマンドを使用します。

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> プレビュー パッケージは、一覧にないと、NuGet.org に発行されます。 NuGet.org を参照して、または Visual Studio でパッケージ マネージャー UI を使用して、検出されません。 パッケージ マネージャー コンソールからインストールするただし、いつ別のコンピューターから復元します。 しましょうパッケージは、完全にアクセスできるときに、最初の非プレビュー バージョンを公開します。

## <a name="create-a-release-build"></a>リリース ビルドを作成します。

NuGet パッケージは、リリース ビルドの場合、追加のツールを実行するプロジェクトを構成します。 このツールは、同じバイナリにネイティブ コードを追加します。
ツールのバイナリが処理されていることを確認するには、ビルドの出力など、この 1 つのメッセージを含めたを確認できます。

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a>FAQ

**Q。新しいバイナリは .NET Framework 4.7.2 なしのマシンでは機能しますか。**

A. .NET Framework 4.7.2 以降を実行しているときに、機能強化による最適化されたバイナリが得られます。 .NET framework の以前のバージョンを実行しているクライアントでは、最適化されていない MSIL コードをバイナリから読み込みます。

**Q。フィードバックを提供または問題を報告する方法は?**

A. Visual Studio 2017 で、フィードバック ツールを使用して、問題を報告します。 [詳細については](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)します。

**Q。既存のバイナリへのネイティブ イメージの追加の影響とは何ですか。**

A. 最適化されたバイナリには、最終的なファイルが大きいため、マネージ コードとネイティブ コードが含まれます。

**Q。このテクノロジを使用してバイナリをリリースすることができますか。**

A. このバージョンには、現在使用できる、Go Live のライセンスが含まれています。
