---
title: ARM でのアプリとエクスペリエンスの制限事項
author: msatranjr
description: ARM で正しく動作しないアプリのトラブルシューティング手順。
ms.author: misatran
ms.date: 02/15/2018
ms.topic: article
keywords: windows 10 s, 常時接続, 制限事項, ARM 版 windows 10
ms.localizationpriority: medium
redirect_url: https://docs.microsoft.com/en-us/windows/uwp/porting/apps-on-arm-troubleshooting-x86
ms.openlocfilehash: 24afc8a876b976f21d0f4ebd5892ceef7c403018
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6025873"
---
# <a name="limitations-of-apps-and-experiences-on-arm"></a>ARM でのアプリとエクスペリエンスの制限事項
ARM 版 Windows 10 には、次の必須の制限事項があります。

- **ARM64 ドライバーだけがサポートされます**。 すべてのアーキテクチャと同様、カーネル モード ドライバー、[ユーザー モード ドライバー フレームワーク (UMDF)](https://docs.microsoft.com/en-us/windows-hardware/drivers/wdf/overview-of-the-umdf) ドライバー、印刷ドライバーが OS のアーキテクチャと一致するようにコンパイルする必要があります。 ARM OS には x86 ユーザー モード アプリをエミュレートする機能がありますが、他のアーキテクチャ (x64 や x86 など) に実装されるドライバーは現在のところエミュレートされないため、このプラットフォームではサポートされません。 独自のカスタム ドライバーと連動するアプリはすべて、ARM64 に移植する必要があります。 限られたシナリオでは、アプリがエミュレーション下で x86 として実行される可能性がありますが、アプリのドライバー部分は ARM64 に移植する必要があります。 ARM64 用ドライバーのコンパイルについて詳しくは、「[WDK を使った ARM64 ドライバーのビルド](https://review.docs.microsoft.com/en-us/windows-hardware/drivers/develop/building-arm64-drivers?branch=rs4-arm64)」をご覧ください。

- **x64 アプリはサポートされません**。 ARM 版 Windows 10 では、x64 アプリのエミュレーションがサポートされません。

- **特定のゲームは動作しません**。 OpenGL 1.1 以降のバージョンを使うか、ハードウェア アクセラレータによる OpenGL を必要とするゲームとアプリは機能しません。 さらに、"アンチチート" ドライバーに依存するゲームはこのプラットフォームではサポートされません。

- **Windows のエクスペリエンスをカスタマイズするアプリが正しく機能しない可能性があります**。 ネイティブ OS コンポーネントは、ネイティブではないコンポーネントを読み込むことができません。 通常これを行うアプリの例として、入力方式エディター (IME)、支援技術、クラウド ストレージ アプリなどがあります。 IME と支援技術は多くの場合、アプリ機能の大部分を入力スタップにフックします。 クラウド ストレージ アプリは一般にシェル拡張を使います (たとえば、エクスプローラーのアイコンや右クリック メニューへの追加)。そのシェル拡張は失敗する可能性があり、失敗が適切に処理されない場合、アプリ自体がまったく動作しない可能性があります。

- **ARM ベースのデバイスすべてがモバイル バージョンの Windows を実行していることを前提としているアプリは正しく機能しない可能性があります**。 この前提を持つアプリは、間違った方法で表示される、予期しない UI レイアウトまたはレンダリングが表示される、コントラクトを利用できるかどうかを最初にテストしないとモバイル専用 API を呼び出そうとするときにまったく起動できないなどの可能性があります。

- **Windows ハイパーバイザー プラットフォームは ARM でサポートされません**。 ARM デバイスでの Hyper-V を使った仮想マシンの実行は機能しません。

次の表に、いくつかの一般的な問題を示し、問題を解決する方法についての提案を示します。

|問題|解決策|
|-----|--------|
| アプリが ARM 用に設計されていないドライバーに依存している。 | x86 ドライバーを ARM64 に再コンパイルします。 「[WDK を使った ARM64 ドライバーのビルド](https://docs.microsoft.com/en-us/windows-hardware/drivers/develop/building-arm64-drivers)」をご覧ください。 |
| アプリが x64 でしか使用できない。 | Microsoft Store 向けに開発する場合、ARM バージョンのアプリを提出します。 詳しくは、「[アプリ パッケージのアーキテクチャ](../packaging/device-architecture.md)」をご覧ください。 Win32 開発者の場合、x86 バージョンのアプリを配布します。 |
| アプリで OpenGL バージョン 1.1 以降が使用されているか、ハードウェア アクセラレータによる OpenGL を必要としている。 | DirectX 9、DirectX 10、DirectX 11、DirectX 12 を使う x86 アプリは ARM で動作します。 詳しくは、「[DirectX のグラフィックスとゲーミング](https://msdn.microsoft.com/en-us/library/windows/desktop/ee663274(v=vs.85).aspx)」をご覧ください。 |
| x86 アプリが期待どおりに動作しない。 | 「[プログラム互換性のトラブルシューティング ツール (ARM)](apps-on-arm-program-compat-troubleshooter.md)」のガイダンスに従って、互換性トラブルシューティング ツールを使ってみてください。 その他のトラブルシューティング手順については、「[ARM における x86 アプリのトラブルシューティング](apps-on-arm-troubleshooting-x86.md)」をご覧ください。 |
| x86 アプリが、ARM で実行されていることを検出しない。 | [IsWow64Process2](https://msdn.microsoft.com/en-us/library/windows/desktop/mt804318(v=vs.85).aspx) を使って、アプリが ARM で実行されているかどうかを調べてください。 |
| UWP ARM32 アプリが期待どおりに動作しない。 | アプリを ARM で正しく実行する方法については、「[ARM における ARM32 アプリのトラブルシューティング](apps-on-arm-troubleshooting-arm32.md)」をご覧ください。 |
