---
author: rido-min
Description: This guide explains how to configure your Visual Studio Solution to optimize the application binaries with native images.
Search.Product: eADQiWindows 10XVcnh
title: ネイティブ イメージで .NET デスクトップ アプリを最適化します。
ms.author: normesta
ms.date: 06/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、ネイティブ コンパイラをイメージします。
ms.localizationpriority: medium
ms.openlocfilehash: d98b576fb51a8f9507802796ab359d0d00d21998
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2839094"
---
# <a name="optimize-your-net-desktop-apps-with-native-images"></a>ネイティブ イメージで .NET デスクトップ アプリを最適化します。

> [!NOTE]
> 一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

バイナリのコンパイル済みで、.NET Framework アプリケーションの起動時を向上させることができます。 パッケージ化し、Windows ストアで配布する大規模なアプリケーションでは、このテクノロジを使用できます。 場合によっては、お見 20% のパフォーマンスが向上します。 [技術的な概要](https://github.com/dotnet/coreclr/blob/master/Documentation/botr/readytorun-overview.md)には、この技術の詳細を学びます。

ネイティブ イメージ コンパイラの preview 版をリリース[NuGet パッケージ](https://www.nuget.org/packages/Microsoft.DotNet.Framework.NativeImageCompiler)としてしましたしました。 このパッケージを適用するには、.NET Framework バージョン 4.6.2 を対象とするすべての .NET Framework アプリケーションまたはそれ以降。 このパッケージでは、ネイティブ アプリケーションで使用されているすべてのバイナリ ペイロードを含む投稿ビルド ステップを追加します。 アプリケーションが実行される .NET 4.7.2 で上にある以前のバージョンの MSIL コードはまだ読み込み中に最適化されたこのペイロードが読み込まれます。

[Windows 10 年 2018年 4 月を更新](https://blogs.windows.com/windowsexperience/2018/04/30/how-to-get-the-windows-10-april-2018-update/)するには、 [.NET framework 4.7.2](https://blogs.msdn.microsoft.com/dotnet/2018/04/30/announcing-the-net-framework-4-7-2/)は含まれています。 Windows 7 + および Windows Server 2008 R2 + を実行しているコンピューター上の .NET Framework には、このバージョンをインストールすることもできます。

> [!IMPORTANT]
> Windows アプリケーション パッケージのプロジェクトでパッケージ化、アプリケーションのネイティブ イメージを作成する場合は、Windows 記念日の更新プログラムにプロジェクトのターゲット プラットフォームの最小バージョンを設定するのに確認します。

## <a name="how-to-produce-native-images"></a>ネイティブ イメージを作成する方法

プロジェクトを構成するのには、次の手順に従います。

1. 4.6.2 または上にあるターゲット フレームワークを構成します。

2. X86 または x64 としてターゲット プラットフォームを構成します。 

3. NuGet パッケージを追加します。

4. リリース ビルドを作成します。

## <a name="configure-the-target-framework-as-462-or-above"></a>4.6.2 または上にあるターゲット フレームワークを構成します。

.NET Framework 4.6.2 対象プロジェクトを構成するのには、.NET Framework 4.6.2 開発ツール必要があります以降。 これらのツールは、.NET デスクトップ開発作業負荷の下にある省略可能なコンポーネントとして Visual Studio インストーラーで提供されます。

![.NET 4.6.2 をインストールする開発ツール](images/desktop-to-uwp/install-4.6.2-devpack.png)

またはから .NET 開発パックを入手することができます。[https://www.microsoft.com/net/download/visual-studio-sdks](https://www.microsoft.com/net/download/visual-studio-sdks)

## <a name="configure-the-target-platform-as-x86-or-x64"></a>X86 または x64 としてターゲット プラットフォームを構成します。

ネイティブ イメージ コンパイラでは、特定のプラットフォームのコードを最適化します。 これを使用するには、x86 または x64 など特定の 1 つのプラットフォームの対象としたアプリケーションを構成する必要があります。

複数のプロジェクト ソリューションである場合は、x86 または x64 としてコンパイル エントリ ポイント プロジェクトのみ (いる可能性が高い実行可能ファイルを作成するプロジェクト) があります。 メインのプロジェクトから参照されているその他のバイナリが AnyCPU としてコンパイルした場合でも、メインのプロジェクトで指定されたアーキテクチャで処理されます。

プロジェクトを構成するには。

1. ソリューションを右クリックし、[**構成マネージャー**] を選びます。

2. 選択 **< 新しい.>** 、実行可能ファイルを作成するプロジェクトの名前の横にある**プラットフォーム**] ドロップダウン メニューでします。

3. **新しいプロジェクト プラットフォーム**] ダイアログ ボックスで、**設定のコピー元**のドロップダウン リストを**任意の CPU**に設定されていることを確認します。

![X86 を構成します。](images/desktop-to-uwp/configure-x86.png)

この手順を繰り返します`Release/x64`x64 を作成する場合のバイナリします。

>[!IMPORTANT]
> AnyCPU 構成は、ネイティブ イメージ コンパイラでサポートされていません。

## <a name="add-the-nuget-packages"></a>NuGet パッケージを追加します。

ネイティブ イメージ コンパイラ実行可能ファイルを作成する Visual Studio プロジェクトに追加する必要がある NuGet パッケージが表示されます。 これは、通常は、Windows フォームまたは WPF プロジェクトです。 そのためには、次の PowerShell コマンドを使用します。

```PS
PM> Install-Package Microsoft.DotNet.Framework.NativeImageCompiler -Version 0.0.1-prerelease-00002  -PRE
```

> [!NOTE]
> プレビュー パッケージは、一覧にないとして NuGet.org で発行されます。 参照 NuGet.org または Visual Studio でパッケージ マネージャーのユーザー インターフェイスを使用して、表示されません。 パッケージ マネージャーからインストールするただしと別のコンピューターから復元します。 しましょうパッケージ完全にアクセスできるときに、最初のプレビューでないバージョンを公開します。

## <a name="create-a-release-build"></a>リリース ビルドを作成します。

NuGet パッケージ リリース ビルドの他のツールを実行するプロジェクトを設定します。 このツールは、同じバイナリにネイティブ コードを追加します。
ツールがバイナリを処理されることを確認するのには、ビルドなど、このメッセージが含まれて かどうかを確認する出力を確認できます。

```
Native image obj\x86\Release\\R2R\DesktopApp1.exe generated successfully.
```

## <a name="faq"></a>FAQ

**Q します。 .NET Framework 4.7.2 に操作する新しいバイナリすればよいですか。**

A. 最適化されたバイナリがのメリットを享受改善点は、.NET Framework 4.7.2 で実行されているときにします。 .NET framework の以前のバージョンを実行しているクライアントはバイナリから最適化されていない MSIL コードを読み込みます。

**Q します。 フィードバックを送信するまたは問題を報告する方法は?**

A. Visual Studio 2017 でフィードバック ツールを使用して、問題の報告します。 [その他の情報](https://docs.microsoft.com/visualstudio/ide/how-to-report-a-problem-with-visual-studio-2017)です。

**Q します。 既存のバイナリにネイティブ イメージを追加する場合の影響は何ですか。**

A. 最適化されたバイナリより大きい最終的なファイルを作成、管理し、ネイティブ コードが含まれています。

**Q します。 このテクノロジを使用してバイナリを解放することができますか。**

A. このバージョンには、現在使用できる Live 移動ライセンスが含まれています。
