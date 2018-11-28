---
title: アプリ インストーラー ファイルを使ったインストールに関する問題のトラブルシューティング
description: アプリ インストーラー ファイルを使ってアプリケーションをサイドローディングするときの一般的な問題。
ms.date: 5/2/2018
ms.topic: article
keywords: Windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング
ms.localizationpriority: medium
ms.openlocfilehash: d4c3aa690dd45a50e6f33d664fbc6cc4503e93f8
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7838319"
---
# <a name="troubleshoot-installation-issues-with-the-app-installer-file"></a>アプリ インストーラー ファイルを使ったインストールに関する問題のトラブルシューティング

アプリ インストーラー ファイルからアプリケーションをインストールするときに問題が発生した場合、このトピックで示されているトラブルシューティングのガイダンスが役立つことがあります。

## <a name="prerequisites"></a>前提条件

Windows 10 でアプリをサイドローディングできるようにするには、ユーザーのデバイスが以下の要件を満たしている必要があります。

- デバイスで開発者モードまたはサイドローディング アプリが有効になっている必要があります。 詳しくは、「[デバイスを開発用に有効にする](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development)」ご覧ください。
- パッケージの署名に使う証明書がデバイスによって信頼されている必要があります。 詳しくは、後述の「**信頼できる証明書**」をご覧ください。
- Windows 10 のバージョンで `.appinstaller` ファイル スキーマと配布プロトコルがサポートされている必要があります。

## <a name="common-issues"></a>一般的な問題

ユーザーのコンピューターで初めてアプリケーションをサイドローディングするときにいくつかの問題がよく発生します。 以降のセクションでは、最も一般的な問題とその解決策について説明します。

### <a name="windows-version"></a>Windows のバージョン

Windows 10 の各リリースでは、サイドローディング エクスペリエンスが強化されています。次の表に、各メジャー リリースで利用可能な機能を示します。 お使いのバージョンの Windows 10 でサポートされていない方法を使ってアプリをサイドローディングしようとすると、展開エラーが発生します。

| バージョン | サイドローディングの注意事項 |
|---------|----------------|
| ビルド 17134 (2018 年 4 月の更新プログラム バージョン 1804)    | `.appinstaller` ファイルには、UNC/共有フォルダー経由でアクセスすることができます。 構成可能な更新プログラムのチェックも使用できます。 |
| ビルド 16299 (Fall Creators Update バージョン 1709) | アプリを自動更新するため、`.appinstaller` ファイルが導入されました。 このバージョンでは、HTTP エンドポイントのみサポートされます。 更新プログラムのチェックは構成できません。24 時間おきに行われます。 |
| ビルド 15063 (Creators Update バージョン 1703)      | アプリ インストーラー アプリは、Microsoft Store からアプリの依存関係をダウンロードできます (リリース モードでのみ)。 |
| ビルド 14393 (Anniversary Update バージョン 1607)   | .appx ファイルと .appxbundle ファイルをインストールするため、アプリ インストーラー アプリが導入されました。.appinstaller ファイルはサポートされません。 |
| ビルド 10586 (November Update バージョン 1511)      | サイドローディングは、PowerShell で [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) コマンドを使う場合のみ使用できます。 |
| ビルド 10240 (Windows 10 バージョン 1507)           | サイドローディングは、PowerShell で [Add-AppxPackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) コマンドを使う場合のみ使用できます。 |

### <a name="trusted-certificates"></a>信頼できる証明書

アプリ パッケージは、デバイスで信頼されている証明書を使って署名されている必要があります。 共通の証明機関によって提供される証明書は、Windows オペレーティング システムで既定で信頼されますが、証明書が信頼されていない場合、アプリをインストールする**前に**デバイスにインストールする必要があります。 証明書を信頼するには、証明書がデバイス上の次のいずれかのローカル コンピューター証明書ストアに存在している必要があります。

- 信頼される発行者
- 信頼されたユーザー
- 信頼されたルート機関 (非推奨)

 >[!IMPORTANT]
 > ローカル コンピューター ストアに証明書をインストールするには、管理アクセス権が必要です。

### <a name="dependencies-not-installed"></a>依存関係はインストールされない 

UWP アプリケーションには、アプリの生成に使用されるアプリケーション プラットフォームに基づいてフレームワークの依存関係を設定できます。 C# や VB を使っている場合、アプリには .NET Runtime と .NET Framework パッケージが必要になります。 C++ アプリケーションには VCLibs が必要です。

>[!IMPORTANT] 
> アプリ パッケージがリリース モード構成でビルドされた場合、フレームワークの依存関係は Microsoft Store から取得されます。 ただし、アプリがデバッグ モード構成でビルドされた場合、依存関係は `.appinstaller` ファイルで指定された場所から取得されます。

### <a name="files-not-accessible"></a>ファイルにアクセスできない

HTTP エンドポイントからインストールする場合、すべてのファイルに正しい MIME タイプを使ってアクセスできることを確認することが重要です。 これらのファイルを確認する最も簡単な方法として、Visual Studio によって生成された HTML ページにあるリンクに移動できます。 以下のファイルを確認する必要があります。

- `.appinstaller` ファイル。使用可能:  `application/xml`
- `.appx` `.appxbundle` ファイル。使用可能:  `application/vns.ms-appx`

## <a name="isolate-app-installer-app-issues"></a>アプリ インストーラー アプリの問題の切り分け

アプリ インストーラー アプリがアプリをインストールできない場合、次の手順でインストールの問題を識別できます。

### <a name="verify-app-package-file-installation"></a>アプリ パッケージ ファイルのインストールを確認します。

- アプリのパッケージ ファイルをローカル フォルダーにダウンロードし、 [Add-appxpackage](https://docs.microsoft.com/powershell/module/appx/add-appxpackage?view=win10-ps) PowerShell コマンドを使用してインストールを試みます。

- `.appinstaller` ファイルをローカル フォルダーにダウンロードし、`Add-AppxPackage -Appinstaller` PowerShell コマンドを使ってインストールしてみます。

## <a name="related-logs"></a>関連するログ

アプリ展開インフラストラクチャには、Windows イベント ビューアーでデバッグするためのログが用意されています。 これらのログは以下の場所にあります。 `Application and Services Logs->Microsoft->Windows->AppxDeployment-Server`



