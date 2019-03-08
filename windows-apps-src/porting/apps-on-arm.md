---
title: ARM 版 Windows 10
description: この記事では、ARM でエクスペリエンスとアプリがどのように実行されるかの概要、どのような制限事項があるか、詳しい情報を参照できる場所について説明します。
ms.date: 02/15/2018
ms.topic: article
keywords: windows 10 s, 常時接続, ARM, ARM64, x86 エミュレーション
ms.localizationpriority: medium
ms.openlocfilehash: 47677cb2a9e8d62c76f10f932b142c4dba9752c6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640997"
---
# <a name="windows-10-on-arm"></a>ARM 版 Windows 10
もともと、Windows 10 (Windows 10 Mobile とは区別されます) は、x86 および x64 プロセッサを搭載した PC でのみ実行できました。 現在では、Fall Creators Update により、ARM64 プロセッサ搭載のコンピューターでも Windows 10 Desktop (Pro エディションおよび S エディション) を実行できるようになりました。 ARM CPU アーキテクチャが持つ省電力の性質により、これらの PC のバッテリーが終日持つようになり、モバイル データ ネットワークがサポートされるようになります。 これらの PC にはアプリケーションの互換性が十分に備わっており、既存の x86 win32 アプリケーションを変更せずに実行できます。 例: Adobe Reader。 詳細またはデモについては、[Always Connected PC に関する Channel 9 ビデオ](https://channel9.msdn.com/Events/Build/2017/P4171)をご覧ください。

ここでは、*"ARM"* という用語を、ARM64 (一般に *AArch64* とも呼ばれます) プロセッサで Windows 10 のデスクトップ バージョンを実行する PC の省略形として使っています。  ここでは、*"ARM32"* という用語を、32 ビット ARM アーキテクチャ (他のドキュメントでは一般に *ARM* と呼ばれます) の省略形として使っています。

## <a name="apps-and-experiences-on-arm"></a>ARM でのアプリとエクスペリエンス

### <a name="built-in-windows-10-experiences-apps-and-drivers"></a>組み込みの Windows 10 エクスペリエンス, アプリとドライバー
Edge、Cortana、スタート メニュー、エクスプローラーなどの組み込みの Windows 10 エクスペリエンスは、すべてネイティブであり、ARM64 (または ARM32) として実行されます。 これには、グラフィックス、ネットワーク、ハード ディスクなどのすべてのデバイス ドライバーも含まれます。 これにより、Qualcomm Snapdragon プロセッサのフル ネイティブ速度で実行されるデバイスにおけるユーザー エクスペリエンスとバッテリー寿命が最適化されます。

### <a name="universal-windows-platform-uwp-apps"></a>ユニバーサル Windows プラットフォーム (UWP) アプリ
ARM 上の Windows 10 の実行、ARM32、および ARM64 のすべての x86 [UWP アプリ](../get-started/universal-application-platform-guide.md)Microsoft Store から。 任意のエミュレーションではなくネイティブ実行 ARM32 および ARM64 のアプリでは、x86 エミュレーションでアプリが実行中にします。 UWP 開発者の場合、デバイスの最適なユーザー エクスペリエンスを提供するため、必ずアプリの ARM パッケージを提出してください。 詳しくは、「[アプリ パッケージのアーキテクチャ](../packaging/device-architecture.md)」をご覧ください。

>[!NOTE]
> ネイティブ ARM64 プラットフォームを対象とする UWP アプリケーションを構築するには、Visual Studio 2017 バージョン 15.9 以降が必要です。 詳細については、次を参照してください。[このブログの投稿](https://blogs.windows.com/buildingapps/2018/11/15/official-support-for-windows-10-on-arm-development)します。

>[!IMPORTANT]
> ユーザーが Microsoft Store から UWP アプリをダウンロードすると、x86 バージョンしか利用できない場合を除き、ARM32 バージョンが ARM64 デバイスにダウンロードされます。 アーキテクチャについて詳しくは、「[アプリ パッケージのアーキテクチャ](../packaging/device-architecture.md)」をご覧ください。

### <a name="win32-apps"></a>Win32 アプリ
UWP アプリに加えて ARM 上の Windows 10 も Win32、x86 を実行 (Adobe Reader) などのアプリが未変更の状態で良好なパフォーマンスと、シームレスなユーザー エクスペリエンスには任意の PC と同様です。 ARM プロセッサで実行されているこれらの x86 Win32 アプリは、ARM 用の再コンパイルする必要はありませんし、しないことを認識しています。 64 ビット x64 Win32 アプリはサポートされていませんが、ほぼすべてのアプリに x86 バージョンがあるため、ユーザーの観点からは 32 ビット x86 インストーラーを選ぶだけで ARM PC の Windows で実行できます。

## <a name="in-this-section"></a>このセクションの内容
|トピック | 説明 |
|-----|-----|
|[どのようにエミュレーションが ARM で動作する x86](apps-on-arm-x86-emulation.md)|x86 アプリが ARM でどのようにエミュレートされるかの概要。|
|[X86 をトラブルシューティング ARM 上のアプリ](apps-on-arm-troubleshooting-x86.md)|ARM で実行する際の x86 アプリの一般的な問題とその解決方法。 |
|[ARM 上の ARM アプリのトラブルシューティング](apps-on-arm-troubleshooting-arm32.md)|ARM、およびその解決方法で実行されているときに、ARM32 および ARM64 のアプリの一般的な問題です。 |
|[ARM でプログラムの互換性のトラブルシューティング](apps-on-arm-program-compat-troubleshooter.md)|アプリが ARM で正しく動作しない場合に互換性の設定を調整するためのガイダンス。 |

## <a name="related-topics"></a>関連トピック
|トピック | 説明 |
|-----|-----|
|[ARM64 ドライバー WDK で構築](https://docs.microsoft.com/en-us/windows-hardware/drivers/develop/building-arm64-drivers)|ARM64 ドライバーをビルドするための手順。 |
| [X86 のデバッグ ARM 上のアプリ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64) | ARM で x86 アプリをデバッグするためのガイダンス。 |
