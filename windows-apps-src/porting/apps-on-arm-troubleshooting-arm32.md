---
title: ARM32 UWP アプリのトラブルシューティング
description: ARM で実行する際の ARM32 アプリの一般的な問題とその解決方法。
ms.date: 01/03/2019
ms.topic: article
keywords: windows 10 s, 常時接続, ARM での ARM32 アプリ, ARM 版 windows 10, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 75019df4b7d70dad20aea1a256abac05c93a481d
ms.sourcegitcommit: 62bc4936ca8ddf1fea03d43a4ede5d14a5755165
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/04/2019
ms.locfileid: "8991638"
---
# <a name="troubleshooting-arm-uwp-apps"></a>UWP アプリを ARM のトラブルシューティング

ARM32 または ARM64 UWP アプリが ARM で正しく動作しない場合に、役立つガイダンスを示します。

>[!NOTE]
> ネイティブ ARM64 プラットフォームを対象とする UWP アプリケーションを構築するには、Visual Studio 2017 バージョン 15.9 以降が必要です。 詳細については、[このブログ記事](https://blogs.windows.com/buildingapps/2018/11/15/official-support-for-windows-10-on-arm-development)を参照してください。

## <a name="common-issues"></a>一般的な問題
ARM32 および ARM64 アプリのトラブルシューティングを行う際に留意する一般的な問題を次に示します。

### <a name="using-windows-10-mobile-only-apis-on-arm-based-processors"></a>ARM ベースのプロセッサでの Windows 10 Mobile 専用 API の使用
ARM アプリは、モバイル専用 Api (たとえば、 **HardwareButtons**) を使う場合、問題が発生実行可能性があります。 これを軽減するには、それらの API を呼び出す前に Windows 10 Mobile でアプリが実行されているかどうかを動的に検出します。 [API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)に関するブログ投稿のガイダンスに従います。

### <a name="including-dependencies-not-supported-by-uwp-apps"></a>UWP アプリによりサポートされていない依存関係の追加
Visual Studio と UWP SDK に組み込まれていない正しくユニバーサル Windows プラットフォーム (UWP) アプリ、ARM64 システムで実行されている ARM アプリが使用できない OS コンポーネントに依存関係があります。 そのような依存関係の例は、次のとおりです。

- .NET Framework の一部が使用可能であることが期待される。
- UWP と互換性のないサード パーティの .NET コンポーネントを参照している。

これらの問題を解決できる: 使用できない依存関係を削除し、最新の Microsoft Visual Studio と UWP SDK バージョンの; を使用して、アプリを再構築します。または、Microsoft Store から ARM アプリを削除する最後の手段としてできるように、x86 バージョンのアプリ (ある場合) がユーザーの Pc にダウンロードします。

UWP アプリに使用可能な .NET API について詳しくは、「[UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)」をご覧ください。

### <a name="compiling-an-app-with-an-older-version-of-visual-studio-and-sdk"></a>以前のバージョンの Visual Studio と SDK を使ったアプリのコンパイル
問題が発生した場合、最新バージョンの Microsoft Visual Studio と Windows SDK を使ってアプリをコンパイルしていることを確認します。 以前のバージョンの Visual Studio と SDK でコンパイルされたアプリでは、以降のバージョンで修正された問題が発生する可能性があります。

## <a name="debugging"></a>デバッグ
ARM プラットフォーム用のアプリを開発するため、既存のツールを使用することができます。 便利なリソースを次に示します。

- Visual Studio 15.5 Preview 1 以降では、ユニバーサル認証モードを使った ARM32 アプリの実行がサポートされます。 これにより、必要なリモート デバッグ ツールが自動的にブートストラップされます。
- ARM でデバッグを行うためのツールと戦略について詳しくは、[ARM64 でのデバッグに関するページ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64)をご覧ください。
