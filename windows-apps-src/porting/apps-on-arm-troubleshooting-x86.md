---
title: x86 デスクトップ アプリのトラブルシューティング
description: ARM で実行する際の x86 アプリの一般的な問題とその解決方法。
ms.author: misatran
ms.date: 05/09/2018
ms.topic: article
keywords: windows 10 s, 常時接続, ARM での x86 エミュレーション, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 01ef13f6f27b45a4cc41244e4ebed0a54804fc8e
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6048083"
---
# <a name="troubleshooting-x86-desktop-apps"></a>x86 デスクトップ アプリのトラブルシューティング
>[!IMPORTANT]
> ARM64 SDK は、現在 Visual Studio 15.8 Preview 1 の一部として利用できます。 アプリがフル ネイティブ速度で実行されるように、アプリを ARM64 に再コンパイルすることをお勧めします。 詳細については、「[ARM 開発での Windows 10 の Visual Studio サポートの初期プレビュー](https://blogs.windows.com/buildingapps/2018/05/08/visual-studio-support-for-windows-10-on-arm-development/)」に関するブログ記事を参照してください。

x86 デスクトップ アプリが x86 コンピューターで実行したときのように動作しない場合、トラブルシューティングに役立つガイダンスを次に示します。

|問題|解決策|
|-----|--------|
| アプリが ARM 用に設計されていないドライバーに依存している。 | x86 ドライバーを ARM64 に再コンパイルします。 「[WDK を使った ARM64 ドライバーのビルド](https://docs.microsoft.com/en-us/windows-hardware/drivers/develop/building-arm64-drivers)」をご覧ください。 |
| アプリが x64 でしか使用できない。 | Microsoft Store 向けに開発する場合、ARM バージョンのアプリを提出します。 詳細については、「[アプリ パッケージのアーキテクチャ](../packaging/device-architecture.md)」を参照してください。 Win32 開発者の場合、アプリを ARM64 に再コンパイルすることをお勧めします。 詳細については、「[ARM 開発での Windows 10 の Visual Studio サポートの初期プレビュー](https://blogs.windows.com/buildingapps/2018/05/08/visual-studio-support-for-windows-10-on-arm-development/)」に関するブログ記事を参照してください。 |
| アプリで OpenGL バージョン 1.1 以降が使用されているか、ハードウェア アクセラレータによる OpenGL を必要としている。 | 利用可能な場合は、アプリの DirectX モードを使用します。 DirectX 9、DirectX 10、DirectX 11、DirectX 12 を使う x86 アプリは ARM で動作します。 詳しくは、「[DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/en-us/library/windows/desktop/ee663274(v=vs.85).aspx)」をご覧ください。 |
| x86 アプリが期待どおりに動作しない。 | 「[プログラム互換性のトラブルシューティング ツール (ARM)](apps-on-arm-program-compat-troubleshooter.md)」のガイダンスに従って、互換性トラブルシューティング ツールを使ってみてください。 その他のトラブルシューティング手順については、「[ARM における x86 アプリのトラブルシューティング](apps-on-arm-troubleshooting-x86.md)」をご覧ください。 |

## <a name="best-practices-for-wow"></a>WOW のベスト プラクティス
アプリが WOW で実行されていることを検出するとある一般的な問題が発生し、x64 システムにあると想定します。 この想定に基づいて、アプリは次の操作を行う可能性があります。

- ARM でサポートされていない、アプリの x64 バージョンをインストールしようとします。
- ネイティブ レジストリ ビューでその他のソフトウェアをチェックします。
- 64 ビット .NET Framework が利用できると想定します。

一般に、アプリは WOW で実行されていると判断された場合、ホスト システムに関する想定を行いません。 可能な限り OS のネイティブ コンポーネントを操作しないようにしてください。

アプリは、ネイティブ レジストリ ビューにレジストリ キーを配置したり、WOW の存在に基づいて機能を実行したりする可能性があります。 元の **IsWow64Process** は、アプリが x64 コンピューターで実行されているかどうかのみ示しています。 アプリは [IsWow64Process2](https://msdn.microsoft.com/en-us/library/windows/desktop/mt804318(v=vs.85).aspx) を使って、WOW をサポートするシステムで実行されているかどうかを判断するようになりました。 

## <a name="drivers"></a>ドライバー 
すべてのカーネル モード ドライバー、[ユーザー モード ドライバー フレームワーク (UMDF)](https://docs.microsoft.com/windows-hardware/drivers/wdf/overview-of-the-umdf) ドライバー、印刷ドライバーが OS のアーキテクチャと一致するようにコンパイルする必要があります。 x86 アプリにドライバーがある場合、そのドライバーを ARM64 用に再コンパイルする必要があります。 x86 アプリはエミュレーション下で適切に実行される可能性がありますが、そのドライバーは ARM64 用に再コンパイルする必要があり、ドライバーに依存するアプリ エクスペリエンスは利用できなくなります。 ARM64 用ドライバーのコンパイルについて詳しくは、「[WDK を使った ARM64 ドライバーのビルド](https://docs.microsoft.com/windows-hardware/drivers/develop/building-arm64-drivers)」をご覧ください。

## <a name="shell-extensions"></a>シェル拡張 
Windows コンポーネントをフックしたり、DLL を Windows プロセスに読み込んだりしようとするアプリは、それらの DLL を再コンパイルしてシステムのアーキテクチャ (つまり、ARM64) と一致させる必要があります。 通常、これらは入力方式エディター (IME)、支援技術、シェル拡張アプリによって使用されます (例: エクスプローラーでクラウド記憶域アイコンを表示したり、コンテキスト メニューを右クリックしたりするなど)。 アプリを DLL または ARM64 に再コンパイルする方法については、「[ARM 開発での Windows 10 の Visual Studio サポートの初期プレビュー](https://blogs.windows.com/buildingapps/2018/05/08/visual-studio-support-for-windows-10-on-arm-development/)」に関するブログ記事を参照してください。 

## <a name="debugging"></a>デバッグ
アプリの動作をより詳しく調査するには、[ARM でのデバッグに関するページ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64)で、ARM でデバッグするためのツールと戦略について参照してください。

## <a name="virtual-machines"></a>仮想マシン
Windows ハイパーバイザー プラットフォームは、Qualcomm の Snapdragon 835 モバイル PC プラットフォームでサポートされていません。 したがって、Hyper-V を使った仮想マシンの実行は機能しません。 将来の Qualcomm チップセットでは、これらのテクノロジへの投資が続けられます。 