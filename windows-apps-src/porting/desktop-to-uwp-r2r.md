---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージでデスクトップの .NET アプリケーションを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: 10、ネイティブの windows イメージのコンパイラ
ms.localizationpriority: medium
ms.openlocfilehash: d98b576fb51a8f9507802796ab359d0d00d21998
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3931122"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a>ネイティブ イメージでデスクトップの .NET アプリケーションを最適化します。

> [!NOTE]
> 一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

バイナリをプリコンパイルして、.NET Framework アプリケーションの起動時間を改善できます。 このテクノロジを使用するには、大規模なアプリケーションをパッケージ化し、Windows ストアを使用して配布するのです。 場合によっては、20% のパフォーマンスの向上は見します。 [技術概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)には、このテクノロジの詳細については。

[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)として、イメージのネイティブ コンパイラのプレビュー バージョンをリリースしましたしました。 4.6.2 のバージョンの.NET Framework を対象とする任意の.NET Framework アプリケーションにこのパッケージを適用することができますまたはそれ以降です。 このパッケージでは、ネイティブ アプリケーションで使用されるすべてのバイナリ ペイロードを含む投稿のビルド ステップを追加します。 この最適化されたペイロードは、アプリケーションが実行される .net 4.7.2 と以前のバージョンの MSIL コードがまだ読み込み中に読み込まれます。

[10 年 2018年 4 月の Windows を更新](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)するには、 [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)が含まれます。 PC 上の Windows 7 + と Windows Server 2008 R2 を実行している.NET Framework のこのバージョンをインストールすることもできます。

> [!IMPORTANT]
> Windows アプリケーションのパッケージ化プロジェクトによってパッケージ化され、アプリケーションのネイティブ イメージを生成する場合は、記念日の Windows 更新プログラムをプロジェクトのターゲット プラットフォームの最小バージョンを設定することを確認してください。

## <a name="how-to-produce-native-images"></a>ネイティブ イメージを生成する方法

プロジェクトを構成するのには、次の手順に従います。

1. 4.6.2 として以上のターゲット フレームワークを構成します。

2. X86 または x64 としてターゲット ・ プラットフォームを構成します。 

3. NuGet パッケージを追加します。

4. リリース ビルドを作成します。

## <a name="configure-the-target-framework-as-462-or-above"></a>4.6.2 として以上のターゲット フレームワークを構成します。

4.6.2 の.NET Framework を対象とするプロジェクトを構成するのには.NET Framework 4.6.2 開発ツールが必要、またはそれ以降です。 これらのツールは、.NET デスクトップ開発の作業負荷の下のオプションのコンポーネントとして Visual Studio インストーラーを使用します。

![.NET 4.6.2 をインストールする開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

またはから .NET 開発者のパックを入手できます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)

## <a name="configure-the-target-platform-as-x86-or-x64"></a>X86 または x64 としてターゲット ・ プラットフォームを構成します。

イメージのネイティブ コンパイラでは、特定のプラットフォーム用のコードを最適化します。 使用するには、x86 または x64 など特定の 1 つのプラットフォームを対象としたアプリケーションを構成する必要があります。

ソリューション内の複数のプロジェクトにある場合は、エントリ ポイントのプロジェクトのみ (ほとんどの場合、実行可能ファイルを生成するプロジェクト) は x86 または x64 としてコンパイルするのには。 AnyCPU としてコンパイルする場合でも、メインのプロジェクトでは、指定されたアーキテクチャを持つメイン プロジェクトから参照されているその他のバイナリが処理されます。

プロジェクトを構成します。

1. ソリューションを右クリックし、[**構成マネージャー**。

2. **を選択して < 新規.>** 、実行可能ファイルを作成するプロジェクトの名前の横にある**プラットフォーム**のドロップダウン ・ メニューです。

3. **新しいプロジェクト プラットフォーム**] ダイアログ ボックスで**設定のコピー元**のドロップ ダウン リストが **[Any CPU**] に設定されていることを確認します。

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

この手順を繰り返して`Release/x64`x64 を生成する場合のバイナリです。

>[!IMPORTANT]
> AnyCPU 構成は、ネイティブ イメージのコンパイラではサポートされていません。

## <a name="add-the-nuget-packages"></a>NuGet パッケージを追加します。

ネイティブ イメージのコンパイラは、実行可能ファイルを生成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージとして提供されます。 これは通常、Windows フォームまたは WPF プロジェクトです。 そのためには、次の PowerShell コマンドを使用します。

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> プレビュー パッケージは、一覧にないとして、NuGet.org で発行されます。 NuGet.org を参照して、または Visual Studio のパッケージ マネージャーの UI を使用しては検出されません。 パッケージ マネージャー コンソールからインストールするとすると別のコンピューターから復元します。 しましょうパッケージ完全にアクセス可能な最初のプレビューでないバージョンを公開するとします。

## <a name="create-a-release-build"></a>リリース ビルドを作成します。

NuGet のパッケージは、リリース ビルドの他のツールを実行するプロジェクトを構成します。 このツールは、同じバイナリのネイティブ コードを追加します。
ツールでバイナリを処理したことを確認するのには、ビルドのいずれかのこのようなメッセージが含まれて かどうかを確認するのには出力を確認できます。

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a>FAQ

**Q。 新しいバイナリに.NET Framework 4.7.2 にも動作しますか。**

A. 最適化されたバイナリが恩恵を受ける機能強化 4.7.2 の.NET Framework で実行している場合。 以前のバージョンの .NET framework を実行しているクライアントは、最適化されていない MSIL コードをバイナリから読み込まれます。

**Q。 フィードバックまたは問題の報告方法は?**

A. Visual Studio 2017 にフィードバック ツールを使用して問題を報告します。 [詳細について](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)は。

**Q。 ネイティブ イメージを追加する既存のバイナリ ファイルへの影響とは何ですか。**

A. 最適化されたバイナリには、最終的なファイルを大きくする、マネージ コードとネイティブ コードが含まれています。

**Q。 このテクノロジーを使用してバイナリをリリースすることができますでしょうか。**

A. このバージョンには、現在使用できる、本番運用のライセンスが含まれています。
