---
Description: パッケージ リソース インデックス (PRI) Api には、UWP アプリのリソース用のカスタム ビルド システムを開発できます。 ビルド システムでは、UWP アプリで必要となる複雑さのレベルにかかわらず、PRI ファイルの作成やバージョン管理を行ったり、PRI ファイルをダンプしたりすることができます。
title: パッケージ リソース インデックス (PRI) API とカスタム ビルド システム
template: detail.hbs
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 617812415d3dcd00ec24d5f55971ae311265b61d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57598517"
---
# <a name="package-resource-indexing-pri-apis-and-custom-build-systems"></a>パッケージ リソース インデックス (PRI) API とカスタム ビルド システム
[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用すると、UWP アプリのリソース用にカスタム ビルド システムを開発することができます。 ビルド システムでは、UWP アプリが必要とする複雑さのレベルにかかわらず、パッケージ リソース インデックス (PRI) ファイルを (XML として) 作成、バージョン管理、ダンプすることができます。 現在 MakePri.exe コマンド ライン ツールを使用しているカスタム ビルド システムがある場合 (「[MakePri.exe を使用して手動でリソースをコンパイルする](makepri-exe-command-options.md)」を参照)、パフォーマンスと制御を向上させるために、MakePri.exe の呼び出しではなく、PRI API の呼び出しに切り替えることをお勧めします。

PRI API は、Windows 10 向け Windows SDK のバージョン 1803 で導入されました。 API は、Win32 Windows API の形式になります。つまり、それらを呼び出すオプションがいくつかあります。 Win32 アプリから直接それらを呼び出すか、または .NET アプリ、さらには UWP アプリからでも [platform invoke](/dotnet/framework/interop/consuming-unmanaged-dll-functions?branch=live) を介してそれらを呼び出すことができます。

このトピックのシナリオでは、Win32 Visual C++ Windows Console Application プロジェクトからの PRI API の呼び出しを示します。 背景情報については、「[リソース管理システム](resource-management-system.md)」を参照してください。

PRI ファイルのサイズ制限は、64 キロバイトです。

> [!NOTE]
> おそらくカスタム ビルド システム アプリを Microsoft Store に提出する必要はないため、この注意事項が問題になることはあまりありません。 ただし、UWP アプリの形式でカスタム ビルド システムを開発するオプションを選択する場合、そのアプリは Microsoft Store に提出することができないという点で通常とは異なる UWP アプリになります。 これは、プラットフォーム呼び出しを使用する UWP アプリが Microsoft Store 認定に失敗するためです。 この場合、プラットフォームの起動呼び出しは、配布する UWP アプリ (PRI ファイルを作成しているアプリ) *ではなく*、*カスタム ビルド システムでのみ行われる*点に注意してください。

## <a name="scenario-walkthroughs"></a>シナリオのチュートリアル
|トピック|説明|
|-|-|
|[シナリオ 1:文字列リソースと資産ファイルからの PRI ファイルを生成します。](pri-apis-scenario-1.md)|このシナリオでは、カスタム ビルド システムを表す新しいアプリを作成します。 リソース インデクサーを作成し、文字列とその他の種類のリソースを追加します。 次に、PRI ファイルを生成してダンプします。|

## <a name="important-apis"></a>重要な API
* [パッケージのリソース インデックス (PRI) の参照](https://msdn.microsoft.com/library/windows/desktop/mt845690)

## <a name="related-topics"></a>関連トピック
* [MakePri.exe を使用して手動でリソースをコンパイルする](makepri-exe-command-options.md)
* [アンマネージ DLL 関数の処理](/dotnet/framework/interop/consuming-unmanaged-dll-functions?branch=live)
* [リソース管理システム](resource-management-system.md)
