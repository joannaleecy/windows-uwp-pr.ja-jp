---
author: stevewhims
Description: MakePri.exe is a command line tool that you can use to create and dump PRI files. It is integrated as part of MSBuild within Microsoft Visual Studio, but it could be useful to you for creating packages manually or with a custom build system.
title: MakePri.exe を使用して手動でリソースをコンパイルする
template: detail.hbs
ms.author: stwhi
ms.date: 10/23/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: d065fdffe2fcb32a9d574c90f59eb7115597167a
ms.sourcegitcommit: f5cf806a595969ecbb018c3f7eea86c7a34940f6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/10/2018
ms.locfileid: "3823516"
---
# <a name="compile-resources-manually-with-makepriexe"></a>MakePri.exe を使用して手動でリソースをコンパイルする

MakePri.exe は、PRI ファイルを作成およびダンプするために使用できるコマンド ライン ツールです。 このツールは、Microsoft Visual Studio の MSBuild の一部として統合されていますが、パッケージを手動で作成したり、カスタム ビルド システムを使って作成する場合にも使うことができます。

> [!NOTE]
> Windows ソフトウェア開発キットをインストールするときに、 **Windows SDK for UWP アプリの管理**オプションをオンにすると、MakePri.exe がインストールされます。 パスにインストールされている`%WindowsSdkDir%bin\<WindowsTargetPlatformVersion>\x64\makepri.exe`(およびその他のアーキテクチャの名前のフォルダーの)。 たとえば、`C:\Program Files (x86)\Windows Kits\10\bin\10.0.17713.0\x64\makepri.exe` と記述します。

PRI ファイルのサイズ制限は、64 キロバイトです。

## <a name="in-this-section"></a>このセクションの内容
|トピック|説明|
|-|-|
| [MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md) | MakePri.exe には、`createconfig`、`dump`、`new`、`resourcepack`、`versioned` コマンドのセットが含まれます。 このトピックでは、コマンド ライン オプションの使用について説明します。 |
| [MakePri.exe 構成ファイル](makepri-exe-configuration.md) | ここでは、MakePri.exe XML 構成ファイルのスキーマについて説明します。 |
| [MakePri.exe の形式に固有のインデクサー](makepri-exe-format-specific-indexers.md) | このトピックでは、リソースのインデックスを生成するために MakePri.exe ツールによって使われる形式に固有のインデクサーについて説明します。 |

## <a name="makepriexe-command-line-options"></a>MakePri.exe のコマンド ライン オプション

MakePri.exe には、`createconfig`、`dump`、`new`、`resourcepack`、`versioned` コマンドのセットが含まれます。 コマンド ライン オプションの使い方について詳しくは、「[MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md)」をご覧ください。

## <a name="makepriexe-configuration"></a>MakePri.exe 構成

PRI XML 構成ファイルは、どのリソースをどのようにインデックス化するかを制御します。 構成 XML のスキーマについては、「[MakePri.exe 構成](makepri-exe-configuration.md)」をご覧ください。

## <a name="format-specific-indexers"></a>形式に固有のインデクサー

MakePri.exe は、通常、`new`、`versioned`、`resourcepack` オプションと共に使用されます。 これらのオプションを使うと、ソース ファイルがインデックス化され、リソースのインデックスが生成されます。 MakePri.exe は、さまざまな別個のインデクサーを使って異なるソース リソース ファイルまたはリソースのコンテナーを読み取ります。 最も単純なインデクサーは、リソース (`.jpg` 画像 や `.png` 画像など) のフォルダーの内容をインデックス化するフォルダー インデクサーです。 詳細については、「[MakePri.exe の形式に固有のインデクサー](makepri-exe-format-specific-indexers.md)」をご覧ください。

## <a name="makepriexe-warnings-and-error-messages"></a>MakePri.exe の警告およびエラー メッセージ

```
Resources found for language(s) '<language(s)>' but no resources found for default language(s): '<language(s)>'. Change the default language or qualify resources with the default language.
```

上記の警告は、言語修飾子によるマークが付けられていると見なされる特定の名前付きリソースのファイルまたは文字列リソースが MakePri.exe または MSBuild によって検出されながら、既定の言語の候補が見つからなかった場合に表示されます。 ファイルやフォルダーの名前に修飾子を使用するプロセスについては、「[言語、スケール、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。 ファイルやフォルダーの名前に言語名を含めることはできますが、リソースはその明示された既定の言語に対して修飾されているとは見なされません。 たとえば、プロジェクトで使う既定の言語が "en-US" で、"de/logo.png" という名前のファイルがプロジェクトにある場合に、既定の言語の "en-US" でマークされたファイルがないと、この警告が出力されます。 この警告が出力されないようにするには、ファイルまたは文字列リソースを既定の言語で修飾するか、または既定の言語を変更する必要があります。 既定の言語を変更するには、Visual Studio でソリューションを開いた状態で、`Package.appxmanifest` を開きます。 [アプリケーション] タブで、既定の言語が適切に設定されている ("en"や "en-us" など) ことを確認します。

```
No default or neutral resource given for '<resource identifier>'. The application may throw an exception for certain user configurations when retrieving the resources.
```

上記の警告は、言語修飾子によるマークが付けられていると見なされるファイルまたはリソースが MakePri.exe または MSBuild によって検出された一方で対応するリソースが不明確な場合に表示されます。 修飾子はありますが、実行時にそのリソース識別子に対して特定のリソース候補を返すことができるという保証がありません。 特定の言語、住んでいる地域、またはその他の修飾子のリソース候補について、既定値であるかまたはユーザーのコンテキストに常に一致することが検出されない場合、この警告が表示されます。 実行時、ユーザーの言語設定や住んでいる地域などの特定のユーザー構成に関して (**[設定]** > **[時刻と言語]** > **[地域と言語]**)、リソースを取得するために使われた API が予期しない例外をスローすることがあります。 この警告が出力されないようにするには、既定のリソースを用意する必要があります。たとえば、プロジェクトの既定の言語やグローバルな住んでいる地域 (homeregion-001) のリソースを用意します。

## <a name="using-makepriexe-in-a-build-system"></a>ビルド システムでの MakePri.exe の使用

ビルドするプロジェクトの種類に応じて、ビルド システムで MakePri.exe の `new`、`versioned`、または `resourcepack` コマンドを使う必要があります。 新しい PRI ファイルを作成するビルド システムでは、`new` コマンドを使う必要があります。 反復を使って内部オフセットの互換性を確認するビルド システムでは、`versioned` コマンドを使うことができます。 リソースの追加バリアントを格納する PRI ファイルを作成し、そのバリアントに対して新しいリソースが追加されないことを確認するビルド システムでは、`resourcepack` コマンドを使う必要があります。

インデックスを作成するソース ファイルを明示的にコントロールする必要があるビルド システムでは、フォルダーをインデックス化する代わりに、ResFiles インデクサーを使うことができます。 また、ビルド システムでは、複数のインデックス パスをさまざまな[形式に固有のインデクサー](makepri-exe-format-specific-indexers.md)と共に使って、単一の PRI ファイルを生成できます。

さらに、ビルド システムでは、PRI 形式に固有のインデクサーを使って、ビルド済みの PRI ファイルを他のコンポーネント (クラス ライブラリ、アセンブリ、SDK、DLL など) のパッケージの PRI に追加できます。

他のコンポーネント、クラス ライブラリ、アセンブリ、DLL、SDK 用に PRI ファイルをビルドする場合は、**initialPath** 構成を使って、格納先のアプリと競合しない独自のサブリソース マップがコンポーネント リソースにあることを確認します。

## <a name="related-topics"></a>関連トピック
* [MakePri.exe のコマンド ライン オプション](makepri-exe-command-options.md)
* [MakePri.exe 構成](makepri-exe-configuration.md)
* [MakePri.exe の形式に固有のインデクサー](makepri-exe-format-specific-indexers.md)
* [言語、スケール、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)
