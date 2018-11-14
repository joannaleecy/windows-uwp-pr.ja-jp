---
title: ARM 版 Windows 10
author: msatranjr
description: この記事では、ARM でエクスペリエンスとアプリがどのように実行されるかの概要、どのような制限事項があるか、詳しい情報を参照できる場所について説明します。
ms.author: misatran
ms.date: 02/15/2018
ms.topic: article
keywords: windows 10 s, 常時接続, ARM, ARM64, x86 エミュレーション
ms.localizationpriority: medium
ms.openlocfilehash: 8f62a873e84f200a019bde23038ae10b21150072
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6257739"
---
# <a name="windows-10-on-arm"></a>ARM 版 Windows 10
もともと、Windows 10 (Windows 10 Mobile とは区別されます) は、x86 および x64 プロセッサを搭載した PC でのみ実行できました。 現在では、Fall Creators Update により、ARM64 プロセッサ搭載のコンピューターでも Windows 10 Desktop (Pro エディションおよび S エディション) を実行できるようになりました。 ARM CPU アーキテクチャが持つ省電力の性質により、これらの PC のバッテリーが終日持つようになり、モバイル データ ネットワークがサポートされるようになります。 これらの PC にはアプリケーションの互換性が十分に備わっており、既存の x86 win32 アプリケーションを変更せずに実行できます。 例: Adobe Reader。 詳細またはデモについては、[Always Connected PC に関する Channel 9 ビデオ](https://channel9.msdn.com/Events/Build/2017/P4171)をご覧ください。 

ここでは、*"ARM"* という用語を、ARM64 (一般に *AArch64* とも呼ばれます) プロセッサで Windows 10 のデスクトップ バージョンを実行する PC の省略形として使っています。  ここでは、*"ARM32"* という用語を、32 ビット ARM アーキテクチャ (他のドキュメントでは一般に *ARM* と呼ばれます) の省略形として使っています。

## <a name="apps-and-experiences-on-arm"></a>ARM でのアプリとエクスペリエンス

### <a name="built-in-windows-10-experiences-apps-and-drivers"></a>組み込みの Windows 10 エクスペリエンス, アプリとドライバー
Edge、Cortana、スタート メニュー、エクスプローラーなどの組み込みの Windows 10 エクスペリエンスは、すべてネイティブであり、ARM64 (または ARM32) として実行されます。 これには、グラフィックス、ネットワーク、ハード ディスクなどのすべてのデバイス ドライバーも含まれます。 これにより、Qualcomm Snapdragon プロセッサのフル ネイティブ速度で実行されるデバイスにおけるユーザー エクスペリエンスとバッテリー寿命が最適化されます。

### <a name="universal-windows-platform-uwp-apps"></a>ユニバーサル Windows プラットフォーム (UWP) アプリ
ARM 版 Windows 10 では、Microsoft Store のすべての x86 および ARM32 [UWP アプリ](../get-started/universal-application-platform-guide.md)が実行されます。 ARM32 アプリはエミュレーションされずにネイティブで実行されますが、x86 アプリはエミュレーション下で実行されます。 UWP 開発者の場合、デバイスの最適なユーザー エクスペリエンスを提供するため、必ずアプリの ARM パッケージを提出してください。 詳しくは、「[アプリ パッケージのアーキテクチャ](../packaging/device-architecture.md)」をご覧ください。

>[!IMPORTANT] 
> ユーザーが Microsoft Store から UWP アプリをダウンロードすると、x86 バージョンしか利用できない場合を除き、ARM32 バージョンが ARM64 デバイスにダウンロードされます。 アーキテクチャについて詳しくは、「[アプリ パッケージのアーキテクチャ](../packaging/device-architecture.md)」をご覧ください。

### <a name="win32-apps"></a>Win32 アプリ
UWP アプリに加えて、ARM 版 Windows 10 では x86 Win32 アプリ (Adobe Reader など) も変更せずに実行でき、他の PC と同じように適切なパフォーマンスとシームレスなユーザー エクスペリエンスが提供されます。 これらの x86 win32 アプリは ARM 用に再コンパイルする必要がなく、ARM プロセッサで実行されていることを認識することもありません。 64 ビット x64 Win32 アプリはサポートされていませんが、ほぼすべてのアプリに x86 バージョンがあるため、ユーザーの観点からは 32 ビット x86 インストーラーを選ぶだけで ARM PC の Windows で実行できます。

## <a name="in-this-section"></a>このセクションの内容
|トピック | 説明 |
|-----|-----|
|[ARM での x86 エミュレーション](apps-on-arm-x86-emulation.md)|x86 アプリが ARM でどのようにエミュレートされるかの概要。|
|[ARM における x86 アプリのトラブルシューティング](apps-on-arm-troubleshooting-x86.md)|ARM で実行する際の x86 アプリの一般的な問題とその解決方法。 |
|[ARM における ARM32 アプリのトラブルシューティング](apps-on-arm-troubleshooting-arm32.md)|ARM で実行する際の ARM32 アプリの一般的な問題とその解決方法。 |
|[プログラム互換性のトラブルシューティング ツール (ARM)](apps-on-arm-program-compat-troubleshooter.md)|アプリが ARM で正しく動作しない場合に互換性の設定を調整するためのガイダンス。 |

## <a name="related-topics"></a>関連トピック
|トピック | 説明 |
|-----|-----|
|[WDK を使った ARM64 ドライバーのビルド](https://docs.microsoft.com/en-us/windows-hardware/drivers/develop/building-arm64-drivers)|ARM64 ドライバーをビルドするための手順。 |
| [ARM における x86 アプリのデバッグ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64) | ARM で x86 アプリをデバッグするためのガイダンス。 |
