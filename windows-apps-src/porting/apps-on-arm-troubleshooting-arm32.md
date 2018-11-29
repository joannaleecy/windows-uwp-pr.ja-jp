---
title: ARM32 UWP アプリのトラブルシューティング
description: ARM で実行する際の ARM32 アプリの一般的な問題とその解決方法。
ms.date: 05/09/2018
ms.topic: article
keywords: windows 10 s, 常時接続, ARM での ARM32 アプリ, ARM 版 windows 10, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 6858f9add2430dc83d468b98d4147cc205dd372e
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8191198"
---
# <a name="troubleshooting-arm32-uwp-apps"></a>ARM32 UWP アプリのトラブルシューティング
>[!IMPORTANT]
> ARM64 SDK は、現在 Visual Studio 15.8 Preview 1 の一部として利用できます。 アプリがフル ネイティブ速度で実行されるように、アプリを ARM64 に再コンパイルすることをお勧めします。 詳細については、「[ARM 開発での Windows 10 の Visual Studio サポートの初期プレビュー](https://blogs.windows.com/buildingapps/2018/05/08/visual-studio-support-for-windows-10-on-arm-development/)」に関するブログ記事を参照してください。

ARM32 UWP アプリが ARM で正しく動作しない場合に役立つガイダンスを示します。 

## <a name="common-issues"></a>一般的な問題
ARM32 アプリをトラブルシューティングするときに念頭に置く必要のある一般的な問題を次に示します。

### <a name="using-windows-10-mobile-only-apis-on-arm-based-processors"></a>ARM ベースのプロセッサでの Windows 10 Mobile 専用 API の使用 
モバイル専用 API (**HardwareButtons** など) を使う場合、ARM32 アプリで問題が発生する可能性があります。 これを軽減するには、それらの API を呼び出す前に Windows 10 Mobile でアプリが実行されているかどうかを動的に検出します。 [API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)に関するブログ投稿のガイダンスに従います。

### <a name="including-dependencies-not-supported-by-uwp-apps"></a>UWP アプリによりサポートされていない依存関係の追加
Visual Studio と UWP SDK を使って適切にビルドされていないユニバーサル Windows プラットフォーム (UWP) アプリは、ARM64 システムで実行されている ARM32 アプリが使用できない OS コンポーネントに依存関係を持っていることがあります。 そのような依存関係の例は、次のとおりです。

- .NET Framework の一部が使用可能であることが期待される。
- UWP と互換性のないサード パーティの .NET コンポーネントを参照している。

これらの問題を解決するには、使用できない依存関係を削除し、最新の Microsoft Visual Studio および UWP SDK バージョンを使ってアプリを再ビルドします。または、最後の手段として、Microsoft Store から ARM32 アプリを削除し、アプリの x86 バージョン (ある場合) がユーザーの PC にダウンロードされるようにすることもできます。 

UWP アプリに使用可能な .NET API について詳しくは、「[UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)」をご覧ください。

### <a name="compiling-an-app-with-an-older-version-of-visual-studio-and-sdk"></a>以前のバージョンの Visual Studio と SDK を使ったアプリのコンパイル
問題が発生した場合、最新バージョンの Microsoft Visual Studio と Windows SDK を使ってアプリをコンパイルしていることを確認します。 以前のバージョンの Visual Studio と SDK でコンパイルされたアプリでは、以降のバージョンで修正された問題が発生する可能性があります。

## <a name="debugging"></a>デバッグ
ARM プラットフォーム用の ARM32 アプリを開発するために既存のツールを使用できます。 便利なリソースを次に示します。

- Visual Studio 15.5 Preview 1 以降では、ユニバーサル認証モードを使った ARM32 アプリの実行がサポートされます。 これにより、必要なリモート デバッグ ツールが自動的にブートストラップされます。
- ARM でデバッグを行うためのツールと戦略について詳しくは、[ARM64 でのデバッグに関するページ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64)をご覧ください。